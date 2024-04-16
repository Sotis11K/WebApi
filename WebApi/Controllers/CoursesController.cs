using Infrastructure.Contexts;
using Infrastructure.Entities;
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
    public async Task<IActionResult> GetAll()
    {
        var courses = await _context.Courses.ToListAsync();
        if(courses == null)
        {
            return NotFound();
        }
        return Ok(courses);
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
        course.CategoryName = updatedCourse.CategoryName ?? course.CategoryName;

        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
        return Ok(course);
    }

    

    [HttpPut]
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


