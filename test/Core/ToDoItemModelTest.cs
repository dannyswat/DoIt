using DoIt.Core.Repositories;
using DoIt.Core.ToDos;

namespace DoIt.Core.Test;

public class ToDoItemModelTest
{
    [Fact]
    public async Task AddItem()
    {
        // Arrange
        var repository = new Mock<IRepository<ToDoItem>>();
        var model = new ToDoItemModel(repository.Object);
        var item = new ToDoItem
        {
            Title = "Test",
            ToDoListId = 1
        };

        // Act
        await model.Add(item);

        // Assert
        repository.Verify(r => r.AddAsync(item), Times.Once);
    }

    [Fact]
    public async Task UpdateItem()
    {
        // Arrange
        var repository = new Mock<IRepository<ToDoItem>>();
        var model = new ToDoItemModel(repository.Object);
        var item = new ToDoItem
        {
            Id = 1,
            Title = "Test",
            ToDoListId = 1
        };

        repository.Setup(r => r.GetByIdAsync(item.Id))
        .ReturnsAsync(new ToDoItem {
            Id = 1,
            Title = "Test Hello",
            ToDoListId = 1
        });

        // Act
        await model.Update(item);

        // Assert
        repository.Verify(r => r.UpdateAsync(item), Times.Once);
    }

    [Fact]
    public async Task DeleteItem()
    {
        // Arrange
        var repository = new Mock<IRepository<ToDoItem>>();
        var model = new ToDoItemModel(repository.Object);

        repository.Setup(r => r.GetByIdAsync(1))
        .ReturnsAsync(new ToDoItem
        {
            Id = 1,
            Title = "Test Hello",
            ToDoListId = 1
        });

        // Act
        var item = await model.Delete(1);

        // Assert
        repository.Verify(r => r.DeleteAsync(item), Times.Once);
    }
}