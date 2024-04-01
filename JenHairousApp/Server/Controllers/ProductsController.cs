using JenHairous.Shared.Entities;
using JenHairousApp.Server.Repositories.ProductsRepository;
using JenHairousApp.Shared.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JenHairousApp.Server.Controllers.v1
{
    public class ProductsController : BaseApiController<ProductsController>
    {
        private readonly IProductsRepository    _productsRepository;
        public ProductsController(IProductsRepository productsRepository, IWebHostEnvironment env)
        {
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products    = await _productsRepository.GetAllAsync();
            return Ok(Result<List<ProductModel>>.Success(products));
        }

        [HttpPost]
        [Route("SaveProduct")]
        public async Task<IActionResult> SaveProduct( ProductModel product )
        {
            await _productsRepository.InsertAsync( product );
            return Ok(Result<int>.Success());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct( int id)
        {
            var result  = await _productsRepository.DeleteAsync( id );
            return Ok(Result<bool>.Success(result));
        }
    }
}
