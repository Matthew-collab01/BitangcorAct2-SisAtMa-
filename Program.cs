using attedanceModels;
using attendanceAppService;


namespace BitangcorAct2_SisAtMa_ {
    internal class Program {

        
        static attBL bl = new attBL();
        static string studname;
        static char ans;

        static void Main(string[] args) {

        ShowChoices();

            while (true) { 
            
                Console.Write("Select a number:");
                int input = Convert.ToInt32(Console.ReadLine());
                var stud = bl.Setlist();
                Console.WriteLine(" ");

                switch (input) { 

                    case 1:
                        CaseCreate();
                        break;

                    case 2:
                        CaseUpdate();
                        break;

                    case 3:
                        CaseDelete();
                        break;

                    case 4:
                        CaseReview();
                        break;

                    case 5:
                        CaseSummary();
                        break;


                    case 6:
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select 1-5! ");
                        break;
                }
            }
        }

        static void ShowChoices(){
            Console.WriteLine("*-----Attendance Management (PUPSIS)-----*");
            Console.WriteLine(" ");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1.) Create Student Attendance");
            Console.WriteLine("2.) Update Student Attendance");
            Console.WriteLine("3.) Delete Student Attendance");
            Console.WriteLine("4.) Show List of Student Attendance");
            Console.WriteLine("5.) Summary of Student Attendance");
            Console.WriteLine("6.) Exit");
            Console.WriteLine(" ");
        }

        static void CaseCreate() {
            do {
                Console.Write("Enter Student Name: ");
                studname = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(studname)) {
                    Console.WriteLine("Please input a valid name.");
                    Console.WriteLine();
                    continue;
                }
                Console.Write("Enter Numbers of Days Present: ");
                int presInput = Convert.ToInt32(Console.ReadLine());

                if (presInput < 0) {
                    Console.WriteLine("Invalid input. Please enter a number!");
                    Console.WriteLine();
                    continue;
                }
                Console.Write("Enter Numbers of Days Absent: ");
                int absInput = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                if (absInput < 0) {
                    Console.WriteLine("Invalid input. Please enter a number!");
                    Console.WriteLine();
                    continue;
                }
                bl.inplist(studname, presInput, absInput);

                Console.WriteLine("Student has been recorded successfully!");
                Console.WriteLine();

                Console.Write("Do you want to add another student? (Y/N): ");
                ans = Console.ReadKey().KeyChar;
                ans = char.ToUpper(ans);
                Console.WriteLine();
                Console.WriteLine();

            } while (ans == 'Y');
                Console.Write("Do you want another transaction? (Y/N): ");
                ans = Console.ReadKey().KeyChar;
                ans = char.ToUpper(ans);
                Console.WriteLine();
                Console.WriteLine();

                if (ans != 'Y') {
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
            }
        }

        static void CaseUpdate() {
            var stud = bl.Setlist();
                Console.WriteLine("*---Update Student Attendance---*");
                Console.WriteLine();

                if (stud.Count == 0) {
                    Console.WriteLine("No students recorded yet.");
                    Console.WriteLine();
                }
                Console.WriteLine("Current students:");
                for (int i = 0; i < stud.Count; i++) {
                    Console.WriteLine($"{i + 1}. {stud[i].studname} - " +
                                    $"Present: {stud[i].Present}, " +
                                    $"Absent: {stud[i].Absent}");
                }
                Console.WriteLine();
                Console.Write("Enter the number of the student to update: ");
                int inp1 = Convert.ToInt32(Console.ReadLine());

                if (inp1 < 1 || inp1 > stud.Count) {
                    Console.WriteLine("Invalid input. Student not found.");
                    Console.WriteLine();
                }
            Guid selectedStudID = stud[inp1 - 1].ident;

            Console.WriteLine();
            Console.WriteLine($"Updating student: {stud[inp1 - 1].studname}");
            Console.WriteLine();

                Console.Write("Enter updated Student Name: ");
                string newname = Console.ReadLine();

                Console.Write("Enter updated Number of Days Present: ");
                int newpresInput = Convert.ToInt32(Console.ReadLine());

                if (newpresInput < 0) {
                    Console.WriteLine("Invalid input. Please enter a valid number!");
                    Console.WriteLine();
                }
                Console.Write("Enter updated Number of Days Absent: ");
                int newabsInput = Convert.ToInt32(Console.ReadLine());

                if (newabsInput < 0) {
                    Console.WriteLine("Invalid input. Please enter a valid number!");
                    Console.WriteLine();
                }
            bl.UpdateStudent(selectedStudID, newname, newpresInput, newabsInput);

                Console.WriteLine($"Student '{newname}' has been updated.");
                Console.WriteLine();

                Console.Write("Do you want another transaction? (Y/N): ");
                ans = Console.ReadKey().KeyChar;
                ans = char.ToUpper(ans);
                Console.WriteLine();
                Console.WriteLine();

                if (ans != 'Y') {
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
            }
        }


        static void CaseDelete(){
            do {
                var stud = bl.Setlist();

                Console.WriteLine("*---Delete Student Attendance---*");
                 Console.WriteLine();

                    if (stud.Count == 0) {
                        Console.WriteLine("No students recorded yet.");
                        Console.WriteLine();
                        Console.Write("Do you want another transaction? (Y/N): ");
                        ans = Console.ReadKey().KeyChar;
                        ans = char.ToUpper(ans);
                        Console.WriteLine();
                        Console.WriteLine();

                    if (ans != 'Y')
                    {
                        Console.WriteLine("Exiting program...");
                    }
                    continue;

                }

                Console.WriteLine("Current students:");
                    for (int i = 0; i < stud.Count; i++) {
                        Console.WriteLine($"{i + 1}. {stud[i].studname} - " +
                            $"Present: {stud[i].Present}, " +
                            $"Absent: {stud[i].Absent}");
                    }
                    Console.WriteLine();
                    Console.Write("Enter the number of the student to delete: ");
                    int inp2 = Convert.ToInt32(Console.ReadLine());

                    if (inp2 < 1 || inp2 > stud.Count) {
                        Console.WriteLine("Invalid choice. Student not found.");
                        Console.WriteLine();
                        continue;
                    }
                 attModels delname = stud[inp2 - 1];
                 bl.DeleteStudent(delname.ident);

                    Console.WriteLine($"Student '{delname.studname}' has been deleted.");
                    Console.WriteLine();
                stud = bl.Setlist();

                Console.Write("Do you want to delete another student? (Y/N): ");
                    ans = Console.ReadKey().KeyChar;
                    ans = char.ToUpper(ans);
                    Console.WriteLine();
                    Console.WriteLine();

                } while (ans == 'Y');

                    Console.Write("Do you want another transaction? (Y/N): ");
                    ans = Console.ReadKey().KeyChar;
                    ans = char.ToUpper(ans);
                    Console.WriteLine();
                    Console.WriteLine();

                    if (ans != 'Y') {
                        Console.WriteLine("Exiting program...");
                        Environment.Exit(0);
                    }
        }

        static void CaseSummary() {
            var stud = bl.Setlist();
            Console.WriteLine("*---Attendance Summary---*");
            Console.WriteLine();

                if (stud.Count == 0) {
                    Console.WriteLine("No students recorded yet.");
                    Console.WriteLine();
                    return;
                }

            int totalStudents = stud.Count;
            int totalPresentDays = 0;
            int totalAbsentDays = 0;

                foreach (var student in stud) {
                    totalPresentDays += student.Present;
                    totalAbsentDays += student.Absent;
                }

            int totalOverallDays = totalPresentDays + totalAbsentDays;

            double attendanceRate = 0.0;
            
                if (totalOverallDays > 0) {
                    attendanceRate = (double)totalPresentDays / totalOverallDays * 100.0;
                }

            Console.WriteLine($"Total number of students: {totalStudents}");
            Console.WriteLine($"Total present days: {totalPresentDays}");
            Console.WriteLine($"Total absent days: {totalAbsentDays}");
            Console.WriteLine();
            Console.WriteLine($"Average attendance rate: {attendanceRate:F1}%");

            Console.WriteLine();
            Console.Write("Do you want another transaction? (Y/N): ");
            ans = Console.ReadKey().KeyChar;
            ans = char.ToUpper(ans);
            Console.WriteLine();
            Console.WriteLine();

                if (ans != 'Y') {
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                }
        }

        static void CaseReview(){
            var stud = bl.Setlist();
                Console.WriteLine("*---List of the Attendance---*");
                Console.WriteLine();

                foreach (var student in stud) {
                    Console.WriteLine($"" +
                    $"Name: {student.studname} " +
                    $"Presents: {student.Present}, " +
                    $"Absents: {student.Absent}, " +
                    $"Total Days: {student.TotalDays}");
                }

                Console.WriteLine();
                Console.Write("Do you want another transaction? (Y/N): ");
                ans = Console.ReadKey().KeyChar;
                ans = char.ToUpper(ans);
                Console.WriteLine();
                Console.WriteLine();

                if (ans != 'Y') {
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                }
        } 

        
    }
}