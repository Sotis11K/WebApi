

using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Filters;

namespace ASPNET.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(ApiContexts context) : ControllerBase
{
    private readonly ApiContexts _context = context;
    [HttpGet]
    [UseApiKey]
    public async Task<IActionResult> GetAll(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 10)
    {

        var query = _context.Courses.Include(i => i.Category).AsQueryable();

        if (!string.IsNullOrWhiteSpace(category) && category != "all")
        {
            query = query.Where(x => x.Category!.CategoryName == category);
        }

        if (!string.IsNullOrEmpty(searchQuery))
        {
            query = query.Where(x => x.Title.Contains(searchQuery) || x.Author.Contains(searchQuery));
        }


        query = query.OrderByDescending(o => o.Id);

        var courses = await query.ToListAsync();


        var response = new CourseResult
        {
            Succeeded = true,
            TotalItems = await query.CountAsync(),
        };

        response.TotalPages = (int)Math.Ceiling(response.TotalItems / (double)pageSize);
        response.Courses = CourseFactory.Create(await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync()); 




        return Ok(response);
    }


    [HttpGet("{id}")]
    [UseApiKey]

    public async Task<IActionResult> GetOne(int id)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course == null)
        {
            return NotFound();
        }

        return Ok(course);
    }


    [HttpPost]
    [UseApiKey]
    [Authorize]
    public async Task<IActionResult> AddCourse([FromBody] CourseEntity course)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOne), new { id = course.Id }, course);
    }



    [HttpPut("{id}")]
    [UseApiKey]
    [Authorize]
    public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseEntity updatedCourse)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var course = await _context.Courses.FindAsync(id);

        if (course == null)
        {
            return NotFound();
        }

        course.IsBestSeller = updatedCourse.IsBestSeller ?? course.IsBestSeller;
        course.Image = updatedCourse.Image ?? course.Image;
        course.Title = updatedCourse.Title ?? course.Title;
        course.Author = updatedCourse.Author ?? course.Author;
        course.Price = updatedCourse.Price ?? course.Price;
        course.DiscountPrice = updatedCourse.DiscountPrice ?? course.DiscountPrice;
        course.Hours = updatedCourse.Hours ?? course.Hours;
        course.LikesInProcent = updatedCourse.LikesInProcent ?? course.LikesInProcent;
        course.LikesInNumbers = updatedCourse.LikesInNumbers ?? course.LikesInNumbers;

        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
        return Ok(course);
    }



    [HttpDelete]
    [UseApiKey]
    [Authorize]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);

        if (course == null)
        {
            return NotFound();
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        return Ok(course);
    }
}
