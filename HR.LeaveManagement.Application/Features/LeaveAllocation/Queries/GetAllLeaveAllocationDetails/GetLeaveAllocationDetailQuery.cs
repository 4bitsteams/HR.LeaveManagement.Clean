using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocationDetails.Queries.GetAllLeaveAllocationDetails
{
    public record GetLeaveAllocationDetailQuery : IRequest<List<LeaveAllocationDetailsDto>>;
}
