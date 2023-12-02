using Microsoft.EntityFrameworkCore;
using Store.Application.interfaces.Contexts;
using Store.Common;
using Store.Domain.Entites.Carts;
using Store.Domain.Entites.Finance;
using Store.Domain.Entites.HomePages;
using Store.Domain.Entites.Products;
using Store.Domain.Entites.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Persistence.Contexts
{
    public class DatabaseContext:DbContext,IDataBaseContext
    {
        public DatabaseContext(DbContextOptions option):base(option)
        {
            
        }
        public DbSet<User>Users { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Role>Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeatures> ProductFeatures { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<Slider>Sliders { get; set; }
        public DbSet<Cart>Carts { get; set; }
        public DbSet<CartItem>CartItems { get; set; }

        public DbSet<HomePageImage> HomePagesImages { get; set; }
        public DbSet<RequestPay> RequestPays { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Role>().HasData(new Role { Id = 1 ,Name=UserRoles.Admin});
           modelBuilder.Entity<Role>().HasData(new Role { Id = 2 ,Name=UserRoles.Operator});
           modelBuilder.Entity<Role>().HasData(new Role { Id = 3 ,Name=UserRoles.Customer});

            modelBuilder.Entity<User>().HasIndex(x=>x.Email).IsUnique();


            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsRemoved);
            modelBuilder.Entity<Category>().HasQueryFilter(p=>!p.IsRemoved);
            modelBuilder.Entity<Product>().HasQueryFilter(p=>!p.IsRemoved);
            modelBuilder.Entity<ProductFeatures>().HasQueryFilter(p=>!p.IsRemoved);
            modelBuilder.Entity<ProductImages>().HasQueryFilter(p=>!p.IsRemoved);
            modelBuilder.Entity<Role>().HasQueryFilter(p=>!p.IsRemoved);
            modelBuilder.Entity<Slider>().HasQueryFilter(p=>!p.IsRemoved);
            modelBuilder.Entity<HomePageImage>().HasQueryFilter(p=>!p.IsRemoved);
            modelBuilder.Entity<Cart>().HasQueryFilter(p=>!p.IsRemoved);
            modelBuilder.Entity<CartItem>().HasQueryFilter(p=>!p.IsRemoved);
            modelBuilder.Entity<RequestPay>().HasQueryFilter(p=>!p.IsRemoved);
          
        }
    }
}
