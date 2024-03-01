using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Domain;

public class LeaveAllocation : BaseEntity
{
    public int NumberofDays { get; set; }

    public LeaveType? LeaveType { get; set; }

    public string EmployeeId { get; set; } = string.Empty;
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}
