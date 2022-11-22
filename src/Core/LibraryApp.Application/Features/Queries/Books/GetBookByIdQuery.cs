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
    public class GetBookByIdQuery : IRequest<ServiceResponse<BookViewDto>>
    {
        public int Id { get; set; }

        public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, ServiceResponse<BookViewDto>>
        {
            private readonly IBookRepository bookRepository;
            private readonly IMapper mapper;

            public GetBookByIdQueryHandler(IBookRepository bookRepository, IMapper mapper)
            {
                this.bookRepository = bookRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<BookViewDto>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
            {
                var book = await bookRepository.GetByIdAsync(request.Id);
                var dto = mapper.Map<BookViewDto>(book);
                return new ServiceResponse<BookViewDto>(dto);
            }
        }
    }
}
