using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3d_Kursach
{
    public partial class Form1 : Form
    {
        public double height, radiusKonus, radiusCilindr, NAprocsimation;
        public List<List<double>> listPoints = new List<List<double>>();
        List<Rebro> listRebraBeforePoints = new List<Rebro>();
        List<Grane> listGrane = new List<Grane>();
        List<int> listIndexFirstCilindr, listIndexFirstKonus;
        List<List<double>> listPerspective = new List<List<double>>();
        public bool VrashenieAndPerspective = false;
        public Form1()
        {
            InitializeComponent();
            radioButtonOyVrashenie.Checked = true;
            radiobuttonProfileVid.Checked = true;
            radiobuttonKavale.Checked = true;
        }

        public void getPointsCilindr()
        {
            double alpha = Math.PI / NAprocsimation;

            List<double> list = new List<double>();
            list.Add(-radiusCilindr);
            list.Add(0);
            list.Add(0);
            listPoints.Add(list);
            int length = listPoints.Count + (int)NAprocsimation - 1;

            for (int i = listPoints.Count; i < length; ++i)
            {
                list = new List<double>();
                list.Add(listPoints[i - 1][0] + (radiusCilindr * 2 * (double)Math.Sin(Math.PI / NAprocsimation) * (double)Math.Sin(alpha)));
                list.Add(0);
                list.Add(listPoints[i - 1][2] + (radiusCilindr * 2 * (double)Math.Sin(Math.PI / NAprocsimation) * (double)Math.Cos(alpha)));
                listPoints.Add(list);
                alpha += 2 * Math.PI / NAprocsimation;
                listRebraBeforePoints.Add(new Rebro(listPoints.Count - 2, listPoints.Count - 1));
            }
            listRebraBeforePoints.Add(new Rebro(listPoints.Count - 1, 0));

            listIndexFirstCilindr = new List<int>();
            for(int i = 0; i < listPoints.Count; ++i)
            {
                listIndexFirstCilindr.Add(i);
            }

            alpha = Math.PI / NAprocsimation;

            list = new List<double>();
            list.Add(-radiusCilindr);
            list.Add(height);
            list.Add(0);
            listPoints.Add(list);

            length = listPoints.Count + (int)NAprocsimation - 1;

            for (int i = listPoints.Count; i < length; ++i)
            {
                list = new List<double>();
                list.Add(listPoints[i - 1][0] + (radiusCilindr * 2 * (double)Math.Sin(Math.PI / NAprocsimation) * (double)Math.Sin(alpha)));
                list.Add(height);
                list.Add(listPoints[i - 1][2] + (radiusCilindr * 2 * (double)Math.Sin(Math.PI / NAprocsimation) * (double)Math.Cos(alpha)));
                listPoints.Add(list);
                alpha += 2 * Math.PI / NAprocsimation;
                listRebraBeforePoints.Add(new Rebro(listPoints.Count - 2, listPoints.Count - 1));
            }
            listRebraBeforePoints.Add(new Rebro(listPoints.Count - 1, listPoints.Count - (int)NAprocsimation));

            List<int> listIndex = new List<int>();
            for(int i = (int)NAprocsimation; i < listPoints.Count; ++i)
            {
                listIndex.Add(i);
            }
            listGrane.Add(new Grane(listIndex.ToArray()));

            for(int i = 0; i < (int)NAprocsimation; ++i)
            {
                listRebraBeforePoints.Add(new Rebro(i, i + (int)NAprocsimation));
            }

            listIndex = new List<int>();
            for (int i = 0; i < (int)NAprocsimation; ++i)
            {
                if (i != (int)NAprocsimation - 1)
                {
                    listIndex.Add(i);
                    listIndex.Add(i + 1);
                    listIndex.Add(i + (int)NAprocsimation + 1);
                    listIndex.Add(i + (int)NAprocsimation);
                }
                else
                {
                    listIndex.Add(i);
                    listIndex.Add(0);
                    listIndex.Add((int)NAprocsimation);
                    listIndex.Add(i + (int)NAprocsimation);
                }
                listGrane.Add(new Grane(listIndex.ToArray()));
                listIndex = new List<int>();
            }
        }

        public void getPointsKonus()
        {
            double alpha = Math.PI / NAprocsimation;

            List<double> list = new List<double>();
            list.Add(-radiusKonus);
            list.Add(0);
            list.Add(0);
            listPoints.Add(list);
            int length = listPoints.Count + (int)NAprocsimation - 1;

            for (int i = listPoints.Count; i < length; ++i)
            {
                list = new List<double>();
                list.Add(listPoints[i - 1][0] + (radiusKonus * 2 * (double)Math.Sin(Math.PI / NAprocsimation) * (double)Math.Sin(alpha)));
                list.Add(0);
                list.Add(listPoints[i - 1][2] + (radiusKonus * 2 * (double)Math.Sin(Math.PI / NAprocsimation) * (double)Math.Cos(alpha)));
                listPoints.Add(list);
                alpha += 2 * Math.PI / NAprocsimation;
                listRebraBeforePoints.Add(new Rebro(listPoints.Count - 2, listPoints.Count - 1));
            }
            listRebraBeforePoints.Add(new Rebro(listPoints.Count - 1, listPoints.Count - (int)NAprocsimation));

            listIndexFirstKonus = new List<int>();
            for (int i = listPoints.Count - (int)NAprocsimation; i < listPoints.Count; ++i)
            {
                listIndexFirstKonus.Add(i);
            }
            List<int> listIndex = new List<int>();
            for(int i = 0; i < (int)NAprocsimation; ++i)
            {
                if (i != (int)NAprocsimation - 1)
                {
                    listIndex.Add(listIndexFirstCilindr[i]);
                    listIndex.Add(listIndexFirstCilindr[i + 1]);
                    listIndex.Add(listIndexFirstKonus[i + 1]);
                    listIndex.Add(listIndexFirstKonus[i]);
                }
                else
                {
                    listIndex.Add(listIndexFirstCilindr[i]);
                    listIndex.Add(listIndexFirstCilindr[0]);
                    listIndex.Add(listIndexFirstKonus[0]);
                    listIndex.Add(listIndexFirstKonus[i]);
                }

                listGrane.Add(new Grane(listIndex.ToArray()));
                listIndex = new List<int>();
            }


            list = new List<double>();
            list.Add(0);
            list.Add(height);
            list.Add(0);
            listPoints.Add(list);

            for(int i = listPoints.Count - (int)NAprocsimation - 1; i < listPoints.Count - 1; ++i)
            {
                listRebraBeforePoints.Add(new Rebro(i, listPoints.Count - 1));
            }

            listIndex = new List<int>();
            for (int i = listPoints.Count - (int)NAprocsimation - 1; i < listPoints.Count - 1; ++i)
            {
                if (i != listPoints.Count - 2)
                {
                    listIndex.Add(i);
                    listIndex.Add(i + 1);
                    listIndex.Add(listPoints.Count - 1);
                }
                else
                {
                    listIndex.Add(i);
                    listIndex.Add(listPoints.Count - (int)NAprocsimation - 1);
                    listIndex.Add(listPoints.Count - 1);
                }
                listGrane.Add(new Grane(listIndex.ToArray()));
                listIndex = new List<int>();
            }
        }

        public void button_Build_Click(object sender, EventArgs e)
        {
            if ((textbox_High_Konus.Text == "") || (textbox_Radius_Cilindr.Text == "") || (textbox_Radius_Konus.Text == "") || (textbox_NAprocsimation.Text == ""))
            {
                MessageBox.Show("Вы заполнили не все поля!");
            }
            else
            {
                
                listPoints.RemoveRange(0, listPoints.Count);
                listRebraBeforePoints.RemoveRange(0, listRebraBeforePoints.Count);
                listGrane.RemoveRange(0, listGrane.Count);
                VrashenieAndPerspective = false;

                this.height = -Convert.ToDouble(textbox_High_Konus.Text);
                this.radiusCilindr = Convert.ToDouble(textbox_Radius_Cilindr.Text);
                this.radiusKonus = Convert.ToDouble(textbox_Radius_Konus.Text);
                this.NAprocsimation = Convert.ToDouble(textbox_NAprocsimation.Text);

                getPointsCilindr();
                getPointsKonus();

                drawFigures(listPoints);
            }
        }

        private void buttonPeremeshenie_Click(object sender, EventArgs e)
        {
            if((textBoxOxPeremeshenie.Text == "") || (textBoxOyPeremeshenie.Text == "") || (textBoxOzPeremeshenie.Text == ""))
            {
                MessageBox.Show("Вы не задали кол-во единиц перемещения по оси!");
            }
            else
            {
                double ox = Convert.ToDouble(textBoxOxPeremeshenie.Text);
                double oy = -Convert.ToDouble(textBoxOyPeremeshenie.Text);
                double oz = Convert.ToDouble(textBoxOzPeremeshenie.Text);
                double[,] matrixPeremeshenie = { { 1, 0, 0, 0 },
                                                 { 0, 1, 0, 0 },
                                                 { 0, 0, 1, 0 },
                                                 { ox, oy, oz, 1 } };
                matrixUmnoshenie(listPoints, matrixPeremeshenie);
                
                
                drawFigures(listPoints);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBoxQxMashtab.Text == "") || (textBoxQyMashtab.Text == "") || (textBoxQzMashtab.Text == ""))
            {
                MessageBox.Show("Вы не задали коэффициенты масштабирования!");
            }
            else
            {
                double qx = Convert.ToDouble(textBoxQxMashtab.Text);
                double qy = Convert.ToDouble(textBoxQyMashtab.Text);
                double qz = Convert.ToDouble(textBoxQzMashtab.Text);
                double[,] matrixMashtab = { { qx, 0, 0, 0 },
                                                 { 0, qy, 0, 0 },
                                                 { 0, 0, qz, 0 },
                                                 { 0, 0, 0, 1 } };
                matrixUmnoshenie(listPoints, matrixMashtab);
               
                
                drawFigures(listPoints);
            }
        }

        private void buttonVrashenie_Click(object sender, EventArgs e)
        {
            if (textBoxUgolVrashenie.Text == "")
            {
                MessageBox.Show("Вы не задали угол вращения!");
            }
            else
            {
                double ugol = Convert.ToDouble(textBoxUgolVrashenie.Text) * Math.PI / 180;

                double[,] matrixVrashenie = new double[4,4];

                if (radioButtonOxVrashenie.Checked == true)
                {
                    double[,] matrix = { { 1, 0, 0, 0 },
                                         { 0, Math.Cos(ugol), Math.Sin(ugol), 0 },
                                         { 0, -Math.Sin(ugol), Math.Cos(ugol), 0 },
                                         { 0, 0, 0, 1 } };

                    matrixVrashenie = matrix;
                }

                if (radioButtonOyVrashenie.Checked == true)
                {
                    double[,] matrix = { { Math.Cos(ugol), 0, -Math.Sin(ugol), 0 },
                                         { 0, 1, 0, 0 },
                                         { Math.Sin(ugol), 0, Math.Cos(ugol), 0 },
                                         { 0, 0, 0, 1 } };

                    matrixVrashenie = matrix;
                }

                if (radioButtonOzVrashenie.Checked == true)
                {
                    double[,] matrix = { { Math.Cos(ugol), Math.Sin(ugol), 0, 0 },
                                         { -Math.Sin(ugol), Math.Cos(ugol), 0, 0 },
                                         { 0, 0, 1, 0 },
                                         { 0, 0, 0, 1 } };

                    matrixVrashenie = matrix;
                }
                matrixUmnoshenie(listPoints, matrixVrashenie);

                if (VrashenieAndPerspective)
                {
                    buttonPerspective_Click(sender, e);
                }
                else
                {
                    drawFigures(listPoints);
                }
            }
        }

        private void buttonPuskTimerVrashenie_Click(object sender, EventArgs e)
        {
            if (buttonPuskTimerVrashenie.Text == "Авто(Вкл)")
            {
                timerVrashenie.Interval = 50;
                timerVrashenie.Start();
                buttonPuskTimerVrashenie.Text = "Авто(Выкл)";
                textBoxUgolVrashenie.Enabled = false;
            }
            else
            {
                timerVrashenie.Stop();
                buttonPuskTimerVrashenie.Text = "Авто(Вкл)";
                textBoxUgolVrashenie.Enabled = true;
            }
        }

        private void timerVrashenie_Tick(object sender, EventArgs e)
        {
            buttonVrashenie_Click(sender, e);
            timerVrashenie.Enabled = true;
        }

        private void buttonOrtogphichVid_Click(object sender, EventArgs e)
        {
            double alpha = 90 * Math.PI / 180;

            if (radiobuttonFrontVid.Checked == true)
            {
                double[,] matrixFront = { { 0, 0, 0, 0 },
                                          { 0, 1, 0, 0 },
                                          { 0, 0, 1, 0 },
                                          { 0, 0, 0, 1 } };

                pointsListToList();
                matrixUmnoshenie(listPerspective, matrixFront);

                double[,] matrix =    { { Math.Cos(alpha), 0, -Math.Sin(alpha), 0 },
                                        { 0, 1, 0, 0 },
                                        { Math.Sin(alpha), 0, Math.Cos(alpha), 0 },
                                        { 0, 0, 0, 1 } };

                matrixUmnoshenie(listPerspective, matrix);
                matrixUmnoshenie(listPoints, matrix);
            }

            if (radiobuttonProfileVid.Checked == true)
            {
                double[,] matrixProfile = { { 1, 0, 0, 0 },
                                            { 0, 0, 0, 0 },
                                            { 0, 0, 1, 0 },
                                            { 0, 0, 0, 1 } };

                pointsListToList();
                matrixUmnoshenie(listPerspective, matrixProfile);

                double[,] matrix = { { 1, 0, 0, 0 },
                                     { 0, Math.Cos(alpha), Math.Sin(alpha), 0 },
                                     { 0, -Math.Sin(alpha), Math.Cos(alpha), 0 },
                                     { 0, 0, 0, 1 } };

                matrixUmnoshenie(listPerspective, matrix);
                matrixUmnoshenie(listPoints, matrix);
            }

            if (radiobuttonGorizontVid.Checked == true)
            {
                double[,] matrixGorizond = { { 1, 0, 0, 0 },
                                             { 0, 1, 0, 0 },
                                             { 0, 0, 0, 0 },
                                             { 0, 0, 0, 1 } };

                pointsListToList();
                matrixUmnoshenie(listPerspective, matrixGorizond);
            }
            
            drawFigures(listPerspective);
        }

        private void buttonAksonometria_Click(object sender, EventArgs e)
        {
            double phi = Convert.ToDouble(textBoxPhiAksonometria.Text) * Math.PI / 180;
            double etta = Convert.ToDouble(textBoxEttaAksonometria.Text) * Math.PI / 180;

            double[,] matrixAksonometria = { { Math.Cos(phi), Math.Sin(phi) * Math.Sin(etta), 0, 0 },
                                             { 0, Math.Cos(etta), 0, 0 },
                                             { Math.Sin(phi), -Math.Cos(phi) * Math.Sin(etta), 0, 0 },
                                             { 0, 0, 0, 1 } };

            double[,] matrixPovorotOy = { { Math.Cos(phi), 0, -Math.Sin(phi), 0 },
                                         { 0, 1, 0, 0 },
                                         { Math.Sin(phi), 0, Math.Cos(phi), 0 },
                                         { 0, 0, 0, 1 } };

            double[,] matrixPovorotOx = { { 1, 0, 0, 0 },
                                         { 0, Math.Cos(etta), Math.Sin(etta), 0 },
                                         { 0, -Math.Sin(etta), Math.Cos(etta), 0 },
                                         { 0, 0, 0, 1 } };

            pointsListToList();
            matrixUmnoshenie(listPerspective, matrixAksonometria);

            matrixUmnoshenie(listPoints, matrixPovorotOy);
            matrixUmnoshenie(listPoints, matrixPovorotOx);
            
            drawFigures(listPerspective);
        }

        private void buttonKosougolnia_Click(object sender, EventArgs e)
        {
            double ugolGorizontNaklon = Convert.ToDouble(textBoxAlphaKosougolnia.Text) * Math.PI / 180;
            double koeffIskashenia;

            if (radiobuttonKavale.Checked == true)
            {
                koeffIskashenia = 1;
            }
            else
            {
                koeffIskashenia = 0.5;
            }

            double[,] matrixKosoug = { { 1, 0, 0, 0 },
                                       { 0, 1, 0, 0 },
                                       { -koeffIskashenia * Math.Cos(ugolGorizontNaklon), -koeffIskashenia * Math.Sin(ugolGorizontNaklon), 0, 0 },
                                       { 0, 0, 0, 1 } };

            double[,] matrixKosougListPoints = { { 1, 0, 0, 0 },
                                                 { 0, 1, 0, 0 },
                                                 { -koeffIskashenia * Math.Cos(ugolGorizontNaklon), -koeffIskashenia * Math.Sin(ugolGorizontNaklon), 1, 0 },
                                                 { 0, 0, 0, 1 } };

            pointsListToList();
            matrixUmnoshenie(listPerspective, matrixKosoug);

            matrixUmnoshenie(listPoints, matrixKosougListPoints);
            
            drawFigures(listPerspective);
        }

        private void checkBoxLight_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLight.Checked)
            {
                groupBoxLight.Enabled = true;
            }
            else
            {
                groupBoxLight.Enabled = false;
            }
        }

        private void checkBoxDeleteLines_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDeleteLines.Checked)
            {
                groupBoxColor.Enabled = true;
            }
            else
            {
                groupBoxColor.Enabled = false;
            }
        }

        private void buttonPerspective_Click(object sender, EventArgs e)
        {
            double phi = Convert.ToDouble(textBoxPhiPerspective.Text) * Math.PI / 180;
            double etta = Convert.ToDouble(textBoxEttaPerspective.Text) * Math.PI / 180;
            double d = Convert.ToDouble(textBoxdPerspective.Text);
            double ro = Convert.ToDouble(textBoxRoPerspective.Text);

            VrashenieAndPerspective = true;

            listPerspective = new List<List<double>>();
            List<double> list = new List<double>();
            for(int i = 0; i < listPoints.Count; ++i)
            {
                list = new List<double>();
                list.Add(listPoints[i][0]);
                list.Add(listPoints[i][1]);
                list.Add(listPoints[i][2]);
                listPerspective.Add(list);
            }

            double[,] matrixPerspective = { { Math.Cos(etta), -Math.Cos(phi) * Math.Sin(etta), -Math.Sin(phi) * Math.Sin(etta), 0 },
                                            { Math.Sin(etta), Math.Cos(phi) * Math.Cos(etta), Math.Sin(phi) * Math.Cos(etta), 0 },
                                            { 0, Math.Sin(phi), -Math.Cos(phi), 0 },
                                            { 0, 0, ro, 1 } };

            matrixUmnoshenie(listPerspective, matrixPerspective);

            for (int i = 0; i < listPerspective.Count; ++i)
            {
                if (Math.Abs(listPerspective[i][2]) < 0.1)
                {
                    listPerspective[i][2] = 0.1;
                }
                else
                {
                    listPerspective[i][0] = listPerspective[i][0] * d / listPerspective[i][2];
                    listPerspective[i][1] = listPerspective[i][1] * d / listPerspective[i][2];
                }
            }
            
            drawFigures(listPerspective);
        }

        public void pointsListToList()
        {
            listPerspective = new List<List<double>>();
            List<double> list;
            for (int i = 0; i < listPoints.Count; ++i)
            {
                list = new List<double>();
                list.Add(listPoints[i][0]);
                list.Add(listPoints[i][1]);
                list.Add(listPoints[i][2]);
                listPerspective.Add(list);
            }
        }

        public void matrixUmnoshenie(List<List<double>> listPoints, double[,] matrix)
        {
            for (int i = 0; i < listPoints.Count; ++i)
            {
                double[,] matrixPoint = { { listPoints[i][0], listPoints[i][1], listPoints[i][2], 1 } };

                for (int j = 0; j < 4; ++j)
                {
                    double temp = 0;
                    for (int k = 0; k < 4; ++k)
                    {
                        temp += matrixPoint[0, k] * matrix[k, j];
                    }
                    if (j < 3) listPoints[i][j] = temp;
                }
            }
        }

        public void drawFigures(List<List<double>> list)
        {
            Bitmap bit = new Bitmap(500, 500);

            Graphics graphics = Graphics.FromImage(bit);

            Brush colorRebra = new SolidBrush(Color.Black);
            Brush colorGrane = new SolidBrush(Color.FromArgb(255, 255, 255));

            if (!checkBoxDeleteLines.Checked)
            {
                for (int i = 0; i < listRebraBeforePoints.Count; ++i)
                {
                    graphics.DrawLine(new Pen(colorRebra, 1), 250 + (float)list[listRebraBeforePoints[i].point1][0], 250 + (float)list[listRebraBeforePoints[i].point1][1], 250 + (float)list[listRebraBeforePoints[i].point2][0], 250 + (float)list[listRebraBeforePoints[i].point2][1]);
                }
            }
            else
            {
                int[] mass = { 1 };
                Grane buff = new Grane(mass);
                for(int i = 0; i < listGrane.Count - 1; ++i)
                {
                    if(listGrane[i].CenterGraneZ(list, (int)NAprocsimation) < listGrane[i + 1].CenterGraneZ(list, (int)NAprocsimation))
                    {
                        buff = listGrane[i];
                        listGrane[i] = listGrane[i + 1];
                        listGrane[i + 1] = buff;
                    }
                }

                for (int i = 0; i < listGrane.Count; ++i)
                {
                    if ((textBoxRColor.Text != "") && (textBoxGColor.Text != "") && (textBoxBColor.Text != ""))
                    {
                        int R = Convert.ToInt32(textBoxRColor.Text);
                        int G = Convert.ToInt32(textBoxGColor.Text);
                        int B = Convert.ToInt32(textBoxBColor.Text);

                        if ((R <= 255) && (G <= 255) && (B <= 255))
                        {
                            if ((checkBoxLight.Checked) && (textBoxLightX.Text != "") && (textBoxLightY.Text != "") && (textBoxLightZ.Text != ""))
                            {
                                if (LightGraneKoeff(listGrane[i], list) > 0)
                                {
                                    double koeff = LightGraneKoeff(listGrane[i], list);

                                    R = Convert.ToInt32(Convert.ToDouble(R) * koeff);
                                    G = Convert.ToInt32(Convert.ToDouble(G) * koeff);
                                    B = Convert.ToInt32(Convert.ToDouble(B) * koeff);
                                }
                            }

                            colorGrane = new SolidBrush(Color.FromArgb(R, G, B));
                        }
                    }

                    listGrane[i].drawGrane(list, colorGrane, graphics);
                }
            }
            pictureBox1.Image = bit;
            pictureBox1.Invalidate();
        }

        public double LightGraneKoeff(Grane grane, List<List<double>> list)
        {
            double X1 = list[grane.massPointsGrane[0]][0];
            double X2 = list[grane.massPointsGrane[1]][0];
            double X3 = list[grane.massPointsGrane[2]][0];
            double Y1 = list[grane.massPointsGrane[0]][1];
            double Y2 = list[grane.massPointsGrane[1]][1];
            double Y3 = list[grane.massPointsGrane[2]][1];
            double Z1 = list[grane.massPointsGrane[0]][2];
            double Z2 = list[grane.massPointsGrane[1]][2];
            double Z3 = list[grane.massPointsGrane[2]][2];

            double A = Y1 * (Z2 - Z3) + Y2 * (Z3 - Z1) + Y3 * (Z1 - Z2);
            double B = Z1 * (X2 - X3) + Z2 * (X3 - X1) + Z3 * (X1 - X2);
            double C = X1 * (Y2 - Y3) + X2 * (Y3 - Y1) + X3 * (Y1 - Y2);

            double x1 = grane.CenterGraneX(list, (int) NAprocsimation);
            double x2 = Convert.ToDouble(textBoxLightX.Text);
            double y1 = grane.CenterGraneY(list, (int) NAprocsimation);
            double y2 = Convert.ToDouble(textBoxLightY.Text);
            double z1 = grane.CenterGraneZ(list, (int) NAprocsimation);
            double z2 = Convert.ToDouble(textBoxLightZ.Text);

            return Math.Abs((A * (x2 - x1) + B * (y2 - y1) + C * (z2 - z1)) /
                Math.Sqrt(A * A + B * B + C * C) /
                Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1)));
        }
    }
}