using System;
using System.Collections.Generic;

namespace SistemaDeRecursosHumanos
{
    class Program
    {
        static void Main(string[] args)
        {
            Menus menus = new Menus();
            menus.MostrarMenu();
        }
    }

    class Empleado
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public decimal Salario { get; set; }

        public Empleado(string cedula, string nombre, string direccion, string telefono, decimal salario)
        {
            Cedula = cedula;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            Salario = salario;
        }
    }

    class Menus
    {
        List<Empleado> empleados = new List<Empleado>();

        public void MostrarMenu()
        {
            List<Empleado> empleados = new List<Empleado>();
            bool salir = false;
            int opcion;

            while (!salir) { 
            Console.WriteLine("Menú Principal");
            Console.WriteLine("1. Agregar Empleados");
            Console.WriteLine("2. Consultar Empleados");
            Console.WriteLine("3. Modificar Empleados");
            Console.WriteLine("4. Borrar Empleados");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("0. Salir");

            Console.Write("Seleccione una opción: ");


            try
            {
                Console.Write("Seleccione una opción: ");
                if (int.TryParse(Console.ReadLine(), out  opcion))
                {

                    switch (opcion)
                    {
                        case 1:
                            // Agregar Empleado
                            Console.WriteLine("Agregar Empleado");
                            Console.Write("Cedula: ");
                            string cedula = Console.ReadLine();
                            Console.Write("Nombre: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Dirección: ");
                            string direccion = Console.ReadLine();
                            Console.Write("Teléfono: ");
                            string telefono = Console.ReadLine();
                            Console.Write("Salario: ");
                            decimal salario;
                            if (decimal.TryParse(Console.ReadLine(), out salario))
                            {
                                Empleado nuevoEmpleado = new Empleado(cedula, nombre, direccion, telefono, salario);
                                empleados.Add(nuevoEmpleado);
                                Console.WriteLine("Empleado agregado con éxito.");
                            }
                            else
                            {
                                Console.WriteLine("Error al ingresar el salario. Introduzca un valor válido.");
                            }
                            break;

                        case 2:
                            // Consultar Empleado
                            Console.Write("Digite la cédula del empleado a consultar: ");
                            string cedulaConsulta = Console.ReadLine();
                            Empleado empleadoEncontrado = empleados.Find(e => e.Cedula == cedulaConsulta);
                            if (empleadoEncontrado != null)
                            {
                                Console.WriteLine($"Empleado encontrado - Nombre: {empleadoEncontrado.Nombre}, Dirección: {empleadoEncontrado.Direccion}, Teléfono: {empleadoEncontrado.Telefono}, Salario: {empleadoEncontrado.Salario}");
                            }
                            else
                            {
                                Console.WriteLine("Empleado no encontrado.");
                            }
                            break;

                        case 3:
                            // Modificar Empleado
                            Console.Write("Digite la cédula del empleado a modificar: ");
                            string cedulaModificacion = Console.ReadLine();
                            Empleado empleadoAModificar = empleados.Find(e => e.Cedula == cedulaModificacion);
                            if (empleadoAModificar != null)
                            {
                                Console.WriteLine("Modificando empleado...");
                                Console.Write("Nuevo Nombre: ");
                                empleadoAModificar.Nombre = Console.ReadLine();
                                Console.Write("Nueva Dirección: ");
                                empleadoAModificar.Direccion = Console.ReadLine();
                                Console.Write("Nuevo Teléfono: ");
                                empleadoAModificar.Telefono = Console.ReadLine();
                                Console.Write("Nuevo Salario: ");
                                decimal nuevoSalario;
                                if (decimal.TryParse(Console.ReadLine(), out nuevoSalario))
                                {
                                    empleadoAModificar.Salario = nuevoSalario;
                                    Console.WriteLine("Empleado modificado con éxito.");
                                }
                                else
                                {
                                    Console.WriteLine("Error al ingresar el nuevo salario. Introduzca un valor válido.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Empleado no encontrado.");
                            }
                            break;
                        case 4:
                            // Borrar Empleado
                            Console.Write("Digite la cédula del empleado a borrar: ");
                            string cedulaBorrado = Console.ReadLine();
                            Empleado empleadoABorrar = empleados.Find(e => e.Cedula == cedulaBorrado);
                            if (empleadoABorrar != null)
                            {
                                empleados.Remove(empleadoABorrar);
                                Console.WriteLine("Empleado eliminado con éxito.");
                            }
                            else
                            {
                                Console.WriteLine("Empleado no encontrado. No se realizó ninguna eliminación.");
                            }
                            break;
                        case 5:

                            empleados.Clear(); // Limpia la lista de empleados
                            Console.WriteLine("Arreglos de empleados inicializados.");
                            break;
                        case 6:
                            // Reportes
                            Console.WriteLine("Menú de Reportes");
                            Console.WriteLine("1. Consultar empleados con número de cédula");
                            Console.WriteLine("2. Listar todos los empleados ordenados por nombre");
                            Console.WriteLine("3. Calcular y mostrar el promedio de los salarios");
                            Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo");
                            Console.WriteLine("0. Volver al Menú Principal");

                            Console.Write("Seleccione una opción: ");
                            int opcionReporte = int.Parse(Console.ReadLine());



                            switch (opcionReporte)
                            {
                                case 1:
                                    Console.Write("Digite la cédula del empleado a consultar: ");
                                    cedulaConsulta = Console.ReadLine();
                                    empleadoEncontrado = empleados.Find(e => e.Cedula == cedulaConsulta);
                                    if (empleadoEncontrado != null)
                                    {
                                        Console.WriteLine($"Empleado encontrado - Nombre: {empleadoEncontrado.Nombre}, Dirección: {empleadoEncontrado.Direccion}, Teléfono: {empleadoEncontrado.Telefono}, Salario: {empleadoEncontrado.Salario}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Empleado no encontrado.");
                                    }
                                    break;


                                case 2:
                                    // Listar todos los empleados ordenados por nombre
                                    var empleadosOrdenados = empleados.OrderBy(e => e.Nombre);
                                    Console.WriteLine("Lista de Empleados Ordenados por Nombre:");
                                    foreach (var empleado in empleadosOrdenados)
                                    {
                                        Console.WriteLine($"Nombre: {empleado.Nombre}, Cédula: {empleado.Cedula}");
                                    }
                                    break;

                                case 3:
                                    // Calcular y mostrar el promedio de los salarios
                                    if (empleados.Count > 0)
                                    {
                                        decimal promedioSalarios = empleados.Average(e => e.Salario);
                                        Console.WriteLine($"El promedio de salarios es: {promedioSalarios}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No hay empleados para calcular el promedio de salarios.");
                                    }
                                    break;

                                case 4:
                                    // Calcular y mostrar el salario más alto y el más bajo
                                    if (empleados.Count > 0)
                                    {
                                        decimal salarioMaximo = empleados.Max(e => e.Salario);
                                        decimal salarioMinimo = empleados.Min(e => e.Salario);
                                        Console.WriteLine($"Salario más alto: {salarioMaximo}");
                                        Console.WriteLine($"Salario más bajo: {salarioMinimo}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No hay empleados para calcular los salarios más alto y más bajo.");
                                    }
                                    break;

                                case 0:
                                    Console.WriteLine("Saliendo del sistema...");
                                    salir = true; // Esto permite salir del bucle y terminar el programa
                                    break;

                                default:
                                    Console.WriteLine("Opción no válida.");
                                    break;
                            }
                            break;
                        case 0:
                            Console.WriteLine("Saliendo del sistema...");
                            salir = true; // Esto permite salir del bucle y terminar el programa
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número válido.");
            }
            
    }
    }
}
}
