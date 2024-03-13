using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagament
{
    public class EmployeeManagament
    {
        private IEmployeeRepository _repository;

        public EmployeeManagament(IEmployeeRepository repository)
        {
            this._repository = repository;
        }

        public List<Employee> GetEmployees() {
            return this._repository.GetAll();
        }

        public void AddEmployee(Employee employee)
        {
            List<Employee> employees = this.GetEmployees();

            employees.Add(employee);

            this._repository.SaveAll(employees);
        }
    }
}
