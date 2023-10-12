using Microsoft.AspNetCore.Mvc.Filters;

namespace AspLesson9.Infrastructure
{
    public class ActionUserCountAttribute:ActionFilterAttribute
    {
        private const string key = "userGuid";
        private const string path = "App_data/UserGuids.txt";
        private static int count;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Session.GetString(key)==null)
            {
                string guid = Guid.NewGuid().ToString();
                count++;
                context.HttpContext.Session.SetString(key, guid);

                StreamWriter writer = new StreamWriter(path, true);
                writer.WriteLine($"user {count}: {guid}");
                writer.WriteLine();
                writer.Close();
            }
        }
    }
}
