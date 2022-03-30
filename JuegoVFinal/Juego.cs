using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Juego
    {
        public List<Invasor> Invasores = new List<Invasor>();
        public List<Jugador> Jugadores = new List<Jugador>();
        public int Sleep;
        public int Puntaje;
        public int VidasJ1;
        public int VidasJ2;
        public Juego(int Puntaje, int Sleep)
        {
            this.Puntaje = Puntaje;
            this.Sleep = Sleep;
        }
        public void Pintar()
        {
            var ColorFondoAnterior = Console.BackgroundColor;
            var ColorCursorAnterior = Console.ForegroundColor;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(15, 40);
            Console.WriteLine("Puntaje: " + Puntaje);
            Console.SetCursorPosition(90, 40);
            Console.WriteLine("VidasJ1: " + VidasJ1);
            Console.SetCursorPosition(110, 40);
            Console.WriteLine("VidasJ2: " + VidasJ2);
            Console.BackgroundColor = ColorFondoAnterior;
            Console.ForegroundColor = ColorCursorAnterior;
        }
        public void Borrar()
        {
            var ColorFondoAnterior = Console.BackgroundColor;
            var ColorCursorAnterior = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(15, 40);
            Console.WriteLine("██████████████████████████████");
            Console.SetCursorPosition(90, 40);
            Console.WriteLine("██████████████████████████████");
            Console.SetCursorPosition(110, 40);
            Console.WriteLine("██████████████████████████████");
            Console.BackgroundColor = ColorFondoAnterior;
            Console.ForegroundColor = ColorCursorAnterior;
        }
    }
}
