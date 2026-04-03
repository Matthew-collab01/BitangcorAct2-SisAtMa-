using attedanceModels;
using attendanceDataService;
using System.Security.Principal;

namespace attendanceAppService {

    public class attBL {

        attDL attdataserve;  

        public attBL(attDL dl) {

            attdataserve = dl;
        }

        public void UpdateStudent(int index, string newName, int newPre, int newAbs) {

            attdataserve.UpdateAttendance(index, newName, newPre, newAbs);
        }

        public void DeleteStudent(int index) {

            attdataserve.RemoveAttendance(index);
        }

        public void inplist(string Sname, int Pre, int Abs) {
            attModels transmod = new attModels
            {
                studname = Sname,
                Present = Pre,
                Absent = Abs,
                TotalDays = Pre + Abs
            };

            attdataserve.AddAttendance(transmod);
        }

    

    }
}
