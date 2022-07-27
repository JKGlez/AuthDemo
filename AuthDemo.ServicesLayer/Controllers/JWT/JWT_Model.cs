using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthDemoServer.Controllers.JWT
{
    public class JWT_Model
    {
        private string userToken;
        private string token;
        private string userRole;

        public string UserToken { get => userToken; set => userToken = value; }
        public string JwkToken { get => token; set => token = value; }
        public string UserRole { get => userRole; set => userRole = value; }

        public JWT_Model(string userToken, string token, string userRole)
        {
            this.userToken = userToken;
            this.token = token;
            this.UserRole = userRole;
        }
    }
}