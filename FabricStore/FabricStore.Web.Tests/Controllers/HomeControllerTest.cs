namespace FabricStore.Web.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using FabricStore.Web;
    using FabricStore.Web.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using FabricStore.Models;
    using FabricStore.Data;

    [TestClass]
    public class HomeControllerTest
    {
        public static IRepository<Product> repository = new GenericRepository<Product>();

        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController(repository);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController(repository);

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Fabric Store about page", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController(repository);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}