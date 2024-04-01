using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenHairousApp.Shared.Entities
{
    public class CategoryModel: Entity<int>
    {
        [Required(ErrorMessage = "*Category name is required")]
        public string Name { get; set; }

        public CategoryModel()
        {
                
        }

        public CategoryModel( int id, string name )
        {
            Id      = id;
            Name    = name;
        }
    }
}
