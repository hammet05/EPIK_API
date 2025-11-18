using System.Linq.Expressions;

namespace Epik_PersonApp.Application.Interfaces.Persistence
{
    public interface IRepository<T> where T : class
    {
        Task<T?> Encontrar(Guid id);
        Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>>? filter = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                    string? includeProperties = null,
                                    bool isTracking = true
                                   );

        Task<T> ObtenerPrimero(Expression<Func<T, bool>>? filter = null,
                                  string? includeProperties = null,
                                  bool isTracking = true);
        Task Crear(T entity);

        void Actualizar(T entity);

        Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>>? filter = null,
                                    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool isTracking = true,
                                    params Expression<Func<T, object>>[] includes);
        //Task ActivarAsync(string identificacion);

        //Task DesactivarAsync(string identificacion);
    }
}
