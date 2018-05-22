using System;
class Employee: Person
{
    public string Department { get; set; }
    public Employee(string firstname, string lastname, string department):base(firstname, lastname)
    {
        if(string.IsNullOrEmpty(department))
        {
            throw new ArgumentOutOfRangeException("department", department, "department is null or empty");
        }
        this.Department=department;
    }
}