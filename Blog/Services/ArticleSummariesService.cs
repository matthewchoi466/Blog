using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domain.Models;
using Blog.Domain.Repositories;
using Blog.Domain.Services;

namespace Blog.Services
{
	public class ArticleSummariesService : IArticleSummariesService
	{
		private readonly IArticleRepository articleRepository;

		public ArticleSummariesService(IArticleRepository articleRepository)
		{
			this.articleRepository = articleRepository;
		}

		public async Task<IEnumerable<Article>> ListAsync()
		{
			return await articleRepository.ListAsync();
	    }
	}
}
