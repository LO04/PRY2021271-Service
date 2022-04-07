using Montrac.api.DataObjects.User;
using System.Collections.Generic;

namespace Montrac.Domain.Models
{
    public class Area : AuditModel
    {
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public ICollection<GuestUsers> Users { get; set; }
    }
}
