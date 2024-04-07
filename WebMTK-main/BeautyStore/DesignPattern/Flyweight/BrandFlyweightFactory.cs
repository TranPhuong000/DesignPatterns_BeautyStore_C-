using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.DesignPattern
{
    public class BrandFlyweightFactory
    {
        private Dictionary<int, BrandFlyweight> brandFlyweights = new Dictionary<int, BrandFlyweight>();

        public BrandFlyweight GetBrandFlyweight(int brandId, string image)
        {
            if (!brandFlyweights.ContainsKey(brandId))
            {
                brandFlyweights[brandId] = new BrandFlyweight(brandId, image);
            }

            return brandFlyweights[brandId];
        }
    }
}