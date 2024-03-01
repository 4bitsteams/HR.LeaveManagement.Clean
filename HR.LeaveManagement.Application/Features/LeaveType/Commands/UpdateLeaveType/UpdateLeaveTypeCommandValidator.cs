using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandValidator : AbstractValidator<UpdateLeaveTypeCommand>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public UpdateLeaveTypeCommandValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(v => v.Id)
                .NotNull()
                .MustAsync(LeaveTypeMustExist)
                .WithMessage("Value Not Exist");

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} must be fewer then 70 characters");

            RuleFor(v => v.DefaultDays)
                .GreaterThan(100).WithMessage("{PropertyName} cannot exceed 100")
                .LessThan(1).WithMessage("{PropertyName} cannot be less then 1");

            RuleFor(v => v)
                .MustAsync(LeaveTypeNameUnique)
                .WithMessage("Leave Type already exists");
            this._leaveTypeRepository = leaveTypeRepository;
        }

        private async Task<bool> LeaveTypeMustExist(int id, CancellationToken token)
        {
            var leaveType = await this._leaveTypeRepository.GetByIdAsync(id);
            return leaveType != null;
        }

        private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
        {
            return await this._leaveTypeRepository.IsLeaveTypeUniqueUpdate(command.Name, command.Id);
        }
    }
}
