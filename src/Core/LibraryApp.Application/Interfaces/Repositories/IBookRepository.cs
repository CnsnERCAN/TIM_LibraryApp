using LibraryApp.Application.Dto;
using LibraryApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Interfaces.Repositories
{
    public interface IBookRepository : IGenericRepositoryAsync<Book>
    {
        Task<Book> GetByAuthorAsync(string name);
        Task<Book> GetByISBNAsync(string name);
        Task<Book> GetByBookNameAsync(string name);
        Task<List<Book>> GetCheckAllOptions(string name);
    }
}
