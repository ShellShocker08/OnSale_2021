using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace OnSale.Web.Helpers
{
    public class ImageHelper : IImageHelper
    {
        public async Task<string> UploadImageAsync(IFormFile imageFile, string containerName)
        {
            string guid = Guid.NewGuid().ToString();
            string file = $"{guid}.jpg";
            string path = CreateFolder(containerName);

            path = Path.Combine(
                Directory.GetCurrentDirectory(),
                $"{path}",
                file);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            string folder = GetFolder(containerName);
            return $"~/img/{folder}/{file}";
        }

        public async Task<string> UpdateImageAsync(IFormFile imageFile, string containerName, bool saveLast, string oldPath)
        {
            if (saveLast)
            {
                //TODO: Historial Imagen
            }
            else
            {
                if(!String.IsNullOrEmpty(oldPath))
                {
                    DeleteImageAsync(oldPath);
                }
            }
            return await UploadImageAsync(imageFile, containerName);
        }

        public async Task<bool> DeleteImageAsync(string oldPath)
        {
            string path = oldPath.Replace("/", "\\").Replace("~", "wwwroot");
            path = Path.Combine(
                Directory.GetCurrentDirectory(),
                $"{path}");

            try
            {
                File.Delete(path);
                return true;
            }
            catch
            {
                //TODO: Log Image No Eliminada
                return false;
            }
        }

        private string CreateFolder(string containerName)
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            string folder = String.Empty;

            if (containerName != null)
            {
                folder = $"{year}\\{month}\\{day}\\{containerName}";
            }
            else
            {
                folder = $"{year}\\{month}\\{day}";
            }

            string path = Path.Combine(
                Directory.GetCurrentDirectory(),
                $"wwwroot\\img\\{folder}");

            Directory.CreateDirectory(path);

            return path;
        }

        private string GetFolder(string containerName)
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            string folder = String.Empty;

            if (containerName != null)
            {
                folder = $"{year}/{month}/{day}/{containerName}";
            }
            else
            {
                folder = $"{year}/{month}/{day}";
            }

            return folder;
        }
    }
}
