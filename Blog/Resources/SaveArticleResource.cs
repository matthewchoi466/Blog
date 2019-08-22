using System.ComponentModel.DataAnnotations;

namespace Blog.Resources
{
    public class SaveArticleResource
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string PublishedDateTime { get; set; }
    }
}
