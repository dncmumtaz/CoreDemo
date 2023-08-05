using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    internal class Writer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Image { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
