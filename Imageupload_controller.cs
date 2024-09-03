using image_p.DTO;
using image_p.Models;
using image_p.Repository.Interface;
using image_p.Service.ImplementaionService;
using image_p.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace image_p.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Image_controller : ControllerBase
    {
        private readonly Iimageservice iimageservice;

        public Image_controller(Iimageservice iimageservice)
        {
            this.iimageservice = iimageservice;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromForm] ImageDto imageDto)
        {
            if (imageDto.ImageUrl == null || imageDto.ImageUrl.Length == 0)
            {
                return BadRequest("No file uploaded");
            }

            await iimageservice.UploadImageAsync(imageDto);
            return Ok("Image uploaded successfully");
        }
    }
}
