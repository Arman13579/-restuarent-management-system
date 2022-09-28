using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace work_01.ViewModels
{
    public class LoginVM
    {
        [Required]
        //[RegularExpression(@"^([\w]*[\w\.]*(?!\.)@gmail.com)", ErrorMessage = "Invalid Email.")]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}