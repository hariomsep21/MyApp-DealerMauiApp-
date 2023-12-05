
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Model
{
    public enum paymentStatus
    {
        Failed,
        Pending,
        Success
        // Add other statuses as needed
    }
    public class PaymentDto
    {
        public int Id { get; set; }
        public decimal? Amount_Due { get; set; }

        public int CarId { get; set; } // Foreign key referencing CarId

        // Navigation property for the related Car


        // CarName, Variant, and Image properties from Car
        public string CarName { get; set; }
        public string Variant { get; set; }
        public paymentStatus? PaymentStatus { get; set; }

        //public DateTime DueDate { get; set; }
        //public DateTime StartDate { get; set; }
        //public decimal? AmountPaid { get; set; }
        //public decimal? ProcessingCharges { get; set; }

        //public string DaysLeft
        //{
        //    get; set;

        //}
        //public string AccountNumber { get; set; }


        //public string IFSCCode { get; set; }

        //public string BankName { get; set; }
        //public string Name { get; set; }
    }
}
