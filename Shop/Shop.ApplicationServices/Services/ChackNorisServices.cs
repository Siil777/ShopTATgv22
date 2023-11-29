using Nancy.Json;
using Shop.Core.Dto.OpenWeastherDtos;
using Shop.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Shop.Core.ServiceInterface;
using Shop.Core.Dto.CuckNorrisDto;
using static System.Net.WebRequestMethods;
using System.Text.Json;
using System.Globalization;

namespace Shop.ApplicationServices.Services
{
    public class ChackNorisServices : ICackNorisServices
    {
        public async Task<ChackNorisResultDto> ChackNorrisResult(ChackNorisResultDto dto)
        {
            string url = "https://api.chucknorris.io/jokes/random";

            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);
                ChackNorisRespondRootDto chuckNorrisResult = JsonSerializer.Deserialize<ChackNorisRespondRootDto>(json);

                dto.categories = chuckNorrisResult.Categories;
                
                dto.icon_url = chuckNorrisResult.IconUrl;
                dto.id = chuckNorrisResult.Id;
                //dto.updated_at = DateTime.ParseExact(chuckNorrisResult.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss.ffffff"), "yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture);
                dto.url = chuckNorrisResult.Url;
                dto.value = chuckNorrisResult.Value;
            }

            return dto;
            
           

        }





    }

}

