using System;

namespace Chapter10.Examples
{
    public class Address
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string Line5 { get; set; }
    }

    public class CustomerOrder
    {
        private readonly Address _deliveryAddress = new Address();

        public void UpdateDeliveryAddress(string line1, string line2, string line3,
            string line4, string line5)
        {
            _deliveryAddress.Line1 = line1;
            _deliveryAddress.Line2 = line2;
            _deliveryAddress.Line3 = line3;
            _deliveryAddress.Line3 = line4;
            _deliveryAddress.Line5 = line5;

        }
    }

    public class Employee
    {
        public double AnnualSalary { get; set; }
    }

    public interface ISalaryCalculator
    {
        public void CalculateSalary(Employee employee, double amount);
    }

    public class SalaryCalculator : ISalaryCalculator
    {
        public void CalculateSalary(Employee employee, double amount)
        {
            employee.AnnualSalary += amount;
        }
    }

    public class PayrollService
    {
        private readonly Employee _employee = new() { AnnualSalary = 1000 };

        public void CalculateSalary(ISalaryCalculator calculator)
        {
            calculator.CalculateSalary(_employee, 200);
            calculator.CalculateSalary(_employee, 200);
        }

        public Employee Employee => _employee;
    }

    public class Program
    {
        public static void Main()
        {
            var payrollService = new PayrollService();
            Console.WriteLine($"Initial Salary: {payrollService.Employee.AnnualSalary}");

            payrollService.CalculateSalary(new SalaryCalculator());

            Console.WriteLine($"New Salary: {payrollService.Employee.AnnualSalary}");
        }
    }
}