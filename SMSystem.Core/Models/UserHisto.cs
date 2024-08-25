using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class UserHisto
    {
        public int IdHisto { get; set; }
        public int? IdUser { get; set; }
        public string Login { get; set; }
        public string Nomcomplet { get; set; }
        public DateTime? DateEntree { get; set; }
        public DateTime? DateSortie { get; set; }
        public int? NbrLogin { get; set; }
    }
}
