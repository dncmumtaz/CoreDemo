using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message2 : BaseEntity
    {
        public int? SenderId { get; set; }
        public int? RecieverId { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public bool Status { get; set; }
        public Writer SenderUser { get; set; }
        public Writer RecieverUser { get; set; }
    }
}
