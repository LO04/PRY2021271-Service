namespace Montrac.API.Domain.Models
{
    public class Screenshot : AuditModel
    {
        public string Name { get; set; }
        public string Blob { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
