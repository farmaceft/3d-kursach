using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace _3d_Kursach
{
    class Grane
    {
        public List<int> massPointsGrane = new List<int>();
        public Grane(int[] massIndex)
        {
            massPointsGrane.AddRange(massIndex);
        }
        public double CenterGrane(List<List<double>> list, int NAprocsimation)
        {
            double pointCenter = 0;

            switch (massPointsGrane.Count)
            {
                case 3: pointCenter = (list[massPointsGrane[0]][2] > list[massPointsGrane[1]][2]) ? ((list[massPointsGrane[0]][2] + list[massPointsGrane[2]][2]) / 8) : (list[massPointsGrane[1]][2] + list[massPointsGrane[2]][2]) / 8;
                    break;
                case 4: pointCenter = (list[massPointsGrane[1]][2] + list[massPointsGrane[3]][2]) / 2;
                    break;
                default: pointCenter = (list[massPointsGrane[NAprocsimation / 4]][2] + list[massPointsGrane[NAprocsimation - (NAprocsimation / 4)]][2]) / 2;
                    break;
            }
            return pointCenter;
        }

        public void drawGrane(List<List<double>> list, Brush brush, Graphics gr)
        {
            Point[] points = new Point[massPointsGrane.Count];

            for (int i = 0; i < points.Length; ++i)
            {
                points[i].X = 250 + Convert.ToInt32(list[massPointsGrane[i]][0]);
                points[i].Y = 250 + Convert.ToInt32(list[massPointsGrane[i]][1]);
            }

            gr.FillPolygon(brush, points);
            gr.DrawPolygon(new Pen(Color.Black), points);
        }
    }
}