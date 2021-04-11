using OnlineRecruitingPlatform.Importers.API.HeadHunter.Directories;
using System;
using System.Threading;

namespace OnlineRecruitingPlatform.Importers.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var minValueId = 0;
            var maxValueId = int.MaxValue;
            var valuesPerUnitTime = 0;

            var readLine = "";

            var importer = new SkillsDirectoryImpoter();

            Console.Write("Укажите минимальный идентификатор записи: ");

            readLine = Console.ReadLine();

            try
            {
                if (int.Parse(readLine) > 0)
                {
                    minValueId = int.Parse(readLine);
                }
            }
            catch
            {

            }

            Console.Write("Укажите максимальный идентификатор записи: ");

            readLine = Console.ReadLine();

            try
            {
                if (int.Parse(readLine) > 0 && int.Parse(readLine) > minValueId)
                {
                    maxValueId = int.Parse(readLine);
                }
            }
            catch
            {

            }

            importer.Start(minValueId, maxValueId);

            Console.WriteLine($"[IMPORTER][{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Импорт начался");

            while (importer.IsRunning)
            {
                if(importer.Duration.TotalMinutes % 5 == 0 && importer.Duration.TotalMinutes != 0)
                {
                    Console.Clear();
                }

                var secondsLeft = (double)importer.CountFoundRecords - (double)importer.CountImportedRecords / (double)importer.CountImportedRecords - (double)valuesPerUnitTime;
                var timeLeft = new TimeSpan(0, 0, (int)(double.IsNaN(secondsLeft) ? 0 : secondsLeft));

                Console.WriteLine($"[IMPORTER][{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Прошло времени: {importer.Duration.ToString("h'h 'm'm 's's'")} Прогресс: {(double.IsNaN(importer.ProgressImport) ? 0.ToString("F5") : importer.ProgressImport.ToString("F5"))}% ({importer.CountImportedRecords.ToString("N")} / {importer.CountFoundRecords.ToString("N")}) Скорость: {(importer.CountImportedRecords - valuesPerUnitTime) * 8} Записей/сек Осталось: {timeLeft.ToString("h'h 'm'm 's's'")}");

                valuesPerUnitTime = importer.CountImportedRecords;

                Thread.Sleep(125);
            }

            Console.WriteLine($"[IMPORTER][{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Импорт завершен");

            Console.ReadKey();
        }
    }
}
