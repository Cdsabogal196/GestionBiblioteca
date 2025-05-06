
# Gestion De Biblioteca
## Instalación

Para instalar y ejecutar el proyecto se debe seguir las siguientes instrucciones:

1. **Descargar el proyecto:**  
Descarga los archivos del proyecto o clona el repositorio en tu local.

2. **Crear la base de datos:** 
Dentro del sistema de gestion  SQL Server Management Studio crea una base de datos llamada Library.

3. **Cambiar la cadena de conexión**: En el archivo Web.config en la ruta principal, cambia la cadena de conexión por la que tengas en la base de datos que creaste:

```
  <connectionStrings>
	  <add name="DefaultConnection" connectionString="Data Source=ReemplazarCadenaDeConexión; Initial Catalog=Library; Integrated Security=True" providerName="System.Data.SqlClient" />
  </connectionStrings>
```


4. **Ejecutar migraciones**:
En la consola del administrador de paquetes ejecute los siguientes comandos, los cuales permitirán crear la migración y actualizar la base de datos según la migración creada. Esto creará las tablas en base de datos y las actualizará cuando haya algun cambio en el modelo:

```Add-Migration InitialCreate```

```Update-Database```


5. **Ejecute el proyecto**
De clic en ejecutar el proyecto y siga la url que se abre en el navegador, por ejemplo:`https://localhost:44357`. Desde aqui podra realizar la gestion de los libros y autores almacenados en la biblioteca.


## Estructura del proyecto

1. **Patrones y Prácticas Implementadas**:

**MVC (Modelo-Vista-Controlador):**

El proyecto se compone de las siguientes partes:

1. Las vistas son la capa mas superficial, desde la que se configura la parte visual y los elementos graficos que el usuario podrá visualizar en la pagina web.

2. Los controladores exponen los servicios para que estos puedan ser consumidos desde las vistas, y de esta manera el usuario podrá hacer uso de las diferentes funcionalidades de la aplicación.

3. La capa de servicios contiene la lógica de negocio, en la que se realizan todas las operaciones internas.

4. En los repositorios se obtiene la información necesaria y se hacen operaciones sobre base de datos.

5. Los modelos representan los objetos utilizados para el manejo de información en el programa, de la siguiente manera:

 - Las **entidades** son las que se usan para realizar las operaciones sobre las tablas en la base de datos.

 - Los **DTO** se utilizan para recibir y enviar la información desde el controlador hacia la vista, además de transferir información entre las diferentes capas de la aplicación.  Sirve para diferenciar entre los modelos de base de datos y objetos de transferencia.


**Inyección de Dependencias**

Con ayuda de la libreria Unity.Mvc, se realiza la inyección de dependencias de los diferentes servicios para ser usados por el controlador.

## Descripcion de patrones y practicas implementadas:

El proyecto está basado en tres practicas de desarrollo diferentes:

La primera es el uso del patrón Modelo-Vista-Controlador (MVC). Se uso para separar las estructuras del código :

1. Modelo: Se encarga de la lógica de los datos y la interacción con la base de datos.

2. Vista: Es la encargada de la presentación de los datos, lo que el usuario ve en la interfaz de usuario.

3. Controlador: Actúa como intermediario entre el Modelo y la Vista, enviando la información hacia la capa del modelo y devolviendola hacia la vista cuando es necesario.

Además de eso, el proyecto maneja una arquitectura en capas para dividir la aplicación:

1.  Servicios (Books and Authors), maneja la lógica de negocio y las operaciones.

2. Acceso a Datos (Repositories),  se encarga de la persistencia y operaciones en base de datos.

El último patrón utilizado es el patrón repositorio, el cual permite garantizar la escalabilidad en el uso de la base de datos, facilitando tanto su gestión como la migración del proyecto en caso de cambio de base de datos.

