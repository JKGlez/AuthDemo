
using System;
using System.Collections.Generic;

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using AuthDemoServer.Models;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using System.Data;


namespace AuthDemoServer.Controllers
{
    //[System.Web.Http.Authorize]
    
    public class UserController : ApiController 
    {

        readonly string connStr = ConfigurationManager.ConnectionStrings["myConnectionString_AuthDemo"].ConnectionString;

        List<User> lstObj_User = new List<User>();

        public UserController(){}

        public UserController(List<User> lstObj_User)
        {
            this.lstObj_User = lstObj_User;
        }


        // GET: api/User
        [HttpGet]
        [Route("api/User/GetAll")]
        public IEnumerable<User> Get()
        {
            IEnumerable<User> lstObj_User;

            var sp_SelectAllUsersOrderByIdAsc = "sp_SelectAllUsersOrderByIdAsc";

            using (var db = new SqlConnection(connStr))
            {
                lstObj_User = db.Query<User>(sp_SelectAllUsersOrderByIdAsc,
                                             commandType: CommandType.StoredProcedure);
            }

            //var message = lst_Parameters.Get<System.String>("message");
            //var result = lst_Parameters.Get<int>("result");

            return lstObj_User;
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }

    }
}


