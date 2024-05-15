using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveAllocations;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Queries.GetAllLeaveAllocations
{
    public class GetLeaveAllocationssQueryHandler : IRequestHandler<GetLeaveAllocationsQuery, List<LeaveAllocationDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationsRepository;
        private readonly IAppLogger<GetLeaveAllocationssQueryHandler> _logger;

        public GetLeaveAllocationssQueryHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationsRepository, IAppLogger<GetLeaveAllocationssQueryHandler> logger)
        {
            this._mapper = mapper;
            this._leaveAllocationsRepository = leaveAllocationsRepository;
            this._logger = logger;
        }
        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Leave Allocations were retrieved successfully");
            return _mapper.Map<List<LeaveAllocationDto>>(await _leaveAllocationsRepository.GetAsync());
        }
    }
}
