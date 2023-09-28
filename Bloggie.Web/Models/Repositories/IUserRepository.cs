using Microsoft.AspNetCore.Identity;

namespace Bloggie.Web.Models.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<IdentityUser>> GetAll();


	}
}
