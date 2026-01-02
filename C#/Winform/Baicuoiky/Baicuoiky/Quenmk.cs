using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baicuoiky
{
    public partial class Quenmk: Form
    {
        public Quenmk()
        {
            InitializeComponent();
        }

        bool movePosition;
        int xCoordinate;
        int yCoordinate;

        private void pbBack_Click(object sender, EventArgs e)
        {
            this.Close();
            Signin signin = new Signin();
            signin.Show();
        }
    }
}
