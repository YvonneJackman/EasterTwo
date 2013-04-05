namespace ExternalWeb.Tests.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using Data.Migrations;
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
            int id = 1;
            CommunityDaysDb db = new CommunityDaysDb();
            var status = new OpportunityStatus
            {
                OpportunityStatusId = id,
                OpportunityStatusDescription = "First status"
            };

            var user = new UserProfile
            {
                UserId = id,
                UserName = "First"
            };

            var company = new Company
            {
                CompanyId = id,
                CompanyName = "First Company",
                UserId = id
            };
            
            db.Company.Add(company);
            db.UserProfiles.Add(user);
            db.OpportunityStatus.Add(status);
            db.SaveChanges();

            // Arrange
            OpportunityController controller = new OpportunityController();
            var model = new Opportunity
            {
                OpportunityId = id,
                OpportunityStatusId = id,
                CompanyId = id,
                MinNumberofVolunteers = id,
                MaxNumberofVolunteers = id,
                OpportunityLocationName = "ABERFELDY",
                OpportunityPostcode = "BD23 1PT",
                OpportunityTitle = "BREADALBANE CANOE CLUB EVENT",
                OpportunityDescription = "ASSIST AS HELPERS AT OUR SLALOM KAYAKING COMPETITION IN ABERFELDY 1ST & 2ND OF APRIL - CAR PARKING, CATERING TENT, HELPING CHILDREN GET IN AND OUT OF BOATS, HELP CARRY BOATS, ETC. OUR OTHER COMPETITION AT GRANDTULLY ON THE 30TH AND 31ST OF MARCH WOULD BENEFIT FROM ANY HELPERS AS WELL. IT IS A PREMIER EVENT AND SOME PREVIOUS OLYMPIC MEDALISTS COMPETE THERE. THE ADVENTURE SHOW ALSO FILMS THE EVENT.",
                OpportunityDate = System.DateTime.Now.AddDays(5).ToShortDateString(),
                OpportunityCreatedDate = System.DateTime.Now,                
                OpportunityAdditionalInformation = "Created: " + System.DateTime.Now.ToString()
            };

            // Act            
            var redirectToRouteResult = controller.Create(model) as RedirectToRouteResult;
            //ViewResult result = controller.Edit(id) as ViewResult;
            //Opportunity modelResult = (Opportunity)result.ViewData.Model;
            
            // Assert
            Assert.IsNotNull(redirectToRouteResult);            
            Assert.AreEqual("Index", redirectToRouteResult.RouteValues["Action"]);
            Assert.AreEqual("OpportunityController", redirectToRouteResult.RouteValues["controller"]);
            //Assert.AreEqual(model.OpportunityId, modelResult.OpportunityId);
        }         
    }
}