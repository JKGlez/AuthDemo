using AuthDemoServer.Controllers.JWT; //To access JWT generator and validator
using AuthDemoServer.Models; //Access to the bussiness models need it
using System.Collections.Generic; //To Handle IEnumerables and collection
using System.Configuration; //To acces the connection String from configuration
using System.Web.Http; //To Connect with the web api
using System.Data.SqlClient; //To handle data from sql db
using System.Data; //To define data types
using Dapper; //Micro ORM to work with the DB server

using System.Linq;
using System.Security.Claims;

namespace AuthDemoServer.Controllers
{

    [AllowAnonymous]
    public class AccountController : ApiController
    {

        readonly string connStr = ConfigurationManager.ConnectionStrings["myConnectionString_AuthDemo"].ConnectionString;

        [HttpPost]
        [Route("api/Account/Login")]
        public IHttpActionResult Login([FromBody] Login obj_loginCredential)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            IEnumerable<User> lstObj_User;
            var sp_LoginByEmailAndPassword = "sp_LoginByEmailAndPassword";
            var lst_Parameters = new DynamicParameters();

            //Assigning: Input type String parameter, to the lst_parameters need it for the store procedure
            lst_Parameters.Add("email", obj_loginCredential.Email, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
            lst_Parameters.Add("password", obj_loginCredential.Password, dbType: DbType.String, direction: ParameterDirection.Input, size: 50);

            //Assigning: Output type String parameter, to the lst_parameters need it for the store procedure
            lst_Parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
            //Assigning: Output type INT parameter, to the lst_parameters need it for the store procedure 
            lst_Parameters.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            using (var db = new SqlConnection(connStr))
            {
                lstObj_User = db.Query<User>(sp_LoginByEmailAndPassword,
                                             lst_Parameters,
                                             commandType: CommandType.StoredProcedure);
            }
            var message = lst_Parameters.Get<System.String>("message");
            var result = lst_Parameters.Get<int>("result");

            if (result == 1)
            {
                User obj_ValidUser = lstObj_User.FirstOrDefault();
                var jwkToken = TokenGenerator.GenerateTokenJwt(obj_ValidUser.Name, obj_ValidUser.RoleDescription);
                var token = new JWT_Model(obj_ValidUser.Name, jwkToken, obj_ValidUser.RoleDescription);
                return Ok(token);
            }
            else
            {
                var token = new JWT_Model("NoOne", "", "Unauthorized");
                //return Ok(token);
                return Unauthorized(); //status code 401
            }
        }

        [HttpPost]
        [Route("api/Account/Register")]
        public IHttpActionResult Register([FromBody] User obj_NewUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int role = 1;

            if (obj_NewUser.RoleDescription == "Administrator")
                role = 0;
                  

            IEnumerable<User> lstObj_User;

            var sp_InsertNewUser = "sp_InsertNewUser";

            var lst_Parameters = new DynamicParameters();

            //return Ok();

            //Assigning: Input type String parameter, to the lst_parameters need it for the store procedure
            lst_Parameters.Add("name", obj_NewUser.Name, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
            lst_Parameters.Add("email", obj_NewUser.Email, dbType: DbType.String, direction: ParameterDirection.Input, size: 100);
            lst_Parameters.Add("password", obj_NewUser.Password, dbType: DbType.String, direction: ParameterDirection.Input, size: 50);

            //Assigning: Input type INT parameter, to the lst_parameters need it for the store procedure 
            lst_Parameters.Add("role", role, DbType.Int32, direction: ParameterDirection.Input);

            //Assigning: Output type String parameter, to the lst_parameters need it for the store procedure
            lst_Parameters.Add("message", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
            //Assigning: Output type INT parameter, to the lst_parameters need it for the store procedure 
            lst_Parameters.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);

            using (var db = new SqlConnection(connStr))
            {
                lstObj_User = db.Query<User>(sp_InsertNewUser,
                                             lst_Parameters,
                                             commandType: CommandType.StoredProcedure);
            }

            var message = lst_Parameters.Get<System.String>("message");
            var result = lst_Parameters.Get<int>("result");

            return Ok();
        }
    }
}
