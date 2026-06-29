# InterbankSOA

API REST para la gestión de usuarios y servicios de InterbankSOA.

## Estructura del proyecto

- `InterbankSOA.API/`
  - `Controllers/`
  - `DTOs/`
  - `Models/`
  - `Repositories/`
  - `Services/`
  - `Program.cs`
  - `InterbankSOA.API.csproj`

## Requisitos

- .NET SDK 8.0 o superior
- Visual Studio 2022/2023, VS Code u otro editor compatible con .NET

## Configuración inicial

1. Clona el repositorio:
   ```bash
   git clone https://github.com/Splazzy/InterbankSOA.git
   ```
2. Entra al directorio del proyecto:
   ```bash
   cd InterbankSOA
   ```
3. Restaura dependencias:
   ```bash
   dotnet restore InterbankSOA.API/InterbankSOA.API.csproj
   ```

## Compilar y ejecutar

### Desde la línea de comandos

```bash
dotnet build InterbankSOA.API/InterbankSOA.API.csproj

dotnet run --project InterbankSOA.API/InterbankSOA.API.csproj
```

### Desde Visual Studio / VS Code

- Abre la carpeta `InterbankSOA`.
- Selecciona `InterbankSOA.API` como proyecto de inicio.
- Ejecuta el proyecto.

## Endpoints principales

- `GET /api/usuario` → Obtener usuarios
- `POST /api/usuario` → Crear usuario
- `POST /api/usuario/login` → Iniciar sesión

## Swagger

- Accede a la documentación en `http://localhost:5131/swagger/index.html` después de iniciar el proyecto.

## SQL compartido

Para que todos los colaboradores usen la misma base de datos y compartan los datos generados:

1. Crea un servidor SQL accesible desde todas las máquinas del equipo.
   - Puede ser un SQL Server en red local, una VM, o un servicio en la nube como Azure SQL.
2. Crea la base de datos `InterbankSOA` en ese servidor.
3. Usa una cadena de conexión compartida.

Ejemplo para Azure SQL:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=tcp:mi-servidor.database.windows.net,1433;Initial Catalog=InterbankSOA;Persist Security Info=False;User ID=miUsuario;Password=miPassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
}
```

Ejemplo para SQL Server en red local:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SERVIDOR_COMPARTIDO;Database=InterbankSOA;User Id=miUsuario;Password=miPassword;TrustServerCertificate=True;"
}
```

### Recomendada: no guardar credenciales en el repositorio

- No subas la contraseña ni la cadena real a GitHub.
- Usa `appsettings.Development.json` sólo localmente o mejor usa `dotnet user-secrets`.

Ejemplo con user secrets:

```bash
dotnet user-secrets init --project InterbankSOA.API/InterbankSOA.API.csproj

dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=SERVIDOR_COMPARTIDO;Database=InterbankSOA;User Id=miUsuario;Password=miPassword;TrustServerCertificate=True;"
```

El proyecto ya está configurado en `Program.cs` para leer `DefaultConnection` desde la configuración, así que basta con tener la cadena de conexión definida en el entorno local de cada colaborador.

## Colaboración

- Clonar: `git clone https://github.com/Splazzy/InterbankSOA.git`
- Crear rama para cambios:
  ```bash
  git checkout -b feature/nombre-de-la-rama
  ```
- Añadir cambios:
  ```bash
  git add .
  ```
- Commit:
  ```bash
  git commit -m "Descripción del cambio"
  ```
- Push de la rama:
  ```bash
  git push -u origin feature/nombre-de-la-rama
  ```

## Remoto

Repositorio remoto:
https://github.com/Splazzy/InterbankSOA
