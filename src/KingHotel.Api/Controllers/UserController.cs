using KingHotel.Application.Commands.User;
using KingHotel.Application.Queries.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingHotel.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "admin, operator")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var getAllUsersQuery = new GetAllUsersQuery();

                var users = await _mediator.Send(getAllUsersQuery);

                return Ok(users);
            }
            catch (Exception e)
            {

                return BadRequest(new { Message=$"Houve um erro, contate o administrador do sistema. {e}" });
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var getByIdUserQuery = new GetByIdUserQuery(id);

                var user = await _mediator.Send(getByIdUserQuery);
                return Ok(user);
            }
            catch (Exception e)
            {

                return BadRequest(new { Message = $"Houve um erro, contate o administrador do sistema. {e}" });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] CreateUserCommand createUserCommand)
        {
            try
            {
                var id = await _mediator.Send(createUserCommand);
                return CreatedAtAction(nameof(GetById), new { id = id }, createUserCommand);
            }
            catch (Exception e)
            {

                return BadRequest(new { Message = $"Houve um erro, contate o administrador do sistema. {e}" });
            }
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Put([FromBody] UpdateUserCommand updateUserCommand)
        {
            try
            {
                var id = await _mediator.Send(updateUserCommand);
                if(updateUserCommand == null)
                    return BadRequest(new { Message="Houve um erro, entre em contato com o administrador do sistema." });
                return Ok(id);
            }
            catch (Exception e)
            {

                return BadRequest(new { Message = $"Houve um erro, contate o administrador do sistema. {e}" });
            }
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Remove(Guid id)
        {
            try
            {
                var command = new DeleteUserCommand(id);
                await _mediator.Send(command);

                return NoContent();

            }
            catch (Exception e)
            {

                return BadRequest(new { Message = $"Houve um erro, contate o administrador do sistema. {e}" });
            }
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginUserCommand command)
        {
            try
            {
                var loginUserViewModel = await _mediator.Send(command);
                if(loginUserViewModel == null)
                    return NotFound(new { Message="Usuário ou senha incorretos." });
                return Ok(loginUserViewModel);
            }
            catch (Exception e)
            {

                return BadRequest(new { Message=$"Erro ao tentar logar: {e}" });
            }
        }
    }
}
