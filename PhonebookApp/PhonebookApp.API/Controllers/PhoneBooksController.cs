using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhonebookApp.Data;
using PhonebookApp.Domain;

namespace PhonebookApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBooksController : ControllerBase
    {
        private readonly PhonebookAppContext _context;

        public PhoneBooksController(PhonebookAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneBook>>> GetPhoneBooks()
        {
            //_context.Database.EnsureDeleted();
            //_context.Database.EnsureCreated();

            return await _context.PhoneBooks.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<PhoneBook>> GetPhoneBooks([FromBody]PhoneBook phoneBook)
        {
            //_context.Database.EnsureDeleted();
            //_context.Database.EnsureCreated();

            var pBook = await _context.PhoneBooks.FirstOrDefaultAsync(n => n.Id == phoneBook.Id);
            if (pBook == null)
            {
                _context.PhoneBooks.Add(phoneBook);
            }
            else
            {
                pBook.Entries = phoneBook.Entries;
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
