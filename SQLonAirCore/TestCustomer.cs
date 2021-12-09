using SQLonAirCore.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLonAirCore
{
    public class TestCustomer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [SQLonAirCalculation("concat(FirstName, ' ', LastName)")]
        public string FullName { get; set; }

        public int PlanId { get; set; }

        [SQLonAirLookup(typeof(Plan), "Name", "PlanId")]
        public string PlanName { get; set; }
        
        [SQLonAirAggregation(typeof(Invoice), "Total", "CustomerId")]
        public string TotalInvoicesAmount { get; set; }

    }
}
