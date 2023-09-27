using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tp_1_calabozos_y_dragones
{
    public class Jugador
    {
        static Random dado = new Random();
        public string Nombre { get; private set; }

        private int posicion;
        public int Posicion 
        {
            get
            {
                return posicion;
            }
            set
            {
                if (value > 50)
                    posicion = 50;
                else if (value < 1)
                    posicion = 1;
                else posicion = value;
            }
        }
        public int PosicionAnterior { get; private set; }
        public int Avance { get; private set; }
        public bool Ganador
        {
            get
            {
                return Posicion == 50;
            }
        }

        public Jugador(string nombre) 
        {
            Nombre = nombre;
        }

        public virtual void Avanzar()
        {
            Avance = dado.Next(1, 6);

            PosicionAnterior = Posicion;
            Posicion += Avance;
        }



    }
}
