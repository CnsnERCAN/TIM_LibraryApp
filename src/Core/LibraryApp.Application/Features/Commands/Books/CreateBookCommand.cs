using AutoMapper;
using LibraryApp.Application.Interfaces.Repositories;
using LibraryApp.Application.Wrappers;
using LibraryApp.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Features.Commands.Books
{
    public class CreateBookCommand : IRequest<Book>
    {
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
        {
            private readonly IBookRepository bookRepository;
            private readonly IMapper mapper;

            public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
            {
                this.bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
                this.mapper = mapper;
            }

            public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
            {
                var book = mapper.Map<Domain.Entites.Book>(request);
                await bookRepository.AddAsync(book);
                return book;
            }
        }
    }
}

