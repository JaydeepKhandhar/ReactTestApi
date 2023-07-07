using ReactTestApi.Context;
using ReactTestApi.Data.Interface;
using ReactTestApi.Models;

namespace ReactTestApi.Data.Repository
{
	public class DepartmentRepository : IDepartmentRepository
	{
		private readonly DataContext _dataContext;
		public DepartmentRepository(DataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public int AddDepartment(Department department)
		{
			int deptId = 0;
			try
			{
				_dataContext.Department.Add(department);
				_dataContext.SaveChanges();
				deptId = department.DepartmentId;
			}
			catch (Exception)
			{
				throw;
			}
			return deptId;
		}

		public void DeleteDepartment(int deptId)
		{
			try
			{
				var dept = _dataContext.Department.Where(d => d.DepartmentId == deptId).FirstOrDefault();
				if (dept != null)
				{
					_dataContext.Department.Remove(dept);
					_dataContext.SaveChanges();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public IEnumerable<Department> GetDepartments()
		{
			List<Department> departments = _dataContext.Department.ToList();
			return departments;
		}

		public void UpdateDepartment(Department department)
		{
			try
			{
				var dept = _dataContext.Department.Where(d => d.DepartmentId == department.DepartmentId).FirstOrDefault();
				if (dept != null)
				{
					dept.DepartmentName = department.DepartmentName;
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
