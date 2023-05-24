using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WebAPI.Logic;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase

    {

        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly EmployeeOperation _employeeOperation;

        public EmployeeController(IConfiguration config)
        {
            _httpClient = new HttpClient();
            _config = config;
            _employeeOperation = new EmployeeOperation();
        }
        /// <summary>
        /// Método HTTP GET que consume una API para obtener la lista de los empleados
        /// </summary>
        /// <returns>Lista de empleados</returns>
        [HttpGet()]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                HttpResponseMessage resulEmployees = await _httpClient.GetAsync(_config.GetValue<string>("Urls:EmployeesApi"));
                resulEmployees.EnsureSuccessStatusCode();
                List<Employee> employees = new();
                string responseObject = await resulEmployees.Content.ReadAsStringAsync();
                JObject result = JObject.Parse(responseObject);
                if (result != null && ((string)result["status"]! == "success"))
                {

                    foreach (JObject item in result["data"]!)
                    {
                        employees.Add(_employeeOperation.CreateEmployee(
                            (int)item["id"]!,
                            (string)item["employee_name"]!,
                            (double)item["employee_salary"]!,
                            (int)item["employee_age"]!,
                            (string)item["profile_image"]!
                        ));
                    }
                    var response = new
                    {
                        Status = "ok",
                        Employees = employees
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new
                    {
                        Status = "Error",
                        Message = "Se genero un error"
                    };
                    return StatusCode(500, response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Status = "Error",
                    Message = $"Se genero un error: {ex.Message}"
                };
                return StatusCode(500, response);
            }
        }
        /// <summary>
        /// Método HTTP GET para Obtener la informacionde del empleado
        /// </summary>
        /// <param name="id">Identificador del empleado a buscar</param>
        /// <returns>Infomarcion del empleado</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> getEmployee(int id)
        {
            try
            {
                HttpResponseMessage resulEmployees = await _httpClient.GetAsync(_config.GetValue<string>("Urls:EmployeeApi") + id);
                resulEmployees.EnsureSuccessStatusCode();
                string responseObject = await resulEmployees.Content.ReadAsStringAsync();
                JObject result = JObject.Parse(responseObject);
                if (result != null && ((string)result["status"]! == "success"))
                {
                    var item = result["data"]!;
                    var employee = _employeeOperation.CreateEmployee(
                        (int) item["id"]!,
                        (string) item["employee_name"]!,
                        (double) item["employee_salary"]!,
                        (int) item["employee_age"]!,
                        (string) item["profile_image"]!
                    );
                    var response = new
                    {
                        Status = "ok",
                        Employee = employee
                    };

                    return Ok(response);
                }
                else
                {
                    var response = new
                    {
                        Status = "Error",
                        Message = "Se genero un error"
                    };
                    return StatusCode(500, response);
                }


            }
            catch (Exception ex)
            {
                var reponse = new
                {
                    Status = "Error",
                    Message = $"Se genero un error: {ex.Message}"
                };
                return StatusCode(500, reponse);
            }
        }

    }
}
