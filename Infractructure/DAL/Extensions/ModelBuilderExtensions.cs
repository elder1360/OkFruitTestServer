using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infractructure.DAL.Extensions
{
    public static class ModelBuilderExtensions
    {
        private static readonly UnitType _unitTypeSeedData = new()
        {
            Id = 1,
            Name = "کیلوگرم"
        };
        private static readonly Product[] _productSeedData = new[]
        {
            new Product { Id = 1, UnitTypeId = 1, Name = "سیب", Price = 8000 },
            new Product { Id = 2, UnitTypeId = 1, Name = "پرتقال", Price = 6500 },
            new Product { Id = 3, UnitTypeId = 1, Name = "هویج", Price = 5000 },
            new Product { Id = 4, UnitTypeId = 1, Name = "گیلاس", Price = 10000 },
            new Product { Id = 5, UnitTypeId = 1, Name = "موز", Price = 15000 },
        };
        private static readonly Customer[] _customerSeedData = new[]
        {
            new Customer{Id = 1, Name ="محمدعلی",LastName="معدلی" },
            new Customer{Id = 2, Name ="علی",LastName="ناصحی" },
            new Customer{Id = 3, Name ="حامد",LastName="رنجبر" },
            new Customer{Id = 4, Name ="کریم",LastName="شیری" },
            new Customer{Id = 5, Name ="نیما",LastName="محمدزاده" },
        };
        private static readonly Purchase[] _PurchaseSeedData = new[]
        {
            new Purchase{Id=1,CustomerId=1,ProductId=1,Quantity=3},
            new Purchase{Id=2,CustomerId=1,ProductId=2,Quantity=2},
            new Purchase{Id=3,CustomerId=1,ProductId=3,Quantity=3},
            new Purchase{Id=4,CustomerId=1,ProductId=4,Quantity=4},
            new Purchase{Id=5,CustomerId=2,ProductId=5,Quantity=1},
            new Purchase{Id=6,CustomerId=2,ProductId=4,Quantity=5},
            new Purchase{Id=7,CustomerId=2,ProductId=3,Quantity=4},
            new Purchase{Id=8,CustomerId=3,ProductId=1,Quantity=3},
            new Purchase{Id=9,CustomerId=4,ProductId=2,Quantity=2},
            new Purchase{Id=10,CustomerId=4,ProductId=1,Quantity=1},
            new Purchase{Id=11,CustomerId=4,ProductId=3,Quantity=2},
            new Purchase{Id=12,CustomerId=4,ProductId=4,Quantity=3},
            new Purchase{Id=13,CustomerId=4,ProductId=5,Quantity=4},
            new Purchase{Id=14,CustomerId=5,ProductId=4,Quantity=5},
            new Purchase{Id=15,CustomerId=5,ProductId=3,Quantity=6},
        };
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnitType>().HasData(_unitTypeSeedData);
            modelBuilder.Entity<Product>().HasData(_productSeedData);
            modelBuilder.Entity<Customer>().HasData(_customerSeedData);
            modelBuilder.Entity<Purchase>().HasData(_PurchaseSeedData);
        }
    }
}
