using Microsoft.AspNetCore.Http;

namespace Medical.Core.Interfaces
{
    public interface IImageRepository
    {
        public Task<string> AddImageAsync(IFormFile imagefile, string phone, string role);

        public Task<string> AddVedioAsync(IFormFile vediofile, string phone);

        public Task<string> UpdateImages(IFormFile imagefile, string imagename, string role);

    }
}
