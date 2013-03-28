namespace InternalWeb.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using Data.Model;
    using InternalWeb;
    using InternalWeb.Controllers;
    using InternalWeb.ViewModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
   
    [TestClass]
    public class OpportunityControllerTest
    {
        [TestMethod]
        public void InternalWebOpportunityIndex()
        {
            // Arrange
            OpportunityController controller = new OpportunityController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Internal Website Application.", result.ViewBag.Message);
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsNotNull(result.ViewData.Count);                        
        }

        [TestMethod]
        public void InternalWebOpportunityDetails()
        {
            // Arrange
            OpportunityController controller = new OpportunityController();

            // Act
            var opportunityId = 1;
            ViewResult result = controller.Details(opportunityId) as ViewResult;
            var model = (Opportunity)result.ViewData.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.ViewName);
            Assert.AreEqual(1, model.OpportunityId);
            Assert.AreEqual("BREADALBANE CANOE CLUB EVENT", model.OpportunityTitle);      
        }

        /// <summary>
        /// Test Edit Opportunity method
        /// </summary>
        [TestMethod]
        public void InternalWebOpportunityEdit()
        {
            // Arrange
            OpportunityController controller = new OpportunityController();
        
            // Act
            var opportunityId = 1;
            ViewResult result = controller.Edit(opportunityId) as ViewResult;
            var model = (Opportunity)result.ViewData.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Edit", result.ViewName);
            Assert.AreEqual(opportunityId, model.OpportunityId);
            Assert.AreEqual("BREADALBANE CANOE CLUB EVENT", model.OpportunityTitle);            
        }
    }
}
