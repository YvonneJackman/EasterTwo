namespace Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data.Model;

    /// <summary>
    /// Setting the base avoids having the full namespace prefix for the database name
    /// </summary>
    public class CommunityDaysDb : DbContext
    {
        public CommunityDaysDb()
                : base("CommunityDays")
        {
        }

        //// The <> param is the model object and Opportunity is the name of the table to create in the database
        public DbSet<Company> Company { get; set; }

        public DbSet<OpportunityStatus> OpportunityStatus { get; set; }

        public DbSet<Opportunity> Opportunity { get; set; }

        public DbSet<OpportunityEmployeeMap> OpportunityEmployeeMap { get; set; }

        public DbSet<EmployeeRole> EmployeeRole { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }
    }
}
