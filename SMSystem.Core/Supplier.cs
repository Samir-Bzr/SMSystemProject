using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core

{
    public partial class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string location { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}