using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Polypack.Models;

namespace Polypack.ViewModel
{
    public class AllDatas
    {
        public Header Header { get; set; }

        public List<About> Abouts { get; set; }

        public List<Category> Categories { get; set; }

        public List<Product> Products { get; set; }

        public List<Service> Services { get; set; }

        public List<Partner> Partners { get; set; }

        public Contact Contact { get; set; }

        public WeProvide WeProvide { get; set; }

        public List<Banner> Banners { get; set; }

        public List<Message> Messages { get; set; }
    }
}