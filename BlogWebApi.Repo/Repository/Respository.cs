using BlogWebApi.Data;
using BlogWebApi.Repo.Repository.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApi.Repo.Repository
{
    public class Respository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        private DbSet<T> entities;

        public Respository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            entities = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAllData()
        {
            return entities.AsEnumerable();
        }

        public T Get(int Id)
        {
            return entities.SingleOrDefault(x => x.Id == Id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entities.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entities.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entities.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void SaveChanges() => _dbContext.SaveChanges();

    }
}
