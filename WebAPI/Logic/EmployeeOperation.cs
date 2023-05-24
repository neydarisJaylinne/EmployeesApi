using WebAPI.Models;

namespace WebAPI.Logic
{
    public class EmployeeOperation
    {
        /// <summary>
        /// Método para calcular el salario anual del empleado
        /// </summary>
        /// <param name="salary">Salario mensual del empleado</param>
        /// <returns>Retorna el salario anual del empleado</returns>
        public double GenerateAnnualSalary(double salary)
        {
            return salary * 12;
        }
        /// <summary>
        /// Método para crear el objeto del empleado con sus parametros
        /// </summary>
        /// <param name="id">Id del empleado</param>
        /// <param name="name">Nombre del empleado</param>
        /// <param name="salary">Salario del empleado</param>
        /// <param name="age">Años del empleado</param>
        /// <param name="profileImage">Imagen de perfil del empleado</param>
        /// <returns>Objeto con todos los datos del empleado</returns>
        public Employee CreateEmployee(int id, string name, double salary, int age, string profileImage)
        {
            Employee employee = new()
            {
                Id = id,
                Age = age,
                Name = name,
                Salary = salary,
                ProfileImage = profileImage,
                AnnualSalary = this.GenerateAnnualSalary(salary)

            };

            return employee;
        }
    }
}
