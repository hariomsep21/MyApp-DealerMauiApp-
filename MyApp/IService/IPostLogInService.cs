using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.IService
{
    public interface IPostLogInService
    {
        Task<bool> PostLoginNumberAsync(string mobileNumber);
    }
}
