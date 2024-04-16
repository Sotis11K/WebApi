using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Filters;

namespace ASPNET.Controllers;

[Route("api/[controller]")]
[ApiController]
[UseApiKey]
public class SubscribeController(ApiContexts context) : ControllerBase
{

    private readonly ApiContexts _context = context;

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribersEntity entity)
    {
        if (!ModelState.IsValid) {
            return BadRequest();
        }
        else {
            if (await _context.Subscribers.AnyAsync(x => x.Email == entity.Email)) {
                return Conflict();
            }
            else
            {
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return Ok();
            }
        }

    }


    [HttpDelete("{email}")]
    public async Task<IActionResult> Unsubscribe(string email)
    {
        var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);

        if (subscriber == null)
        {
            return NotFound();
        }

        _context.Subscribers.Remove(subscriber);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
