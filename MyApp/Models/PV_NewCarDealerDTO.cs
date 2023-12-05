using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class PV_NewCarDealerDTO
    {
        public int UserInfoId { get; set; }
        public string PurchaseAmount { get; set; } = string.Empty;
        public string VehicleNumber { get; set; }=string.Empty;
        public string OdometerPicture { get; set; } = string.Empty;
        public string VehiclePicFromFront { get; set; } = string.Empty;
        public string VehiclePicFromBack { get; set; } = string.Empty;
        public string Invoice { get; set; } = string.Empty;
        public string PictOfOrginalRC { get; set; } = string.Empty;

        // Constructor to set UserInfoId
       
    }

   
}
