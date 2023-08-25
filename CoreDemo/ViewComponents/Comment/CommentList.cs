using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    Id = 1,
                    UserName = "Mümtaz",
                },

                new UserComment
                {
                    Id = 2,
                    UserName = "Sinan",
                },

                new UserComment
                {
                    Id = 3,
                    UserName = "Aras",
                }
            };
            return View(commentValues);
        }
    }
}
