using Montrac.api.DataObjects.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Montrac.Domain.DataObjects
{
    public class NewArea
    {
        public int Id { get; set; }
    }
    public class RegisterArea
    {
        public string Name { get; set; }
    }
    public class BasicAreaView
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
