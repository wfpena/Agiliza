using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using AgilizaScrum.EntityFramework;

namespace AgilizaScrum
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(AgilizaScrumCoreModule))]
    public class AgilizaScrumDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<AgilizaScrumDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
