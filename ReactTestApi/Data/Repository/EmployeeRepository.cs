using ReactTestApi.Context;
using ReactTestApi.Data.Interface;
using ReactTestApi.Models;

namespace ReactTestApi.Data.Repository
{
	public class EmployeeRepository : IEmployeeRepository
	{
		private readonly DataContext _dataContext;
		public EmployeeRepository(DataContext dataContext) 
		{
			_dataContext= dataContext;
		}
		public int AddEmployee(Employee employee)
		{
			int empId = 0;
			try
			{
				_dataContext.Employee.Add(employee);
				_dataContext.SaveChanges();
				empId = employee.EmployeeId;
			}
			catch (Exception)
			{
				throw;
			}
			return empId;
		}

		public void DeleteEmployee(int empId)
		{
			try
			{
				var emp = _dataContext.Employee.Where(e => e.EmployeeId == empId).FirstOrDefault();
				if (emp != null)
				{
					_dataContext.Employee.Remove(emp);
					_dataContext.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public IEnumerable<Employee> GetEmployees()
		{
			List<Employee> employees = _dataContext.Employee.ToList();
			return employees;
		}

		public void UpdateEmployee(Employee employee)
		{
			try
			{
				var emp = _dataContext.Employee.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault();
				if (emp != null)
				{
					emp.EmployeeName = employee.EmployeeName;
					emp.Department = employee.Department;
					emp.DateOfJoin = employee.DateOfJoin;
					emp.PhotoFileName = employee.PhotoFileName;
					_dataContext.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
