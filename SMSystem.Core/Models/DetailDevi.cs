using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class DetailDevi
    {
        public int IdDevis { get; set; }
        public int? IdArt { get; set; }
        public int? QteDevis { get; set; }
        public decimal? PuvDevis { get; set; }
    }
}
