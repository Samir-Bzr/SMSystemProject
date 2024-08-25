using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class DetailBl
    {
        public int IdBl { get; set; }
        public string RefArtFini { get; set; }
        public int QteBl { get; set; }
        public decimal PuvBl { get; set; }
        public int? PaletissageBl { get; set; }
        public int? ColissageBl { get; set; }
        public decimal? TvaBl { get; set; }
        public decimal? RemiseBl { get; set; }
    }
}
