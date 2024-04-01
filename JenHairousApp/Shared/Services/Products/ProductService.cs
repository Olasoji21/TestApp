using JenHairous.Shared.Entities;
using JenHairousApp.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JenHairousApp.Shared.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly  HttpClient _httpClient;
        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IResult<List<ProductModel>>> GetProducts()
        {
            var response = await _httpClient.GetAsync( Routes.ProductsEndPoint.GetAllProducts );
            return await response.ToResult<List<ProductModel>>();
        }

        public async Task<IResult<int>> SaveProduct( ProductModel product )
        {
            var response = await _httpClient.PostAsJsonAsync<ProductModel>("api/products/SaveProduct", product);
            return await response.ToResult<int>();
        }

        public async Task<IResult<bool>> DeleteProduct(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.ProductsEndPoint.DeleteProduct }/{id}");
            return await response.ToResult<bool>();
        }
    }
}
