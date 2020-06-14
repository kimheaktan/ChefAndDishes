using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefAndDishes.Controllers
{
    public class HomeController : Controller
    {
        private Context _db; 

        public HomeController(Context context)
        {
            _db = context; 
        } 
        public IActionResult Index()
        {
            List<Chef> AllChef = _db.Chefs.Include(ch => ch.Dishes).ToList();

            return View(AllChef);
        }

        


        


        

        


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
