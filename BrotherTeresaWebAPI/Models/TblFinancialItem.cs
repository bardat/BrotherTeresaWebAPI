using System;
using System.Collections.Generic;

#nullable disable

namespace BrotherTeresaWebAPI.Models
{
    public partial class TblFinancialItem
    {
        public int FinancialItemId { get; set; }
        public string FinancialItemName { get; set; }
        public string FinancialItemDescription { get; set; }
        public string FinancialItemDonor { get; set; }
        public string FinancialItemIsMoney { get; set; }
        public double? FinancialItemCashAmount { get; set; }
    }
}
