using System.Collections.Generic;
using System.Linq;
using StudentLibrary.Models;

namespace StudentLibrary
{
    public static class DataAccessLayer
    {
        private static List<Student> students = new List<Student>();

        public static void AddStudent(Student student) => students.Add(student);

        public static void EditStudent(Student student)
        {
            var index = students.FindIndex(s => s.Id == student.Id);
            if (index != -1) students[index] = student;
        }

        public static List<Student> GetAllStudents() => new List<Student>(students);

        public static List<Student> FindStudents(string keyword) =>
            students.Where(s => s.Name.Contains(keyword) || s.Major.Contains(keyword)).ToList();

        public static void DeleteStudent(int studentId) =>
            students.RemoveAll(s => s.Id == studentId);
    }
}