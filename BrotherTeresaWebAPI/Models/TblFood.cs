using System;
using System.Collections.Generic;

#nullable disable

namespace BrotherTeresaWebAPI.Models
{
    public partial class TblFood
    {
        public int FoodId { get; set; }
        public int LogId { get; set; }
        public string FoodName { get; set; }
        public string FoodImgUrl { get; set; }

        public virtual TblLog Log { get; set; }
    }
}
