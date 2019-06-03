using System;
using System.Collections.Generic;

namespace gradebook
{
    public class StudGrade
    {
        //Classes, as in school classes, will be stored in the Book.cs

        public string StudentName {get; set;}

        public List<double> grades;

        public StudGrade(string n)
        {
            grades = new List<double>();
            StudentName = n;
        }

        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
                grades.Add(grade);
            else
                Console.WriteLine("Invalid grade.");
        }

        public void AddSingleGrade(double gradeToAdd)
        {
            grades.Add(gradeToAdd);
        }

        public string StrForFile()
        {
            string stringBuilder = StudentName + ", ";

            foreach (var grade in grades)
            {
                stringBuilder += grade.ToString("0.##") + ", ";
            }

            return stringBuilder;
        }

        //override is used to use this instead of the inherieted class
        public override string ToString()
        {
            return StudentName + ": " + String.Join(" ", grades);
        }
    }



}