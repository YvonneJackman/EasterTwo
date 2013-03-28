namespace ExternalWeb.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using Data.Model;
    using ExternalWeb;
    using ExternalWeb.Controllers;
    using ExternalWeb.ViewModels;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OpportunityControllerTest
    {
        [TestMethod]
        public void ExternalWebOpportunityIndex()
        {
            // Arrange
            OpportunityController controller = new OpportunityController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewData.Count);
        }

        [TestMethod]
        public void ExternalWebOpportunityDetails()
        {
            // Arrange
            OpportunityController controller = new OpportunityController();

            // Act
            var opportunityId = 1;
            ViewResult result = controller.Details(opportunityId) as ViewResult;
            var model = (Opportunity)result.ViewData.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(opportunityId, model.OpportunityId);
            Assert.AreEqual("BREADALBANE CANOE CLUB EVENT", model.OpportunityTitle);
        }

        /// <summary>
        /// Test Edit Opportunity method
        /// </summary>
        [TestMethod]
        public void ExternalWebOpportunityEdit()
        {
            // Arrange
            OpportunityController controller = new OpportunityController();

            // Act
            var opportunityId = 1;
            ViewResult result = controller.Edit(opportunityId) as ViewResult;
            var model = (Opportunity)result.ViewData.Model;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("BREADALBANE CANOE CLUB EVENT", model.OpportunityTitle);
        }

        /// <summary>
        /// Test Create Opportunity method
        /// </summary>
        [TestMethod]
        public void ExternalWebOpportunityCreate()
        {
            // Arrange
            OpportunityController controller = new OpportunityController();
            var model = new Opportunity
            {
                OpportunityId = 100,
                OpportunityStatusId = 2,
                CompanyId = 1,
                MaxNumberofVolunteers = 1,
                OpportunityLocationName = "ABERFELDY",
                OpportunityPostcode = "BD23 1PT",
                OpportunityTitle = "BREADALBANE CANOE CLUB EVENT",
                OpportunityDescription = "ASSIST AS HELPERS AT OUR SLALOM KAYAKING COMPETITION IN ABERFELDY 1ST & 2ND OF APRIL - CAR PARKING, CATERING TENT, HELPING CHILDREN GET IN AND OUT OF BOATS, HELP CARRY BOATS, ETC. OUR OTHER COMPETITION AT GRANDTULLY ON THE 30TH AND 31ST OF MARCH WOULD BENEFIT FROM ANY HELPERS AS WELL. IT IS A PREMIER EVENT AND SOME PREVIOUS OLYMPIC MEDALISTS COMPETE THERE. THE ADVENTURE SHOW ALSO FILMS THE EVENT.",
                OpportunityDate = System.DateTime.Now.AddDays(5).ToShortDateString(),
                OpportunityCreatedDate = System.DateTime.Now,
                MinNumberofVolunteers = 1,
                OpportunityAdditionalInformation = "Created: " + System.DateTime.Now.ToString()
            };

            // Act            
            var redirectToRouteResult = controller.Create(model) as RedirectToRouteResult; 
            
            // Assert
            Assert.IsNotNull(redirectToRouteResult);            
            Assert.AreEqual("Index", redirectToRouteResult.RouteValues["Action"]);
            Assert.AreEqual("OpportunityController", redirectToRouteResult.RouteValues["controller"]);        
        }         
    }
}