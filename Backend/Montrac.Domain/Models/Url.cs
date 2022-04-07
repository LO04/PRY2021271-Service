using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.Models
{
    public class Url : AuditModel
    {
        public string Uri { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public Url()
        {
            Date = DateTime.Now;
        }
    }
}
