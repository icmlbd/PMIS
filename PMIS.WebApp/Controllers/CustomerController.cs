using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PMIS.Models;
using PMIS.Models.EntityModels;
using PMIS.Repositories;
using PMIS.Repositories.Abstractions;
using PMIS.Services.Abstractions;
using PMIS.WebApp.Models;
using PMIS.WebApp.Models.ViewModels;

namespace PMIS.WebApp.Controllers
{

    public class CustomerController : Controller
    {
        ICustomerService _customerService;
        ICustomerCategoryService _customerCategoryService; 


        public CustomerController(ICustomerService customerService, ICustomerCategoryService cateogryService)
        {
            _customerService = customerService;
            _customerCategoryService = cateogryService;
        }


        public IActionResult Index(string? customerType)
        {
            List<Customer> customers;
                        customers = _customerService.GetAll().OrderBy(c => c.Name).ToList();
            return View(customers);
        }


        public IActionResult Create()
        {
            //first time operation > we dont want to have database operation 
            // goal: mainly customer create page return 

            CustomerCreateViewModel model = new CustomerCreateViewModel();
            model.Customers = _customerService.GetAll().ToList();
            model.CustomerCategories = _customerCategoryService.GetAll()
                                                    .ToList()
                                                    .Select(c => new SelectListItem()
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
            if (ModelState.IsValid)
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


                bool isAdded = _customerService.Add(inputCustomer);
                if (isAdded)
                {
                    return RedirectToAction("Index");
                }

            }

            customer.CustomerCategories = _customerCategoryService.GetAll()
                                                    .ToList()
                                                    .Select(c => new SelectListItem()
                                                    {
                                                        Text = c.Name,
                                                        Value = c.Id.ToString()
                                                    });
            customer.Customers = _customerService.GetAll().ToList();
            return View(customer);


            //return View(model);
        }

        public IActionResult View(int? id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            Customer existingCustomer = _customerService.Get((int)id);

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

            Customer customer = _customerService.Get((int)id);

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
                Customer existingCustomer = _customerService.Get(customer.Id);

                existingCustomer.Name = customer.Name;
                existingCustomer.Phone = customer.Phone;
                existingCustomer.Address = customer.Address;
                existingCustomer.Age = customer.Age;

                bool isUpdated = _customerService.Update(existingCustomer);

                return RedirectToAction("Index");
            }

            return View(customer);

        }



    }


}
