using AuthDemoServer.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AuthDemoServer.Controllers
{
    public class Calculator
    {
        //public Calculator() { }

        //readonly string connStr = ConfigurationManager.ConnectionStrings["myConnectionString_AuthDemo"].ConnectionString;

        

        public IEnumerable<User> Get()
        {
            IEnumerable<User> lstObj_User;

            var sp_SelectAllUsersOrderByIdAsc = "sp_SelectAllUsersOrderByIdAsc";

        //    using (var db = new SqlConnection(connStr))
        //    //{
        //    //    lstObj_User = db.Query<User>(sp_SelectAllUsersOrderByIdAsc,
        //    //                                 commandType: CommandType.StoredProcedure);
        //    //}

        //    //var message = lst_Parameters.Get<System.String>("message");
        //    //var result = lst_Parameters.Get<int>("result");

        //    //return lstObj_User;
            return null;
        }
    }
}