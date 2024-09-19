using CustomerOrderManagementApp.Models.EntityModels;
using CustomerOrderManagementApp.Models.ViewModels;
using CustomerOrderManagementApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerOrderManagementApp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository _employeeRepository;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public IActionResult Index()
        {
            var employees=_employeeRepository.GetAll();
            // Map Employee entities to EmployeeViewModel
            var employeeViewModels = employees.Select(e => new EmployeeViewModel
            {
                Id = e.Id,
                Name = e.Name,
                EmployeeId = e.EmployeeId,
                PresentAddress = e.PersonalInformation.PresentAddress,
                PermanentAddress = e.PersonalInformation.PermanentAddress,
                FathersName = e.PersonalInformation.FathersName,
                MothersName = e.PersonalInformation.MothersName,
                SpousesName = e.PersonalInformation.SpousesName,
                MobileNo = e.PersonalInformation.MobileNo,
                TelephoneNo = e.PersonalInformation.TelephoneNo,
                Email = e.PersonalInformation.Email,
                DateOfBirth = e.PersonalInformation.DateOfBirth,
                NIDNo = e.PersonalInformation.NIDNo,
                BloodGroup = e.PersonalInformation.BloodGroup,
                BankAccountInfo = e.PersonalInformation.BankAccountInfo
            }).ToList();

            return View(employeeViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeViewModel) 
        {
            if (ModelState.IsValid) 
            {
                var employee = new Employee
                {
                    Name = employeeViewModel.Name,
                    EmployeeId = employeeViewModel.EmployeeId,
                    PersonalInformation=new PersonalInformation {
                        PresentAddress = employeeViewModel.PresentAddress,
                        PermanentAddress = employeeViewModel.PermanentAddress,
                        FathersName = employeeViewModel.FathersName,
                        MothersName = employeeViewModel.MothersName,
                        SpousesName = employeeViewModel.SpousesName,
                        MobileNo = employeeViewModel.MobileNo,
                        TelephoneNo = employeeViewModel.TelephoneNo,
                        Email = employeeViewModel.Email,
                        DateOfBirth = employeeViewModel.DateOfBirth,
                        BloodGroup = employeeViewModel.BloodGroup,
                        BankAccountInfo = employeeViewModel.BankAccountInfo,
                        NIDNo = employeeViewModel.NIDNo,
                    }
                };
                _employeeRepository.Add(employee);
                return RedirectToAction("Index");
            
            }
            return View(employeeViewModel);

        }

        public IActionResult Delete(int id) { 
            var employee= _employeeRepository.Get(id);
            if (employee == null)
            {
                return NotFound();
            }

            _employeeRepository.Delete(employee);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id) 
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Map to EmployeeViewModel for the view
            var employeeViewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                EmployeeId = employee.EmployeeId,
                PresentAddress = employee.PersonalInformation.PresentAddress,
                PermanentAddress = employee.PersonalInformation.PermanentAddress,
                FathersName = employee.PersonalInformation.FathersName,
                MothersName = employee.PersonalInformation.MothersName,
                SpousesName = employee.PersonalInformation.SpousesName,
                MobileNo = employee.PersonalInformation.MobileNo,
                TelephoneNo = employee.PersonalInformation.TelephoneNo,
                Email = employee.PersonalInformation.Email,
                DateOfBirth = employee.PersonalInformation.DateOfBirth,
                NIDNo = employee.PersonalInformation.NIDNo,
                BloodGroup = employee.PersonalInformation.BloodGroup,
                BankAccountInfo = employee.PersonalInformation.BankAccountInfo
            };

            return View(employeeViewModel);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel employeeViewModel) {

            if (ModelState.IsValid) { 
                var employee= _employeeRepository.Get(employeeViewModel.Id);
                if (employee == null)
                {
                    return NotFound();
                }

                // Update employee properties
                employee.Name = employeeViewModel.Name;
                employee.EmployeeId = employeeViewModel.EmployeeId;
                employee.PersonalInformation.PresentAddress = employeeViewModel.PresentAddress;
                employee.PersonalInformation.PermanentAddress = employeeViewModel.PermanentAddress;
                employee.PersonalInformation.FathersName = employeeViewModel.FathersName;
                employee.PersonalInformation.MothersName = employeeViewModel.MothersName;
                employee.PersonalInformation.SpousesName = employeeViewModel.SpousesName;
                employee.PersonalInformation.MobileNo = employeeViewModel.MobileNo;
                employee.PersonalInformation.TelephoneNo = employeeViewModel.TelephoneNo;
                employee.PersonalInformation.Email = employeeViewModel.Email;
                employee.PersonalInformation.DateOfBirth = employeeViewModel.DateOfBirth;
                employee.PersonalInformation.NIDNo = employeeViewModel.NIDNo;
                employee.PersonalInformation.BloodGroup = employeeViewModel.BloodGroup;
                employee.PersonalInformation.BankAccountInfo = employeeViewModel.BankAccountInfo;

                _employeeRepository.Update(employee);
                return RedirectToAction("Index");

            }

            return View(employeeViewModel);


        }

        public IActionResult Details(int id) {

            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                return NotFound();
            }

            // Map to EmployeeViewModel for the view
            var employeeViewModel = new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                EmployeeId = employee.EmployeeId,
                PresentAddress = employee.PersonalInformation.PresentAddress,
                PermanentAddress = employee.PersonalInformation.PermanentAddress,
                FathersName = employee.PersonalInformation.FathersName,
                MothersName = employee.PersonalInformation.MothersName,
                SpousesName = employee.PersonalInformation.SpousesName,
                MobileNo = employee.PersonalInformation.MobileNo,
                TelephoneNo = employee.PersonalInformation.TelephoneNo,
                Email = employee.PersonalInformation.Email,
                DateOfBirth = employee.PersonalInformation.DateOfBirth,
                NIDNo = employee.PersonalInformation.NIDNo,
                BloodGroup = employee.PersonalInformation.BloodGroup,
                BankAccountInfo = employee.PersonalInformation.BankAccountInfo
            };

            return View(employeeViewModel);

        }
    }
}
