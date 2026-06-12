using attedanceModels;
using System.Security.Principal;

namespace attendanceDataService {

    public class attDL {

            public List <attModels> Attendancelist = new List<attModels>();

        public ISystemDataServices _attDL;
        public attDL(ISystemDataServices attdataserve)
        {
            _attDL = attdataserve;
        }

        public void UpdateAttendance(int index, string newName, int newPre, int newAbs) {

            if (index >= 0 && index < Attendancelist.Count) {

                var att = Attendancelist[index];

                att.studname = newName;
                att.Present = newPre;
                att.Absent = newAbs;
                att.TotalDays = newPre + newAbs;
            }
        }

        public void AddAttendance(attModels att) {

            Attendancelist.Add(att);
        }

        public void RemoveAttendance(int index) {

            if (index >= 0 && index < Attendancelist.Count) {

                Attendancelist.RemoveAt(index);
            }
        }

        public attModels? GetById(Guid ident)
        {
            return _attDL.GetById(ident);
        }

        public List<attModels> Setlist() {

            return Attendancelist;
        }

    }
}
