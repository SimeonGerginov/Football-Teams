using System.Collections.Generic;

namespace FootballTeams.Repositories.Contracts
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        void Add(T entity);
    }
}
