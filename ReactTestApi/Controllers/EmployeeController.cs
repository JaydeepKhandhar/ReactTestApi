using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactTestApi.BusinessLogic.Interface;
using ReactTestApi.Models;

namespace ReactTestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly IEmployeeManager _employeeManager;
		private readonly IWebHostEnvironment _environment;
		public EmployeeController(IEmployeeManager employeeManager, IWebHostEnvironment environment)
		{
			_employeeManager = employeeManager;
			_environment = environment;
		}

		[HttpGet]
		public IEnumerable<Employee> Get()
		{
			List<Employee> employees = _employeeManager.GetEmployees().ToList();
			return employees;
		}

		[HttpPost]
		public APIResponse Post(Employee employee)
		{
			APIResponse response = new APIResponse();
			try
			{
				int empId = _employeeManager.AddEmployee(employee);
				if (empId > 0)
				{
					response.isSuccess = true;
					response.Message = "Data added successfully";
				}
			}
			catch (Exception ex)
			{
				response.isSuccess = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[HttpPut]
		public APIResponse Update(Employee employee)
		{
			APIResponse response = new APIResponse();
			try
			{
				_employeeManager.UpdateEmployee(employee);
				response.isSuccess = true;
				response.Message = "Data updated successfully";
			}
			catch (Exception ex)
			{
				response.isSuccess = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[HttpDelete]
		public APIResponse Delete(int empId)
		{
			APIResponse response = new APIResponse();
			try
			{
				_employeeManager.DeleteEmployee(empId);
				response.isSuccess = true;
				response.Message = "Data deleted successfully";
			}
			catch (Exception ex)
			{
				response.isSuccess = false;
				response.Message = ex.Message;
			}
			return response;
		}

		[Route("SaveFile")]
		public APIResponse SaveFile()
		{
			APIResponse response = new APIResponse();
			try
			{
				var httpRequest = Request.Form;
				var postedFile = httpRequest.Files[0];
				string fileName = postedFile.FileName;
				var physicalPath = _environment.ContentRootPath + "/Photos/" + fileName;
				using (var stream = new FileStream(physicalPath, FileMode.Create))
				{
					postedFile.CopyTo(stream);
				}
				response.isSuccess = true;
				response.Message = "File saved successfully";
			}
			catch (Exception ex)
			{
				response.isSuccess = false;
				response.Message = ex.Message;
			}
			return response;
		}

	}
}
