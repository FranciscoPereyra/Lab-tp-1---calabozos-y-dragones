using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_tp_1_calabozos_y_dragones
{
    class Dragon : Pieza
    {
        public string Nombre
        {
            get
            {
                return Nombre;
            }
            set
            {
                Nombre = value;
            }
        }

        public int Posicion { get; set; }

        public string Dueño { get; set; }

        public Dragon()
        {

        }
        public override void Evaluar()
        {

        }

         public override void VerDescripcion()
        {

        }

    }
}
