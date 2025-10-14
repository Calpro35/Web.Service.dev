using Web.Service.Cap7.Models;

namespace Web.Service.Cap7.Interfaces;

public interface IRepository<T> where T : Model
{
    Task CreateAsync(T entity, CancellationToken cancellationToken);
    void Update(T entity);
    void Delete(T entity);
    Task<T?> GetAsync(int id, CancellationToken cancellationToken);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
}
