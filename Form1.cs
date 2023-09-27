using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_tp_1_calabozos_y_dragones
{
    public partial class Form1 : Form
    {
        Juego nuevo = new Juego();

        int caballeroVerdeX = 5;
        int caballeroVerdeY = 58;

        int caballeroRojoX = 3;
        int caballeroRojoY = 5;



        int dragonRojoY = 161;
        int dragonRojoX = 4;

        int dragonVerdeY = 205;
        int dragonVerdeX = 2;

        public Form1()
        {
            InitializeComponent();

            // posicionar picturebox inicial

            // Calcula la nueva posición del PictureBox
            //int caballeroRojoX = 3;
           // int caballeroRojoY = 5;

           

            // Establece la nueva posición
            pbCaballeroRojo.Location = new Point(caballeroRojoX, caballeroRojoY);
            pbCaballeroRojo.BackColor = Color.Transparent;
            pbDragonRojo.Location = new Point(dragonRojoX, dragonRojoY);

            pBCaballeroVerde.Location = new Point(caballeroVerdeX, caballeroVerdeY);
            pBCaballeroVerde.BackColor = Color.Transparent;
            pbDragonVerde.Location = new Point(dragonVerdeX, dragonVerdeY);

            // Tamaño de cada cuadrícula
            int gridSize = 50;

            // Cambia el color de fondo del Panel a rojo
           // panelTablero.BackColor = Color.Red;
            

            // Número de cuadrículas por fila y columna
            int numCols = 10;
            int numRows = 5;

            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    // Crear una nueva cuadrícula como un control Panel
                    Panel cuadricula = new Panel
                    {
                        Size = new Size(gridSize, gridSize),
                        Location = new Point(col * gridSize, row * gridSize),
                        BorderStyle = BorderStyle.FixedSingle // Agregar un borde
                    };

                    // Puedes personalizar la apariencia de cada cuadrícula aquí

                    // Agregar la cuadrícula al panel del tablero
                    panelTablero.Controls.Add(cuadricula);
                }
            } // fin Cuadricula

           




        }

        private void btnAvanzar_Click(object sender, EventArgs e)
        {
            // Este metodo mueve al caballero horizontalmente, sumandole 50 a nuevaX

            // Calcula la nueva posición del PictureBox
            caballeroRojoX = pbCaballeroRojo.Left + (50);
            caballeroRojoY = pbCaballeroRojo.Top;

            dragonRojoX = caballeroRojoX;

            if (caballeroRojoX >= 450) caballeroRojoX = 450;

            // Establece la nueva posición
            pbCaballeroRojo.Location = new Point(caballeroRojoX, caballeroRojoY);
            pbDragonRojo.Location = new Point(dragonRojoX, dragonRojoY);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Este metodo mueve al caballero horizontalmente, sumandole 50 a nuevaX

            // Calcula la nueva posición del PictureBox
            caballeroVerdeX = pBCaballeroVerde.Left + (50);
            dragonVerdeX = caballeroVerdeX;
           

            if (caballeroVerdeX >= 450) caballeroVerdeX = 450;

            // Establece la nueva posición
            pBCaballeroVerde.Location = new Point(caballeroVerdeX,caballeroVerdeY );
            pbDragonVerde.Location = new Point(dragonVerdeX, dragonVerdeY);

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FormDatos fDato = new FormDatos();

            if (fDato.ShowDialog() == DialogResult.OK)
            {
                lbResultados.Items.Clear();

                string jugador = fDato.tbNombre.Text;
                int cantidad = Convert.ToInt32(fDato.nudCantidad.Value);
                int nivel = fDato.cbNivel.SelectedIndex + 1;

                nuevo.IniciarJuego(jugador, cantidad, nivel);

                btnJugar.Enabled = true;
            }
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            if (nuevo.Tablero.Termino() == false)
            {
                nuevo.Tablero.Jugar();

                for (int n = 0; n < nuevo.Tablero.CantidadJugadores; n++)
                {
                    Jugador jugador = nuevo.Tablero.VerJugador(n);

                    string linea = $">{jugador.Nombre} se movió desde la posición: {jugador.PosicionAnterior}" +
                                    $" a la posición {jugador.Posicion} ({jugador.Avance})";

                    lbResultados.Items.Add(linea);
                    lbResultados.SelectedIndex = lbResultados.Items.Count - 1;
                }

                lbResultados.Items.Add("------");
            }
            else
            {
                MessageBox.Show("Finalizó!");

                for (int n = 0; n < nuevo.Tablero.CantidadJugadores; n++)
                {
                    Jugador jug = (Jugador)(nuevo.Tablero.VerJugador(n));
                    if (jug.Ganador)
                        nuevo.AgregarPartida(jug.Nombre);
                }

                btnJugar.Enabled = false;
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            FormHistorial fHistorial = new FormHistorial();

            foreach (Partida p in nuevo.ListarPartidas())
                fHistorial.lbHistorial.Items.Add($"{p.Ganador}  {p.Ganadas}");

            fHistorial.ShowDialog();

            fHistorial.Dispose();
        }
    }
}

