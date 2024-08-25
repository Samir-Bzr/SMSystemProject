using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class BonLivraison
    {
        public int IdBl { get; set; }
        public int? IdClt { get; set; }
        public DateTime? DateBl { get; set; }
        public string ModeBl { get; set; }
        public string ObsvBl { get; set; }
        public decimal? TotalHtBl { get; set; }
        public decimal? TotalTvaBl { get; set; }
        public decimal? TotalTtcBl { get; set; }
        public DateTime? Datetimecreation { get; set; }
        public string IsInvoiced { get; set; }
        public string NumFact { get; set; }
    }
}
