using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HPCapp.Models;
using Microsoft.AspNetCore.Cors;
using System.Text.RegularExpressions;
using System.Net;

namespace HPCapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ShipDetailController : ControllerBase
    {
        private readonly ShipDBContext _context;

        public ShipDetailController(ShipDBContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipDetail>>> GetShipDetails()
        {
            return await _context.ShipDetails.ToListAsync();
        }

         
        [HttpGet("{id}")]
        public async Task<ActionResult<ShipDetail>> GetShipDetail(int id)
        {
            var shipDetail = await _context.ShipDetails.FindAsync(id);

            if (shipDetail == null)
            {
                return NotFound();
            }

            return shipDetail;
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipDetail(Guid id, ShipDetail shipDetail)
        {
            shipDetail.id = id;
            //if (id != shipDetail.id)
            //{
            //    return BadRequest();
            //}

            _context.Entry(shipDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipDetailExists(id))
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

  
        [HttpPost]
        public async Task<ActionResult<ShipDetail>> PostShipDetail(ShipDetail shipDetail)
        {

          
            if (shipDetail.code != "" && shipDetail.length > 0 && shipDetail.name !="" && shipDetail.width > 0 )
            {
 
            _context.ShipDetails.Add(shipDetail);
            await _context.SaveChangesAsync();
                return CreatedAtAction("GetShipDetail", new { id = shipDetail.id }, shipDetail);
            }
            else
            {
                return BadRequest("Please fill all required fields");

            }


        }

       
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShipDetail>> DeleteShipDetail(Guid id)
        {
            var shipDetail = await _context.ShipDetails.FindAsync(id);
            if (shipDetail == null)
            {
                return NotFound();
            }

            _context.ShipDetails.Remove(shipDetail);
            await _context.SaveChangesAsync();

            return shipDetail;
        }

        private bool ShipDetailExists(Guid id)
        {
            return _context.ShipDetails.Any(e => e.id == id);
        }
    }
}
