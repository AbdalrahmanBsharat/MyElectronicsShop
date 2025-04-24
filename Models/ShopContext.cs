using Microsoft.EntityFrameworkCore;
using MyElectronicShop.Models;


namespace MyElectronicShop.Models
{

    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Types> Type { get; set; } = null!;
        public DbSet<Product> Product { get; set; } = null!;
        public DbSet<CartItem> CartItem { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User
               {
                   UserId = 1,
                   Username = "admin",
                   Email = "admin@gmail.com",
                   Password = "admin"
               },
            
               new User
               {
                   UserId = 2,
                   Username = "abdulrahman",
                   Email = "bsh@gmail.com",
                   Password = "1234"
               }
               );

            modelBuilder.Entity<Types>().HasData(
                new Types
                {
                    TypeId = "Lp",
                    Name = "Laptop"
                },
                new Types
                {
                    TypeId = "Ph",
                    Name = "Phone"
                },
                new Types
                {
                    TypeId = "Kb",
                    Name = "Keyboard"
                },
                new Types
                {
                    TypeId = "Hp",
                    Name = "HeadPhone"
                },
                new Types
                {
                    TypeId = "Tb",
                    Name = "Tablet"
                }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    PrId = 1,
                    Name = "Hp",
                    Price = 2333,
                    url = "https://i5.walmartimages.com/seo/HP-Pavilion-13-3-FHD-Intel-Core-i3-8GB-RAM-128GB-SSD-Silver_906cf222-d138-430a-8146-d129b0cca3a2_2.f838f300a6e31f50074faf4091a1da7b.jpeg",
                    TypeId = "Lp"
                },
                new Product
                {
                    PrId = 2,
                    Name = "Lenovo",
                    Price = 1933,
                    url = "https://5.imimg.com/data5/DE/DA/QN/SELLER-32244351/lenovo-laptop.jpg",
                    TypeId = "Lp"
                },
                new Product
                {
                    PrId = 3,
                    Name = "Logetich",
                    Price = 200,
                    url = "https://resource.logitechg.com/w_692,c_lpad,ar_4:3,q_auto,f_auto,dpr_2.0/d_transparent.gif/content/dam/gaming/en/non-braid/g213-finch/g213-gallery-1-nb.png?v=1",
                    TypeId = "Kb"
                },
                new Product
                {
                    PrId = 4,
                    Name = "dell",
                    Price = 2300,
                    url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQMKs7Vxec19Gg5sde8PgYCpX8gWxnE95rQc_dOg0Z7zXWhy2k&s",
                    TypeId = "Lp"
                },
                new Product
                {
                    PrId = 5,
                    Name = "IPad",
                    Price = 1000,
                    url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTMQNuL-_Ki109-IuOFLsuA0KqKqVfJFFqD2HuSsoBtWpYYBpQh&s",
                    TypeId = "Tb"
                },
                new Product
                {
                    PrId = 6,
                    Name = "Razer",
                    Price = 400,
                    url = "https://i5.walmartimages.com/seo/Razer-Kraken-V3-Pro-Wireless-Gaming-Headset-for-PC-2-4GHz-Haptics-Chroma-RGB-368g-Black_124e137a-e85f-459b-9fbb-0ac27e9391ef.561e94d10b97d275b6595b557ad4aea3.jpeg",
                    TypeId = "Hp"
                },
                new Product
                {
                    PrId = 7,
                    Name = "Iphone 15 pro max",
                    Price = 1200,
                    url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS7_2BCfJmsRBXN3n7N6JAf3Wz8Qr-DIENaIVioqg0YxffTTGU&s",
                    TypeId = "Ph"
                },
                new Product
                {
                    PrId = 8,
                    Name = "MegaGee",
                    Price = 500,
                    url = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTwelPo0iIyzHKB-m-IH86RvUa2E7Q0igaR--CfVZkBkQ-4CLQ&s",
                    TypeId = "Kb"
                }
                );

            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    CartItemId = 1,
                    UserId = 2,
                    PrId = 1,
                    Quantity = 1,

                },
                new CartItem
                {
                    CartItemId = 2,
                    UserId = 2,
                    PrId = 3,
                    Quantity = 2,
                },
                new CartItem
                {
                    CartItemId = 3,
                    UserId = 2,
                    PrId = 1,
                    Quantity = 2,
                }
                );
        }

    }
}
