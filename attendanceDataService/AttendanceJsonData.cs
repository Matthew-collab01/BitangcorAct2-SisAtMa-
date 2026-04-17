using attedanceModels;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Text.Json;

namespace attendanceDataService {

    public class AttendanceJsonData : ISystemDataServices {
        
        private List<attModels> attendanceList = new List<attModels>();
        private string _jsonFileName;

        public AttendanceJsonData() {

            _jsonFileName = $"{AppDomain.CurrentDomain.BaseDirectory}/AttendanceJSONdatafile.json";

            PopulateJsonFile();
        }

        private void PopulateJsonFile() {

            RetrieveDataFromJsonFile();

            if (attendanceList.Count <= 0) {

                attendanceList.Add(new attModels {ident = Guid.NewGuid(), studname = "Matt", Present = 2, Absent = 0, TotalDays = 2});

                SaveDataToJsonFile();
            }
        }

        private void SaveDataToJsonFile() {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                };

                string jsonString = JsonSerializer.Serialize(attendanceList, options);
                File.WriteAllText(_jsonFileName, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
                throw;
            }
        }

        private void RetrieveDataFromJsonFile() {
            try
            {
                if (!File.Exists(_jsonFileName))
                {
                    attendanceList = new List<attModels>();
                    return;
                }

                string jsonString = File.ReadAllText(_jsonFileName);

                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    attendanceList = new List<attModels>();
                    return;
                }

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                attendanceList = JsonSerializer.Deserialize<List<attModels>>(jsonString, options);

                if (attendanceList == null)
                {
                    attendanceList = new List<attModels>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                attendanceList = new List<attModels>();
            }
        }
        


        public void AddAttendance(attModels att) {

            RetrieveDataFromJsonFile();
            attendanceList.Add(att);
            SaveDataToJsonFile();
        }

        public void RemoveAttendance(Guid studentId) {

            RetrieveDataFromJsonFile();

            var target = attendanceList.FirstOrDefault(x => x.ident == studentId);
            if (target != null)
            {
                attendanceList.Remove(target);
                SaveDataToJsonFile();
            }

            
        }

        public List<attModels> Setlist() {

            RetrieveDataFromJsonFile();
            return attendanceList;
        }

        public void UpdateAttendance(attModels att) {

            RetrieveDataFromJsonFile();

            var existingStud = attendanceList.FirstOrDefault(x => x.ident == att.ident);
            
            if (existingStud != null) {
                existingStud.studname = att.studname;
                existingStud.Present = att.Present;
                existingStud.Absent = att.Absent;
                existingStud.TotalDays = att.TotalDays;
                SaveDataToJsonFile();
            }

            
        }
    }
}
