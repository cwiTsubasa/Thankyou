using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sample.Models
{
    public class MemberModels
    {
        

        public string Mail { get; set; }

        
        public string Password { get; set; }
    }

    //public class MyContext : DbContext
    //{
    //    public DbSet<NewCustomer> NewCustomers { get; set; }
    //}
}