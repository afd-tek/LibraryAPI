using System;
using System.Collections.Generic;

namespace LibraryAPI.Models
{
    public partial class Tables
    {
        public int Id { get; set; }
        public int Room { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public int? Owner { get; set; }

        public virtual Users OwnerNavigation { get; set; }
        public virtual Rooms RoomNavigation { get; set; }
    }
}
