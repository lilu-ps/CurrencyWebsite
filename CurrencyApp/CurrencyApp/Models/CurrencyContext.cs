using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{


    public class CurrencyContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<CurrencyModel> currencies { get; set; }

        public CurrencyContext(DbContextOptions<CurrencyContext> options)
            : base(options)
        {
        }
        
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CurrencyModel>().HasData(
                
        //        );
        //}

    }
}
