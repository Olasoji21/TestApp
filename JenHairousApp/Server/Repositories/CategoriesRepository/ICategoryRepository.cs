using JenHairous.Shared.Entities;
using JenHairousApp.Shared.Entities;
using JenHairousApp.Shared.Wrapper;

namespace JenHairousApp.Server.Repositories.CategoriesRepository
{
    public interface ICategoryRepository: IRepository<CategoryModel, int>
    {
        Task<Result<bool>>         GetByUniqueNameAsync( string name );
    }
}
