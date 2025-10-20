using OneToOneRelation.Data.Entities;
using System.ComponentModel;

namespace OneToOneRelation.ViewModels
{
    public class CarViewModel
    {
        public int? CarId { get; set; }
        [DisplayName("Модел")]
        public string Model { get; set; }
        [DisplayName("Номер на рама")]
        public string PlateNumber { get; set; }

        public void MapTo(Car car)
        {
            car.Model = this.Model;
            if (car.Registration == null)
                car.Registration = new CarRegistration();

            car.Registration.PlateNumber = this.PlateNumber;
        }
        public void MapFrom(Car car)
        {
            CarId = car.Id;
            Model = car.Model;
            PlateNumber = car.Registration?.PlateNumber;
        }
    }
}
