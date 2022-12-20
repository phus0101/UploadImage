using Microsoft.AspNetCore.Mvc;
using UploadImage.ViewModels;

namespace UploadImage.Controllers
{
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(ImageVM image)
        {
            string uploads = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/images/");
            // create folder if not exists
            Directory.CreateDirectory(uploads);
            if (image.File.Length > 0)
            {
                FileInfo fileInfo = new FileInfo(image.File.FileName);
                string fileName = string.Format("{0}_{1}_{2}{3}", image.Name, image.Width, image.Height, fileInfo.Extension);

                string filePath = Path.Combine(uploads, fileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    try
                    {
                        // copy file to folder
                        await image.File.CopyToAsync(fileStream);
                    }
                    catch (Exception ex)
                    {
                        return BadRequest("Có lỗi trong khi upload hình ảnh.");
                    }
                }
            }

            return Ok("Upload hình ảnh thành công.");
        }
    }
}
