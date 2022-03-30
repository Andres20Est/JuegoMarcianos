using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Jugador
    {
        public Coordenada Coordenada;
        public int Vidas;
        public ConsoleColor Color;
        public bool Vivo;
        public Bala Bala;
        public void Pintar()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(Coordenada.X, Coordenada.Y);
            Console.WriteLine("█");
            Console.SetCursorPosition(Coordenada.X - 2, Coordenada.Y + 1);
            Console.WriteLine("█████");
            Console.SetCursorPosition(Coordenada.X - 2, Coordenada.Y + 2);
            Console.WriteLine("█ █ █");
        }
        public void Borrar()

        {
            Console.ForegroundColor = Console.BackgroundColor;
            Console.SetCursorPosition(Coordenada.X, Coordenada.Y);
            Console.WriteLine("█");
            Console.SetCursorPosition(Coordenada.X - 2, Coordenada.Y + 1);
            Console.WriteLine("█████");
            Console.SetCursorPosition(Coordenada.X - 2, Coordenada.Y + 2);
            Console.WriteLine("█ █ █");
        }
        public void Mover(Direccion Direccion)
        {
            Borrar();
            switch (Direccion)
            {
                case Direccion.Arriba: Coordenada.Y--; break;
                case Direccion.Abajo: Coordenada.Y++; break;
                case Direccion.Derecha: Coordenada.X++; break;
                case Direccion.Izquierda: Coordenada.X--; break;
            }
            Pintar();
        }
        public Jugador(Coordenada coordenada, int Vidas, ConsoleColor Color, bool Vivo, Bala bala)
        {
            Coordenada = coordenada;
            this.Vidas = Vidas;
            this.Color = Color;
            this.Vivo = Vivo;
            Bala = bala;
        }

    }
}
