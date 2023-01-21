using Microsoft.EntityFrameworkCore;
using ProductHandler.Models;

namespace ProductHandler.Data
{
    internal class DbSeeder
    {
        internal static void Initialize(ProductHandlerContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.Products.Any()) return;

            var products = new ProductModel[]
            {
                new ProductModel{ Name = "Laptop", Description = "Lenovo ThinkPad X1 Carbon", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Tablet", Description = "iPad Pro 12.9-inch", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Smartphone", Description = "Samsung Galaxy S21", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Camera", Description = "Canon EOS R", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Headphones", Description = "Bose QuietComfort 35", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Speakers", Description = "Sonos One", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Watch", Description = "Apple Watch Series 6", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Fitness Tracker", Description = "Fitbit Charge 4", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Drone", Description = "DJI Mavic Air 2", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Vacuum", Description = "Roomba i7+", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Air Purifier", Description = "Dyson Pure Cool", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Lawn Mower", Description = "Husqvarna Automower", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Power Bank", Description = "Anker PowerCore 10000", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Smart Thermostat", Description = "Nest Learning Thermostat", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Security Camera", Description = "Ring Stick Up Cam", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Smart Lock", Description = "August Smart Lock Pro", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Smart Plug", Description = "Amazon Smart Plug", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Electric Toothbrush", Description = "Oral-B Genius X", CreatedDate = RandomDay() },
                new ProductModel{ Name = "Hair Dryer", Description = "Dyson Supersonic", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Blender", Description = "Vitamix A3500", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Coffee Maker", Description = "Breville Precision Brewer", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Rice Cooker", Description = "Zojirushi Neuro Fuzzy", CreatedDate = RandomDay()},
                new ProductModel{ Name = "Electric Kettle", Description = "Hamilton Beach FlexBrew", CreatedDate = RandomDay()}

            };

            foreach (var product in products)
                dbContext.Products.Add(product);

            dbContext.SaveChanges();
        }

        private static Random gen = new Random();
        private static DateTime RandomDay()
        {
            DateTime start = new DateTime(2020, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
