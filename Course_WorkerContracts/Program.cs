using System;
using System.Collections.Generic;
using Course_WorkerContracts.Entities;

using Course_WorkerContracts.Entities.Enums;

namespace Course_WorkerContracts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Entre the departament's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter worker data");
            Console.Write("Name: ");
            string workerName = Console.ReadLine();
            Console.Write("Level(Junior/MidLevel/Senior): ");
            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine());
            
            Department dept = new Department(deptName);
            Worker worker = new Worker(workerName, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int numContracts = int.Parse(Console.ReadLine());

            for (int x = 1; x <= numContracts; x++)
            {
                Console.WriteLine($"Enter #{x} contract data");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContracts(contract);
            }

            Console.WriteLine();

            Console.Write("Enter month and the year to calculate de income (MM/YYYY)");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));
            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {monthAndYear}: {worker.Income(year, month).ToString("c")}");

            Console.ReadLine();
        }
    }
}
