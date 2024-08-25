using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class Client
    {
        public int IdClt { get; set; }
        public string NomClt { get; set; }
        public string CategClt { get; set; }
        public string AdrClt { get; set; }
        public string VilleClt { get; set; }
        public string TelClt { get; set; }
        public string MobilClt { get; set; }
        public string EmailClt { get; set; }
        public string NrcClt { get; set; }
        public string NifClt { get; set; }
        public string NisClt { get; set; }
        public string NaiClt { get; set; }
        public decimal? SoldeCreance { get; set; }
        public DateTime? Datetimecreation { get; set; }
    }
}
