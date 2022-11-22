using LibraryApp.Application.Interfaces.Repositories;
using LibraryApp.Domain.Common;
using LibraryApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByAuthorAsync(string name)
        {
            return await dbContext.Set<T>().FindAsync(name) ?? throw new ArgumentNullException(nameof(name));
        }

        public async Task<T> GetByBookNameAsync(string name)
        {
            return await dbContext.Set<T>().FindAsync(name) ?? throw new ArgumentNullException(nameof(name));
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id) ?? throw new ArgumentNullException(nameof(id));
        }

        public async Task<T> GetByISBNAsync(string name)
        {
            return await dbContext.Set<T>().FindAsync(name) ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
