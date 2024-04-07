using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BeautyStore.DesignPattern.Builder_Pattern
{
    public class MenuBuilderAdmin
    {
        private StringBuilder _menuAdmin;

        public MenuBuilderAdmin()
        {
            _menuAdmin = new StringBuilder();
            _menuAdmin.AppendLine("<ul class='sidebar-nav' id='sidebar-nav'>");
        }

        public void AddMenuItem(string text, string url, string iconClass, string spanText)
        {
            _menuAdmin.AppendLine("<li class='nav-item'>");
            _menuAdmin.AppendLine($"<a class='nav-link collapsed' href='{url}'>");
            _menuAdmin.AppendLine($"<i class='{iconClass}'></i>");
            _menuAdmin.AppendLine($"<span>{spanText}</span>");
            _menuAdmin.AppendLine("</a>");
            _menuAdmin.AppendLine("</li>");
        }

        public void AddCustomItem(string customHtml)
        {
            _menuAdmin.Append(customHtml);
        }

        public string GetMenu()
        {
            _menuAdmin.AppendLine("</ul>");
            return _menuAdmin.ToString();
        }
    }
}