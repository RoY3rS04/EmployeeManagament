using EmployeeManagament;

string employeesFile = "employees.txt";

IEmployeeRepository employeeRepository = new FileEmployeeRepository(employeesFile);

EmployeeManagament.EmployeeManagament employeeManagament = new EmployeeManagament.EmployeeManagament(employeeRepository);

int option;
bool shouldContinue = true;

do
{
    Console.Clear();

    Console.WriteLine("Welcome Back, Please select one of the following options to continue");
    Console.WriteLine("1. List All Employees");
    Console.WriteLine("2. Add A New Employee");
    Console.WriteLine("3. Exit");

    option = Convert.ToInt16(Console.ReadLine());

    if(option < 1 || option > 3)
    { 
        Console.WriteLine("Please select a valid option");
    }

    string yesOrNo;

    switch (option)
    {
        case 1:
            {
                Console.WriteLine("Name | Age | Ocupation");
                foreach (Employee employee in employeeManagament.GetEmployees())
                {
                    Console.WriteLine($"{employee.Name} | " + $"{employee.Age} | " + $"{employee.Ocupation}");
                }

                Console.WriteLine("Do you wish to keep using the program? Y/n");
                yesOrNo = Console.ReadLine();
                shouldContinue = keepUsing(yesOrNo);

                break;
            }

        case 2:
            {
                string name, ocupation;
                int age;

                Console.WriteLine("Write down the employee's name");
                name = Console.ReadLine();

                Console.WriteLine("Write down the employee's age");
                age = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("Write down the employee's ocupation");
                ocupation = Console.ReadLine();

                employeeManagament.AddEmployee(
                    new Employee
                    {
                        Name = name,
                        Age = age,
                        Ocupation = ocupation
                    }
                );

                Console.WriteLine("Employee stored successfully");
                Console.WriteLine("Do you wish to keep using the program? y/n");
                yesOrNo = Console.ReadLine();

                shouldContinue = keepUsing(yesOrNo);

                break;
            }

        case 3:
            {
                Console.WriteLine("Goodbye!");
                shouldContinue = false;
                break;
            }
    }

} while (shouldContinue);

bool keepUsing(string yesOrNo)
{
    return yesOrNo == "y" ? true : false;
}