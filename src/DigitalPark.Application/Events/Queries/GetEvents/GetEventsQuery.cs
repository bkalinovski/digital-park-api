using AutoMapper;
using DigitalPark.Application.Common.Extensions;
using DigitalPark.Application.Common.Interfaces;
using DigitalPark.Application.Common.Models;
using DigitalPark.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DigitalPark.Application.Events.Queries.GetEvents;

public class GetEventsQuery : PagedRequest, IRequest<PagedResult<EventDto>>
{
    public GetEventsQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
    
    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, PagedResult<EventDto>>
    {
        private readonly IDigitalParkDbContext _context;
        private readonly IMapper _mapper;

        public GetEventsQueryHandler(IDigitalParkDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedResult<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            var events = await _context.Events
                                       .Include(t => t.Location)
                                       .OrderByDescending(t => t.Date)
                                       .AsNoTracking()
                                       .ToPagedResultAsync<Event, EventDto>(
                                           request.PageNumber, request.PageSize,
                                           _mapper.ConfigurationProvider, cancellationToken);

            return events;
        }
    }
}