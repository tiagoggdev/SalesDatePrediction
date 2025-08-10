
# Sales Date Prediction App

Aplicación para la predicción de fechas de nuevas órdenes de clientes basada en su historial de pedidos. La solución incluye un backend en .NET, un frontend en Angular y una base de datos SQL Server. Se proporciona soporte para ejecución tanto mediante `docker-compose` como de forma manual.

## Contenido del proyecto

- `d3/`: Carpeta que contiene la solución al punto de crear un gráfico con d3.js
- `db/init-db/`: Scripts y configuración para inicializar la base de datos (Ejecutados automáticamente si usas docker, o manualmente si no)
- `postman/`: Colección postman
- `queries-db/`: Carpeta que contiene las consultas requeridas en el punto dos
- `SalesDatePrediction-back/`: Backend en ASP.NET Core Web API
- `SalesDatePrediction-web-app/`: Frontend en Angular 17
- `README.md`: Instrucciones del proyecto
- `docker-compose.yml`: Archivo de orquestación de contenedores
---

## Tecnologías utilizadas

### Backend

- .NET Core 9
- ASP.NET Core Web API
- Entity Framework Core (Database-First)
- MediatR para CQRS
- FluentValidation para validaciones
- SQL Server
- Docker

### Frontend

- Angular 17
- Angular Material
- Docker

### Base de Datos

- SQL Server
- Scripts incluidos:
  - `DBSetup.sql`: Creación de base de datos y tablas
  - `create-view-for-back.sql`: Creación de vista para obtener predicción de fecha de próxima venta
  - `spneworder.sql`: Procedimiento almacenado para crear una nueva orden
- Docker

---
## Postman

En la raíz del repositorio se encuentra una carpeta llamada /postman. Dentro encontrarás la siguiente colección
- SalesDatePrediction.API.postman_collection.json

Puedes importarla en Postman u otra plataforma API

## Primer Paso
### Clonar repositorio
```bash

git  clone  https://github.com/tiagoggdev/SalesDatePrediction.git

cd  SalesDatePrediction

```
---
Puedes ejecutar el proyecto de dos maneras:

## 1. Ejecutar el proyecto  con Docker Compose

### Requisitos
- Docker

### Pasos

1.  **Verifica que los scripts de base de datos estén en la carpeta `init-db/` 

  

2.  Ejecuta Docker Compose:

  

```bash

docker-compose  up  --build

```

  

Esto construirá y levantará los siguientes servicios:

  

-  **db**: Contenedor con SQL Server 2019 y los scripts necesarios ya ejecutados.

-  **api_container**: Web API ASP.NET Core.
-  **webapp_container**: Aplicación web Angular.

  

3.  **Acceso a los servicios:**

| API | http://localhost:5000 |
| Web App | http://localhost:4200/ |

| SQL Server | localhost:1433 (usuario: `sa`, password: `salesPred314!`) |
  

---

  

## 2. Ejecutar el proyecto manualmente (sin Docker)

  

### 1. Configurar la base de datos

  

- Asegúrate de tener SQL Server instalado y en ejecución.

- Ejecuta los siguientes scripts en orden:

1.  `DBSetup.sql`

2.  `create-view-for-back.sql`

3.  `spneworder.sql`

  

### 2. Ejecutar el backend

  

```bash

cd  SalesDatePrediction-back

dotnet  restore

dotnet  build

cd SalesDatePrediction.API
dotnet  run

```

  

Verifica que esté escuchando en `http://localhost:5000`.

  

### 3. Ejecutar el frontend
Abra otra terminal, dentro de Sales-Date-Prediction ejecute:
  

```bash

cd  SalesDatePrediction-web-app

npm  install

ng  serve

```

  

La aplicación estará disponible en `http://localhost:4200`.

  ---
## Pruebas
El proyecto incluye pruebas unitarias para el proyecto .NET que cubren:

-   **Validaciones con FluentValidation**:
    
    -   Validación de parámetros para consultas (por ejemplo, `CustomerId`, `PageNumber`, `PageSize`).
        
    -   Asegura que los comandos y queries no acepten datos inválidos antes de ser procesados.
        
-   **Casos de negocio para creación de órdenes**:
    
    -   Fallo si el cliente no existe.
        
    -   Fallo si el empleado no existe.
        
    -   Fallo si el transportista no existe.
        
    -   Fallo si el producto no existe.
        

Esto garantiza la robustez del sistema frente a entradas inválidas o referencias inexistentes en la base de datos.

Para ejecutar los tests:

1.  Abre una terminal en la raíz del proyecto.
    
2.  Navega a la carpeta de tests:

```bash
cd SalesDatePrediction-back/SalesDatePrediction.Test
dotnet test
```

---
### Gráfico con D3.js
En la ruta raíz se encuentra una carpeta llamada d3, dentro hay tres archivos:
index.html
styles.css
script.js
Sólo debe abrir el archivo .html para visualizar la solución.

## Notas

  

- El backend usa DB First con Entity Framework Core.

- Los scripts deben ser ejecutados antes de usar la aplicación si no se usa Docker.

