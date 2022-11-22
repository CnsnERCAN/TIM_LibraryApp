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
    public class GetBookByAuthorQuery : IRequest<ServiceResponse<BookViewDto>>
    {
        public string Author { get; set; }

        public class GetBookByAuthorQueryHandler : IRequestHandler<GetBookByAuthorQuery, ServiceResponse<BookViewDto>>
        {
            private readonly IBookRepository bookRepository;
            private readonly IMapper mapper;

            public GetBookByAuthorQueryHandler(IBookRepository bookRepository, IMapper mapper)
            {
                this.bookRepository = bookRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<BookViewDto>> Handle(GetBookByAuthorQuery request, CancellationToken cancellationToken)
            {
                var book = await bookRepository.GetByAuthorAsync(request.Author);
                var dto = mapper.Map<BookViewDto>(book);
                return new ServiceResponse<BookViewDto>(dto);
            }
        }
    }
}