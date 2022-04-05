using FundTransferService.Database;
using FundTransferService.Database.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FundTransferService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundTransferController : ControllerBase
    {
        DatabaseContext db;

        public FundTransferController(DatabaseContext datacontext)
        {
            db = datacontext;
        }

        [HttpGet("GetCustomers")]
        public IEnumerable<Customers> GetCustomers()
        {
            return db.Customers.ToList();
        }

        [HttpGet("GetCustomerById/{id}")]
        public Customers GetCustomerById(int id)
        {
            return db.Customers.Find(id);
        }

        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer([FromBody] Customers customerModel)
        {
            try
            {
                db.Customers.Add(customerModel);
                db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, customerModel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
                throw;
            }
        }

    }
}
