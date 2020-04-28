using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MySportMeal.Models
{
    public class MealSeeders : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var meals = new List<Meal>();

            meals.Add(new Meal() { Name = "Grilled Meat", ImagePath = "/Images/1.jpg", Price = 23, Description = "Grilled meat cooked with some vegetables" });
            meals.Add(new Meal() { Name = "Classic Steak", ImagePath = "/Images/2.jpg", Price = 27, Description = "Grilled steak with poached potatoes and some vegetables " });
            meals.Add(new Meal() { Name = "Grilled chicken", ImagePath = "/Images/10.jpg", Price = 17, Description = "Grilled chicken cooked with grilled vegetables  " });
            meals.Add(new Meal() { Name = "Grilled fish", ImagePath = "/Images/6.jpg", Price = 25, Description = "Grilled fish cooked with some vegetables " });
            meals.Add(new Meal() { Name = "Grilled salmon", ImagePath = "/Images/7.jpg", Price = 29, Description = "Salmon cooked with some vegetables and sauce" });
            meals.Add(new Meal() { Name = "Mexican Taco", ImagePath = "/Images/8.jpg", Price = 15, Description = "Meat taco with beside sliced lemmon" });
            meals.Add(new Meal() { Name = "Diet Salad", ImagePath = "/Images/5.jpg", Price = 15, Description = "Poached egg with vegetables and avocado salad" });
            meals.Add(new Meal() { Name = "MySportMeal salad", ImagePath = " /Images/4.jpg", Price = 17 , Description = "Some avocado with some vegetables and chickpeas" });
            meals.Add(new Meal() { Name = "Classic salad", ImagePath = "/Images/11.jpg", Price = 13, Description = "Some vegetables mixed together" });
            foreach (var meal in meals)
            {
                context.Meals.Add(meal);
            }

            base.Seed(context);

        }
    }
}



      

           