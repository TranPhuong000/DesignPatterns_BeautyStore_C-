using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautyStore.DesignPattern.Prototype
{
    //Mẫu Prototype
    public interface BrandClone
    {
        BrandClone Clone();
    }
}
