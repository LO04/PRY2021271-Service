using Montrac.api.DataObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.DataObjects.Screenshot
{
    public class NewScreenshot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Blob { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
