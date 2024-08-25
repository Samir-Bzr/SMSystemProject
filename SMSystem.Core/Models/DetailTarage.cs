using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class DetailTarage
    {
        public int GrossId { get; set; }
        public string RefArtFini { get; set; }
        public DateTime? DateGross { get; set; }
        public DateTime? TimeGross { get; set; }
        public int? Gross { get; set; }
        public string MachineId { get; set; }
    }
}
