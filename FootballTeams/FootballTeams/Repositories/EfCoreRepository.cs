using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<T> GetAll()
        {
            return this.set.AsEnumerable();
        }

        public void Add(T entity)
        {
            this.set.Add(entity);
        }
    }
}
