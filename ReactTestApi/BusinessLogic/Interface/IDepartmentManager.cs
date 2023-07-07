using ReactTestApi.Models;

namespace ReactTestApi.BusinessLogic.Interface
{
	public interface IDepartmentManager
	{
		IEnumerable<Department> GetDepartments();
		int AddDepartment (Department department);
		void UpdateDepartment(Department department);
		void DeleteDepartment(int deptId);
	}
}
