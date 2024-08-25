using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class BonProduction
    {
        public int IdBprod { get; set; }
        public int? IdAtelier { get; set; }
        public string DateProd { get; set; }
        public string ModeProd { get; set; }
        public string ObsvProd { get; set; }
        public int? TotalHtProd { get; set; }
        public int? TotalTvaProd { get; set; }
        public int? TotalTtcProd { get; set; }
        public DateTime? DateTimeCreat { get; set; }
    }
}
