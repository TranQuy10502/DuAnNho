using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DuAnNho.IServices;
using DuAnNho.Models;
using Microsoft.Extensions.Options;


namespace DuAnNho.Services
{
    public class PhotoServices : IPhotoServices
    {
        private readonly Cloudinary _cloudinary;
        public PhotoServices(IOptions<CloudinarySettings> config)
        {
            var photo = new Account(
                  config.Value.CloudName,
                  config.Value.ApiKey,
                  config.Value.ApiSecret
                  );
            _cloudinary = new Cloudinary(photo);
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParms = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParms);

            }
            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicUrl)
        {
            var publicId = publicUrl.Split('/').Last().Split('.')[0];
            var deleteParams = new DeletionParams(publicId);
            return await _cloudinary.DestroyAsync(deleteParams);
        }
    }
}
