using DOAN_CHuyenNGanh.Helper;
using DOAN_CHuyenNGanh.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DOAN_CHuyenNGanh.Controllers.api
{
    [Route("api/[controller]")]
    public class ImagesController : ApiController
    {
        private readonly AzureStorageConfig storageConfig = null;

        // POST /api/images/upload
        [HttpPost]
        public async Task<IHttpActionResult> Upload(ICollection<IFormFile> files)
        {
            bool isUploaded = false;

            try
            {

                if (files.Count == 0)

                    return BadRequest("No files received from the upload");

                if (storageConfig.AccountKey == string.Empty || storageConfig.AccountName == string.Empty)

                    return BadRequest("sorry, can't retrieve your azure storage details from appsettings.js, make sure that you add azure storage details there");

                if (storageConfig.ImageContainer == string.Empty)

                    return BadRequest("Please provide a name for your image container in the azure blob storage");

                foreach (var formFile in files)
                {
                    if (StorageHelper.IsImage(formFile))
                    {
                        if (formFile.Length > 0)
                        {
                            using (Stream stream = formFile.OpenReadStream())
                            {
                                isUploaded = await StorageHelper.UploadFileToStorage(stream, formFile.FileName, storageConfig);
                            }
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                }

                if (isUploaded)
                {
                    if (storageConfig.ThumbnailContainer != string.Empty)

                        return BadRequest(string.Format("GetThumbNails", "Images", null, null));

                    else

                        return Ok();
                }
                else

                    return BadRequest("Look like the image couldnt upload to the storage");


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
