using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.IService
{
    public interface IAgg_DropDownYORegisService
    {
        Task<IEnumerable<Agg_DropDownYORegisDTO>> GetYearOfRegData();

    }
}
