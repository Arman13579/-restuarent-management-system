using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace work_01.ViewModels
{
    public class RegisterVM
    {
        [Key]
        [Required]
        //[RegularExpression(@"^\w+([-+.']\w+)*@123g.com$", ErrorMessage = "Invalid Email.")]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}