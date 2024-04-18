using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models;

public class CourseResult
{
    public bool Succeeded { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<Course>? Courses { get; set; }

}
