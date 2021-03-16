using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MasterRad.Models
{
    public class Courier
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Validation { get; set; }
        public DateTime ComplitionDate { get; set; }
    }
}