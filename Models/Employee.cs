﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAdvanceCS.Models
{
    public delegate bool SeniorChecker(Employee employee);

    //Region #Fields #Properties #Method
    public class Employee
    {
        #region Fields
        private int _id;
        private string _name;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }
        #endregion

        #region Method
        public static void GetFilteredEmployee(List<Employee> employess, SeniorChecker seniorChecker)
        {
            foreach (Employee emp in employess)
            {
                if (seniorChecker(emp))
                {
                    Console.WriteLine($"Name:{emp.Name}Experience: {emp.Experience} Salary: {emp.Salary}");
                }
            }
        }
        #endregion
    }

}
