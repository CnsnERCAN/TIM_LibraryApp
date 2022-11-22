using LibraryApp.Application.Features.Commands.Transactions;
using LibraryApp.Application.Features.Queries.Books;
using LibraryApp.Application.Features.Queries.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator mediator;

        public TransactionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllTransactionsQuery();
            return Ok(await mediator.Send(query));
        }

        [HttpGet("{bookName}")]
        public async Task<IActionResult> GetByBookName(string bookName)
        {
            var query = new GetTransactionByBookName() { BookName = bookName };
            return Ok(await mediator.Send(query));
        }

        [HttpGet, Route("GetWaitingDeliveryList")]
        public async Task<IActionResult> GetWaitingDeliveryList()
        {
            var query = new GetWaitingForDeliveryQuery();
            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction(CreateTransactionCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
