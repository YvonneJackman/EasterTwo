namespace ExternalWeb.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Migrations;
    using Data.Model;
    using WebMatrix.WebData;

    public class OpportunityController : Controller
    {
        private CommunityDaysDb db = new CommunityDaysDb();
       
        // GET: /Opportunity/
        [Authorize]
        public ActionResult Index()
        {
            int companyId = 0;
            if (this.User != null)
            {
                companyId = WebSecurity.GetUserId(User.Identity.Name);
            }

            var opportunity = this.db.Opportunity.Where(o => o.CompanyId.Equals(companyId));
                                  
            return this.View(opportunity.ToList());
        }

        // GET: /Opportunity/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Opportunity opportunity = this.db.Opportunity.Find(id);
            if (opportunity == null)
            {
                return this.HttpNotFound();
            }

            return this.View(opportunity);
        }

        /// <summary>
        /// GET: /Opportunity/Create
        /// This method is called before the create event used to extract any data needed for the data input
        /// </summary>
        /// <returns>An action result</returns>
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CompanyId = WebSecurity.GetUserId(User.Identity.Name);

            if (this.db.Company.Find(WebSecurity.GetUserId(User.Identity.Name)) != null)
            {
                ViewBag.CompanyName = this.db.Company.Find(WebSecurity.GetUserId(User.Identity.Name)).CompanyName;
            }

            return this.View();
        }

        // POST: /Opportunity/Create
        [Authorize]
        [HttpPost]
        public ActionResult Create(Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                opportunity.OpportunityStatusId = 1;
                
                if (this.User != null)
                {
                    if (this.User.Identity.Name != null)
                    {
                        opportunity.CompanyId = WebSecurity.GetUserId(User.Identity.Name);
                    }
                }

                opportunity.OpportunityCreatedDate = System.DateTime.Now;

                this.db.Opportunity.Add(opportunity);
                this.db.SaveChanges();
                return this.RedirectToAction("Index", "OpportunityController");
            }

            ViewBag.OpportunityStatusId = new SelectList(this.db.OpportunityStatus, "OpportunityStatusId", "OpportunityStatusDescription", opportunity.OpportunityStatusId);
            ViewBag.CompanyId = new SelectList(this.db.Company, "CompanyId", "CompanyName", opportunity.CompanyId);
            return this.View(opportunity);
        }
     
        // GET: /Opportunity/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Opportunity opportunity = this.db.Opportunity.Find(id);
            if (opportunity == null)
            {
                return this.HttpNotFound();
            }

            ViewBag.OpportunityStatusId = new SelectList(this.db.OpportunityStatus, "OpportunityStatusId", "OpportunityStatusDescription", opportunity.OpportunityStatusId);
            ViewBag.CompanyId = new SelectList(this.db.Company, "CompanyId", "CompanyName", opportunity.CompanyId);
            return this.View(opportunity);
        }

        // POST: /Opportunity/Edit/5
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(opportunity).State = EntityState.Modified;
                this.db.SaveChanges();
                return this.RedirectToAction("Index", "OpportunityController");
            }

            ViewBag.OpportunityStatusId = new SelectList(this.db.OpportunityStatus, "OpportunityStatusId", "OpportunityStatusDescription", opportunity.OpportunityStatusId);
            ViewBag.CompanyId = new SelectList(this.db.Company, "CompanyId", "CompanyName", opportunity.CompanyId);
            return this.View(opportunity);
        }
     
        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}