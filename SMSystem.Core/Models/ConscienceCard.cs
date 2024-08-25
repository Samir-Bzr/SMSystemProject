using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class ConscienceCard
    {
        public int Id { get; set; }
        public string DepName { get; set; }
        public string MaterialName { get; set; }
        public int Quantity { get; set; }
        public int OutComeNo { get; set; }
        public DateTime OutComeDate { get; set; }
        public string ReciverName { get; set; }
        public DateTime ReciverDate { get; set; }
        public string ReciverSign { get; set; }
        public string DepTransportName { get; set; }
        public string DepTransportReciverName { get; set; }
        public DateTime DepTransportReciverDate { get; set; }
        public string DepTransportReciverSign { get; set; }
        public DateTime AddDate { get; set; }
        public int CustomerId { get; set; }


        // Navigations
       

        public Customer customers { get; set; }

    }
}
