using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using restaurant_booking_Domain.Common;
using restaurant_booking_Domain.Entities;
using restaurant_booking_Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace restaurant_booking_Infrastructure.SeederClass
{
    public class RbaSeeder
    {
        public static async Task SeedData(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            await Seeder(
                (UserManager<AppUsers>)serviceScope.ServiceProvider.GetService(typeof(UserManager<AppUsers>)),
                serviceScope.ServiceProvider.GetService<RbaContext>(),
                (RoleManager<IdentityRole>)serviceScope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>))
                );
        }
        private async static Task Seeder(UserManager<AppUsers> userManager, RbaContext context, RoleManager<IdentityRole> roleManager)
        {
            try
            {
                var baseDir = Directory.GetCurrentDirectory();

                await context.Database.EnsureCreatedAsync();
                if (!context.Users.Any())
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = UserRole.Admin.ToString() });
                    await roleManager.CreateAsync(new IdentityRole { Name = UserRole.Customer.ToString() });

                    var userList = new List<AppUsers>
                    {
                        new AppUsers
                        {
                            Id = "87a9ee6d-7d2e-4d90-a000-1246c1286080",
                            FirstName = "Samuel",
                            LastName = "Adeosun",
                            Email = "adeosunsamsamuel30@gmail.com",
                            UserName = "Allos",
                            PhoneNumber = "08165434179",
                            PasswordHash = "Password@123",
                            EmailConfirmed = true,
                            Avatar = null,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                            Customer = new Customer()
                            {
                                Address = "12 Hallway Road M3 4GR North London, UK",
                                AppUsersId = "87a9ee6d-7d2e-4d90-a000-1246c1286080"
                            }
                        },
                        new AppUsers
                        {
                            Id = "87a9ee6d-7d2e-4d90-a000-1fj40s2f091q",
                            FirstName = "Ayodeji",
                            LastName = "Adeosun",
                            Email = "adeosunsamuel30@gmail.com",
                            UserName = "deji",
                            PhoneNumber = "08143547856",
                            PasswordHash = "Password@123",
                            EmailConfirmed = true,
                            Avatar = null,
                            CreatedAt = DateTime.UtcNow,
                            UpdatedAt = DateTime.UtcNow,
                            Customer = new Customer()
                            {
                                Address = "43 Oxford Road M13 4GR Manchester, UK",
                                AppUsersId = "87a9ee6d-7d2e-4d90-a000-1fj40s2f091q"
                            }
                        },
                        
                    };

                    foreach (var user in userList)
                    {
                        await userManager.CreateAsync(user, user.PasswordHash);
                        if (user == userList[0])
                        {
                            await userManager.AddToRoleAsync(user, UserRole.Admin.ToString());
                        }
                        else
                            await userManager.AddToRoleAsync(user, UserRole.Customer.ToString());
                    }
                }

                if (!context.Meals.Any())
                {
                    var path = File.ReadAllText(FilePath(baseDir, "Json/Meal.json"));

                    var meal = JsonConvert.DeserializeObject<List<Meal>>(path);
                    await context.Meals.AddRangeAsync(meal);
                }
                if (!context.GadgetProducts.Any())
                {
                    var path = File.ReadAllText(FilePath(baseDir, "Json/Product.json"));

                    var gadgetProducts = JsonConvert.DeserializeObject<List<GadgetProduct>>(path);
                    await context.GadgetProducts.AddRangeAsync(gadgetProducts);
                }

                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        static string FilePath(string folderName, string fileName)
        {
            return Path.Combine(folderName, fileName);
        }
    }
}
