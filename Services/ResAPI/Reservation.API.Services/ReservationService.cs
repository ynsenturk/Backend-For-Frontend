using Reservation.API.Infrastructure;
using Reservation.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservation.API.Services
{
    public class ReservationService : IReservationService
    {
        public ReservationDTO GetResById(int Id)
        {
            return new ReservationDTO()
            {
                Id = Id,
                BookingNumber = "testInvoiceBug4",
                ETADate = new DateTime(2022, 3, 31),
                TotalPrice = 19.00,
                CarrierPayment = 12.70,
                PaymentType = "Line Of Credit"
            };
        }
    }
}
