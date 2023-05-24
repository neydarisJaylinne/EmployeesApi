using NUnit.Framework;
using WebAPI.Logic;
using WebAPI.Models;

namespace WebAPI.Test
{
    [TestFixture]
    public class TestEmployee
    {
        /// <summary>
        /// Prueba para validar el metodo que genera el salario anual
        /// </summary>
        [Test]
        public void TestAnnualSalary()
        {
            double salary = 5000;
            double annualSalary = 60000;
            EmployeeOperation employeeOperation = new EmployeeOperation();

            Assert.AreEqual(annualSalary, employeeOperation.GenerateAnnualSalary(salary));

        }
        /// <summary>
        /// Prueba para validar el metodo que genera el salario anual
        /// </summary>
        [Test]
        public void TestAnnualSalaryTwo()
        {
            double salary = 100;
            double annualSalary = 1200;
            EmployeeOperation employeeOperation = new EmployeeOperation();

            Assert.AreEqual(annualSalary, employeeOperation.GenerateAnnualSalary(salary));

        }
        /// <summary>
        /// Prueba para validar la creacion del objeto de un empleado
        /// </summary>
        [Test]
        public void CreateEmployee()
        {
            EmployeeOperation employeeOperation = new EmployeeOperation();
            Employee employee = employeeOperation.CreateEmployee(1,"Andres",100,25,"help");

            Assert.NotNull(employee);
            Assert.AreEqual(1, employee.Id);
            Assert.AreNotEqual("Juan", employee.Name);          

        }
    }
}
