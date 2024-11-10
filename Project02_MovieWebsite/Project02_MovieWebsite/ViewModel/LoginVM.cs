using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project02_MovieWebsite.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username cannot be blank.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be blank.")]

        public string Password { get; set; }

    }
}