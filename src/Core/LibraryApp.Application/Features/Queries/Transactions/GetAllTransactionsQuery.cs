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
    public class GetAllTransactionsQuery : IRequest<ServiceResponse<List<TransactionViewDto>>>
    {
        public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, ServiceResponse<List<TransactionViewDto>>>
        {
            private readonly IBookTransactionRepository transactionRepository;
            private readonly IMapper mapper;

            public GetAllTransactionsQueryHandler(IBookTransactionRepository transactionRepository, IMapper mapper)
            {
                this.transactionRepository = transactionRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<TransactionViewDto>>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
            {
                var transactions = await transactionRepository.GetAllAsync();
                var viewModel = mapper.Map<List<TransactionViewDto>>(transactions);
                return new ServiceResponse<List<TransactionViewDto>>(viewModel);
            }
        }
    }
}
