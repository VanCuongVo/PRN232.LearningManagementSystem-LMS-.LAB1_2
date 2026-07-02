using Microsoft.EntityFrameworkCore;
using PRN232.LMS.Repositories.Entities;
using PRN232.LMS.Repositories.RequestModel;

namespace PRN232.LMS.Services.Utility
{
    public static class CourseQueryExtension
    {
        public static IQueryable<Course> Search(this IQueryable<Course> query, QueryParameters request)
        {
            if (string.IsNullOrWhiteSpace(request.Search))
            {
                return query;
            }
            var search = request.Search.ToLower();
            return query.Where(x => x.Coursename.ToLower().Contains(search));
        }

        public static IQueryable<Course> Sort(this IQueryable<Course> query, QueryParameters request)
        {
            return request.Sort switch
            {
                "courseName" => query.OrderBy(x => x.Coursename),
                "-courseName" => query.OrderByDescending(x => x.Coursename),
                _ => query.OrderBy(x => x.Courseid)
            };
        }

        public static IQueryable<Course> Paging(this IQueryable<Course> query, QueryParameters request)
        {
            return query.Skip((request.Page - 1) * request.Size).Take(request.Size);
        }

        public static IQueryable<Course> Expand(this IQueryable<Course> query, QueryParameters request)
        {
            if (string.IsNullOrWhiteSpace(request.Expand))
            {
                return query;
            }
            var expands = request.Expand.Split(",");

            foreach (var item in expands)
            {
                switch (item.ToLower())
                {
                    case "enrollment":
                        query = query.Include(x => x.Enrollments);
                        break;
                    case "student":
                        query = query.Include(x => x.Enrollments).ThenInclude(x => x.Student);
                        break;
                }
            }
            return query;
        }
    }
}