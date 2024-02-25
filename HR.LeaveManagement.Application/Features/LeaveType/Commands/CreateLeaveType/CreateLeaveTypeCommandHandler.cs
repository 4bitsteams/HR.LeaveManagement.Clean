using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //validate incoming data
            var validator = new CreateLeaveTypeCommandValidator(this._leaveTypeRepository);
            var validatorResult=await validator.ValidateAsync(request);
            if (validatorResult.Errors.Any()) 
                throw new BadRequestException("Invalid LeaveType",validatorResult);
            //Convert to domain entity object
            var leaveTypeCreate = this._mapper.Map<Domain.LeaveType>(request);
            //Add to Database
            await this._leaveTypeRepository.CreateAsync(leaveTypeCreate);
            //return record Id
            return leaveTypeCreate.Id;
        }
    }
}
