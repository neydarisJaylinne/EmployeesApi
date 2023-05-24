namespace WebAPI.Models
{
    public class ResponseEmployee
    {
        public string Status { get; set; }
        public string? Message { get; set; }
        public Employee? Employee { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
