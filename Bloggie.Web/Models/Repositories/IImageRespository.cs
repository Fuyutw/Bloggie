namespace Bloggie.Web.Models.Repositories
{
    public interface IImageRespository
    {
        Task<string> UploadAsync(IFormFile file);


    }
}
