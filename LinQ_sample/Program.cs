

//                              Part 1 : basic

/*
List<int> list = new List<int>() { 1, 2,3,4,5,6,7,8,9,10 };  // DataSource

IEnumerable<int> querySyntax = from obj in list                  // querySyntax
                  where obj > 2
                  select obj;

foreach (var item in querySyntax)               //execution

{
    Console.WriteLine(item);
}

Console.WriteLine("-------------------------");

var methodQuery = list.Where(obj => obj > 2);        // methodSyntax

foreach (var item in methodQuery)               //execution

{
    Console.WriteLine(item);
}

Console.WriteLine("-------------------------");

var mixedSyntax = (from obj in list select obj).Max();          //  mixedSyntax

Console.WriteLine(mixedSyntax);


IEnumerable<Employee> employee = new List<Employee>()
{
    new Employee(){Id = 1,Name = "Tom"},
    new Employee(){Id = 2,Name = "john"}
};

IEnumerable<Employee> query = from emp in employee
                              where emp.Id == 1
                              select emp;

IQueryable<Employee> query1 = employee.AsQueryable().Where(x => x.Id == 1);

foreach (var item in query1 )
{
    Console.WriteLine("Id = " + item.Id + " And Name = " + item.Name);
}
{
    
}


class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }    
}*/


//                              Part 2 :  Select in LINQ


using LinQ_sample;

List<Employee> employees = new List<Employee>()
{
    new Employee(){Id=1,Name="Saurav",Email="saurav@gmail.com"},
    new Employee(){Id=2,Name="Rohit",Email="rohit@gmail.com"},
    new Employee(){Id=3,Name="Pandey",Email="pandey@gmail.com"},
    new Employee(){Id=4,Name="Tiwari",Email="tiwari@gmail.com"},
    new Employee(){Id=5,Name="Adam",Email="adam@gmail.com"}
};

var basicquery = (from emp in employees
                 select emp).ToList();

var basicMethod = employees.ToList();


//----------
/// operation
/// 

var basicPropquery = (from emp in employees
                  select emp.Id +1).ToList();

var basicPropMethod = employees.Select(emp => emp.Id).ToList();

// In this case I need to fetch all the detail but i need to call only two properties

/*var selectQuery = (from emp in employees
                   select new Employee()
                   {
                       Id = emp.Id,
                       Email = emp.Email
                   }).ToList();*/


// Binding with student Class

var selectQuery1 = (from emp in employees
                   select new Student()
                   {
                       StudentID = emp.Id,
                       StdName = emp.Name,
                       StdEmail = emp.Email
                   }).ToList();

var selectMethod = employees.Select(emp => new Student()
{
    StudentID=emp.Id,
    StdName=emp.Name,
    StdEmail=emp.Email
}).ToList();


// anonymous class

var selectQuery2 = (from emp in employees
                    select new
                    {
                        CustomID = emp.Id,
                        CustomName = emp.Name,
                        CustomEmail = emp.Email
                    }).ToList();

var selectMethod2 = employees.Select(emp => new 
{
    CustomID = emp.Id,
    CustomName = emp.Name,
    CustomEmail = emp.Email
}).ToList();

// fetch index and name

var query = employees.Select((emp, index) => new
{
    Index = index,
    FullName = emp.Name
}).ToList();

foreach (var item in selectQuery1)
{
    Console.WriteLine($"Id = {item.StudentID}, Name ={item.StdName} , Email = {item.StdEmail}");
}
