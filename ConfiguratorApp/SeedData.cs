using ConfiguratorApp.Common.Enums;
using ConfiguratorApp.DataAccessLayer.DataAccess;
using ConfiguratorApp.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConfiguratorApp.WebApp
{
    public static class SeedData
    {
        public static readonly string[] Manufacturers = { "Intel", "Amd", "Asus", "Msi", "Kingston", "Samsung", "NVIDIA", "Corsair", "COUGAR" };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using ConfiguratorAppDbContext dbContext = new ConfiguratorAppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ConfiguratorAppDbContext>>());
            //// Look for any TODO items.
            if (dbContext.Components.Any())
            {
                return;   // DB has been seeded
            }

            PopulateTestData(dbContext);
        }
        public static void PopulateTestData(ConfiguratorAppDbContext dbContext)
        {
            dbContext.Computers.RemoveRange(dbContext.Computers);
            dbContext.Components.RemoveRange(dbContext.Components);
            dbContext.Manufacturers.RemoveRange(dbContext.Manufacturers);
            dbContext.SaveChanges();
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            foreach (string item in Manufacturers)
            {
                manufacturers.Add(new Manufacturer() { Name = item });
            }

            dbContext.AddRange(manufacturers);
            dbContext.SaveChanges();
            List<Component> listComponents = new List<Component>();
            foreach (Manufacturer item in dbContext.Manufacturers.AsNoTracking().ToList())
            {
                switch (item.Name)
                {
                    case "Intel":
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId=item.ID,
                            Model = "i7-11700F",
                            Type = ComponentType.CPU,
                            Name = "Intel Core i7-11700F (2.5GHz)",
                            Price = 260,
                            Picture= @"https://p1.akcdn.net/full/796803618.intel-core-i7-11700f-8-core-2-5ghz-lga1200.jpg",
                            Count=5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "i5-10400 (2.9GHz) TRAY",
                            Type = ComponentType.CPU,
                            Name = "Intel Core i5-10400 (2.9GHz) TRAY",
                            Price = 429,
                            Picture= @"https://p1.akcdn.net/full/685923264.intel-core-i5-10400-6-core-2-9ghz-lga1200.jpg",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "i3-9100F",
                            Type = ComponentType.CPU,
                            Name = "Intel Core i3-9100F (3.6GHz)",
                            Price = 285,
                            Picture = @"https://s13emagst.akamaized.net/products/22580/22579162/images/res_7ebceeb5fa4997c3584a2f6fd7a44ffa.png",
                            Count = 5
                        });
                        break;

                    case "Amd":
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "Ryzen 3",
                            Type = ComponentType.CPU,
                            Name = "AMD Ryzen 3 2200G (3.5GHz)",
                            Price = 320,
                            Picture = @"https://p1.akcdn.net/full/591313548.amd-ryzen-3-3200g-4-core-3-6ghz-am4.jpg",
                            Count = 5

                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "Ryzen 9 5900X",
                            Type = ComponentType.CPU,
                            Name = "AMD Ryzen 9 5900X (3.70GHz)",
                            Price = 460,
                            Picture = @"https://p1.akcdn.net/full/739327311.amd-ryzen-9-5900x-12-core-3-7ghz-am4.jpg",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "Ryzen 7 5800X",
                            Type = ComponentType.CPU,
                            Name = "AMD Ryzen 7 5800X (3.8GHz)",
                            Price = 350,
                            Picture = @"https://p1.akcdn.net/full/739326690.amd-ryzen-7-5800x-8-core-3-8ghz-am4.jpg",
                            Count = 5
                        });
                        break;
                    case "Asus":
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "A320M-C R2.0",
                            Type = ComponentType.Motherboard,
                            Name = "ASUS PRIME A320M-C R2.0",
                            Price = 160,
                            Picture = @"https://www.asus.com/media/global/gallery/a3XOHvlueoHFMpOO_setting_xxx_0_90_end_2000.png",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "H510M-E",
                            Type = ComponentType.Motherboard,
                            Name = "ASUS PRIME H510M-E",
                            Price = 180,
                            Picture = @"https://dlcdnwebimgs.asus.com/gain/dd1db03e-a6a6-4129-819d-6150ae380797/",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "B460-F Gaming",
                            Type = ComponentType.Motherboard,
                            Name = "ASUS ROG STRIX B460-F Gaming",
                            Price = 250,
                            Picture = @"https://p1.akcdn.net/full/690955545.asus-rog-strix-b460-f-gaming.jpg",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "GT301",
                            Type = ComponentType.Case,
                            Name = "ASUS TUF Gaming GT301",
                            Price = 160,
                            Picture = @"https://ardes.bg/uploads/p/asus-tuf-gaming-gt301-cheren-273036.jpg",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "GT501",
                            Type = ComponentType.Case,
                            Name = "ASUS TUF Gaming GT501",
                            Price = 180,
                            Picture = @"https://ardes.bg/uploads/p/kutiya-asus-tuf-gaming-gt501-rgb-mid-tower-237568.jpg",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "Strix",
                            Type = ComponentType.Case,
                            Name = "ASUS ROG Strix Helios",
                            Price = 200,
                            Picture = @"https://ardes.bg/uploads/p/kutiya-asus-rog-strix-helios-rgb-eatx-mid-tower-248523.jpg",
                            Count = 5
                        }); ;
                        break;
                    case "Msi":
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "A320M-A PRO MAX",
                            Type = ComponentType.Motherboard,
                            Name = "MSI A320M-A PRO MAX",
                            Price = 150,
                            Picture = @"https://s13emagst.akamaized.net/products/29202/29201212/images/res_c4e58825655a812e09d234b87685f290.png",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "B560M BAZOOKA",
                            Type = ComponentType.Motherboard,
                            Name = "MSI MAG B560M BAZOOKA",
                            Price = 180,
                            Picture = @"https://www.vario.bg/images/product/35569/7D18-003R.jpg",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = " B550 GAMING CARBON WIFI",
                            Type = ComponentType.Motherboard,
                            Name = "MSI MPG B550 GAMING CARBON WIFI",
                            Price = 300,
                            Picture = @"https://storage-asset.msi.com/global/picture/features/MB/Gaming/B550/b550-carbon-wifi-board03.png",
                            Count = 5
                        });
                        break;
                    case "Kingston":
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "KC600",
                            Type = ComponentType.StorageDevice,
                            Name = "1ТB SSD Kingston KC600",
                            Price = 260,
                            Picture = @"https://s13emagst.akamaized.net/products/26777/26776867/images/res_2d4b20cd0d2ba9968f67743e878346bd.jpg",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "A400",
                            Type = ComponentType.StorageDevice,
                            Name = "240GB SSD Kingston A400",
                            Price = 160,
                            Picture = @"https://ardes.bg/uploads/original/kingston-ssd-480gb-a400-sata3-2-5-ssd-7mm-height-t-159648.jpg",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "KC600",
                            Type = ComponentType.StorageDevice,
                            Name = "2TB SSD Kingston KC600",
                            Price = 100,
                            Picture = @"https://www.bechtle.com/shop/medias/5da090069ce9692310094a8d-900Wx900H-820Wx820H?context=bWFzdGVyfHJvb3R8NDYzNTJ8aW1hZ2UvanBlZ3xoMjcvaDg0LzEwOTY0Mjc1MDAzNDIyLmpwZ3wzNjZjM2FkY2MzMjZiNGJhMTgwMjZkZDBiZTgwMTNhNDlhM2QzNzEyYmEyN2YyMDE2YmUxMDI5NTMyNDAwMjE2",
                            Count = 5
                        });
                        break;
                    case "Samsung":
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "DDR4",
                            Type = ComponentType.RAM,
                            Name = "32GB DDR4 3200 Samsung",
                            Price = 260,
                            Picture = @"https://i0.wp.com/memory.net/wp-content/uploads/2019/09/a1b0892c-m471a4g43ab1-cwe.png?fit=1647%2C707&quality=70&strip=1&ssl=1",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "DDR4",
                            Type = ComponentType.RAM,
                            Name = "8GB DDR4 3200 Samsung",
                            Price = 160,
                            Picture = @"https://i0.wp.com/memory.net/wp-content/uploads/2019/09/a1b0892c-m471a4g43ab1-cwe.png?fit=1647%2C707&quality=70&strip=1&ssl=1",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "DDR4",
                            Type = ComponentType.RAM,
                            Name = "16GB DDR4 3200 Samsung",
                            Price = 60,
                            Picture = @"https://i0.wp.com/memory.net/wp-content/uploads/2019/09/a1b0892c-m471a4g43ab1-cwe.png?fit=1647%2C707&quality=70&strip=1&ssl=1",
                            Count = 5
                        });
                        break;
                    case "NVIDIA":
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "P620 2GB V2",
                            Type = ComponentType.GPU,
                            Name = "PNY NVIDIA Quadro P620 2GB V2",
                            Price = 260,
                            Picture = @"https://p1.akcdn.net/full/689687880.pny-quadro-p620-2gb-gddr5-v2-vcqp620dviv2-pb.jpg",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "GEFORCE RTX 3090",
                            Type = ComponentType.GPU,
                            Name = "GEFORCE RTX 3090",
                            Price = 1260,
                            Picture = @"https://www.nvidia.com/content/dam/en-zz/Solutions/geforce/ampere/rtx-3090/geforce-rtx-3090-shop-630-d@2x.png",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "GEFORCE RTX 2080",
                            Type = ComponentType.GPU,
                            Name = "GEFORCE RTX 2080",
                            Price = 800,
                            Picture = @"https://www.nvidia.com/content/dam/en-zz/Solutions/geforce/geforce-rtx-turing/2080/gallery/geforce-rtx-2080-gallery-c-641-u@2x.jpg",
                            Count = 5
                        });
                        break;
                    case "Corsair":
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "RM550x",
                            Type = ComponentType.PSU,
                            Name = "550W Corsair RM550x",
                            Price = 260,
                            Picture = @"https://p1.akcdn.net/full/482831215.corsair-rmx-series-rm550x-550w-gold-cp-9020090.jpg",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "RM850",
                            Type = ComponentType.PSU,
                            Name = "850W Corsair RM850 80+ Gold",
                            Price = 300,
                            Picture = @"https://m.media-amazon.com/images/I/71fiKD2ckCL._AC_SS450_.jpg",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "RM650",
                            Type = ComponentType.PSU,
                            Name = "650W Corsair RM650",
                            Price = 100,
                            Picture = @"https://www.corsair.com/corsairmedia/sys_master/productcontent/CP-9020054-NA-RM650_01.png",
                            Count = 5
                        });
                        break;
                    case "COUGAR":
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "500",
                            Type = ComponentType.PSU,
                            Name = "500W COUGAR VTE 500 80+ Bronze",
                            Price = 260,
                            Picture = @"",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "GEX",
                            Type = ComponentType.PSU,
                            Name = "650W COUGAR GEX",
                            Price = 280,
                            Picture = @"",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "GEX",
                            Type = ComponentType.PSU,
                            Name = "750W COUGAR GEX",
                            Price = 300,
                            Picture = @"",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "240",
                            Type = ComponentType.Cooling,
                            Name = "COUGAR AQUA 240",
                            Price = 100,
                            Picture = @"https://desktop.bg/system/images/245106/original/cougar_aqua.png",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "360",
                            Type = ComponentType.Cooling,
                            Name = "COUGAR AQUA 360",
                            Price = 200,
                            Picture = @"https://p1.akcdn.net/full/699253476.cougar-aqua-360-maqu3600001.jpg",
                            Count = 5
                        });
                        listComponents.Add(new Component()
                        {
                            CreatedOn = DateTime.Now,
                            ManufacturerId = item.ID,
                            Model = "280",
                            Type = ComponentType.Cooling,
                            Name = "COUGAR AQUA ARGB 280",
                            Price = 300,
                            Picture = @"https://cougargaming.com/_cgrwdr_/wwdpp/wp-content/uploads/2020/08/01-1-1.png",
                            Count = 5
                        });
                        break;

                    default:
                        break;
                }
            }
            dbContext.AddRange(listComponents);

            dbContext.SaveChanges();
        }
    }
}
