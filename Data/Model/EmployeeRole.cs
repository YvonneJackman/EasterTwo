namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class EmployeeRole
    {
        [Key]
        public int OpportunityRoleId { get; set; }

        [StringLength(200)]
        [Display(Name = "Role Description")]
        public string OpportunityRoleDescription { get; set; }
    }
}
