using ReactTestApi.Models;

namespace ReactTestApi.BusinessLogic.Interface
{
	public interface IEmployeeManager
	{
		IEnumerable<Employee> GetEmployees();
		int AddEmployee(Employee employee);
		void UpdateEmployee(Employee employee);
		void DeleteEmployee(int empId);
	}
}
