using attedanceModels;
using attendanceAppService;
using attendanceDataService;

namespace BitangcorAct2_SisAtMa_{
    internal class Program{
        static attDL atten = new attDL();
        static attBL bl = new attBL(atten);
        static string studname;
        static int present, absent;
        static char ans;
        static void Main(string[] args) { 
        

            Console.WriteLine("-----Attendance Management (PUPSIS)-----");
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
                int swi;
                Console.WriteLine(" ");

                if (!int.TryParse(input, out swi)){ 
                

                    Console.WriteLine("Invalid input. Please enter a number (1-6).");
                    Console.WriteLine();
                    continue;
                }

                switch (swi){ 

                    case 1:

                        do{ 
                        
                            Console.Write("Enter Student Name: ");
                            studname = Console.ReadLine();

                            Console.Write("Enter Numbers of Days Present: ");
                            present = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter Numbers of Days Absent: ");
                            absent = Convert.ToInt32(Console.ReadLine());

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
                        Console.WriteLine("hello");
                        break;


                    case 3:

                        do { 

                            Console.WriteLine("---Delete Student Attendance---");
                            Console.WriteLine();

                            if (stud.Count == 0){

                                Console.WriteLine("No students recorded yet.");
                                Console.WriteLine();
                                break;
                            }

                            Console.WriteLine("Current students:");
                            for (int i = 0; i < stud.Count; i++){

                                Console.WriteLine($"{i + 1}. {stud[i].studname} - Present: {stud[i].Present}, Absent: {stud[i].Absent}");
                            }

                            Console.WriteLine();
                            Console.Write("Enter the number of the student to delete (1-99): ");
                            string inp = Console.ReadLine();
                            int cho;

                            if (!int.TryParse(inp, out cho) || cho < 1 || cho > stud.Count){
                                Console.WriteLine("Invalid choice. Student not found.");
                                Console.WriteLine();
                                break;
                            }

                            string delname = stud[cho - 1].studname;
                            bl.DeleteStudent(cho - 1);

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

                        if (ans != 'Y'){
                            Console.WriteLine("Exiting program...");
                            return;
                        }
                        break;


                    case 4:
                        Console.WriteLine("---List of the Attendance---");
                        Console.WriteLine();

                        foreach (var student in stud){
                            Console.WriteLine($"Name: {student.studname} Presents: {student.Present}, Absents: {student.Absent}, Total Days: {student.TotalDays}");
                        }

                        Console.WriteLine();
                        Console.Write("Do you want another transaction? (Y/N): ");
                        ans = Console.ReadKey().KeyChar;
                        ans = char.ToUpper(ans);
                        Console.WriteLine();
                        Console.WriteLine();

                        if (ans != 'Y'){
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