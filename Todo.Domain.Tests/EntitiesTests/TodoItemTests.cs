using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.EntitiesTests;

[TestClass]
public class TodoItemTests
{
    private readonly TodoItem _validTodo = new TodoItem("titulo", "leo", DateTime.Now);
    [TestMethod]
    public void Dado_um_novo_todo_o_mesmo_deve_iniciar_como_nao_concluido()
    {
        Assert.AreEqual(_validTodo.Done, false);
    }
}