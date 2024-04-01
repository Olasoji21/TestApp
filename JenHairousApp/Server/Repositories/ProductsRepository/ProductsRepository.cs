using JenHairous.Shared.Entities;
using JenHairousApp.Server.Data;
using JenHairousApp.Shared.DBEntities;
using JenHairousApp.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenHairousApp.Server.Repositories.ProductsRepository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext       _dbContext;
        public ProductsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool flag       = false;
            var _product    = _dbContext.Products.FirstOrDefault( x => x.Id == id );
            if (_product != null)
            {
                _dbContext.Products.Remove(_product);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public async Task<List<ProductModel>> GetAllAsync()
        {
            var productData                 = _dbContext.Products.ToList();
            var _productList                = new List<ProductModel>();
            foreach (var c in productData)
            {
                var _productModel           = new ProductModel();
                _productModel.Id            = c.Id;
                _productModel.Name          = c.Name;
                _productModel.Price         = c.Price;
                _productModel.Stock         = c.Stock;
                _productModel.ImageUrl      = c.ImageUrl;
                _productModel.CategoryId    = c.CategoryId;
                _productList.Add(_productModel);
            }
            return _productList;
        }

        public Task<ProductModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetNewProductId()
        {
            try
            {
                int nextProductId   = _dbContext.Products.ToList().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefault();
                return nextProductId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Result<bool>> InsertAsync(ProductModel product)
        {
            var productPresent      = _dbContext.Products.ToList().FirstOrDefault(x => x.Id == product.Id)  ?? new Product();

            productPresent.Name           = product.Name;
            productPresent.ImageUrl       = product.ImageUrl;
            productPresent.Price          = product.Price;
            productPresent.Stock          = product.Stock;
            productPresent.CategoryId     = product.CategoryId;

            if (productPresent == null )
            {
                _dbContext.Add(productPresent);
            }
            else
            {
                _dbContext.Update(productPresent);
            }

            _dbContext.SaveChanges();
            return Result<bool>.Success(true);
        }

        public Task UpdateAsync(ProductModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
