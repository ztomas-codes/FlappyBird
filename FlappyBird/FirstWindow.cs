using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class FirstWindow : MetroFramework.Forms.MetroForm
    {
        public FirstWindow()
        {
            InitializeComponent();
        }

        public static void NewGame()
        {
            Form1 f = new Form1();
            f.Show();
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewGame();
        }
    }
}
