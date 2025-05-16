namespace Web_Api.Model
{
    public class AddEmployeeDto
    {

       
        public required string Name { get; set; }

        public required string Phone { get; set; }
        public required string Position { get; set; }
        public required string Office { get; set; }
        public int? Age { get; set; }
        public decimal? Salary { get; set; }
    }
}
