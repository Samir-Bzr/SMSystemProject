using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class DetailBrm
    {
        public int IdBrm { get; set; }
        public int? IdArt { get; set; }
        public string RefArt { get; set; }
        public int? QteRceptMat { get; set; }
        public int? PrxRceptMat { get; set; }
        public int? NbrColisRcept { get; set; }
        public int? Colisx1Rcept { get; set; }
        public int? Colisx2Rcept { get; set; }
        public int? PoidsRcept { get; set; }
        public int? TotPdsRcept { get; set; }
    }
}
