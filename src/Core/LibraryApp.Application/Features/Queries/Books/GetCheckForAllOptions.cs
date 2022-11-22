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
    public class GetCheckForAllOptions : IRequest<ServiceResponse<List<BookViewDto>>>
    {
        public string Name { get; set; }

        public class GetCheckForAllOptionsHandler : IRequestHandler<GetCheckForAllOptions, ServiceResponse<List<BookViewDto>>>
        {
            private readonly IBookRepository repository;
            private readonly IMapper mapper;

            public GetCheckForAllOptionsHandler(IBookRepository repository, IMapper mapper)
            {
                this.repository = repository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<BookViewDto>>> Handle(GetCheckForAllOptions request, CancellationToken cancellationToken)
            {
                var response = await repository.GetCheckAllOptions(request.Name);
                var dto = mapper.Map<List<BookViewDto>>(response);
                return new ServiceResponse<List<BookViewDto>> (dto);
            }
        }
    }
}
