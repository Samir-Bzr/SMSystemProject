using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class DetailComposit
    {
        public int CopsitId { get; set; }
        public string RefArtMat { get; set; }
        public int? CopsitQte { get; set; }
        public double? CopsitTaux { get; set; }
    }
}
