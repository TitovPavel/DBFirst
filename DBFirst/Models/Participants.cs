using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class Participants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Attend { get; set; }
        public string Reason { get; set; }
        public int? AvatarId { get; set; }
        public int PartyId { get; set; }
        public int UserId { get; set; }
        public DateTime ArrivalDate { get; set; }

        public Images Avatar { get; set; }
        public Parties Party { get; set; }
        public Users User { get; set; }
    }
}
