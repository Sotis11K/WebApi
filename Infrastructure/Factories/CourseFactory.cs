using Infrastructure.Entities;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Factories;

public class CourseFactory
{
    public static Course Create(CourseEntity entity)
    {
        try
        {
            return new Course
            {
                Id = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                Price = entity.Price,
                DiscountPrice = entity.DiscountPrice,
                Hours = entity.Hours,
                IsBestSeller = entity.IsBestSeller,
                LikesInNumbers = entity.LikesInNumbers,
                LikesInProcent = entity.LikesInProcent,
                Image = entity.Image,
                BigImage = entity.BigImage,
                Category = entity.Category!.CategoryName
            };
        }
        catch { }
        return null!;
    }


    public static IEnumerable<Course> Create(List<CourseEntity> entities)
    {

        List<Course> courses = [];

        try
        {
            foreach (var entity in entities)
            {
                courses.Add(Create(entity));
            }
        }
        catch { }
        return courses;
    }
}
