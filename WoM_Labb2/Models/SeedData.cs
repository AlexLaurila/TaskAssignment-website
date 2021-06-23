using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoM_Labb2.Data;

namespace WoM_Labb2.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DatabaseContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DatabaseContext>>()))
            {
                if (context.Tasks.Any())
                {
                    return;
                }

                context.Tasks.Add(
                    new WoM_Labb2.Models.Tasks
                    {
                        Title = "Systemarkitekt webblabb 1",
                        Requirements = "Basic knowlegde in C#",
                        BeginDateTime = DateTime.Today,
                        DeadlineDateTime = DateTime.Today.AddDays(100)
                    });

                context.Tasks.Add(
                    new WoM_Labb2.Models.Tasks
                    {
                        Title = "Systemarkitekt webblabb 2",
                        Requirements = "Basic knowlegde in Python",
                        BeginDateTime = DateTime.Today,
                        DeadlineDateTime = DateTime.Today.AddDays(49)
                    });

                context.Tasks.Add(
                    new WoM_Labb2.Models.Tasks
                    {
                        Title = "Systemarkitekt webblabb 3",
                        Requirements = "Basic knowlegde in C++",
                        BeginDateTime = DateTime.Today,
                        DeadlineDateTime = DateTime.Today.AddDays(150)
                    });

                context.Users.Add(
                    new WoM_Labb2.Models.Users
                    {
                        FirstName = "Alex",
                        LastName = "Laurila"
                    });

                context.Users.Add(
                    new WoM_Labb2.Models.Users
                    {
                        FirstName = "Derp",
                        LastName = "Derpsson"
                    });

                context.SaveChanges();
            }
        }
    }
}
