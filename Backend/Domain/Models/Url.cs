namespace Montrac.API.Domain.Models
{
    public class Url : AuditModel
    {
        public string Uri { get; set; }
        public string Title { get; set; }
        public string Browser { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
