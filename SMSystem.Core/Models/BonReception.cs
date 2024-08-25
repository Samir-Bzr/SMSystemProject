using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class BonReception
    {
        public int IdBrm { get; set; }
        public int? IdFrs { get; set; }
        public string DateBrm { get; set; }
        public string ModeBrm { get; set; }
        public string ObsvBrm { get; set; }
        public int? TotalHtBrm { get; set; }
        public int? TotalTvaBrm { get; set; }
        public int? TotalTtcBrm { get; set; }
        public DateTime? DateTimeCreat { get; set; }
    }
}
