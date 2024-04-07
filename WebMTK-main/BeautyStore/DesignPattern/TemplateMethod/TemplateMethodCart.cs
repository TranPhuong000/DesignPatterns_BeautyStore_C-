using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeautyStore.Models;

namespace BeautyStore.DesignPattern
{
    public abstract class TemplateMethodCart : Controller
    {
        protected abstract int GetTotalNumber();
        protected abstract decimal GetTotalPrice();

    }
}