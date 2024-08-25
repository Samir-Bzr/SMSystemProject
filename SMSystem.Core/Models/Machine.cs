using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class Machine
    {
        public string IdMachine { get; set; }
        public string RefMachine { get; set; }
        public string TypeMachine { get; set; }
        public string StatusMachine { get; set; }
        public int? IdUnit { get; set; }
    }
}
