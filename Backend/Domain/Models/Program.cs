namespace Montrac.API.Domain.Models
{
    public class Program : AuditModel
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimeUsed { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
