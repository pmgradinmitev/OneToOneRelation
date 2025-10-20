namespace OneToOneRelation.Data.Entities
{
    public class CarRegistration
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }

        // Foreign key
        public int CarId { get; set; }

        // Navigation property
        public Car Car { get; set; }
    }
}