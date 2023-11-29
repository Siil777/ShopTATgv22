using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using Nancy;
using Nancy.Json;
using Shop.Core.Dto.AccuWeather;
using Shop.Core.Dto.CoctailDto;
using Shop.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Shop.ApplicationServices.Services.AcuWeatherServices;

namespace Shop.ApplicationServices.Services
{
    public class AcuWeatherServices : IAcuWeatherServices
    {




        public async Task<AcuWeatherResultDto> AcuWeatherResult(AcuWeatherResultDto dto)
        {
            string AccuWeatherAPI = "0W13ZaWmgJDBaIJNASqT4MS8d3WcfzTV";

            using (WebClient client = new WebClient())
            {
                // Location API call to get the key (id) of the city
                string searchUrl = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={AccuWeatherAPI}&q={dto.City}";

                try
                {
                    string searchJson = client.DownloadString(searchUrl);
                    AcuWeatherRespondDto locationResult = new JavaScriptSerializer().Deserialize<List<AcuWeatherRespondDto>>(searchJson).FirstOrDefault();

                    dto.Key = locationResult.Key;

                    // Forecast API call
                    string forecastUrl = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{dto.Key}?apikey={AccuWeatherAPI}";
                    string forecastJson = client.DownloadString(forecastUrl);
                    AcuWeatherForecastResponseRoot forecastResult = new JavaScriptSerializer().Deserialize<AcuWeatherForecastResponseRoot>(forecastJson);

                    dto.Minimum = forecastResult.DailyForecasts.FirstOrDefault().Temperature.Minimum.Value;
                    dto.Maximum = forecastResult.DailyForecasts.FirstOrDefault().Temperature.Maximum.Value;
                    dto.Link = forecastResult.DailyForecasts.FirstOrDefault().Link;
                }
                catch (WebException ex)
                {
                    
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return dto;
        }





    }
}







