using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BupaApp.Models;

namespace BupaApp.Models
{
    public class Vehicle
    {
        public string Make {get; set;}
        public string Model {get; set;}

        public string PrimaryColour {get; set;}

        public MotTest? MotTest {get; set;}
    }
}