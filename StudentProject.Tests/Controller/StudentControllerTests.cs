using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentTesting.Controllers;
using StudentTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Tests.Controller
{
    
    public class StudentControllerTests
    {
        private async Task<StudentDBContext> GetDBContext()
        {
            var options = new DbContextOptionsBuilder<StudentDBContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var dbContext = new StudentDBContext(options);
            dbContext.Database.EnsureCreated();
            if(await dbContext.studenttbls.CountAsync() < 0)
            {
                for(int i = 0; i < 10; i++)
                {
                    dbContext.studenttbls.Add(
                    new Studenttbl()
                    {
                        StudentName = "Hemachandru",
                        Reg_no = "1813035",
                        DOB = null,
                        Mobile_No = "7448594738",
                        StudentEmail = "hemachandru@gmail.com",
                        Department = "EEE",
                        Password = "Chandru@07",
                        CPassword = "Chandru@07"
                    });
                    await dbContext.SaveChangesAsync();
                }
                
            }
            return dbContext;
        }

        [Fact]
        public async void AddTest()
        {
            //Arrange
            var student = new Studenttbl()
            {
                
                StudentName = "Hemachandru J",
                Reg_no = "1813035",
                DOB = null,
                Mobile_No = "7448594738",
                StudentEmail = "hemachandru@gmail.com",
                Department = "EEE",
                Password = "Chandru@07",    
                CPassword = "Chandru@07"
            };
            var dbContext = await GetDBContext();
            var StudentController = new StudentController(dbContext);
            //Act
            var result = StudentController.Create(student);

            //Assert
            
            result.Should().NotBeNull();
            
            //Assert.IsType<OkObjectResult>(result);
        }
    }

}
