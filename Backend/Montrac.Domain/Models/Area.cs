using Montrac.api.DataObjects.User;
using System.Collections.Generic;

namespace Montrac.Domain.Models
{
    public class Area : AuditModel
    {
        public string Name { get; set; }
        public ICollection<BasicUserView> Users { get; set; }

        public Area()
        {
            Users = new HashSet<BasicUserView>();
        }
    }
}
