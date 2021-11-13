using System;
using Volo.Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Todos.AppEntities
{
  public class Tag : Entity<Guid>
  {
    [Required]
    public string TagName { get; set; }
    public DateTime CreatedAt { get; set; }

    public Tag(string tagName)
    {
      TagName = tagName;
      CreatedAt = DateTime.Now;
    }
  }
}