using AuthDemoServer.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Web.Http;

namespace MSTestAuth
{
    [TestClass]
    public class UnitTest1
    {
        private readonly UserController _controller;

        //public UnitTest1()
        //{
        //    _controller = new UserController();
        //}

        [TestMethod]
        public void TestMethod1()
        {
            Calculator y = new Calculator();
            //var controller = new UserController();
            //_controller.Get();
            //controller.Request = new HttpRequestMessage();
            //controller.Configuration = new HttpConfiguration();
            var x = true;
            Assert.IsTrue(x);
        }
    }
}
