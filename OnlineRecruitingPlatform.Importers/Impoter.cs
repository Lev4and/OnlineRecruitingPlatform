using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database;
using OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers
{
    public abstract class Impoter
    {
        public bool IsRunning { get; private protected set; }

        public int CountFoundRecords { get; private protected set; }

        public int CountImportedRecords { get; private protected set; }

        public double ProgressImport { get; private protected set; }

        public TimeSpan Duration { get; private protected set; }

        private DateTime _startDateTime;

        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;

        private readonly OnlineRecruitingPlatformDbContext _context;
        private protected readonly DataManager _dataManager;

        public Impoter()
        {
            IsRunning = false;

            ProgressImport = 0;
            CountFoundRecords = 0;
            CountImportedRecords = 0;

            _startDateTime = DateTime.Now;

            Duration = new TimeSpan();

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

            var optionsBuilder = new DbContextOptionsBuilder<OnlineRecruitingPlatformDbContext>();
            var options = optionsBuilder.UseSqlServer(@"Server=DESKTOP-9CDGA5B;Database=OnlineRecruitingPlatform;User ID=sa;Password=sa;Trusted_Connection=True;").Options;

            _context = new OnlineRecruitingPlatformDbContext(options);
            _dataManager = new DataManager(
                new EFApplicantCommentAccessTypesRepository(_context),
                new EFApplicantCommentsOrdersRepository(_context),
                new EFApplicantNegotiationStatusesRepository(_context),
                new EFBusinessTripReadinessTypesRepository(_context),
                new EFCurrenciesRepository(_context),
                new EFDriverLicenseTypesRepository(_context),
                new EFEducationLevelsRepository(_context),
                new EFEmployerActiveVacanciesOrdersRepository(_context),
                new EFEmployerArchivedVacanciesOrdersRepository(_context),
                new EFEmployerRelationsRepository(_context),
                new EFEmployerTypesRepository(_context),
                new EFEmploymentsRepository(_context),
                new EFExperiencesRepository(_context),
                new EFGendersRepository(_context),
                new EFLanguagesRepository(_context),
                new EFLanguageLevelsRepository(_context),
                new EFSkillsRepository(_context),
                new EFIdentityRolesRepository(_context));
        }

        public async Task Start(int minValueSkillId = 0, int maxValueSkillId = int.MaxValue)
        {
            new Thread(new ThreadStart(Timer)).Start();

            await Import(_cancellationToken, minValueSkillId, maxValueSkillId);
        }

        public void Stop()
        {
            _cancellationTokenSource.Cancel();
        }

        private void Timer()
        {
            IsRunning = true;

            ProgressImport = 0;
            CountFoundRecords = 0;
            CountImportedRecords = 0;

            _startDateTime = DateTime.Now;

            while (!_cancellationToken.IsCancellationRequested || IsRunning)
            {
                ProgressImport = (double)CountImportedRecords / (double)CountFoundRecords * (double)100;

                Duration = DateTime.Now - _startDateTime;

                Task.Delay(1000);
            }
        }

        private protected virtual async Task Import(CancellationToken cancellationToken, int minValueSkillId = 0, int maxValueSkillId = int.MaxValue)
        {

        }
    }
}
