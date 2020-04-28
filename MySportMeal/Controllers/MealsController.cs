﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySportMeal.Models;

namespace MySportMeal.Controllers
{
    public class MealsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Meals
        public ActionResult Index()
        {
            return View(db.Meals.ToList());
        }

        // GET: Meals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // GET: Meals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ImageFile,ImagePath,Description,Price")] MealHelper mealHelper)
        {

            Meal meal = new Meal();
            if (ModelState.IsValid)
            {


                string pic = System.IO.Path.GetFileName(mealHelper.ImageFile.FileName);
                string path = System.IO.Path.Combine(
                Server.MapPath("~/Images/"), pic);
                mealHelper.ImageFile.SaveAs(path);


                meal.ID = mealHelper.ID;
                meal.Name = mealHelper.Name;
                meal.ImagePath = "~/Images/" + pic;
                // university.ImagePath = path;
                meal.Price = mealHelper.Price;
                meal.Description = mealHelper.Description;

                
                db.Meals.Add(meal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meal);
        }

        public ActionResult RedirectToOrder(int? price,string meal)
        {
            Session["Price"] = price;
            Session["Meal"] = meal;
            return RedirectToAction("Create", "Orders",price);
        }

        // GET: Meals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: Meals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Price")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meal);
        }

        // GET: Meals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meal meal = db.Meals.Find(id);
            if (meal == null)
            {
                return HttpNotFound();
            }
            return View(meal);
        }

        // POST: Meals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meal meal = db.Meals.Find(id);
            db.Meals.Remove(meal);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
