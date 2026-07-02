using PRN232.LMS.Repositories.Entities;
using PRN232.LMS.Repositories.RequestModel;

namespace PRN232.LMS.Services.Utility
{
    public static class StubjectQueryExtensions
    {
        public static IQueryable<Subject> Search(this IQueryable<Subject> query, QueryParameters request)
        {
            if (string.IsNullOrEmpty(request.Search))
            {
                return query;
            }
            var search = query.Where(x => x.Subjectname.ToLower().Contains(request.Search.ToLower()));
            return search;
        }

        public static IQueryable<Subject> Sort(this IQueryable<Subject> query, QueryParameters request)
        {
            return request.Sort switch
            {
                "subjectName" => query.OrderBy(x => x.Subjectname),
                "-subjectName" => query.OrderByDescending(x => x.Subjectname),
                _ => query.OrderBy(x => x.Subjectid)
            };
        }

        public static IQueryable<Subject> Paging(
            this IQueryable<Subject> query,
            QueryParameters request)
        {
            return query.Skip((request.Page - 1) * request.Size).Take(request.Size);
        }
    }
}