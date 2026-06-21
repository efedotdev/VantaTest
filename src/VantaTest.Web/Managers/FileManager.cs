using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using VantaTest.Headers;
using VantaTest.Managers;

namespace VantaTest.Web.Managers
{
    public class FileManager : IFileManager
    {
        private readonly IWebHostEnvironment _env;
        public FileManager(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<string> UpdateImagePath(IFormFile imageFile, string pyshicalPath)
        {
            var directoryPath = Path.GetDirectoryName(pyshicalPath);
            var folderName = Path.GetFileName(directoryPath);
            var oldRelativePath = pyshicalPath.TrimStart('/');
            var oldPhysicalPath = Path.Combine(_env.WebRootPath, oldRelativePath);
            if (System.IO.File.Exists(oldPhysicalPath))
            {
                System.IO.File.Delete(oldPhysicalPath);
            }
            var extension = Path.GetExtension(imageFile.FileName);
            var newFileName = Guid.NewGuid().ToString() + extension;
            var folderPath = Path.Combine(_env.WebRootPath, "images", folderName);
            var exactFilePath = Path.Combine(folderPath, newFileName);
            using (var stream = new FileStream(exactFilePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            var newPath = $"/images/{folderName}/{newFileName}" ;
            return newPath;
        }
        public async Task<string> CreateImagePath(IFormFile imageFile,string folderName )
        {
            var extension = Path.GetExtension(imageFile.FileName);
            var newFileName = Guid.NewGuid().ToString() + extension;
            var folderPath = Path.Combine(_env.WebRootPath, "images", folderName);
            var exactFilePath = Path.Combine(folderPath, newFileName);
            using (var stream = new FileStream(exactFilePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            var newPath = $"/images/{folderName}/{newFileName}";
            return newPath;
        }
        public async Task DeleteImagePath(string pyshicalPath)
        {
            var oldRelativePath = pyshicalPath.TrimStart('/');
            var oldPhysicalPath = Path.Combine(_env.WebRootPath, oldRelativePath);
            if (System.IO.File.Exists(oldPhysicalPath))
            {
                System.IO.File.Delete(oldPhysicalPath);
            }
        } 
    }
}
