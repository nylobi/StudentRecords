using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentObjects
{
    class Program
    {
        static List<Student> records = new List<Student>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Student Records");
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("1 - Read File");
                Console.WriteLine("2 - Find Student by index No.");
                Console.WriteLine("3 - Find First Match");
                Console.WriteLine("4 - List all student records.");
                Console.WriteLine("5 - Search student by student number.");
                Console.WriteLine("6 - Search student by Grade");
                Console.WriteLine("9 - Quit");
                Console.Write("Select an option: ");
                char menuChoice = Console.ReadLine().ToCharArray()[0];
                Console.WriteLine();
                switch (menuChoice)
                {
                    case '1':
                        ReadInFile();
                        break;
                    case '2':
                        FindRecordByIndex();
                        break;
                    case '3':
                        FindFirstMatch();
                        break;
                    case '4':
                        ListAllRecords();
                        break;
                    case '9':
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid menu choice");
                        break;
                }
            }
       
        }
        static void ReadInFile()
        {
            Console.Write("Enter FileName: ");
            string fileName = Console.ReadLine() + ".txt";
            try
            {
                ReadFileIntoRecordsArray(fileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File does not exist");
            }
        }

        static void FindRecordByIndex()
        {
            Console.Write("Enter Index No. :");
            try
            {
                int index = Convert.ToInt32(Console.ReadLine());
                WriteRecordToConsole(records[index]);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Not a valid index");
            }
            catch (FormatException)
            {
                Console.WriteLine("Not a number");
            }
        }

        static void FindFirstMatch()
        {
            Console.Write("Enter a search string: ");
            string searchString = Console.ReadLine();
            var record = FindFirstMatch(searchString);
            WriteRecordToConsole(record);
        }

        static string FindFirstMatch(string searchString)
        {
            return records.Where(r => r.Contains(searchString)).First();
        }

        static void ReadFileIntoRecordsArray(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                int i = 0;
                while (!reader.EndOfStream)
                {
                    var record = reader.ReadLine();
                    var elements = record.Split(',');

                    int Number = Convert.ToInt32(elements[0]);
                    string FirstName = Convert.ToString(elements[1]);
                    string LastName = Convert.ToString(elements[2]);
                    DateTime DateOfBirth = Convert.ToDateTime(elements[3]);
                    char Grade = Convert.ToChar(elements[4]);

                    Student s = new Student(Number, FirstName, LastName, DateOfBirth, Grade);

                    i++;
                }
            }
        }

        static void WriteRecordToConsole(string record)
        {
            var formatted = record.Replace(",", "\t");
            Console.WriteLine(formatted);
        }

        static void ListAllRecords()
        {

            foreach (var record in records)
            {
                WriteRecordToConsole(record);
            }
        }
    }
}
