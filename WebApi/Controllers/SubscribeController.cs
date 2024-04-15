using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNET.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscribeController(ApiContexts context) : ControllerBase
{

    private readonly ApiContexts _context = context;

    [HttpPost]
    public async Task<IActionResult> Subscribe(SubscribersEntity entity)
    {
        if(!ModelState.IsValid){
            return BadRequest();
        }

        else{
            if(await _context.Subscribers.AnyAsync(x => x.Email == entity.Email)){
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

    [HttpDelete]
    public async Task<IActionResult> Unsubscribe(string email)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        else
        {
            
            var subscriberEntity = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
            if (subscriberEntity == null) 
            {
                return NotFound();
            }

            _context.Remove(subscriberEntity);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
