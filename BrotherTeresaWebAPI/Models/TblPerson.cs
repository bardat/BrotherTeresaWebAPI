using System;
using System.Collections.Generic;

#nullable disable

namespace BrotherTeresaWebAPI.Models
{
    public partial class TblPerson
    {
        public TblPerson()
        {
            TblRequests = new HashSet<TblRequest>();
        }

        public int PersonId { get; set; }
        public int LogId { get; set; }
        public string PersonName { get; set; }
        public string PersonDescription { get; set; }
        public string PersonNote { get; set; }
        public string PersonGender { get; set; }
        public string PersonAge { get; set; }
        public string PersonRace { get; set; }
        public string PersonHeight { get; set; }
        public string PersonWeight { get; set; }
        public string PersonImageUrl { get; set; }

        public virtual TblLog Log { get; set; }
        public virtual ICollection<TblRequest> TblRequests { get; set; }
    }
}
