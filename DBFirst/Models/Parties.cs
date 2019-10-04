using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class Parties
    {
        public Parties()
        {
            Participants = new HashSet<Participants>();
            SponsorsParties = new HashSet<SponsorsParties>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int OwnerId { get; set; }

        public Users Owner { get; set; }
        public ICollection<Participants> Participants { get; set; }
        public ICollection<SponsorsParties> SponsorsParties { get; set; }
    }
}
