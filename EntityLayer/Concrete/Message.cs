using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message: BaseEntity
    {
        public string Sender { get; set; }
        public string Reciever { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public bool Status { get; set; }

    }
}
