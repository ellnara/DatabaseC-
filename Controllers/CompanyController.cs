using ConsoleApp17.DataAccess;
using ConsoleApp17.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp17.Controllers
{
    public class CompanyController
    {
        private readonly AppDbContext _context;
        public CompanyController()
        {
            _context = new AppDbContext();
        }
        public void GetAllEmployees()
        {
            foreach (var item in _context.Employees)
            {
                Console.WriteLine(  item.Fullname); 
            }
        }
        public void AddEmployee(string FullName)
        {
            try
            {
                Employee employee = new Employee { Fullname = FullName };
                _context.Employees.Add(employee);
                _context.SaveChanges();
                Console.WriteLine("Employee Created");
            }
            catch (Exception)
            {

                Console.WriteLine("Could not create Employee");
            }
        }
        public void DeleteEmployee(int id)
        {
            try
            {
                Employee employee = _context.Employees.Find(id);
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                Console.WriteLine("Employee Deleted");
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Id Doesn't Exist");
            }
        }
        public void GetEmployeeById(int id)
        {
            try
            {
                Console.WriteLine(_context.Employees.Find(id).Fullname);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                Console.WriteLine("Could not find Id");
            }
        }
        public void FilterByName(string search)
        {
            try
            {
                List<Employee> employees = _context.Employees.ToList();
                foreach (var item in employees)
                {
                    if (item.Fullname.ToLower().Contains(search) || item.Fullname.ToUpper().Contains(search))
                    {
                        Console.WriteLine(item.Fullname);
                    }
                    else
                    {
                        Console.WriteLine("Employee Does not Exist");
                        break;
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Employee Does not Exist");
            }
        }
    }
}
