using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Invasor
    {
        public Coordenada Coordenada;
        public int Sleep;
        public bool Generado;
        public bool Direccion;//True = derecha, False = Izquierda
        public int Velocidad;
        public ConsoleColor Color;
        public bool Escudo;
        public bool Vivo;
        public Bala Bala;
        public Invasor(Coordenada coordenada, ConsoleColor Color, bool Vivo, int Sleep, bool Generado, bool Direccion, bool Escudo, int Velocidad, Bala bala)
        {
            Coordenada = coordenada;
            this.Color = Color;
            this.Vivo = Vivo;
            this.Sleep = Sleep;
            this.Generado = Generado;
            this.Direccion = Direccion;
            this.Escudo = Escudo;
            this.Velocidad = Velocidad;
            Bala = bala;
        }
        public void Pintar()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Coordenada.X, Coordenada.Y);
            Console.WriteLine(" ▄██▄ ");
            Console.SetCursorPosition(Coordenada.X, Coordenada.Y + 1);
            Console.WriteLine("██████");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.SetCursorPosition(Coordenada.X, Coordenada.Y + 2);
            Console.WriteLine(" ▀  ▀ ");
        }
        public void Borrar()
        {
            Console.ForegroundColor = Console.BackgroundColor;
            Console.SetCursorPosition(Coordenada.X, Coordenada.Y);
            Console.WriteLine(" ▄██▄ ");
            Console.SetCursorPosition(Coordenada.X, Coordenada.Y + 1);
            Console.WriteLine("██████");
            Console.SetCursorPosition(Coordenada.X, Coordenada.Y + 2);
            Console.WriteLine(" ▀  ▀ ");
        }
    }

}

