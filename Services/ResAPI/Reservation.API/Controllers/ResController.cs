using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservation.API.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResController : ControllerBase
    {
        private readonly IReservationService reservationService;

        public ResController(IReservationService ReservationService)
        {
            reservationService = ReservationService;
        }

        [HttpGet("{Id}")]
        public Reservation.API.Models.ReservationDTO Get(int Id)
        {
            return reservationService.GetResById(Id);
        }
    }
}
