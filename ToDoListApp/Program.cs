using System;
using System.Collections.Generic;
using System.Threading;

namespace Prueba_Tecnica
{
    /// <summary>
    /// Representa una tarea en la lista de tareas.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Descripción de la tarea.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Fecha límite para completar la tarea. Puede ser null si no se establece.
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Estado de la tarea (completada o no).
        /// </summary>
        public bool IsCompleted { get; private set; }

        /// <summary>
        /// Constructor para inicializar una nueva tarea.
        /// </summary>
        /// <param name="description">Descripción de la tarea.</param>
        /// <param name="dueDate">Fecha límite para completar la tarea (opcional).</param>
        public Task(string description, DateTime? dueDate = null)
        {
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
        }

        /// <summary>
        /// Marca la tarea como completada.
        /// </summary>
        public void CompleteTask()
        {
            IsCompleted = true;
        }

        /// <summary>
        /// Retorna una representación en cadena de la tarea.
        /// </summary>
        /// <returns>Cadena que representa la tarea.</returns>
        public override string ToString()
        {
            var dueDateString = DueDate.HasValue ? DueDate.Value.ToShortDateString() : "No especificada";
            return $"Descripción: {Description}, Fecha Límite: {dueDateString}, Completada: {IsCompleted}";
        }
    }

    internal class Program
    {
        // Lista para almacenar las tareas
        static List<Task> tasks = new List<Task>();
        static string idiomaCliente;
        static bool running;

        // Mensajes
        const string MSG_ADD_TASK_SPANISH = "Descripción de la tarea: ";
        const string MSG_DUE_DATE_SPANISH = "Fecha límite (dd/mm/yyyy, opcional): ";
        const string MSG_ADD_TASK_ENGLISH = "Task description: ";
        const string MSG_DUE_DATE_ENGLISH = "Due date (dd/mm/yyyy, optional): ";

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        static void Main(string[] args)
        {
            ConfigurarIdioma();
            running = true;

            while (running)
            {
                MostrarMenu();
                ManejarSeleccionUsuario();
            }

            MostrarMensajeDespedida();
        }

        /// <summary>
        /// Muestra el menú principal según el idioma seleccionado.
        /// </summary>
        private static void MostrarMenu()
        {
            Console.Clear();
            if (idiomaCliente == "1") // Español
            {
                Console.WriteLine("\n    === GESTIÓN DE TAREAS ===\n");
                Console.WriteLine("1. Agregar nueva tarea");
                Console.WriteLine("2. Listar todas las tareas");
                Console.WriteLine("3. Marcar tarea como completada");
                Console.WriteLine("4. Eliminar tarea");
                Console.WriteLine("5. Salir");
                Console.Write("\nSelecciona una opción: ");
            }
            else // Inglés
            {
                Console.WriteLine("\n    === TASK MANAGEMENT ===\n");
                Console.WriteLine("1. Add new task");
                Console.WriteLine("2. List all tasks");
                Console.WriteLine("3. Mark task as completed");
                Console.WriteLine("4. Delete task");
                Console.WriteLine("5. Exit");
                Console.Write("\nSelect an option: ");
            }
        }

        /// <summary>
        /// Maneja la selección del usuario del menú principal.
        /// </summary>
        private static void ManejarSeleccionUsuario()
        {
            switch (Console.ReadLine())
            {
                case "1":
                    AgregarTarea();
                    break;
                case "2":
                    ListarTareas();
                    break;
                case "3":
                    CompletarTarea();
                    break;
                case "4":
                    EliminarTarea();
                    break;
                case "5":
                    SalirAplicacion();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }
        }

        /// <summary>
        /// Configura el idioma del cliente y muestra la introducción de la aplicación.
        /// </summary>
        private static void ConfigurarIdioma()
        {
            Console.Title = "ToDoListApp | By: Andrés Cardona";
            MostrarAnimacionInicial();

            bool idiomaValido = false;
            while (!idiomaValido)
            {
                Console.Clear();
                Console.WriteLine("SELECCIONE EL IDIOMA / SELECT THE LANGUAGE");
                Console.WriteLine("ESPAÑOL = 1       ENGLISH = 2");
                string idioma = Console.ReadLine();

                if (idioma == "1" || idioma == "2")
                {
                    idiomaCliente = idioma;
                    idiomaValido = true;
                }
                else
                {
                    Console.WriteLine("Idioma no válido. Intenta de nuevo.");
                }
            }
        }

        /// <summary>
        /// Muestra una animación inicial al iniciar la aplicación.
        /// </summary>
        private static void MostrarAnimacionInicial()
        {
            int retardo = 700;
            string[] animacion = {
                "          ____ ___________   ___    _________   __________  ____  _____",
                "   / __ )/  _/ ____/ | / / |  / / ____/ | / /  _/ __ \\/ __ \\/ ___/",
                "  / __  |/ // __/ /  |/ /| | / / __/ /  |/ // // / / / / / /\\__ \\ ",
                " / /_/ // // /___/ /|  / | |/ / /___/ /|  // // /_/ / /_/ /___/ / ",
                "/_____/___/_____/_/ |_/  |___/_____/_/ |_/___/_____/\\____//____/  "
            };

            Console.Clear();
            foreach (string linea in animacion)
            {
                Console.WriteLine(linea);
                Thread.Sleep(retardo / 3);
            }
            Thread.Sleep(retardo);
        }

        /// <summary>
        /// Permite agregar una nueva tarea a la lista.
        /// </summary>
        private static void AgregarTarea()
        {
            string descripcion;
            DateTime? fechaLimite = null;

            if (idiomaCliente == "1")
            {
                Console.Write(MSG_ADD_TASK_SPANISH);
                descripcion = Console.ReadLine();
                fechaLimite = ObtenerFechaLimite(MSG_DUE_DATE_SPANISH);
            }
            else
            {
                Console.Write(MSG_ADD_TASK_ENGLISH);
                descripcion = Console.ReadLine();
                fechaLimite = ObtenerFechaLimite(MSG_DUE_DATE_ENGLISH);
            }

            tasks.Add(new Task(descripcion, fechaLimite));
            Console.WriteLine(idiomaCliente == "1" ? "Tarea agregada exitosamente." : "Task added successfully.");
            Console.ReadKey();
        }

        /// <summary>
        /// Solicita al usuario una fecha límite válida. Si la entrada está vacía, se devuelve null.
        /// </summary>
        /// <param name="mensaje">Mensaje para solicitar la fecha.</param>
        /// <returns>Fecha válida o null si no se especifica.</returns>
        private static DateTime? ObtenerFechaLimite(string mensaje)
        {
            while (true)
            {
                Console.Write(mensaje);
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    return null;
                }

                if (DateTime.TryParse(input, out DateTime fechaLimite))
                {
                    return fechaLimite;
                }
                else
                {
                    Console.WriteLine(idiomaCliente == "1" ? "Fecha no válida. Intenta de nuevo." : "Invalid date. Please try again.");
                }
            }
        }

        /// <summary>
        /// Muestra todas las tareas registradas.
        /// </summary>
        private static void ListarTareas()
        {
            Console.WriteLine(idiomaCliente == "1" ? "\n=== LISTA DE TAREAS ===" : "\n=== TASK LIST ===");

            if (tasks.Count == 0)
            {
                Console.WriteLine(idiomaCliente == "1" ? "No hay tareas registradas." : "No tasks registered.");
            }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {tasks[i]}");
                }
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Permite marcar una tarea como completada.
        /// </summary>
        private static void CompletarTarea()
        {
            ListarTareas();
            Console.Write(idiomaCliente == "1" ? "Número de tarea a completar: " : "Task number to complete: ");

            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks[taskNumber - 1].CompleteTask();
                Console.WriteLine(idiomaCliente == "1" ? "Tarea completada." : "Task completed.");
            }
            else
            {
                Console.WriteLine(idiomaCliente == "1" ? "Número de tarea no válido." : "Invalid task number.");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Elimina una tarea de la lista.
        /// </summary>
        private static void EliminarTarea()
        {
            ListarTareas();
            Console.Write(idiomaCliente == "1" ? "Número de tarea a eliminar: " : "Task number to delete: ");

            if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
            {
                tasks.RemoveAt(taskNumber - 1);
                Console.WriteLine(idiomaCliente == "1" ? "Tarea eliminada." : "Task deleted.");
            }
            else
            {
                Console.WriteLine(idiomaCliente == "1" ? "Número de tarea no válido." : "Invalid task number.");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Finaliza la ejecución de la aplicación y muestra un mensaje de despedida.
        /// </summary>
        private static void SalirAplicacion()
        {
            running = false;
        }

        /// <summary>
        /// Muestra un mensaje de despedida al salir de la aplicación.
        /// </summary>
        private static void MostrarMensajeDespedida()
        {
            Console.Clear();
            string mensajeDespedida = idiomaCliente == "1"
                ? "¡Gracias por usar la aplicación de gestión de tareas!\nHasta luego. ¡Que tengas un excelente día!"
                : "Thank you for using the Task Management application!\nGoodbye. Have a great day!";

            string lineaDecorativa = new string('=', mensajeDespedida.Length);

            Console.WriteLine(lineaDecorativa);
            Console.WriteLine(mensajeDespedida);
            Console.WriteLine(lineaDecorativa);

            Thread.Sleep(3000); // Espera 3 segundos antes de cerrar la aplicación
        }

    }
}
