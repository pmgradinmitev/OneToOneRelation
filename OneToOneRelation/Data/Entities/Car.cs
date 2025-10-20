namespace OneToOneRelation.Data.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Model { get; set; }

        // Navigation property
        public CarRegistration Registration { get; set; }
    }
}
