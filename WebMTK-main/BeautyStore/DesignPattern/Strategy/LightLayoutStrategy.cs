using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.DesignPattern.Strategy
{
    public class LightLayoutStrategy : ILayoutStrategy
    {
        public void ApplyLayout()
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("theme", "light"));
            // Thực hiện áp dụng màu nền sáng cho trang web
        }
    }
}