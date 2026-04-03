using attedanceModels;
using attendanceAppService;
using attendanceDataService;

namespace BitangcorAct2_SisAtMa_ {
    internal class Program {

        static attDL atten = new attDL();
        static attBL bl = new attBL(atten);
        static string studname;
        static int present, absent;
        static char ans;

        static void Main(string[] args) {

            Console.WriteLine("*-----Attendance Management (PUPSIS)-----*");
            Console.WriteLine(" ");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1.) Create Student Attendance");
            Console.WriteLine("2.) Update Student Attendance");
            Console.WriteLine("3.) Delete Student Attendance");
            Console.WriteLine("4.) Show list of all Students Attendance");
            Console.WriteLine("5.) Exit");
            Console.WriteLine(" ");

            while (true) { 
            

                Console.Write("Select a number:");
                string input = Console.ReadLine();
                var stud = atten.Setlist();
                int choice;
                Console.WriteLine(" ");

                if (!int.TryParse(input, out choice)) { 
                
                    Console.WriteLine("Invalid input. Please enter a number (1 - 5).");
                    Console.WriteLine();
                    continue;
                }

                switch (choice) { 

                    case 1:

                        do {

                            Console.Write("Enter Student Name: ");
                            studname = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(studname)) {

                                Console.WriteLine("Please input a valid name.");
                                Console.WriteLine();
                                continue;
                            }

                            Console.Write("Enter Numbers of Days Present: ");
                            string presInput = Console.ReadLine();

                            if (!int.TryParse(presInput, out present) || present < 0) {

                                Console.WriteLine("Invalid input. Please enter a number!");
                                Console.WriteLine();
                                continue;
                            }

                            Console.Write("Enter Numbers of Days Absent: ");
                            string absInput = Console.ReadLine();
                            Console.WriteLine();

                            if (!int.TryParse(absInput, out absent) || absent < 0) {
                                
                                Console.WriteLine("Invalid input. Please enter a number!");
                                Console.WriteLine();
                                continue;
                            }

                            bl.inplist(studname, present, absent);

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
                            return;
                        }
                        break;


                    case 2:

                        Console.WriteLine("---Update Student Attendance---");
                        Console.WriteLine();

                        if (stud.Count == 0) {
                            Console.WriteLine("No students recorded yet.");
                            Console.WriteLine();
                            break;
                        }

                        Console.WriteLine("Current students:");
                        for (int i = 0; i < stud.Count; i++) {

                            Console.WriteLine($"{i + 1}. {stud[i].studname} - " +
                                $"Present: {stud[i].Present}, " +
                                $"Absent: {stud[i].Absent}");
                        }
                        Console.WriteLine();

                        Console.Write("Enter the number of the student to update: ");
                        string inp1 = Console.ReadLine();
                        int cho1;

                        if (string.IsNullOrEmpty(inp1)) {

                            Console.WriteLine("Please enter a valid number.");
                            Console.WriteLine();
                            break;
                        }

                        if (!int.TryParse(inp1, out cho1) || cho1 < 1 || cho1 > stud.Count) {

                            Console.WriteLine("Invalid choice. Student not found.");
                            Console.WriteLine();
                            break;
                        }

                        Console.WriteLine();
                        Console.WriteLine($"Updating student: {stud[cho1 - 1].studname}");
                        Console.WriteLine();

                        Console.Write("Enter updated Student Name: ");
                        string newname = Console.ReadLine();

                        Console.Write("Enter updated Number of Days Present: ");
                        string newpresInput = Console.ReadLine();

                        if (!int.TryParse(newpresInput, out int newPres) || newPres < 0) {

                            Console.WriteLine("Invalid input. Please enter a valid number!");
                            Console.WriteLine();
                            break;
                        }

                        Console.Write("Enter updated Number of Days Absent: ");
                        string newabsInput = Console.ReadLine();

                        if (!int.TryParse(newabsInput, out int newAbs) || newAbs < 0) {

                            Console.WriteLine("Invalid input. Please enter a valid number!");
                            Console.WriteLine();
                            break;
                        }

                        bl.UpdateStudent(cho1 - 1, newname, newPres, newAbs);

                        Console.WriteLine($"Student '{newname}' has been updated.");
                        Console.WriteLine();

                        Console.Write("Do you want another transaction? (Y/N): ");
                        ans = Console.ReadKey().KeyChar;
                        ans = char.ToUpper(ans);
                        Console.WriteLine();
                        Console.WriteLine();

                        if (ans != 'Y') {

                            Console.WriteLine("Exiting program...");
                            return;
                        }

                        break;


                    case 3:

                        do { 

                            Console.WriteLine("*---Delete Student Attendance---*");
                            Console.WriteLine();

                            if (stud.Count == 0) {

                                Console.WriteLine("No students recorded yet.");
                                Console.WriteLine();
                                break;
                            }

                            Console.WriteLine("Current students:");
                            for (int i = 0; i < stud.Count; i++) {

                                Console.WriteLine($"{i + 1}. {stud[i].studname} - " +
                                    $"Present: {stud[i].Present}, " +
                                    $"Absent: {stud[i].Absent}");
                            }

                            Console.WriteLine();
                            Console.Write("Enter the number of the student to delete: ");
                            string inp2 = Console.ReadLine();

                            if (!int.TryParse(inp2, out int cho2) || cho2 < 1 || cho2 > stud.Count) {

                                Console.WriteLine("Invalid choice. Student not found.");
                                Console.WriteLine();
                                break;
                            }

                            string delname = stud[cho2 - 1].studname;
                            bl.DeleteStudent(cho2 - 1);

                            Console.WriteLine($"Student '{delname}' has been deleted.");
                            Console.WriteLine();

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
                            return;
                        }
                        break;


                    case 4:
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
                            return;
                        }

                        break;

                    case 5:
                        Console.WriteLine("Exiting program...");
                        return;


                    default:
                        Console.WriteLine("Invalid choice. Please select 1-5! ");
                        break;
                }
            }
        }
    }
}