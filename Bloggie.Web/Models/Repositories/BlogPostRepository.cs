using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Models.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly bloggieDbContext bloggieDbContext;

        public BlogPostRepository(bloggieDbContext bloggieDbContext)
        {
            this.bloggieDbContext = bloggieDbContext;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogpost)
        {
            await bloggieDbContext.AddAsync(blogpost);
            await bloggieDbContext.SaveChangesAsync();
            return blogpost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingBlog = await bloggieDbContext.BlogPosts.FindAsync(id);

            if (existingBlog != null)
            {
                bloggieDbContext.BlogPosts.Remove(existingBlog);
                await bloggieDbContext.SaveChangesAsync();
                return existingBlog;
            }
            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await bloggieDbContext.BlogPosts.Include(x => x.Tags).ToListAsync();
        }
        
        public async Task<BlogPost?> GetAsync(Guid id)
        {
            return await bloggieDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> GetByUrlHandelAsync(string urlHandel)
        {
            return await bloggieDbContext.BlogPosts.Include(x=> x.Tags).FirstOrDefaultAsync(x=> x.UrlHandle == urlHandel);
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogpost)
        {
            var existingBlog =  await bloggieDbContext.BlogPosts.Include(x => x.Tags).FirstOrDefaultAsync(x => x.Id == blogpost.Id);

            if(existingBlog != null)
            {
                existingBlog.Id = blogpost.Id;
                existingBlog.Heading = blogpost.Heading;
                existingBlog.PageTitle = blogpost.PageTitle;
                existingBlog.Content = blogpost.Content;
                existingBlog.ShortDescription = blogpost.ShortDescription;
                existingBlog.Author = blogpost.Author;
                existingBlog.FeaturedImageUrl = blogpost.FeaturedImageUrl;
                existingBlog.UrlHandle = blogpost.UrlHandle;
                existingBlog.Visible = blogpost.Visible;
                existingBlog.PublishedDate = blogpost.PublishedDate;
                existingBlog.Tags = blogpost.Tags;
                
                await bloggieDbContext.SaveChangesAsync();
                return existingBlog;
            }
            return null;
        }
    }
}
