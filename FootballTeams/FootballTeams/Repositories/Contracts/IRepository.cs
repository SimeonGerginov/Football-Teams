using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FootballTeams.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAllAndIncludeEntities(IEnumerable<string> entitiesToInclude);

        IEnumerable<T> GetAllFiltered(Expression<Func<T, bool>> filterExpression);

        IEnumerable<T> GetAllOrdered(Func<T, object> orderByFunc);

        void Add(T entity);
    }
}
