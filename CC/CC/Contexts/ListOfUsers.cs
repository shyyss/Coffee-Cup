using CC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CC.Contexts
{
    public class ListOfUsers : DbContext
    {
        public ListOfUsers() : base ("ListOfUsers")
        {
        }

        public DbSet<User> TableOfUsers { get; set; }
    }
}