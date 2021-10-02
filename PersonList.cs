using System;
using System.Collections.Generic;
public class PersonList
{
	public List<Student> StudentList;
	public List<Employee> EmployeeList;
	public PersonList()
	{
		EmployeeList = new List<Employee>();
		StudentList = new List<Student>();
	}
	public void AddListST(Student student)//เพิ่ม Student ลงในลิส Student
	{
		StudentList.Add(student);
	}
	public void AddListEP(Employee employee)//เพิ่ม Employee ลงในลิส Employee
	{
		EmployeeList.Add(employee);
	}
	public void GetList()//แสดงค่าในลิส
	{
		StudentList.ForEach(value => { Console.WriteLine(value.name + value.password + value.studentID); });
		EmployeeList.ForEach(value => { Console.WriteLine(value.name + value.password + value.employeeID); });
	}
	public bool CheckList(string name, string password)//ตัวเช็คว่ามีราบชื่อในลิสหรือไม่
	{
		bool result = true;
		StudentList.ForEach(value => {if (name == value.name && password == value.password) { result = true; } else { result = false; } } );
		if (result == false)
		{
			EmployeeList.ForEach(value => { if (name == value.name && password == value.password) { result = true; } else { result = false; } });
		}
		return result;
	}
	public Person findPerson(string name,string password)//ค้นหาตัวตนจากชื่อและรหัสที่ผู้ใช้กรอก
    {
		Person person = new Person("0","0",0);
		StudentList.ForEach(value => { if (name == value.name && password == value.password) { person = new Person(value.name,value.password,value.type); } });
		EmployeeList.ForEach(value => { if (name == value.name && password == value.password) { person = new Person(value.name, value.password, value.type); } });
		return person;
	}
	public Student findStudent(string name,string password)//ค้นหานักเรียนจากตัวตน
    {
		Student student = new Student("0", "0", 0, "0");
		StudentList.ForEach(value => { if (name == value.name && password == value.password) { student = new Student(value.name, value.password, value.type,value.studentID); } });
		return student;
	}
	public Employee findEmployee(string name, string password)//ค้นหาพนักงานจากตัวตน
	{
		Employee employee = new Employee("0", "0", 0, "0");
		EmployeeList.ForEach(value => { if (name == value.name && password == value.password) { employee = new Employee(value.name, value.password, value.type, value.employeeID); } });
		return employee;
	}
}
