using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nCoreCMSBL.Models
{
    public class AppVersions
    {
        public int Id { get; set; }
        public string AppVersion { get; set; }
        public string AppType { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
    public class AppVersionsDto
    {
        public string AppVersion { get; set; }
        public string AppType { get; set; }
    }
    public class VersionsResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public VersionsResults results { get; set; }
    }
    public class VersionsResults
    {
        public List<AppVersions> appVersions { get; set; }
        public string apiMessage { get; set; }
    }
}
