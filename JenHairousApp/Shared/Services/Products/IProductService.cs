using JenHairous.Shared.Entities;
using JenHairousApp.Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenHairousApp.Shared.Services.Products
{
    public interface IProductService
    {
        Task<IResult<List<ProductModel>>>       GetProducts();

        Task<IResult<int>>                      SaveProduct( ProductModel product);

        Task<IResult<bool>>                     DeleteProduct( int id);
    }
}
