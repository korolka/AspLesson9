//�������
//�������� ��� ���������� � ������ ��������, ������� ����� ���������� � ���� ��� ������ �������� � ����� ��������� � ����.
//��� ���� ������ ����� ���� �������� � ������ ������ �������� ����������.

//������� 1
//�������� ������, ������� ����� ������� ���������� ���������� �������������, ����������� ������ � ��� ����������.
//���������� � ���������� ������������� ������ ������ ���������� � ����.
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