using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Web.Http;
using Nelibur.ObjectMapper;
using nCoreCMSBL.Repository;
using nCoreCMSBL.Models;
using System.Web;
using System.IO;
using Newtonsoft.Json.Serialization;
using System.Net.Mail;
using System.Configuration;
using EmiratesWebApi.Models;

namespace EmiratesWebApi.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        ApplicationMessage applicationMessage = new ApplicationMessage();
        Response response = new Response();
        RegistrationMsg results = new RegistrationMsg();

        [HttpGet]
        public HttpResponseMessage GetUserList()
        {
            try
            {
                var item = UserRepository.GetUserList();//.Where(i => i.StatusID == (int)UserStatus.Active);//Active
                if (item != null)
                {
                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(item, Formatting.None), Encoding.UTF8, "application/json");
                    return response;
                }

                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //[HttpGet]
        //[Route("approval")]
        //public HttpResponseMessage GetUserApprovalList()
        //{
        //    try
        //    {
        //        var item = UserRepository.GetUserList().Where(i => i.StatusID == (int)UserStatus.Inactive).OrderByDescending(i => i.CreatedDate);//InActive
        //        if (item != null)
        //        {
        //            var response = this.Request.CreateResponse(HttpStatusCode.OK);
        //            response.Content = new StringContent(JsonConvert.SerializeObject(item, Formatting.None), Encoding.UTF8, "application/json");
        //            return response;
        //        }

        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        //[HttpGet]
        //[Route("userstatus")]
        //public HttpResponseMessage GetStatusList()
        //{
        //    try
        //    {
        //        var item = UserRepository.GetUserStatusList();
        //        if (item != null)
        //        {
        //            var response = this.Request.CreateResponse(HttpStatusCode.OK);
        //            response.Content = new StringContent(JsonConvert.SerializeObject(item, Formatting.None), Encoding.UTF8, "application/json");
        //            return response;
        //        }

        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        //[HttpGet]
        //[Route("{id}")]
        //public HttpResponseMessage GetUser(int id)
        //{
        //    try
        //    {
        //        UserAssociatedRoles objAssociatedRole = new UserAssociatedRoles();
        //        if (id == 0)
        //        {
        //            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //            id = Convert.ToInt32(identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
        //        }

        //        var user = UserRepository.GetUserList().Where(i => i.UserID == id).FirstOrDefault();

        //        objAssociatedRole.User = user;
        //        objAssociatedRole.User.ImageName = GetImageFromByteArray(id, user.IsSocialLogin, user.SocialImageURL);
        //        objAssociatedRole.UserRoles = UserRepository.GetUserRolePermissions(id);
        //        objAssociatedRole.LoginModel = UserRepository.GetAccountInfo(id);

        //        if (objAssociatedRole != null)
        //        {
        //            var response = this.Request.CreateResponse(HttpStatusCode.OK);
        //            response.Content = new StringContent(JsonConvert.SerializeObject(objAssociatedRole, Formatting.None), Encoding.UTF8, "application/json");
        //            return response;
        //        }

        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        //[HttpGet]
        //[Route("getuser")]
        //public HttpResponseMessage GetUser()
        //{
        //    try
        //    {
        //        var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //        int userID = Convert.ToInt32(identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());

        //        var item = UserRepository.GetUserList().Where(i => i.UserID == userID).FirstOrDefault();
        //        item.ImageName = GetImageFromByteArray(userID, item.IsSocialLogin, item.SocialImageURL);
        //        if (item != null)
        //        {
        //            var response = this.Request.CreateResponse(HttpStatusCode.OK);
        //            response.Content = new StringContent(JsonConvert.SerializeObject(item, Formatting.None), Encoding.UTF8, "application/json");
        //            return response;
        //        }

        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        //[HttpPost]
        //[Route("search")]
        //public HttpResponseMessage SearchUser([FromBody]SearchForm svm)
        //{
        //    try
        //    {
        //        SearchForm sf = TinyMapper.Map<SearchForm>(svm);
        //        IEnumerable<Users> objUser = UserRepository.GetUserList();

        //        if (!string.IsNullOrEmpty(sf.SearchText))
        //        {
        //            objUser = objUser.Where(i => ((i.FirstName.ToLower().Contains(sf.SearchText) && i.FirstName != "") || (i.LastName.ToLower().Contains(sf.SearchText) && i.LastName != "")));
        //        }

        //        if (svm.StatusID > 0)
        //        {
        //            objUser = objUser.Where(i => i.StatusID == svm.StatusID);
        //        }

        //        if (objUser != null)
        //        {
        //            var response = this.Request.CreateResponse(HttpStatusCode.OK);
        //            response.Content = new StringContent(JsonConvert.SerializeObject(objUser, Formatting.None), Encoding.UTF8, "application/json");
        //            return response;
        //        }

        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        //[HttpPost]
        //[Authorize]
        //public HttpResponseMessage Add([FromBody]Users uvm)
        //{
        //    try
        //    {
        //        var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //        if (uvm != null)
        //        {
        //            var user = TinyMapper.Map<Users>(uvm);

        //            // override any property that could be wise to set from server-side only
        //            user.CreatedBy = Convert.ToInt32(identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());

        //            // add the new item
        //            int userID = UserRepository.AddUser(user);

        //            // return the newly-created Item to the client.
        //            var response = this.Request.CreateResponse(HttpStatusCode.Created, userID);
        //            return response;
        //        }

        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        [HttpPost]
        [Route("register")]
        public IHttpActionResult RegisterUser([FromBody]Register rvm)
        {
            try
            {
                if (rvm != null)
                {                    
                    results.apiMessage = applicationMessage.registerationSuccessfully;
                    var register = TinyMapper.Map<Register>(rvm);
                    UserRepository.RegisterUser(rvm);
                    var item = this.Request.CreateResponse(HttpStatusCode.OK);
                    response.message = applicationMessage.executedSuccessfully;
                    response.status = applicationMessage.status;
                    response.results = results;
                    return Ok(response);
                }

                else
                {
                    return Ok(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found"));
                }
            }
            catch (Exception ex)
            {
                return Ok(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex));
            }
        }

        //[HttpPut]
        //[Authorize]
        //[Route("chgpwd/{id}")]
        //public HttpResponseMessage UpdatePassword(int id, [FromBody]LoginModel lvm)
        //{
        //    try
        //    {
        //        var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //        if (id == 0)
        //        {
        //            id = Convert.ToInt32(identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
        //        }
        //        if (lvm != null)
        //        {
        //            var loginModel = TinyMapper.Map<LoginModel>(lvm);
        //            loginModel.UserID = id;
        //            UserRepository.UpdatePassword(loginModel);

        //            // return the newly-created Item to the client.
        //            return this.Request.CreateResponse(HttpStatusCode.OK, "");
        //        }


        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        //[HttpPut]
        //[Authorize]
        //[Route("updateuser/{id}")]
        //public HttpResponseMessage Update(int id, [FromBody]Users uvm)
        //{
        //    try
        //    {
        //        var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //        if (id == 0)
        //        {
        //            id = Convert.ToInt32(identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
        //        }
        //        if (uvm != null)
        //        {
        //            var user = TinyMapper.Map<Users>(uvm);

        //            user.UserID = id;
        //            user.ModifiedBy = Convert.ToInt32(identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
        //            UserRepository.UpdateUser(user);

        //            if (uvm.SendApprovalEmail)
        //            {
        //                SendApprovalEmail(uvm);
        //            }

        //            return this.Request.CreateResponse(HttpStatusCode.OK, "");
        //        }

        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        //private void SendApprovalEmail(Users uvm)
        //{
        //    var user = UserRepository.GetLoginDetails(uvm.EmailAddress).FirstOrDefault();

        //    StreamReader reader = null;
        //    reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/emailtemplates/accountApproval.htm"));
        //    string readFile = reader.ReadToEnd();
        //    string myString = "";
        //    myString = readFile;
        //    myString = myString.Replace("$$UserName$$", user.LoginUserName);
        //    myString = myString.Replace("$$Password$$", user.LoginPassword);
        //    MailMessage Msg = new MailMessage();
        //    MailAddress fromMail = new MailAddress(ConfigurationManager.AppSettings["FromEmail"], "Account Approval");
        //    Msg.From = fromMail;
        //    Msg.To.Add(new MailAddress(uvm.EmailAddress));
        //    // Subject of e-mail
        //    Msg.Subject = "Account Approval";
        //    Msg.Body = myString.ToString();
        //    /*GoDaddy Code*/
        //    Msg.IsBodyHtml = true;
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = ConfigurationManager.AppSettings["Host"];
        //    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
        //    smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]);
        //    smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
        //    smtp.Send(Msg);
        //    /*Google Code
        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = ConfigurationManager.AppSettings["Host"].ToString();
        //    smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
        //    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
        //    NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
        //    NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
        //    smtp.UseDefaultCredentials = true;
        //    smtp.Credentials = NetworkCred;
        //    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
        //    smtp.Send(Msg);*/
        //    reader.Dispose();

        //}

        //[System.Web.Http.HttpPut]
        //[Authorize]
        //[Route("{id}")]
        //public HttpResponseMessage UpdateRoles(int id, [FromBody]List<UserRoles> urvm)
        //{
        //    try
        //    {
        //        var _userrole = new UserRoles();
        //        var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //        if (urvm != null)
        //        {
        //            foreach (UserRoles item in urvm)
        //            {
        //                _userrole.UserID = id;
        //                _userrole.RoleID = item.RoleID;
        //                _userrole.IsRolePermission = item.IsRolePermission;
        //                _userrole.ModifiedBy = Convert.ToInt32(identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
        //                UserRepository.UpdateUserRoles(_userrole);
        //            }

        //            // return the updated Item to the client.
        //            return this.Request.CreateResponse(HttpStatusCode.OK, "");
        //        }


        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        //[HttpPost]
        //[Authorize]
        //[Route("updateprofileimage/{id}")]
        //public HttpResponseMessage UpdateProfileImage(int id)
        //{
        //    try
        //    {
        //        var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //        if (id == 0)
        //        {
        //            id = Convert.ToInt32(identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
        //        }
        //        var httpRequest = HttpContext.Current.Request;
        //        var postedFile = httpRequest.Files["Image"];

        //        if (postedFile.ContentLength > 0)
        //        {
        //            string fileName = postedFile.FileName.ToString();

        //            var user = new Users();
        //            user.UserID = id;
        //            user.ImageName = fileName;
        //            user.ModifiedBy = Convert.ToInt32(identity.Claims.Where(c => c.Type == ClaimTypes.Sid).Select(c => c.Value).SingleOrDefault());
        //            UserRepository.UpdateProfileImage(user);

        //            var imgPath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/_Files/_UserImages/"), "_" + id.ToString());
        //            if (File.Exists(imgPath))
        //            {
        //                File.Delete(imgPath);
        //            }
        //            postedFile.SaveAs(imgPath);
        //            var response = this.Request.CreateResponse(HttpStatusCode.Created);
        //            response.Content = new StringContent("", Encoding.UTF8, "application/json");
        //            return response;

        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }

        //}

        //[System.Web.Http.HttpPut]
        //[Route("fileupload/{id}")]
        //public HttpResponseMessage UploadProfileImage(int id)
        //{
        //    try
        //    {
        //        var file = HttpContext.Current.Request.Files[0];

        //        if (file.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(file.FileName);
        //            var imgPath = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/_files/_UserImages/"), "_" + id.ToString());
        //            if (File.Exists(imgPath))
        //            {
        //                File.Delete(imgPath);
        //            }
        //            file.SaveAs(imgPath);
        //            var response = this.Request.CreateResponse(HttpStatusCode.OK);
        //            response.Content = new StringContent("", Encoding.UTF8, "application/json");
        //            return response;
        //        }
        //        else
        //        {
        //            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not found");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }


        //}

        //[HttpGet]
        //[Route("checkemail/{email}")]
        //public HttpResponseMessage CheckEmail(string email)
        //{
        //    try
        //    {
        //        var IsEmailExists = UserRepository.CheckEmailExists(email);

        //        var response = this.Request.CreateResponse(HttpStatusCode.OK);
        //        if (IsEmailExists)
        //        {
        //            response.Content = new StringContent(JsonConvert.SerializeObject("OK", Formatting.None), Encoding.UTF8, "application/json");

        //        }
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        //[HttpGet]
        //[Route("checkusername/{username}")]
        //public HttpResponseMessage CheckUsername(string username)
        //{
        //    try
        //    {
        //        var IsExistUser = UserRepository.IsExistUser(username);

        //        var response = this.Request.CreateResponse(HttpStatusCode.OK);
        //        if (IsExistUser)
        //        {
        //            response.Content = new StringContent(JsonConvert.SerializeObject("ok", Formatting.None), Encoding.UTF8, "application/json");

        //        }
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
        //    }
        //}

        //private string GetImageFromByteArray(int userID, bool isSocial, string socialImageURL)
        //{
        //    string imgPath = System.Web.Hosting.HostingEnvironment.MapPath("~/_Files/_UserImages/_") + userID.ToString();
        //    if (File.Exists(imgPath))
        //    {
        //        byte[] byteData = System.IO.File.ReadAllBytes(imgPath);
        //        string imreBase64Data = Convert.ToBase64String(byteData);
        //        return string.Format("data:image/png;base64,{0}", imreBase64Data);
        //    }
        //    else
        //    {
        //        byte[] byteData = null;
        //        if (isSocial)
        //        {
        //            byteData = this.GetImage(socialImageURL);
        //        }
        //        else
        //        {
        //            imgPath = System.Web.Hosting.HostingEnvironment.MapPath("~/_Files/_default/_user.png");
        //            byteData = System.IO.File.ReadAllBytes(imgPath);
        //        }
        //        string imreBase64Data = Convert.ToBase64String(byteData);
        //        return string.Format("data:image/png;base64,{0}", imreBase64Data);
        //    }
        //}

        //private byte[] GetImage(string url)
        //{
        //    Stream stream = null;
        //    byte[] buf;

        //    try
        //    {
        //        WebProxy myProxy = new WebProxy();
        //        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

        //        HttpWebResponse response = (HttpWebResponse)req.GetResponse();
        //        stream = response.GetResponseStream();

        //        using (BinaryReader br = new BinaryReader(stream))
        //        {
        //            int len = (int)(response.ContentLength);
        //            buf = br.ReadBytes(len);
        //            br.Close();
        //        }

        //        stream.Close();
        //        response.Close();
        //    }
        //    catch (Exception exp)
        //    {
        //        buf = null;
        //    }

        //    return (buf);
        //}
    }
}
