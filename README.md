# PRN232 Learning Management System (LMS)

> RESTful API cho bài tập môn PRN232 — Learning Management System.

## Mô tả

Dự án này là một hệ thống quản lý đào tạo (LMS) đơn giản được triển khai bằng ASP.NET Core Web API. Nó cung cấp các chức năng cơ bản cho quản lý môn học, khóa học, sinh viên, học kỳ, ghi danh và xác thực người dùng.

## Tính năng chính

- Xác thực & phân quyền (JWT)
- Quản lý môn học (`SubjectController`)
- Quản lý khóa học (`CourseController`)
- Quản lý sinh viên (`StudentController`)
- Quản lý học kỳ (`SemesterController`)
- Quản lý ghi danh (`EnrollmentController`)
- API trả về nhiều định dạng (JSON, XML, CSV, HTML)
- Swagger UI để khám phá API

## Kiến trúc & cấu trúc mã

- `PRN232.LMS.API/` — ASP.NET Core Web API (entrypoint)
- `PRN232.LMS.Models/` — Các entity, request/response models và validation attributes
- `PRN232.LMS.Services/` — Business logic
- `PRN232.LMS.Repositories/` — Lớp truy xuất dữ liệu

## Công nghệ

- .NET 8 (TargetFramework: net8.0)
- ASP.NET Core Web API
- Entity Framework Core 8 + Npgsql (PostgreSQL)
- Swagger (Swashbuckle)
- FluentValidation

## Yêu cầu trước khi chạy

- .NET 8 SDK
- PostgreSQL database (hoặc dùng docker-compose để khởi động DB tự động)
- (Tùy chọn) Docker & Docker Compose

## Cấu hình môi trường

Sao chép và chỉnh sửa `appsettings.Development.json` hoặc set các biến môi trường cần thiết:

- `ConnectionStrings:DefaultConnection` — chuỗi kết nối PostgreSQL
- `Jwt:Key`, `Jwt:Issuer`, `Jwt:Audience` — cấu hình JWT

## Chạy ứng dụng (local)

1. Cập nhật chuỗi kết nối trong `PRN232.LMS.API/appsettings.Development.json`.
2. Từ thư mục gốc của solution, chạy:

```powershell
dotnet build
cd PRN232.LMS.API
dotnet run
```

API mặc định sẽ được phục vụ tại `https://localhost:5001` (hoặc port được cấu hình trong launch settings).

## Chạy với Docker Compose

Nếu bạn muốn chạy toàn bộ stack (ứng dụng + DB) dùng Docker:

```bash
docker compose up --build
```

Compose file có sẵn tại thư mục gốc (`docker-compose.yml`) để khởi động dịch vụ và database.

## Migrations (EF Core)

Nếu cần áp dụng migration thủ công:

```powershell
cd PRN232.LMS.API
dotnet ef database update --project ../PRN232.LMS.API/ --startup-project ../PRN232.LMS.API/
```

Đảm bảo cài `dotnet-ef` nếu chưa có: `dotnet tool install --global dotnet-ef`.

## Tài nguyên API (tổng quan)

Các controller chính (có thể tham khảo trong `PRN232.LMS.API/Controllers`):

- `AuthController` — đăng nhập, refresh token
- `CourseController` — CRUD khóa học
- `SubjectController` — CRUD môn học
- `StudentController` — CRUD sinh viên
- `SemesterController` — CRUD học kỳ
- `EnrollmentController` — ghi danh học phần

Mở Swagger UI để xem chi tiết endpoint và yêu cầu mẫu: `https://localhost:5001/swagger` (hoặc đường dẫn tương ứng).

## Kiến nghị đóng góp

1. Fork repository
2. Tạo branch tính năng: `feature/my-feature`
3. Tạo pull request mô tả thay đổi

## License

Project này là bài lab cho mục đích học tập. Ghi rõ nguồn khi tái sử dụng.

---

Nếu bạn muốn, mình có thể mở rộng README với hướng dẫn chi tiết cho từng endpoint, ví dụ request/response hoặc file environment mẫu. Bạn muốn bao gồm phần đó không?
