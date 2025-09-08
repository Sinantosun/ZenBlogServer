using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ZenBlog.Application.Contracts.Persistence;
using ZenBlog.Domain.Entites.Common;
using ZenBlog.Persistence.Context;

namespace ZenBlog.Persistence.Concrete;

public class GenericRepository<TEntity>(AppDbContext _context) : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly DbSet<TEntity> _table = _context.Set<TEntity>();

    public async Task CreateAsync(TEntity entity)
    {
        await _table.AddAsync(entity);
    }

    public void Delete(TEntity entity)
    {
        _table.Remove(entity);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {


        return await _table.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity> GetByIdAsync(Guid id)
    {
        return await _table.FindAsync(id);
    }

    public async Task<List<TEntity>> GetMultipleAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _table.Where(filter).ToListAsync();
    }

    public async Task<(List<TEntity> Data, int TotalCount)> GetPagedAsync(int page = 1, int pageSize = 8)
    {
        var totalCount = await _table.CountAsync();
        var data = await _table.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return (data, totalCount);
    }

    public IQueryable<TEntity> GetQuery()
    {
        return _table;
    }

    public async Task DeleteManyWithFilterAsync(Expression<Func<TEntity, bool>> filter)
    {
        await _table.Where(filter).ExecuteDeleteAsync();
    }

    public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _table.AsNoTracking().FirstOrDefaultAsync(filter);
    }

    public void Update(TEntity entity)
    {
        _table.Update(entity);
    }
}
