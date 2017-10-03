using System.Data.Common;
using Abp.Zero.EntityFramework;
using AgilizaScrum.Authorization.Roles;
using AgilizaScrum.Authorization.Users;
using AgilizaScrum.MultiTenancy;

namespace AgilizaScrum.EntityFramework
{
    public class AgilizaScrumDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public AgilizaScrumDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in AgilizaScrumDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of AgilizaScrumDbContext since ABP automatically handles it.
         */
        public AgilizaScrumDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public AgilizaScrumDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public AgilizaScrumDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
