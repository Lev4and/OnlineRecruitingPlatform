namespace OnlineRecruitingPlatform.Importers
{
    public enum ImportStatus
    {
        NotStarted,
        Started,
        Stopped,
        SearchForARangeOfValidValues,
        DownloadFromAPI,
        SavingToDb,
        SavingToJsonFile,
        SavingToExcelFile,
        SavingToAccessFile,
        Completed
    }
}
