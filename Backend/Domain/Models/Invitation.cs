namespace Montrac.API.Domain.Models
{
    public class Invitation : AuditModel
    {
        public bool Status { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int GuestId { get; set; }
        public int ManagerId { get; set; }
    }
}
