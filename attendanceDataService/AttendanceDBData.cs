using attedanceModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace attendanceDataService {
    public class AttendanceDBData : ISystemDataServices {
        private string connectionString
        = "Data Source =localhost\\SQLEXPRESS01; Initial Catalog = AttendanceData; Integrated Security = True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public AttendanceDBData() {

            sqlConnection = new SqlConnection(connectionString);

            AddSeeds();
        }

        private void AddSeeds() {

            var existing = Setlist();

            if (existing.Count == 0)
            {
                attModels BaseData = new attModels { ident = Guid.NewGuid(), studname = "Matti", Present = 20, Absent = 20, TotalDays = 40 };

                AddAttendance(BaseData);
                
            }
        }

        public void AddAttendance(attModels attdata) {

            var insertStatement = "INSERT INTO TB_AttendanceDATA VALUES (@identityID, @student_name, @PresentDays, @AbsentDays, @TotalDays)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@identityID", attdata.ident);
            insertCommand.Parameters.AddWithValue("@student_name", attdata.studname);
            insertCommand.Parameters.AddWithValue("@PresentDays", attdata.Present);
            insertCommand.Parameters.AddWithValue("@AbsentDays", attdata.Absent);
            insertCommand.Parameters.AddWithValue("@TotalDays", attdata.TotalDays);
            sqlConnection.Open();

            insertCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<attModels> Setlist() {

            string selectStatement = "SELECT identityID, student_name, PresentDays, AbsentDays, TotalDays FROM TB_AttendanceDATA";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();

            SqlDataReader reader = selectCommand.ExecuteReader();

            var attendance = new List<attModels>();

            while (reader.Read()) {

                attModels attDatas = new attModels();
                attDatas.ident = Guid.Parse(reader["identityID"].ToString());
                attDatas.studname = reader["student_name"].ToString();
                attDatas.Present = int.Parse(reader["PresentDays"].ToString());
                attDatas.Absent = int.Parse(reader["AbsentDays"].ToString());
                attDatas.TotalDays = int.Parse(reader["TotalDays"].ToString());

                attendance.Add(attDatas);
            }

            sqlConnection.Close();
            return attendance;
        }


        public void RemoveAttendance(int index) {

            throw new NotImplementedException();
        }

        public void UpdateAttendance(attModels att) {

            throw new NotImplementedException();
        }
    }
}
