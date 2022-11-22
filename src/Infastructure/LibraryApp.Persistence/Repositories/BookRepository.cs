using LibraryApp.Application.Interfaces.Repositories;
using LibraryApp.Domain.Entites;
using LibraryApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Book>> GetCheckAllOptions(string name)
        {
            List<Book> listForBook = await dbContext.Books.Where(x => x.Name.Contains(name)).ToListAsync();
            List<Book> listForAuthor = await dbContext.Books.Where(x => x.Author.Contains(name)).ToListAsync();
            List<Book> listForISBN = await dbContext.Books.Where(x => x.ISBN.Contains(name)).ToListAsync();
            listForBook.AddRange(listForAuthor);
            listForBook.AddRange(listForISBN);
            return listForBook;
        }
    }
}
