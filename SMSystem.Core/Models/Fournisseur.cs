using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class Fournisseur
    {
        public int IdFrs { get; set; }
        public string NomFrs { get; set; }
        public string CategFrs { get; set; }
        public string AdrFrs { get; set; }
        public string VilleFrs { get; set; }
        public string TelFrs { get; set; }
        public string MobilFrs { get; set; }
        public string EmailFrs { get; set; }
        public string NrcFrs { get; set; }
        public string NifFrs { get; set; }
        public string NisFrs { get; set; }
        public string NaiFrs { get; set; }
        public double? SoldeDette { get; set; }
        public DateTime? Datetimecreation { get; set; }
    }
}
