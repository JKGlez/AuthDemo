using System;
using Xunit;
using AuthDemoServer.Controllers;
using Microsoft.AspNetCore.Mvc;
using AuthDemoServer.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace AuthTest_XUnitTest
{
    public class Account
    {
        [Fact]
        public void Test1()
        {
            var controller = new UserController();
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //var response = controller.Get();

            //UserController x = new UserController();
            //var y = true;
            //Assert.True(y);
        }
    }
}
