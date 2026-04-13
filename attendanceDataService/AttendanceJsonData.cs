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

            using (var outputStream = File.OpenWrite(_jsonFileName))
            {
                JsonSerializer.Serialize<List<attModels>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    { SkipValidation = true, Indented = true })
                    , attendanceList);
            }
        }

        private void RetrieveDataFromJsonFile() {

            using (var jsonFileReader = File.OpenText(_jsonFileName)) {

                attendanceList = JsonSerializer.Deserialize<List<attModels>>
                    (jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                    { PropertyNameCaseInsensitive = true })
                    .ToList();
            }
        }


        public void AddAttendance(attModels att) {

            attendanceList.Add(att);
            SaveDataToJsonFile();
        }

        public void RemoveAttendance(int index) {

            throw new NotImplementedException();
        }

        public List<attModels> Setlist() {

            RetrieveDataFromJsonFile();
            return attendanceList;
        }

        public void UpdateAttendance(attModels att) {

            RetrieveDataFromJsonFile();

            var existingStud = attendanceList.FirstOrDefault(x => x.ident == att.ident);
            if (existingStud != null)
            {
                existingStud.studname = att.studname;
                existingStud.Present = att.Present;
                existingStud.Absent = att.Absent;
                existingStud.TotalDays = att.TotalDays;
            }

            SaveDataToJsonFile();
        }
    }
}
