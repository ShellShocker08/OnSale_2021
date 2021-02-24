using OnSale.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnSale.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
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
