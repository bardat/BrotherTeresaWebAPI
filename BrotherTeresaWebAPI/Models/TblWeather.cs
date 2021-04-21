using System;
using System.Collections.Generic;

#nullable disable

namespace BrotherTeresaWebAPI.Models
{
    public partial class TblWeather
    {
        public int WeatherId { get; set; }
        public int LogId { get; set; }
        public string WeatherTemp { get; set; }
        public string WeatherDescription { get; set; }

        public virtual TblLog Log { get; set; }
    }
}
