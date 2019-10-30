using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SD2411.KPI2019.Module.Core.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Email Address is required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
    }
}
