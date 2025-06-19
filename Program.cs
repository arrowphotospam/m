using System;
using StudentLibrary;
using StudentLibrary.Models;

namespace StudentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n1. Add Student\n2. Edit Student\n3. List Students\n4. Find Student\n5. Delete Student\n6. Exit");
                Console.Write("Choose option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        var newStudent = GetStudentDetails();
                        try
                        {
                            BusinessLayer.ValidateStudentData(newStudent);
                            DataAccessLayer.AddStudent(newStudent);
                            Console.WriteLine("Student added.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "2":
                        var editStudent = GetStudentDetails();
                        try
                        {
                            BusinessLayer.ValidateStudentData(editStudent);
                            DataAccessLayer.EditStudent(editStudent);
                            Console.WriteLine("Student updated.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "3":
                        foreach (var s in DataAccessLayer.GetAllStudents())
                            DisplayStudent(s);
                        break;

                    case "4":
                        Console.Write("Enter keyword: ");
                        var keyword = Console.ReadLine();
                        var results = DataAccessLayer.FindStudents(keyword);
                        results.ForEach(DisplayStudent);
                        break;

                    case "5":
                        Console.Write("Enter ID to delete: ");
                        int id = int.Parse(Console.ReadLine());
                        DataAccessLayer.DeleteStudent(id);
                        Console.WriteLine("Student deleted.");
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        static Student GetStudentDetails()
        {
            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Grade: ");
            string grade = Console.ReadLine();
            Console.Write("Major: ");
            string major = Console.ReadLine();

            return new Student { Id = id, Name = name, Age = age, Grade = grade, Major = major };
        }

        static void DisplayStudent(Student s)
        {
            Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Age: {s.Age}, Grade: {s.Grade}, Major: {s.Major}");
        }
    }
}