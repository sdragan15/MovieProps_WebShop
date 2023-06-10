using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MovieProps.BLL.Contract.Services;
using MovieProps.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Services
{
    public class ImageService : IImageService
    {
        IHttpContextAccessor _httpContext;
        IWebHostEnvironment _env;

        public ImageService(IHttpContextAccessor httpContext, IWebHostEnvironment environment)
        {
            _httpContext = httpContext;
            _env = environment;
        }

        public async Task<ResponsePackage<string>> SaveImage(IFormFile formFile)
        {
            if(formFile == null || formFile.Length == 0)
            {
                return new ResponsePackage<string>(Shared.Constants.StatusCode.BAD_REQUEST, "Image not sent");
            }

            string uniqueName = Guid.NewGuid().ToString() + "_" + formFile.FileName;

            string imagePath = Path.Combine(_env.ContentRootPath, "Images");
            Directory.CreateDirectory(imagePath);

            string filePath = Path.Combine(imagePath, uniqueName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            string imageUrl = "/Images/" + uniqueName;

            string baseUrl = $"{_httpContext.HttpContext.Request.Scheme}://{_httpContext.HttpContext.Request.Host}";
            string pathForDb = imageUrl;
            string result = baseUrl + pathForDb;

            return new ResponsePackage<string>()
            {
                Data = result
            };
        }
    }
}
