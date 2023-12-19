using Microsoft.EntityFrameworkCore;
using WebFlightInfrastructure.Entities;

namespace WebFlightInfrastructure.Repositories;

public abstract class Repository<T> where T : BaseEntity
{
    protected Repository(DbContext dbContext)
    {
        DbContext = dbContext;
    }

    protected DbContext DbContext { get; }

    public virtual T Get(BaseEntity entity)
    {
        if (entity == null) return default!;

        return DbContext.Set<T>().SingleOrDefault(x => x.Id == entity.Id);
    }

    public virtual List<T> GetAll()
    {
        return DbContext.Set<T>().ToList();
    }

    public virtual T Create(T entity)
    {
        var result = DbContext.Set<T>().Add(entity);
        return result.Entity;
    }

    public virtual T Update(T entity)
    {
        var result = DbContext.Set<T>().Update(entity);
        return result.Entity;
    }

    public virtual T Delete(T entity)
    {
        var result = DbContext.Set<T>().Remove(entity);
        return result.Entity;
    }

    public bool Commit()
    {
        return DbContext.SaveChanges() > 0;
    }
}