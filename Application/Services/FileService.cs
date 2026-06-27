namespace RestaurantOrderSystem.Application.Services
{
    public class FileService
    {
        public async Task<string?> SaveImageAsync(IFormFile file, string folder)
        {
            if (file == null || file.Length == 0)
                return null;

            var extension = Path.GetExtension(file.FileName).ToLower();

            var fileName = Path.GetFileNameWithoutExtension(file.FileName)
                + "_" + DateTime.Now.Ticks + extension;

            
            var uploadFolder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/images",
                folder
            );

            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            var filePath = Path.Combine(uploadFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            
            return $"/images/{folder}/{fileName}";
        }
    }
}
