using hlzn1.APIModels;
using Microsoft.EntityFrameworkCore;

namespace hlzn1.Services;

public interface ICRUDGenericService<T, TKey> where T : class
{
    Task<BasicCreateUpdateResponse<T>> CreateAsync(BasicCreateUpdateRequest<T> request);
    Task<BasicResponse<T>> UpdateAsync(BasicCreateUpdateRequest<T> request);
    Task<BasicResponse<bool>> DeleteAsync(TKey id);
    Task<BasicResponse<T>> GetByIdAsync(TKey id);
    Task<BasicResponse<List<T>>> GetAllAsync(BasicCollectionRequest request);
}

public class CRUDGenericService<T, TKey> : ICRUDGenericService<T, TKey> where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public CRUDGenericService(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public virtual async Task<BasicCreateUpdateResponse<T>> CreateAsync(BasicCreateUpdateRequest<T> request)
    {
        try
        {
            var entity = request.Data;
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new BasicCreateUpdateResponse<T>
            {
                Success = true,
                Data = entity
            };
        }
        catch (Exception ex)
        {
            return new BasicCreateUpdateResponse<T>
            {
                Success = false,
                Message = ex.Message
            };
        }
    }

    public virtual async Task<BasicResponse<bool>> DeleteAsync(TKey id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            return new BasicResponse<bool>
            {
                Success = false,
                Message = "Entity not found"
            };
        }

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();

        return new BasicResponse<bool>
        {
            Success = true,
            Data = true
        };
    }

    public virtual Task<BasicResponse<List<T>>> GetAllAsync(BasicCollectionRequest request)
    {
        throw new NotImplementedException();
    }

    public virtual Task<BasicResponse<T>> GetByIdAsync(TKey id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<BasicResponse<T>> UpdateAsync(BasicCreateUpdateRequest<T> request)
    {
        throw new NotImplementedException();
    }
}
