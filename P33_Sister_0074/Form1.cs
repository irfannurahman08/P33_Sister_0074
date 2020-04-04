using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace P33_Sister_0074
{
    public partial class Form1 : Form
    {
        public bool playAgain = false;
        static Random r;
        static Thread player1thd;
        static Thread player2thd;
        static Thread player3thd;
        public static int countPlayer1;
        public static int countPlayer2;
        public static int countPlayer3;
        public Form1()
        {
            InitializeComponent();
            countPlayer1 = 0;
            countPlayer2 = 0;
            countPlayer3 = 0;
            r = new Random();
        }

        public static void Player1()
        {
            while (true)
            {
                Thread.Sleep(50);
                if (countPlayer1 > 650)
                {
                    player1thd.Abort();
                    break;
                }
                countPlayer1 = countPlayer1 + (1 + r.Next(6));
            }
        }

        public static void Player2()
        {
            while (true)
            {
                Thread.Sleep(50);
                if (countPlayer2 > 650)
                {
                    player2thd.Abort();
                    break;
                }
                countPlayer2 = countPlayer2 + (1 + r.Next(6));
            }
        }

        public static void Player3()
        {
            while (true)
            {
                Thread.Sleep(50);
                if (countPlayer3 > 650)
                {
                    player3thd.Abort();
                    break;
                }
                countPlayer3 = countPlayer3 + (1 + r.Next(6));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            countPlayer1 = 0;
            countPlayer2 = 0;
            countPlayer3 = 0;

            player1thd = new Thread(new ThreadStart(Player1));
            player1thd.IsBackground = true;
            player1thd.Start();

            player2thd = new Thread(new ThreadStart(Player2));
            player2thd.IsBackground = true;
            player2thd.Start();

            player3thd = new Thread(new ThreadStart(Player3));
            player3thd.IsBackground = true;
            player3thd.Start();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool chech = false;

            if (countPlayer1 > 650)
            {
                timer1.Stop();

                countPlayer1 = 0;
                countPlayer2 = 0;
                countPlayer3 = 0;
                chech = true;
                int i = Int32.Parse(labelSatu.Text);
                i++;
                labelSatu.Text = i.ToString();
                MessageBox.Show("Player one win the race");
            }

            if (countPlayer2 > 650)
            {
                timer1.Stop();

                countPlayer1 = 0;
                countPlayer2 = 0;
                countPlayer3 = 0;
                chech = true;
                int i = Int32.Parse(labelDua.Text);
                i++;
                labelDua.Text = i.ToString();
                MessageBox.Show("Player two win the race");
            }

            if (countPlayer3 > 650)
            {
                timer1.Stop();
                
                countPlayer1 = 0;
                countPlayer2 = 0;
                countPlayer3 = 0;
                chech = true;
                int i = Int32.Parse(labelTiga.Text);
                i++;
                labelTiga.Text = i.ToString();
                MessageBox.Show("Player three win the race");
            }

            if (chech == false)
            {
                button1.Left = countPlayer1;
                button2.Left = countPlayer2;
                button3.Left = countPlayer3;
            }
        }
    }
}
