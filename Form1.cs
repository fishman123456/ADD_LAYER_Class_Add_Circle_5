using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADD_LAYER_Class_Add_Circle_5
{
    public partial class Form1 : Form
    {

        public List<string> LayList = new List<string>();
        public char[] separator = { '\n' };
        string[] h;

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox1.Lines.Length; i++)
            {

                h = textBox1.Text.Split(separator);

            }
           
            Class2_Class_add_Layer class2_Class_Add_Layer = new Class2_Class_add_Layer();
              class2_Class_Add_Layer.AddLayer(h);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
