namespace Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Text;    
    using Data.Migrations;
    using Data.Model;   
    using WebMatrix.WebData;
 
    public class Configuration : DbMigrationsConfiguration<CommunityDaysDb>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CommunityDaysDb context)
         {
             ////  This method will be called after migrating to the latest version.

             ////  You can use the DbSet<T>.AddOrUpdate() helper extension method 
             ////  to avoid creating duplicate seed data. E.g.
             ////
             ////    context.People.AddOrUpdate(
             ////      p => p.FullName,
             ////      new Person { FullName = "Andrew Peters" },
             ////      new Person { FullName = "Brice Lambson" },
             ////      new Person { FullName = "Rowan Miller" }
             ////    );
             ////

             WebSecurity.InitializeDatabaseConnection("CommunityDays", "UserProfile", "UserId", "UserName", autoCreateTables: true);
         
             this.SetupStaticLookupData(context);
             this.SetupTestData(context);
         }

        /// <summary>
        /// Wrapper for SaveChanges adding the Validation Messages to the generated exception
        /// </summary>
        /// <param name="context">The context.</param>
        private void SaveChanges(CommunityDaysDb context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), 
                    ex); // Add the original exception as the innerException
            }
        }

        /// <summary>
        /// Create static lookup data, required not just for test
        /// </summary>
        /// <param name="context">The database context</param>
        private void SetupStaticLookupData(CommunityDaysDb context)
        {
            var newOpportunityStatuses = new List<Data.Model.OpportunityStatus>
            {
                new Data.Model.OpportunityStatus { OpportunityStatusId = 1, OpportunityStatusDescription = "Request received" },
                new Data.Model.OpportunityStatus { OpportunityStatusId = 2, OpportunityStatusDescription = "Request approved" },
                new Data.Model.OpportunityStatus { OpportunityStatusId = 3, OpportunityStatusDescription = "Organisation contacted" },
                new Data.Model.OpportunityStatus { OpportunityStatusId = 4, OpportunityStatusDescription = "Volunteers signed-up" },
                new Data.Model.OpportunityStatus { OpportunityStatusId = 5, OpportunityStatusDescription = "Risk assessment completed" },
                new Data.Model.OpportunityStatus { OpportunityStatusId = 6, OpportunityStatusDescription = "Team leader allocated" },
                new Data.Model.OpportunityStatus { OpportunityStatusId = 7, OpportunityStatusDescription = "Project ready to go" },
                new Data.Model.OpportunityStatus { OpportunityStatusId = 8, OpportunityStatusDescription = "Feedback completed" },
                new Data.Model.OpportunityStatus { OpportunityStatusId = 9, OpportunityStatusDescription = "CaH Manager signed off" }                
            };
            newOpportunityStatuses.ForEach(s => context.OpportunityStatus.AddOrUpdate(s));
  
            var newEmployeeRole = new List<Data.Model.EmployeeRole>
            {
                new Data.Model.EmployeeRole { OpportunityRoleId = 1, OpportunityRoleDescription = "Volunteer" },
                new Data.Model.EmployeeRole { OpportunityRoleId = 2, OpportunityRoleDescription = "Project Leader" },
                new Data.Model.EmployeeRole { OpportunityRoleId = 3, OpportunityRoleDescription = "Champion" },
                new Data.Model.EmployeeRole { OpportunityRoleId = 4, OpportunityRoleDescription = "Community Manager" },
            };
            newEmployeeRole.ForEach(s => context.EmployeeRole.AddOrUpdate(s));
            //// context.SaveChanges();
            this.SaveChanges(context);
        }

        /// <summary>
        /// Create test data
        /// </summary>
        /// <param name="context">The database context</param>
        private void SetupTestData(CommunityDaysDb context)
        {
            var newUserProfiles = new List<Data.Model.UserProfile>
            {
                new Data.Model.UserProfile { UserId = 1, UserName = "one" },
                new Data.Model.UserProfile { UserId = 2, UserName = "two" },
                new Data.Model.UserProfile { UserId = 3, UserName = "three" },
                new Data.Model.UserProfile { UserId = 4, UserName = "four" },
                new Data.Model.UserProfile { UserId = 5, UserName = "five" },
            };

            newUserProfiles.ForEach(s => context.UserProfiles.AddOrUpdate(s));

            var newCompanies = new List<Data.Model.Company>
            {
                new Data.Model.Company { CompanyId = 1, UserId = 1, CompanyName = "BREADALBANE CANOE CLUB", CompanyApproved = true, CompanyContactName = "Mary Shoe", CompanyContactEmail = "Mary@canoe.com", CompanyContactPhone = "02392 123123", CompanyAddress = "ABERFELDY", CompanyPostcode = "BD23 1PT", CharityNumber = "0", CompanyDetails = "Breadalbane Canoe Club is an active and inclusive club promoting both competitive and recreational paddling. We encourage participation at all levels and work to protect, improve and promote responsible paddle sports." },
                new Data.Model.Company { CompanyId = 2, UserId = 2, CompanyName = "RNLI", CompanyApproved = true, CompanyContactName = "Brian Boat", CompanyContactEmail = "Brian@RNLI.com", CompanyContactPhone = "02392 998877", CompanyAddress = "London", CompanyPostcode = string.Empty, CharityNumber = "0", CompanyDetails = "The RNLI is the charity that saves lives at sea" },            
                new Data.Model.Company { CompanyId = 3, UserId = 3, CompanyName = "St Stephens Primary School, Blairgowrie", CompanyApproved = true, CompanyContactName = "Sarah School", CompanyContactEmail = "Sarah@school.com", CompanyContactPhone = "02392 334455", CompanyAddress = "Coupar Angus", CompanyPostcode = string.Empty, CharityNumber = "0", CompanyDetails = "Fund-raising for school projects" },            
                new Data.Model.Company { CompanyId = 4, UserId = 4, CompanyName = "Whizz Kidz", CompanyApproved = true, CompanyContactName = "Keith Kidd", CompanyContactEmail = "Keith@whizzkids.com", CompanyContactPhone = "02392 889900", CompanyAddress = "London", CompanyPostcode = string.Empty, CharityNumber = "0", CompanyDetails = "Whizz-Kidz provides disabled children with the essential wheelchairs and other mobility equipment they need to lead fun and active childhoods." },      
                new Data.Model.Company { CompanyId = 5, UserId = 5, CompanyName = "Breast Cancer Care", CompanyApproved = true, CompanyContactName = "Brenda Boom", CompanyContactEmail = "Brenda@bcc.com", CompanyContactPhone = "02392 223355", CompanyAddress = "Scotland", CompanyPostcode = string.Empty, CharityNumber = "0", CompanyDetails = "http://www.breastcancercare.org.uk/ Follow Breast Cancer Care Scotland on Twitter @BccareScot" },              
            };

            newCompanies.ForEach(s => context.Company.AddOrUpdate(s));

            var today = System.DateTime.Now;
            var newOpportunities = new List<Data.Model.Opportunity>
            {
                new Data.Model.Opportunity { OpportunityId = 1, OpportunityStatusId = 2, CompanyId = 1, MaxNumberofVolunteers = 1, OpportunityLocationName = "ABERFELDY", OpportunityPostcode = "BD23 1PT", OpportunityTitle = "BREADALBANE CANOE CLUB EVENT", OpportunityDescription = "ASSIST AS HELPERS AT OUR SLALOM KAYAKING COMPETITION IN ABERFELDY 1ST & 2ND OF APRIL - CAR PARKING, CATERING TENT, HELPING CHILDREN GET IN AND OUT OF BOATS, HELP CARRY BOATS, ETC. OUR OTHER COMPETITION AT GRANDTULLY ON THE 30TH AND 31ST OF MARCH WOULD BENEFIT FROM ANY HELPERS AS WELL. IT IS A PREMIER EVENT AND SOME PREVIOUS OLYMPIC MEDALISTS COMPETE THERE. THE ADVENTURE SHOW ALSO FILMS THE EVENT.", OpportunityDate = today.AddDays(5).ToShortDateString(), OpportunityCreatedDate = today },
                new Data.Model.Opportunity { OpportunityId = 2, OpportunityStatusId = 2, CompanyId = 2, MaxNumberofVolunteers = 10, OpportunityLocationName = "London", OpportunityPostcode = string.Empty, OpportunityTitle = "London Lifeboat Day", OpportunityDescription = "London Lifeboat Day is coming up on 30th April and we are looking for volunteers to collect donations at London stations.", OpportunityDate = today.AddDays(10).ToShortDateString(), OpportunityCreatedDate = today },
                new Data.Model.Opportunity { OpportunityId = 3, OpportunityStatusId = 3, CompanyId = 3, MaxNumberofVolunteers = 5, OpportunityLocationName = "Blairgowrie", OpportunityPostcode = string.Empty, OpportunityTitle = "St Stephens Primary School, Blairgowriee", OpportunityDescription = "The School have the use of a charity shop in Coupar Angus from Sunday 21st April until Saturday 27th April and are looking for volunteers who could help staff the shop from 10-4pm", OpportunityDate = today.AddDays(15).ToShortDateString(), OpportunityCreatedDate = today },
                new Data.Model.Opportunity { OpportunityId = 4, OpportunityStatusId = 4, CompanyId = 4, MaxNumberofVolunteers = 2, OpportunityLocationName = "London", OpportunityPostcode = string.Empty, OpportunityTitle = "Whizz Kidz", OpportunityDescription = "Whizz Kidz are looking for help at the following events: London Marathon 21st April (stewarding) and Sitting Volleyball Tournament, Reebok Centre, Canary Wharf 28th Feb (helpers).", OpportunityDate = today.AddDays(20).ToShortDateString(), OpportunityCreatedDate = today },
                new Data.Model.Opportunity { OpportunityId = 5, OpportunityStatusId = 5, CompanyId = 5, MaxNumberofVolunteers = 25, MinNumberofVolunteers = 5, OpportunityLocationName = "Scotland", OpportunityPostcode = string.Empty, OpportunityTitle = "Breast Cancer Care - Big Pink Bucket Collection", OpportunityDescription = "We are looking for volunteers all over Scotland for the week commencing 4th who would be willing to either organise their own collections in their area or be part of a collection organised by BCC. Dates & Locations available at: www.breastcancercare.org.uk/bigpinkbucketcollection", OpportunityDate = today.AddDays(25).ToShortDateString(), OpportunityCreatedDate = today }            
            };       
              
            newOpportunities.ForEach(s => context.Opportunity.AddOrUpdate(s));
            //// context.SaveChanges();
            this.SaveChanges(context);
         }
    }
}