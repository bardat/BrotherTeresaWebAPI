using System;
using System.Collections.Generic;

#nullable disable

namespace BrotherTeresaWebAPI.Models
{
    public partial class TblLocation
    {
        public int LocationId { get; set; }
        public int LogId { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public string LocationImageUrl { get; set; }
        public string LocationAddress { get; set; }
        public string LocationGps { get; set; }

        public virtual TblLog Log { get; set; }
    }
}
