using System;
using StudentLibrary.Models;

namespace StudentLibrary
{
    public class BusinessLayer
    {
        public static void ValidateStudentData(Student student)
        {
            if (string.IsNullOrWhiteSpace(student.Name))
                throw new ArgumentException("Name is required.");
            if (student.Age < 0 || student.Age > 150)
                throw new ArgumentException("Invalid age.");
            if (string.IsNullOrWhiteSpace(student.Grade))
                throw new ArgumentException("Grade is required.");
            if (string.IsNullOrWhiteSpace(student.Major))
                throw new ArgumentException("Major is required.");
        }
    }
}