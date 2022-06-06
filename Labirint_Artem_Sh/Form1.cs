using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labirint_Artem_Sh
{
    public partial class Form1 : Form
    {
        Point startLocation;
        int countDown = 0;
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }
        private void InitializeGame()
        {
            GameTimer.Start();
            startLocation = panel1.Location;
            Cursor.Position = PointToScreen(startLocation);
            countDown = 12;
        }

        private void HotWalls(object sender, EventArgs e)
        {
            InitializeGame();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if(countDown < 0)
            {
                GameTimer.Stop();
                DialogResult userchoice = MessageBox.Show("Ты не успел дойти до выхода за отведённое время\n Попробовать снова?","Системное оповещение", MessageBoxButtons.YesNo);
                if(userchoice == DialogResult.Yes)
                {
                    InitializeGame();
                }
                else
                {
                    this.Close();
                }
            }
            lblTimer.Text = countDown.ToString();
            countDown--;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            GameTimer.Stop();
            DialogResult userchoice = MessageBox.Show("Ты успел дойти до выхода за отведённое время\n Попробовать снова?", "Системное оповещение", MessageBoxButtons.YesNo);
            if (userchoice == DialogResult.Yes)
            {
                InitializeGame();
            }
            else
            {
                this.Close();
            }
        }

        private void panelOuter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
