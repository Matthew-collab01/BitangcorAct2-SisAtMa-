using attedanceModels;

using System;
using System.Collections.Generic;
using System.Text;

namespace attendanceDataService
{
    public interface ISystemDataServices
    {
        void AddAttendance(attModels att);
        void UpdateAttendance(attModels att);
        void RemoveAttendance(int index);
        List<attModels> Setlist();
    }
}
