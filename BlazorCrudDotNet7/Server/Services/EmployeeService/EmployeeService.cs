using BlazorCrudDotNet7.Server.Data;
using BlazorCrudDotNet7.Shared;
using BlazorCrudDotNet7.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet7.Server.Services.EmployeeService;

public class EmployeeService : IEmployeeService
{
    private readonly DataContext _context;

    public EmployeeService(DataContext context)
    {
        _context = context;
    }

    public Task<List<Employee>> GetEmployees()
    {
        return _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeById(int employeeId)
    {
        var employee = await _context.Employees.FindAsync(employeeId);
        return employee;
    }

    public async Task<Employee> CreateEmployee(Employee employee)
    {
        _context.Add(employee);
        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task<Employee?> UpdateEmployee(int employeeId, Employee employee)
    {
        var dbEmployee = await _context.Employees.FindAsync(employeeId);
        if (dbEmployee != null)
        {
            dbEmployee.FullName = employee.FullName;
            dbEmployee.Position = employee.Position;
            dbEmployee.PhoneNumber = employee.PhoneNumber;
            dbEmployee.Age = employee.Age;
            dbEmployee.Birth = employee.Birth;
            dbEmployee.Salary = employee.Salary;

            await _context.SaveChangesAsync();
        }

        return dbEmployee;
    }

    public async Task<bool> DeleteEmployee(int employeeId)
    {
        var employee = await _context.Employees.FindAsync(employeeId);
        
        if (employee == null)
        {
            return false;
        }

        _context.Remove(employee);
        await _context.SaveChangesAsync();

        return true;
    }
}