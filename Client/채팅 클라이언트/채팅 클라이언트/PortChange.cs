using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 채팅_클라이언트
{
    public partial class PortChange : Form
    {
        public PortChange()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.IpAdress1 = maskedTextBox1.Text;
            form.Port1 = int.Parse(maskedTextBox2.Text);
            form.채팅서버접속Menu1.Enabled = true;
            
        }
    }
}
