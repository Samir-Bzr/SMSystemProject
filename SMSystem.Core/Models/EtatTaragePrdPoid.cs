using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class EtatTaragePrdPoid
    {
        public DateTime? DateGross { get; set; }
        public string MachineId { get; set; }
        public string Designation { get; set; }
        public int? TotalPoids { get; set; }
        public int? Shift06 { get; set; }
        public int? Shift14 { get; set; }
        public int? Shift22 { get; set; }
    }
}
