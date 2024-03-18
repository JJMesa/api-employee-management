# Informacion general

Este proyecto es una Minimal API con .Net 6 enfocada en una arquitectura de microservicios. Implementa un CRUD para la creación de empleados y el almacenamiento de archivos, como la imagen del empleado, utilizando la misma API como servidor de archivos. Se reconoce que esta práctica no es considerada buena práctica; sin embargo, permite escalabilidad en la implementación de servicios como el almacenamiento de blobs o un S3."

# Pasos para la configuracion de la Api.

##### Configuracion archivo appsettings:

1. **ConnectionStrings** - Configuracion de la cadena de conexion de base de datos.
- **DefaultConnection:** Se debe cambiar su valor actual por la configuracion del servidor de base de datos, ejemplo:
'Server=```{Servidor base de datos}```;Initial Catalog=```{Nombre base de datos}```;Persist Security Info=False;User ID=```{Usuario servidor base de datos}```;Password=```{Contraseña servidor base de datos}```;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=```{Timeout para consultas a base de datos}```'

## Migraciones ##

Luego de la configuración previa de las cadenas de conexión, se puede proceder a la implementación de las migraciones. El proyecto ya cuenta con la primera migración creada y únicamente se requiere ejecutar el comando correspondiente, ya sea utilizando el CLI de .Net (dotnet ef database update) o la consola de administración de paquetes (update-database).

