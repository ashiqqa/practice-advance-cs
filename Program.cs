﻿using PracticeAdvanceCS.EmployeePart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace PracticeAdvanceCS
{
    //Protecting Shared Resource from concurrent access in multithreading
    public class Program
    {
        static int total = 0;
        public static void Main(string[] args)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            Thread t1 = new Thread(Program.AddOneMillion);
            Thread t2 = new Thread(Program.AddOneMillion);
            Thread t3 = new Thread(Program.AddOneMillion);

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("Sum = " + total);
            stopWatch.Stop();
            Console.WriteLine("Total Ticks: "+stopWatch.ElapsedTicks);
            Console.WriteLine("Ticks per MiliSecond: "+TimeSpan.TicksPerMillisecond);

            //Console.ReadKey();
        }
        //static object _lock = new object();
        private static void AddOneMillion()
        {
            for (int i = 1; i <= 1000000; i++)
            {
                Interlocked.Increment(ref total); //Better performance
                //lock (_lock)
                //{
                //    total++;
                //}
            }
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