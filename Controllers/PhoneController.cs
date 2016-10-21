using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using HowAreYou.Models;
using HowAreYou.Models.BindingModels;
using Microsoft.AspNetCore.Mvc;

namespace HowAreYou.Controllers
{
    [Route("phone")]
    public class PhoneController : Controller
    {
        public IActionResult Register([FromBody] PhoneRegistrationBindingModel model)
        {
            Regex stripRegex = new Regex("[^0-9]*");
            var number = stripRegex.Replace(model.Number, "");
            // Assume US area code if ommitted
            if (number.Length == 10)
            {
                number = "1" + number;
            }
            // We only support US numbers
            if (number.Length != 11)
            {
                return BadRequest("Couldn't recognize this phone number. Only US phone numbers are supported.");
            }
            using (var db = new ApplicationDbContext())
            {
                var existingPhone = db.Phones.SingleOrDefault(p => p.Number == number);
                if (existingPhone != null)
                {
                    return BadRequest("This phone number already exists.");
                }
                var newPhone = new Phone()
                {
                    PhoneId = Guid.NewGuid(),
                    Number = number
                };
                db.Phones.Add(newPhone);
                db.SaveChanges();
                return Ok(newPhone);
            }
        }
    }
}