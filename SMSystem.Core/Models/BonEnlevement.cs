using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class BonEnlevement
    {
        public int IdBem { get; set; }
        public int? IdMatUser { get; set; }
        public DateTime? DateBem { get; set; }
        public DateTime? TimeBem { get; set; }
        public string ObsvBem { get; set; }
        public int? TotalHtBem { get; set; }
        public int? TotalTvaBem { get; set; }
        public int? TotalTtcBem { get; set; }
        public DateTime? DateTimeCreat { get; set; }
    }
}
