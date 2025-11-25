using Examples.CleanArquitecture.Application.Contracts.Persistence;
using Examples.CleanArquitecture.Domain.Common;
using Examples.CleanArquitecture.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Examples.CleanArquitecture.Persistence.Repositories;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    /// <summary>
    /// 
    /// </summary>
    protected readonly PersonsDatabaseContext _context;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public GenericRepository(PersonsDatabaseContext context)
    {
        this._context = context;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task CreateAsync(T entity)
    {
        await this._context.AddAsync(entity);
        await this._context.SaveChangesAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await this._context.SaveChangesAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await this._context.Set<T>().AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<T> GetByIdAsync(int id)
    {
        return await this._context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task UpdateAsync(T entity)
    {
        this._context.Entry(entity).State = EntityState.Modified;
        await this._context.SaveChangesAsync();
    }
}
