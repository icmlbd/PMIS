// See https://aka.ms/new-console-template for more information


using CustomerOrderManagementApp.DataStorage;
using CustomerOrderManagementApp.Models.EntityModels;
using EFCorePractices;
using Microsoft.EntityFrameworkCore;

EcommerceDbContext db = new EcommerceDbContext();

//Customer Category CRUD operations 

//CustomerCategory cc = new CustomerCategory()
//{
//    Name = "Regular",
//};

//CustomerCategory cc1 = new CustomerCategory()
//{
//    Name = "Silver",
//};

//List<Customer> customers = new List<Customer>()
//    {
//        new Customer()
//        {
//            Name="A",
//            Phone = "9839832",
//            Age = 32,
//            Address = "Dhaka"

//        },
//         new Customer()
//        {
//            Name="B",
//            Phone = "232353453",
//            Age = 34,
//            Address = "Dhaka"

//        },
//          new Customer()
//        {
//            Name="C",
//            Phone = "23435435",
//            Age = 36,
//            Address = "Sylhet"

//        },
//    };

////CustomerCategory cc2 = new CustomerCategory()
////{
////    Name = "Gold",
////    Customers = customers
////};

//var existingCategory = db.CustomersCategories.FirstOrDefault(c => c.Id == 4);

//if(existingCategory == null)
//{
//    Console.WriteLine("Category not found!");
//}

//var newCustomer = new Customer()
//{
//    Name = "E",
//    Phone = "23435435",
//    Age = 36,
//    Address = "Sylhet",
//    Category = existingCategory

//};


////db.CustomersCategories.Add(cc);
////db.CustomersCategories.Add(cc1);

////db.CustomersCategories.Add(cc2);

//db.Customers.Add(newCustomer);

//int successCount = db.SaveChanges();


//if (successCount > 0)
//{
//    Console.WriteLine("Saved Successfully!");
//}


// all customer records ##


//var customers = db.Customers
//                    //.Include(c=>c.Category)

//explicitly loading

//lazy loading

//var categories = db.CustomersCategories
//                    .Include(c => c.Customers)
//                    .ToList();

//foreach(var category in categories)
//{
//    db.Entry(category)
//        .Collection(c => c.Customers)
//        .Query()
//        .Where(c=>c.Age>23)
//        .Load();
//}



//foreach (var customer in customers)
//{
//    //var category = db.CustomersCategories.FirstOrDefault(c => c.Id == customer.CategoryId);

//    //customer.Category = category; 

//    //db.Entry(customer)
//    //    .Reference(c => c.Category)
//    //    .Load();

//    string categoryName = customer.Category == null ? "N/A" : customer.Category.Name;
//    Console.WriteLine($"Cust.Id: {customer.Id} Name: {customer.Name} Phone: {customer.Phone} Cat.Id: {customer.CategoryId} Category: {categoryName}");
//}

// search box: 
string keyword = "sy";

//var customers = db.Customers.AsQueryable();

//customers = customers.Where(c => 
//c.Name.ToLower().Contains(keyword.ToLower())
//|| c.Phone.ToLower().Contains(keyword.ToLower())
//|| (c.Address!=null && c.Address.ToLower().Contains(keyword.ToLower()))
//);

//var retrieveCustomers = customers.ToList();


//People people = new People();
//people.Add(new Person() { Id = 1, Name = "A" });

//foreach(Person person in people)
//{

//}

List<int> numbers = new List<int>();
List<Person> persons = new List<Person>();
                    

Console.ReadKey();
