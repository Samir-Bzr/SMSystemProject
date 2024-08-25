using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class HistReglClt
    {
        public int IdClt { get; set; }
        public int? IdBl { get; set; }
        public DateTime? DateBl { get; set; }
        public int? IdMode { get; set; }
        public decimal? MontTtcBl { get; set; }
        public DateTime? DateReglement { get; set; }
        public decimal? MontReglement { get; set; }
        public string ModeReglement { get; set; }
        public string NumComptclt { get; set; }
        public string NumVersement { get; set; }
        public string NumVirement { get; set; }
        public string NumCheque { get; set; }
        public DateTime? DateVersement { get; set; }
        public DateTime? DateVirement { get; set; }
        public DateTime? DateCheque { get; set; }
    }
}
