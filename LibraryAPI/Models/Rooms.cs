using System;
using System.Collections.Generic;

namespace LibraryAPI.Models
{
    public partial class Rooms
    {
        public Rooms()
        {
            Tables = new HashSet<Tables>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tables> Tables { get; set; }
    }
}
