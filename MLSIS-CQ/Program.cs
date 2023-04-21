using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Abstractions;
using MLSIS_CQ.Database;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;


namespace MapleLeafStudentInformationDatabase
{ 
    class DatabaseBackend
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Server Informations
            //var serverInfos = GetServerInformation();

            // Database Mode
            //string connectString = $"Server={serverInfos[0]};Port={serverInfos[1]};Database={serverInfos[2]};User ID={serverInfos[3]};Password={serverInfos[4]};";
            //var serverVersion = ServerVersion.AutoDetect(connectString);
            //builder.Services.AddDbContext<SIDB>(opt => opt.UseMySql(connectString, serverVersion));

            // Memory Mode
            builder.Services.AddDbContext<SIDB>(opt => opt.UseInMemoryDatabase("StudentInformation"));

            // Add services to the container.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapGet("/", () =>
            {
                return "Maple Leaf Student Information System\nRegion: Chongqing";
            });

            app.MapGet("/student", async (SIDB db) =>
            {
                var LookUp = await db.students.ToListAsync();
                return Results.Ok(LookUp);
            });
            app.MapGet("/student/{id}", async (string id, SIDB db) =>
            {
                return await db.students.FindAsync(id) is Student member ? Results.Ok(member) : Results.NotFound();
            });
            app.MapPost("/student", async (Student student, SIDB db) =>
            {
                db.students.Add(student);
                await db.SaveChangesAsync();
                return Results.Created($"/student/{student.student_id}", student);
            });
            app.MapPut("/student{id}", async (string id, Student student, SIDB db) =>
            {
                var select = await db.students.FindAsync(id);
                if (select is null) return Results.NotFound();
                select.student_name = student.student_name;
                select.student_dorm = student.student_dorm;
                select.student_class = student.student_class;
                await db.SaveChangesAsync();
                return Results.Ok();
            });

            app.Run();
        }
        /// <summary>
        /// Get server informations
        /// </summary>
        /// <returns>A five elements array, which contains every that required to connection to database</returns>
        static string?[] GetServerInformation()
        {
            Console.WriteLine("Database IP(null for default \"127.0.0.1\"):");
            string ServerIP = Console.ReadLine() ?? "127.0.0.1";
            Console.WriteLine("Database Port(null for default \"3306\"):");
            string ServerPort = Console.ReadLine() ?? "3306";
            Console.WriteLine("Database Name:");
            string? DatabaseName = Console.ReadLine();
            Console.WriteLine("User ID:");
            string? UserID = Console.ReadLine();
            Console.WriteLine("Password:");
            string? Password = Console.ReadLine();

            string?[] result = new string?[5];
            result[0] = ServerIP;
            result[1] = ServerPort;
            result[2] = DatabaseName;
            result[3] = UserID;
            result[4] = Password;

            return result;
        }
    }
}