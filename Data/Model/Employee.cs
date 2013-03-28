namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Display(Name = "Login")]
        public string NTLogin { get; set; }

        [Display(Name = "Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Email")]
        public string EmployeeEmail { get; set; }

        [Display(Name = "Department")]
        public string EmployeeDepartment { get; set; }

        [Display(Name = "Contact Number")]
        public string EmployeeContactNumber { get; set; }

        [Display(Name = "Postcode")]
        public string EmployeeWorkPostcode { get; set; }
    }
}
