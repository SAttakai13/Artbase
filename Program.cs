using Artbase.Data;

namespace Artbase
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //These are for the database itself
            builder.Services.Configure<ArtbaseDatabaseSettings>(
                builder.Configuration.GetSection("Users"));

            //These are all for the multiple tables
            builder.Services.AddSingleton<UserAccountDAL>();
            builder.Services.AddSingleton<UserProfileDAL>();
            builder.Services.AddSingleton<UserPostDAL>();
            builder.Services.AddSingleton<UserCommentDAL>();
            builder.Services.AddSingleton<UserUploadDAL>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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