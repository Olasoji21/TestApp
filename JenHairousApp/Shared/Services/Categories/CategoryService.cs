using JenHairous.Shared.Entities;
using JenHairousApp.Shared.Entities;
using JenHairousApp.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JenHairousApp.Shared.Services.Categories
{
    public class CategoryService : ICategoryService
    {

        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient             = httpClient;
        }

        public async Task<IResult<bool>> GetByUniqueName( string name )
        {
            var response = await _httpClient.GetAsync($"{Routes.CategoriesEndPoint.GetByUniqueName}/{name}");
            return await response.ToResult<bool>();
        }

        public async Task<IResult<List<CategoryModel>>> GetAllCategoriesAsync()
        {
            var response = await _httpClient.GetAsync( Routes.CategoriesEndPoint.GetAllCategories );
            return await response.ToResult<List<CategoryModel>>();
        }

        public async Task<IResult<bool>> SaveCategoryAsync( CategoryModel category )
        {
            var response = await _httpClient.PostAsJsonAsync( Routes.CategoriesEndPoint.SaveCategory, category);
            return await response.ToResult<bool>();
        }

        public async Task<IResult<bool>> DeleteCategoryAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.CategoriesEndPoint.DeleteCategory}/{id}");
            return await response.ToResult<bool>();
        }
    }
}
