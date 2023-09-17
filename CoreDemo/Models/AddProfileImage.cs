using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;

namespace CoreDemo.Models
{
    public class AddProfileImage:BaseEntity
    {
        public string Name { get; set; }
        public string About { get; set; }
        public IFormFile Image { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
