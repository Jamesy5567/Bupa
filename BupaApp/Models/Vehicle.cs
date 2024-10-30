using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BupaApp.Models;
using System.Text.Json.Serialization;

namespace BupaApp.Models
{
    public class Vehicle
    {
        [JsonPropertyName("make")]
        public string Make {get; set;}
        
        [JsonPropertyName("model")]
        public string Model {get; set;}

        [JsonPropertyName("primaryColour")]
        public string PrimaryColour {get; set;}

        [JsonPropertyName("motTests")]
        public List<MotTest> MotTests {get; set;}
    }
}