using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using System.Threading.Tasks;
using PaymentAPI.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PaymentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PaymentDetailController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public PaymentDetailController(ApiDbContext context){
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentItems()
        {
            var item = await _context.PaymentDetails.ToListAsync();
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(PaymentItem data){
            if(ModelState.IsValid){
                await _context.PaymentDetails.AddAsync(data);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetPaymentItems), new {id = data.paymentDetailId}, data);
            }
                return new JsonResult("Something went wrong") {StatusCode = 500};
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItems(int id){
            var items = await _context.PaymentDetails.FirstOrDefaultAsync(x=> x.paymentDetailId == id);

            if(items== null)
                return NotFound();
            return Ok(items);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, PaymentItem item)
        {
            if(id!=item.paymentDetailId){
                return BadRequest();
            }
            var existItem = await _context.PaymentDetails.FirstOrDefaultAsync(x=> x.paymentDetailId == id);

            if(existItem == null)
                return NotFound();

            existItem.paymentDetailId = item.paymentDetailId;
            existItem.cardOwnerName = item.cardOwnerName;
            existItem.expirationDate = item.expirationDate;
            existItem.securityCode = item.securityCode;
            
            
            await _context.SaveChangesAsync();
            return Ok(existItem);
            
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id){

            var existItem = await _context.PaymentDetails.FirstOrDefaultAsync(x=> x.paymentDetailId == id);

            if(existItem == null)
                return NotFound();

            _context.PaymentDetails.Remove(existItem);
            await _context.SaveChangesAsync();
            return Ok(existItem);
        }
    
    }
}