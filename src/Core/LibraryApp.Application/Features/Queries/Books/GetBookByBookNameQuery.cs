using AutoMapper;
using LibraryApp.Application.Dto;
using LibraryApp.Application.Interfaces.Repositories;
using LibraryApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Features.Queries.Books
{
    public class GetBookByBookNameQuery : IRequest<ServiceResponse<BookViewDto>>
    {
        public string BookName { get; set; }

        public class GetBookByBookNameQueryHandler : IRequestHandler<GetBookByBookNameQuery, ServiceResponse<BookViewDto>>
        {
            private readonly IBookRepository bookRepository;
            private readonly IMapper mapper;

            public GetBookByBookNameQueryHandler(IBookRepository bookRepository, IMapper mapper)
            {
                this.bookRepository = bookRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<BookViewDto>> Handle(GetBookByBookNameQuery request, CancellationToken cancellationToken)
            {
                var book = await bookRepository.GetByBookNameAsync(request.BookName);
                var dto = mapper.Map<BookViewDto>(book);
                return new ServiceResponse<BookViewDto>(dto);
            }
        }
    }
}
