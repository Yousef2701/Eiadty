using Medical.Core.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Medical.Core.Repositories
{
    public class ImageRepository: IImageRepository
    {
       

        public async Task<string> AddImageAsync(IFormFile imagefile, string phone,string role)
        {
            if (imagefile == null&&role=="UsersImages")
            { return "avatar.png"; }
            string imageUrl = phone+imagefile.FileName;
            string useresImages = Path.Combine(Environment.CurrentDirectory, role);
            string path = Path.Combine(useresImages, imageUrl);

            if (System.IO.File.Exists(imageUrl))
            {
                string temporary = Path.Combine(Environment.CurrentDirectory, "ImagePackups");
                File.Copy(path, temporary);
                string newFilePath = Path.Combine(path, imageUrl);
                File.Move(temporary, newFilePath);
            }
            else
            { imagefile.CopyTo(new FileStream(path, FileMode.Create)); }


            return imageUrl;
        }

        public async Task<string> AddVedioAsync(IFormFile vediofile, string phone)
        {
            string imageUrl = phone + vediofile.FileName;
            string useresImages = Path.Combine(Environment.CurrentDirectory, "PostVedios");
            string path = Path.Combine(useresImages, imageUrl);

            if (System.IO.File.Exists(imageUrl))
            {
                string temporary = Path.Combine(Environment.CurrentDirectory, "ImagePackups");
                File.Copy(path, temporary);
                string newFilePath = Path.Combine(path, imageUrl);
                File.Move(temporary, newFilePath);
            }
            else
            { vediofile.CopyTo(new FileStream(path, FileMode.Create)); }


            return imageUrl;
        }

        public async Task<string> UpdateImages(IFormFile imagefile, string imagename, string role)
        {
            string imageUrl = imagefile.FileName;
            string path = Path.Combine(Environment.CurrentDirectory, role);
            if (System.IO.File.Exists(imagename))
            {
                System.IO.File.Delete(imagename);
                imagefile.CopyTo(new FileStream(path, FileMode.Create));
            }


            return imageUrl;//add username at the controller
        }
        private async Task<bool> IsValidAsync(IFormFile imagefile)
        {
            if(imagefile.Length>1024*1024)
                return false;

            return true;
        }
    }
}
