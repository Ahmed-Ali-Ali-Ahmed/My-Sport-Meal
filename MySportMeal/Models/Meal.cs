﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySportMeal.Models
{
    public class Meal
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string  Description { get; set; }

        public int Price { get; set; }

        public string ImagePath { get; set; }
    }
}