using System;
using System.Collections.Generic;

namespace LibraryAPI.Models
{
    public partial class Debts
    {
        public int Debtor { get; set; }
        public decimal DebtQuantity { get; set; }

        public virtual Users DebtorNavigation { get; set; }
    }
}
