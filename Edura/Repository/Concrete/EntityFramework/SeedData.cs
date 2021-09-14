using Edura.WebUI.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edura.WebUI.Repository.Concrete.EntityFramework
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<EduraContext>();

            context.Database.Migrate();

            if (!context.Products.Any())
            {
                var products = new[] {
                    new Product(){ ProductName="Photo Camera",Price=1000,Image="product1_thumb.jpg",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. Proin varius arcu metus.",HTMLContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. <b> Proin varius arcu metus.</b>",DateAdded=DateTime.Now.AddDays(-10)},
                    new Product(){ ProductName="Webcam",Price=200,Image="product2_thumb.jpg",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. Proin varius arcu metus.",HTMLContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. <b> Proin varius arcu metus.</b>",DateAdded=DateTime.Now.AddDays(-6)},
                    new Product(){ ProductName="Hand Bag",Price=300,Image="product4_thumb.jpg",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. Proin varius arcu metus.",HTMLContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. <b> Proin varius arcu metus.</b>",DateAdded=DateTime.Now.AddDays(-8)},
                    new Product(){ ProductName="Sofa",Price=3000,Image="product3_thumb.jpg",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. Proin varius arcu metus.",HTMLContent="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur eget leo at velit imperdiet varius. In eu ipsum vitae velit congue iaculis vitae at risus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas vitae vehicula enim. Sed quis ante quis eros maximus dignissim a eu mi. <b> Proin varius arcu metus.</b>",DateAdded=DateTime.Now.AddDays(-15)}
                };
                context.Products.AddRange(products);

                var catgories = new[] {
                    new Category(){ CategoryName="Electronics"},
                    new Category(){ CategoryName="Accessories"},
                    new Category(){ CategoryName="Furniture"},
                };
                context.Categories.AddRange(catgories);

                var productcategories = new[]
                {
                    new ProductCategory(){ Product=products[0],Category=catgories[0]},
                    new ProductCategory(){ Product=products[1],Category=catgories[0]},
                    new ProductCategory(){ Product=products[2],Category=catgories[1]},
                    new ProductCategory(){ Product=products[3],Category=catgories[2]}
                };
                var images = new[]
                {
                    new Image(){ImageName="product1_thumb.jpg",Product=products[0] },
                    new Image(){ImageName="product2_thumb.jpg",Product=products[0] },
                    new Image(){ImageName="product3_thumb.jpg",Product=products[0] },
                    new Image(){ImageName="product4_thumb.jpg",Product=products[0] },

                    new Image(){ImageName="product1_thumb.jpg",Product=products[1] },
                    new Image(){ImageName="product2_thumb.jpg",Product=products[1] },
                    new Image(){ImageName="product3_thumb.jpg",Product=products[1] },
                    new Image(){ImageName="product4_thumb.jpg",Product=products[1] },

                     new Image(){ImageName="product1_thumb.jpg",Product=products[2] },
                    new Image(){ImageName="product2_thumb.jpg",Product=products[2] },
                    new Image(){ImageName="product3_thumb.jpg",Product=products[2] },
                    new Image(){ImageName="product4_thumb.jpg",Product=products[2] },

                     new Image(){ImageName="product1_thumb.jpg",Product=products[3] },
                    new Image(){ImageName="product2_thumb.jpg",Product=products[3] },
                    new Image(){ImageName="product3_thumb.jpg",Product=products[3] },
                    new Image(){ImageName="product4_thumb.jpg",Product=products[3] }
                };
                context.Images.AddRange(images);

                var attiributes = new[]
                {
                    new ProductAttirubute(){AttirubuteName="Display",Value="15.6",Product=products[0]},
                    new ProductAttirubute(){AttirubuteName="Processor",Value="Intel i7",Product=products[0]},
                    new ProductAttirubute(){AttirubuteName="Ram Memory",Value="8 GB",Product=products[0]},
                    new ProductAttirubute(){AttirubuteName="Hard Disk",Value="1 TB",Product=products[0]},
                    new ProductAttirubute(){AttirubuteName="Color",Value="Black",Product=products[0]},

                    new ProductAttirubute(){AttirubuteName="Display",Value="15.6",Product=products[1]},
                    new ProductAttirubute(){AttirubuteName="Processor",Value="Intel i7",Product=products[1]},
                    new ProductAttirubute(){AttirubuteName="Ram Memory",Value="8 GB",Product=products[1]},
                    new ProductAttirubute(){AttirubuteName="Hard Disk",Value="1 TB",Product=products[1]},
                    new ProductAttirubute(){AttirubuteName="Color",Value="Black",Product=products[1]},

                    new ProductAttirubute(){AttirubuteName="Display",Value="15.6",Product=products[2]},
                    new ProductAttirubute(){AttirubuteName="Processor",Value="Intel i7",Product=products[2]},
                    new ProductAttirubute(){AttirubuteName="Ram Memory",Value="8 GB",Product=products[2]},
                    new ProductAttirubute(){AttirubuteName="Hard Disk",Value="1 TB",Product=products[2]},
                    new ProductAttirubute(){AttirubuteName="Color",Value="Black",Product=products[2]},

                    new ProductAttirubute(){AttirubuteName="Display",Value="15.6",Product=products[3]},
                    new ProductAttirubute(){AttirubuteName="Processor",Value="Intel i7",Product=products[3]},
                    new ProductAttirubute(){AttirubuteName="Ram Memory",Value="8 GB",Product=products[3]},
                    new ProductAttirubute(){AttirubuteName="Hard Disk",Value="1 TB",Product=products[3]},
                    new ProductAttirubute(){AttirubuteName="Color",Value="Black",Product=products[3]}
                };

                context.ProductAttirubutes.AddRange(attiributes);


                context.AddRange(productcategories);
                context.SaveChanges();
            }
        }
    }
}
