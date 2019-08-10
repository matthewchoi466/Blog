using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Domain.Models;
using Blog.Domain.Repositories;
using Blog.Persistence.Contexts;
using SimplePatch;

namespace Blog.Persistence.Repositories
{
    public class ArticleRepository : BaseRepository, IArticleRepository
    {
        public ArticleRepository(AppDbContext context) : base(context)
	    {
	    }

	    public async Task<IEnumerable<Article>> ListAsync()
	    {
            return await context.Articles.Include(p => p.Author)
                .ToListAsync();
	    }

        public async Task<Article> FindByIdAsync(int id)
        {
            return await context.Articles.Include(p => p.Author)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Article article)
        {
            await context.Articles.AddAsync(article);
        }

        public async Task SaveChangesAsync(Article article, Delta<Article> changesOfArticle)
        {
            changesOfArticle.Patch(article);
            context.Entry(article).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
