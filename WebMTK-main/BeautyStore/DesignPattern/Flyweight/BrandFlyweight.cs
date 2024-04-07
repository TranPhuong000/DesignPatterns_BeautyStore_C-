using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.DesignPattern
{
    public class BrandFlyweight
    {
        private readonly int brandId;
        private readonly string image;

        public BrandFlyweight(int brandId, string image)
        {
            this.brandId = brandId;
            this.image = image;
        }

        public void Display()
        {
            Console.WriteLine(image);
        }
    }
}