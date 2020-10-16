using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // GET: api/PhoneBooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhoneBook>>> GetPhoneBooks()
        {
            return await _context.PhoneBooks.ToListAsync();
        }

        // GET: api/PhoneBooks/5
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<PhoneBook>> GetPhoneBooks(int id)
        {
            var phoneBook = await _context.PhoneBooks.FirstOrDefaultAsync(n => n.Id == id);

            if (phoneBook == null)
            {
                return NotFound();
            }

            return phoneBook;
        }

        [HttpGet("entry/{id}")]
        public async Task<ActionResult<PhoneBook>> GetEntry(int id)
        {
            //var phoneBook = await _context.PhoneBooks.FirstOrDefaultAsync(n => n.Id == id);

            //if (phoneBook == null)
            //{
            //    return NotFound();
            //}

            //return phoneBook;

            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AddEntry(int id, PhoneBook phoneBook)
        {
            //if (id != phoneBook.Id)
            //{
            //    return BadRequest();
            //}

            //_context.Entry(phoneBook).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PhoneBookExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();

            throw new NotImplementedException();
        }
    }
}
