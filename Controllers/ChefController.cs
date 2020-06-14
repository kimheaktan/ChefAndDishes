using System;
using System.Collections.Generic;
using System.Linq;
using ChefAndDishes.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChefAndDishes.Controllers
{
    public class ChefController : Controller
    {
        private Context _db; 

        public ChefController(Context context) 
        { 
        _db = context; 
        } 

        [HttpGet("chef/new")]
        
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpPost("chef/create")]
        public IActionResult CreateChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                DateTime now = DateTime.Now;
                DateTime chefBirth = newChef.DOB;
                int age = now.Year - chefBirth.Year;
                if (chefBirth > now.AddYears(-age))
                    age--;
                newChef.Age = age;
                _db.Chefs.Add(newChef);
                _db.SaveChanges();
                return RedirectToAction("Index","Home");
                //action Index in HomeController// need to specify where the action is if in different Controller
            }
            return View("NewChef");
        }

        public IActionResult DeleteChef(int chefId)
        {
            Chef toBeDeleted = _db.Chefs.FirstOrDefault(ch => ch.ChefId == chefId);
            _db.Chefs.Remove(toBeDeleted);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
                


    }
}