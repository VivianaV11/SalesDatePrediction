# Prueba Técnica - Desarrollador CODIFICO

## Descripción del Proyecto
Este proyecto consiste en una aplicación full-stack diseñada para predecir la fecha de la próxima compra de un cliente. La solución incluye:

1. Backend en .NET Framework con acceso a SQL Server con arquitectura basada en tres capas (API, DataProvider, Repository), siguiendo buenas practicas de desarrollo y principios SOLID 
2. Carpeta SQL donde se encuentran las consultas y el script para ingresar una nueva orden.
3. Frontend en Angular 18 para la interacción con el usuario y el consumo de la API.
4. Visualización de datos con D3.js, implementada en una aplicación separada utilizando JavaScript Vanilla.

## Arquitectura del Proyecto
La solución sigue una arquitectura de tres capas, organizada de la siguiente manera:

1. ## Capa de Presentación (API Layer) - SalesDatePrediction.API
- Contiene la API REST que expone los endpoints al frontend.
- Maneja las peticiones HTTP y coordina la lógica de negocio.
- Implementa los Controllers para interactuar con la lógica de negocio.

2. ## Capa de Negocio (Business Layer)  - SalesDatePrediction.DataProvider 
- Implementa la lógica de negocio y reglas empresariales.
- Coordina la comunicación entre la API y la capa de acceso a datos.
- Contiene servicios que procesan la información antes de enviarla al frontend o a la base de datos.

3. ## Capa de Acceso a Datos (DataAccess Layer) - SalesDatePrediction.Repository
- Se encarga de la comunicación con la base de datos SQL Server.
- Contiene la configuración de Entity Framework.
- Define las entidades (Models).


El frontend consume la API REST para interactuar con el sistema, y la visualización de datos se realiza en una aplicación separada utilizando D3.js.

## Prerequisitos
Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

1. Node.js v18+
2. Angular CLI v18.2.14
3. SQL Server con la base de datos de la prueba cargada
4. Visual Studio (para ejecutar la API)

# Ejecución de la solución
## Backend (.NET API)
1. Abrir la SalesDatePrediction.API en Visual Studio
2. Instalar dependencias si es necesario
3. Ejecutar el proyecto para levantar la API

## Frontend (Angular)
1. Desde la terminal de Visual Studio Code Navegar hasta la carpeta llamada app-sales-date-prediction
2. Instalar las dependencias: npm install
3. Iniciar el servidor en angular: ng server
4. El navegador abrirá automáticamente la aplicación en: http://localhost:4200/

## Visualización de Datos (D3.js)
1. Abrir la carpeta VanillaJs.
2. Abrir el archivo index.html en un navegador 




