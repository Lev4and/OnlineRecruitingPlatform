using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers
{
    public class ImportTimer
    {
        private DateTime _startDateTime;
        private Thread _thread;

        public int MillisecondsDelay { get; }

        public TimeSpan Duration { get; private set; }

        public ImportTimer()
        {
            _startDateTime = new DateTime();
            _thread = new Thread(new ThreadStart(Tick));

            MillisecondsDelay = 1000;
            Duration = new TimeSpan();
        }

        public void Start()
        {
            _thread.Start();
        }

        public void Stop()
        {
            _thread.Abort();
        }

        private void Tick()
        {
            _startDateTime = DateTime.Now;

            while (_thread.ThreadState == ThreadState.Running)
            {
                Duration = DateTime.Now - _startDateTime;

                Task.Delay(MillisecondsDelay);
            }
        }
    }
}
