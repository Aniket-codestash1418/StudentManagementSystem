using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using StudentManagementSystem.Application.Common;
using StudentManagementSystem.Application.RequestModels;
using StudentManagementSystem.Application.Services;

namespace StudentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }

        #region Add Student
        [Authorize]
        [HttpPost]
        [Route("addstudent")]
        public async Task<ActionResult<ResponseModel>> AddStudent([FromBody] StudentDto request)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                if (!ModelState.IsValid)
                {
                    responseModel.Message = "Please enter valid Details";
                    responseModel.StatusCode = 400;
                    return BadRequest(responseModel);
                }
                var response = await _studentService.AddAsync(request);
                if (response != null)
                {
                    responseModel.StatusCode = 200;
                    responseModel.Message = "Record added successfully";
                    return Ok(responseModel);
                }
                return BadRequest(responseModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error Occured in AddStudent ");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Student Details
        [Authorize]
        [HttpPut]
        [Route("updatestudentdata")]
        public async Task<ActionResult<ResponseModel>> UpdateStudent([FromBody] UpdateStudentDto request)
        {
            ResponseModel responseModel = new();
            try
            {
                if (!ModelState.IsValid)
                {
                    responseModel.Message = "Please enter valid Details";
                    responseModel.StatusCode = 400;
                    return BadRequest(responseModel);
                }

                var response = await _studentService.UpdateAsync(request);
                if (response is true)
                {
                    responseModel.StatusCode = 200;
                    responseModel.Message = "Record Updated successfully";
                    return Ok(responseModel);
                }
                responseModel.Message = "Record not updated";
                responseModel.StatusCode = 400;
                return BadRequest(responseModel);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error Occured in UpdateStudent ");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Delete Student Record
        [Authorize]
        [HttpDelete]
        [Route("deletestudent")]
        public async Task<ActionResult<ResponseModel>> DeleteStudent(int studentId)
        {
            ResponseModel responseModel = new();
            try
            {
                if (studentId < 0)
                {
                    responseModel.Message = "Please enter correct Id";
                    responseModel.StatusCode = 400;
                    return BadRequest(responseModel);
                }
                var response = await _studentService.DeleteAsync(studentId);
                if (response is true)
                {
                    responseModel.StatusCode = 200;
                    responseModel.Message = "Record deleted Successfully";
                    return Ok(responseModel);
                }
                responseModel.Message = "Record not deleted";
                responseModel.StatusCode = 400;
                return BadRequest(responseModel);

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error Occured in DeleteStudent ");
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Get All Student Data
        [Authorize]
        [HttpGet]
        [Route("getallstudentdata")]
        public async Task<ActionResult<ResponseModel>> GetAllStudentData()
        {
            ResponseModel responseModel = new();
            try
            {
                var response = await _studentService.GetAllAsync();
                if (response is not null && response.Any())
                {
                    responseModel.Data = response;
                    responseModel.Message = "Records fetched successfully";
                    responseModel.StatusCode = 200;
                    return Ok(responseModel);
                }
                else
                {
                    responseModel.Data = response;
                    responseModel.Message = "No records found";
                    responseModel.StatusCode = 201;
                    return Ok(responseModel);
                }

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error Occured in GetAllStudentData ");
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}





