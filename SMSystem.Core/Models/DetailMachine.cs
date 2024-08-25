using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class DetailMachine
    {
        public string IdMachine { get; set; }
        public DateTime? DatePanne { get; set; }
        public string TypePanne { get; set; }
        public int? DureePanne { get; set; }
        public string Obsv { get; set; }
    }
}
