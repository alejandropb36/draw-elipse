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
                labelDDA.Text = "DDA: " + String.Format("{0}", sw.Elapsed.TotalMilliseconds) + " s";

                /*Ejecución de Bresenham*/
                sw.Restart();
                bresenham(centro, radio);
                labelBresenham.Text = "Bresenham: " + String.Format("{0}", sw.Elapsed.TotalMilliseconds) + " s";

                centro.X = centro.Y = -1;
                radio.X = radio.Y = -1;
            }
        }

        /*Dibujo de cadrantes de una elipse*/
        void setPixelCuadrante(int xc, int yc, int x, int y, Color color)
        {
            if (x + xc > 0 && x + xc < width && y + yc > 0 && y + yc < height)  /// Cuadrante 2
                bmp.SetPixel(x + xc, y + yc, color);
            if (-x + xc > 0 && -x + xc < width && -y + yc > 0 && -y + yc < height)  ///CUADRANTE 6
                bmp.SetPixel(-x + xc, -y + yc, color);
            if (-x + xc > 0 && -x + xc < width && y + yc > 0 && y + yc < height)  ///Cuadrante 3
                bmp.SetPixel(-x + xc, y + yc, color);
            if (x + xc > 0 && x + xc < width && -y + yc > 0 && -y + yc < height)  ///Cuadrante 7
                bmp.SetPixel(x + xc, -y + yc, color);
        }

        private void DDA(Point centro, Point radio)
        {
            int xc = centro.X;
            int yc = centro.Y;
            int xf = radio.X;
            int yf = radio.Y;
            int rx = xf - xc;
            int ry = yf - yc;
            double rx2, ry2;
            double rx2ry2;
            double x, y;

            x = y = 0;
            rx = Math.Abs(rx);
            ry = Math.Abs(ry);
            rx2 = Math.Pow(rx, 2);
            ry2 = Math.Pow(ry, 2);
            rx2ry2 = rx2 * ry2;

            for(x = 0; x < rx; x++)
            {
                y = Math.Sqrt((rx2ry2 - (Math.Pow(x, 2) * ry2)) / (rx2));
                y = Math.Round(y);
                setPixelCuadrante(xc, yc, (int)x, (int)y, Color.Red);
            }
            for (y = 0; y < ry; y++)
            {
                x = Math.Sqrt((rx2ry2 - (Math.Pow(y, 2) * rx2)) / (ry2));
                x = Math.Round(x);
                setPixelCuadrante(xc, yc, (int)x, (int)y, Color.Red);
            }

            workSpace.Image = bmp;
        }

        private void bresenham(Point centro, Point radio)
        {
            int xc = centro.X;
            int yc = centro.Y;
            int xf = radio.X;
            int yf = radio.Y;
            int rx = xf - xc;
            int ry = yf - yc;
            double rx2, ry2;
            double x, y;
            double pk, pk2;

            x = 0;
            y = ry;
            rx = Math.Abs(rx);
            ry = Math.Abs(ry);
            rx2 = Math.Pow(rx, 2);
            ry2 = Math.Pow(ry, 2);
            pk = ry2 - (rx2 * ry) + (0.25 * rx2);   ///Inicializacion PK para primera iteracion por cada x iterar en y

            while ((ry2 * x) < (rx2 * y))   ///Cuando radio cuadrado de y sea mayor al radio cuadrado de x iterando con el opuesto para esta iteracion
            {
                if (pk < 0)
                {
                    x++;
                    pk = pk + (2 * ry2 * x) + ry2;
                }
                else
                {
                    x++; y--;
                    pk = pk + (2 * ry2 * x) - (2 * rx2 * y) + ry2;
                }
                setPixelCuadrante(xc, yc, (int)x, (int)y, Color.Blue);        
            }

            pk2 = (ry2) * Math.Pow((x + 0.5), 2) + (rx2) * Math.Pow((y - 1), 2) - (rx2 * ry2);
            while (y > 0)
            {
                if (pk2 > 0)
                {
                    y--;
                    pk2 = pk2 - (2 * rx2 * y) + rx2;
                }
                else
                {
                    x++; y--;
                    pk2 = pk2 + (2 * ry2 * x) - (2 * rx2 * y) + rx2;
                }
                setPixelCuadrante(xc, yc, (int)x, (int)y, Color.Blue);
            }

            workSpace.Image = bmp;
        }
    }
}
