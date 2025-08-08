using CarManufacturersMVC.Models;

namespace CarManufacturersMVC.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Manufacturers.Any())
            {
                return;
            }

            var manufacturers = new Manufacturer[]
            {
                new Manufacturer
                {
                    Name = "Rayfield",
                    Country = "Соединённое Королевство",
                },
                new Manufacturer
                {
                    Name = "Quadra",
                    Country = "НСША",
                },
                new Manufacturer
                {
                    Name = "Mizutani",
                    Country = "Япония",
                },
                new Manufacturer
                {
                    Name = "Archer",
                    Country = "Китай",
                },
                new Manufacturer
                {
                    Name = "Villefort",
                    Country = "НСША",
                }
            };

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            var cars = new Car[]
            {
                new Car
                {
                    Name = "Rayfield Caliburn",
                    Class = "Гиперкар",
                    Model = "Caliburn",
                    Country = "Соединённое Королевство",
                    ProductionYears = "2070",
                    PhotoUrl = "images/photo_cars/rayfield_caliburn.jpg",
                    ManufacturerId = manufacturers[0].Id
                },
                new Car
                {
                    Name = "Quadra Type-66 \"Cthulhu\"",
                    Class = "Спортивный автомобиль",
                    Model = "Type-66",
                    Country = "НСША",
                    ProductionYears = "2070-е",
                    PhotoUrl = "images/photo_cars/quadra_type66_cthulhu.jpg",
                    ManufacturerId = manufacturers[1].Id
                },
                new Car
                {
                    Name = "Mizutani Shion \"Coyote\"",
                    Class = "Спортивный автомобиль",
                    Model = "Shion",
                    Country = "Япония",
                    ProductionYears = "2060-е",
                    PhotoUrl = "images/photo_cars/mizutani_shion_coyote.jpg",
                    ManufacturerId = manufacturers[2].Id
                },
                new Car
                {
                    Name = "Archer Quartz \"Bandit\"",
                    Class = "Спортивный автомобиль",
                    Model = "Quartz",
                    Country = "Китай",
                    ProductionYears = "2041–2077",
                    PhotoUrl = "images/photo_cars/archer_quartz_bandit.jpg",
                    ManufacturerId = manufacturers[3].Id
                },
                new Car
                {
                    Name = "Villefort Alvarado V4F 570 \"Delegate\"",
                    Class = "Лимузин",
                    Model = "Alvarado",
                    Country = "НСША",
                    ProductionYears = "2044",
                    PhotoUrl = "images/photo_cars/villefort_alvarado_delegate.jpg",
                    ManufacturerId = manufacturers[4].Id
                }
            };

            context.Cars.AddRange(cars);
            context.SaveChanges();
        }
    }
} 