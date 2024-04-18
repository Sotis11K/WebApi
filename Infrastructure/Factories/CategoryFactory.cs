using Infrastructure.Entities;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Factories;

public class CategoryFactory
{
    public static Category Create(CategoriesEntity entity)
    {
        try
        {
            return new Category
            {
                Id = entity.Id,
                CategoryName = entity.CategoryName,
            }; 
        }
        catch { }
        return null!;
    }


    public static IEnumerable<Category> Create(List<CategoriesEntity> entities)
    {

        List<Category> categories = [];

        try
        {
            foreach(var entity in entities)
            {
                categories.Add(Create(entity));
            }
        }
        catch { }
        return categories;
    }
}
