using System.Net;
using System.Net.Http.Json;
using BlazorCrudDotNet7.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorCrudDotNet7.Client.Services.EmployeeService;

public class EmployeeService : IEmployeeService
{
    private readonly HttpClient _httpClient;
    private readonly NavigationManager _navigationManger;

    public EmployeeService(HttpClient httpClient, NavigationManager navigationManager)
    {
        _httpClient = httpClient;
        _navigationManger = navigationManager;
    }

    public List<Employee> Employees { get; set; } = new();
    
    public async Task GetEmployees()
    {
        var employees = await _httpClient.GetFromJsonAsync<List<Employee>>("api/employee");

        if (employees is not null)
            Employees = employees;
    }

    public async Task<Employee?> GetEmployeeById(int? id)
    {
        var result = await _httpClient.GetAsync($"api/employee/{id}");

        if (result.StatusCode == HttpStatusCode.OK)
        {
            return await result.Content.ReadFromJsonAsync<Employee>();
        }

        return null;
    }

    public async Task CreateEmployee(Employee employee)
    {
        await _httpClient.PostAsJsonAsync("api/employee", employee);
        _navigationManger.NavigateTo("employees");
    }

    public async Task UpdateEmployee(int employeeId, Employee employee)
    {
        await _httpClient.PutAsJsonAsync($"api/employee/{employeeId}", employee);
        _navigationManger.NavigateTo("employees");
    }

    public async Task DeleteEmployee(int id)
    {
        await _httpClient.DeleteAsync($"api/employee/{id}");
        _navigationManger.NavigateTo("employees");
    }
}