using Montrac.api.DataObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.DataObjects.Url
{
    public class NewUrl
    {
        public int Id { get; set; }
        public string Uri { get; set; }
        public string Description { get; set; }
        public string Browser { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
