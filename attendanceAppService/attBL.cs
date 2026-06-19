using attedanceModels;
using attendanceDataService;

namespace attendanceAppService
{
    public class attBL
    {
        AttendanceMediator attdataserve = new AttendanceMediator(new AttendanceDBData());

        public void inplist(string Sname, int Pre, int Abs)
        {
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

        public List<attModels> Setlist()
        {
            return attdataserve.Setlist();
        }

        public void UpdateStudent(Guid studentId, string newName, int newPre, int newAbs)
        {
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

        public void DeleteStudent(Guid StudentID)
        {
            attdataserve.RemoveAttendance(StudentID);
        }

        public List<attModels> GetAllAttendances()
        {
            return attdataserve.Setlist();
        }

        public attModels? GetAttendance(Guid ident)
        {
            return attdataserve.GetById(ident);
        }

        public attModels AddStudent(string studname, int present, int absent)
        {
            attModels newRecord = new attModels
            {
                ident = Guid.NewGuid(),
                studname = studname,
                Present = present,
                Absent = absent,
                TotalDays = present + absent
            };
            attdataserve.AddAttendance(newRecord);
            return newRecord;
        }

        public bool UpdateStudentById(Guid ident, string newName, int newPre, int newAbs)
        {
            var existing = attdataserve.GetById(ident);
            if (existing == null) return false;

            attModels updated = new attModels
            {
                ident = ident,
                studname = newName,
                Present = newPre,
                Absent = newAbs,
                TotalDays = newPre + newAbs
            };
            attdataserve.UpdateAttendance(updated);
            return true;
        }

        public bool DeleteStudentById(Guid ident)
        {
            var existing = attdataserve.GetById(ident);
            if (existing == null) return false;

            attdataserve.RemoveAttendance(ident);
            return true;
        }
    }
}