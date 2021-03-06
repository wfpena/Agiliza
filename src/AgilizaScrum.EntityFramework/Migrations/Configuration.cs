using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using AgilizaScrum.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace AgilizaScrum.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<AgilizaScrum.EntityFramework.AgilizaScrumDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "AgilizaScrum";
        }

        protected override void Seed(AgilizaScrum.EntityFramework.AgilizaScrumDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
