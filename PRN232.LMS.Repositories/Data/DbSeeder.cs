using System;
using PRN232.LMS.Models.Entities;
using PRN232.LMS.Models.Enum;

namespace PRN232.LMS.Repositories.Data
{
    public static class DbSeeder
    {
        public static void Seed(LmsdbContext context)
        {
            SeedSubjects(context);
            SeedSemesters(context);
            SeedStudents(context);
            SeedUsers(context);
            SeedCourses(context);
            SeedEnrollments(context);
        }

        private static void SeedSubjects(LmsdbContext context)
        {
            if (context.Subjects.Any()) return;

            var subjects = new List<Subject>
            {
                new Subject { Subjectcode = "PRN211", Subjectname = "Basic Cross-Platform Application Programming With .NET", Credit = 3 },
                new Subject { Subjectcode = "PRN221", Subjectname = "Advanced Cross-Platform Application Programming With .NET", Credit = 3 },
                new Subject { Subjectcode = "PRN231", Subjectname = "Building Cross-Platform Back-End Application With .NET", Credit = 3 },
                new Subject { Subjectcode = "PRN232", Subjectname = "Building Cross-Platform Back-End Application With .NET (Advanced)", Credit = 3 },
                new Subject { Subjectcode = "DBI202", Subjectname = "Database Systems", Credit = 3 },
                new Subject { Subjectcode = "SWP391", Subjectname = "Application Development Project", Credit = 3 },
                new Subject { Subjectcode = "SWR302", Subjectname = "Software Requirement", Credit = 3 },
                new Subject { Subjectcode = "SWD392", Subjectname = "Software Architecture and Design", Credit = 3 }
            };

            context.Subjects.AddRange(subjects);
            context.SaveChanges();
        }

        private static void SeedSemesters(LmsdbContext context)
        {
            if (context.Semesters.Any()) return;

            var semesters = new List<Semester>
            {
                new Semester
                {
                    Semestername = "Spring 2025",
                    Startdate = DateTime.SpecifyKind(new DateTime(2025, 1, 6), DateTimeKind.Utc),
                    Enddate = DateTime.SpecifyKind(new DateTime(2025, 4, 30), DateTimeKind.Utc)
                },
                new Semester
                {
                    Semestername = "Summer 2025",
                    Startdate = DateTime.SpecifyKind(new DateTime(2025, 5, 12), DateTimeKind.Utc),
                    Enddate = DateTime.SpecifyKind(new DateTime(2025, 8, 31), DateTimeKind.Utc)
                },
                new Semester
                {
                    Semestername = "Fall 2025",
                    Startdate = DateTime.SpecifyKind(new DateTime(2025, 9, 8), DateTimeKind.Utc),
                    Enddate = DateTime.SpecifyKind(new DateTime(2025, 12, 20), DateTimeKind.Utc)
                },
                new Semester
                {
                    Semestername = "Spring 2026",
                    Startdate = DateTime.SpecifyKind(new DateTime(2026, 1, 5), DateTimeKind.Utc),
                    Enddate = DateTime.SpecifyKind(new DateTime(2026, 4, 28), DateTimeKind.Utc)
                },
                new Semester
                {
                    Semestername = "Summer 2026",
                    Startdate = DateTime.SpecifyKind(new DateTime(2026, 5, 11), DateTimeKind.Utc),
                    Enddate = DateTime.SpecifyKind(new DateTime(2026, 8, 30), DateTimeKind.Utc)
                }
            };

            context.Semesters.AddRange(semesters);
            context.SaveChanges();
        }

        private static void SeedStudents(LmsdbContext context)
        {
            if (context.Students.Any()) return;

            var students = new List<Student>
            {
                new Student
                {
                    Studentcode = "SE171001",
                    Fullname = "Le Hoang Cuong",
                    Email = "cuonglh@fpt.edu.vn",
                    Dateofbirth = DateTime.SpecifyKind(new DateTime(2003, 5, 15), DateTimeKind.Utc),
                    Age = 23,
                    Phonenumber = "0901234001"
                },
                new Student
                {
                    Studentcode = "SE171002",
                    Fullname = "Pham Minh Duc",
                    Email = "ducpm@fpt.edu.vn",
                    Dateofbirth = DateTime.SpecifyKind(new DateTime(2003, 8, 22), DateTimeKind.Utc),
                    Age = 22,
                    Phonenumber = "0901234002"
                },
                new Student
                {
                    Studentcode = "SE171003",
                    Fullname = "Vo Thi Hoa",
                    Email = "hoavt@fpt.edu.vn",
                    Dateofbirth = DateTime.SpecifyKind(new DateTime(2004, 1, 10), DateTimeKind.Utc),
                    Age = 22,
                    Phonenumber = "0901234003"
                },
                new Student
                {
                    Studentcode = "SE171004",
                    Fullname = "Dang Quoc Khanh",
                    Email = "khanhdq@fpt.edu.vn",
                    Dateofbirth = DateTime.SpecifyKind(new DateTime(2003, 11, 3), DateTimeKind.Utc),
                    Age = 22,
                    Phonenumber = "0901234004"
                },
                new Student
                {
                    Studentcode = "SE171005",
                    Fullname = "Bui Thanh Long",
                    Email = "longbt@fpt.edu.vn",
                    Dateofbirth = DateTime.SpecifyKind(new DateTime(2003, 7, 28), DateTimeKind.Utc),
                    Age = 22,
                    Phonenumber = "0901234005"
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();
        }

        private static void SeedUsers(LmsdbContext context)
        {
            if (context.Users.Any()) return;

            var students = context.Students.ToList();

            var users = new List<User>
            {
                new User
                {
                    Username = "admin",
                    PasswordHash = "AQAAAAIAAYagAAAAEL9c5fR0x==", // placeholder hash
                    Role = "Admin",
                    IsActive = true,
                    CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 1, 1), DateTimeKind.Utc)
                },
                new User
                {
                    Username = "lecturer01",
                    PasswordHash = "AQAAAAIAAYagAAAAEL9c5fR0x==",
                    Role = "Lecturer",
                    IsActive = true,
                    CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 1, 15), DateTimeKind.Utc)
                },
                new User
                {
                    Username = "lecturer02",
                    PasswordHash = "AQAAAAIAAYagAAAAEL9c5fR0x==",
                    Role = "Lecturer",
                    IsActive = true,
                    CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 2, 1), DateTimeKind.Utc)
                },
                new User
                {
                    Username = "cuonglh",
                    PasswordHash = "AQAAAAIAAYagAAAAEL9c5fR0x==",
                    Role = "Student",
                    IsActive = true,
                    StudentId = students.FirstOrDefault(s => s.Studentcode == "SE171001")?.Studentid,
                    CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 3, 1), DateTimeKind.Utc)
                },
                new User
                {
                    Username = "ducpm",
                    PasswordHash = "AQAAAAIAAYagAAAAEL9c5fR0x==",
                    Role = "Student",
                    IsActive = true,
                    StudentId = students.FirstOrDefault(s => s.Studentcode == "SE171002")?.Studentid,
                    CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 3, 1), DateTimeKind.Utc)
                },
                new User
                {
                    Username = "hoavt",
                    PasswordHash = "AQAAAAIAAYagAAAAEL9c5fR0x==",
                    Role = "Student",
                    IsActive = true,
                    StudentId = students.FirstOrDefault(s => s.Studentcode == "SE171003")?.Studentid,
                    CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 3, 5), DateTimeKind.Utc)
                },
                new User
                {
                    Username = "khanhdq",
                    PasswordHash = "AQAAAAIAAYagAAAAEL9c5fR0x==",
                    Role = "Student",
                    IsActive = true,
                    StudentId = students.FirstOrDefault(s => s.Studentcode == "SE171004")?.Studentid,
                    CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 3, 10), DateTimeKind.Utc)
                },
                new User
                {
                    Username = "longbt",
                    PasswordHash = "AQAAAAIAAYagAAAAEL9c5fR0x==",
                    Role = "Student",
                    IsActive = true,
                    StudentId = students.FirstOrDefault(s => s.Studentcode == "SE171005")?.Studentid,
                    CreatedAt = DateTime.SpecifyKind(new DateTime(2025, 3, 10), DateTimeKind.Utc)
                }
            };

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static void SeedCourses(LmsdbContext context)
        {
            if (context.Courses.Any()) return;

            var semesters = context.Semesters.ToList();

            var sp25 = semesters.First(s => s.Semestername == "Spring 2025");
            var su25 = semesters.First(s => s.Semestername == "Summer 2025");
            var fa25 = semesters.First(s => s.Semestername == "Fall 2025");
            var sp26 = semesters.First(s => s.Semestername == "Spring 2026");
            var su26 = semesters.First(s => s.Semestername == "Summer 2026");

            var courses = new List<Course>
            {
                new Course { Coursecode = "PRN231-SP25-01", Coursename = "PRN231 - Building Cross-Platform Back-End Application With .NET", Semesterid = sp25.Semesterid },
                new Course { Coursecode = "PRN232-SU25-01", Coursename = "PRN232 - Building Cross-Platform Back-End Application With .NET (Advanced)", Semesterid = su25.Semesterid },
                new Course { Coursecode = "DBI202-SP25-01", Coursename = "DBI202 - Database Systems", Semesterid = sp25.Semesterid },
                new Course { Coursecode = "SWP391-FA25-01", Coursename = "SWP391 - Application Development Project", Semesterid = fa25.Semesterid },
                new Course { Coursecode = "SWR302-SP26-01", Coursename = "SWR302 - Software Requirement", Semesterid = sp26.Semesterid },
                new Course { Coursecode = "SWD392-SU26-01", Coursename = "SWD392 - Software Architecture and Design", Semesterid = su26.Semesterid },
                new Course { Coursecode = "PRN211-SP25-01", Coursename = "PRN211 - Basic Cross-Platform Application Programming With .NET", Semesterid = sp25.Semesterid },
                new Course { Coursecode = "PRN221-FA25-01", Coursename = "PRN221 - Advanced Cross-Platform Application Programming With .NET", Semesterid = fa25.Semesterid },
                new Course { Coursecode = "PRN232-SU26-01", Coursename = "PRN232 - Building Cross-Platform Back-End Application With .NET (Advanced)", Semesterid = su26.Semesterid },
                new Course { Coursecode = "DBI202-SU25-01", Coursename = "DBI202 - Database Systems", Semesterid = su25.Semesterid }
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();
        }

        private static void SeedEnrollments(LmsdbContext context)
        {
            if (context.Enrollments.Any()) return;

            var students = context.Students.ToList();
            var courses = context.Courses.ToList();

            var enrollments = new List<Enrollment>();

            // Student 1 - SE171001 - Le Hoang Cuong
            var student1 = students.First(s => s.Studentcode == "SE171001");
            enrollments.Add(new Enrollment
            {
                Studentid = student1.Studentid,
                Courseid = courses.First(c => c.Coursecode == "PRN231-SP25-01").Courseid,
                Enrolldate = DateTime.SpecifyKind(new DateTime(2025, 1, 6), DateTimeKind.Utc),
                Status = EnrollmentStatus.Completed
            });
            enrollments.Add(new Enrollment
            {
                Studentid = student1.Studentid,
                Courseid = courses.First(c => c.Coursecode == "DBI202-SP25-01").Courseid,
                Enrolldate = DateTime.SpecifyKind(new DateTime(2025, 1, 6), DateTimeKind.Utc),
                Status = EnrollmentStatus.Completed
            });
            enrollments.Add(new Enrollment
            {
                Studentid = student1.Studentid,
                Courseid = courses.First(c => c.Coursecode == "PRN232-SU25-01").Courseid,
                Enrolldate = DateTime.SpecifyKind(new DateTime(2025, 5, 12), DateTimeKind.Utc),
                Status = EnrollmentStatus.Active
            });

            // Student 2 - SE171002 - Pham Minh Duc
            var student2 = students.First(s => s.Studentcode == "SE171002");
            enrollments.Add(new Enrollment
            {
                Studentid = student2.Studentid,
                Courseid = courses.First(c => c.Coursecode == "PRN211-SP25-01").Courseid,
                Enrolldate = DateTime.SpecifyKind(new DateTime(2025, 1, 6), DateTimeKind.Utc),
                Status = EnrollmentStatus.Completed
            });
            enrollments.Add(new Enrollment
            {
                Studentid = student2.Studentid,
                Courseid = courses.First(c => c.Coursecode == "PRN232-SU25-01").Courseid,
                Enrolldate = DateTime.SpecifyKind(new DateTime(2025, 5, 12), DateTimeKind.Utc),
                Status = EnrollmentStatus.Active
            });
            enrollments.Add(new Enrollment
            {
                Studentid = student2.Studentid,
                Courseid = courses.First(c => c.Coursecode == "SWP391-FA25-01").Courseid,
                Enrolldate = DateTime.SpecifyKind(new DateTime(2025, 9, 8), DateTimeKind.Utc),
                Status = EnrollmentStatus.Pending
            });

            // Student 3 - SE171003 - Vo Thi Hoa
            var student3 = students.First(s => s.Studentcode == "SE171003");
            enrollments.Add(new Enrollment
            {
                Studentid = student3.Studentid,
                Courseid = courses.First(c => c.Coursecode == "DBI202-SP25-01").Courseid,
                Enrolldate = DateTime.SpecifyKind(new DateTime(2025, 1, 6), DateTimeKind.Utc),
                Status = EnrollmentStatus.Completed
            });
            enrollments.Add(new Enrollment
            {
                Studentid = student3.Studentid,
                Courseid = courses.First(c => c.Coursecode == "PRN221-FA25-01").Courseid,
                Enrolldate = DateTime.SpecifyKind(new DateTime(2025, 9, 8), DateTimeKind.Utc),
                Status = EnrollmentStatus.Dropped
            });

            // Student 4 - SE171004 - Dang Quoc Khanh
            var student4 = students.First(s => s.Studentcode == "SE171004");
            enrollments.Add(new Enrollment
            {
                Studentid = student4.Studentid,
                Courseid = courses.First(c => c.Coursecode == "SWR302-SP26-01").Courseid,
                Enrolldate = DateTime.SpecifyKind(new DateTime(2026, 1, 5), DateTimeKind.Utc),
                Status = EnrollmentStatus.Active
            });
            enrollments.Add(new Enrollment
            {
                Studentid = student4.Studentid,
                Courseid = courses.First(c => c.Coursecode == "PRN232-SU26-01").Courseid,
                Enrolldate = DateTime.SpecifyKind(new DateTime(2026, 5, 11), DateTimeKind.Utc),
                Status = EnrollmentStatus.Pending
            });

            // Student 5 - SE171005 - Bui Thanh Long
            var student5 = students.First(s => s.Studentcode == "SE171005");
            enrollments.Add(new Enrollment
            {
                Studentid = student5.Studentid,
                Courseid = courses.First(c => c.Coursecode == "DBI202-SU25-01").Courseid,
                Enrolldate = DateTime.SpecifyKind(new DateTime(2025, 5, 12), DateTimeKind.Utc),
                Status = EnrollmentStatus.Completed
            });
            enrollments.Add(new Enrollment
            {
                Studentid = student5.Studentid,
                Courseid = courses.First(c => c.Coursecode == "SWP391-FA25-01").Courseid,
                Enrolldate = DateTime.SpecifyKind(new DateTime(2025, 9, 8), DateTimeKind.Utc),
                Status = EnrollmentStatus.Active
            });
            enrollments.Add(new Enrollment
            {
                Studentid = student5.Studentid,
                Courseid = courses.First(c => c.Coursecode == "SWD392-SU26-01").Courseid,
                Enrolldate = DateTime.SpecifyKind(new DateTime(2026, 5, 11), DateTimeKind.Utc),
                Status = EnrollmentStatus.Pending
            });

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}
