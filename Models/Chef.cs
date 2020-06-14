using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefAndDishes.Models
{
    public class Chef
    {
        [Key] //Primary Key
        public int ChefId {get;set;}

        [Required(ErrorMessage = "is required")]
        public string FirstName {get;set;}

        [Required(ErrorMessage = "is required")]

        public string LastName {get;set;}

        [Required(ErrorMessage = "is required")]
        // [DataType(DataType.Date)]
        // [OnlyDateInPast(ErrorMessage="Birthday must be in Past")]

        //in controller if (newChef.DOB >= DateTime.Now || newChef.DOB ) 
        // ModelState.AddModelMessage...
        [OnlyDateInPast(ErrorMessage="Birthday must be in Past")]
        [MinAge(18, ErrorMessage="Chef must be more than 18 years old")]


        public DateTime DOB {get;set;}

        public int Age{get;set;}
        public List<Dish> Dishes {get;set;}//1 Chef : N Dishes relationship
        public DateTime CreatedAt {get;set;}=DateTime.Now;
        public DateTime UpdatedAt {get;set;}=DateTime.Now;

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        //Min Age for Validation
        public class OnlyDateInPastAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if((DateTime)value > DateTime.Now)
                return new ValidationResult("Date must be in the Past");
            return ValidationResult.Success;
        }
        
    }

    public class MinAgeAttribute: ValidationAttribute
    {
        private int _Limit;
        public MinAgeAttribute (int limit)
        {
            this._Limit = limit;
        }
        public override bool IsValid(object value)
        {
            DateTime date;
            if(DateTime.TryParse(value.ToString(),out date))
            {
                return date.AddYears(_Limit) < DateTime.Now;
            }
            return false;
        }
        
    }

        // public class MinAge : ValidationAttribute
    // {
        // private int _Limit;
        // public MinAge(int Limit) { // The constructor which we use in modal.
            // this._Limit = Limit;
        // }
    //     protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
    //     {
    //             DateTime bday = DateTime.Parse(value.ToString());
    //             DateTime today = DateTime.Today;
    //             int age = today.Year - bday.Year;
    //             if (bday > today.AddYears(-age))
    //             {
    //                age--; 
    //             }
    //             if (age < _Limit)
    //             {
    //                 var result = new ValidationResult("Sorry you are not old enough");
    //                 return result; 
    //             }


    //         return null;

    //     }
    // }
//     [MinAge(18)]

//     DateTime now = DateTime.Today;
// int age = now.Year - bday.Year;
// if (now < bday.AddYears(age)) age--;
    }
    }
