using System;
using Course_WorkerContracts.Entities.Enums;
using System.Collections.Generic;
using System.

namespace Course_WorkerContracts.Entities
{
    class Worker
    {
        public string Name  { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddContracts(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContracts(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;

            foreach(HourContract contracts in Contracts)
            {
                if(contracts.Date.Year == year && contracts.Date.Month == month)
                {
                    sum += contracts.totalValue();
                }
            }

            return sum;
        }
    }
}
