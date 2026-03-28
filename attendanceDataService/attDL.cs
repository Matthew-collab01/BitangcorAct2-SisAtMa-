using attedanceModels;
using System.Security.Principal;

namespace attendanceDataService
{
    public class attDL
    {
            public List <attModels> Attendancelist = new List<attModels>();
            
        public attDL()
        {

        }

        public void AddAttendance(attModels att)
        {
            Attendancelist.Add(att);
        }

        public List<attModels> Setlist()
        {
            return Attendancelist;
        }

    }
}
