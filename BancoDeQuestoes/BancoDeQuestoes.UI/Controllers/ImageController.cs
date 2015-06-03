using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BancoDeQuestoes.UI.Controllers
{
    public class ImageController : Controller
    {
        [HttpPost]
        public ActionResult CropImage(
            string imagePath,
            int? cropPointX,
            int? cropPointY,
            int? imageCropWidth,
            int? imageCropHeight)
        {
            if (string.IsNullOrEmpty(imagePath)
                || !cropPointX.HasValue
                || !cropPointY.HasValue
                || !imageCropWidth.HasValue
                || !imageCropHeight.HasValue)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            byte[] imageBytes = System.IO.File.ReadAllBytes(Server.MapPath(imagePath));
            byte[] croppedImage = ImageHelper.CropImage(imageBytes, cropPointX.Value, cropPointY.Value, imageCropWidth.Value, imageCropHeight.Value);

            //string tempFolderName = Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.TempFolderName"]);
            string tempFolderName = "Temp";
            string tempFolderPath = Server.MapPath("~/" + tempFolderName);

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath);
            string fileName = Path.GetFileName(imagePath).Replace(fileNameWithoutExtension, fileNameWithoutExtension + "_cropped");

            try
            {
                FileHelper.SaveFile(croppedImage, Path.Combine(tempFolderPath, fileName));
            }
            catch (Exception)
            {
                //Log an error     
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }

            string photoPath = string.Concat("/", tempFolderName, "/", fileName);
            return Json(new { photoPath = photoPath }, JsonRequestBehavior.AllowGet);
        }
    }
}