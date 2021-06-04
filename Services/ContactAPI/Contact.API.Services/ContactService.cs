using Contact.API.Infrastructure;
using Contact.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.API.Services
{
    public class ContactService : IContactService
    {
        public ContactDTO GetContactById(int Id)
        {
            return new ContactDTO()
            {
                Id = Id,
                FirstName = "emre",
                LastName = "kefelioglu",
                CompanyName = "kefeliShipper",
                PhoneNumber = "5306007080",
                Email = "m.emrekefeli+shipper@gmail.com",
                Operator = "muhammet emre test kefelioglu"
            };
        }
    }
}
