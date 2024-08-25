using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class DetailBem
    {
        public int IdBem { get; set; }
        public int? IdArt { get; set; }
        public string RefArt { get; set; }
        public int? QteMatDem { get; set; }
        public decimal? PrxMatDem { get; set; }
        public int? NbrColisDem { get; set; }
        public int? Colisx1Dem { get; set; }
        public int? Colisx2Dem { get; set; }
        public decimal? PoidsDem { get; set; }
        public decimal? TotalPdsDem { get; set; }
    }
}
