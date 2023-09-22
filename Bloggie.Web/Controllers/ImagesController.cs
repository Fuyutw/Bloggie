using Bloggie.Web.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bloggie.Web.Controllers
{
    
    [ApiController]
    
    public class ImagesController : ControllerBase
    {
        private readonly IImageRespository imageRespository;

        /*
[HttpGet]
public IActionResult Index()
{
return Ok("this is the GET Images API call");
}*/
        
        public ImagesController(IImageRespository imageRespository)
        {
            this.imageRespository = imageRespository;
        }
        [Route("api/images")]
        [Route("api/images/UploadAsync")]
        [HttpPost]
        public async Task<IActionResult> UploadAsync1126(IFormFile file)
        {
            // call a repository
            var imageURL = await imageRespository.UploadAsync(file);
            if (imageURL == null)
            {
                return Problem("Something went wrong!", null, (int)HttpStatusCode.InternalServerError);
            }
            return new JsonResult(new { link = imageURL });

        }


    }
    
   



}
