using System;
using System.Collections.Generic;

namespace DBFirst.Models
{
    public partial class Images
    {
        public Images()
        {
            Participants = new HashSet<Participants>();
            Sponsors = new HashSet<Sponsors>();
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }

        public ICollection<Participants> Participants { get; set; }
        public ICollection<Sponsors> Sponsors { get; set; }
    }
}
