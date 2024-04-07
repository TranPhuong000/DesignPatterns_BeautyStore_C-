using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.DesignPattern.Strategy
{
    public static class LayoutHelper
    {
        public static string GetThemeStyleSheet()
        {
            var theme = "light"; // Chọn chế độ mặc định là sáng
            if (HttpContext.Current.Request.Cookies["theme"] != null)
            {
                theme = HttpContext.Current.Request.Cookies["theme"].Value;
            }
            return $"/Content/css/{theme}-theme.css";
        }
    }
}