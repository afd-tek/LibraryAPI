using System;
using System.Collections.Generic;

namespace LibraryAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Books = new HashSet<Books>();
            Tables = new HashSet<Tables>();
        }

        public int Id { get; set; }
        public string Tckimlik { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Utype { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string StudentNumber { get; set; }
        public string Phone { get; set; }

        public virtual Debts Debts { get; set; }
        public virtual ICollection<Books> Books { get; set; }
        public virtual ICollection<Tables> Tables { get; set; }
    }
}
