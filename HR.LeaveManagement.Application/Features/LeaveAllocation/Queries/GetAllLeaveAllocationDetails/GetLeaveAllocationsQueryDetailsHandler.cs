using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveAllocationDetails.Queries.GetAllLeaveAllocationDetails;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Queries.GetAllLeaveAllocationDetails
{
    public class GetLeaveAllocationQueryDetailsHandler : IRequestHandler<GetLeaveAllocationDetailQuery, List<LeaveAllocationDetailsDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationsRepository;
        private readonly IAppLogger<GetLeaveAllocationQueryDetailsHandler> _logger;

        public GetLeaveAllocationQueryDetailsHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationsRepository, IAppLogger<GetLeaveAllocationQueryDetailsHandler> logger)
        {
            this._mapper = mapper;
            this._leaveAllocationsRepository = leaveAllocationsRepository;
            this._logger = logger;
        }
        public async Task<List<LeaveAllocationDetailsDto>> Handle(GetLeaveAllocationDetailQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Leave Allocation Details were retrieved successfully");
            return _mapper.Map<List<LeaveAllocationDetailsDto>>(await _leaveAllocationsRepository.GetAsync());
        }
    }
}
