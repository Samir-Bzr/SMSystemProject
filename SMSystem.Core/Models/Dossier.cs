using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class Dossier
    {
        public string NameEntp { get; set; }
        public string ActivEntp { get; set; }
        public string AdresseEntp { get; set; }
        public string NrcEntp { get; set; }
        public string NifEntp { get; set; }
        public string NisEntp { get; set; }
        public string NaiEntp { get; set; }
        public byte[] LogoEntp { get; set; }
        public string Tel01Entp { get; set; }
        public string Tel02Entp { get; set; }
        public string Tel03Entp { get; set; }
        public string EmailEntp { get; set; }
    }
}
