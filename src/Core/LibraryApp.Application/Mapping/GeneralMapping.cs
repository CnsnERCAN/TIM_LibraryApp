using AutoMapper;
using LibraryApp.Application.Dto;
using LibraryApp.Application.Features.Commands.Books;
using LibraryApp.Application.Features.Commands.Member;
using LibraryApp.Application.Features.Commands.Transactions;
using LibraryApp.Application.Features.Queries.Transactions;
using LibraryApp.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Book, Dto.BookViewDto>().ReverseMap();
            CreateMap<Member, MemberReadDto>().ReverseMap();

            CreateMap<Book, BookReadDto>().ReverseMap();

            CreateMap<BookTransaction, TransactionViewDto>().ReverseMap();

            CreateMap<Member, CreateMemberCommand>().ReverseMap();
            CreateMap<Book, CreateBookCommand>().ReverseMap();
            CreateMap<BookTransaction, CreateTransactionCommand>().ReverseMap();

            CreateMap<Member, MemberViewDto>().ReverseMap();
        }
    }
}
