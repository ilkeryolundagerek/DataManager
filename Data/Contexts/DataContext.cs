using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts
{
    public class DataContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
    }
}
