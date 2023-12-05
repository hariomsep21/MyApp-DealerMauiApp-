using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class PV_OpenMarketDTO
    {
        public int UserInfoId { get; set; }
        public string PurchaseAmount { get; set; } = string.Empty;
        public string TokenAmount { get; set; } = string.Empty;
        public string WithholdAmount { get; set; } = string.Empty;

        [MaxLength(12)]
        public string SellerContactNumber { get; set; } = string.Empty;

        [EmailAddress]
        [RegularExpression(@"^[\w-]+@gmail\.(com|in)$", ErrorMessage = "Email must end with @gmail.com or @gmail.in")]
        public string SellerEmailAddress { get; set; } = string.Empty;
        public string VehicleNumber { get; set; } = string.Empty;
        public string PaymentProof { get; set; } = string.Empty;
        public string SellerAdhaar { get; set; } = string.Empty;
        public string SellerPAN { get; set; } = string.Empty;
        public string PictureOfOriginalRC { get; set; } = string.Empty;
        public string OdometerPicture { get; set; } = string.Empty;
        public string VehiclePictureFromFront { get; set; } = string.Empty;
        public string VehiclePictureFromBack { get; set; } = string.Empty;
    }
}
