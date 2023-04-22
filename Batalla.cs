using System;

class Program
{
    static int[,] tablero = new int[5, 5]; // matriz que representa el tablero
    static int barcosImpactados = 0; // variable para llevar la cuenta de barcos impactados

    static void Main(string[] args)
    {
        CrearTablero(); // se crea el tablero
        ColocarBarcos(); // se colocan los barcos en el tablero
        ImprimirTablero(); // se imprime el tablero en pantalla

        while (true)
        {
            IngresarCoordenadas(); // el usuario ingresa las coordenadas

            // se revisa si todos los barcos han sido impactados
            if (barcosImpactados == 4)
            {
                Console.WriteLine("¡Felicitaciones, has ganado!"); // mensaje de felicitaciones
                break; // salir del ciclo while
            }
        }
    }

    static void CrearTablero()
    {
        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                tablero[i, j] = 0; // se inicializa cada celda del tablero en 0 (sin barcos)
            }
        }
    }

    static void ColocarBarcos()
    {
        // se colocan los barcos en las siguientes posiciones
        tablero[4, 3] = 1;
        tablero[1, 3] = 1;
        tablero[2, 3] = 1;
        tablero[4, 4] = 1;
    }

    static void ImprimirTablero()
    {
        // se recorre la matriz y se imprime cada celda con un caracter según su valor
        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                String caracter_imprimir;

                switch (tablero[i, j])
                {
                    case 0:
                        caracter_imprimir = "   -   "; // celda vacía
                        break;

                    case 1:
                        caracter_imprimir = "   -   "; // celda con un barco sin impactar
                        break;

                    case 2:
                        caracter_imprimir = " <[|  "; // celda con un barco impactado
                        break;

                    case -1:
                        caracter_imprimir = " X "; // celda con un tiro fallado
                        break;

                    default:
                        caracter_imprimir = "   -   "; // celda vacía por defecto
                        break;
                }

                Console.Write(caracter_imprimir + ""); // se imprime el caracter
            }
            Console.WriteLine(); // se imprime una nueva línea para la siguiente fila
        }
    }

    static void IngresarCoordenadas()
    {
        Console.Write("Ingresa la Fila: ");
        int fila = Convert.ToInt32(Console.ReadLine()); // se lee la fila ingresada por el usuario

        Console.Write("Ingresa la Columna: ");
        int columna = Convert.ToInt32(Console.ReadLine()); // se lee la columna ingresada por el usuario

        if (tablero[fila, columna] == 1) // si la celda contiene un barco
        {
            Console.Beep(); // se reproduce un sonido de impacto
            tablero[fila, columna] = 2; //
 barcosImpactados++; //aumentar el contador de barcos impactados
    }
    else
    {
        tablero[fila, columna] = -1;
    }

    Console.Clear();
    ImprimirTablero();
}
}