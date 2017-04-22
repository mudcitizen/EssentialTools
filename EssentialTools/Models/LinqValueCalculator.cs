using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqValueCalculator : IValueCalculator
    {

        IDiscountHelper discounter;

        public LinqValueCalculator(IDiscountHelper discountHelper) {
            discounter = discountHelper;
        }
   
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}