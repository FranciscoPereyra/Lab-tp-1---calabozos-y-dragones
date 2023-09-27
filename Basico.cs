using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tp_1_calabozos_y_dragones
{
    public class Basico
    {
        protected ArrayList jugadores = new ArrayList();

        public int CantidadJugadores { get { return jugadores.Count; } }

        //public Basico(int cantJugadores) : this("Virtual 1", cantJugadores) { }
        public Basico(string nombre, int cantJugadores)
        {
            IniciarTablero(nombre, cantJugadores);
        }

        virtual protected void IniciarTablero(string nombre, int cantJugadores)
        {
            jugadores.Add(new Jugador(nombre));

            for (int n = 1; n <= cantJugadores; n++)
            {
                jugadores.Add(new Jugador("Virtual " + n));
            }
        }

        virtual public void Jugar()
        {
            foreach (Jugador jugador in jugadores)
            {
                jugador.Avanzar();
            }
        }
        public Jugador VerJugador(int idx)
        {
            return (Jugador)jugadores[idx];
        }
        public bool Termino()
        {
            bool haFinalizado = false;
            foreach (Jugador jugador in jugadores)
            {
                if (jugador.Ganador == true)
                {
                    haFinalizado = true;
                }
            }
            return haFinalizado;
        }
    }
}
