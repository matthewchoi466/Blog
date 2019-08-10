using AutoMapper;
using Blog.Domain.Models;
using Blog.Resources;
using SimplePatch;

namespace Blog.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveArticleResource, Article>();
            CreateMap<AuthorResource, Article>();
            CreateMap<PatchArticleResource, Delta<Article>>();
        }
    }
}
