using JenHairousApp.Server.Data;
using JenHairousApp.Shared.DBEntities;
using JenHairousApp.Shared.Entities;
using JenHairousApp.Shared.Wrapper;

namespace JenHairousApp.Server.Repositories.CategoriesRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext      = dbContext;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool flag       = false;
            var _category    = _dbContext.Categories.FirstOrDefault( x => x.Id == id );
            if (_category != null)
            {
                _dbContext.Categories.Remove(_category);
                _dbContext.SaveChanges();
                flag = true;
            }
            return flag;
        }

        public async Task<List<CategoryModel>> GetAllAsync()
        {
            var data            = _dbContext.Categories.ToList();
            var _categoryList   = new List<CategoryModel>();
            foreach (var c in data)
            {
                var _categoryModel      = new CategoryModel();
                _categoryModel.Id       = c.Id;
                _categoryModel.Name     = c.Name;
                _categoryList.Add(_categoryModel);
            }

            return _categoryList;
        }

        public Task<CategoryModel> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<bool>> GetByUniqueNameAsync( string name )
        {
            var result = _dbContext.Categories.FirstOrDefault(c => c.Name == name);
            if (result != null)
                return Result<bool>.Success(true);                
            else
                return Result<bool>.Fail();
        }

        public async Task<Result<bool>> InsertAsync( CategoryModel category )
        {
            string message;
            var categoryPresent     = _dbContext.Categories.ToList().FirstOrDefault( x => x.Id == category.Id ) ?? new Category();
            categoryPresent.Name    = category.Name;

            if (categoryPresent == null)
            {
                _dbContext.Add(categoryPresent);
                message = "Category Added!";
            }
            else
            {
                _dbContext.Update(categoryPresent);
                message =  "Category Updated!";
            }

            _dbContext.SaveChanges();
            return Result<bool>.Success(true, message);
        }

        public Task UpdateAsync(CategoryModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
