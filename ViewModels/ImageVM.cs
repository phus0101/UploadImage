namespace UploadImage.ViewModels
{
    public class ImageVM
    {
        public IFormFile File { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Name { get; set; }
    }
}
