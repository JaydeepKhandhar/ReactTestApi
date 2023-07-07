using ReactTestApi.Models;

namespace ReactTestApi.Data.Interface
{
	public interface IDepartmentRepository
	{
		IEnumerable<Department> GetDepartments();
		int AddDepartment(Department department);
		void UpdateDepartment(Department department);
		void DeleteDepartment(int deptId);
	}
}
