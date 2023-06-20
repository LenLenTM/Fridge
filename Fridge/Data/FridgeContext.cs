using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Fridge.Models;

namespace Fridge.Data
{
    public class FridgeContext : DbContext
    {
        public FridgeContext (DbContextOptions<FridgeContext> options)
            : base(options)
        {
        }

        public DbSet<Fridge.Models.Item> Item { get; set; } = default!;
    }
}
