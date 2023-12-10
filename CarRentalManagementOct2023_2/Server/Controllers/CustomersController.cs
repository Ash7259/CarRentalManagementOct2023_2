using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarRentalManagementOct2023_2.Server.Data;
using CarRentalManagementOct2023_2.Shared.Domain;
using CarRentalManagementOct2023_2.Server.IRepository;
using CarRentalManagementOct2023_2.Server.IRepository;
using CarRentalManagementOct2023_2.Shared.Domain;

namespace CarRentalManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //punlicCustomerController(ApplicationDbContext context)
        public CustomerController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Customer
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<customer>>> GetCustomer()
        public async Task<IActionResult> GetCustomer()
        {
            //Refactored
            //return await _context.Customer.ToListAsync();
            var Customer = await _unitOfWork.Customers.GetAll();
            return Ok(Customer);
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<customer>> Getcustomer(int id)
        public async Task<ActionResult<Customer>> Getcustomer(int id)
        {
            //Refactored
            //var customer = await _context.Customer.FindAsync(id);
            var customer = await _unitOfWork.Customers.Get(q => q.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            //Refactored
            return Ok(customer);
        }

        // PUT: api/Customer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putcustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(customer).State = EntityState.Modified;
            _unitOfWork.Customers.Update(customer);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!customerExists(id))
                if (!await CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> Postcustomer(Customer customer)
        {
            //Refactored
            //_context.Customer.Add(customer);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Customers.Insert(customer);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("Getcustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletecustomer(int id)
        {
            //Refactored
            //var customer = await _context.Customer.FindAsync(id);
            var customer = await _unitOfWork.Customers.Get(q => q.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Customer.Remove(customer);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Customers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool customerExists(int id)
        private async Task<bool> CustomerExists(int id)
        {
            //Refactored
            //return _context.Customer.Any(e => e.Id == id);
            var customer = await _unitOfWork.Customers.Get(q => q.Id == id);
            return customer != null;
        }
    }
}