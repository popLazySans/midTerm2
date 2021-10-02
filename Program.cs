using System;

namespace mySelf
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonList listPerson = new PersonList();
            int inputManagement;
            string name;
            string password;
            int type;
            string ID;
            Person person;
            Student personST;
            Employee personEP;
            int inputMenu;
            string InputName;
            bool resultLogin;
            string bookID;
            BookList booklist;
            BookList borrowlist;
            Book book1;
            Book book2;
            Book book3;
            Book book4;
            //ประกาศตัวแปร

            booklist = new BookList();
            book1 = new Book("1", "NOW I UNDERSTAND");
            book2 = new Book("2", "REVOLUTIONARY WEALTH");
            book3 = new Book("3", "Six Degrees");
            book4 = new Book("4", "Les Vacances");
            booklist.AddBook(book1);
            booklist.AddBook(book2);
            booklist.AddBook(book3);
            booklist.AddBook(book4);
            //นำหนังสือเข้ารายการ

            while (true)
            {
                Console.WriteLine("Welcome to Digital Library\n\n1.Login\n2.Register\nSelectMenu: ");
                inputMenu = int.Parse(Console.ReadLine());
                Console.Clear();
                //หน้าเมนู

                if (inputMenu == 1 && (listPerson.StudentList.Count !=0 || listPerson.EmployeeList.Count != 0))
                {
                    Console.WriteLine("Login Screen\n");
                    Console.Write("Input name : ");
                    InputName = Console.ReadLine();
                    Console.Write("Input Password : ");
                    string InputPassword = Console.ReadLine();
                    Console.Clear();
                    //หน้าล็อกอิน

                    resultLogin =  listPerson.CheckList(InputName,InputPassword);//ตัวเช็คว่ามีรายชื่อในลิสหรือไม่
                    if (resultLogin == true)
                    {
                        person = listPerson.findPerson(InputName, InputPassword);//หาตัวตนของผู้ใช้จากชื่อและรหัส
                        if(person.type == 1)
                        {
                            personST = listPerson.findStudent(InputName,InputPassword);//หารายชื่อนักเรียนจากตัวตนของผู็ใข้
                            Console.Write("Student Management\n\nStudent name : {0}\nStudent ID : {1}\n1.Borrow Book\nInput Menu :",personST.name,personST.studentID);
                            inputManagement = int.Parse(Console.ReadLine());
                            Console.Clear();
                            //การจัดการของนักเรียน


                            if (inputManagement == 1)
                            {
                                Console.WriteLine("Book List\n");
                                booklist.GetBook();
                                //แสดงหนังสือทั้งหมดในรายการ

                                borrowlist = new BookList();
                                while (true)
                                {
                                    Console.Write("Input book ID : ");
                                    bookID = Console.ReadLine();
                                    
                                    if (bookID == "Exit")//พิมพ์ Exit เพื่อสรุปหนังสือที่ยืม
                                    {
                                        break;
                                    }
                                    else {
                                        
                                        borrowlist.AddBook(booklist.CheckBookFromID(bookID));//เพิ่มหนังสือที่ยืมเข้ารายการยืม
                                    }      

                                }
                                Console.Clear();
                                Console.WriteLine("Student name : {0}\nStudent ID : {1}\n\nBook List\n", personST.name, personST.studentID);
                                borrowlist.GetBook();//แสดงหนังสือที่ยืมทั้งหมด
                                break;
                            }

                        }
                        else if(person.type == 2)
                        {
                            personEP = listPerson.findEmployee(InputName, InputPassword);//หาพนักงานจากตัวตนของผู้ใช้
                            Console.Write("Employee Management\n\nEmployee name : {0}\nEmployee ID : {1}\n1.Get List Books\nInput Menu :",personEP.name, personEP.employeeID);
                            inputManagement = int.Parse(Console.ReadLine());
                            Console.Clear();
                            //การจัดการของพนักงาน

                            if (inputManagement == 1)
                            {
                                Console.WriteLine("Book List\n");
                                booklist.GetBook();//แสดงรายการหนังสือที่มี
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong");
                    }
                }
                else if (inputMenu == 2)
                {
                    Console.WriteLine("Register new Person\n");
                    Console.Write("Input name : ");
                    name = Console.ReadLine();
                    Console.Write("Input password : ");
                    password = Console.ReadLine();
                    Console.Write("Input User Type 1 = Student, 2 = Employee : ");
                    type = int.Parse(Console.ReadLine());
                    //หน้าสมัคร

                    
                    if (type == 1)
                    {
                        Console.Write("Student ID : ");
                        ID = Console.ReadLine();
                        personST = new Student(name, password, type, ID);
                        listPerson.AddListST(personST);
                    }
                    else if (type == 2)
                    {
                        Console.Write("Employee ID : ");
                        ID = Console.ReadLine();
                        personEP = new Employee(name, password, type, ID);
                        listPerson.AddListEP(personEP);
                    }
                    //เช็คว่าเป็นนักเรียนหรือพนักงาน
                    Console.Clear();
                }
            }
        }
    }
}
