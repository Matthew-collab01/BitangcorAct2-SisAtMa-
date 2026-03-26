namespace BitangcorAct2_SisAtMa_
{
    internal class Program
    {
        static string studname;
        static int present, absent;
        static char ans;
        static void Main(string[] args)
        {
            Console.WriteLine("-----Attendance Management (PUPSIS)-----");

            Console.WriteLine("Please select an option:");
            Console.WriteLine("1.) Create Student Attendance");
            Console.WriteLine("2.) Retrieve Student Attendance");
            Console.WriteLine("3.) Update Student Attendance");
            Console.WriteLine("4.) Delete Student Attendance");
            Console.WriteLine("5.) Exit");
            Console.WriteLine(" ");
            Console.Write("Select a number:");
            int swi = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" ");

        switch (swi) {

            case 1:

              while (true)
              {
                Console.Write("Enter Student Name: ");
                studname = Console.ReadLine();
                Console.Write("Enter Numbers of Days Present: ");
                present = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Numbers of Days Absent: ");
                absent = Convert.ToInt32(Console.ReadLine());
                ;

                Console.WriteLine("Student has been recorded successfully!");

                Console.Write("do you want to add another student? (Y/N)");
                ans = Console.ReadKey().KeyChar;
                ans = char.ToUpper(ans);
                Console.WriteLine();
                if (ans != 'Y')
                {
                    break;
                }

            }
                
                case 2:

                    break;

        }
    }
}