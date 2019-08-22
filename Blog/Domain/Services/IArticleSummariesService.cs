using System.Collections.Generic;
using System.Threading.Tasks;
using Blog.Domain.Models;

namespace Blog.Domain.Services
{
    public interface IArticleSummariesService
    {
		Task<IEnumerable<Article>> ListAsync();
    }
}
