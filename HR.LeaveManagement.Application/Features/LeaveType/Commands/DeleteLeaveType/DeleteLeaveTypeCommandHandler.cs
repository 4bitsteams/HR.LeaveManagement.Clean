using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Convert to domain entity object
            var leaveTypeDelete = await this._leaveTypeRepository.GetByIdAsync(request.Id);
            //verify record exist
            //Delete to Database
            await this._leaveTypeRepository.DeleteAsync(leaveTypeDelete);
            //return record Id
            return Unit.Value;
        }
    }
}
