using Business.Apstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Wep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : Controller
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;
        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            string path = _webHostEnvironment.WebRootPath + "\\Images\\";
            var newGuidPath = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fileStream = System.IO.File.Create(path + newGuidPath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            if (file == null)
            {
                carImage.ImagePath = path + "default.png";
            }

            var result = _carImageService.Add(new CarImage
            {
                CarId = carImage.CarId,
                Date = DateTime.Now,
                ImagePath = newGuidPath
            });

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _carImageService.GetAll();
            if (result.Success == true)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);



        }
    }
}
