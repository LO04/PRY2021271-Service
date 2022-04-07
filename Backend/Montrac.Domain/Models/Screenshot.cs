using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.Models
{
    public class Screenshot : AuditModel
    {
        public string Name { get; set; }
        public string Blob { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
