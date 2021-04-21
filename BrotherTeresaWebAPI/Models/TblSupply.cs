using System;
using System.Collections.Generic;

#nullable disable

namespace BrotherTeresaWebAPI.Models
{
    public partial class TblSupply
    {
        public int SupplyId { get; set; }
        public int LogId { get; set; }
        public string SupplyName { get; set; }
        public string SupplyImgUrl { get; set; }

        public virtual TblLog Log { get; set; }
    }
}
