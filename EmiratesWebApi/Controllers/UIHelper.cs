using System;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;

namespace EmiratesWebApi.Controllers
{
    public sealed class UIHelper
    {
        private UIHelper()
        {
        }

        public static string GetImageFromByteArray(int imageID, string basePath, string defaultPath)
        {
            string imgPath = System.Web.Hosting.HostingEnvironment.MapPath("~/_files/_" + basePath + "/_") + imageID.ToString();
            if (File.Exists(imgPath))
            {
                byte[] byteData = System.IO.File.ReadAllBytes(imgPath);
                string imreBase64Data = Convert.ToBase64String(byteData);
                return string.Format("data:image/png;base64,{0}", imreBase64Data);
            }
            else
            {
                //imgPath = System.Web.Hosting.HostingEnvironment.MapPath("~/_files/_default/_" + defaultPath + ".png");
                //byte[] byteData = System.IO.File.ReadAllBytes(imgPath);
                //string imreBase64Data = Convert.ToBase64String(byteData);
                //return string.Format("data:image/png;base64,{0}", imreBase64Data);
                return "";
            }
        }

        public static HttpResponseMessage GetFile(string filePath)
        {
            HttpResponseMessage response = null;
            if (!File.Exists(filePath))
            {
                //if file not found than return response as resource not present 
                ////response = Request.CreateResponse(HttpStatusCode.Gone);
            }
            else
            {
                //if file present than read file 
                var fStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                //compose response and include file as content in it
                response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StreamContent(fStream)
                };
                //set content header of reponse as file attached in reponse
                response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = Path.GetFileName(fStream.Name)
                };
                //set the content header content type as application/octet-stream as it      
                //returning file as reponse 
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            }
            return response;
        }
    }
}