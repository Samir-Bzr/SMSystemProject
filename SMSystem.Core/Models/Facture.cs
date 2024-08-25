using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class Facture
    {
        public int IdFact { get; set; }
        public int? IdClt { get; set; }
        public string NumFact { get; set; }
        public DateTime? DateFact { get; set; }
        public string NatFact { get; set; }
        public string ObsvFact { get; set; }
        public decimal? TothtFact { get; set; }
        public decimal? TotvaFact { get; set; }
        public decimal? TottcFact { get; set; }
    }
}
