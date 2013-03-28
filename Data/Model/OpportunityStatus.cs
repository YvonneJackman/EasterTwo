namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OpportunityStatus
    {
        [Key]
        public int OpportunityStatusId { get; set; }

        [StringLength(200)]
        [Display(Name = "Status")]
        public string OpportunityStatusDescription { get; set; }
    }
}
