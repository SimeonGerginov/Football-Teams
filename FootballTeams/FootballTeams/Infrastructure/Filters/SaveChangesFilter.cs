using System;
using FootballTeams.UnitOfWork.Contracts;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FootballTeams.Infrastructure.Filters
{
    public class SaveChangesFilter : IActionFilter
    {
        private readonly IUnitOfWork unitOfWork;

        public SaveChangesFilter(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException();
            }

            this.unitOfWork = unitOfWork;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Just to satisfy the interface. Cannot decouple from it.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            this.unitOfWork.Complete();
        }
    }
}
