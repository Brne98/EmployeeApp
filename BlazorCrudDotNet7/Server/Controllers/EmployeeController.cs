using BlazorCrudDotNet7.Server.Services.EmployeeService;
using BlazorCrudDotNet7.Shared;
using BlazorCrudDotNet7.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrudDotNet7.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    
    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<List<Employee>> GetEmployees()
    {
        return await _employeeService.GetEmployees();
    }
    
    [HttpGet("{id}")]
    public async Task<Employee?> GetEmployeeById(int id)
    {
        return await _employeeService.GetEmployeeById(id);
    }
    
    [HttpPost]
    public async Task<Employee> CreateEmployee(Employee employee)
    {
        return await _employeeService.CreateEmployee(employee);
    }
    
    [HttpPut("{id}")]
    public async Task<Employee?> UpdateEmployee(int id, Employee employee)
    {
        return await _employeeService.UpdateEmployee(id, employee);
    }
    
    [HttpDelete("{id}")]
    public async Task<bool> DeleteEmployee(int id)
    {
        return await _employeeService.DeleteEmployee(id);
    }
}