using System;
using System.Drawing;
using System.Windows.Forms;

namespace CSGO_CRASH
{
    public partial class MainForm : Form
    {
        Graphics g;
        Pen p;
        Random rand = new Random();
        int guess = 0;
        int upperB = 1000;
        decimal multiplier = 1.00m;
        bool IsRunning = false;
        int tick = 0;

        public MainForm()
        {
            InitializeComponent();
            p = new Pen(Brushes.Black, 1f);
            g = CreateGraphics();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (guess + multiplier < upperB)
            {
                tick++;


                upperB = (int)multiplier + 1000;
                guess = rand.Next(upperB);
                multiplier += multiplier / 1000.00m;
                label1.Text = $"{Math.Round(multiplier, 2)}x";
                if (tick < Width)
                    g.DrawEllipse(p, tick, Height - (float)multiplier * 100f, 1f, 1f);
            }
            else
            {
                timer1.Stop();
                IsRunning = false;
                button1.Text = "Start";
                MessageBox.Show($"Crashed in { tick / 100.0f} seconds");
                tick = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!IsRunning)
            {
                button1.Text = "Stop";
                guess = 0;
                upperB = 1000;
                multiplier = 1.00m;
                timer1.Start();
            }
            else
            {
                button1.Text = "Start";
                timer1.Stop();
            }
        }
    }
}