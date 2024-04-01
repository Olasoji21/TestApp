using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenHairousApp.Shared.Routes
{
    public class CategoriesEndPoint
    {
        public static string GetAllCategories   = "api/categories";
        public static string GetByUniqueName    = "api/categories/getbyname";
        public static string SaveCategory       = "api/categories";
        public static string DeleteCategory     = "api/categories";
    }
}
