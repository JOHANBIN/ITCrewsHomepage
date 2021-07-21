using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITCREWS.Models
{
    public class LoginModel
    {
        [Required] public string ID { get; set; } = null;

        [Required] public string PW { get; set; } = null;
    }
}
