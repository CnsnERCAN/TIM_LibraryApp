using AutoMapper;
using LibraryApp.Application.Dto;
using LibraryApp.Application.Features.Queries.Books;
using LibraryApp.Application.Interfaces.Repositories;
using LibraryApp.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Features.Queries.Members
{
    public class GetAllMembersQuery : IRequest<ServiceResponse<List<MemberViewDto>>>
    {
        public class GetAllMembersQueryHandler : IRequestHandler<GetAllMembersQuery, ServiceResponse<List<MemberViewDto>>>
        {
            private readonly IMemberRepository memberRepository;
            private readonly IMapper mapper;

            public GetAllMembersQueryHandler(IMemberRepository memberRepository, IMapper mapper)
            {
                this.memberRepository = memberRepository;
                this.mapper = mapper;
            }

            public async Task<ServiceResponse<List<MemberViewDto>>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
            {
                var members = await memberRepository.GetAllAsync();
                var viewModel = mapper.Map<List<MemberViewDto>>(members);
                return new ServiceResponse<List<MemberViewDto>>(viewModel);
            }
        }
    }
}
