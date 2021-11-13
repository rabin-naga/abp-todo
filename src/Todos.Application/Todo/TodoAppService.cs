
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Todos.Dto;
using Todos.Permissions;
using Volo.Abp.Domain.Repositories;

namespace Todos
{
  [Authorize(Roles = "admin")]
  public class TodoAppService : TodosAppService
  {
    private readonly IRepository<Todo, Guid> todoRepository;
    public TodoAppService(IRepository<Todo, Guid> todoRepository)
    {
      this.todoRepository = todoRepository;
    }

    [Authorize(TodosPermissions.Todo.Default)]
    public async Task<List<Todo>> GetAll()
    {
      // return ObjectMapper.Map<List<Todo>, List<TodoDto>>(await todoRepository.GetListAsync());
      var todos = await todoRepository.ToListAsync();
      return todos;
    }

    public async Task<Todo> CreateAsync(TodoDto todoDto)
    {
      try
      {
        var todo = new Todo(GuidGenerator.Create(), todoDto.Content, todoDto.IsDone);
        var createdTodo = await todoRepository.InsertAsync(todo);
        // return ObjectMapper.Map<Todo, TodoDto>(createdTodo);
        return createdTodo;
      }
      catch (Exception ex)
      {
        throw new Exception(ex.Message);
        //  throw new UserFriendlyException(ex.Message, "403");
      }

    }

    public async Task<TodoDto> UpdateAsync(TodoDto todoDto)
    {
      var todo = ObjectMapper.Map<TodoDto, Todo>(todoDto);
      var createdTodo = await todoRepository.UpdateAsync(todo);
      return ObjectMapper.Map<Todo, TodoDto>(createdTodo);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
      var todo = await todoRepository.FirstOrDefaultAsync(x => x.Id == id);
      if (todo != null)
      {
        await todoRepository.DeleteAsync(todo);
        return true;
      }
      return false;
    }
  }

}