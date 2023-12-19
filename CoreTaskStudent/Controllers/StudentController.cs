using CoreTaskStudent.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks; // Add this using directive
using CoreTaskStudent.Repository; // Add the namespace for the repository

namespace CoreTaskStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentDB _studentDB; // Change the type to IStudentDB

        public StudentController(IStudentDB studentDB)
        {
            _studentDB = studentDB;
        }

        // GET api/students
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IEnumerable<Student> students = await _studentDB.GetStudentDetails();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/students
        [HttpPost] // Add [HttpPost] attribute to indicate the HTTP method
        public IActionResult Post([FromBody] Student student)
        {
            try
            {
                string result = _studentDB.InsertStudent(student);
                return StatusCode(201, result); // Use StatusCode method to return a specific status code
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/students/5
        [HttpPut("{id}")] // Add [HttpPut] attribute to indicate the HTTP method
        public IActionResult Put(int id, [FromBody] Student student)
        {
            try
            {
                student.Student_id = id;
                string result = _studentDB.UpdateStudentResult(student);
                return Ok(result); // Use Ok method to return 200 OK status code
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/students/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                string result = _studentDB.DeleteStudentResult(id);

                if (result == "SUCCESS")
                {
                    return Ok("Student deleted successfully");
                }
                else
                {
                    return BadRequest("Failed to delete student");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}




























































































//using CoreTaskStudent.Models;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks; // Add this using directive

//namespace CoreTaskStudent.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class StudentController : ControllerBase
//    {
//        private readonly StudentDB _studentDB;

//        public StudentController(StudentDB studentDB)
//        {
//            _studentDB = studentDB;
//        }

//        // GET api/students
//        [HttpGet]
//        public async Task<IActionResult> Get()
//        {
//            try
//            {
//                IEnumerable<Student> students = await _studentDB.GetStudentDetails();
//                return Ok(students);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        // POST api/students
//        [HttpPost] // Add [HttpPost] attribute to indicate the HTTP method
//        public IActionResult Post([FromBody] Student student)
//        {
//            try
//            {
//                string result = _studentDB.InsertStudent(student);
//                return StatusCode(201, result); // Use StatusCode method to return a specific status code
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        // PUT api/students/5
//        [HttpPut("{id}")] // Add [HttpPut] attribute to indicate the HTTP method
//        public IActionResult Put(int id, [FromBody] Student student)
//        {
//            try
//            {
//                student.Student_id = id;
//                string result = _studentDB.UpdateStudentResult(student);
//                return Ok(result); // Use Ok method to return 200 OK status code
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }

//        // DELETE api/students/5
//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            try
//            {
//                string result = _studentDB.DeleteStudentResult(id);

//                if (result == "SUCCESS")
//                {
//                    return Ok("Student deleted successfully");
//                }
//                else
//                {
//                    return BadRequest("Failed to delete student");
//                }
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }

//        }
//    }
//}
