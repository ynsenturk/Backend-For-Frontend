using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.API.Models
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public string BookingNumber { get; set; }
        public DateTime? ETADate { get; set; }
        public double TotalPrice { get; set; }
        public double CarrierPayment { get; set; }
        public string PaymentType { get; set; }

    }
}
