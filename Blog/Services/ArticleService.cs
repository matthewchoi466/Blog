using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domain.Models;
using Blog.Domain.Repositories;
using Blog.Domain.Services;
using Blog.Domain.Services.Communication;
using SimplePatch;

namespace Blog.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository articleRepository;
        private readonly IUnitOfWork unitOfWork;

        public ArticleService(IArticleRepository articleRepository, IUnitOfWork unitOfWork)
        {
            this.articleRepository = articleRepository;
            this.unitOfWork = unitOfWork;
        }
        
        public async Task<ArticleResponse> GetAsync(int id)
        {
            var article = await articleRepository.FindByIdAsync(id);

            if (article == null)
                return new ArticleResponse($"An error occurred when getting the article: {id}");
            else
                return new ArticleResponse(article);
        }

        public async Task<IEnumerable<Article>> ListAsync()
        {
            return await articleRepository.ListAsync();
        }

        public async Task<ArticleResponse> SaveAsync(Article article)
        {
            try
            {
                await articleRepository.AddAsync(article);
                await unitOfWork.CompleteAsync();

                return new ArticleResponse(article);
            }
            catch(Exception ex)
            {
                return new ArticleResponse($"An error occurred when saving the article: { ex.Message }");
            }
        }

        public async Task<ArticleResponse> SaveChangesAsync(Article article, Delta<Article> changesOfArticle)
        {
            try
            {
                await articleRepository.SaveChangesAsync(article, changesOfArticle);

                return new ArticleResponse(article);
            }
            catch (Exception ex)
            {
                return new ArticleResponse($"An error occurred when saving the changes to article: { ex.Message }");
            }
        }
    }
}
