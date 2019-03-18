using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*Usigns*/
/*Add for use Stopwatch (timer)*/
using System.Diagnostics;

namespace draw_elipse
{
    public partial class MainForm : Form
    {
        /*Meddas de area de trabajo*/
        const int width = 500;
        const int height = 500;
        Point centro, radio;
        Bitmap bmp;
        Stopwatch sw;

        public MainForm()
        {
            centro = new Point(-1, -1);
            radio = new Point(-1, -1);
            bmp = new Bitmap(width, height);
            sw = new Stopwatch();
            InitializeComponent();
        }

        /*Limpieza del area de trabajo */
        private void buttonClear_Click(object sender, EventArgs e)
        {
            centro.X = centro.Y = -1;
            radio.X = radio.Y = -1;

            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(Brushes.White, 0, 0, width, height);
            workSpace.Image = bmp;

            labelDDA.Text = "DDA: 0 s";
            labelBresenham.Text = "Bresenham: 0 s";
        }

        /*Recoleccion de las coordenadas de los  puntos*/
        private void workSpace_MouseClick(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(Color.Orange, 3);

            if (centro.X == -1)
            {
                centro.X = e.X;
                centro.Y = e.Y;
                workSpace.CreateGraphics().DrawEllipse(pen, centro.X, centro.Y, 3, 3);
            }
            else
            {
                radio.X = e.X;
                radio.Y = e.Y;
                workSpace.CreateGraphics().DrawEllipse(pen, radio.X, radio.Y, 3, 3);

                Console.WriteLine("------------- Puntos ------------------");
                Console.WriteLine("punto inicial: (" + centro.X + ", " + centro.Y + ")");
                Console.WriteLine("punto final: (" + radio.X + ", " + radio.Y + ")");

                /*Ejecucuión de DDA*/
                sw.Restart();
                //DDA(centro, radio);
                workSpace.Text = "DDA: " + String.Format("{0}", sw.Elapsed.TotalMilliseconds) + " s";

                /*Ejecución de Bresenham*/
                sw.Restart();
                //bresenham(centro, radio);
                labelBresenham.Text = "Bresenham: " + String.Format("{0}", sw.Elapsed.TotalMilliseconds) + " s";

                centro.X = centro.Y = -1;
                radio.X = radio.Y = -1;
            }
        }
    }
}
