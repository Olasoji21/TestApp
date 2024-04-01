using JenHairous.Shared.Entities;
using JenHairousApp.Shared.Entities;
using JenHairousApp.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenHairousApp.Shared.Services.Categories
{
    public interface ICategoryService
    {
        Task<IResult<List<CategoryModel>>>              GetAllCategoriesAsync();

        Task<IResult<bool>>                             GetByUniqueName( string name           );

        Task<IResult<bool>>                             SaveCategoryAsync( CategoryModel category    );

        Task<IResult<bool>>                             DeleteCategoryAsync( int id );




    }
}
