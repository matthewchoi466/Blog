using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domain.Models;
using SimplePatch;


namespace Blog.Domain.Repositories
{
    public interface IArticleRepository
    {
		Task<IEnumerable<Article>> ListAsync();
        Task<Article> FindByIdAsync(int id);
        Task AddAsync(Article article);
        Task SaveChangesAsync(Article article, Delta<Article> changesOfArticle);
	}
}
