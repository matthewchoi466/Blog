using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domain.Models;
using Blog.Domain.Services.Communication;
using SimplePatch;

namespace Blog.Domain.Services
{
    public interface IArticleService
    {

        Task<IEnumerable<Article>> ListAsync();
        Task<ArticleResponse> GetAsync(int id);
        Task<ArticleResponse> SaveAsync(Article article);
        Task<ArticleResponse> SaveChangesAsync(Article article, Delta<Article> changesOfArticle);
    }
}
