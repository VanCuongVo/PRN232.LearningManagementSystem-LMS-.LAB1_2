# Bảng tổng hợp các lỗi và giải pháp khắc phục (LMS Project)

Dưới đây là tổng hợp toàn bộ các lỗi mà hệ thống chấm điểm tự động (grading script) đã báo và các bước cụ thể đã thực hiện để khắc phục chúng:

---

## 1. Lỗi đếm số lượng Project (project-count:3)
* **Thông báo lỗi:** 
  `Expected 3 project(s), found 4: PRN232.LMS.API.csproj, PRN232.LMS.Models.csproj, PRN232.LMS.Repositories.csproj, PRN232.LMS.Services.csproj`
* **Nguyên nhân:** Solution ban đầu chứa 4 project riêng biệt, trong khi đề bài yêu cầu cấu trúc 3 lớp (3-layer architecture) tương đương với tối đa **3 project** `.csproj`.
* **Giải pháp khắc phục:**
  1. Gộp toàn bộ thư mục của project `PRN232.LMS.Models` (Custom, Entities, Enum, RequestModel, ResponseModel) vào project `PRN232.LMS.Repositories`.
  2. Bổ sung các thư viện NuGet cần thiết (Entity Framework Core, Tools, Npgsql) vào project `PRN232.LMS.Repositories.csproj`.
  3. Xóa tham chiếu dự án đến `Models` cũ trong file `.sln` và xóa hẳn thư mục `PRN232.LMS.Models`.
  4. Giữ nguyên namespace `PRN232.LMS.Models.*` của các file đã di chuyển để tránh việc phải sửa đổi code diện rộng ở các tầng API hay Services.

---

## 2. Lỗi không tìm thấy file Validators (file-contains:**/Validators/*.cs)
* **Thông báo lỗi:** 
  `No files matching '**/Validators/*.cs' found in archive.`
* **Nguyên nhân:** 
  1. Các file validator ban đầu nằm sâu bên trong các thư mục con (ví dụ: `Validators/CourseValidators/Command/`), khiến cho glob pattern tìm kiếm của script chấm điểm `**/Validators/*.cs` (chỉ quét trực tiếp trong thư mục con liền kề tên là `Validators`) bị bỏ sót.
  2. Các file validator mới tạo ra chưa được thêm (git add) và commit vào Git, khiến tool lưu trữ `git archive HEAD` của script chấm không quét thấy file.
* **Giải pháp khắc phục:**
  1. Di chuyển toàn bộ các file validator C# trực tiếp ra thư mục gốc `PRN232.LMS.Services/Validators/`.
  2. Xóa bỏ các thư mục con trống.
  3. Thực hiện add và commit toàn bộ thay đổi vào Git.

---

## 3. Lỗi thư mục Middleware (file-exists:**/Middleware/*Exception*.cs)
* **Thông báo lỗi:** 
  `No file matching '**/Middleware/*Exception*.cs' found.`
* **Nguyên nhân:** Thư mục chứa Exception Middleware của project API ban đầu được đặt tên số nhiều là `Middlewares`, trong khi script chấm điểm quét chính xác từ khóa số ít `**/Middleware/`.
* **Giải pháp khắc phục:**
  1. Đổi tên thư mục từ `PRN232.LMS.API/Middlewares/` thành `PRN232.LMS.API/Middleware/`.
  2. Cập nhật lại namespace của các file bên trong thành `PRN232.LMS.API.Middleware`.
  3. Sửa lại dòng khai báo `using PRN232.LMS.API.Middleware;` trong file `Program.cs`.

---

## 4. Lỗi Đăng nhập trả về 500 (POST /api/v1/auth/login)
* **Thông báo lỗi:** 
  `Expected status 200, got 500.`
* **Nguyên nhân:** Trong file `DbSeeder.cs`, các tài khoản (kể cả `admin`) được gán sẵn một password hash giả định dạng chuỗi placeholder (`AQAAAAIAAYagAAAAEL9c5fR0x==`). Khi gọi API đăng nhập, phương thức `BCrypt.Net.BCrypt.Verify()` so sánh chuỗi này và ném ra lỗi định dạng salt/hash không hợp lệ, dẫn tới lỗi Internal Server Error (500).
* **Giải pháp khắc phục:**
  1. Tích hợp thư viện mã hóa `BCrypt.Net-Next` vào tầng Repository.
  2. Sửa đổi phương thức `SeedUsers` trong `DbSeeder.cs` để hash mật khẩu `"123456"` bằng BCrypt thực tế trước khi lưu vào DB.

---

## 5. Lỗi Endpoint 404 khi không truyền Version (POST /api/auth/login)
* **Thông báo lỗi:** 
  `Expected status 200, got 404.`
* **Nguyên nhân:** Hệ thống được cấu hình định tuyến API Version qua phân khúc URL (`api/v{version:apiVersion}/auth`). Khi script chấm điểm gọi trực tiếp endpoint không có version `/api/auth/login`, hệ thống sẽ trả về 404.
* **Giải pháp khắc phục:**
  1. Bổ sung các thuộc tính định tuyến dự phòng (fallback route) không chứa version vào toàn bộ các Controller chính ở tầng V1.
  2. Ví dụ: Thêm `[Route("api/auth")]` song song với `[Route("api/v{version:apiVersion}/auth")]`. 

---

## 6. Lỗi cho phép truy cập nặc danh (Anonymous Access)
* **Thông báo lỗi:** 
  `Expected protected endpoint to reject anonymous request with 401 or 403, got 200 / 201.`
* **Nguyên nhân:** Các API truy xuất dữ liệu danh sách học sinh, khóa học, học phần, môn học, ghi danh ban đầu không được bảo mật bằng cơ chế xác thực JWT, dẫn tới việc bất kỳ request nặc danh nào cũng lấy được dữ liệu.
* **Giải pháp khắc phục:**
  1. Bổ sung attribute `[Authorize]` lên trên đầu khai báo lớp (class-level) của toàn bộ các Controller tài nguyên: `StudentController`, `CourseController`, `SubjectController`, `SemesterController`, và `EnrollmentController`.
  2. Đảm bảo các request không gửi kèm JWT token hợp lệ sẽ ngay lập tức bị chặn lại với mã lỗi 401 Unauthorized trước khi đi vào xử lý logic.
