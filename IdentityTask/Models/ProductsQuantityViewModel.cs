using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityTask.Models
{
    public class ProductsQuantityViewModel
    {
        public Product Product { set; get; }
        public int Quantity { get; set; }
    }
}