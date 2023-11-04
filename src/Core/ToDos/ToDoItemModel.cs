using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoIt.Core.Models;
using DoIt.Core.Repositories;

namespace DoIt.Core.ToDos
{
    public class ToDoItemModel : CRUDModel<ToDoItem, IRepository<ToDoItem>>
    {
        public ToDoItemModel(IRepository<ToDoItem> repository) : base(repository)
        {
        }

        public override Task Validate(ToDoItem entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Title))
            {
                throw new ArgumentException("Title must not be empty");
            }

            if (entity.ToDoListId == default)
            {
                throw new ArgumentException("ToDoListId must not be default");
            }

            return Task.CompletedTask;
        }
    }
}
