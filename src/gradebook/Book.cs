using System;
using System.Collections.Generic;

namespace gradebook
{
    public class Book
    {
        private List<StudGrade> sGrades;
        public string className {get; set;}

        public Book(string cName)
        {
            className = cName;
            sGrades = new List<StudGrade>();
        }

        public void AddStudent(string sName)
        {
            StudGrade newStudent = new StudGrade(sName);

            if(!sGrades.Contains(newStudent))
                sGrades.Add(newStudent);
        }

        public void AddGrade(string sName, double gradeToAdd)
        {
            var counter = 0;

            foreach (var student in sGrades)
            {
                if (student.StudentName == sName)
                {
                    student.AddSingleGrade(gradeToAdd);
                }
                else
                {
                        counter += 1;
                }

                //the following won't execute unless the loop is 
                //at its end and hasn't done anything but go to the
                //else clause on the preceeding statement
                if(counter == sName.Length)
                {
                    this.AddStudent(sName);

                    //recursively call AddGrade to enter the value
                    this.AddGrade(sName, gradeToAdd);
                }
            }

        }

        public List<string> AllStudentsNames()
        {
            List<string> temp = new List<string>();

            foreach(var s in sGrades)
                temp.Add(s.StudentName);

            return temp;
        }

        public string PrintBook()
        {
            string temp = className;

            foreach(var student in sGrades)
            {
                temp += "\n" + student.ToString();
            }

            return temp;
        }

        public string StringForFile()
        {
            string stringBuilder = className + ", ";

            foreach (var student in sGrades)
            {
                stringBuilder += student.StrForFile() + ", ";
            }

            return stringBuilder;
        }
        /* 
        public Statistics GetStats()
        {
            var result = new Statistics();
            var totalOfGrades = 0.0;
          
            foreach(var num in sGrades)
            {
                result.Low = Math.Min(num, result.Low);
                result.High = Math.Max(num, result.High);
                totalOfGrades += num;
            }


            return result;
        }
        */
    }



}