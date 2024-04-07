using BeautyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BeautyStore.DesignPattern
{
    public interface IProductDecorator
    {
        MvcHtmlString Decorate(Product item);
    }
}