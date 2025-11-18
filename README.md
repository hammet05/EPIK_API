# EPIK_API
Esta API provee los endpoints para la administración efectiva del personal de EPIK.

# Instrucciones de Despliegue
1. Crear base de datos ejecutando Epik_DB.sql
2. Actualizar ConnectionString en appsettings.json en el proyecto de .NET
3. Ejecutar: dotnet restore
4. Ejecutar: dotnet ef database update
5. Ejecutar: dotnet run --project src/Epik_PersonApp
6. Abrir Swagger en: https://localhost:7178/index.html --modificar puerto si es necesario


# Características Implementadas
  - Arquitectura Hexagonal:Application, Domain,Infrastructure, Controllers
  - Entity Framework Core: Code First con migraciones
  - AutoMapper: DTOs para transferencia de datos
  - Logging: ILogger integrado
  - Swagger/OpenAPI: Documentación automática
  - Vista SQL: VistaPersonalFemenino
  - 4 Tablas: Personas, TipoIdentificacion, Generos, Migraciones
  - CRUD Completo Personas: Registrar, ObtenerTodasPersonas, ObtenerPersonaPorIdentificacion, ObtenerPersonalFemenino, ActualizarEdad,CambiarEstado,Eliminar
  - Generos: ObtenerGeneros
  - TiposIdentificacion: ObtenerTiposIdentificacion

# EndPoints API
  # Personas

  - https://localhost:7178/api/v1/personas/registrar
  - https://localhost:7178/api/v1/personas/obtenerTodasPersonas
  - https://localhost:7178/api/v1/personas/obtenerPersonPorIdentificacion?numeroIdentificacion=''
  - https://localhost:7178/api/v1/personas/obtenerPersonalFemenino
  - https://localhost:7178/api/v1/personas/actualizarEdad
  - https://localhost:7178/api/v1/personas/cambiarEstado
  - https://localhost:7178/api/v1/personas/eliminar

 # Generos
   - https://localhost:7178/api/v1/generos/obtenerGeneros
     
 # Tipos de Identificación
   - https://localhost:7178/api/v1/tiposIdentificacion/obtenerTiposIdentificacion
