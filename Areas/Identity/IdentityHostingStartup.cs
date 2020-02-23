using System;
using Issue_Tracker_MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Issue_Tracker_MVC.Areas.Identity.IdentityHostingStartup))]
namespace Issue_Tracker_MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Issue_Tracker_IdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Issue_Tracker_IdentityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Issue_Tracker_IdentityContext>();
            });
        }
    }
}