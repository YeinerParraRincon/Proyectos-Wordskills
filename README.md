# 🏆 WorldSkills — Pruebas y Proyectos C#

![C#](https://img.shields.io/badge/Lenguaje-C%23-blue)
![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![WorldSkills](https://img.shields.io/badge/WorldSkills-Colombia-green)
![Estado](https://img.shields.io/badge/Estado-En%20progreso-yellow)

Repositorio personal con todas mis pruebas y proyectos desarrollados durante mi preparación para **WorldSkills Colombia**. Incluye ejercicios de APIs REST, Entity Framework, algoritmos de consola y aplicaciones Windows Forms.

---

## 📁 Estructura del repositorio
```
📦 worldskills-csharp/
│
├── 🌐 APIs y Web API
│   ├── API/
│   ├── API3/
│   ├── API4/
│   ├── API5/
│   ├── API6/
│   ├── API7/
│   ├── API10/
│   ├── API11/
│   ├── API17/
│   ├── Api-Prueba/
│   ├── Apis2/
│   ├── Prueba-api-1/
│   ├── Prueba-API-RICKY/
│   ├── Pruebas Api/
│   ├── Test1/
│   └── Test12/
│
├── 🗄️ Entity Framework y Base de Datos
│   ├── Entity-Movil-1/
│   ├── Entity-Movil-2/
│   ├── P4-Nacional-Entity/
│   ├── PreeEliminar/
│   ├── Pureba-Entity-1/
│   ├── Prueba-entity-2/
│   ├── prueba-entity-3/
│   └── pruebaManagen21/
│
├── 🖼️ Manejo de Imágenes
│   ├── Imgaenes/
│   └── TrearImAGENES/
│
├── 🏅 Competencias Oficiales
│   ├── P4-Nacional/
│   ├── Preselecion/
│   └── WebApplication1/
│   └── WepApplication2/
│
└── 🖥️ Windows Forms
    ├── WindowsFormsApp1/
    ├── WindowsFormsApp2/
    └── WindowsFormsApp3/
```

---

## 📋 Tabla de proyectos

| Carpeta | Tipo | Descripción | Estado |
|---|---|---|---|
| API | Web API | Primera prueba de API REST | ✅ |
| API3 | Web API | Prueba API v3 | ✅ |
| API4 | Web API | Prueba API v4 | ✅ |
| API5 | Web API | Prueba API v5 | ✅ |
| API6 | Web API | Prueba API v6 | ✅ |
| API7 | Web API | Prueba API v7 | ✅ |
| API10 | Web API | Prueba API v10 | ✅ |
| API11 | Web API | Prueba API v11 | ✅ |
| API17 | Web API | Prueba API v17 | ✅ |
| Api-Prueba | Web API | Prueba general de API | ✅ |
| Apis2 | Web API | Segunda serie de APIs | ✅ |
| Prueba-api-1 | Web API | Prueba API individual | ✅ |
| Prueba-API-RICKY | Web API | Prueba API con ejercicio Ricky | ✅ |
| Pruebas Api | Web API | Conjunto de pruebas API | ✅ |
| Test1 | Web API | Test rápido 1 | ✅ |
| Test12 | Web API | Test rápido 12 | ✅ |
| Entity-Movil-1 | Entity Framework | API con EF para app móvil | ✅ |
| Entity-Movil-2 | Entity Framework | API con EF para app móvil v2 | ✅ |
| P4-Nacional-Entity | Entity Framework | Prueba nacional con Entity | ✅ |
| PreeEliminar | Entity Framework | Práctica preeliminar | ✅ |
| Pureba-Entity-1 | Entity Framework | Prueba Entity Framework 1 | ✅ |
| Prueba-entity-2 | Entity Framework | Prueba Entity Framework 2 | ✅ |
| prueba-entity-3 | Entity Framework | Prueba Entity Framework 3 | ✅ |
| pruebaManagen21 | Entity Framework | Prueba de manejo avanzado | ✅ |
| Imgaenes | Imágenes | Manejo y carga de imágenes | ✅ |
| TrearImAGENES | Imágenes | Traer imágenes desde API | ✅ |
| P4-Nacional | Competencia | Prueba fase nacional P4 | ✅ |
| Preselecion | Competencia | Prueba de preselección | ✅ |
| WebApplication1 | Web App | Aplicación web 1 | ✅ |
| WepApplication2 | Web App | Aplicación web 2 | ✅ |
| WindowsFormsApp1 | Windows Forms | App de escritorio 1 | ✅ |
| WindowsFormsApp2 | Windows Forms | App de escritorio 2 | ✅ |
| WindowsFormsApp3 | Windows Forms | App de escritorio 3 | ✅ |

---

## 🚀 Cómo ejecutar un proyecto

### APIs / Web API
```bash
# Clonar el repositorio
git clone https://github.com/tu-usuario/tu-repositorio.git

# Entrar a la carpeta del proyecto
cd API6

# Restaurar dependencias y ejecutar
dotnet restore
dotnet run
```
La API estará disponible en `https://localhost:5001` o `http://localhost:5000`.  
Puedes probarla con **Swagger** entrando a `https://localhost:5001/swagger`.

### Entity Framework
```bash
cd Entity-Movil-1

# Restaurar dependencias
dotnet restore

# Aplicar migraciones a la base de datos
dotnet ef database update

# Ejecutar
dotnet run
```

### Windows Forms
Abrir el archivo `.sln` directamente con **Visual Studio 2022** y presionar `F5` para ejecutar.

---

## 🛠️ Tecnologías usadas

| Tecnología | Uso |
|---|---|
| C# / .NET 8 | Lenguaje principal |
| ASP.NET Core Web API | Creación de APIs REST |
| Entity Framework Core | ORM para base de datos |
| SQL Server / SQLite | Motor de base de datos |
| Windows Forms | Aplicaciones de escritorio |
| Swagger / Postman | Pruebas de endpoints |

---

## 📌 Requisitos previos

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- Visual Studio 2022 (recomendado) o VS Code con extensión C#
- SQL Server o SQLite (para proyectos con Entity Framework)
- Postman o Swagger para probar las APIs

---

## 👤 Autor

Yeiner Parra Rincon  
Competidor WorldSkills Colombia 🇨🇴  
https://github.com/YeinerParraRincon
