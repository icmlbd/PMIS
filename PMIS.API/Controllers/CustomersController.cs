using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PMIS.Models.DTOs.Customers;
using PMIS.Models.EntityModels;
using PMIS.Services;
using PMIS.Services.Abstractions;

namespace PMIS.API.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;
        IPaymentGatewayService _paymentGatewayService; 
        IMapper _mapper; 

        public CustomersController(ICustomerService customerService, IMapper mapper,IPaymentGatewayService paymentGatewayService)
        {
            _customerService = customerService;
            _mapper = mapper;
            _paymentGatewayService = paymentGatewayService;
        }


        // GET api/customers 
        [HttpGet]
        public IActionResult GetCustomers([FromQuery]CustomerRequestDTO model)
        {
            _paymentGatewayService.GetPaymentGateway();

            var customers = _customerService.GetCustomers(model);

            var customerResponseDtos = _mapper.Map<List<CustomerResponseDTO>>(customers);
            return Ok(customerResponseDtos);
        }


        // GET api/customers/233 

        [HttpGet("{id}", Name ="GetById")]
        public IActionResult GetById(int id)
        {
            var customer = _customerService.Get(id);

            if (customer == null) {
                return NotFound("The customer doesn't exists!");
            }

            var customerResponseDto = _mapper.Map<CustomerResponseDTO>(customer);

            return Ok(customerResponseDto);
        }
        
        // POST api/customers

        [HttpPost]
        public IActionResult Post([FromBody]CustomerCreateDTO model)
        {
            if (ModelState.IsValid)
            {
                var customer = _mapper.Map<Customer>(model);
                var isSaved = _customerService.Add(customer);

                if (isSaved)
                {
                    var customerRetrieve = _customerService.Get(customer.Id);
                    var customerResponse = _mapper.Map<CustomerResponseDTO>(customerRetrieve);
                    
                    //api/customers/id 
                    return CreatedAtAction("GetById",new {id=customer.Id}, customerResponse);
                }
            }

            return BadRequest("Customer could not be saved!");
        }

        // PUT api/customers/id 
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomerUpdateDTO model)
        {
            if (ModelState.IsValid)
            {
                var existingCustomer = _customerService.Get(id);

                if(existingCustomer == null)
                {
                    return NotFound("The requested customer not found!"); 
                }

                //copy from model to existing customer 

                _mapper.Map(model, existingCustomer);

                var isUpdated = _customerService.Update(existingCustomer);

                if (isUpdated)
                {
                    return NoContent(); 
                }

            }

            return BadRequest(ModelState); 
        }

        // DELETE api/customers/id 

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _customerService.Get(id);

            if(customer == null)
            {
                return NotFound("No customer found to delete!");
            }

            bool isDeleted = _customerService.Delete(customer);
            if(isDeleted)
            {
                return NoContent();
            }

            return BadRequest("Could not delete the customer!");
        }

        // PATCH api/customers/id 

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, JsonPatchDocument<CustomerUpdateDTO> jsonPatch)
        {
            var existingCustomer = _customerService.Get(id); 

            if(existingCustomer == null)
            {
                return NotFound("No Customer found for this id"); 
            }

            var customerUpdate = _mapper.Map<CustomerUpdateDTO>(existingCustomer);

            jsonPatch.ApplyTo(customerUpdate, ModelState);

            TryValidateModel(customerUpdate);

            if (ModelState.IsValid)
            {
                _mapper.Map(customerUpdate,existingCustomer);

                bool isSuccess = _customerService.Update(existingCustomer);

                if (isSuccess)
                {
                    return NoContent(); 
                }
            }

            return BadRequest(ModelState);

        }


        //api/categories/{categoryId}/customers
        [HttpGet("/api/categories/{categoryId}/customers")]
        public IActionResult GetByCategory(int categoryId, [FromQuery] CustomerRequestDTO model)
        {
            var customers = _customerService.GetCustomers(categoryId, model);

            if(customers == null)
            {
                return NotFound("No customer found!");
            }

            var customerResponse = _mapper.Map<List<CustomerResponseDTO>>(customers);

            return Ok(customerResponse);

        }
       


    }
}
