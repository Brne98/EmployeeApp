using BlazorCrudDotNet7.Shared;
using BlazorCrudDotNet7.Shared.Entities;

namespace BlazorCrudDotNet7.Client.Services.EmployeeService;

public interface IEmployeeService
{
    List<Employee> Employees { get; set; }
    Task GetEmployees();
    Task<Employee?> GetEmployeeById(int? id);
    Task CreateEmployee(Employee employee);
    Task UpdateEmployee(int employeeId, Employee employee);
    Task DeleteEmployee(int id);
}