namespace InternalWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;
    using Data.Migrations;
    using Data.Model;
    using InternalWeb.ViewModels;
            
    public class OpportunityController : Controller
    {
        private CommunityDaysDb db = new CommunityDaysDb();

        /// <summary>
        /// GET: /Opportunity/
        /// </summary>
        /// <returns>An ActionResult object</returns>
        public ActionResult Index()
        {
            ViewBag.Message = "Internal Website Application.";
            OpportunityViewModel[] viewModel = (from opp in this.db.Opportunity
                                                join comp in this.db.Company 
                                                on opp.CompanyId equals comp.CompanyId                              
                                                join oppStatus in this.db.OpportunityStatus 
                                                on opp.OpportunityStatusId equals oppStatus.OpportunityStatusId
                                                where oppStatus.OpportunityStatusId  > 0
                                                select new OpportunityViewModel 
                                                {   
                                                    OpportunityId = opp.OpportunityId,
                                                    CompanyId = comp.CompanyId,
                                                    CompanyName = comp.CompanyName,
                                                    CompanyApproved = comp.CompanyApproved,
                                                    CharityNumber = comp.CharityNumber,
                                                    CompanyContactName = comp.CompanyContactName,
                                                    CompanyContactPhone = comp.CompanyContactPhone,
                                                    CompanyContactEmail = comp.CompanyContactEmail,
                                                    CompanyDetails = comp.CompanyDetails,
                                                    CompanyAddress = comp.CompanyAddress,
                                                    CompanyPostcode = comp.CompanyPostcode,
                                                    OpportunityTitle = opp.OpportunityTitle, 
                                                    OpportunityDescription = opp.OpportunityDescription,
                                                    OpportunityAdditionalInformation = opp.OpportunityAdditionalInformation,
                                                    OpportunityLocationName = opp.OpportunityLocationName,
                                                    OpportunityPostcode = opp.OpportunityPostcode,
                                                    MinNumberofVolunteers = opp.MinNumberofVolunteers,
                                                    MaxNumberofVolunteers = opp.MaxNumberofVolunteers,
                                                    OpportunityDate = opp.OpportunityDate,
                                                    OpportunityCreatedDate = opp.OpportunityCreatedDate,
                                                    OpportunityStatusId = opp.OpportunityStatusId,
                                                    OpportunityStatusDescription = oppStatus.OpportunityStatusDescription,                                                      
                                                }).ToArray();
            return this.View("Index", viewModel);            
        }

        /// <summary>
        /// GET: /Opportunity/Details/5
        /// </summary>
        /// <param name="id">The id of the opportunity</param>
        /// <returns>An ActionResult object</returns>
        public ActionResult Details(int id = 0)
        {
            Opportunity opportunity = this.db.Opportunity.Find(id);
            if (opportunity == null)
            {
                return this.HttpNotFound();
            }

            return this.View("Details", opportunity);
        }

        /// <summary>
        /// GET: /Opportunity/Edit/5
        /// </summary>
        /// <param name="id">The id of the opportunity to edit</param>
        /// <returns>An ActionResult object</returns>
        public ActionResult Edit(int id = 0)
        {
            Opportunity opportunity = this.db.Opportunity.Find(id);
            if (opportunity == null)
            {
                return this.HttpNotFound();
            }

            return this.View("Edit", opportunity);
        }

        /// <summary>
        /// POST: /Opportunity/Edit/5
        /// </summary>
        /// <param name="opportunity">The opportunity object to edit</param>
        /// <returns>An ActionResult object</returns>"
        [HttpPost]
        public ActionResult Edit(Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(opportunity).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index");
            }

            return this.View("Edit", opportunity);
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="disposing">A flag to indicate disposal</param>
        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}