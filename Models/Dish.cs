using System;
using System.ComponentModel.DataAnnotations;

namespace ChefAndDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}

        [Required(ErrorMessage = "is required")]
        [Display(Name="Name")]
        public string Name {get;set;}

        [Required(ErrorMessage = "is required")]
        [Display(Name="Tastiness")]

        public int Tastiness {get;set;}

        [Required(ErrorMessage = "is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Calories must be a positive number")]
        public int Calories {get;set;}

        [Required(ErrorMessage = "is required")]

        public string Description {get;set;}

        public int ChefId {get;set;}//Foreign Key
        public Chef Cook {get;set;}//1 Chef related to eatch Dish
        public DateTime CreatedAt {get;set;}=DateTime.Now;
        public DateTime UpdatedAt {get;set;}=DateTime.Now;
        
    }
}