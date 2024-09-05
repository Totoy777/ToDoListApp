# Aplicación de Gestión de Tareas

## Descripción

Esta es una aplicación de consola desarrollada en C# utilizando .NET Framework 4.8. Su propósito es gestionar una lista de tareas (To-Do List), permitiendo a los usuarios agregar, listar, marcar como completadas y eliminar tareas.

## Requisitos

- .NET Framework 4.8
- Visual Studio 2019 o posterior (recomendado)

## Funcionalidades

1. **Agregar tareas:**
   - Permite agregar nuevas tareas con una descripción y una fecha límite opcional.

2. **Listar tareas:**
   - Muestra un listado de todas las tareas registradas.

3. **Marcar tareas como completadas:**
   - Permite marcar una tarea específica como completada.

4. **Eliminar tareas:**
   - Permite eliminar una tarea específica de la lista.

## Requerimientos Técnicos

1. **Uso de Clases y Objetos:**
   - Se utiliza una clase `Task` para representar las tareas.
   - Principios de encapsulación aplicados.

2. **Manejo de Colecciones:**
   - Se usa una lista genérica (`List<Task>`) para almacenar las tareas.

3. **Interacción con el Usuario:**
   - Implementa un menú de opciones para interactuar con el usuario a través de la consola.

4. **Manejo de Errores:**
   - Manejo básico de excepciones para entradas inválidas y fechas incorrectas.

## Uso

1. **Configurar Idioma:**
   - Al iniciar la aplicación, selecciona el idioma (Español o Inglés).

2. **Menú Principal:**
   - Agregar nueva tarea
   - Listar todas las tareas
   - Marcar tarea como completada
   - Eliminar tarea
   - Salir

3. **Ejemplo de Entrada:**
   - Cuando se selecciona "Agregar nueva tarea", se solicita la descripción y la fecha límite (si se desea).

## Ejecución

Para ejecutar la aplicación:

1. Abre el proyecto en Visual Studio.
2. Compila y ejecuta la aplicación (`Ctrl+F5` para iniciar sin depurar).
3. Sigue las instrucciones en la consola para interactuar con la aplicación.

## Mensaje de Despedida

Al salir de la aplicación, se mostrará un mensaje de despedida con un diseño visualmente atractivo, agradeciendo al usuario por utilizar la aplicación y deseándole un buen día.

## Contribuciones

Si deseas contribuir a este proyecto, por favor realiza un fork del repositorio y envía un pull request con tus mejoras.

## Licencia

Este proyecto está licenciado bajo los términos de la licencia MIT.

