using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    public class PurchaseVehicleRecordModel
    {
        public string? CarName { get; set; }
        public string? Variant { get; set; }
        public int PurchaseId { get; set; }
        public string ActionRequired { get; set; }
    }
}
