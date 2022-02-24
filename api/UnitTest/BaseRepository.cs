using System.Threading.Tasks;
using api.Models;
using api.Repositories;
using api.Repositories.Common;
using api.Repositories.Common.Exceptions;
using api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace UnitTest;

public class BaseRepositoryTests
{
    [Fact]
    public async Task CanGetAll()
    {
        // Arrange
        var entity1 = new WeatherForecast();
        var entity2 = new WeatherForecast();

        var (context, repository) = await GetRepository();

        await context.Set<WeatherForecast>().AddRangeAsync(entity1, entity2);
        await context.SaveChangesAsync();

        // Act
        var result = await (await repository.GetAll()).ToListAsync();

        // Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task CanGetById()
    {
        // Arrange
        var entityId = 123;
        var entity = new WeatherForecast { Id = entityId };

        var (context, repository) = await GetRepository();

        await context.Set<WeatherForecast>().AddAsync(entity);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.Get(entityId);

        // Assert
        Assert.NotNull(result);
    }


    [Fact]
    public async Task GetByIdThrowsWhenEntityMissing()
    {
        // Arrange
        var entityId = 123;
        var entity = new WeatherForecast { Id = entityId };

        var (context, repository) = await GetRepository();

        await context.Set<WeatherForecast>().AddAsync(entity);
        await context.SaveChangesAsync();

        // Act, Assert
        await Assert.ThrowsAsync<EntityNotFoundException<WeatherForecast>>(() => repository.Get(0));
    }

    [Fact]
    public async Task CanInsert()
    {
        // Arrange
        var entityId = 123;
        var entity = new WeatherForecast { Id = entityId };

        var (context, repository) = await GetRepository();

        // Act
        await repository.Insert(entity);
        await repository.Save();

        // Assert
        var result = await context.Set<WeatherForecast>().FirstOrDefaultAsync(x => x.Id == entityId);

        Assert.NotNull(result);
    }


    [Fact]
    public async Task CanUpdate()
    {
        // Arrange
        var entityId = 123;
        var entity = new WeatherForecast { Id = entityId };

        var (context, repository) = await GetRepository();
        await context.Set<WeatherForecast>().AddAsync(entity);
        await context.SaveChangesAsync();

        entity.Summary = "summary";

        // Act
        await repository.Update(entity);
        await repository.Save();

        // Assert
        var result = await context.Set<WeatherForecast>().FirstOrDefaultAsync(x => x.Id == entityId);

        Assert.NotNull(result);
        Assert.Equal("summary", result!.Summary);
    }


    [Fact]
    public async Task CanDelete()
    {
        // Arrange
        var entityId = 123;
        var entity = new WeatherForecast { Id = entityId };

        var (context, repository) = await GetRepository();
        await context.Set<WeatherForecast>().AddAsync(entity);
        await context.SaveChangesAsync();

        // Act
        await repository.Delete(entityId);
        await repository.Save();


        // Assert
        var result = await context.Set<WeatherForecast>().ToListAsync();

        Assert.Equal(0, result.Count);
    }

    private async Task<(NorTollDbContext, IBaseRepository<WeatherForecast>)> GetRepository()
    {
        var options = new DbContextOptionsBuilder<NorTollDbContext>().UseInMemoryDatabase("BaseRepositoryUnitTests").Options;

        var context = new NorTollDbContext(options);

        // clear previous testing datacontext
        context.Set<WeatherForecast>().RemoveRange(await context.Set<WeatherForecast>().ToArrayAsync());

        return (context, new BaseRepository<WeatherForecast>(context));
    }
}
