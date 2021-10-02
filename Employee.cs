using System;
using System.Collections.Generic;
public class Employee : Person
{
	public string employeeID;
	
	public Employee(string Name, string Password, int Type, string EmployeeID) : base(Name, Password, Type)
	{
		this.employeeID = EmployeeID;
		
	}
	
}
