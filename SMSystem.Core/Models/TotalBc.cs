using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class TotalBc
    {
        public int IdBc { get; set; }
        public decimal? SommeMht { get; set; }
        public decimal? SommeMtva { get; set; }
        public decimal? SommeMttc { get; set; }
    }
}
