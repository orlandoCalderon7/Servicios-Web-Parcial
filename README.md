# ClínicaCitas API - Gestión de Citas Médicas (.NET 10)
Proyecto parcial para el curso Desarrollo de Servicios Web. Construcción de una API RESTful empleando buenas prácticas, arquitectura de capas, y manejo centralizado de excepciones.

## Carátula
- **Curso:** Desarrollo de Servicios Web
- **Docente:** Felix Rafael Contreras Martinez
- **Grupo:** Grupo 4
- **Integrantes:**
  1. Elmer David Querevalu Puescas
  2. Hilda Lisbet Pomacarhua Alberco
  3. Jose Orlando Calderon Agip
- **Enlace al repositorio:** https://github.com/orlandoCalderon7/Servicios-Web-Parcial


##  Estructura del Repositorio (Arquitectura de Capas)
El proyecto se organiza en una arquitectura monolítica modular, separando responsabilidades para garantizar la mantenibilidad y escalabilidad del código:

    ClinicaCitas/
    ├──  ClinicaCitas.sln                <-- Solución principal del proyecto
    ├──  README.md                       <-- Informe técnico y guía de ejecución
    │
    ├──  Controllers/                    <-- Exposición de Endpoints HTTP (REST)
    │   └──  CitasController.cs          <-- Endpoints CRUD (GET, POST, PUT, DELETE)
    │
    ├──  Middlewares/                    <-- Interceptores del pipeline HTTP
    │   └──  ErrorHandlerMiddleware.cs   <-- Manejo global de excepciones (evita caídas 500)
    │
    ├──  Models/                         <-- Entidades de dominio y DTOs
    │   ├──  Cita.cs                     <-- Modelo con Data Annotations ([Required], [StringLength])
    │   ├──  Medico.cs
    │   └──  Paciente.cs
    │
    ├──  Services/                       <-- Lógica de negocio y persistencia
    │   ├──  ICitaService.cs             <-- Interfaz (Contrato)
    │   └──  CitaService.cs              <-- Implementación con almacenamiento estático (Singleton)
    │
    ├──  appsettings.json                <-- Variables de entorno
    └──  Program.cs                      <-- Inyección de dependencias (DI) y Scalar en /scalar/v1

##  Cómo Ejecutar el Proyecto

### Opción A: Abrir con Visual Studio 2026 (Recomendado)
1. Navega a la carpeta del proyecto y haz doble clic en el archivo `ClinicaCitas.sln`.
2. En la barra superior, asegúrate de seleccionar el perfil de ejecución **`http`** o **`ClinicaCitas`** (no IIS Express ni el archivo Program.cs).
3. Presiona el botón verde de **Play** (o la tecla `F5`).
4. El navegador se abrirá automáticamente en: `http://localhost:5000/scalar/v1`

### Opción B: Ejecución Local con .NET CLI (Terminal)
1. Abre tu terminal o consola de comandos.
2. Ubícate en la raíz del proyecto donde se encuentra el archivo `.csproj`:
       cd ClinicaCitas
3. Levanta el servidor local con el siguiente comando:
       dotnet run
4. Ingresa desde tu navegador a la documentación interactiva:
   `http://localhost:5000/scalar/v1`

##  Datos Precargados de Prueba (Seed Data)
El proyecto simula la persistencia mediante listas estáticas en memoria administradas a través de inyección de dependencias (`AddSingleton`). Al levantar el proyecto, los siguientes registros ya estarán disponibles para probar el endpoint `GET /api/citas`:

| ID Cita | ID Paciente | ID Médico | Estado | Motivo |
| :--- | :--- | :--- | :--- | :--- |
| **1** | 1 | 1 | Programada | Chequeo general preventivo |
| **2** | 2 | 2 | Programada | Lectura de análisis de sangre |
| **3** | 3 | 1 | Programada | Dolor muscular crónico |

##  Notas Técnicas Adicionales
- **Base de Datos:** Para esta entrega no se implementó Entity Framework ni conexiones externas (SQL Server/PostgreSQL). El almacenamiento es 100% volátil en memoria.
- **Validaciones:** Se recomienda probar el endpoint `POST` enviando JSON incompletos para verificar el retorno de códigos `400 Bad Request` capturados por los *Data Annotations*.
- **Manejo de Errores:** Cualquier error crítico interno es capturado por el `ErrorHandlerMiddleware`, devolviendo un formato JSON estándar en lugar de exponer la traza de la pila (Stack Trace).