using System;
using HospitalMS.Areas.Identity.Data;
using HospitalMS.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(HospitalMS.Areas.Identity.IdentityHostingStartup))]
namespace HospitalMS.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("HospitalConnectionString")));

                services.AddDefaultIdentity<ApplicationUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedEmail = false;
                    options.Password.RequireUppercase = false;
                }
                )
                    .AddEntityFrameworkStores<AuthContext>();
            });
        }
    }
}