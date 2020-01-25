using nCoreCMSBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmiratesWebApi.Models
{
    public class CommonResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public VersionResults results { get; set; }
    }
    public class CommonResults
    {
        public string apiMessage { get; set; }
    }
    public class VersionResults
    {
        public int values { get; set; }
        public string apiMessage { get; set; }
    }


    public class TokenResults
    {
        public string token { get; set; }
        public string apiMessage { get; set; }
    }
    public class TokenResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public TokenResults results { get; set; }
    }
}