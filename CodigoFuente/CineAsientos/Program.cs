using System;

namespace CineAsientos
{
    class Program
    {
        // Tamaño de la sala y estado de los asientos
        const int FILAS = 5;
        const int COLUMNAS = 8;
        const int LIBRE = 0;
        const int OCUPADO = 1;

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // La sala es una matriz: 0 = libre, 1 = ocupado
            int[,] sala = new int[FILAS, COLUMNAS];

            // Al inicio todos los asientos están libres
            for (int f = 0; f < FILAS; f++)
            {
                for (int c = 0; c < COLUMNAS; c++)
                {
                    sala[f, c] = LIBRE;
                }
            }

            int opcion = 0;

            while (opcion != 6)
            {
                MostrarMenu();

                // Si no escribe un número, opcion queda en 0 y será inválida
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0;
                }

                if (opcion == 1)
                {
                    MostrarSala(sala);
                }
                else if (opcion == 2)
                {
                    ReservarAsiento(sala);
                }
                else if (opcion == 3)
                {
                    LiberarAsiento(sala);
                }
                else if (opcion == 4)
                {
                    ConsultarAsiento(sala);
                }
                else if (opcion == 5)
                {
                    Console.WriteLine("Estadísticas: pendiente (Día 6).");
                }
                else if (opcion == 6)
                {
                    Console.WriteLine("Gracias por usar el sistema. ¡Hasta luego!");
                }
                else
                {
                    Console.WriteLine("Opción inválida. Elija un número del 1 al 6.");
                }

                if (opcion != 6)
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

        static void MostrarSala(int[,] sala)
        {
            Console.WriteLine();
            Console.WriteLine("============== PANTALLA ==============");
            Console.WriteLine();

            // Números de las columnas
            Console.Write("     ");
            for (int c = 1; c <= COLUMNAS; c++)
            {
                Console.Write(" " + c + "  ");
            }
            Console.WriteLine();

            // Cada fila con su letra
            for (int f = 0; f < FILAS; f++)
            {
                char letra = (char)('A' + f);
                Console.Write("  " + letra + "  ");

                for (int c = 0; c < COLUMNAS; c++)
                {
                    if (sala[f, c] == LIBRE)
                    {
                        Console.Write("[ ] ");
                    }
                    else
                    {
                        Console.Write("[X] ");
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

            if (string.IsNullOrWhiteSpace(texto))
            {
                Console.WriteLine("No ingresó ningún dato. Intente de nuevo.");
                return -1;
            }

            texto = texto.Trim().ToUpper();

            if (texto.Length != 1 || texto[0] < 'A' || texto[0] > 'E')
            {
                Console.WriteLine("Fila inválida. Use una letra de la A a la E.");
                return -1;
            }

            // A = 0, B = 1, C = 2, D = 3, E = 4
            return texto[0] - 'A';
        }

        // Pide la columna (1-8). Devuelve 0 a 7, o -1 si es inválida
        static int LeerColumna()
        {
            Console.Write("Ingrese la columna (1-8): ");
            string texto = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(texto))
            {
                Console.WriteLine("No ingresó ningún dato. Intente de nuevo.");
                return -1;
            }

            int numero;
            if (!int.TryParse(texto, out numero) || numero < 1 || numero > COLUMNAS)
            {
                Console.WriteLine("Columna inválida. Use un número del 1 al 8.");
                return -1;
            }

            // La columna 1 es la posición 0 de la matriz
            return numero - 1;
        }

        // ---------- RESERVAR ----------

        static void ReservarAsiento(int[,] sala)
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

            string nombre = "" + (char)('A' + fila) + (columna + 1);

            if (sala[fila, columna] == OCUPADO)
            {
                Console.WriteLine("El asiento " + nombre + " ya está ocupado. Elija otro.");
            }
            else
            {
                sala[fila, columna] = OCUPADO;
                Console.WriteLine("Reservación exitosa: asiento " + nombre + " ocupado.");
            }
        }

        // ---------- LIBERAR ----------

        static void LiberarAsiento(int[,] sala)
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

            string nombre = "" + (char)('A' + fila) + (columna + 1);

            if (sala[fila, columna] == LIBRE)
            {
                Console.WriteLine("El asiento " + nombre + " ya estaba libre. No había reservación.");
            }
            else
            {
                sala[fila, columna] = LIBRE;
                Console.WriteLine("Asiento " + nombre + " liberado correctamente.");
            }
        }

        // ---------- CONSULTAR DISPONIBILIDAD (DÍA 5) ----------

        static void ConsultarAsiento(int[,] sala)
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

            string nombre = "" + (char)('A' + fila) + (columna + 1);

            if (sala[fila, columna] == LIBRE)
            {
                Console.WriteLine("El asiento " + nombre + " está DISPONIBLE.");
            }
            else
            {
                Console.WriteLine("El asiento " + nombre + " está OCUPADO.");
            }
        }

        // ---------- ESTADÍSTICAS (DÍA 6) ----------

        // Mi parte Erick - Revisa todos los asientos y cuenta cuántos están ocupados
        static int ContarOcupados(int[,] sala)
        {
            int ocupados = 0;

            for (int f = 0; f < FILAS; f++)
            {
                for (int c = 0; c < COLUMNAS; c++)
                {
                    if (sala[f, c] == OCUPADO)
                    {
                        ocupados = ocupados + 1;
                    }
                }
            }

            return ocupados;
        }
    }
}