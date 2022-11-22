using AutoMapper;
using LibraryApp.Application.Features.Commands.Books;
using LibraryApp.Application.Features.Queries.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace LibraryApp.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator mediator;

        public BookController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllBooksQuery();
            return Ok(await mediator.Send(query));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBookByIdQuery() { Id = id };
            return Ok(await mediator.Send(query));
        }

        [HttpGet("{bookName}")]
        public async Task<IActionResult> GetByBookName(string bookName)
        {
            var query = new GetBookByBookNameQuery() { BookName = bookName };
            return Ok(await mediator.Send(query));
        }

        [HttpGet, Route("CheckForAll")]
        public async Task<IActionResult> GetCheckForAllOptions(string name)
        {
            var queryName = new GetCheckForAllOptions() { Name = name };
            return Ok(await mediator.Send(queryName));
        }

        [HttpGet("{author}")]
        public async Task<IActionResult> GetByAuthor(string author)
        {
            var query = new GetBookByAuthorQuery() { Author = author };
            return Ok(await mediator.Send(query));
        }

        [HttpGet("{isbn}")]
        public async Task<IActionResult> GetByISBN(string isbn)
        {
            var query = new GetBookByISBNQuery() { ISBN = isbn };
            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBookCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
