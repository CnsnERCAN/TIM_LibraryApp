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

namespace LibraryApp.Application.Features.Queries.Transactions
{
    public class GetTransactionByBookName : IRequest<ServiceResponse<TransactionViewDto>>
    {
        public string BookName { get; set; }

        public class GetTransactionByBookNameHandler : IRequestHandler<GetTransactionByBookName, ServiceResponse<TransactionViewDto>>
        {
            private readonly IBookTransactionRepository transactionRepository;
            private readonly IMapper mapper;

            public GetTransactionByBookNameHandler(IBookTransactionRepository transactionRepository, IMapper mapper)
            {
                this.transactionRepository = transactionRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<TransactionViewDto>> Handle(GetTransactionByBookName request, CancellationToken cancellationToken)
            {
                var transaction = await transactionRepository.GetByBookNameAsync(request.BookName);
                var dto = mapper.Map<TransactionViewDto>(transaction);
                return new ServiceResponse<TransactionViewDto>(dto);
            }
        }
    }
}
