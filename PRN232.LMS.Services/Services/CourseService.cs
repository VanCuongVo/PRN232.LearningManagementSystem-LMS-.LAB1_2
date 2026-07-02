using Microsoft.EntityFrameworkCore;
using PRN232.LMS.Repositories.Entities;
using PRN232.LMS.Repositories.RequestModel;
using PRN232.LMS.Repositories.ResponseModel;
using PRN232.LMS.Repositories.IRepositories;
using PRN232.LMS.Services.Extensions;
using PRN232.LMS.Services.IServices;
using PRN232.LMS.Services.Utility;

namespace PRN232.LMS.Services.Services
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<CourseResponse>> CreateAsync(CreateCourseRequest request)
        {
            var createCourse = new Course
            {
                Coursename = request.CourseName,
                Semesterid = request.SemesterId,
                Coursecode = request.Coursecode
            };
            var course = await _unitOfWork.Courses.AddAsync(createCourse);
            await _unitOfWork.SaveChangesAsync();
            var courseFromDb = await _unitOfWork.Courses.GetQueryable().Include(x => x.Semester).FirstOrDefaultAsync(x => x.Courseid == course.Courseid);

            return new ApiResponse<CourseResponse>
            {
                success = true,

                message = "Create course successfully",

                Data = courseFromDb.ToCourseResponse()
            };
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int id)
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course != null)
            {
                await _unitOfWork.Courses.DeleteAsync(course.Courseid);

                await _unitOfWork.SaveChangesAsync();

                return new ApiResponse<bool>
                {
                    success = true,
                    message = "Delete course successfully"
                };
            }

            return new ApiResponse<bool>
            {
                success = false,
                message = "Delete course fails"
            };

        }

        public async Task<ApiResponse<object>> GetAllAsync(QueryParameters query)
        {
            var coursesQuery = _unitOfWork.Courses.GetQueryable().Include(x => x.Semester).
                                                                      Search(query).Expand(query);
            var totalItems = await coursesQuery.CountAsync();
            var courses = await coursesQuery.Sort(query).Paging(query).ToListAsync();
            var response = courses.ToCourseResponseList();

            var shapedData = response.SelectFields(query.Fields);
            return new ApiResponse<object>
            {
                success = true,
                message = "Get courses successfully",
                Data = shapedData,

                pagination = new PaginationMetadata
                {
                    Page = query.Page,
                    PageSize = query.Size,
                    TotalItems = totalItems,

                    TotalPages = (int)Math.Ceiling(
                (double)totalItems / query.Size)
                }
            };
        }

        public async Task<CourseResponse?> GetByIdAsync(int id)
        {
            var existingCourse = await _unitOfWork.Courses
                 .GetQueryable()
                 .Include(x => x.Semester).Include(x => x.Enrollments).ThenInclude(x => x.Student)
                 .FirstOrDefaultAsync(
                     x => x.Courseid == id);

            if (existingCourse == null)
            {
                return null;
            }

            return CourseMapperExtension.ToCourseResponse(existingCourse);
        }

        public async Task<ApiResponse<object>> GetEnrollmentsAsync(int courseId, QueryParameters query)
        {
            var enrollmentsQuery = _unitOfWork.Enrollments.GetQueryable().Where(x => x.Courseid == courseId).Expand(query).Search(query);
            var totalItems = await enrollmentsQuery.CountAsync();
            var enrollments = await enrollmentsQuery.Sort(query).Paging(query).ToListAsync();
            var response = enrollments.Select(x => x.ToCourseEnrollmentResponse()).ToList();
            var shapedData = response.SelectFields(query.Fields);
            return new ApiResponse<object>
            {
                success = true,
                message = "Get courses enrollments successfull",
                Data = shapedData,

                pagination = new PaginationMetadata
                {
                    Page = query.Page,
                    PageSize = query.Size,
                    TotalItems = totalItems,

                    TotalPages = (int)Math.Ceiling(
                (double)totalItems / query.Size)
                }
            };
        }

        public async Task<ApiResponse<CourseResponse>> UpdateAsync(int id, UpdateCourseRequest request)
        {
            var course =
                await _unitOfWork.Courses.GetByIdAsync(id);

            if (course == null)
            {
                return new ApiResponse<CourseResponse>
                {
                    success = false,
                    message = "Course not found"
                };
            }
            course.Coursename = request.CourseName;
            course.Semesterid = request.SemesterId;
            course.Coursecode = request.Coursecode;
            await _unitOfWork.Courses.UpdateAsync(course);
            await _unitOfWork.SaveChangesAsync();
            var courseFromDb = await _unitOfWork.Courses.GetQueryable().Include(x => x.Semester).FirstOrDefaultAsync(x => x.Courseid == course.Courseid);
            return new ApiResponse<CourseResponse>
            {
                success = true,
                message = "Update course successfully",
                Data = courseFromDb.ToCourseResponse()
            };
        }
    }

}