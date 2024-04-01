using JenHairousApp.Shared.Entities;
using JenHairousApp.Shared.Wrapper;

namespace JenHairousApp.Server.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey>
            where TEntity : Entity<TPrimaryKey>
    {

        Task<List<TEntity>>             GetAllAsync();
        Task<TEntity>                   GetAsync(TPrimaryKey id);
        Task<Result<bool>>              InsertAsync(TEntity entity);
        Task                            UpdateAsync(TEntity entity);
        Task<bool>                      DeleteAsync(TPrimaryKey id);

    }
}
