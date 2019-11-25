﻿using PracticeAdvanceCS.EmployeePart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PracticeAdvanceCS
{
    //Stack  Last in First Out (LIFO)
    public class Program
    {
        public static void Main(string[] args)
        {
            Student student1 = new Student { Id = 1013, Name = "Mark", DueFee = 2500 };
            Student student2 = new Student { Id = 1320, Name = "Alex", DueFee = 1900 };
            Student student3 = new Student { Id = 1231, Name = "Sam", DueFee = 2800 };

            Stack<Student> stackStudents = new Stack<Student>();
            stackStudents.Push(student1);
            stackStudents.Push(student2);
            stackStudents.Push(student3);
            foreach(Student std in stackStudents)
            {
                Console.WriteLine(std.Name);
            }

            //Push() retrive last/top item with removing
            Student s1 = stackStudents.Pop();
            Console.WriteLine($"Exist: {stackStudents.Count} student, Retrived: {s1.Name}");
            Student s2 = stackStudents.Pop();
            Console.WriteLine($"Exist: {stackStudents.Count} student, Retrived: {s2.Name}");
            //Peek() retrive last/top item without removing
            Student s3 = stackStudents.Peek();
            Console.WriteLine($"Exist: {stackStudents.Count} student, Peeked: {s3.Name}");

            Console.ReadKey();
        }
    }

    //Creating A complex type as Sortable
    public class Student : IComparable<Student>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DueFee { get; set; }

        public int CompareTo(Student other)
        {
            return this.Name.CompareTo(other.Name);
        }
        public static int SortById(Student s1, Student s2)
        {
            return s1.Id.CompareTo(s2.Id);
        }
    }

    //Creating Custom Sort field
    public class SortByDueFee : IComparer<Student>
    {
        public int Compare(Student s1, Student s2)
        {
            if (s1.DueFee > s2.DueFee) return 1;
            else if (s1.DueFee < s2.DueFee) return -1;
            else return 0;
        }
    }
}
