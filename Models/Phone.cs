using System;
using System.ComponentModel.DataAnnotations;

namespace HowAreYou.Models
{
    public class Phone
    {
        [Key]
        public Guid PhoneId { get; set; }

        public string Number { get; set; }
        
        public DateTimeOffset TimeRegistered { get; set; }
    }
}