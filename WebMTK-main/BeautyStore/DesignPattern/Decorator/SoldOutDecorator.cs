using BeautyStore.Interfaces;
using BeautyStore.Models;
using BeautyStore.DesignPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BeautyStore.Controllers
{
    // 'ConcreteDecorator' class for sold-out products
    public class SoldOutDecorator : IProductDecorator
    {
        private readonly HtmlHelper _htmlHelper;

        public SoldOutDecorator(HtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public MvcHtmlString Decorate(Product item)
        {
            if (item.amount < 1)
            {
                var tagBuilder = new TagBuilder("div");
                tagBuilder.AddCssClass("sold-out-label");
                string imageUrl = VirtualPathUtility.ToAbsolute("~/image/download.png");
                tagBuilder.InnerHtml = $"<img src=\"{imageUrl}\" alt=\"\">" +
                                       "<p>Hết hàng</p>";

                return MvcHtmlString.Create(tagBuilder.ToString());
            }

            return MvcHtmlString.Empty;
        }
    }
}