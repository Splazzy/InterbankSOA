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
