using Montrac.api.DataObjects.User;
using Montrac.Domain.DataObjects.Invitation;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Montrac.Domain.Models
{
    public class User : AuditModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string Token { get; set; }
        public User Manager { get; set; }
        public int? ManagerId { get; set; }
        public ICollection<User> Users { get; set; }
        //guest users are separated from the users that the manager is in 
        //charge of because this type of users still dont accept the invitation request
        public ICollection<GuestUsers> GuestUsers { get; set; }
        public ICollection<Area> Areas { get; set; }
        public ICollection<Screenshot> Screenshots { get; set; }
        public ICollection<Program> Programs { get; set; }
        public ICollection<Url> Urls { get; set; }
    }
}