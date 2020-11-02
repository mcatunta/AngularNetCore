using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SalesDiego.Web.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SalesDiego.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : BaseController
    {
        [HttpPost]
        [Route("upload")]
        public ActionResult<int> UploadImages()
        {
            return Execute(() =>
            {
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                foreach(var file in Request.Form.Files)
                {
                    if (file.Length>0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse
                            (file.ContentDisposition).FileName.Trim().ToString();
                        var fullPath = Path.Combine(pathToSave, fileName);
                        using var stream = new FileStream(fullPath, FileMode.Create);
                            file.CopyTo(stream);
                    }
                }
                return Request.Form.Files.Count();
            });
        }

        [HttpPost]
        [Route("delete")]
        public ActionResult<int> DeleteImages(List<ImageModel> images)
        {
            return Execute(() =>
            {
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                foreach (var image in images)
                {
                    var fullPath = Path.Combine(pathToSave, image.NameImage);
                    System.IO.File.Delete(fullPath);
                };
                return images.Count();
            });            
        }
    }
}
