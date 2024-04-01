using AtmosUserManager.Domain.Contracts;
using JenHairousApp.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JenHairous.Shared.Entities
{
    public class ProductModel : Entity<int> 
    {
        [Required(ErrorMessage="*Product Price is required")]
        public int?             Price           { get; set; }

        [Required(ErrorMessage ="*Product Stock is required")]
        public int?             Stock           { get; set; }

        [Required(ErrorMessage ="*Product Category is required")]
        public int?             CategoryId      { get; set; } 

        [Required(ErrorMessage = "*Product Name is required")]
        public string           Name            { get; set; }

        //[Required(ErrorMessage = "*Kindly Upload Product Photo")]
        public string           FileName        { get; set; }
        public string           CategoryName    { get; set; }
        public string           ImageUrl        { get; set; }
    }
}
