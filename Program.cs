using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Git
{
    internal class Program
    {
        class Alumno
        {
            private string nombre;
            private float promedio1;
            private float promedio2;
            private float promedio3;

            public Alumno(string nombre, float promedio1, float promedio2, float promedio3)
            {
                this.nombre = nombre;
                this.promedio1 = promedio1;
                this.promedio2 = promedio2;
                this.promedio3 = promedio3;
            }

            public float CalcularPromedio()
            {
                return (promedio1 + promedio2 + (promedio3 * 2)) / 4;
            }
          
            public string ObtenerNombre()
            {
                return nombre;
            }


        }

        class Salon
        {
            private List<Alumno> alumnos = new List<Alumno>();

            public void RegistrarAlumno(Alumno alumno)
            {
                this.alumnos.Add(alumno);
            }

            public List<Alumno> ObtenerAlumnos()
            {
                return alumnos;
            }

            public void RemoverAlumno(Alumno alumno)
            {
                this.alumnos.Remove(alumno);
            }

            public int CantidadAprobados()
            {
                int cantidad = 0;

                for (int i = 0; i<alumnos.Count; i++)
                {
                    if (alumnos[i].CalcularPromedio() >= 13)
                    {
                        cantidad = cantidad + 1;
                    }                    
                }
                return cantidad;
            }

            public int CantidadDesaprobados()
            {
                int cantidad = 0;

                for (int i = 0; i < alumnos.Count; i++)
                {
                    if (alumnos[i].CalcularPromedio() < 13)
                    {
                        cantidad = cantidad + 1;
                    }
                }
                return cantidad;
            }

            public List<Alumno> ObtenerListaAprobados()
            {
                List<Alumno> aprobados = new List<Alumno>();
                
                for (int i = 0; i < alumnos.Count; i++)
                {
                    if (alumnos[i].CalcularPromedio() >= 13)
                    {
                        aprobados.Add(alumnos[i]);
                    }
                }
                return aprobados; 
            }

            public List<Alumno> ObtenerListaDesaprobados()
            {
                List<Alumno> desaprobados = new List<Alumno>();

                for (int i = 0; i < alumnos.Count; i++)
                {
                    if (alumnos[i].CalcularPromedio() < 13)
                    {
                        desaprobados.Add(alumnos[i]);
                    }
                }
                return desaprobados;
            }

            public float CalcularPromedioSalon()
            {
                if (alumnos.Count == 0)
                {
                    return 0;
                }

                float suma = 0;

                for (int i = 0; i < alumnos.Count; i++)
                {
                    suma = suma + alumnos[i].CalcularPromedio();
                }

                return suma / alumnos.Count;
            }
        }

        static void Main(string[] args)
        {
            List<Salon> salones = new List<Salon>();

            int opcion = 0;

            while (opcion != 3)
            {
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("1. Crear salon");
                Console.WriteLine("2. Seleccionar salon");
                Console.WriteLine("3. Salir");
                Console.WriteLine("Ingrese una opcion:");

                int.TryParse(Console.ReadLine(), out opcion);
                Console.Clear();

                if (opcion == 1)
                {
                    Salon salon = new Salon();
                    salones.Add(salon);

                    Console.WriteLine("xXSALON CREADOXx");
                }

                if (opcion == 2)
                {
                    Console.WriteLine("SELECCIONE UN SALON:");

                    if (salones.Count == 0)
                    {
                        Console.WriteLine("NO EXISTEN SALONES CREADOS");
                    }

                    else
                    {

                        for (int i = 0; i < salones.Count; i++)
                        {
                            Console.WriteLine(i + " - Salon " + i);
                        }

                        Console.WriteLine("INGRESE EL NUMERO DEL SALON:");

                        int numeroSalon = 0;

                        while (!int.TryParse(Console.ReadLine(), out numeroSalon) ||
                               numeroSalon < 0 ||
                               numeroSalon >= salones.Count)
                        {
                            Console.WriteLine("INGRESE EL NUMERO DE UN SALON VALIDO:");
                        }

                        Salon salonSeleccionado = salones[numeroSalon];

                        int opcionSalon = 0;

                        while (opcionSalon != 8)
                        {
                            Console.WriteLine("SALON");
                            Console.WriteLine("1. Registrar alumno");
                            Console.WriteLine("2. Eliminar alumno");
                            Console.WriteLine("3. Cantidad de aprobados");
                            Console.WriteLine("4. Cantidad de desaprobados");
                            Console.WriteLine("5. Mostrar aprobados");
                            Console.WriteLine("6. Mostrar desaprobados");
                            Console.WriteLine("7. Promedio general");
                            Console.WriteLine("8. Volver");

                            int.TryParse(Console.ReadLine(), out opcionSalon);
                            Console.Clear();

                            if (opcionSalon == 1)
                            {
                                Console.WriteLine("Ingrese nombre:");
                                string nombre = Console.ReadLine();

                                bool nombreValido = false;

                                while (!nombreValido)
                                {
                                    nombreValido = true;

                                    if (nombre == "")
                                    {
                                        nombreValido = false;
                                    }

                                    for (int i = 0; i < nombre.Length; i++)
                                    {
                                        if (nombre[i] >= '0' && nombre[i] <= '9')
                                        {
                                            nombreValido = false;
                                        }
                                    }

                                    if (!nombreValido)
                                    {
                                        Console.WriteLine("Ingrese un nombre valido:");
                                        nombre = Console.ReadLine();
                                    }
                                }

                                Console.WriteLine("Ingrese promedio 1:");
                                float promedio1;
                                while (!float.TryParse(Console.ReadLine(), out promedio1))
                                {
                                    Console.WriteLine("Ingrese un numero:");
                                }

                                Console.WriteLine("Ingrese promedio 2:");
                                float promedio2;
                                while (!float.TryParse(Console.ReadLine(), out promedio2))
                                {
                                    Console.WriteLine("Ingrese un numero:");
                                }

                                Console.WriteLine("Ingrese promedio 3:");
                                float promedio3;
                                while (!float.TryParse(Console.ReadLine(), out promedio3))
                                {
                                    Console.WriteLine("Ingrese un numero:");
                                }

                                Alumno alumno = new Alumno(
                                    nombre,
                                    promedio1,
                                    promedio2,
                                    promedio3
                                    );

                                salonSeleccionado.RegistrarAlumno(alumno);

                                Console.WriteLine("Alumno Registrado");
                            }

                            if (opcionSalon == 2)
                            {
                                if (salonSeleccionado.ObtenerAlumnos().Count == 0)
                                {
                                    Console.WriteLine("No existen alumnos para eliminar.");
                                }
                                else
                                {
                                    for (int i = 0; i < salonSeleccionado.ObtenerAlumnos().Count; i++)
                                    {
                                        Console.WriteLine(i + " - " + salonSeleccionado.ObtenerAlumnos()[i].ObtenerNombre());
                                    }

                                    Console.WriteLine("Ingrese el numero del alumno:");

                                    int numeroAlumno = 0;

                                    while (!int.TryParse(Console.ReadLine(), out numeroAlumno) ||
                                           numeroAlumno < 0 ||
                                           numeroAlumno >= salonSeleccionado.ObtenerAlumnos().Count)
                                    {
                                        Console.WriteLine("Ingrese un numero de alumno valido:");
                                    }

                                    Alumno alumno = salonSeleccionado.ObtenerAlumnos()[numeroAlumno];

                                    salonSeleccionado.RemoverAlumno(alumno);

                                    Console.WriteLine("Alumno eliminado");
                                }
                            }

                            if (opcionSalon == 3)
                            {
                                Console.WriteLine("Cantidad de aprobados: " + salonSeleccionado.CantidadAprobados());
                            }

                            if (opcionSalon == 4)
                            {
                                Console.WriteLine("Cantidad de desaprobados: " + salonSeleccionado.CantidadDesaprobados());
                            }

                            if (opcionSalon == 5)
                            {
                                List<Alumno> aprobados = salonSeleccionado.ObtenerListaAprobados();

                                foreach (Alumno alumno in aprobados)
                                {
                                    Console.WriteLine(alumno.ObtenerNombre());
                                }
                            }

                            if (opcionSalon == 6)
                            {
                                List<Alumno> desaprobados = salonSeleccionado.ObtenerListaDesaprobados();

                                foreach (Alumno alumno in desaprobados)
                                {
                                    Console.WriteLine(alumno.ObtenerNombre());
                                }
                            }

                            if (opcionSalon == 7)
                            {
                                Console.WriteLine("Promedio general:" + salonSeleccionado.CalcularPromedioSalon());
                            }


                        }

                    } 
                }
            }
        }
    }
}
