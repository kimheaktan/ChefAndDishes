using Microsoft.EntityFrameworkCore;

namespace ChefAndDishes.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options) { } 

        //tables in db
        public DbSet<Chef> Chefs {get;set;}
        public DbSet<Dish> Dishes {get;set;}
    }
}