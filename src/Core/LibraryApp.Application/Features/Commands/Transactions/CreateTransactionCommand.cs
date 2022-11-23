using AutoMapper;
using LibraryApp.Application.Dto;
using LibraryApp.Application.Interfaces.Repositories;
using LibraryApp.Application.Wrappers;
using LibraryApp.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Features.Commands.Transactions
{
    public class CreateTransactionCommand : IRequest<ServiceResponse<BookTransaction>>
    {
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime CheckInDate { get; set; }     
        public DateTime CreateDate { get; set; }        
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, ServiceResponse<BookTransaction>>
        {
            private readonly IBookTransactionRepository transactionRepository;
            private readonly IMapper mapper;

            public CreateTransactionCommandHandler(IBookTransactionRepository transactionRepository, IMapper mapper)
            {
                this.transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository)); ;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<BookTransaction>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
            {
                var transaction = mapper.Map<BookTransaction>(request);
                await transactionRepository.AddTransactionAsync(transaction);
                return new ServiceResponse<BookTransaction>(transaction);
            }
        }
    }
}
