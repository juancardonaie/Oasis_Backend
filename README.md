# Oasis Backend API

API REST desarrollada en **ASP.NET Core** que actúa como capa de lógica de negocio para la aplicación móvil **Oasis**, una app de gestión de inventario conectada a **Firebase Firestore**.

## Propósito

Esta API centraliza la lógica del negocio, evitando que la app Flutter se comunique directamente con Firestore. Flutter delega las operaciones a esta API, que se encarga de validar y ejecutar las acciones sobre la base de datos.

## Tecnologías

- ASP.NET Core Web API
- Google Cloud Firestore (via Application Default Credentials)
- Swagger / OpenAPI

## Endpoints disponibles

| Método | Ruta | Descripción |
|--------|------|-------------|
| GET | /api/products | Obtener todos los productos |
| GET | /api/products/{id} | Obtener un producto por ID |
| POST | /api/products | Crear un nuevo producto |
| PUT | /api/products/{id} | Actualizar un producto |
| DELETE | /api/products/{id} | Eliminar un producto |

## Funcionalidad implementada

- Inserción de productos en Firestore desde Flutter vía API

## Estructura del proyecto

oasis_backend/
├── Controllers/
│   └── ProductsController.cs
├── Models/
│   └── Product.cs
├── Services/
│   └── ProductService.cs
├── Program.cs
└── oasis_backend.csproj

## Autenticación con Firestore

Se utiliza **Application Default Credentials (ADC)** mediante Google Cloud CLI, debido a restricciones del proyecto institucional que impiden generar claves privadas directamente desde Firebase.

## Ejecución local

```bash
dotnet run
```

La API estará disponible en `http://localhost:5214`.
La documentación Swagger en `http://localhost:5214/swagger`.