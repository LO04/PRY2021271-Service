using Montrac.api.DataObjects.User;
using Montrac.Domain.DataObjects;
using Montrac.Domain.DataObjects.Invitation;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Montrac.Domain.Models
{
    public class User : AuditModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string Token { get; set; }

        public GuestUsers Manager { get; set; }
        public int? ManagerId { get; set; }
        //public ICollection<Area> Areas { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<InvitationRequest> Invitations { get; set; }
        public ICollection<Screenshot> Screenshots { get; set; }
        public ICollection<Program> Programs { get; set; }
        public ICollection<Url> Urls { get; set; }

        public User()
        {
            Users = new HashSet<User>();
            Invitations = new HashSet<InvitationRequest>();
            Screenshots = new HashSet<Screenshot>();
            Programs = new HashSet<Program>();
            Urls = new HashSet<Url>();
        }
    }
}