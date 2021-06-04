﻿using Microsoft.AspNetCore.Http;
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
    public class FakeDefinedAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var reservationResponse = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var contactResponse = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var rezervation = JsonConvert.DeserializeObject<Reservation>(reservationResponse);
            var contact = JsonConvert.DeserializeObject<Contact>(contactResponse);
            var model = new AggrigateResponse 
            { 
                ReservationId = rezervation.Id,
                BookingNumber = rezervation.BookingNumber,
                TotalPrice = rezervation.TotalPrice,
                FullName = contact.FullName,
                CompanyName = contact.CompanyName,
                Operator = contact.Operator
            };
            var response = new HttpResponseMessage();
            response.Content = new StringContent(JsonConvert.SerializeObject(model));
            var result = new DownstreamResponse(response);
            return result;
        }

    }
    public class AggrigateResponse
    {
        public int ReservationId { get; set; }
        public string BookingNumber { get; set; }
        public double TotalPrice { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string Operator { get; set; }
    }

    public class Reservation
    {
        public int Id { get; set; }
        public string BookingNumber { get; set; }
        public DateTime? ETADate { get; set; }
        public double TotalPrice { get; set; }
        public double CarrierPayment { get; set; }
        public string PaymentType { get; set; }

    }

    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Operator { get; set; }
    }
}
