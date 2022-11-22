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
    public class GetBookByISBNQuery : IRequest<ServiceResponse<BookViewDto>>
    {
        public string ISBN { get; set; }

        public class GetBookByISBNHandler : IRequestHandler<GetBookByISBNQuery, ServiceResponse<BookViewDto>>
        {
            private readonly IBookRepository bookRepository;
            private readonly IMapper mapper;

            public GetBookByISBNHandler(IBookRepository bookRepository, IMapper mapper)
            {
                this.bookRepository = bookRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<BookViewDto>> Handle(GetBookByISBNQuery request, CancellationToken cancellationToken)
            {
                var book = await bookRepository.GetByISBNAsync(request.ISBN);
                var dto = mapper.Map<BookViewDto>(book);
                return new ServiceResponse<BookViewDto>(dto);
            }
        }
    }
}
