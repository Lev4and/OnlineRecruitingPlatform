using Microsoft.EntityFrameworkCore;
using OnlineRecruitingPlatform.Model.Database;
using OnlineRecruitingPlatform.Model.Database.Repositories.EntityFramework;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.Importers
{
    public abstract class Importer
    {
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;

        private readonly OnlineRecruitingPlatformDbContext _context;
        private protected readonly DataManager _dataManager;

        public ImportStatus Status { get; private protected set; }

        public ImportTimer Timer { get; private protected set; }

        public ImportProgress Progress { get; private protected set; }

        public Importer()
        {
            Status = ImportStatus.NotStarted;

            Timer = new ImportTimer();
            Progress = new ImportProgress();

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
                new EFIndustriesRepository(_context),
                new EFLanguagesRepository(_context),
                new EFLanguageLevelsRepository(_context),
                new EFSkillsRepository(_context),
                new EFSubIndustriesRepository(_context),
                new EFIdentityRolesRepository(_context));
        }

        public bool IsRunning()
        {
            return Status != ImportStatus.NotStarted && Status != ImportStatus.Stopped && Status != ImportStatus.Completed;
        }

        public async Task Start()
        {
            Timer.Start();

            Status = ImportStatus.Started;

            await Import(_cancellationToken);
        }

        public async Task Start(int minValueId = 0, int maxValueId = int.MaxValue)
        {
            Timer.Start();

            Status = ImportStatus.Started;

            await Import(_cancellationToken, minValueId, maxValueId);
        }

        public void Stop()
        {
            Timer.Stop();
            Progress.Reset();

            Status = ImportStatus.Stopped;

            _cancellationTokenSource.Cancel();
        }

        private protected virtual async Task Import(CancellationToken cancellationToken)
        {

        }

        private protected virtual async Task Import(CancellationToken cancellationToken, int minValueId = 0, int maxValueId = int.MaxValue)
        {

        }
    }
}
