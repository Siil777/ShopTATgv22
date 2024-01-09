using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Shop.Core.Dto.AccuWeather.AcuWeatherRespondDto;

namespace Shop.Core.Dto.AccuWeather
{
    public class AcuWeatherResultDto
    {


        public string City { get; set; }
        public string Key { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
        public string Link { get; set; }

        //Day
        public string IconPhrase { get; set; }

        //HeadLine
        public string Text { get; set; }





    }
   


}
