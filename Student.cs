using System;
using System.Collections.Generic;
public class Student : Person
{
	public string studentID;
	

	public Student(string Name, string Password, int Type,string StudentID) :base(Name,Password, Type)
	{
		this.studentID = StudentID;
		
	}
}
