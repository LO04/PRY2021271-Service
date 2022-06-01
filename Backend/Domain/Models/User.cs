using System.Text.Json.Serialization;

namespace Montrac.API.Domain.Models
{
    public class User : AuditModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? ManagerId { get; set; }
        public ICollection<Program> Programs{ get; set; }
        public ICollection<Screenshot> Screenshots{ get; set; }
        public ICollection<Url> Urls{ get; set; }

        public User()
        {
            Identification = Guid.NewGuid().ToString("N");
            Programs = new HashSet<Program>();
            Screenshots = new HashSet<Screenshot>();
            Urls = new HashSet<Url>();
        }
    }
}