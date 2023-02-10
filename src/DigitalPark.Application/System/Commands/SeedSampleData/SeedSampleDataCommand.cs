using DigitalPark.Application.Common.Interfaces;
using MediatR;

namespace DigitalPark.Application.System.Commands.SeedSampleData;

public class SeedSampleDataCommand : IRequest
{
    public class SeedSampleDataCommandHandler : IRequestHandler<SeedSampleDataCommand>
    {
        private readonly IDigitalParkDbContext _context;

        public SeedSampleDataCommandHandler(IDigitalParkDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SeedSampleDataCommand request, CancellationToken cancellationToken)
        {
            var seeder = new SampleDataSeeder(_context);

            await seeder.SeedAllAsync(cancellationToken);

            return Unit.Value;
        }
    }
}