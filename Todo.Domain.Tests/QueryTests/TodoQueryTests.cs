using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests;

[TestClass]
public class TodoQueryTests
{
    private List<TodoItem> _items;

    public TodoQueryTests()
    {
        _items = new List<TodoItem>();
        _items.Add(new TodoItem("Tarefa 1", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 2", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 3", "andrebaltieri", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 4", "usuarioA", DateTime.Now));
        _items.Add(new TodoItem("Tarefa 5", "andrebaltieri", DateTime.Now));
    }
    [TestMethod]
    public void Dada_a_consulta_deve_retornar_apenas_tarefas_do_usuario_andre()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("andrebaltieri"));
        Assert.AreEqual(2, result.Count());
    }
    [TestMethod]
    public void Dada_a_consulta_deve_retornar_apenas_tarefas_do_usuario_andre_feitas()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAllDone("andrebaltieri"));
        Assert.AreEqual(0, result.Count());
    }
    [TestMethod]
    public void Dada_a_consulta_deve_retornar_apenas_tarefas_do_usuario_andre_nao_feitas()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAllUndone("andrebaltieri"));
        Assert.AreEqual(2, result.Count());
    }
    [TestMethod]
    public void Dada_a_consulta_deve_retornar_uma_tarefa_pelo_id()
    {
        var todo = new TodoItem("Tarefa 332", "andrebaltieri", DateTime.Now);
        _items.Add(todo);

        var result = _items.AsQueryable().Where(TodoQueries.GetById(todo.Id, todo.User));
        Assert.AreEqual(1, result.Count());
    }
}