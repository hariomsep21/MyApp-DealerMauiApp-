using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.IService
{
    public interface IPV_NewCarDealerService
    {
        Task<bool> PostMobileNumberAsync(PV_NewCarDealerDTO NewCarDetails);

    }
}
