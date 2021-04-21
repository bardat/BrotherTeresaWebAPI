using System;
using System.Collections.Generic;

#nullable disable

namespace BrotherTeresaWebAPI.Models
{
    public partial class TblRequest
    {
        public int RequestId { get; set; }
        public int PersonId { get; set; }
        public string RequestItem { get; set; }
        public string RequestDescription { get; set; }

        public virtual TblPerson Person { get; set; }
    }
}
