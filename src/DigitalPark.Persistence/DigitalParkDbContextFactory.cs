using Microsoft.EntityFrameworkCore;

namespace DigitalPark.Persistence;

public class DigitalParkDbContextFactory : DesignTimeDbContextFactoryBase<DigitalParkDbContext>
{
    protected override DigitalParkDbContext CreateNewInstance(DbContextOptions<DigitalParkDbContext> options)
    {
        return new DigitalParkDbContext(options);
    }
}