using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graphics3DS;

namespace Ejercicio11_Piramide
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        Graphics3D g3;
        int esc = 5;
        int traslacion = 5;

        Point3DF[] puntos = new Point3DF[5];

        private void Form1_Load(object sender, EventArgs e)
        {
            // Dibujar los 5 puntos que van a formar la Pirámide
            puntos[0] = new Point3DF(-100, -100, 50);
            puntos[1] = new Point3DF(100, 100, 50);
            puntos[2] = new Point3DF(-100, 100, 50);
            puntos[3] = new Point3DF(-100, 100, -50);
            puntos[4] = new Point3DF(100, 100, -50);
        }

        private void Whiteboard_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g3 = new Graphics3D(g);
            e.Graphics.TranslateTransform(Whiteboard.Width / 2, Whiteboard.Height / 2);
            Pen PlumonNegro = new Pen(Color.Black, 3);
            Pen PlumonVerde = new Pen(Color.Green, 3);
            Pen PlumonRojo = new Pen(Color.Red, 3);
            Pen PlumonMorado = new Pen(Color.Purple, 3);

            // Líneas que unen los puntos
            g3.DrawLine3D(PlumonNegro, puntos[0], puntos[3]);
            // Eje de las X
            g3.DrawLine3D(PlumonRojo, puntos[0], puntos[1]);
            g3.DrawLine3D(PlumonRojo, puntos[4], puntos[0]);
            // Eje de las Y
            g3.DrawLine3D(PlumonMorado, puntos[1], puntos[2]);
            g3.DrawLine3D(PlumonMorado, puntos[2], puntos[3]);
            g3.DrawLine3D(PlumonMorado, puntos[3], puntos[4]);
            g3.DrawLine3D(PlumonMorado, puntos[4], puntos[1]);
            // Eje de las Z
            g3.DrawLine3D(PlumonRojo, puntos[2], puntos[0]);

            // Dibujar las esquinas
            //for (int i = 0; i < puntos.Length; i++)
            //{
            //    PointF p = new PointF()
            //    {
            //        // Calcular las esquinas del cubo en el plano X, Y, y Z
            //        X = puntos[i].Z * (float)(Math.Cos(45 * Math.PI / 180) + puntos[i].X) - 3,
            //        Y = puntos[i].Z * (float)(Math.Cos(45 * Math.PI / 180) + puntos[i].X) - 3
            //    };
            //    // Dibujar los puntos del cubo
            //    g.FillEllipse(new SolidBrush(Color.Yellow), new RectangleF(p, new SizeF(5F, 5F)));
            //}
        }

        private void Whiteboard_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // Flecha derecha o izquierda, escalar X
                case Keys.Left:
                    EscalarX(false);
                    break;
                case Keys.Right:
                    EscalarX(true);
                    break;
                // Flecha arriba y abajo, escalar Y
                case Keys.Up:
                    EscalarY(true);
                    break;
                case Keys.Down:
                    EscalarY(false);
                    break;
                // Tecla Q y W, escalar en Z
                case Keys.Q:
                    EscalarZ(true);
                    break;
                case Keys.W:
                    EscalarZ(false);
                    break;
                // Tecla A y S, Trasladar en X
                case Keys.A:
                    TrasladarX(true);
                    break;
                case Keys.S:
                    TrasladarX(false);
                    break;
                // Tecla D y F, Trasladar en Y
                case Keys.D:
                    TrasladarY(true);
                    break;
                case Keys.F:
                    TrasladarY(false);
                    break;
            }
        }

        private void EscalarX(bool aumentar_disminuir)
        {
            if (aumentar_disminuir)
            {
                // Aumenta tamaño cuando presiona Flecha Derecha - TRUE
                puntos[0].X += esc;
                puntos[1].X += esc;
                puntos[4].X += esc;
            }
            else
            {
                // Disminuye tamaño cuando presiona Flecha Izquierda - FALSE
                puntos[0].X -= esc;
                puntos[1].X -= esc;
                puntos[4].X -= esc;
            }
            Whiteboard.Refresh(); //Volver a los valores originales 
        }

        private void EscalarY(bool aumentar_disminuir)
        {
            if (aumentar_disminuir)
            {
                // Aumenta tamaño cuando presiona Flecha Arriba - TRUE
                puntos[1].Y += esc;
                puntos[2].Y += esc;
                puntos[3].Y += esc;
                puntos[4].Y += esc;
            }
            else
            {
                // Disminuye tamaño cuando presiona Flecha Abajo - FALSE
                puntos[1].Y -= esc;
                puntos[2].Y -= esc;
                puntos[3].Y -= esc;
                puntos[4].Y -= esc;
            }
            Whiteboard.Refresh(); //Volver a los valores originales 
        }

        private void EscalarZ(bool aumentar_disminuir)
        {
            if (aumentar_disminuir)
            {
                // Aumenta tamaño cuando presiona Q - TRUE
                puntos[0].Z += esc;
                puntos[1].Z += esc;
                puntos[2].Z += esc;
            }
            else
            {
                // Disminuye tamaño cuando presiona W - FALSE
                puntos[0].Z -= esc;
                puntos[1].Z -= esc;
                puntos[2].Z -= esc;
            }
            Whiteboard.Refresh(); //Volver a los valores originales 
        }

        // Aplicar efectos de Traslación X, Y
        // Crear el método para trasladar en el eje de las X
        private void TrasladarX(bool der_izq)
        {
            if (der_izq)
            {
                // Mover la figura X unidades hacia la derecha
                for (int i = 0; i < puntos.Length; i++)
                {
                    puntos[i].X += traslacion;
                }
            }
            else
            {
                // Mover la figura X unidades hacia la izquierda
                for (int i = 0; i < puntos.Length; i++)
                {
                    puntos[i].X -= traslacion;
                }
            }
            Whiteboard.Refresh();
        }

        // Crear el método para trasladar en el eje de las X
        private void TrasladarY(bool arriba_abajo)
        {
            if (arriba_abajo)
            {
                // Mover la figura Y unidades hacia arriba
                for (int i = 0; i < puntos.Length; i++)
                {
                    puntos[i].Y += traslacion;
                }
            }
            else
            {
                // Mover la figura Y unidades hacia abajo
                for (int i = 0; i < puntos.Length; i++)
                {
                    puntos[i].Y -= traslacion;
                }
            }
            Whiteboard.Refresh();
        }
    }
}
