using System;
using System.Collections.Generic;

#nullable disable

namespace SMSystem.Core.Models
{
    public partial class Users
    {
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Nomcomplet { get; set; }
        public string Pwd { get; set; }
        public int? IdRole { get; set; }
    }
}
