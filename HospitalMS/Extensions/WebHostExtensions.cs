using HospitalDemo.Seeders;
using HospitalMS.Data;
using HospitalMS.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMS.Extensions
{
    public static class WebHostExtensions
    {
        public static IHost Initialize(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {

               var services = scope.ServiceProvider;
                var context = services.GetRequiredService<HospitalContext>();
                context.Database.Migrate();

                var authContext = services.GetRequiredService<AuthContext>();
                authContext.Database.Migrate();

                new RoomSeeder(context).Seed();
                new PhysicianSeeder(context).Seed();
                new CountrySeeder(context).Seed();
                new PatientSeeder(context).Seed();
                new AdmissionSeeder(context).Seed();
                new DischargeSeeder(context).Seed();
                new SpecialtySeeder(context).Seed();
                new AppointmentSeeder(context).Seed();
            }
            return host;
        }
    }
}
