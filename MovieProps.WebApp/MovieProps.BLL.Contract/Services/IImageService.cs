using Microsoft.AspNetCore.Http;
using MovieProps.Shared.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieProps.BLL.Contract.Services
{
    public interface IImageService
    {
        Task<ResponsePackage<string>> SaveImage(IFormFile formFile);
        string LoadImage(string path);
    }
}
