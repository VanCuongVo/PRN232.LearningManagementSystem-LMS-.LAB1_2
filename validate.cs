using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

public class Program {
    public static void Main() {
        var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiIxIiwidW5pcXVlX25hbWUiOiJhZG1pbiIsImVtYWlsIjoiYWRtaW5AZ21haWwuY29tIiwicm9sZSI6IkFkbWluIiwibmJmIjoxNzgxNTc1NjUxLCJleHAiOjE3ODE1NzkyNTEsImlhdCI6MTc4MTU3NTY1MSwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDE2IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MDE2In0.Rb5dJlHVRQV0JWhwNIVQxYz-DDzqk4DmSFeiIenRb8g";
        var key = "daylachuoibimatantoanvaduccungcapboimotchuyenbiagiuathukhoa";
        
        var validationParameters = new TokenValidationParameters {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:5016",
            ValidAudience = "http://localhost:5016",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ClockSkew = TimeSpan.FromMinutes(5)
        };
        
        var handler = new JwtSecurityTokenHandler();
        try {
            handler.ValidateToken(token, validationParameters, out var validatedToken);
            Console.WriteLine("Token is valid!");
        } catch (Exception ex) {
            Console.WriteLine("Exception: " + ex.GetType().Name);
            Console.WriteLine("Message: " + ex.Message);
        }
    }
}
