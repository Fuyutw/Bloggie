using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Models.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        
        Task<BlogPost?> GetAsync(Guid id);

        Task<BlogPost?> GetByUrlHandelAsync(string urlHandel);
        
        Task<BlogPost> AddAsync(BlogPost blogpost);

        Task<BlogPost?> UpdateAsync(BlogPost blogpost);

        Task<BlogPost?> DeleteAsync(Guid id);    

    }
}
