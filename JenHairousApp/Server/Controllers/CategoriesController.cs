using JenHairousApp.Server.Repositories.CategoriesRepository;
using JenHairousApp.Shared.Entities;
using JenHairousApp.Shared.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JenHairousApp.Server.Controllers
{
    public class CategoriesController : BaseApiController<CategoriesController>
    {
        private readonly ICategoryRepository _categoriesRepository;

        public CategoriesController(ICategoryRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _categoriesRepository.GetAllAsync();
            return Ok( Result<List<CategoryModel>>.Success( categories ) );
        }

        [HttpGet("getbyname/{name}")]
        public async Task<IActionResult> GetByUniqueName( string name )
        {
            var response = await _categoriesRepository.GetByUniqueNameAsync( name );
            return Ok( response );
        }

        [HttpPost]
        public async Task<IActionResult> SaveCategoryAsync( CategoryModel category )
        {
            var response = await _categoriesRepository.InsertAsync( category );
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync( int id )
        {
            var result = await _categoriesRepository.DeleteAsync(id);
            var message = result ? "Category deleted" : string.Empty;
            return Ok(Result<bool>.Success(result, message));
        }
    }
}
