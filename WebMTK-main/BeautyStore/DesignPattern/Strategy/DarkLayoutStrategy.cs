using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeautyStore.DesignPattern.Strategy
{
    public class DarkLayoutStrategy : ILayoutStrategy
    {
        public void ApplyLayout()
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("theme", "dark"));
            // Thực hiện áp dụng màu nền tối cho trang web
        }
    }
}