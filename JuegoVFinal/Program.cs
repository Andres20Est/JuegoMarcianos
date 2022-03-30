using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;

namespace ConsoleApp2
{
    class Program
    {
        static Juego Juego = new Juego(0, 0);
        static ConsoleKey tecla = ConsoleKey.P;
        static int Alazar1 = 30, Alazar2 = 100, Alazar3 = 45, Alazar4 = 69, SleepAzares = 0;
        static int hilo1 = 0;
        /*
         PARA CONFIGURAR LA VENTANA DE COMPILACION SE REQUIEREN LOS SIGUIENTES PARAMETROS
         Diseño
         {
             Tamaño del Buffer de Pantalla
             Ancho  ->  166
             Alto   ->  9001
             [√] Ajustar resultados del texto al cambiar el tamaño

             Tamaño de la Ventana
             Ancho  ->  166
             Alto   ->  43

            Posicion de la Ventana
            Izquierda   ->  0
            Superior    ->  0
            [ ] El Sistema Ubica La Ventana
         }
         Colores
         {
         [√]  ->  Fondo De la Pantalla
         Rojo   -> 128
         Azul   -> 128
         Verde  -> 0
         }


        */
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            //Juego Juego = new Juego(30, 0);// Modo Facil Con todos los Aliens
            Juego Juego = new Juego(120, 0);// Modo Facil
            //Juego Juego = new Juego(420, 0);// Modo Normal
            //Juego Juego = new Juego(600, 0);// Modo Dificil
            //Juego Juego = new Juego(720, 0);// Modo Imposible
            /// EL  PRIMER PARAMETRO ES EL PUNTAJE INICIAL PARA PROBAR LOS DISTINTOS ALIENS Y LA VELOCIDAD 
            // Al descomentar alguna de las lineas de arriba cambia la dificultad, y al comentar todos los valores es el nivel basico.
            Jugador Jugador1 = new Jugador(new Coordenada(55, 34), 3, ConsoleColor.Yellow, true, new Bala(new Posicion(1, 1), 0, false));
            Jugador Jugador2 = new Jugador(new Coordenada(110, 34), 3, ConsoleColor.Cyan, true, new Bala(new Posicion(2, 1), 0, false));
            Juego.Jugadores.Add(Jugador1);
            Juego.Jugadores.Add(Jugador2);
            Invasor Invasor1 = new Invasor(new Coordenada(3, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false));
            Invasor Invasor2 = new Invasor(new Coordenada(3, 4), ConsoleColor.DarkGreen, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false));
            Invasor Invasor3 = new Invasor(new Coordenada(3, 4), ConsoleColor.Red, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false));
            Juego.Invasores.Add(new Invasor(new Coordenada(3, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false))); // los primeros 4
            Juego.Invasores.Add(new Invasor(new Coordenada(3, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
            Juego.Invasores.Add(new Invasor(new Coordenada(3, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
            Juego.Invasores.Add(new Invasor(new Coordenada(3, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
            int AnchoNave = 5, AltoNave = 1, AnchoJugador = 2, AltoJugador = 2;
            bool GenerarFila = false;
            // int Alazar1 = 30, Alazar2 = 100, Alazar3 = 45, Alazar4 = 69, SleepAzares = 0;  //Inicializacion Variables aleatorias con datos basura
            int Disparo = new Random().Next(5, 145);
            int JugadoresVivos = 2;
            bool Hilo1 = false;
            Juego.VidasJ1 = Juego.Jugadores[0].Vidas;
            Juego.VidasJ2 = Juego.Jugadores[1].Vidas;
            List<Invasor> NumeroInvasor = new List<Invasor>();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            //ConsoleKey tecla = ConsoleKey.P;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            //PINTAR SUELO
            for (int i = 38; i <= 44; i++)
            {
                for (int j = 0; j <= 165; j++)
                {
                    Console.SetCursorPosition(j, i);
                    Console.WriteLine("█");
                }
            }
            //////////////////////////////////////////////
            ///Pintar Primera Linea de aliens
            Console.SetCursorPosition(3, 2);
            Console.WriteLine(" ");
            Juego.Invasores[0].Coordenada.X = 48;
            Juego.Invasores[0].Pintar();
            Juego.Invasores[1].Coordenada.X = 33;
            Juego.Invasores[1].Pintar();
            Juego.Invasores[2].Coordenada.X = 18;
            Juego.Invasores[2].Pintar();
            Juego.Invasores[3].Coordenada.X = 3;
            Juego.Invasores[3].Pintar();
            int Speed = Juego.Puntaje;


            do
            {

                try
                {
                    ////AUMENTO VELOCIDAD
                    if (Juego.Puntaje <= 720)
                    {
                        Speed = (Juego.Puntaje) / 30;
                    }
                    //// VELOCIDAD LIMITE
                    else
                    {
                        Speed = 24;
                    }
                    ///////////////////////////////////////////////////////////
                    ////// ALEATORIZADOR DE ENEMIGOS()LV DIFICULTAD " CON HILOS
                    if (Hilo1 == false)
                    {
                        System.Threading.ThreadStart Hilos = new System.Threading.ThreadStart(AleatorizadorMarcianos);
                        System.Threading.Thread hilo1 = new System.Threading.Thread(Hilos);
                        hilo1.Start();
                        hilo1.Join();
                        Hilo1 = true;

                    }
                    hilo1++;
                    if (hilo1 >= 50)
                    {
                        Hilo1 = false;
                        hilo1 = 0;
                    }
                    /////////////////////////////////////////////////////////////////////////////
                    /////// JUGADORES VIVOS
                    if (Juego.Jugadores[0].Vivo == true && Juego.Jugadores[1].Vivo == true)
                    {
                        JugadoresVivos = 2;
                    }
                    if ((Juego.Jugadores[0].Vivo == true && Juego.Jugadores[1].Vivo == false) || ((Juego.Jugadores[0].Vivo == false && Juego.Jugadores[1].Vivo == true)))
                    {
                        JugadoresVivos = 1;
                    }
                    /////PANTALLA COMANDO
                    if (Console.KeyAvailable == true) tecla = Console.ReadKey(true).Key;
                    else tecla = ConsoleKey.P;
                    /////////////////////////////////////////////////////////////
                    ///Operaciones Listas Jugadores
                    Juego.Jugadores[0].Pintar();
                    Juego.Jugadores[1].Pintar();
                    if (Juego.Jugadores[0].Vidas != 0)
                    {
                        if (tecla == ConsoleKey.Spacebar && Juego.Jugadores[0].Bala.Activa == false)
                        {
                            Juego.Jugadores[0].Bala.Activa = true;
                            Juego.Jugadores[0].Bala.Posicion.X = Juego.Jugadores[0].Coordenada.X;
                            Juego.Jugadores[0].Bala.Posicion.Y = Juego.Jugadores[0].Coordenada.Y - 1;
                            Juego.Jugadores[0].Bala.Pintar();

                        }
                        if (Juego.Jugadores[0].Bala.Activa == true && Juego.Jugadores[0].Vivo == true)        ///Bala
                        {
                            Juego.Jugadores[0].Bala.Sleep++;

                            if (Juego.Jugadores[0].Bala.Sleep >= 65)
                            {
                                Juego.Jugadores[0].Bala.Sleep = 0;
                                Juego.Jugadores[0].Bala.Borrar();
                                if (Juego.Jugadores[0].Bala.Posicion.Y >= 3)
                                {
                                    Juego.Jugadores[0].Bala.Posicion.Y--;
                                    Juego.Jugadores[0].Bala.Pintar();
                                }
                                else
                                {
                                    Juego.Jugadores[0].Bala.Activa = false;
                                }
                            }

                        }//
                        if (Juego.Jugadores[0].Bala.Activa == false)
                        {
                            Juego.Jugadores[0].Bala.Posicion.X = 1;
                            Juego.Jugadores[0].Bala.Posicion.Y = 1;
                        }
                        if (tecla == ConsoleKey.RightArrow && Juego.Jugadores[0].Coordenada.X < 160)
                        {
                            Juego.Jugadores[0].Mover(Direccion.Derecha);
                        }
                        if (tecla == ConsoleKey.LeftArrow && Juego.Jugadores[0].Coordenada.X > 3)
                        {
                            Juego.Jugadores[0].Mover(Direccion.Izquierda);
                        }
                        /*if (tecla == ConsoleKey.UpArrow && Juego.Jugadores[0].Coordenada.Y > 3)
                        {
                            Juego.Jugadores[0].Mover(Direccion.Arriba);
                        }
                        if (tecla == ConsoleKey.DownArrow && Juego.Jugadores[0].Coordenada.Y < 35)
                        {
                            Juego.Jugadores[0].Mover(Direccion.Abajo);
                        }*/ // Descomentar si se quiere tambien mover arriba y abajo
                    }
                    else
                    {
                        Juego.Jugadores[0].Borrar();
                        Juego.Jugadores[0].Color = Console.BackgroundColor;
                        Juego.Jugadores[0].Vidas--;
                        Juego.Jugadores[0].Vivo = false;
                        Juego.Jugadores[0].Bala.Activa = true;
                    }
                    if (Juego.Jugadores[1].Vidas != 0)
                    {
                        if (tecla == ConsoleKey.N && Juego.Jugadores[1].Bala.Activa == false)
                        {
                            Juego.Jugadores[1].Bala.Activa = true;
                            Juego.Jugadores[1].Bala.Posicion.X = Juego.Jugadores[1].Coordenada.X;
                            Juego.Jugadores[1].Bala.Posicion.Y = Juego.Jugadores[1].Coordenada.Y - 1;
                            Juego.Jugadores[1].Bala.Pintar();
                        }
                        if (Juego.Jugadores[1].Bala.Activa == true)        ///Bala
                        {
                            Juego.Jugadores[1].Bala.Sleep++;

                            if (Juego.Jugadores[1].Bala.Sleep >= 65)
                            {
                                Juego.Jugadores[1].Bala.Sleep = 0;
                                Juego.Jugadores[1].Bala.Borrar();
                                if (Juego.Jugadores[1].Bala.Posicion.Y >= 3)
                                {
                                    Juego.Jugadores[1].Bala.Posicion.Y--;
                                    Juego.Jugadores[1].Bala.Pintar();
                                }
                                else
                                {
                                    Juego.Jugadores[1].Bala.Activa = false;

                                }
                            }

                        }//
                        if (Juego.Jugadores[1].Bala.Activa == false)
                        {
                            Juego.Jugadores[1].Bala.Posicion.X = 2;
                            Juego.Jugadores[1].Bala.Posicion.Y = 1;
                        }
                        if (tecla == ConsoleKey.D && Juego.Jugadores[1].Coordenada.X < 160)
                        {
                            Juego.Jugadores[1].Mover(Direccion.Derecha);
                        }
                        if (tecla == ConsoleKey.A && Juego.Jugadores[1].Coordenada.X > 3)
                        {
                            Juego.Jugadores[1].Mover(Direccion.Izquierda);
                        }
                        /*if (tecla == ConsoleKey.W && Juego.Jugadores[1].Coordenada.Y > 3)
                        {
                            Juego.Jugadores[1].Mover(Direccion.Arriba);
                        }
                        if (tecla == ConsoleKey.S && Juego.Jugadores[1].Coordenada.Y < 35)
                        {
                            Juego.Jugadores[1].Mover(Direccion.Abajo);
                        }*/  // Descomentar si se quiere tambien mover arriba y abajo
                    }
                    else
                    {
                        Juego.Jugadores[1].Borrar();
                        Juego.Jugadores[1].Color = Console.BackgroundColor;
                        Juego.Jugadores[1].Vidas--;
                        Juego.Jugadores[1].Vivo = false;
                        Juego.Jugadores[1].Bala.Activa = true;
                    }
                    ///////////////////////////////////////////////////////////////////////  
                    ////// DATOS EN PANTALLA
                    Juego.Sleep++;
                    if (Juego.Sleep >= 600)
                    {
                        Juego.Borrar();
                        Juego.Sleep = 0;
                        Juego.Pintar();
                    }
                    //////////////////////////
                    int Count = 0;
                    //int C = Count;

                    ///////// LISTAS ENEMIGOS
                    foreach (var Inv in Juego.Invasores)
                    {
                        if (Juego.Invasores[Count].Generado == false)
                        {
                            Juego.Invasores[Count].Generado = true;
                        }
                        if (Juego.Invasores[Count].Generado == true)
                        {
                            Juego.Invasores[Count].Sleep++;
                            if (Juego.Invasores[Count].Sleep >= 140 - 5 * Speed)
                            {
                                Juego.Invasores[Count].Sleep = 0;
                                if (Juego.Invasores[Count].Coordenada.X < 159 && Juego.Invasores[Count].Direccion == true)
                                {
                                    if (Juego.Invasores[Count].Vivo == true)
                                    {
                                        Juego.Invasores[Count].Borrar();
                                        Juego.Invasores[Count].Coordenada.X++;
                                        Juego.Invasores[Count].Pintar();
                                    }
                                    if (Juego.Invasores[Count].Vivo == false)
                                    {
                                        Juego.Invasores[Count].Coordenada.X++;
                                    }
                                }

                                if (Juego.Invasores[Count].Coordenada.X == 159 && Juego.Invasores[Count].Coordenada.Y == 4)
                                {
                                    GenerarFila = true;
                                    int Count2 = Juego.Invasores.Count - 1;
                                    foreach (var Inv2 in Juego.Invasores)
                                    {
                                        if (Juego.Invasores[Count].Coordenada.Y == Juego.Invasores[Count2].Coordenada.Y && Count != Count2 && Juego.Invasores[Count].Coordenada.X >= 75)
                                        {
                                            Juego.Invasores[Count2].Borrar();
                                            Juego.Invasores[Count2].Coordenada.Y += 5;
                                            if (Juego.Invasores[Count2].Vivo == true)
                                                Juego.Invasores[Count2].Pintar();
                                            Juego.Invasores[Count2].Direccion = false;
                                        }
                                        Count2--;
                                    }
                                    Juego.Invasores[Count].Borrar();
                                    Juego.Invasores[Count].Coordenada.Y += 5;
                                    if (Juego.Invasores[Count].Vivo == true)
                                        Juego.Invasores[Count].Pintar();
                                    Juego.Invasores[Count].Direccion = false;
                                }
                                if (Juego.Invasores[Count].Coordenada.X > 3 && Juego.Invasores[Count].Direccion == false)
                                {
                                    Juego.Invasores[Count].Borrar();
                                    Juego.Invasores[Count].Coordenada.X--;
                                    if (Juego.Invasores[Count].Vivo == true)
                                    {
                                        Juego.Invasores[Count].Pintar();
                                    }
                                }
                                if (Juego.Invasores[Count].Coordenada.X == 4 && Juego.Invasores[Count].Coordenada.Y == 9)
                                {

                                    int Count2 = Juego.Invasores.Count - 1;
                                    foreach (var Inv2 in Juego.Invasores)
                                    {
                                        if (Juego.Invasores[Count].Coordenada.Y == Juego.Invasores[Count2].Coordenada.Y && Count != Count2)
                                        {
                                            Juego.Invasores[Count2].Borrar();
                                            Juego.Invasores[Count2].Coordenada.Y += 5;
                                            if (Juego.Invasores[Count2].Vivo == true)
                                                Juego.Invasores[Count2].Pintar();
                                            Juego.Invasores[Count2].Direccion = true;
                                        }
                                        Count2--;
                                    }
                                    Juego.Invasores[Count].Borrar();
                                    Juego.Invasores[Count].Coordenada.Y += 5;
                                    if (Juego.Invasores[Count].Vivo == true)
                                        Juego.Invasores[Count].Pintar();
                                    Juego.Invasores[Count].Direccion = true;
                                }
                                if (Juego.Invasores[Count].Coordenada.X == 159 && Juego.Invasores[Count].Coordenada.Y == 14)
                                {
                                    int Count2 = Juego.Invasores.Count - 1;
                                    foreach (var Inv2 in Juego.Invasores)
                                    {
                                        if (Juego.Invasores[Count].Coordenada.Y == Juego.Invasores[Count2].Coordenada.Y && Count != Count2 && Juego.Invasores[Count].Coordenada.X >= 75)
                                        {
                                            Juego.Invasores[Count2].Borrar();
                                            Juego.Invasores[Count2].Coordenada.Y += 5;
                                            if (Juego.Invasores[Count2].Vivo == true)
                                                Juego.Invasores[Count2].Pintar();
                                            Juego.Invasores[Count2].Direccion = false;
                                        }
                                        Count2--;
                                    }
                                    Juego.Invasores[Count].Borrar();
                                    Juego.Invasores[Count].Coordenada.Y += 5;
                                    if (Juego.Invasores[Count].Vivo == true)
                                        Juego.Invasores[Count].Pintar();
                                    Juego.Invasores[Count].Direccion = false;
                                }

                                if (Juego.Invasores[Count].Coordenada.X == 4 && Juego.Invasores[Count].Coordenada.Y == 19)
                                {

                                    int Count2 = Juego.Invasores.Count - 1;
                                    foreach (var Inv2 in Juego.Invasores)
                                    {
                                        if (Juego.Invasores[Count].Coordenada.Y == Juego.Invasores[Count2].Coordenada.Y && Count != Count2)
                                        {
                                            Juego.Invasores[Count2].Borrar();
                                            Juego.Invasores[Count2].Coordenada.Y += 5;
                                            if (Juego.Invasores[Count2].Vivo == true)
                                                Juego.Invasores[Count2].Pintar();
                                            Juego.Invasores[Count2].Direccion = true;
                                        }
                                        Count2--;
                                    }
                                    Juego.Invasores[Count].Borrar();
                                    Juego.Invasores[Count].Coordenada.Y += 5;
                                    if (Juego.Invasores[Count].Vivo == true)
                                        Juego.Invasores[Count].Pintar();
                                    Juego.Invasores[Count].Direccion = true;
                                }

                                if (Juego.Invasores[Count].Coordenada.X == 159 && Juego.Invasores[Count].Coordenada.Y == 24)
                                {
                                    int Count2 = Juego.Invasores.Count - 1;
                                    foreach (var Inv2 in Juego.Invasores)
                                    {
                                        if (Juego.Invasores[Count].Coordenada.Y == Juego.Invasores[Count2].Coordenada.Y && Count != Count2 && Juego.Invasores[Count].Coordenada.X >= 75)
                                        {
                                            Juego.Invasores[Count2].Borrar();
                                            Juego.Invasores[Count2].Coordenada.Y += 5;
                                            if (Juego.Invasores[Count2].Vivo == true)
                                                Juego.Invasores[Count2].Pintar();
                                            Juego.Invasores[Count2].Direccion = false;
                                        }
                                        Count2--;
                                    }
                                    Juego.Invasores[Count].Borrar();
                                    Juego.Invasores[Count].Coordenada.Y += 5;
                                    if (Juego.Invasores[Count].Vivo == true)
                                        Juego.Invasores[Count].Pintar();
                                    Juego.Invasores[Count].Direccion = false;
                                }
                                if (Juego.Invasores[Count].Coordenada.X == 4 && Juego.Invasores[Count].Coordenada.Y == 29)
                                {

                                    int Count2 = Juego.Invasores.Count - 1;
                                    foreach (var Inv2 in Juego.Invasores)
                                    {
                                        if (Juego.Invasores[Count].Coordenada.Y == Juego.Invasores[Count2].Coordenada.Y && Count != Count2)
                                        {
                                            Juego.Invasores[Count2].Borrar();
                                            Juego.Invasores[Count2].Coordenada.Y += 5;
                                            if (Juego.Invasores[Count2].Vivo == true)
                                                Juego.Invasores[Count2].Pintar();
                                            Juego.Invasores[Count2].Direccion = true;
                                        }
                                        Count2--;
                                    }
                                    Juego.Invasores[Count].Borrar();
                                    Juego.Invasores[Count].Coordenada.Y += 5;
                                    if (Juego.Invasores[Count].Vivo == true)
                                        Juego.Invasores[Count].Pintar();
                                    Juego.Invasores[Count].Direccion = true;
                                }

                            }

                        }
                        if ((Juego.Invasores[Count].Color == ConsoleColor.Red || Juego.Invasores[Count].Color == ConsoleColor.Magenta))
                        {
                            if (Juego.Invasores[Count].Coordenada.X == Alazar1 || Juego.Invasores[Count].Coordenada.X == Alazar2 || Juego.Invasores[Count].Coordenada.X == Alazar3 || Juego.Invasores[Count].Coordenada.X == Alazar4)
                            {
                                if (Juego.Invasores[Count].Bala.Activa == false)
                                {
                                    Juego.Invasores[Count].Bala.Activa = true;
                                    Juego.Invasores[Count].Bala.Posicion.X = Juego.Invasores[Count].Coordenada.X + 3;
                                    Juego.Invasores[Count].Bala.Posicion.Y = Juego.Invasores[Count].Coordenada.Y + 2;
                                }
                            }
                            if (Juego.Invasores[Count].Bala.Activa == true && Juego.Invasores[Count].Vivo == true)        ///Bala
                            {
                                Juego.Invasores[Count].Bala.Sleep++;

                                if (Juego.Invasores[Count].Bala.Sleep >= 55)
                                {
                                    Juego.Invasores[Count].Bala.Sleep = 0;
                                    Juego.Invasores[Count].Bala.Borrar();
                                    if (Juego.Invasores[Count].Bala.Posicion.Y <= 36)
                                    {
                                        Juego.Invasores[Count].Bala.Posicion.Y++;
                                        Juego.Invasores[Count].Bala.Pintar();
                                    }
                                    else
                                    {
                                        Juego.Invasores[Count].Bala.Activa = false;
                                    }
                                }

                            }

                        }
                        /////// Colisiones  Bala Naves
                        if (Juego.Jugadores[0].Coordenada.X - AnchoJugador <= Juego.Invasores[Count].Bala.Posicion.X && Juego.Invasores[Count].Bala.Posicion.X <= Juego.Jugadores[0].Coordenada.X + AnchoJugador && Juego.Jugadores[0].Coordenada.Y <= Juego.Invasores[Count].Bala.Posicion.Y && Juego.Invasores[Count].Bala.Posicion.Y <= Juego.Jugadores[0].Coordenada.Y + AltoJugador && Juego.Jugadores[0].Vivo == true)
                        {
                            Juego.Invasores[Count].Bala.Borrar();
                            Juego.Invasores[Count].Bala.Posicion.X = 3;
                            Juego.Invasores[Count].Bala.Posicion.Y = 1;
                            Juego.Invasores[Count].Bala.Activa = false;
                            Juego.Jugadores[0].Vidas--;
                            Juego.VidasJ1--;
                            Juego.Borrar();
                            Juego.Pintar();
                        }
                        if (Juego.Jugadores[1].Coordenada.X - AnchoJugador <= Juego.Invasores[Count].Bala.Posicion.X && Juego.Invasores[Count].Bala.Posicion.X <= Juego.Jugadores[1].Coordenada.X + AnchoJugador && Juego.Jugadores[1].Coordenada.Y <= Juego.Invasores[Count].Bala.Posicion.Y && Juego.Invasores[Count].Bala.Posicion.Y <= Juego.Jugadores[1].Coordenada.Y + AltoJugador && Juego.Jugadores[1].Vivo == true)
                        {
                            Juego.Invasores[Count].Bala.Borrar();
                            Juego.Invasores[Count].Bala.Posicion.X = 3;
                            Juego.Invasores[Count].Bala.Posicion.Y = 1;
                            Juego.Invasores[Count].Bala.Activa = false;
                            Juego.Jugadores[1].Vidas--;
                            Juego.VidasJ2--;
                            Juego.Borrar();
                            Juego.Pintar();
                        }
                        ////////////////////////////////
                        /////COLISIONES BALA Jugadores
                        if (Juego.Invasores[Count].Coordenada.X <= Juego.Jugadores[0].Bala.Posicion.X && Juego.Jugadores[0].Bala.Posicion.X <= Juego.Invasores[Count].Coordenada.X + AnchoNave && Juego.Invasores[Count].Coordenada.Y <= Juego.Jugadores[0].Bala.Posicion.Y && Juego.Jugadores[0].Bala.Posicion.Y <= Juego.Invasores[Count].Coordenada.Y + AltoNave && Juego.Invasores[Count].Vivo == true)
                        {
                            if (Juego.Invasores[Count].Escudo == false)
                            {
                                Juego.Puntaje++;
                                Juego.Borrar();
                                Juego.Pintar();
                                Juego.Invasores[Count].Vivo = false;
                                Juego.Invasores[Count].Borrar();
                                Juego.Jugadores[0].Bala.Activa = false;
                                Juego.Jugadores[0].Bala.Borrar();
                                Juego.Jugadores[0].Bala.Posicion.X = 1;
                                Juego.Jugadores[0].Bala.Posicion.Y = 1;
                            }
                            else
                            {
                                if (Juego.Invasores[Count].Color == ConsoleColor.DarkGreen)
                                    Juego.Invasores[Count].Color = ConsoleColor.Green;
                                if (Juego.Invasores[Count].Color == ConsoleColor.Red)
                                    Juego.Invasores[Count].Color = ConsoleColor.Magenta;
                                Juego.Invasores[Count].Escudo = false;
                                Juego.Jugadores[0].Bala.Activa = false;
                                Juego.Jugadores[0].Bala.Borrar();
                                Juego.Jugadores[0].Bala.Posicion.X = 1;
                                Juego.Jugadores[0].Bala.Posicion.Y = 1;
                            }
                        }
                        if (Juego.Invasores[Count].Coordenada.X <= Juego.Jugadores[1].Bala.Posicion.X && Juego.Jugadores[1].Bala.Posicion.X <= Juego.Invasores[Count].Coordenada.X + AnchoNave && Juego.Invasores[Count].Coordenada.Y <= Juego.Jugadores[1].Bala.Posicion.Y && Juego.Jugadores[1].Bala.Posicion.Y <= Juego.Invasores[Count].Coordenada.Y + AltoNave && Juego.Invasores[Count].Vivo == true)
                        {
                            if (Juego.Invasores[Count].Escudo == false)
                            {
                                Juego.Puntaje++;
                                Juego.Borrar();
                                Juego.Pintar();
                                Juego.Invasores[Count].Vivo = false;
                                Juego.Invasores[Count].Borrar();
                                Juego.Jugadores[1].Bala.Activa = false;
                                Juego.Jugadores[1].Bala.Borrar();
                                Juego.Jugadores[1].Bala.Posicion.X = 2;
                                Juego.Jugadores[1].Bala.Posicion.Y = 1;
                            }
                            else
                            {
                                if (Juego.Invasores[Count].Color == ConsoleColor.DarkGreen)
                                    Juego.Invasores[Count].Color = ConsoleColor.Green;
                                if (Juego.Invasores[Count].Color == ConsoleColor.Red)
                                    Juego.Invasores[Count].Color = ConsoleColor.Magenta;
                                Juego.Invasores[Count].Escudo = false;
                                Juego.Jugadores[1].Bala.Activa = false;
                                Juego.Jugadores[1].Bala.Borrar();
                                Juego.Jugadores[1].Bala.Posicion.X = 1;
                                Juego.Jugadores[1].Bala.Posicion.Y = 1;
                            }
                        }
                        //////////////////////////////////////////////////////////
                        ////////// LINQ 1 MUERTE POR ALIENS EN EL BORDE ///////////////////////////////
                        IEnumerable<Invasor> Fin = Juego.Invasores.Where(Borde => (Borde.Coordenada.Y >= 30 && Borde.Vivo == true));
                        foreach (var Borde in Fin)
                        {

                            tecla = ConsoleKey.Escape;
                            Console.CursorVisible = true;
                        }
                        //FIN DEL JUEGO WHERE
                        Count++;
                    }                      // Ciclo Movimiento
                    ////////// LINQ 2 MUERTE POR NINGUN JUGADOR VIVO ///////////////////////////////
                    IEnumerable<Jugador> Fin2 = Juego.Jugadores.Where(Vidas => (Vidas.Vivo == false));
                    foreach (var Vidas in Fin2)
                    {
                        if (JugadoresVivos == 0)
                        {

                            tecla = ConsoleKey.Escape;
                            Console.CursorVisible = true;
                        }
                        JugadoresVivos--;
                    }
                    //GENERAR FILA DE ENEMIGOS
                    if (GenerarFila == true)
                    {

                        GenerarFila = false;
                        if (Juego.Puntaje < 15)
                        {
                            Juego.Invasores.Add(new Invasor(new Coordenada(48, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
                            Juego.Invasores.Add(new Invasor(new Coordenada(33, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
                            Juego.Invasores.Add(new Invasor(new Coordenada(18, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
                            Juego.Invasores.Add(new Invasor(new Coordenada(3, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
                        }
                        if (Juego.Puntaje >= 15 && Juego.Puntaje < 30)
                        {

                            if (Alazar1 <= 50)
                                Juego.Invasores.Add(new Invasor(new Coordenada(48, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar1 >= 51)
                                Juego.Invasores.Add(new Invasor(new Coordenada(48, 4), ConsoleColor.DarkGreen, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false)));

                            if (Alazar2 <= 50)
                                Juego.Invasores.Add(new Invasor(new Coordenada(33, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar2 >= 51)
                                Juego.Invasores.Add(new Invasor(new Coordenada(33, 4), ConsoleColor.DarkGreen, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false)));

                            if (Alazar3 <= 50)
                                Juego.Invasores.Add(new Invasor(new Coordenada(18, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar3 >= 51)
                                Juego.Invasores.Add(new Invasor(new Coordenada(18, 4), ConsoleColor.DarkGreen, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false)));

                            if (Alazar4 <= 50)
                                Juego.Invasores.Add(new Invasor(new Coordenada(3, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar4 >= 51)
                                Juego.Invasores.Add(new Invasor(new Coordenada(3, 4), ConsoleColor.DarkGreen, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false)));
                        }
                        if (Juego.Puntaje >= 30)
                        {
                            if (Alazar1 <= 50)
                                Juego.Invasores.Add(new Invasor(new Coordenada(48, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar1 >= 51 && Alazar1 <= 99)
                                Juego.Invasores.Add(new Invasor(new Coordenada(48, 4), ConsoleColor.DarkGreen, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar1 >= 100)
                                Juego.Invasores.Add(new Invasor(new Coordenada(48, 4), ConsoleColor.Red, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar2 <= 50)
                                Juego.Invasores.Add(new Invasor(new Coordenada(33, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar2 >= 51 && Alazar2 <= 99)
                                Juego.Invasores.Add(new Invasor(new Coordenada(33, 4), ConsoleColor.DarkGreen, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar2 >= 100)
                                Juego.Invasores.Add(new Invasor(new Coordenada(33, 4), ConsoleColor.Red, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar3 <= 50)
                                Juego.Invasores.Add(new Invasor(new Coordenada(18, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar3 >= 51 && Alazar3 <= 99)
                                Juego.Invasores.Add(new Invasor(new Coordenada(18, 4), ConsoleColor.DarkGreen, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar3 >= 100)
                                Juego.Invasores.Add(new Invasor(new Coordenada(18, 4), ConsoleColor.Red, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar4 <= 50)
                                Juego.Invasores.Add(new Invasor(new Coordenada(3, 4), ConsoleColor.Blue, true, 0, false, true, false, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar4 >= 51 && Alazar4 <= 99)
                                Juego.Invasores.Add(new Invasor(new Coordenada(3, 4), ConsoleColor.DarkGreen, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false)));
                            if (Alazar4 >= 100)
                                Juego.Invasores.Add(new Invasor(new Coordenada(3, 4), ConsoleColor.Red, true, 0, false, true, true, 0, new Bala(new Posicion(3, 1), 0, false)));
                        }
                    }
                    //////////////////////////////////////////////////////////////////////////////////////////////////////

                }
                catch (Exception e)
                {
                    Console.SetCursorPosition(5, 5);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error" + e.Message);
                }
            } while (tecla != ConsoleKey.Escape);

            Console.ReadKey();
        }
        static void AleatorizadorMarcianos()
        {

            SleepAzares++;
            if (SleepAzares == 10)
            {
                Alazar1 = new Random().Next(5, 145);
            }
            if (SleepAzares == 20)
            {
                Alazar2 = new Random().Next(5, 145);
            }
            if (SleepAzares == 30)
            {
                Alazar3 = new Random().Next(5, 145);
            }
            if (SleepAzares == 40)
            {
                Alazar4 = new Random().Next(5, 145);
                SleepAzares = 0;
            }


        }
    }
}
