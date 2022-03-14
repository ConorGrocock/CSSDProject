using System;
using System.Threading.Tasks;
using api.Models.Entities;
using api.Repositories;
using api.Repositories.Common;
using api.Repositories.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Xunit;
using static UnitTest.Repository.Common.RepositoryUtilities;

namespace UnitTest.Repository;

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
        var entityId = Guid.NewGuid();
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
        var entityId = Guid.NewGuid();
        var entity = new WeatherForecast { Id = entityId };

        var (_, repository) = await GetRepository();

        // Act, Assert
        await Assert.ThrowsAsync<EntityNotFoundException<WeatherForecast>>(() => repository.Get(entityId));
    }

    [Fact]
    public async Task CanInsert()
    {
        // Arrange
        var entityId = Guid.NewGuid();
        var entity = new WeatherForecast { Id = entityId };

        var (context, repository) = await GetRepository();

        // Act
        await repository.Insert(entity);

        // Assert
        var result = await context.Set<WeatherForecast>().FirstOrDefaultAsync(x => x.Id == entityId);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task CanUpdate()
    {
        // Arrange
        var entityId = Guid.NewGuid();
        var entity = new WeatherForecast { Id = entityId };

        var (context, repository) = await GetRepository();
        await context.Set<WeatherForecast>().AddAsync(entity);
        await context.SaveChangesAsync();

        entity.Summary = "summary";

        // Act
        await repository.Update(entity);

        // Assert
        var result = await context.Set<WeatherForecast>().FirstOrDefaultAsync(x => x.Id == entityId);

        Assert.NotNull(result);
        Assert.Equal("summary", result!.Summary);
    }


    [Fact]
    public async Task CanDelete()
    {
        // Arrange
        var entityId = Guid.NewGuid();
        var entity = new WeatherForecast { Id = entityId };

        var (context, repository) = await GetRepository();
        await context.Set<WeatherForecast>().AddAsync(entity);
        await context.SaveChangesAsync();

        // Act
        await repository.Delete(entityId);

        // Assert
        var result = await context.Set<WeatherForecast>().ToListAsync();

        Assert.Empty(result);
    }

    private static async Task<(NorTollDbContext, BaseRepository<WeatherForecast>)> GetRepository()
    {
        var context = await GetContext();

        return (context, new BaseRepository<WeatherForecast>(context));
    }
}
