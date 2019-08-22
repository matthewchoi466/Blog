using Blog.Domain.Models;

namespace Blog.Domain.Services.Communication
{
    public class ArticleResponse : BaseResponse
    {
       public Article Article { get; private set; }

       private ArticleResponse(bool success, string message, Article article) : base(success, message)
        {
            Article = article;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="article">Saved article.</param>
        /// <returns>Response.</returns>
        public ArticleResponse(Article article) : this(true, string.Empty, article)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ArticleResponse(string message) : this(false, message, null)
        { }
    }
}
