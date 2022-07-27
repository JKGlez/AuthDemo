using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthDemoServer.Models;
using AuthDemoServer.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Net.Http;

namespace AuthTest
{
    [TestClass]
    public class AccountTest
    {

        private readonly UserController _UserController;
        //private readonly AccountController _AccountController;

        //public AccountTest()
        //{
        //    _AccountController = new AccountController();
        //}

        [TestMethod]
        public void Login_SendingValidCredentials_ShouldPassTest()
        {
            //Arrange
            Login defaultValidLogin = new Login();
            defaultValidLogin.Email = "employee@email.com";
            defaultValidLogin.Password = "employee";

            var _AccountController = new AccountController();
            _AccountController.Request = new HttpRequestMessage();
            _AccountController.Configuration = new HttpConfiguration();

            var expected = true;

            //Act

            var x =_AccountController.Login(defaultValidLogin);
            
            Console.WriteLine("pause");

            //Assert

            Assert.IsTrue(expected);

        }

        [TestMethod]
        public void GetAllUser()
        {
            var users = _UserController.Get();
            Assert.

        }
    }
}
