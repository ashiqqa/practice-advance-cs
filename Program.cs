﻿using PracticeAdvanceCS.EmployeePart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace PracticeAdvanceCS
{
    //Lamda
    public class Program
    {
       public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>() {
                new Employee{ Id=1, Name="Ashiq"},
                new Employee{ Id=2, Name="Shakib"},
                new Employee{Id=1, Name="Shopon"}
            };


            //Employee employee = employees.Find((Employee emp )=> emp.Id == 2);
            Employee employee = employees.Find(emp => emp.Id==2);

            Console.WriteLine($"Id = {employee.Id}, Name= {employee.Name}");
            Console.WriteLine($"Name start with A = {employees.Count(emp => emp.Name.StartsWith("A"))}");

            Console.ReadKey();

        }
    }

    public class Account
    {
        public Account(int id, double balance)
        {
            Id = id;
            Balance = balance;
        }
        public int Id { get; set; }
        public double Balance { get; set; }
        public void Withdraw(double amount)
        {
            Balance -= amount;
        }
        public void Deposit(double amount)
        {
            Balance += amount;
        }
    }

    public class AccountManager
    {
        public AccountManager(Account fromAcc, Account toAcc, double transferAmount)
        {
            FromAccount = fromAcc;
            ToAccount = toAcc;
            AmountToTransfer = transferAmount;
        }
        Account FromAccount { get; set; }
        Account ToAccount { get; set; }
        double AmountToTransfer { get; set; }
        public void Transfer()
        {
            object _lock1, _lock2;
            if (FromAccount.Id < ToAccount.Id)
            {
                _lock1 = FromAccount;
                _lock2 = ToAccount;
            }
            else
            {
                _lock1 = ToAccount;
                _lock2 = FromAccount;
            }
            Console.WriteLine($"{Thread.CurrentThread.Name} trying to acquire lock on {((Account)_lock1).Id.ToString()}");
            lock (_lock1)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {((Account)_lock1).Id.ToString()}");
                Console.WriteLine($"{Thread.CurrentThread.Name} suspende for 1 sec");
                Thread.Sleep(1000);
                Console.WriteLine($"{Thread.CurrentThread.Name} back on action and trying to acquire lock on {((Account)_lock2).Id.ToString()}");
                lock (_lock2)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {((Account)_lock2).Id.ToString()}");
                    FromAccount.Withdraw(AmountToTransfer);
                    ToAccount.Deposit(AmountToTransfer);
                    Console.WriteLine($"{Thread.CurrentThread.Name} Transfered {AmountToTransfer} From {FromAccount.Id} to {ToAccount.Id}");
                }
            }
        }

    }
}