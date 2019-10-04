using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class Users
    {
        public Users()
        {
            Participants = new HashSet<Participants>();
            Parties = new HashSet<Parties>();
        }

        public int Id { get; set; }
        public string Fio { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }

        public ICollection<Participants> Participants { get; set; }
        public ICollection<Parties> Parties { get; set; }
    }
}
