using Shop.Core.Dto.CuckNorrisDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface ICackNorisServices
    {
        Task<ChackNorisResultDto> ChackNorrisResult(ChackNorisResultDto dto);


    }
}
