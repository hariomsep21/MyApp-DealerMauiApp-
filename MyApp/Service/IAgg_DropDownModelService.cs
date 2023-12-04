using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Service
{
    public interface IAgg_DropDownModelService
    {
        Task<IEnumerable<Agg_DropDownModelDTO>> GetModelData();

    }
}
