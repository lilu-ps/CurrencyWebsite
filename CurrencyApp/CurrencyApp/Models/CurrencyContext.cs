using Microsoft.EntityFrameworkCore;

namespace CurrencyApp.Models
{


    public class CurrencyContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public Microsoft.EntityFrameworkCore.DbSet<RegisterModel> RegisteredList { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<CurrencyModel> Currencies { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<CalculatorModel> CalculatroOperations { get; set; }

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
