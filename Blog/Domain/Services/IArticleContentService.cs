using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domain.Models;

namespace Blog.Domain.Services
{
    public interface IArticleContentService
    {
        Task<Article> FindByIdAsync(int id);
    }
}
