using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopController : ControllerBase
    {


        //private static List<laptop> ListOflaptops = new List<laptop>
        //{
        //    new laptop {
        //        Id= 1,
        //        Name="Name 1",
        //        CPU="CPU 1",
        //        Harddisk="harddisk 1",
        //        Ram="16G"},
        //    new laptop {
        //        Id= 2,
        //        Name="Name 2",
        //        CPU="CPU 2",
        //        Harddisk="harddisk 2",
        //        Ram="32G"}
        //};
        private readonly DataContext _context;

        public LaptopController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<laptop>>> Get()
        {
            return Ok(await _context.laptops.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<laptop>> Get(int id)
        {
            var laptop = await _context.laptops.FindAsync(id);
            if (laptop == null) return BadRequest("Laptop not found.");
            return Ok( laptop);
        }

        [HttpPost]
        public async Task<ActionResult<List<laptop>>> AddLaptop(laptop newlaptop)
        {
            _context.laptops.Add(newlaptop);
            await _context.SaveChangesAsync();
            return Ok(await _context.laptops.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<laptop>>> UpdateLaptop(laptop newlaptop)
        {
            var laptop = await _context.laptops.FindAsync(newlaptop.Id);
            if (laptop == null) return BadRequest("Laptop not found.");
            laptop.Name = newlaptop.Name;
            laptop.CPU = newlaptop.CPU;
            laptop.Harddisk = newlaptop.Harddisk;
            laptop.Ram = newlaptop.Ram;
            await _context.SaveChangesAsync();
            return Ok(await _context.laptops.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<laptop>>> DeleteLaptop(int id)
        {
            var laptop = await _context.laptops.FindAsync(id);
            if (laptop == null) return BadRequest("Laptop not found.");
            _context.laptops.Remove(laptop);
            await _context.SaveChangesAsync();
            return Ok(await _context.laptops.ToListAsync());
        }

    }
}
