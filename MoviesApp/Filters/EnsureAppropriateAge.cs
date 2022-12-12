using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MoviesApp.Filters
{
    public class EnsureAppropriateAge: Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var formDate = DateTime.Parse(context.HttpContext.Request.Form["BirthDate"]);
            var age = Years(formDate, DateTime.Now);
            if (age < 7 | age > 99 )
            {
                context.Result = new BadRequestResult();
            }
        }
        
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
        
        private int Years(DateTime start, DateTime end)
        {
            return (end.Year - start.Year - 1) +
                   (((end.Month > start.Month) ||
                     ((end.Month == start.Month) && (end.Day >= start.Day))) ? 1 : 0);
        }
    }
}