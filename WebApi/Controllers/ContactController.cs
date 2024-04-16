using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(ApiContexts context) : ControllerBase
    {
        private readonly ApiContexts _context = context;

        [HttpPost]
        [UseApiKey]
        public async Task<IActionResult> Contact(ContactEntity entity)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _context.Contact.AnyAsync(x => x.Email == entity.Email))
            {
                return Conflict();
            }
            else
            {
                await _context.Contact.AddAsync(entity);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }
    }

}
