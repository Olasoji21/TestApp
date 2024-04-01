using JenHairous.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JenHairousApp.Server.Repositories.ProductsRepository
{
    public interface IProductsRepository: IRepository<ProductModel, int>
    {
        Task<int>                               GetNewProductId();
    }
}
