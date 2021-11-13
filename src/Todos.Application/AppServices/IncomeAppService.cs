using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Todos.Application.AppServices
{
    public class IncomeAppService: ApplicationService
    {
        private readonly IRepository<Todo, Guid> todoRepository;

        public IncomeAppService(IRepository<Todo, Guid> todoRepository)
        {
        this.todoRepository = todoRepository;
        }
    }
}