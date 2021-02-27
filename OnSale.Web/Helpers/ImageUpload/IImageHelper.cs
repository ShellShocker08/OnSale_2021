using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnSale.Web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile file, string containerName);
        Task<string> UpdateImageAsync(IFormFile file, string containerName, bool saveLast, string oldPath);
        Task<bool> DeleteImageAsync(string oldPath);
    }
}
