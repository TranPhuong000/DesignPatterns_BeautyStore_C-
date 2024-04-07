using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BeautyStore.DesignPattern.Builder_Pattern
{
    public class MenuBuilder
    {
        private StringBuilder _menu;

        public MenuBuilder()
        {
            _menu = new StringBuilder();
        }

        public string AddMenuItem(string text, string url, string cssClass)
        {
            return $"<li><a class='{cssClass}' href='{url}'>{text}</a></li>";
        }

        public string GetMenu()
        {
            return _menu.ToString();
        }
    }
}