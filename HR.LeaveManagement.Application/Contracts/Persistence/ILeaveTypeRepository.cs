using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {
        Task<bool> IsLeaveTypeUnique(string LeaveTypeName);
        Task<bool> IsLeaveTypeUniqueUpdate(string LeaveTypeName, int Id);
    }
}