namespace InternalWeb.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public class OpportunityViewModel
    {
        public int OpportunityId { get; set; }

        public int CompanyId { get; set; }

        [Display(Name = "Approved")]
        public bool CompanyApproved { get; set; }

        [Display(Name = "Name")]
        public string CompanyName { get; set; }

        [Display(Name = "Charity Number")]
        public string CharityNumber { get; set; }
        
        [Display(Name = "Contact Name")]
        public string CompanyContactName { get; set; }

        [Display(Name = "Contact Phone")]
        public string CompanyContactPhone { get; set; }
        
        [Display(Name = "Contact Email")]
        public string CompanyContactEmail { get; set; }

        [Display(Name = "Details")]
        public string CompanyDetails { get; set; }

        [Display(Name = "Address")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Postcode")]
        public string CompanyPostcode { get; set; }

        [Display(Name = "Title")]
        public string OpportunityTitle { get; set; }

        [Display(Name = "Description")]
        public string OpportunityDescription { get; set; }

        [Display(Name = "Additional Information")]
        public string OpportunityAdditionalInformation { get; set; }

        [Display(Name = "Location")]
        public string OpportunityLocationName { get; set; }

        [Display(Name = "Postcode")]
        public string OpportunityPostcode { get; set; }

        [Display(Name = "Group Size (Min)")]
        public int MinNumberofVolunteers { get; set; }

        [Display(Name = "Group Size")]
        public int MaxNumberofVolunteers { get; set; }

        [Display(Name = "Date")]    
        public string OpportunityDate { get; set; }

        [Display(Name = "Posted Date")]   
        public DateTime OpportunityCreatedDate { get; set; }

        public int OpportunityStatusId { get; set; }

        [Display(Name = "Status")]    
        public string OpportunityStatusDescription { get; set; }        
    }
}