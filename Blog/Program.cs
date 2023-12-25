using Blog.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Blog
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<BlogDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
            });
			builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BlogDbContext>();
            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllerRoute(
				name: "areas",
				pattern: "{area=exists}/{controller=Slider}/{action=Index}/{id?}");

            app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}