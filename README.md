# Employee API - Guía de Implementación

## Descripción
Este proyecto es una API en .NET diseñada para la gestión de información de empleados. Su principal función es consumir una API externa para obtener y procesar datos de empleados.

## Tecnologías Utilizadas
- .NET 6/7
- ASP.NET Core Web API
- Newtonsoft.Json
- HttpClient
- Angular: https://github.com/neydarisJaylinne/AngularWebApi

## Estructura del Proyecto
```
/WebAPI
│── Controllers
│── Logic
│── Models
│── Program.cs
│── appsettings.json
```

## Características Principales
- Consumo de APIs REST utilizando `HttpClient`.
- Manejo de datos en formato JSON con `Newtonsoft.Json`.
- Implementación de controladores en .NET Core.
- Configuración de `appsettings.json` para almacenar URLs de APIs externas.

## Configuración
Para configurar las URLs de las APIs externas, edite el archivo `appsettings.json`:
```
"Urls": {
  "EmployeesApi": "https://api.ejemplo.com/employees",
  "EmployeeApi": "https://api.ejemplo.com/employee/"
}
```

## Endpoints Disponibles
### Obtener todos los empleados
**GET** `/api/Employee`

**Respuesta:**
```json
{
  "Status": "ok",
  "Employees": [
    {
      "id": 1,
      "employee_name": "John Doe",
      "employee_salary": 50000,
      "employee_age": 30,
      "profile_image": ""
    }
  ]
}
```

### Obtener un empleado por ID
**GET** `/api/Employee/{id}`

**Parámetros:**
- `id` (int): Identificador del empleado.

**Respuesta:**
```json
{
  "Status": "ok",
  "Employee": {
    "id": 1,
    "employee_name": "John Doe",
    "employee_salary": 50000,
    "employee_age": 30,
    "profile_image": ""
  }
}
```

## Uso del Proyecto como Referencia
Este proyecto sirve como guía para implementar anotaciones y palabras reservadas en otros proyectos .NET. Se puede utilizar como referencia para la estructura de controladores, consumo de APIs externas y manejo de respuestas JSON.

## Contribución
Si deseas contribuir, puedes clonar el repositorio y hacer un pull request con mejoras o ejemplos adicionales.
