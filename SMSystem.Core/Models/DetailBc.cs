using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class DetailBc
    {
        public int IdBc { get; set; }
        public int? IdArt { get; set; }
        public int? QteCmd { get; set; }
        public decimal? PuaCmd { get; set; }
    }
}
