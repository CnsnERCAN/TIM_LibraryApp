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
    public class GetAllBooksQuery : IRequest<ServiceResponse<List<BookViewDto>>>
    {
        public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, ServiceResponse<List<BookViewDto>>>
        {
            private readonly IBookRepository bookRepository;
            private readonly IMapper mapper;

            public GetAllBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
            {
                this.bookRepository = bookRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<BookViewDto>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
            {
                var books = await bookRepository.GetAllAsync();
                var viewModel = mapper.Map<List<BookViewDto>>(books);
                return new ServiceResponse<List<BookViewDto>>(viewModel);
            }
        }
    }
}
