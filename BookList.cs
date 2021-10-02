using System;
using System.Collections.Generic;
public class BookList
{
	
	public List<Book> booklist;
	public List<Book> borrowlist;
	public BookList()
	{
		
		booklist = new List<Book>();
		borrowlist = new List<Book>();
	}
	public void AddBook(Book book)//เพิ่มหนังสือเข้ารายการ
    {
		booklist.Add(book);
    }
	public void borrowBook(Book book)//เพิ่มหนังสือที่ยืม
    {
		borrowlist.Add(book);
    }
	public void GetBook()//แสดงหนังสือที่มีทั้งหมด
    {
		booklist.ForEach(value => { Console.WriteLine("Book ID: {0}\nBook name: {1}", value.bookID, value.bookName); });
    }
	public void ShowBorrowBook()//แสดงหนังสือที่ยืมทั้งหมด
	{
		borrowlist.ForEach(value => { Console.WriteLine("Book ID: {0}\nBook name: {1}", value.bookID, value.bookName); });
	}
	public Book CheckBookFromID(string id)//เช็คชื่อหนังสือจากรหัส
    {
		string nameFromID = "";
		
		booklist.ForEach(value => { if (value.bookID == id) { nameFromID = value.bookName; } });
		Book book = new Book(id,nameFromID);
		return book;
    }
}
