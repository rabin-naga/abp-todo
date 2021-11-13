using System;
using Volo.Abp.Application.Dtos;

namespace Todos.Dto
{
  public class TodoDto
  {
    public string Content { get; set; }
    public bool IsDone { get; set; }
  }
}