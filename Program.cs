﻿
using System;
using System.Reflection;

namespace PracticeAdvanceCS
{
    //EarlyBinding vs LateBinding
    class Program
    {
        public static void Main(string[] args)
        {
            //Early binding
            Student student = new Student();
            string studentInfobyEarlyBinding = student.GetById(1, "Ashiq");

            //Late binding
            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Type typeOfStudent = Type.GetType("PracticeAdvanceCS.Student");
            object instanceOfStudent = Activator.CreateInstance(typeOfStudent);
            MethodInfo getByIdMethod = typeOfStudent.GetMethod("GetById");
            object[] methodParams = new object[2];
            methodParams[0] = 2;
            methodParams[1] = "Swapan";
            string studentInfoByLateBinding = (string)getByIdMethod.Invoke(instanceOfStudent, methodParams);

            Console.WriteLine("EarlyBInding: {0}", studentInfobyEarlyBinding);
            Console.WriteLine("LateBInding: {0}", studentInfoByLateBinding);

            Console.ReadKey();
        }
    }

    public class Student
    {
        private string _name;
        private string _roll;
        public int Id { get; set; } 
        public string Reg { get; set; }
        public string GetById(int id, string name)
        {
            return $"StudentId: {id}, Name: {name}";
        }

    }

}
