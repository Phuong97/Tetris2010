using System;
using System.Threading;
using System.Windows.Forms;


namespace Tetris
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        { 
            InitializeComponent();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);
            if(progressBar1.Value == progressBar1.Maximum)
            {
               
                timer1.Enabled = false;
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
        }
    }
}
