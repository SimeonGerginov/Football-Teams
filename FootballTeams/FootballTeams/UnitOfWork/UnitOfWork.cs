using System;

using FootballTeams.Data;
using FootballTeams.UnitOfWork.Contracts;

namespace FootballTeams.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FootballTeamsContext context;

        public UnitOfWork(FootballTeamsContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }

            this.context = context;
        }

        public void Complete()
        {
            if (!this.context.ChangeTracker.HasChanges())
            {
                return;
            }

            this.context.SaveChanges();
        }
    }
}
