using System;

namespace CineAsientos
{
    /// <summary>
    /// Programa principal: crea la sala, muestra el menú
    /// y envía cada opción al módulo correspondiente.
    /// </summary>
    class Program
    {
        // Dimensiones de la sala y estados de un asiento
        public const int FILAS = 5;
        public const int COLUMNAS = 8;
        public const int LIBRE = 0;
        public const int OCUPADO = 1;

        static void Main(string[] args)
        {
            // La sala es una matriz (arreglo bidimensional) de FILAS x COLUMNAS
            int[,] sala = new int[FILAS, COLUMNAS];
            InicializarSala(sala);

            int opcion;
            do
            {
                MostrarMenu();
                opcion = LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        MostrarSala(sala);
                        break;
                    case 2:
                        Captura.ReservarAsiento(sala);
                        break;
                    case 3:
                        Captura.LiberarAsiento(sala);
                        break;
                    case 4:
                        Console.WriteLine("Consultar disponibilidad: pendiente (Día 5).");
                        break;
                    case 5:
                        Console.WriteLine("Estadísticas: pendiente (Día 6).");
                        break;
                    case 6:
                        Console.WriteLine("Gracias por usar el sistema. ¡Hasta luego!");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Elija un número del 1 al 6.");
                        break;
                }

                if (opcion != 6)
                {
                    Pausar();
                }
            } while (opcion != 6);
        }

        /// <summary>Recorre la matriz y marca todos los asientos como libres.</summary>
        static void InicializarSala(int[,] sala)
        {
            for (int fila = 0; fila < FILAS; fila++)
            {
                for (int columna = 0; columna < COLUMNAS; columna++)
                {
                    sala[fila, columna] = LIBRE;
                }
            }
        }

        /// <summary>Imprime el menú principal.</summary>
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

        /// <summary>
        /// Lee la opción del menú. Si el usuario escribe algo que no es número,
        /// devuelve -1 para que el switch lo trate como opción inválida.
        /// </summary>
        static int LeerOpcion()
        {
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int opcion))
            {
                return opcion;
            }

            return -1;
        }

        /// <summary>Recorre la matriz e imprime cada asiento como [ ] libre o [X] ocupado.</summary>
        public static void MostrarSala(int[,] sala)
        {
            Console.WriteLine();
            Console.WriteLine("============== PANTALLA ==============");
            Console.WriteLine();

            // Encabezado con los números de columna
            Console.Write("     ");
            for (int columna = 1; columna <= COLUMNAS; columna++)
            {
                Console.Write($" {columna}  ");
            }
            Console.WriteLine();

            // Una línea por fila, con su letra al inicio
            for (int fila = 0; fila < FILAS; fila++)
            {
                char letraFila = (char)('A' + fila);
                Console.Write($"  {letraFila}  ");

                for (int columna = 0; columna < COLUMNAS; columna++)
                {
                    if (sala[fila, columna] == LIBRE)
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

        /// <summary>Espera a que el usuario presione Enter antes de volver al menú.</summary>
        public static void Pausar()
        {
            Console.WriteLine();
            Console.WriteLine("Presione Enter para volver al menú...");
            Console.ReadLine();
        }
    }

    /// <summary>
    /// Módulo de captura: lee y valida la posición de un asiento,
    /// y realiza las operaciones de reservar y liberar sobre la matriz.
    /// </summary>
    static class Captura
    {
        /// <summary>
        /// Pide al usuario la fila (letra A-E) y la columna (número 1-8).
        /// Convierte la letra a índice (A=0...E=4) y la columna a índice (1=0...8=7).
        /// Devuelve true si ambos datos son válidos; si no, muestra el error y devuelve false.
        /// </summary>
        public static bool LeerPosicion(out int fila, out int columna)
        {
            fila = -1;
            columna = -1;

            // --- Fila ---
            Console.Write("Ingrese la fila (A-E): ");
            string entradaFila = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entradaFila))
            {
                Console.WriteLine("No ingresó ningún dato. Intente de nuevo.");
                return false;
            }

            entradaFila = entradaFila.Trim().ToUpper();
            char letra = entradaFila[0];

            if (entradaFila.Length != 1 || letra < 'A' || letra >= 'A' + Program.FILAS)
            {
                Console.WriteLine("Fila inválida. Use una letra de la A a la E.");
                return false;
            }

            fila = letra - 'A';

            // --- Columna ---
            Console.Write("Ingrese la columna (1-8): ");
            string entradaColumna = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entradaColumna))
            {
                Console.WriteLine("No ingresó ningún dato. Intente de nuevo.");
                return false;
            }

            if (!int.TryParse(entradaColumna, out int numeroColumna))
            {
                Console.WriteLine("Columna inválida. Use un número del 1 al 8.");
                return false;
            }

            columna = numeroColumna - 1;

            if (!ValidarPosicion(fila, columna))
            {
                Console.WriteLine("Columna inválida. Use un número del 1 al 8.");
                return false;
            }

            return true;
        }

        /// <summary>Comprueba que los índices estén dentro del rango de la matriz.</summary>
        public static bool ValidarPosicion(int fila, int columna)
        {
            return fila >= 0 && fila < Program.FILAS
                && columna >= 0 && columna < Program.COLUMNAS;
        }

        /// <summary>Devuelve el nombre del asiento como lo ve el usuario, por ejemplo "B4".</summary>
        public static string NombreAsiento(int fila, int columna)
        {
            char letra = (char)('A' + fila);
            return $"{letra}{columna + 1}";
        }

        /// <summary>
        /// Reserva un asiento: valida la posición, verifica que esté libre
        /// y lo marca como ocupado (inserción en la matriz).
        /// </summary>
        public static void ReservarAsiento(int[,] sala)
        {
            Console.WriteLine();
            Console.WriteLine("----------- RESERVAR ASIENTO -----------");

            if (!LeerPosicion(out int fila, out int columna))
            {
                return; // El mensaje de error ya se mostró en LeerPosicion
            }

            string asiento = NombreAsiento(fila, columna);

            if (sala[fila, columna] == Program.OCUPADO)
            {
                Console.WriteLine($"El asiento {asiento} ya está ocupado. Elija otro.");
            }
            else
            {
                sala[fila, columna] = Program.OCUPADO;
                Console.WriteLine($"Reservación exitosa: asiento {asiento} ocupado.");
            }
        }

        /// <summary>
        /// Libera un asiento: valida la posición, verifica que esté ocupado
        /// y lo marca como libre (eliminación lógica en la matriz).
        /// </summary>
        public static void LiberarAsiento(int[,] sala)
        {
            Console.WriteLine();
            Console.WriteLine("----------- LIBERAR ASIENTO -----------");

            if (!LeerPosicion(out int fila, out int columna))
            {
                return;
            }

            string asiento = NombreAsiento(fila, columna);

            if (sala[fila, columna] == Program.LIBRE)
            {
                Console.WriteLine($"El asiento {asiento} ya estaba libre. No había reservación.");
            }
            else
            {
                sala[fila, columna] = Program.LIBRE;
                Console.WriteLine($"Asiento {asiento} liberado correctamente.");
            }
        }
    }
}