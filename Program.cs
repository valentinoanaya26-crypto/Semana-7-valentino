using Microsoft.SqlServer.Server;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace CASO_semana7

{

    internal class Program

    {

        static int max = 100;

        static string[] nombres = new string[max];

        static double[] notas = new double[max];

        static int contador = 0;

        static public void Titulo()

        {

            Console.WriteLine("*********************************");

            Console.WriteLine("   SISTEMA DE NOTAS ");

            Console.WriteLine("*********************************");

        }

        static public void Registrar_estudiante()

        {

            Console.WriteLine("Registro de estudiante nuevo:");

            if (contador >= max)

            {

                Console.WriteLine("LLegamos a la capacidad maxima");

                return;

            }

            Console.WriteLine("Ingresar nombres:");

            string nombre = Console.ReadLine();

            double nota;

            while (true)

            {

                Console.WriteLine("Ingresar nota:");

                nota = double.Parse(Console.ReadLine());

                if (nota >= 0 && nota <= 20)

                {

                    break;

                }

                Console.WriteLine("Error:La nota debe ser [0-20]: ");

            }

            nombres[contador] = nombre;

            notas[contador] = nota;

            contador++;

            Console.WriteLine("Estudiante registrado correctamente");

        }

        static public void mostrar()

        {

            Console.WriteLine("**************Listado de Estudiantes***************");

            if (contador == 0)

            {

                Console.WriteLine("No hay datos por mostrar:");

                return;

            }

            for (int i = 0; i < contador; i++)

            {

                Console.WriteLine((i + 1) + ".-" + nombres[i] + ".-Nota:" + notas[i]);

            }

        }

        static public void buscar_estudiante()

        {

            Console.WriteLine("**************Busqueda de Estudiantes***************");

            if (contador == 0)

            {

                Console.WriteLine("No hay datos por mostrar:");

                return;

            }

            Console.WriteLine("Ingresar nombre a buscar:");

            string nombre = Console.ReadLine().ToLower();

            bool encontrado = false;

            for (int i = 0; i < contador; i++)

            {

                if (nombres[i].ToLower() == nombre.ToLower())

                {

                    Console.WriteLine("Estudiante encontrado: " + nombres[i] + ".-Nota:" + notas[i]);

                    encontrado = true;

                    break;

                }

            }

            if (!encontrado)

            {

                Console.WriteLine("Estudiante no encontrado");

            }

        }

        static public void modificar_nota()

        {

            Console.WriteLine("**************Modificar nota de Estudiantes***************");

            if (contador == 0)

            {

                Console.WriteLine("No hay datos por mostrar:");

                return;

            }

            Console.WriteLine("Ingresar nombre a buscar:");

            string nombre = Console.ReadLine();

            bool encontrado = false;

            for (int i = 0; i < contador; i++)

            {

                if (nombres[i].ToLower() == nombre.ToLower())

                {

                    Console.WriteLine("Estudiante encontrado: " + nombres[i] + ".-Nota:" + notas[i]);

                    double nuevaNota;

                    while (true)

                    {

                        Console.WriteLine("Ingresar nueva nota:");

                        nuevaNota = double.Parse(Console.ReadLine());

                        if (nuevaNota >= 0 && nuevaNota <= 20)

                        {

                            break;

                        }

                        Console.WriteLine("Error:La nota debe ser [0-20]: ");

                    }

                    notas[i] = nuevaNota;

                    Console.WriteLine("Nota modificada correctamente");

                    encontrado = true;

                    break;

                }

            }

            if (!encontrado)

            {

                Console.WriteLine("Estudiante no encontrado");

            }

        }

        static public void burbuja()

        {

            Console.WriteLine("**************Reporte de Estudiantes Ordenado por Burbuja***************");

            if (contador == 0)

            {

                Console.WriteLine("No hay datos por mostrar:");

                return;

            }

            for (int i = 0; i < contador - 1; i++)

            {

                for (int j = 0; j < contador - i - 1; j++)

                {

                    if (notas[j] > notas[j + 1])

                    {

                        double tempNota = notas[j];

                        notas[j] = notas[j + 1];

                        notas[j + 1] = tempNota;

                        string tempNombre = nombres[j];

                        nombres[j] = nombres[j + 1];

                        nombres[j + 1] = tempNombre;

                    }

                }

            }

            mostrar();

        }

        static public void seleccion_desc()

        {

            Console.WriteLine("**************Reporte por Seleccion Descendente (DESC)***************");

            if (contador == 0)

            {

                Console.WriteLine("No hay datos por mostrar.");

                return;

            }



            for (int i = 0; i < contador - 1; i++)

            {

                int maxIndex = i;

                for (int j = i + 1; j < contador; j++)

                {

                    if (notas[j] > notas[maxIndex])

                    {

                        maxIndex = j;

                    }

                }



                // Intercambio de notas

                double tempNota = notas[i];

                notas[i] = notas[maxIndex];

                notas[maxIndex] = tempNota;



                // Intercambio de nombres

                string tempNombre = nombres[i];

                nombres[i] = nombres[maxIndex];

                nombres[maxIndex] = tempNombre;

            }



            mostrar();

        }

        static public void promedio_y_maxima()

        {

            Console.WriteLine("**************Promedio y Nota Maxima***************");

            if (contador == 0)

            {

                Console.WriteLine("No hay datos por mostrar.");

                return;

            }

            double suma = 0;

            double notaMax = notas[0];

            for (int i = 0; i < contador; i++)

            {

                suma += notas[i];

                if (notas[i] > notaMax)

                {

                    notaMax = notas[i];

                }

            }

            double promedio = suma / contador;



            Console.WriteLine("Promedio general de notas: " + promedio);

            Console.WriteLine("Nota maxima alcanzada: " + notaMax);

        }

        static void Main(string[] args)

        {

            Titulo();

            int opc = 0;

            while (opc != 8)

            {

                Console.WriteLine("******MENU PRINCIPAL********");

                Console.WriteLine("[1] Registrar estudiante");

                Console.WriteLine("[2] Buscar estudiantes");

                Console.WriteLine("[3]Modificar nota");

                Console.WriteLine("[4] Mostrar lista sin ordenar");

                Console.WriteLine("[5] Mostrar reporte ordenador por burbuja");

                Console.WriteLine("[6] Mostrar por seleccion DESC");

                Console.WriteLine("[7]Proedio y nota maxima");

                Console.WriteLine("[8]Salir");

                Console.Write("Ingresar opcion:");



                if (!int.TryParse(Console.ReadLine(), out opc))

                {

                    Console.WriteLine("Error,ingresar un valor numerico:");

                    continue;

                }

                switch (opc)

                {

                    case 1:

                        Registrar_estudiante(); break;

                    case 2:

                        buscar_estudiante();

                        break;

                    case 3:

                        modificar_nota();

                        break;

                    case 4:

                        mostrar();

                        break;

                    case 5:

                        burbuja();

                        break;

                    case 6:

                        seleccion_desc();

                        break;

                    case 7:

                        promedio_y_maxima();

                        break;

                    case 8:

                        Console.Write("Gracias por usar el sistema");

                        break;

                    default:

                        Console.WriteLine("Opcion incorrecta...!!");

                        break;

                }



            }



        }



    }



}