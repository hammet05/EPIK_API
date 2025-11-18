using Epik_PersonApp.Application.Interfaces.Persistence;
using Epik_PersonApp.Domain.Common;
using Epik_PersonApp.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Epik_PersonApp.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _applicationDbContext;
        internal DbSet<T> _dbSet;

        public Repository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _dbSet = _applicationDbContext.Set<T>();
        }

        public async Task Crear(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string? includeProperties = null, bool isTracking = true)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool isTracking = true, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _dbSet;

            // Aplicar filtro
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Aplicar includes tipados
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // Orden
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            // Tracking
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task<T?> Encontrar(Guid id)
        {
            return await _dbSet!.FindAsync(id);
        }

        public Task<T> ObtenerPrimero(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool isTracking = true)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            return query.FirstOrDefaultAsync()!;
        }

        public void Actualizar(T entity)
        {
            if (entity is BaseEntity baseEntity)
            {
                baseEntity.SetUpdated();
            }

            _dbSet.Update(entity);
        }
        //public async Task ActivarAsync(string identificacion)
        //{
        //    var entity = await _dbSet.FindAsync(identificacion);
        //    if (entity is BaseEntity baseEntity)
        //    {
        //        baseEntity.Activate();
        //        _dbSet.Update(entity);

        //    }
        //}
        //public async Task DesactivarAsync(string identificacion)
        //{
        //    var entity = await _dbSet.FindAsync(identificacion);
        //    if (entity is BaseEntity baseEntity)
        //    {
        //        baseEntity.Deactivate();
        //        _dbSet.Update(entity);
        //    }
        //}
    }
}
