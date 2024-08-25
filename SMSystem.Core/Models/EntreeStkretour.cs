using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class EntreeStkretour
    {
        public int? IdArt { get; set; }
        public int? SumQteRtourPrd { get; set; }
        public int? QteEntree { get; set; }
        public int? TpuAchat { get; set; }
        public int? TotalAchat { get; set; }
        public int? Tachat { get; set; }
        public int? PumAchat { get; set; }
    }
}
