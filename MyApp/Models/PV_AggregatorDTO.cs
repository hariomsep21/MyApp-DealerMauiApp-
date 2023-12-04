using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
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
}
