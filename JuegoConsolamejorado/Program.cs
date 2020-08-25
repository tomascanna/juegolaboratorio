using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsolamejorado
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo tecla;
            Random r = new Random();
            bool final = false;
            int i,incr=1;
            int cantobs=0,cantoponente=0;

            int x = r.Next(100), y = r.Next(44);//jugador
            //Ingreso de la cantidad de oponentes
            do
            {
                Console.Clear();
                Console.Write("Ingrese la cantidad de oponentes: ");
                cantoponente = Convert.ToInt32(Console.ReadLine());
                if (cantoponente<0)
                {
                    Console.Clear();
                    Console.WriteLine("ERROR,no se puede ingresar numeros negativos");
                    Console.ReadKey();
                }
            } while (cantoponente < 0);

            //Ingreso de la cantidad de obstaculos
            do
            {
                Console.Clear();
                Console.Write("Ingrese la cantidad de obstaculos: ");
                cantobs = Convert.ToInt32(Console.ReadLine());
                if (cantobs < 0)
                {
                    Console.Clear();
                    Console.WriteLine("ERROR,no se puede ingresar numeros negativos");
                    Console.ReadKey();
                }
            } while (cantobs < 0);
            
            //Objetos
            int[] xobs = new int[cantobs];
            int[] yobs = new int[cantobs];

            //Oponentes
            int[] xoponente = new int[cantoponente];
            int[] yoponente = new int[cantoponente];

            //Asignacion de puntos x e y de los obstaculo
            for (i = 0; i < cantobs; i++)
            {
                xobs[i] = r.Next(5,45);
                yobs[i] = r.Next(5, 45);
            }

            //Asignacion de puntos x e y enemigos
            for (i = 0; i < cantoponente; i++)
            {
                xoponente[i] = r.Next(5, 45);
                yoponente[i] = r.Next(5, 45);
            }

            while (final == false)
            {
                // Imprime los elementos en pantalla
                Console.Clear();
                Console.WriteLine("Posicion x" + x + "Posicion y" + y);
                Console.SetCursorPosition(1, 5);
                Console.Write("---------------------------------------------------------------------------------------------------");
                Console.SetCursorPosition(1, 45);
                Console.Write("---------------------------------------------------------------------------------------------------");
                for (i = 5; i < 45;i++)
                {
                    Console.SetCursorPosition(100, i);
                    Console.WriteLine("|");
                }
                Console.SetCursorPosition(x, y);
                Console.Write("A");

                for (i = 0; i < cantobs; i++)
                {
                    Console.SetCursorPosition(xobs[i], yobs[i]);
                    Console.Write("o");
                }

                for (i = 0; i < cantoponente; i++)
                {
                    Console.SetCursorPosition(xoponente[i], yoponente[i]);
                    Console.Write("@");
                }


                tecla = Console.ReadKey(false);
                if (tecla.Key == ConsoleKey.RightArrow) x++;
                if (tecla.Key == ConsoleKey.LeftArrow) x--;
                if (tecla.Key == ConsoleKey.DownArrow) y++;
                if (tecla.Key == ConsoleKey.UpArrow) y--;

                
                for(i=0;i<cantoponente; i++)
                {
                    xoponente[i] = xoponente[i] + incr;
                    if ((xoponente[i]==5) || (xoponente[i] == 79))
                        incr = -incr;
                }

                for (i = 0; i < cantoponente; i++)
                {
                    if (x == xoponente[i] && y==yoponente[i])
                    {
                        Console.Clear();
                        Console.SetCursorPosition(45,23);
                        Console.WriteLine("PERDISTE!!.Tocaste a un enemigo");
                        final = true;

                    }
                }

                for (i = 0; i < cantobs; i++)
                {
                    if (x == xobs[i] && y == yobs[i])
                    {
                        Console.Clear();
                        Console.SetCursorPosition(45, 23);
                        Console.WriteLine("PERDISTE!!.Tocaste un Objeto");
                        final = true;

                    }
                }

                //Condicion para que no pase los limites
                if (y == 45){
                    y = 6;
                }

                if (y == 5)
                {
                    y = 44;
                }

                if (x ==-1)
                {
                    x = 99;
                }

                if (x == 100)
                {
                    x = 0;
                }
            }//corhcete de while

            Console.ReadKey();
        }
    }
}
