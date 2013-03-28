namespace ExternalWeb.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using ExternalWeb;
    using ExternalWeb.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void ExternalWebHomeIndex()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("External Website Application.", result.ViewBag.Message);
        }

        [TestMethod]
        public void ExternalWebHomebout()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ExternalWebHomeContact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
