using attedanceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace attendanceDataService {
    public class AttendanceMediator {
        
        ISystemDataServices _attenDataService;

        public AttendanceMediator(ISystemDataServices attenDataService) {

            _attenDataService = attenDataService;
        }

        public void AddAttendance(attModels att) {

            _attenDataService.AddAttendance(att);
        }

        public void UpdateAttendance(attModels att) {

            _attenDataService.UpdateAttendance(att);
        }

        public void RemoveAttendance(Guid studentID) {

            _attenDataService.RemoveAttendance(studentID);
        }

        public List<attModels> Setlist() {

            return _attenDataService.Setlist();
        }
    }
}
