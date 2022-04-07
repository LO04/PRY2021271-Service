using Montrac.api.DataObjects.User;
using Montrac.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.DataObjects.Invitation
{
    public class InvitationRequest : AuditModel
    {
        public bool IsAccepted { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public User Guest { get; set; }
        public int GuestId { get; set; }
        public User Manager { get; set; }
        public int ManagerId { get; set; }
    }
}
