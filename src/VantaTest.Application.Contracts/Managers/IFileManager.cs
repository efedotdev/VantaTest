using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VantaTest.Headers;
using Volo.Abp.DependencyInjection;

namespace VantaTest.Managers
{
    public interface IFileManager : ITransientDependency
    {
        public Task<string> UpdateImagePath(IFormFile imageFile,string phsicalPath);
        public Task<string> CreateImagePath(IFormFile imageFile, string folderName);
        public Task DeleteImagePath(string pyshicalPath);
    }
}
