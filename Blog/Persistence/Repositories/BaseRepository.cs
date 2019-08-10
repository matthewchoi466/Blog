using Blog.Persistence.Contexts;

namespace Blog.Persistence.Repositories
{
    public abstract class BaseRepository
    {
		protected readonly AppDbContext context;
        public BaseRepository(AppDbContext context)
		{
			this.context = context;
		}
    }
}
