using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace gradebook
{
    class Program
    {       
        //this is a method named Main
        //args is an array of string(s)
        //arrays are zero based so args[0] is the first 
        static void Main(string[] args)
        {            
            string input;
            bool loginState;
            char opt = 'c';
            List<Book> teachersClasses = new List<Book>();

            //welcome the user       
            if(args.Length > 0)
                Console.WriteLine($"Hello {args[0]}!");
            
            Console.WriteLine("Welcome to GradeBook!\n");

            //login 
            Console.Write("Would you like to login (enter y for yes)? ");
            input = Console.ReadLine();

            if (input.Length < 1)
            {        
                Console.WriteLine("Invalid input!");
                loginState = false;
            }
            else
            {
                if (input == "y" || input == "Y")
                    loginState = LoginPrompt(args);
                else 
                    loginState = false;
            }

            while (loginState)
            {
                Console.WriteLine(""); //to add an empty line

                opt = OptionPrompt();

                if (opt == 'x')
                    break;
                
                //blank but this is the space for switching between books based on OptionPrompt
                switch (opt)
                {
                    case 'g': 
                        LoadOrAddGradebook(ref teachersClasses);
                        break;
                    case 'a':
                        AddGradesToAGradeBookInMemory(ref teachersClasses);
                        break;
                    case 'u':
                        AddStudentToGradeBookInMemory(ref teachersClasses);
                        break;
                    case 's':
                        SeeGradesAndStats(teachersClasses);
                        break;
                    case 'v':
                        WriteDataToFile(teachersClasses);
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
            
        }

        //a is the args from the program's instantiation
        static bool LoginPrompt(string[] a)
        {
            if (a.Length == 2)
            {
                Console.WriteLine("It looks like you tried to login when you started the program.");
                Console.WriteLine("Please wait while we check your credentials!");
                    
                return LoginAuthentication(a[0], a[1]);
            }
            else
            {
                Console.WriteLine("Enter your name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter your password: ");
                string password = Console.ReadLine();

                return LoginAuthentication(name, password);
            }
        }

        static bool LoginAuthentication(string userName, string userPassword)
        {
            //only returns true for now
            //later the username and password will be checked to see if they are in the file system
            //the function will return false if they are not after this feature is implemented
            return true;
        }

        static char OptionPrompt()
        {
            Console.WriteLine("Enter 'g' to load or add to a gradebook");
            Console.WriteLine("Enter 'a' to add grades");
            Console.WriteLine("Enter 'u' to add a student");
            Console.WriteLine("Enter 's' to see grades and get statistics");
            Console.WriteLine("Enter 'v' to the gradebook save to a file");
            Console.Write("Enter 'x' to exit program ");
            return char.Parse(Console.ReadLine());
        }

        //to be implemented later as a file parser to populate the teachersClasses list object
        static void LoadOrAddGradebook(ref List<Book> tClasses)
        {
            StreamReader r = new StreamReader(@"objectStore.txt");
            string line = r.ReadLine();

            while(line != null)
            {
                //Split returns an array of type string
                int len = line.Split(", ").Length;
                string[] splitLine = line.Split(", ");
                string className = splitLine[0];
                int index = 1; //starts after class name
                string student = "";
                Book tempClass = new Book(className);

                while(index < len)
                {
                    var l = splitLine[index];

                    if(double.TryParse(l, out double d))
                    {
                        tempClass.AddGrade(student, double.Parse(l));
                    }
                    else if (l != "")
                    {
                        student = l;
                        tempClass.AddStudent(l);
                    }

                    index += 1;
                }

                tClasses.Add(tempClass);
                line = r.ReadLine();
            }

            r.Close();
        }

        static void AddGradesToAGradeBookInMemory(ref List<Book> tClasses)
        {
            string cName, sName, gradesForStudent;
            string[] grades;

            Console.Write("Enter student name: ");
            cName = Console.ReadLine();
            Console.Write("Enter student name: ");
            sName = Console.ReadLine();
            Console.Write("Enter grades for that student separated by a ',' ");
            gradesForStudent = Console.ReadLine();

            grades = gradesForStudent.Split(",");

            foreach (var grade in grades)
            {
                foreach (var member in tClasses)
                {
                    if(member.className == cName)
                    {
                        try
                        {
                            member.AddGrade( sName, double.Parse(grade));
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }    
                    }
                }
            }
        }

        static void WriteDataToFile(List<Book> tClasses)
        {
            StreamWriter w = new StreamWriter(@"objectStore.txt");
            string stringBuilder = "";

            foreach (var aClass in tClasses)
            {
                stringBuilder += aClass.StringForFile() + "\n";
            }

            w.WriteLine(stringBuilder);

            w.Close();
        }

        static void SeeGradesAndStats(List<Book> books)
        {
            foreach (var book in books)
                Console.WriteLine(book.PrintBook());

            Console.WriteLine("Stats to be implemented");
        }

        static void AddStudentToGradeBookInMemory(ref List<Book> tClasses)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch(Exception x)
            {
                Console.WriteLine(x.Message);
            }
        }

    }
}
