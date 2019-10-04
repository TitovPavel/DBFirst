using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class SponsorsParties
    {
        public int Id { get; set; }
        public int PartyId { get; set; }
        public int SponsorId { get; set; }

        public Parties Party { get; set; }
        public Sponsors Sponsor { get; set; }
    }
}
