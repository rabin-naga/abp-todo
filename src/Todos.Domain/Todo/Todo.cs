using System;
using Volo.Abp.Domain.Entities;

namespace Todos
{
  public class Todo : Entity<Guid>
  {
    public string Content { get; set; }
    public bool IsDone { get; set; }

    public Todo() { }

    public Todo(Guid id, string content, bool isDone)
    {
      Id = id;
      Content = content;
      IsDone = isDone;
    }
  }
}