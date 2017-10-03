using AgilizaScrum.EntityFramework;
using EntityFramework.DynamicFilters;

namespace AgilizaScrum.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly AgilizaScrumDbContext _context;

        public InitialHostDbBuilder(AgilizaScrumDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
