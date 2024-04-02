namespace MyEmployee.Models.Admin_Management
{
    public class ApplicationLog
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Level { get; set; }
    }
}
