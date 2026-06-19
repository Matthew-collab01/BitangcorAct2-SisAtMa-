using attedanceModels;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace attendanceDataService {
    public class AttendanceDBData : ISystemDataServices {
        private string connectionString
        = "Data Source =(localdb)\\MSSQLLocalDB; Initial Catalog = AttendanceData; Integrated Security = True; TrustServerCertificate=True;";

        private SqlConnection sqlConnection;

        public AttendanceDBData() {

            sqlConnection = new SqlConnection(connectionString);

            AddSeeds();
        }

        private void AddSeeds() {

            var existing = Setlist();

            if (existing.Count == 0) {
                attModels BaseData = new attModels { ident = Guid.NewGuid(), studname = "Matt", Present = 2, Absent = 2, TotalDays = 4 };

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

        public void RemoveAttendance(Guid studentId) {

            string delStatement = "DELETE FROM TB_AttendanceDATA WHERE identityID = @identityID";

            using (SqlCommand deleteCommand = new SqlCommand(delStatement, sqlConnection))
            {
                deleteCommand.Parameters.AddWithValue("@identityID", studentId);

                sqlConnection.Open();
                deleteCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public void UpdateAttendance(attModels att)
        {

            string updateStatement =
        "UPDATE TB_AttendanceDATA " +
        "SET student_name = @student_name, " +
        "    PresentDays = @PresentDays, " +
        "    AbsentDays = @AbsentDays, " +
        "    TotalDays = @TotalDays " +
        "WHERE identityID = @identityID";
            Console.WriteLine("SQL UPDATE = " + updateStatement);

            using (SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection))
            {
                updateCommand.Parameters.AddWithValue("@identityID", att.ident);
                updateCommand.Parameters.AddWithValue("@student_name", att.studname);
                updateCommand.Parameters.AddWithValue("@PresentDays", att.Present);
                updateCommand.Parameters.AddWithValue("@AbsentDays", att.Absent);
                updateCommand.Parameters.AddWithValue("@TotalDays", att.TotalDays);

                sqlConnection.Open();
                updateCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        public attModels GetById(Guid ident)
        {
            var selectStatement = @"SELECT identityID, student_name, PresentDays, AbsentDays, TotalDays
                             FROM [AttendanceData].[dbo].[TB_AttendanceDATA]
                             WHERE identityID = @identityID";

            attModels mod = null;

            using (SqlConnection conn = new SqlConnection(sqlConnection.ConnectionString))
            using (SqlCommand selectCommand = new SqlCommand(selectStatement, conn))
            {
                selectCommand.Parameters.AddWithValue("@identityID", ident);

                conn.Open();

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        mod = new attModels
                        {
                            ident = Guid.Parse(reader["identityID"].ToString()),
                            studname = reader["student_name"].ToString(),
                            Present = Convert.ToInt32(reader["PresentDays"]),
                            Absent = Convert.ToInt32(reader["AbsentDays"]),
                            TotalDays = Convert.ToInt32(reader["TotalDays"])
                        };
                    }
                }
            }

            return mod;
        }


    }
    
}
