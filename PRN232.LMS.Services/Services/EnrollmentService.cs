using Microsoft.EntityFrameworkCore;
using PRN232.LMS.Repositories.Entities;
using PRN232.LMS.Repositories.RequestModel;
using PRN232.LMS.Repositories.ResponseModel;
using PRN232.LMS.Repositories.IRepositories;
using PRN232.LMS.Services.Extensions;
using PRN232.LMS.Services.Interfaces;
using PRN232.LMS.Services.Utility;

namespace PRN232.LMS.Services.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _unitOFWork;

        public EnrollmentService(IUnitOfWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }

        public async Task<ApiResponse<EnrollmentResponse>> CreateAsync(CreateEnrollmentRequest request)
        {
            var enrollment = new Enrollment
            {
                Studentid = request.StudentId,
                Courseid = request.CourseId,
                Enrolldate = DateTime.SpecifyKind(request.EnrollDate, DateTimeKind.Utc),
                Status = request.Status,
            };
            await _unitOFWork.Enrollments.AddAsync(enrollment);
            await _unitOFWork.SaveChangesAsync();

            enrollment = await _unitOFWork.Enrollments.GetQueryable().Include(x => x.Student).Include(x => x.Course).FirstAsync(x => x.Enrollmentid == enrollment.Enrollmentid);
            return new ApiResponse<EnrollmentResponse>
            {
                success = true,
                message = "Create enrollment successfully",
                Data = enrollment.ToEnrollmentResponse()
            };
        }

        public async Task<ApiResponse<object>> GetAllAsync(QueryParameters query)
        {
            var enrollermentQuery = _unitOFWork.Enrollments.GetQueryable().Include(x => x.Student).Include(x => x.Course).Search(query).Expand(query);
            var totalItems = await enrollermentQuery.CountAsync();
            var enrollments = await enrollermentQuery.Sort(query).Paging(query).ToListAsync();
            var result = enrollments.ToEnrollmentResponseList();

            var shapedData = result.SelectFields(query.Fields);
            return new ApiResponse<object>
            {
                success = true,
                message = "Get enrollments successfully",
                Data = shapedData,
                pagination = new PaginationMetadata
                {
                    Page = query.Page,
                    PageSize = query.Size,
                    TotalItems = totalItems,
                    TotalPages =
                            (int)Math.Ceiling(
                                (double)totalItems
                                / query.Size)
                }
            };
        }

        public async Task<EnrollmentResponse?> GetByIdAsync(int id)
        {
            var enrollment = await _unitOFWork.Enrollments.GetQueryable()
                .Include(x => x.Student)
                .Include(x => x.Course)
                .FirstOrDefaultAsync(x => x.Enrollmentid == id);

            if (enrollment == null)
            {
                return null;
            }
            return enrollment.ToEnrollmentResponse();
        }

        public async Task<ApiResponse<EnrollmentResponse?>> UpdateAsync(int id, UpdateEnrollmentRequest request)
        {
            var enrollment = await _unitOFWork.Enrollments.GetQueryable().FirstOrDefaultAsync(x => x.Enrollmentid == id);

            if (enrollment == null)
            {
                return new ApiResponse<EnrollmentResponse?>
                {
                    success = false,
                    message = $"Enrollment with id {id} not found",
                    Data = null
                };
            }

            enrollment.Studentid = request.StudentId;
            enrollment.Courseid = request.CourseId;
            enrollment.Enrolldate = request.EnrollDate;
            enrollment.Status = request.Status;

            await _unitOFWork.Enrollments.UpdateAsync(enrollment);
            await _unitOFWork.SaveChangesAsync();

            enrollment = await _unitOFWork.Enrollments.GetQueryable()
      .Include(x => x.Student)
      .Include(x => x.Course)
      .FirstAsync(x => x.Enrollmentid == id);
            return new ApiResponse<EnrollmentResponse?>
            {
                success = true,
                message = "Update enrollment successfully",
                Data = enrollment.ToEnrollmentResponse()
            };
        }

    }
}