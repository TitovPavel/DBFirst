using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class Contacts
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Sponsors Sponsors { get; set; }
    }
}
