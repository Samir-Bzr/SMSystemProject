using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class BonCommand
    {
        public int IdBc { get; set; }
        public int? IdFrs { get; set; }
        public DateTime? DateBc { get; set; }
        public string NumPiece { get; set; }
        public string TypePiece { get; set; }
        public string ObsvBc { get; set; }
        public decimal? TotalHtBc { get; set; }
        public decimal? TotalTvaBc { get; set; }
        public decimal? TotalTtcBc { get; set; }
        public DateTime? DateTimeCreat { get; set; }
    }
}
