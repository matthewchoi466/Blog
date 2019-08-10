using Blog.Domain.Models;

namespace Blog.Resources
{
    public class AuthorResource
    {
        public User Author { get; set; }
        public int AuthorUserID { get; set; }
    }
}
