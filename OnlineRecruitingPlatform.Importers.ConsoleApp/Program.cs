using OnlineRecruitingPlatform.Importers.API.DaDataRu.OKVED2;
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

            var importer = new SubIndustriesImporter();

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

            //importer.Start(minValueId, maxValueId);
            importer.Start();

            Console.WriteLine($"[IMPORTER][{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Импорт начался");

            while (importer.IsRunning())
            {
                if(importer.Timer.Duration.TotalMinutes % 5 == 0 && importer.Timer.Duration.TotalMinutes != 0)
                {
                    Console.Clear();
                }

                var secondsLeft = ((double)importer.Progress.CountFoundRecords - (double)importer.Progress.CountImportedRecords) / ((double)importer.Progress.CountImportedRecords - (double)valuesPerUnitTime);
                var timeLeft = new TimeSpan(0, 0, (int)(double.IsNaN(secondsLeft) ? 0 : secondsLeft));

                Console.WriteLine($"[IMPORTER][{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Прошло времени: {importer.Timer.Duration.ToString("d'd 'h'h 'm'm 's's'")} Прогресс: {(double.IsNaN(importer.Progress.ProgressImport) ? 0.ToString("F5") : importer.Progress.ProgressImport.ToString("F5"))}% ({importer.Progress.CountImportedRecords.ToString("N")} / {importer.Progress.CountFoundRecords.ToString("N")}) Скорость: {importer.Progress.CountImportedRecords - valuesPerUnitTime} Записей/сек Осталось: {timeLeft.ToString("d'd 'h'h 'm'm 's's'")}");

                valuesPerUnitTime = importer.Progress.CountImportedRecords;

                Thread.Sleep(1000);
            }

            Console.WriteLine($"[IMPORTER][{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}] Импорт завершен");

            Console.ReadKey();
        }
    }
}
