namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;

    public class Opportunity
    {
        [Key]
        public int OpportunityId { get; set; }
        
        [ForeignKey("Company"), Column(Order = 0)]
        public int CompanyId { get; set; }
        
        [StringLength(200)]
        [Display(Name = "Title")]
        public string OpportunityTitle { get; set; }
        
        [StringLength(1000)]
        [MinLength(10)]
        [Required(ErrorMessage = "Description required.")]
        [Display(Name = "Description")]
        public string OpportunityDescription { get; set; }

        [StringLength(1000)]
        [Display(Name = "Additional Information")]
        public string OpportunityAdditionalInformation { get; set; }

        [Display(Name = "Location")]
        public string OpportunityLocationName { get; set; }

        [Display(Name = "Postcode")]
        public string OpportunityPostcode { get; set; }

        [Display(Name = "Volunteers (Min)")]
        public int MinNumberofVolunteers { get; set; }

        [Display(Name = "Volunteers (Max)")]
        public int MaxNumberofVolunteers { get; set; }
        
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public string OpportunityDate { get; set; }

        [Display(Name = "Posted Date")]    
        public DateTime OpportunityCreatedDate { get; set; }
        
        [ForeignKey("OpportunityStatus")]
        public int OpportunityStatusId { get; set; }

        [Display(Name = "Status")]    
        public virtual OpportunityStatus OpportunityStatus { get; set; }

        public virtual Company Company { get; set; }
    }
}
