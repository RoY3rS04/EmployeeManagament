using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagament
{
    public class FileEmployeeRepository: IEmployeeRepository
    {
        private string _fileName;

        public FileEmployeeRepository(string fileName)
        {
            _fileName = fileName;
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();

            try
            {
                using (StreamReader sr = new StreamReader(this._fileName))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split(",");

                        Employee employee = new Employee
                        {
                            Name = data[0],
                            Age = Convert.ToInt16(data[1]),
                            Ocupation = data[2]
                        };

                        employees.Add(employee);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Something went wrong when reading the file {e.Message}");
            }

            return employees;
        }

        public void SaveAll(List<Employee> employees)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(this._fileName))
                {
                    foreach(Employee employee in employees)
                    {
                        sw.WriteLine($"{employee.Name}," + $"{employee.Age}," + $"{employee.Ocupation}");
                    } 
                }
            } catch (IOException e)
            {
                Console.WriteLine($"Something went wrong while writing in the file {e.Message}");
            }
        }
    }
}
