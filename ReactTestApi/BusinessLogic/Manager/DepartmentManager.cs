using ReactTestApi.BusinessLogic.Interface;
using ReactTestApi.Data.Interface;
using ReactTestApi.Models;

namespace ReactTestApi.BusinessLogic.Manager
{
	public class DepartmentManager : IDepartmentManager
	{
		private readonly IDepartmentRepository _departmentRepository;
		public DepartmentManager(IDepartmentRepository departmentRepository)
		{
			_departmentRepository = departmentRepository;
		}
		public int AddDepartment(Department department)
		{
			int deptId = _departmentRepository.AddDepartment(department);
			return deptId;
		}

		public void DeleteDepartment(int deptId)
		{
			_departmentRepository.DeleteDepartment(deptId);
		}

		public IEnumerable<Department> GetDepartments()
		{
			List<Department> departments = _departmentRepository.GetDepartments().ToList();
			return departments;
		}

		public void UpdateDepartment(Department department)
		{
			_departmentRepository.UpdateDepartment(department);
		}
	}
}
