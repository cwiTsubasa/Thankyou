using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sample.Models
{
    public class LoginModel
    {
        //[EmailAddress(ErrorMessage = "正しいメールアドレスではありません。")]
        [Display(Name = "メールアドレス")]
        public string Mail { get; set; }

       
        [Display(Name = "パスワード")]
        public string Password { get; set; }

    }

  
}