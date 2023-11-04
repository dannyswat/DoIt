using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoIt.Core.Repositories;
using DoIt.Core.ToDos;

namespace DoIt.Core.Test;

public class ToDoListModelTest
{
    [Fact]
    public async Task AddList()
    {
        var repository = new Mock<IRepository<ToDoList>>();
        var model = new ToDoListModel(repository.Object);

        var list = new ToDoList
        {
            Title = "Test",
            Description = "Testing"
        };

        repository.Setup(r => r.AddAsync(list))
            .Callback<ToDoList>(l => l.Id = 1);

        await model.Add(list);

        Assert.NotEqual(default, list.Id);
        repository.Verify(r => r.AddAsync(list), Times.Once);
    }

    [Fact]
    public async Task UpdateList()
    {
        var repository = new Mock<IRepository<ToDoList>>();
        var model = new ToDoListModel(repository.Object);

        var list = new ToDoList
        {
            Id = 1,
            Title = "Test",
            Description = "Testing"
        };

        repository.Setup(r => r.GetByIdAsync(list.Id))
            .ReturnsAsync(new ToDoList
            {
                Id = 1,
                Title = "Test Hello",
                Description = "Testing"
            });

        await model.Update(list);

        repository.Verify(r => r.UpdateAsync(list), Times.Once);
    }

    [Fact]
    public async Task DeleteList()
    {
        var repository = new Mock<IRepository<ToDoList>>();
        var model = new ToDoListModel(repository.Object);

        repository.Setup(r => r.GetByIdAsync(1))
            .ReturnsAsync(new ToDoList
            {
                Id = 1,
                Title = "Test Hello",
                Description = "Testing"
            });

        var list = await model.Delete(1);

        repository.Verify(r => r.DeleteAsync(list), Times.Once);
    }
}
