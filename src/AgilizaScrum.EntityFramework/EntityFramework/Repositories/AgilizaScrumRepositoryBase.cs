﻿using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace AgilizaScrum.EntityFramework.Repositories
{
    public abstract class AgilizaScrumRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<AgilizaScrumDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected AgilizaScrumRepositoryBase(IDbContextProvider<AgilizaScrumDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class AgilizaScrumRepositoryBase<TEntity> : AgilizaScrumRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected AgilizaScrumRepositoryBase(IDbContextProvider<AgilizaScrumDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
