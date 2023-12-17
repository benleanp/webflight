using Microsoft.EntityFrameworkCore;
using WebFlightInfrastructure.Entities;

namespace WebFlightInfrastructure.Repositories;

public abstract class Repository<T> where T : BaseEntity
{
    protected DbContext DbContext { get; }

    protected Repository(DbContext dbContext)
    {
        DbContext = dbContext;
    }

    public virtual T Get(BaseEntity entity)
    {
        if (entity == null)
        {
            return default(T)!;
        }

        return DbContext.Set<T>().SingleOrDefault(x => x.Id == entity.Id);
    }

    public List<T> GetAll()
    {
        return DbContext.Set<T>().ToList();
    }

    public T Create(T entity)
    {
        var result = DbContext.Set<T>().Add(entity);
        return result.Entity;
    }

    public T Update(T entity)
    {
        var result = DbContext.Set<T>().Update(entity);
        return result.Entity;
    }

    public T Delete(T entity)
    {
        var result = DbContext.Set<T>().Remove(entity);
        return result.Entity;
    }
}