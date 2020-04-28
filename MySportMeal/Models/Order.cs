using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySportMeal.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public int Quantity { get; set; }


        public int Total { get; set; }

        public int MealPrice { get; set; }

        public string MealName { get; set; }
    }
}