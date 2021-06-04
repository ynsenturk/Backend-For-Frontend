using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using Ocelot.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIGateway
{
    public class FakeDefinedWebAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var reservationResponse = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var contactResponse = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var rezervation = JsonConvert.DeserializeObject<Reservation>(reservationResponse);
            var contact = JsonConvert.DeserializeObject<Contact>(contactResponse);
            var model = new AggrigateWebResponse
            {
                ReservationId = rezervation.Id,
                BookingNumber = rezervation.BookingNumber,
                TotalPrice = rezervation.TotalPrice,
                CarrierPayment = rezervation.CarrierPayment,
                PaymentType = rezervation.PaymentType,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                CompanyName = contact.CompanyName,
                PhoneNumber = contact.PhoneNumber,
                Email = contact.Email,
                Operator = contact.Operator
            };
            var response = new HttpResponseMessage();
            response.Content = new StringContent(JsonConvert.SerializeObject(model));
            var result = new DownstreamResponse(response);
            return result;
        }

    }
    public class AggrigateWebResponse
    {
        public int ReservationId { get; set; }
        public string BookingNumber { get; set; }
        public double TotalPrice { get; set; }
        public double CarrierPayment { get; set; } //Web
        public string PaymentType { get; set; } //Web
        public string FirstName { get; set; } //Web
        public string LastName { get; set; } //Web
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; } //Web
        public string Email { get; set; } //Web
        public string Operator { get; set; }
    }

}
