using OnSale.Common.Entities;
using OnSale.Common.Enums;
using OnSale.Web.Data.Entities;
using OnSale.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnSale.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();

            await CheckUserAsync("0001", "Marco", "Luna", "mlunac08@outlook.com", "55 123 4567", "Calle Luna Calle Sol", UserType.Admin);
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "México",
                    States = new List<State>
                {
                    new State
                    {
                        Name = "Querétaro",
                        Cities = new List<City>
                        {
                            new City { Name = "Querétaro" },
                            new City { Name = "Corregidora" },
                            new City { Name = "El Marqués" }
                        }
                    },
                    new State
                    {
                        Name = "San Luis Potosí",
                        Cities = new List<City>
                        {
                            new City { Name = "San Luis Potosí" },
                            new City { Name = "Xilitla" }
                        }
                    },
                    new State
                    {
                        Name = "Guanajuato",
                        Cities = new List<City>
                        {
                            new City { Name = "Guanajuato" },
                            new City { Name = "San Miguel de Allende" },
                            new City { Name = "León" }
                        }
                    }
                }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = new List<State>
                {
                    new State
                    {
                        Name = "Antioquia",
                        Cities = new List<City>
                        {
                            new City { Name = "Medellín" },
                            new City { Name = "Envigado" },
                            new City { Name = "Itagüi" }
                        }
                    },
                    new State
                    {
                        Name = "Bogotá",
                        Cities = new List<City>
                        {
                            new City { Name = "Bogotá" },                            
                        }
                    }
                }
                });
                await _context.SaveChangesAsync();
            }
        }
    }
}
