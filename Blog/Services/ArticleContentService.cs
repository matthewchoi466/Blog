using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domain.Models;
using Blog.Domain.Repositories;
using Blog.Domain.Services;

namespace Blog.Services
{
	public class ArticleContentService : IArticleContentService
    {
		private readonly IArticleRepository articleRepository;

		public ArticleContentService(IArticleRepository articleRepository)
		{
			this.articleRepository = articleRepository;
		}

        public async Task<Article> FindByIdAsync(int id)
        {
            return await articleRepository.FindByIdAsync(id);
        }

        public async Task<IEnumerable<Article>> ListAsync()
		{
			return await articleRepository.ListAsync();
	    }
	}
}