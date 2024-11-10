﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Project02_MovieWebsite.Identity
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() : base("MyConnectionString"){ }
    }
}