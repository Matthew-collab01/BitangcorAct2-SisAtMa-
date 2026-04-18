using attedanceModels;
using attendanceDataService;
using System.Security.Principal;

namespace attendanceAppService {

    public class attBL {

        AttendanceMediator attdataserve = new AttendanceMediator(new AttendanceJsonData());
       
        public void UpdateStudent(Guid studentId, string newName, int newPre, int newAbs) {

            attModels updData = new attModels
            { 
                ident = studentId,
                studname = newName,
                Present = newPre,
                Absent = newAbs,
                TotalDays = newPre + newAbs
            };

            attdataserve.UpdateAttendance(updData);
        }

        public void DeleteStudent(Guid StudentID) {

            attdataserve.RemoveAttendance(StudentID);
        }

        public void inplist(string Sname, int Pre, int Abs) {
            attModels transmod = new attModels
            {
                ident = Guid.NewGuid(),
                studname = Sname,
                Present = Pre,
                Absent = Abs,
                TotalDays = Pre + Abs
            };

            attdataserve.AddAttendance(transmod);
        }

        public List<attModels> GetAllAttendances()
        {
            return attdataserve.Setlist();
        }

        public List<attModels> Setlist(){

            return attdataserve.Setlist();
        }

    }
}
