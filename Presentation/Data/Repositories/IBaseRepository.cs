using Presentation.Data.Models;
using System.Linq.Expressions;

namespace Presentation.Data.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<RepositoryResult> AddAsync(TEntity entity);
    Task<RepositoryResult> AlreadyExistAsync(Expression<Func<TEntity, bool>> experssion);
    Task<RepositoryResult> DeleteAsync(TEntity entity);
    Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync();
    Task<RepositoryResult<TEntity?>> GetAsync(Expression<Func<TEntity, bool>> experssion);
    Task<RepositoryResult> UpdateAsync(TEntity entity);
}