using System;
using System.Collections.Generic;

namespace CineAsientos
{
    class Program
    {
        // Listas con las filas y columnas válidas (se usan para validar con IndexOf)
        static List<string> letrasFila = new List<string> { "A", "B", "C", "D", "E" };
        static List<string> numerosColumna = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8" };

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // La sala es una matriz de asientos: cada asiento tiene nombre y estado
            Asiento[,] sala = new Asiento[letrasFila.Count, numerosColumna.Count];

            // Al inicio todos los asientos están libres
            for (int f = 0; f < letrasFila.Count; f++)
            {
                for (int c = 0; c < numerosColumna.Count; c++)
                {
                    sala[f, c] = new Asiento() { Nombre = letrasFila[f] + numerosColumna[c], Ocupado = false };
                }
            }

            string opcion = "";

            while (opcion != "6")
            {
                MostrarMenu();
                opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    MostrarSala(sala);
                }
                else if (opcion == "2")
                {
                    ReservarAsiento(sala);
                }
                else if (opcion == "3")
                {
                    LiberarAsiento(sala);
                }
                else if (opcion == "4")
                {
                    ConsultarAsiento(sala);
                }
                else if (opcion == "5")
                {
                    MostrarEstadisticas(sala);
                }
                else if (opcion == "6")
                {
                    Console.WriteLine("Gracias por usar el sistema. ¡Hasta luego!");
                }
                else
                {
                    Console.WriteLine("Opción inválida. Elija un número del 1 al 6.");
                }

                if (opcion != "6")
                {
                    Console.WriteLine();
                    Console.WriteLine("Presione Enter para volver al menú...");
                    Console.ReadLine();
                }
            }
        }

        // ---------- MENÚ ----------

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("==================================================");
            Console.WriteLine("      SISTEMA DE ADMINISTRACIÓN DE ASIENTOS");
            Console.WriteLine("                 CINE - SALA 1");
            Console.WriteLine("==================================================");
            Console.WriteLine("  1. Mostrar asientos");
            Console.WriteLine("  2. Reservar asiento");
            Console.WriteLine("  3. Liberar asiento");
            Console.WriteLine("  4. Consultar disponibilidad");
            Console.WriteLine("  5. Estadísticas de ocupación");
            Console.WriteLine("  6. Salir");
            Console.WriteLine("==================================================");
            Console.Write("Seleccione una opción (1-6): ");
        }

        // ---------- MOSTRAR LA SALA ----------

        static void MostrarSala(Asiento[,] sala)
        {
            Console.WriteLine();
            Console.WriteLine("============== PANTALLA ==============");
            Console.WriteLine();

            // Números de las columnas
            Console.Write("     ");
            foreach (var numero in numerosColumna)
            {
                Console.Write($" {numero}  ");
            }
            Console.WriteLine();

            // Cada fila con su letra
            for (int f = 0; f < letrasFila.Count; f++)
            {
                Console.Write($"  {letrasFila[f]}  ");

                for (int c = 0; c < numerosColumna.Count; c++)
                {
                    if (sala[f, c].Ocupado)
                    {
                        Console.Write("[X] ");
                    }
                    else
                    {
                        Console.Write("[ ] ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("  [ ] Libre    [X] Ocupado");
        }

        // ---------- LEER FILA Y COLUMNA ----------

        // Pide la fila (A-E). Devuelve 0 a 4, o -1 si es inválida
        static int LeerFila()
        {
            Console.Write("Ingrese la fila (A-E): ");
            string texto = Console.ReadLine();

            if (texto == "")
            {
                Console.WriteLine("No ingresó ningún dato. Intente de nuevo.");
                return -1;
            }

            // IndexOf busca la letra en la lista y devuelve su posición (-1 si no está)
            int fila = letrasFila.IndexOf(texto.ToUpper());

            if (fila == -1)
            {
                Console.WriteLine("Fila inválida. Use una letra de la A a la E.");
            }

            return fila;
        }

        // Pide la columna (1-8). Devuelve 0 a 7, o -1 si es inválida
        static int LeerColumna()
        {
            Console.Write("Ingrese la columna (1-8): ");
            string texto = Console.ReadLine();

            if (texto == "")
            {
                Console.WriteLine("No ingresó ningún dato. Intente de nuevo.");
                return -1;
            }

            // IndexOf busca el número en la lista y devuelve su posición (-1 si no está)
            int columna = numerosColumna.IndexOf(texto);

            if (columna == -1)
            {
                Console.WriteLine("Columna inválida. Use un número del 1 al 8.");
            }

            return columna;
        }

        // ---------- RESERVAR ----------

        static void ReservarAsiento(Asiento[,] sala)
        {
            Console.WriteLine();
            Console.WriteLine("----------- RESERVAR ASIENTO -----------");

            int fila = LeerFila();
            if (fila == -1)
            {
                return;
            }

            int columna = LeerColumna();
            if (columna == -1)
            {
                return;
            }

            var asiento = sala[fila, columna];

            if (asiento.Ocupado)
            {
                Console.WriteLine($"El asiento {asiento.Nombre} ya está ocupado. Elija otro.");
            }
            else
            {
                asiento.Ocupado = true;
                Console.WriteLine($"Reservación exitosa: asiento {asiento.Nombre} ocupado.");
            }
        }

        // ---------- LIBERAR ----------

        static void LiberarAsiento(Asiento[,] sala)
        {
            Console.WriteLine();
            Console.WriteLine("----------- LIBERAR ASIENTO -----------");

            int fila = LeerFila();
            if (fila == -1)
            {
                return;
            }

            int columna = LeerColumna();
            if (columna == -1)
            {
                return;
            }

            var asiento = sala[fila, columna];

            if (asiento.Ocupado)
            {
                asiento.Ocupado = false;
                Console.WriteLine($"Asiento {asiento.Nombre} liberado correctamente.");
            }
            else
            {
                Console.WriteLine($"El asiento {asiento.Nombre} ya estaba libre. No había reservación.");
            }
        }

        // ---------- CONSULTAR DISPONIBILIDAD (DÍA 5) ----------

        static void ConsultarAsiento(Asiento[,] sala)
        {
            Console.WriteLine();
            Console.WriteLine("-------- CONSULTAR DISPONIBILIDAD --------");

            int fila = LeerFila();
            if (fila == -1)
            {
                return;
            }

            int columna = LeerColumna();
            if (columna == -1)
            {
                return;
            }

            var asiento = sala[fila, columna];

            if (asiento.Ocupado)
            {
                Console.WriteLine($"El asiento {asiento.Nombre} está OCUPADO.");
            }
            else
            {
                Console.WriteLine($"El asiento {asiento.Nombre} está DISPONIBLE.");
            }
        }

        // ---------- ESTADÍSTICAS (DÍA 6) ----------

        // Mi parte Erick - Revisa todos los asientos y cuenta cuántos están ocupados
        static int ContarOcupados(Asiento[,] sala)
        {
            int ocupados = 0;

            foreach (var asiento in sala)
            {
                if (asiento.Ocupado)
                {
                    ocupados = ocupados + 1;
                }
            }

            return ocupados;
        }

        // Mi parte-carlos
        // Muestra el total, los ocupados, los disponibles y el porcentaje
        static void MostrarEstadisticas(Asiento[,] sala)
        {
            Console.WriteLine();
            Console.WriteLine("----------- ESTADÍSTICAS DE OCUPACIÓN -----------");

            int total = letrasFila.Count * numerosColumna.Count;
            int ocupados = ContarOcupados(sala);
            int disponibles = total - ocupados;
            double porcentaje = ocupados * 100.0 / total;

            Console.WriteLine($"Total de asientos:        {total}");
            Console.WriteLine($"Asientos ocupados:        {ocupados}");
            Console.WriteLine($"Asientos disponibles:     {disponibles}");
            Console.WriteLine($"Porcentaje de ocupación:  {porcentaje} %");
        }
    }

    // Un asiento de la sala (propiedades, como la clase Galaxias de la clase)
    class Asiento
    {
        public string Nombre { get; set; }
        public bool Ocupado { get; set; }
    }
}