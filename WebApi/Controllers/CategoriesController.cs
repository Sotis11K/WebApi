using Infrastructure.Contexts;
using Infrastructure.Factories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ApiContexts contexts) : ControllerBase
{
    private readonly ApiContexts _contexts = contexts;


    [HttpGet]

    public async Task<IActionResult> GetAll()
    {
        var categories = await _contexts.Categories.OrderBy(o => o.CategoryName).ToListAsync();
        return Ok(CategoryFactory.Create(categories));
    }

}
