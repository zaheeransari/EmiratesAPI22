using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmiratesWebApi.Models
{
    public sealed class ApplicationMessage
    {
        public Boolean status = true;
        public string executedSuccessfully = "Api executed successfully";
        public string loginSuccessfully = "Login successfully";
        public string loginFails = "User Id / Password is incorrect";
        public string registerationSuccessfully = "Registeration successfully";
        public string versionSuccessfully = "Version successfully";
        public string carproductSuccessfully = "Car Product successfully";
        public string carproductFails = "Car Product Fails";
        public Boolean statusfails = false;
        public string executedFails = "Api executed fails";
    }
}