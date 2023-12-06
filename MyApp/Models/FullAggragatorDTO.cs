﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Agg_DropDownMakeDTO
    {
        public int MakeId { get; set; }
        public string MakeName { get; set; }
        public int Id => MakeId;

    }
    public class Agg_DropDownModelDTO
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public int Id => ModelId;
    }
    public class Agg_DropDownYORegisDTO
    {
        public int YearId { get; set; }
        public int YearCode { get; set; }
        public int Id => YearId;
    }

    public class Agg_DropDownVariantDTO
    {
        public int VariantId { get; set; }
        public string VariantName { get; set; }
        public int Id => VariantId;
    }
    public class PV_AggregatorDTO
    {
        public string PurchaseAmount { get; set; }
        public int MakeId { get; set; }
        public int ModelId { get; set; }
        public int YearOfRegistration { get; set; }
        public int VariantId { get; set; }
        public string PriceBreak { get; set; }
        public string StockIn { get; set; }
        public string RCAvailable { get; set; }
        public int UserInfoId { get; set; }

    }

    public class PV_NewCarDealerDTO
    {
        public int UserInfoId { get; set; }
        public string PurchaseAmount { get; set; } = string.Empty;
        public string VehicleNumber { get; set; } = string.Empty;
        public string OdometerPicture { get; set; } = string.Empty;
        public string VehiclePicFromFront { get; set; } = string.Empty;
        public string VehiclePicFromBack { get; set; } = string.Empty;
        public string Invoice { get; set; } = string.Empty;
        public string PictOfOrginalRC { get; set; } = string.Empty;

        // Constructor to set UserInfoId

    }
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

