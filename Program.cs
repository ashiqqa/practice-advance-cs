﻿using PracticeAdvanceCS.EmployeePart;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeAdvanceCS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<int, string> dictionaries = new Dictionary<int,string>();
            dictionaries.Add(1, "Ashiq");
            dictionaries.Add(2, "Shopon");
            dictionaries.Add(3, "Md Ashiqur Rahman Shopon");
            foreach (KeyValuePair<int, string> item in dictionaries)
            {
                Console.WriteLine($"Id: {item.Key}, Name: {item.Value}");
            }
            //Using TryGetValue function escape exception
            string name = dictionaries.TryGetValue(4, out name)?name:"Not found";
            Console.WriteLine(name);
            int totalItem = dictionaries.Count;
            Console.WriteLine($"TotalItem = {totalItem}");

            List<string> items = new List<string>();
            items.Add("Item1");
            items.Add("Item2");
            items.Add("Item3");
            Dictionary<int, string> listToDictionaries = items.ToDictionary(c => c.Length, c => c);

            Console.ReadKey();
        }
        
        
    }

    public class Company
    {
        private List<Employee> employees;
        public Company()
        {
            employees = new List<Employee>()
            {
                new Employee(){Id=1, Name="Ashiq"},
                new Employee(){Id=2, Name="Shopon"},
                new Employee(){Id=3, Name="Ashiqur Rahman"}
            };
        }
        public string this[int employeeId]
        {
            get{ return this.employees.Find(c => c.Id == employeeId).Name;}
            set{this.employees.Find(c => c.Id == employeeId).Name = value;}
        }
        public Employee this[int id, string updatedName]
        {
            get {
                this.employees.Find(e => e.Id == id).Name = updatedName;
                return employees.Find(c => c.Id == id);
            }
        }

    }

}
