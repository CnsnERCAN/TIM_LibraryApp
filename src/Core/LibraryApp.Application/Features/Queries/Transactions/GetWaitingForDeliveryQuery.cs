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
using System.Transactions;

namespace LibraryApp.Application.Features.Queries.Transactions
{
    public class GetWaitingForDeliveryQuery : IRequest<ServiceResponse<List<TransactionViewDto>>>
    {
        public class GetWaitingForDeliveryQueryHandler : IRequestHandler<GetWaitingForDeliveryQuery, ServiceResponse<List<TransactionViewDto>>>
        {
            private readonly IBookTransactionRepository transactionRepository;
            private readonly IMapper mapper;

            public GetWaitingForDeliveryQueryHandler(IBookTransactionRepository transactionRepository, IMapper mapper)
            {
                this.transactionRepository = transactionRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<TransactionViewDto>>> Handle(GetWaitingForDeliveryQuery request, CancellationToken cancellationToken)
            {
                var listForLast3Days = await transactionRepository.GetLast3DaysAsync(DateTime.Now.Date);
                var last3Days = mapper.Map<List<TransactionViewDto>>(listForLast3Days);
                return new ServiceResponse<List<TransactionViewDto>>(last3Days);
            }
        }
    }
}
