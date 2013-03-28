namespace ExternalWeb.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;
    using Data.Model;

    public class OpportunityViewModel
    {
        public Opportunity Opportunity { get; set; }

        public DateTime? EventDate { get; set; }
    }
}