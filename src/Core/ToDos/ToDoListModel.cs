using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoIt.Core.Models;
using DoIt.Core.Repositories;

namespace DoIt.Core.ToDos;

public class ToDoListModel : CRUDModel<ToDoList, IRepository<ToDoList>>
{
    public ToDoListModel(IRepository<ToDoList> repository) : base(repository)
    {
    }

    public override Task Validate(ToDoList entity)
    {
        if (string.IsNullOrWhiteSpace(entity.Title))
        {
            throw new ArgumentException("Title must not be empty");
        }

        return Task.CompletedTask;
    }
}