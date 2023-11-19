using Nancy.Json;
using Shop.Core.Dto;
using Shop.Core.Dto.OpenWeastherDtos;
using Shop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Shop.Core.ServiceInterface;

namespace Shop.ApplicationServices.Services
{
    public class WheatherForecastServices: IWheatherForecastServices
    {
        public async Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto)
        {
            string idOpendWeather = "";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={dto.City}&units=metric&appid={idOpendWeather}";

            using (WebClient client = new WebClient())
            {

                string json= client.DownloadString(url);

                OpenWeatherRespondsRootDto weatherResult = new JavaScriptSerializer().Deserialize<OpenWeatherRespondsRootDto>(json);



                dto.City = weatherResult.Name;
                dto.Temp = weatherResult.Main.Temp;
                dto.FeelsLike = weatherResult.Main.Feels_like;
                dto.Humidity = weatherResult.Main.Humidity;
                dto.Pressure = weatherResult.Main.Pressure;
                dto.WindSpeed = weatherResult.Wind.Speed;
                dto.Description = weatherResult.Weather[0].Description;



















            }


            return dto;
        }

    }
}
