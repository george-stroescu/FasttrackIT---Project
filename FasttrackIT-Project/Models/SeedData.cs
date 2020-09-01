using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FasttrackIT_Project.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            //using (var context = new ProjectDbContext(serviceProvider.GetRequiredService<DbContextOptions<ProjectDbContext>>()))
            //{
            //    //Look for any movies.
            //    if (context.Product.Any())
            //    {
            //        return;
            //    }

            //    context.Product.AddRange(
            //        new Product
            //        {
            //            ProductName = "Faina",
            //            Price = 2.99M,
            //        },

            //        new Product
            //        {
            //            ProductName = "Malai",
            //            Price = 1.50M,
            //        },

            //        new Product
            //        {
            //            ProductName = "Paine",
            //            Price = 3M,
            //        },

            //        new Product
            //        {
            //            ProductName = "Cereale",
            //            Price = 3M,
            //        },

            //        new Product
            //        {
            //            ProductName = "Paste",
            //            Price = 3.50M,
            //        },

            //        new Product
            //        {
            //            ProductName = "Orez",
            //            Price = 4M,
            //        },

            //        new Product
            //        {
            //            ProductName = "Porumb",
            //            Price = 2M,
            //        },

            //        new Product
            //        {
            //            ProductName = "Cartofi",
            //            Price = 1.50M,
            //        }
            //    );
            //    context.SaveChanges();
            //}
        }
    }
}
