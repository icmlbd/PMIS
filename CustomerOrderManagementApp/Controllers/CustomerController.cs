using CustomerOrderManagementApp.Models.EntityModels;
using CustomerOrderManagementApp.Models.ViewModels;
using CustomerOrderManagementApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerOrderManagementApp.Controllers
{

    public class CustomerController : Controller
    {
        CustomerRepository _customerRepository;
        CustomerCategoryRepository _custCategoryRepository; 
       
        
        public CustomerController()
        {
           _customerRepository = new CustomerRepository();
            _custCategoryRepository = new CustomerCategoryRepository();
        }

       
        public IActionResult Index()
        {
            var customers = _customerRepository.GetAll().ToList();

            return View(customers);
        }


        public IActionResult Create()
        {
            //first time operation > we dont want to have database operation 
            // goal: mainly customer create page return 

            CustomerCreateViewModel model = new CustomerCreateViewModel();
            model.Customers = _customerRepository.GetAll().ToList();
            model.CustomerCategories = _custCategoryRepository.GetAll()
                                                    .ToList()
                                                    .Select(c=> new SelectListItem()
                                                    {
                                                        Text = c.Name, 
                                                        Value = c.Id.ToString()
                                                    });

            return View(model);
        }

        //customer/create
        [HttpPost]
        public IActionResult Create(CustomerCreateViewModel customer)
        {
            //second time: on submit we want to have the database operation
            //database related operations
            //problem: customer list data is not persisted 
            if(ModelState.IsValid)
            {
                var inputCustomer = new Customer()
                {
                    Name = customer.Name,
                    Phone = customer.Phone,
                    Address = customer.Address,
                    Age = customer.Age,
                    CategoryId = customer.CategoryId,
                    AddressCity = customer.AddressCity
                    
                };


              bool isAdded =  _customerRepository.Add(inputCustomer);
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }
                
            }

            customer.CustomerCategories = _custCategoryRepository.GetAll()
                                                    .ToList()
                                                    .Select(c => new SelectListItem()
                                                    {
                                                        Text = c.Name,
                                                        Value = c.Id.ToString()
                                                    }); 
            customer.Customers = _customerRepository.GetAll().ToList();
            return View(customer);

            
            //return View(model);
        }

        public IActionResult View(int? id)
        {
            if(id == null)
            {
                return View("NotFound");
            }

            Customer existingCustomer = _customerRepository.Get((int)id);

            if (existingCustomer == null)
            {
                return View("Customer Not Found!");
            }


            return View(existingCustomer);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            Customer customer = _customerRepository.Get((int)id);

            if (customer == null)
            {
                return View("NotFound");
            }

            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            if (customer == null)
            {
                return View("NotFound");

            }

            if (ModelState.IsValid)
            {
                Customer existingCustomer = _customerRepository.Get((int)customer.Id);

                existingCustomer.Name = customer.Name;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.Address = customer.Address;
                existingCustomer.Age = customer.Age;

                bool isUpdated = _customerRepository.Update(existingCustomer);

                return RedirectToAction("Index");
            }

            return View(customer);

        }

       
        
    }


}
