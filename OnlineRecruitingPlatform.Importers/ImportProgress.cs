namespace OnlineRecruitingPlatform.Importers
{
    public class ImportProgress
    {
        private int _countFoundRecords;
        private int _countImportedRecords;
        private readonly int _millisecondsDelay;

        public int CountFoundRecords 
        {
            get
            {
                return _countFoundRecords;
            }
            set
            {
                _countFoundRecords = value;

                Recalculate();
            }
        }

        public int CountImportedRecords
        {
            get
            {
                return _countImportedRecords;
            }
            set
            {
                _countImportedRecords = value;

                Recalculate();
            }
        }

        public double ProgressImport { get; private set; }

        public ImportProgress()
        {
            Reset();
        }

        public void Reset()
        {
            ProgressImport = 0;
            CountFoundRecords = 0;
            CountImportedRecords = 0;
        }

        private void Recalculate()
        {
            ProgressImport = (double)CountImportedRecords / (double)CountFoundRecords * (double)100;
        }
    }
}
