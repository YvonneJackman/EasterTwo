namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class OpportunityEmployeeMap
    {
        [Key]       
        public int OpportunityEmployeeMapId { get; set; }
       
        [ForeignKey("Opportunity"), Column(Order = 0)]
        public int OpportunityId { get; set; }
       
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
       
        [ForeignKey("EmployeeRole")]
        public int EmployeeRoleId { get; set; }

        public virtual Opportunity Opportunity { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual EmployeeRole EmployeeRole { get; set; }
    }
}