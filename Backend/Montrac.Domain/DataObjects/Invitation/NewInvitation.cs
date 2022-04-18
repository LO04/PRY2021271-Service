using Montrac.api.DataObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.DataObjects.Invitation
{
    public class NewInvitation
    {
        public bool Status { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int GuestId { get; set; }
        public int ManagerId { get; set; }
    }
}
