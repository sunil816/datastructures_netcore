namespace ConsoleApp1.Streams;

public class Employee
{
    public int EmployeeID { get; set; }
    public string City { get; set; }
    public double Salary { get; set; }
}

public class StreamsAPI
{
    List<Employee> employees = new List<Employee>();

    public StreamsAPI()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                employees.Add(
                    new Employee()
                    {
                        EmployeeID = i*10 + j, 
                        City = "Bangalore" + i,
                        Salary = (i + j + 1) * i + 100.00,
                    });
            }
        }
    }

    public void NthLowestPaidEmpoyee()
    {
        
    }
    
    
    
    
    
    
    
    
    
    
    
    
    

    public void GetEmployeeCountByCity()
    {
        var employeeCountByCities = 
            employees
            .GroupBy(employee => employee.City)
            .Select(cityGroup => new { city = cityGroup.Key, count = cityGroup.Count() })
            .ToList();
        foreach (var employeeCountByCity in employeeCountByCities)
        {
            Console.WriteLine($"{employeeCountByCity.city} : {employeeCountByCity.count}");
        }
        return;
    }

    public void GetEmployeesByCity()
    {
        var employeesByCities = employees
            .OrderByDescending(employees => employees.City)
            .GroupBy(employee => employee.City)
            .Select(employeesByCity => new { city = employeesByCity.Key, Employees = employeesByCity.ToList() })
            .ToList();
        foreach (var employeesByCity in employeesByCities)
        {
            Console.WriteLine($"{employeesByCity.city} : {string.Join(",", employeesByCity.Employees.Select(employees =>employees.EmployeeID).ToList())})");
        }
    }
}