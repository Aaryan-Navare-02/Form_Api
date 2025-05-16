namespace Web_Api.Model.Entities
{
    public class Employee
    {
        public  int Id { get; set; }
        public required string Name { get; set; }

        public required string  Phone { get; set; }
        public required string Position { get; set; }
        public required string Office { get; set; }
        public int? Age  { get; set; }
        public decimal? Salary { get; set; }

       
    }
}
