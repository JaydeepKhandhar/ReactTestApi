using ReactTestApi.BusinessLogic.Interface;
using ReactTestApi.Data.Interface;
using ReactTestApi.Models;

namespace ReactTestApi.BusinessLogic.Manager
{
	public class EmployeeManager : IEmployeeManager
	{
		private readonly IEmployeeRepository _employeeRepository;
		public EmployeeManager(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}
		public int AddEmployee(Employee employee)
		{
			int empId = _employeeRepository.AddEmployee(employee);
			return empId;
		}

		public void DeleteEmployee(int empId)
		{
			_employeeRepository.DeleteEmployee(empId);
		}

		public IEnumerable<Employee> GetEmployees()
		{
			List<Employee> employees = _employeeRepository.GetEmployees().ToList();
			return employees;
		}

		public void UpdateEmployee(Employee employee)
		{
			_employeeRepository.UpdateEmployee(employee);
		}
	}
}
