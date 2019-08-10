using System;
namespace Blog.Domain.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDateTime { get; set; }
        public DateTime LastEditDateTime { get; set; }
        
        public int AuthorUserID { get; set; }
		public User Author { get; set; }
	}
}
