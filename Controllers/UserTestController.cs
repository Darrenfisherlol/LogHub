using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserTestSpace.Models;

namespace LogHubStart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTestController : ControllerBase
    {
        private readonly UserTestContext _context;

        public UserTestController(UserTestContext context)
        {
            _context = context;
        }

        // GET: api/UserTest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTest>>> GetUserTests()
        {
            return await _context.UserTests.ToListAsync();
        }

        // GET: api/UserTest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTest>> GetUserTest(int id)
        {
            var userTest = await _context.UserTests.FindAsync(id);

            if (userTest == null)
            {
                return NotFound();
            }

            return userTest;
        }

        // PUT: api/UserTest/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTest(int id, UserTest userTest)
        {
            if (id != userTest.id)
            {
                return BadRequest();
            }

            _context.Entry(userTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTestExists(id))
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

        // POST: api/UserTest
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserTest>> PostUserTest(UserTest userTest)
        {
            _context.UserTests.Add(userTest);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetUserTest", new { id = userTest.id }, userTest);
            // use nameof -  The C# nameof keyword is used to avoid hard-coding the action name in the CreatedAtAction call.
            return CreatedAtAction(nameof(GetUserTest), new { id = userTest.id }, userTest);
        }

        // DELETE: api/UserTest/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTest(int id)
        {
            var userTest = await _context.UserTests.FindAsync(id);
            if (userTest == null)
            {
                return NotFound();
            }

            _context.UserTests.Remove(userTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserTestExists(int id)
        {
            return _context.UserTests.Any(e => e.id == id);
        }
    }
}
