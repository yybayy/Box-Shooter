using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        Button bitti = new Button();
        Label baslik = new Label();
        Button oyna = new Button();
        Random random = new Random();
        Button cikis = new Button();
        

        int puan = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int dirX = random.Next(1, 445);

            Label box = new Label();
            Label bomba = new Label();

            box.Width = 50;
            box.Height = 50;
            box.BackColor = Color.Firebrick;
            box.ForeColor = Color.White;
            box.TextAlign = ContentAlignment.MiddleCenter;
            box.Text = random.Next(1, 101).ToString();

            bomba.Width = 50;
            bomba.Height = 50;
            bomba.BackColor = Color.Azure;
            bomba.ForeColor = Color.White;
            bomba.TextAlign = ContentAlignment.MiddleCenter;
            bomba.Text = "BOMBA!!";
            bomba.Click += Bomba_Click;
           
            bomba.Location = new Point(dirX, 0);
            box.Location = new Point(dirX, 0);
            
            box.Click += Box_Click;

            this.Controls.Add(box);
            this.Controls.Add(bomba);

            if (puan == 500)
            {
                timer2.Interval = 100;
            }
            else if (puan == 1500)
            {
                timer2.Interval = 75;
            }
            else if (puan == 2500)
            {
                timer2.Interval = 50;
            }
            else if (puan == 4000)
            {
                timer2.Interval = 40;
            }
        }

        private void Bomba_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();

            bitti.Width = 100;
            bitti.Height = 50;
            bitti.ForeColor = Color.White;
            bitti.TextAlign = ContentAlignment.MiddleCenter;
            bitti.Font = new Font("Microsoft YaHei", 9);
            bitti.Text = "Patladın\n Menüye Dön";
            bitti.Location = new Point(200, 175);
            this.Controls.Add(bitti);
            bitti.Click += Bitti_Click;
            bitti.TabIndex = 0;

        }

        private void Box_Click(object sender, EventArgs e)
        {
            if (sender is Label)
            {
                Label label = (Label)sender;
                puan += int.Parse(label.Text);
                this.Text = "Puan: " + puan.ToString();

                label.Dispose();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baslik.Text = "  Kutu Shooter ";
            baslik.Font = new Font("Microsoft YaHei", 30);
            baslik.ForeColor = Color.White;
            baslik.Location = new Point(165, 70);
            baslik.Size = new Size(250, 250);
            baslik.AutoSize = false;

            oyna.Text = "Oyna";
            oyna.ForeColor = Color.White;
            oyna.Font = new Font("Microsoft YaHei", 15);
            oyna.Location = new Point(187, 200);
            oyna.Size = new Size(120, 100);
            oyna.Click += Oyna_Click;

            cikis.Text = "Çıkış";
            cikis.ForeColor = Color.White;
            cikis.Font = new Font("Microsoft YaHei", 15);
            cikis.Location = new Point(187, 320);
            cikis.Size = new Size(120, 100);
            cikis.Click += Cikis_Click;

            this.Controls.Add(cikis);
            this.Controls.Add(oyna);
            this.Controls.Add(baslik);
            this.BackColor = Color.Black;

            this.CenterToScreen();

            
        }

        private void Cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Oyna_Click(object sender, EventArgs e)
        {
            Controls.Remove(baslik);
            Controls.Remove(oyna);
            Controls.Remove(cikis);
            timer1.Start();
            timer2.Start();
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                if (control is Label)
                {
                    Label lbl = (Label)control;
                    lbl.Top += 10;
                    if (lbl.Top == 410)
                    {
                        timer1.Stop();
                        timer2.Stop();

                        bitti.Width = 100;
                        bitti.Height = 50;
                        bitti.ForeColor = Color.White;
                        bitti.TextAlign = ContentAlignment.MiddleCenter;
                        bitti.Font = new Font("Microsoft YaHei", 9);
                        bitti.Text = "Öldün\n Menüye Dön";
                        bitti.Location = new Point(200, 175);
                        this.Controls.Add(bitti);
                        bitti.Click += Bitti_Click;
                        bitti.TabIndex = 0;
                    }
                }
            }
        }

        private void Bitti_Click(object sender, EventArgs e)
        {
            Controls.Remove(cikis);
            Controls.Remove(oyna);
            Controls.Remove(baslik);

            Application.Restart();
        }
    }
}
