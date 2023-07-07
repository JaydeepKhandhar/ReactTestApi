using ReactTestApi.Models;

namespace ReactTestApi.Data.Interface
{
	public interface IEmployeeRepository
	{
		IEnumerable<Employee> GetEmployees();
		int AddEmployee(Employee employee);
		void UpdateEmployee(Employee employee);
		void DeleteEmployee(int empId);
	}
}
