using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactTestApi.BusinessLogic.Interface;
using ReactTestApi.Models;

namespace ReactTestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController : ControllerBase
	{
		private readonly IDepartmentManager _departmentManager;
		public DepartmentController(IDepartmentManager departmentManager)
		{
			_departmentManager = departmentManager;
		}

		[HttpGet]
		public IEnumerable<Department> Get()
		{
			List<Department> departments = _departmentManager.GetDepartments().ToList();
			return departments;
		}

		[HttpPost]
		public APIResponse Post(Department department)
		{
			APIResponse response = new APIResponse();
			try
			{
				int deptId = _departmentManager.AddDepartment(department);
				if (deptId > 0)
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
		public APIResponse Update(Department department)
		{
			APIResponse response = new APIResponse();
			try
			{
				_departmentManager.UpdateDepartment(department);
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
		public APIResponse Delete(int deptId)
		{
			APIResponse response = new APIResponse();
			try
			{
				_departmentManager.DeleteDepartment(deptId);
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
		
	}
}
