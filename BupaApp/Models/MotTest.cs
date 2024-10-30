using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace BupaApp.Models
{
    public class MotTest
    {
        [JsonPropertyName("expiryDate")]
        public string ExpiryDate {get; set;}

         [JsonPropertyName("odometerValue")]
        public string OdometerValue {get; set;}
    }
}