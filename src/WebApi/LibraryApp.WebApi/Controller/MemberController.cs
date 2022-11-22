using LibraryApp.Application.Features.Commands.Books;
using LibraryApp.Application.Features.Commands.Member;
using LibraryApp.Application.Features.Queries.Books;
using LibraryApp.Application.Features.Queries.Members;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMediator mediator;

        public MemberController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllMembersQuery();
            return Ok(await mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateMemberCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
