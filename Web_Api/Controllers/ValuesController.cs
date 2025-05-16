using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api.Model;
using Web_Api.Model.Data;
using Web_Api.Model.Entities;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public ValuesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployess()
        {
            //var allEmployess = dbContext.Employees.ToList();

            return Ok(dbContext.Employees.ToList());
        }
        [HttpGet]
        [Route("{id:int}")]

        public IActionResult GetEmployeeById(int id)
        {
            var employee = dbContext.Employees.Find(id);
                
               
            
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]

      

        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee()
            {
               
                Name = addEmployeeDto.Name,
                Phone = addEmployeeDto.Phone,
                Position = addEmployeeDto.Position,
                Office = addEmployeeDto.Office,
                Age = addEmployeeDto.Age,
                Salary = addEmployeeDto.Salary
            };

            dbContext.Employees.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateEmployee(int id, AddEmployeeDto addEmployeeDto)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = addEmployeeDto.Name;
            employee.Phone = addEmployeeDto.Phone;
            employee.Position = addEmployeeDto.Position;
            employee.Office = addEmployeeDto.Office;
            employee.Age = addEmployeeDto.Age;
            employee.Salary = addEmployeeDto.Salary;

            dbContext.SaveChanges();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            dbContext.Employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok(employee);
        }
    }
}