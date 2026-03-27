using attedanceModels;
using attendanceDataService;
using System.Security.Principal;

namespace attendanceAppService
{
    public class attBL
    {
        attDL attdataserve = new attDL();
        public void inplist(string Sname, int Pre, int Abs)
        {

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
