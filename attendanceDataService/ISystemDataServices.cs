using attedanceModels;

using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace attendanceDataService
{
    public interface ISystemDataServices
    {
        attModels? GetById(Guid ident);
        void AddAttendance(attModels att);
        void UpdateAttendance(attModels att);
        void RemoveAttendance(Guid studentId);
        List<attModels> Setlist();
    }
}
