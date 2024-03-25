// See https://aka.ms/new-console-template for more information
using EFCoreBasics.Data;
using EFCoreBasics.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");




using (var context = new AppDbContext())
{

    //Adding to database
    //Insert manager details   , //instance of model class
    /*
     * var manager = new Manager();
     manager.MngFirstName = "Ayub";
     manager.MngLastName = "khan";

     context.Managers.Add(manager);
     context.SaveChanges();
    */

    //Insert employee
    /*
     var employees = new Employee();
     employees.EmpFirstName = "King";
     employees.EmpLastName = "khans";
     employees.EmpSalary = 10000;
     employees.ManagerId = 1;
     context.Employees.Add(employees);
     context.SaveChanges();


     var employee = new Employee();
     employee.EmpFirstName = "Sid";
     employee.EmpLastName = "Pasha";
     employee.EmpSalary = 30000;
     employee.ManagerId = 1;
     context.Employees.Add(employee);
     context.SaveChanges();
      */

    //insert EmployeeDetails

    /*
    var employeeDetails = new EmployeeDetails();
    employeeDetails.Address = "Frankfurt";
    employeeDetails.PhoneNumber = "9019108181";
    employeeDetails.Email = "khan@gmail.com";
    employeeDetails.EmployeeId = 1;
    context.EmployeeDetails.Add(employeeDetails);
    var result = context.SaveChanges();
    */

    /*
    context.EmployeeDetails.Add(new EmployeeDetails
    {
        Address = "New York, USA",
        PhoneNumber = "555-123-4567",
        Email = "john.doe@company.com",
        EmployeeId = 3
    });
    */

    /*
    //INSERT TO  PROJECT
    var project = new Project();
    project.Name = "MyProject1";
    context.Projects.Add(project);
    context.SaveChanges();
    */

    /*
      //Insert into mant to many
      var employeeProject = new EmployeeProject
      {
          EmployeeId = 2,
          ProjectId = 1
      };
      context.EmployeeProjects.Add(employeeProject);
      context.SaveChanges();
    */


    //Retrieve  in ef core 
    /*
    var employees = context.Employees.ToList();
    for (int i = 0; i < employees.Count; i++)
    {
        Console.WriteLine($"Employee Name : {employees[i].EmpFirstName}, Employee Lastname : {employees[i].EmpLastName}, Employee Salary : {employees[i].EmpSalary}");
       
    }

    //retrieve single employee
    var employee = context.Employees.FirstOrDefault(e => e.EmployeeId == 1); //or use .single()
    Console.WriteLine(employee.EmpFirstName);
    */

    /*
    //Update  in ef core 
    var employee = context.Employees.FirstOrDefault(e => e.EmployeeId == 1);
    employee.EmpSalary = 50000;
    context.SaveChanges();
    Console.WriteLine($"Employee Updated Salary :  {employee.EmpSalary}");
    */

    /*
    //Delete data in ef core 
    var employee = context.Employees.FirstOrDefault(e => e.EmployeeId == 1);
    context.Remove(employee);
    context.SaveChanges();
    Console.WriteLine("Deleted Successfully");
    */

    //Eager Loading 
    /*
    var employees = context.Employees.Include(e => e.EmployeeDetails).ToList();
    foreach (var emp in employees)
    {
        if (emp.EmployeeDetails != null)
        {
            Console.WriteLine($"Id : {emp.EmployeeDetails.EmployeeId} Employee Name : {emp.EmpFirstName} Employee Address : {emp.EmployeeDetails.Address}");
        }
        else
        {
            Console.WriteLine($"Id : {emp.EmployeeId} Employee Name : {emp.EmpFirstName} No Employee Details Found");
        }
    }

    //EAGER LOADING MANY TO MANY
    var projects = context.Projects.Include(p => p.EmployeeProjects).ThenInclude(e => e.Employee).ToList();
    foreach (var project in projects)
    {
        Console.WriteLine($"Project Name : {project.Name} ");
        foreach (var empProj in project.EmployeeProjects)
        {
            Console.WriteLine($"Employee Name : {empProj.Employee.EmpFirstName}");
        }

    }
    */

    //Explicit Loading
    /*
    var employees = context.Employees.ToList(); //load main entity
    foreach (var emp in employees)
    {
        //Load Related Entity
        context.Entry(emp).Reference(e => e.EmployeeDetails).Load();

        Console.WriteLine($"Id : {emp.EmployeeDetails.EmployeeId} Employee Name : {emp.EmpFirstName} Employee Address : {emp.EmployeeDetails.Address}");
    }
    */
    /*
    var employees = context.Employees.ToList(); //load main entity
    foreach (var emp in employees)
    {
        //Load Related Entity
        context.Entry(emp).Reference(e => e.EmployeeDetails).Load();

        if (emp.EmployeeDetails != null)
        {
            Console.WriteLine($"Id : {emp.EmployeeDetails.EmployeeId} Employee Name : {emp.EmpFirstName} Employee Address : {emp.EmployeeDetails.Address}");
        }
        else
        {
            Console.WriteLine($"Id : {emp.EmployeeId} Employee Name : {emp.EmpFirstName} No Employee Details Found");
        }
    }


    var manager = context.Managers.ToList();
   foreach(var mng in manager)
    {
        Console.WriteLine($"Manager Name : {mng.MngFirstName} & Manager last name : {mng.MngLastName}");
        context.Entry(mng).Collection(e => e.Employees).Load();

        if(mng.Employees.Any())
        {
            Console.WriteLine("Employess : ");

            foreach (var emp in mng.Employees)
            {
                Console.WriteLine($"Employee Name : {emp.EmpFirstName} {emp.EmpLastName}");
            }
          
        }

    }
    */

    /*
    //LAZY LOADING
    var manager = context.Managers.ToList();
    foreach (var mng in manager)
    {
        Console.WriteLine($"Manager Name : {mng.MngFirstName} & Manager last name : {mng.MngLastName}");
        if (mng.Employees.Any())
        {
            Console.WriteLine("Employess : ");

            foreach (var emp in mng.Employees)
            {
                Console.WriteLine($"Employee Name : {emp.EmpFirstName} {emp.EmpLastName}");
            }

        }
    }
    */

    //Transaction

    //Begin transaction
    using (var transaction = context.Database.BeginTransaction())
    {
        //perform database operations
        var employeeId = 2;

        //retreive the employee, employee deatils, project and manager to update
        var employeeToUpdate = context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
        var employeeDetailsToUpdate = context.EmployeeDetails.FirstOrDefault(e => e.Id == employeeToUpdate.EmployeeId);

        if(employeeToUpdate != null && employeeDetailsToUpdate != null)
        {
            try
            {
                //update  the employee last name  and address
                employeeToUpdate.EmpLastName = "Syed";
                employeeDetailsToUpdate.Address = "Australia";

                //update manager details
                employeeToUpdate.ManagerId = 1;

                //save changes
                context.SaveChanges();

                //commit the transaction
                transaction.Commit();

                Console.WriteLine("Updated Successfully");
            }
            catch(Exception) 
            {
                transaction.Rollback();
                Console.WriteLine("Rollback has occured");
                throw;
            }
         
        }
        else
        {
            throw new Exception();
        }
       
    }



}





