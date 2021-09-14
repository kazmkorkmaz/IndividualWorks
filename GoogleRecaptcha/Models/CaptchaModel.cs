using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleRecaptcha.Models
{
    public class CaptchaModel
    {
        public bool success { get; set; }
        public DateTime timestamp { get; set; }
        public string hostname { get; set; }
       
    }
}
