using ASPNETLab2.Services;

namespace ASPNETLab2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //builder.Configuration
            //    .AddJsonFile("config.json")
            //    .AddXmlFile("config.xml")
            //    .AddIniFile("config.ini");

            builder.Configuration.AddJsonFile("aboutme.json");

            //builder.Services.AddTransient<CompanyService>();
            builder.Services.AddTransient<AboutMeService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();


        }
    }
}
