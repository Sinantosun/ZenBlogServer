using System.Linq.Expressions;
using ZenBlog.Domain.Entites.Common;

namespace ZenBlog.Application.Contracts.Persistence;

public interface IRepository<TEntity> where TEntity : BaseEntity
{
    Task<List<TEntity>> GetAllAsync();

    IQueryable<TEntity> GetQuery();

    Task<TEntity> GetByIdAsync(Guid id);

    Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter);
    Task<List<TEntity>> GetMultipleAsync(Expression<Func<TEntity, bool>> filter);

    Task CreateAsync(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<(List<TEntity> Data, int TotalCount)> GetPagedAsync(int page = 1, int pageSize = 8);
}
