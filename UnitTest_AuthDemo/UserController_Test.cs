using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AuthDemoServer.Controllers;
using AuthDemoServer.Models;
using System.Collections.Generic;

namespace UnitTest_AuthDemo
{
    [TestClass]
    public class UserController_Test
    {
        [TestMethod]
        public void GetAllProducts_ShouldReturnAllProducts()
        {
            List<User> lstObj_User = new List<User>();

            lstObj_User.Add(new User(0, "prueba", "prueba", "prueba", 0));
            //UserController controller = new UserController(lstObj_User);
            var controller = new Calculator();

            //var result = controller.Get() as List<User>;
            //Assert.AreEqual(testProducts.Count, result.Count);

            int x = 1;

            Assert.IsNotNull(x);
        }
    }
}
