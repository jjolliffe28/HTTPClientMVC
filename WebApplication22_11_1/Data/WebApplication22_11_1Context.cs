using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication22_11_1.Models;

namespace WebApplication22_11_1.Data
{
    public class WebApplication22_11_1Context : DbContext
    {
        public WebApplication22_11_1Context (DbContextOptions<WebApplication22_11_1Context> options)
            : base(options)
        {
        }

        public DbSet<WebApplication22_11_1.Models.Lunch> Lunch { get; set; } = default!;
    }
}
