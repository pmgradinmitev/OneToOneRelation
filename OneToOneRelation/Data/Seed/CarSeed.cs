using Microsoft.EntityFrameworkCore;
using OneToOneRelation.Data;
using OneToOneRelation.Data.Entities;

namespace MuseumSearch.Data.Seed
{
    public class CarSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
            //Looks for any paintings. If no found, seeds the table.
            if (!context.Cars.Any())
            {
                var car1 = new Car
                {
                    Model = "Toyota Corolla",
                    Registration = new CarRegistration
                    {
                        PlateNumber = "ABC-1234"
                    }
                };

                var car2 = new Car
                {
                    Model = "Honda Civic",
                    Registration = new CarRegistration
                    {
                        PlateNumber = "XYZ-5678"
                    }
                };

                var car3 = new Car
                {
                    Model = "Ford Mustang",
                    Registration = new CarRegistration
                    {
                        PlateNumber = "MUS-9012"
                    }
                };

                context.Cars.AddRange(car1, car2, car3);
                context.SaveChanges();
            }
        }
    }
}
