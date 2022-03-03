using Application.Repository.Base.Interface;
using Domain.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Base;

public class BaseAsyncRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class
{
    private readonly CustomerContext _customerContext;
    public BaseAsyncRepository(CustomerContext customerContext)
    {
        _customerContext = customerContext;
    }
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _customerContext.Set<TEntity>().AddAsync(entity);
        await _customerContext.SaveChangesAsync();
        return entity;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _customerContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity> GetAsync(int id)
    {
        return await _customerContext.Set<TEntity>().FindAsync(id);
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _customerContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        await _customerContext.SaveChangesAsync();
    }
}
