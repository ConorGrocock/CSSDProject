using System;
using System.Threading.Tasks;
using api.Models.Common;
using api.Repositories;
using api.Repositories.Common;
using api.Repositories.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Tests.Unit.Repository.Common;

public static class RepositoryUtilities
{
    public static async Task<NorTollDbContext> GetContext()
    {
        var options = new DbContextOptionsBuilder<NorTollDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new NorTollDbContext(options);

        await context.Database.EnsureDeletedAsync();

        return context;
    }
}