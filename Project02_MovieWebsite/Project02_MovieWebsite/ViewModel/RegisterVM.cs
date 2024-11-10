using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project02_MovieWebsite.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Username cannot be blank.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be blank.")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password cannot be blank.")]
        [Compare("Password",ErrorMessage ="Password and Confirm password do not match.")]

        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Email cannot be blank.")]
        [EmailAddress(ErrorMessage ="Invalid Email.")]
        public string Email { get; set; }
    }
}