using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsLeaveTypeUnique(string LeaveTypeName)
        {
            return await _context.LeaveTypes.AnyAsync(x => x.Name == LeaveTypeName);
        }

        public async Task<bool> IsLeaveTypeUniqueUpdate(string LeaveTypeName,int Id)
        {
            return await _context.LeaveTypes.AnyAsync(x => x.Name == LeaveTypeName && x.Id!=Id);
        }
    }
}
