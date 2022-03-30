
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Bala
    {
        public Posicion Posicion;
        public int Sleep;
        public bool Activa;

        public void Pintar()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(Posicion.X, Posicion.Y);
            Console.WriteLine("█");
        }
        public void Borrar()
        {
            Console.ForegroundColor = Console.BackgroundColor;
            Console.SetCursorPosition(Posicion.X, Posicion.Y);
            Console.WriteLine("█");
        }
        public Bala(Posicion posicion, int Sleep, bool Activa)
        {
            Posicion = posicion;
            this.Sleep = Sleep;
            this.Activa = Activa;
        }

    }
}
