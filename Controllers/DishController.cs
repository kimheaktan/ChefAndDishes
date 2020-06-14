using System;
using System.Collections.Generic;
using System.Linq;
using ChefAndDishes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ChefAndDishes.Controllers
{
    public class DishController : Controller
    {
        private Context _db; 
        public DishController(Context context)
        { 
            _db = context; 
        } 

        [HttpGet("dish/new")]
        public IActionResult NewDish()
        {            
            ViewBag.AllChefs = _db.Chefs.ToList();
            return View("NewDish");
        }

        public IActionResult CreateDish(Dish inputDish)
        {
            if (ModelState.IsValid)
            {
                _db.Dishes.Add(inputDish);
                _db.SaveChanges();                
                return RedirectToAction("AllDishes");
            }
            return View("NewDish");
        }

        public IActionResult AllDishes()
        {
            List<Dish> AllDishes = _db.Dishes.Include(d => d.Cook).ToList();

            return View(AllDishes);
        }

        public IActionResult DeleteDish(int dishId)
        {
            Dish toBeDeleted = _db.Dishes.FirstOrDefault(d => d.DishId == dishId);
            _db.Dishes.Remove(toBeDeleted);
            _db.SaveChanges();
            
            return RedirectToAction("AllDishes");
        }

    
    }
}