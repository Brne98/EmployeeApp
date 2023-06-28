namespace BlazorCrudDotNet7.Shared;

public class Employee
{
    public int Id { get; set; }
        
    public required string FullName { get; set; }

    public string Position { get; set; } = string.Empty;
    
    public int Salary { get; set; }
    
    public string? PhoneNumber { get; set; }
    
    public int Age { get; set; }
    
    public DateTime Birth { get; set; }
}