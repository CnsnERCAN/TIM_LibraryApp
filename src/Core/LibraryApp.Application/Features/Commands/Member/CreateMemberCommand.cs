using MediatR;
using LibraryApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Application.Features.Commands.Books;
using AutoMapper;
using LibraryApp.Application.Interfaces.Repositories;

namespace LibraryApp.Application.Features.Commands.Member
{
    public class CreateMemberCommand : IRequest<Domain.Entites.Member>
    {
        public string FullName { get; set; }
        public string Email { get; set; }

        public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Domain.Entites.Member>
        {
            private readonly IMemberRepository memberRepository;
            private readonly IMapper mapper;

            public CreateMemberCommandHandler(IMemberRepository memberRepository, IMapper mapper)
            {
                this.memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
                this.mapper = mapper;
            }

            public async Task<Domain.Entites.Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
            {
                var member = mapper.Map<Domain.Entites.Member>(request);
                await memberRepository.AddAsync(member);
                return member;
            }
        }
    }
}
