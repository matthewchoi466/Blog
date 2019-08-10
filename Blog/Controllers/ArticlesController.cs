using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Blog.Domain.Models;
using Blog.Domain.Services;
using Blog.Extensions;
using Blog.Resources;
using SimplePatch;



namespace Blog.Controllers
{
    [Route("/api/[controller]")]
    public class ArticlesController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public ArticlesController(IArticleService articleService, IUserService userService, IMapper mapper)
        {
            this.articleService = articleService;
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ArticleSummaryResource>> GetAllAsync()
        {
            var articles = await articleService.ListAsync();
            var resources = mapper.Map<IEnumerable<Article>, IEnumerable<ArticleSummaryResource>>(articles);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await articleService.GetAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var articleContentResource = mapper.Map<Article, ArticleContentResource>(result.Article);

            return Ok(articleContentResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveArticleResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var authorResult = await userService.GetAsync(resource.AuthorName);

            if (!authorResult.Success)
                return BadRequest(authorResult.Message);

            var author = mapper.Map<User, AuthorResource>(authorResult.User);
            var article = mapper.Map<AuthorResource, Article>(author);
            mapper.Map(resource, article);

            var result = await articleService.SaveAsync(article);

            if (!result.Success)
                return BadRequest(result.Message);

            var articleContentResource = mapper.Map<Article, ArticleContentResource>(result.Article);

            return Ok(articleContentResource);
        }

        //Need to change delta article to delta of article content resources?
        //Cannot use delta due to no mapper
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAsync(int id, [FromBody] Delta<Article> resource)
        {
            var articleToPatch = await articleService.GetAsync(id);

            if (!articleToPatch.Success)
                return BadRequest(articleToPatch.Message);


            var result = await articleService.SaveChangesAsync(articleToPatch.Article, resource);


            if (!result.Success)
                return BadRequest(result.Message);

            var articleContentResource = mapper.Map<Article, ArticleContentResource>(result.Article);

            return Ok(articleContentResource);

        }
    }
}
