using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccuWeatherApp.Model.City
{

    public class City 
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public Country Country { get; set; }
        public Administrativearea AdministrativeArea { get; set; }

        [JsonIgnore]
        public string NameAndCountry => $"{LocalizedName}, {Country.LocalizedName}, {AdministrativeArea.LocalizedName}";
    }


}
