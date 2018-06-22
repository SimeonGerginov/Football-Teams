using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using FootballTeams.Data;
using FootballTeams.Repositories.Contracts;

using Microsoft.EntityFrameworkCore;

namespace FootballTeams.Repositories
{
    public class EfCoreRepository<T> : IRepository<T> 
        where T : class
    {
        private readonly DbSet<T> set;
        private readonly FootballTeamsContext context;

        public EfCoreRepository(FootballTeamsContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("Context is null !");
            }

            this.context = context;
            this.set = this.context.Set<T>();
        }

        public T GetById(int id)
        {
            return this.set.Find(id);
        }

        public IEnumerable<T> GetAllAndIncludeEntities(string entity, string[] entitiesToInclude)
        {
            // Include City, Country and President if entity is team.
            if (entity == "team")
            {
                return this.set
                    .Include(entitiesToInclude[0])
                    .Include(entitiesToInclude[1])
                    .Include(entitiesToInclude[2])
                    .Include(entitiesToInclude[3])
                    .AsEnumerable();
            }
            else
            {
                return this.set
                    .AsEnumerable();
            }
        }

        public IEnumerable<T> GetAllFiltered(Expression<Func<T, bool>> filterExpression)
        {
            return this.set
                .Where(filterExpression)
                .AsEnumerable();
        }

        public IEnumerable<T> GetAllOrdered(Func<T, object> orderByFunc)
        {
            return this.set
                .OrderBy(orderByFunc)
                .AsEnumerable();
        }

        public void Add(T entity)
        {
            this.set.Add(entity);
        }
    }
}
