//Задание
//Создайте веб приложение и фильтр действия, который будет записывать в файл имя метода действия и время обращения к нему.
//При этом фильтр может быть применен к любому методу действия приложения.

//Задание 1
//Создайте фильтр, который будет считать количество уникальных пользователей, выполнивших запрос к веб приложению.
//Информацию о количестве пользователей фильтр должен записывать в файл.
using AspLesson9.Infrastructure;
using AspLesson9.Services;

namespace AspLesson9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddMemoryCache();
            builder.Services.AddSession();
            builder.Services.AddTransient<ActionInfoAttribute>();
            builder.Services.AddTransient<Saver>();
            builder.Services.AddControllersWithViews().AddMvcOptions(option =>
            {
                option.Filters.Add<ActionUserCountAttribute>();
                option.Filters.Add<ActionInfoAttribute>();
            });
            var app = builder.Build();
            app.UseRouting();

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default","{controller=home}/{action=index}");
            });

            app.Run();
        }
    }
}