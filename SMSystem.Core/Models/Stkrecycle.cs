using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class Stkrecycle
    {
        public string RefArtRcyl { get; set; }
        public string Designation { get; set; }
        public string TypeArt { get; set; }
        public string NatArt { get; set; }
        public decimal? TauxTva { get; set; }
        public int? StockMin { get; set; }
        public int? QteEntree { get; set; }
        public int? QteSortie { get; set; }
        public decimal? Puachat { get; set; }
        public decimal? Puvente { get; set; }
        public int? QteStock { get; set; }
        public int? TotalStock { get; set; }
        public int? EtatStock { get; set; }
        public int? ColisX1 { get; set; }
        public int? ColisX2 { get; set; }
        public int? PaletX1 { get; set; }
        public int? PaletX2 { get; set; }
        public int? Colissage { get; set; }
        public int? Palletissage { get; set; }
        public int? NbrColis { get; set; }
        public decimal? DefaultPds { get; set; }
        public decimal? PdsUnit { get; set; }
        public decimal? PdsStock { get; set; }
    }
}
