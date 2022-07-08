using Microsoft.AspNetCore.Http;
namespace MetiJob.Api.FileUtils
{
    public static class UploadPdfFileExension
    {
        public static bool AddPdfToServer(this IFormFile file, string fileName, string orginalPath,string deletefileName = null)
        {
            if (file != null &&Path.GetExtension(fileName).ToLower()==".pdf")
            {
                if (!Directory.Exists(orginalPath))
                    Directory.CreateDirectory(orginalPath);

                if (!string.IsNullOrEmpty(deletefileName))
                {
                    if (File.Exists(orginalPath + deletefileName))
                        File.Delete(orginalPath + deletefileName);

                }
                string OriginPath = orginalPath + fileName;
                using (var stream = new FileStream(OriginPath, FileMode.Create))
                {
                    if (!Directory.Exists(OriginPath)) file.CopyTo(stream);
                }
                return true;
            }
            else return false;
        }

    }
}
