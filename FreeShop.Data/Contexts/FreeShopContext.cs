using FreeShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeShop.Data.Contexts
{
    public class FreeShopContext : DbContext
    {
        public FreeShopContext(DbContextOptions<FreeShopContext> options) : base(options)
        {

        }
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<ProductEntity> Products => Set<ProductEntity>();
        public DbSet<CategoryEntity> Categories => Set<CategoryEntity>();
        public DbSet<CommentEntity> Comments => Set<CommentEntity>();
        public DbSet<BasketEntity> Baskets => Set<BasketEntity>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CommentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BasketEntityConfiguration());


            modelBuilder.Entity<UserEntity>().HasData(new List<UserEntity>()
                {
                new UserEntity()
                {
                    Id = 1,
                    FirstName = "Sedat",
                    LastName = "Admin",
                    Email = "admin@freshop.com",
                    Password = "123456",
                    UserType = Enums.UserTypeEnum.admin,
                },
                new UserEntity()
                {
                    Id=2,
                    FirstName = "Kullanici",
                    LastName = "KullaniciSoyad",
                    Email = "kullanici@freeshop.com",
                    Password = "654321",
                    UserType = Enums.UserTypeEnum.user
                }

            });


            base.OnModelCreating(modelBuilder);
        }

    }
}
