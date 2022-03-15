using System;
using System.Threading.Tasks;
using api.Models.Entities;
using api.Repositories;
using api.Repositories.Common;
using api.Repositories.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Xunit;
using static Tests.Unit.Repository.Common.RepositoryUtilities;

namespace Tests.Unit.Repository;

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
        var entity = new WeatherForecast();

        var (context, repository) = await GetRepository();

        await context.Set<WeatherForecast>().AddAsync(entity);
        await context.SaveChangesAsync();

        // Act
        var result = await repository.Get(entity.Id);

        // Assert
        Assert.NotNull(result);
    }


    [Fact]
    public async Task GetByIdThrowsWhenEntityMissing()
    {
        // Arrange
        var entity = new WeatherForecast();

        var (_, repository) = await GetRepository();

        // Act, Assert
        await Assert.ThrowsAsync<EntityNotFoundException<WeatherForecast>>(() => repository.Get(Guid.NewGuid()));
    }

    [Fact]
    public async Task CanInsert()
    {
        // Arrange
        var entity = new WeatherForecast();

        var (context, repository) = await GetRepository();

        // Act
        await repository.Insert(entity);

        // Assert
        var result = await context.Set<WeatherForecast>().FirstOrDefaultAsync(x => x.Id == entity.Id);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task CanUpdate()
    {
        // Arrange
        var entity = new WeatherForecast();

        var (context, repository) = await GetRepository();
        await context.Set<WeatherForecast>().AddAsync(entity);
        await context.SaveChangesAsync();

        entity.Summary = "summary";

        // Act
        await repository.Update(entity);

        // Assert
        var result = await context.Set<WeatherForecast>().FirstOrDefaultAsync(x => x.Id == entity.Id);

        Assert.NotNull(result);
        Assert.Equal("summary", result!.Summary);
    }


    [Fact]
    public async Task CanDelete()
    {
        // Arrange
        var entity = new WeatherForecast();

        var (context, repository) = await GetRepository();
        await context.Set<WeatherForecast>().AddAsync(entity);
        await context.SaveChangesAsync();

        // Act
        await repository.Delete(entity.Id);

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
