using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create(
        [FromBody] CreateTodoCommand command,
        [FromServices] TodoHandler handler
       )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(
        [FromServices] ITodoRepository repository
       )
        {
            return repository.GetAll("andre balta");
        }

        [Route("done/todau")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday(
        [FromServices] ITodoRepository repository
       )
        {
            return repository.GetByPeriod("andre balta", DateTime.Now.Date, true);
        }
        [Route("undone/todau")]
        [HttpGet]
        public IEnumerable<TodoItem> GetUndoneForToday(
        [FromServices] ITodoRepository repository
       )
        {
            return repository.GetByPeriod("andre balta", DateTime.Now.Date, false);
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone(
        [FromServices] ITodoRepository repository
       )
        {
            return repository.GetAllDone("andre balta");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone(
        [FromServices] ITodoRepository repository
       )
        {
            return repository.GetAllUndone("andre");
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update(
        [FromBody] UpdateTodoCommand command,
        [FromServices] TodoHandler handler
       )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
        [FromBody] MarkTodoAsDoneCommand command,
        [FromServices] TodoHandler handler
       )
        {
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return (GenericCommandResult)handler.Handle(command);
        }
        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
        [FromBody] MarkTodoAsUndoneCommand command,
        [FromServices] TodoHandler handler
       )
        {
            command.User = "andre balta";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}