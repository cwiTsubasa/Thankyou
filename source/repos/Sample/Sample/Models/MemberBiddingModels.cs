using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public class MemberBiddingModels
    {
        [Required]
        [Display(Name = "メールアドレス")]
        public string Mail { get; set; }

        [Required]
        [Display(Name = "パスワード")]
        public string  Password  { get; set; }

    }
}