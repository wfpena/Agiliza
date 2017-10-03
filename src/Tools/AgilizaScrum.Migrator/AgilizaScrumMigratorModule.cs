using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using AgilizaScrum.EntityFramework;

namespace AgilizaScrum.Migrator
{
    [DependsOn(typeof(AgilizaScrumDataModule))]
    public class AgilizaScrumMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<AgilizaScrumDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}