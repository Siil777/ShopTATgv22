using Shop.Core.Dto.AccuWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface IAcuWeatherServices
    {
        Task<AcuWeatherResultDto> AcuWeatherResult(AcuWeatherResultDto dto);
    }
}
