using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Todos.AppEntities;
using Volo.Abp.Domain.Repositories;

namespace Todos.AppServices
{
  public class TagService : TodosAppService
  {
    private readonly IRepository<Tag, Guid> tagRepository;

    public new ILogger<TodosAppService> Logger { get; set; }
    public TagService(IRepository<Tag, Guid> tagRepository)
    {
      this.tagRepository = tagRepository;
    }

    public async Task<Tag> CreateAsync(Tag tag)
    {
      try
      {
        var createdTag = await this.tagRepository.InsertAsync(tag);
        return createdTag;
      }
      catch (Exception ex)
      {
        Logger.LogException(ex, LogLevel.Warning);
        throw new Exception(ex.Message);
      }
    }
  }
}