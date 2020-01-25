using nCoreCMSBL.Models;
using nCoreCMSBL.Repository;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Data;
using EmiratesWebApi.Models;

namespace EmiratesWebApi.Controllers
{
    [RoutePrefix("api/versions")]
    public class VersionController : ApiController
    {
        ApplicationMessage appmessage = new ApplicationMessage();

        [HttpPost]
        [Route("appVersion")]
        public HttpResponseMessage GetVersion([FromBody]AppVersionsDto appVersion)
        {
            int results = 0;
            try
            {
                CommonResponse commonResponse = new CommonResponse();
                VersionResults versionResults = new VersionResults();

                DataTable item = VersionRepository.GetVersion();

                if (item != null)
                {
                    int val1 = VersionValue(item.Rows[0]["AppVersion"].ToString());
                    int val2 = VersionValue(appVersion.AppVersion.ToString());
                    results = VersionItem(val1, val2);

                    versionResults.values = results;
                    versionResults.apiMessage = appmessage.versionSuccessfully;
                    commonResponse.status = true;
                    commonResponse.message = appmessage.executedSuccessfully;
                    commonResponse.results = versionResults;

                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(commonResponse, Formatting.None), Encoding.UTF8, "application/json");
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

        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetData()
        {
            try
            {
                VersionsResponse versionsResponse = new VersionsResponse();
                VersionsResults versionsResults = new VersionsResults();

                versionsResults.appVersions = VersionRepository.GetAllVersion();
                versionsResults.apiMessage = appmessage.versionSuccessfully;
                if (versionsResults != null)
                {
                    versionsResponse.status = true;
                    versionsResponse.message = appmessage.executedSuccessfully;
                    versionsResponse.results = versionsResults;
                    var response = this.Request.CreateResponse(HttpStatusCode.OK);
                    response.Content = new StringContent(JsonConvert.SerializeObject(versionsResponse, Formatting.None), Encoding.UTF8, "application/json");
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
        private int VersionValue(string val)
        {
            string[] arr = val.Split('.');
            string def = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                def = def + arr[i];
            }
            return Convert.ToInt32(def);
        }
        private int VersionItem(int first, int second)
        {
            int results;
            if (second >= first)
            {
                results = 1;
            }
            else
            {
                results = 0;
            }
            return results;
        }
    }
}
