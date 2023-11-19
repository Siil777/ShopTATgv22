using Shop.Core.Dto;
using Shop.Core.Dto.OpenWeastherDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface IWheatherForecastServices
    {
        Task<OpenWeatherResultDto> OpenWeatherResult(OpenWeatherResultDto dto);
    }
}
