using System;
using System.Collections.Generic;

#nullable disable

namespace BrotherTeresaWebAPI.Models
{
    public partial class TblLog
    {
        public TblLog()
        {
            TblFoods = new HashSet<TblFood>();
            TblLocations = new HashSet<TblLocation>();
            TblPeople = new HashSet<TblPerson>();
            TblSupplies = new HashSet<TblSupply>();
            TblWeathers = new HashSet<TblWeather>();
        }

        public int LogId { get; set; }
        public string LogShortName { get; set; }
        public string LogDate { get; set; }

        public virtual ICollection<TblFood> TblFoods { get; set; }
        public virtual ICollection<TblLocation> TblLocations { get; set; }
        public virtual ICollection<TblPerson> TblPeople { get; set; }
        public virtual ICollection<TblSupply> TblSupplies { get; set; }
        public virtual ICollection<TblWeather> TblWeathers { get; set; }
    }
}
