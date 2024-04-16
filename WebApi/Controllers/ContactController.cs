using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(ApiContexts context) : ControllerBase
    {
        private readonly ApiContexts _context = context;

        //[HttpPost]
        //public async Task<IActionResult> Contact(ContactEntity entity)
        //{
        //}


    }
}
