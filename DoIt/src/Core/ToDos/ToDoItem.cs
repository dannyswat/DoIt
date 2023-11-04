using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoIt.Core.Entities;

namespace DoIt.Core.ToDos;

public class ToDoItem : IAggregateRoot
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsDone { get; set; }

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = string.Empty;

    public DateTime UpdatedAt { get; set; }

    public string UpdatedBy { get; set; } = string.Empty;

    public byte[] RowVersion { get; set; } = Array.Empty<byte>();

    public int ToDoListId { get; set; }

    public ToDoList ToDoList { get; set; } = default!;
}