using AspLesson9.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspLesson9.Infrastructure
{
    public class ActionInfoAttribute : ActionFilterAttribute
    {
        Saver saver;
        public ActionInfoAttribute(Saver saver)
        {
            this.saver = saver;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            DateTime dateTime= DateTime.Now;
            string name = context.ActionDescriptor.DisplayName.Split('.')[3].Split(' ')[0];
            if (!string.IsNullOrEmpty(name))
            {
                saver.SaveActionName(name,dateTime);
            }
        }
    }
}
