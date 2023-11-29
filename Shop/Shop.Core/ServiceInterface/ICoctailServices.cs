using Shop.Core.Dto.CoctailDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface
{
    public interface  ICoctailServices
    {
        Task<CoctailresultDto> CoctailResult(CoctailresultDto dto);
    }
}
