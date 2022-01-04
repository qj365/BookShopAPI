using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopAPI.Areas.Admin.ViewModel
{
    public class BookSoldViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Sold { get; set; }

    }
}