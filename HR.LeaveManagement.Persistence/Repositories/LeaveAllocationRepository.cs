using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
        {
        }

        public async Task AddAllocations(List<LeaveAllocation> leaveAllocations)
        {
            await _context.AddRangeAsync(leaveAllocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int priod)
        {
            return await _context.LeaveAllocations
                .AnyAsync(x => x.EmployeeId == userId
                && x.LeaveTypeId == leaveTypeId
                && x.Period == priod);
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            return await _context.LeaveAllocations.Include(x => x.LeaveTypeId).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            return await _context.LeaveAllocations.Include(x => x.LeaveTypeId).ToListAsync();
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
        {
            return await _context.LeaveAllocations.Where(x => x.EmployeeId == userId).Include(x => x.LeaveTypeId).ToListAsync();
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            return await _context.LeaveAllocations.FirstOrDefaultAsync(x => x.EmployeeId == userId && x.LeaveTypeId == leaveTypeId);
        }
    }
}
