using OnlineRecruitingPlatform.Model.Database;

namespace OnlineRecruitingPlatform.Importers.ImportMethods
{
    public abstract class DbImportMethod : ImportMethod
    {
        private protected readonly DataManager _dataManager;

        public DbImportMethod(DataManager dataManager) : base()
        {
            _dataManager = dataManager;
        }

        public abstract void Save(object entity);
    }
}
