using System;
using System.Collections.Generic;

namespace LibraryAPI.Models
{
    public partial class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime? State { get; set; }
        public int? Taker { get; set; }
        public bool? IsTaken { get; set; }
        public string Desk { get; set; }

        public virtual Users TakerNavigation { get; set; }
    }
}
