using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExpertChooseSystem.Model;

namespace ExpertChooseSystem
{
    public partial class WightInputWindow : Form
    {
        private IList<double> _wigths;

        public WightInputWindow(IList<double> wigths)
        {
            InitializeComponent();
            _wigths = wigths;
            Init();
        }

        private void Init()
        {
            textBox1.Text = _wigths[0].ToString();
            textBox2.Text = _wigths[1].ToString();
            textBox3.Text = _wigths[2].ToString();

            textBox4.Text = _wigths[3].ToString();
            textBox5.Text = _wigths[4].ToString();
            textBox6.Text = _wigths[5].ToString();
            textBox7.Text = _wigths[6].ToString();

            textBox8.Text = _wigths[7].ToString();
            textBox9.Text = _wigths[8].ToString();
            textBox10.Text = _wigths[9].ToString();

            textBox11.Text = _wigths[10].ToString();
            textBox12.Text = _wigths[11].ToString();
            textBox13.Text = _wigths[12].ToString();
            textBox14.Text = _wigths[13].ToString();
        }

        //点击确定保存
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _wigths[0] = Double.Parse(textBox1.Text);
                _wigths[1] = Double.Parse(textBox2.Text);
                _wigths[2] = Double.Parse(textBox3.Text);

                _wigths[3] = Double.Parse(textBox4.Text);
                _wigths[4] = Double.Parse(textBox5.Text);
                _wigths[5] = Double.Parse(textBox6.Text);
                _wigths[6] = Double.Parse(textBox7.Text);

                _wigths[7] = Double.Parse(textBox8.Text);
                _wigths[8] = Double.Parse(textBox9.Text);
                _wigths[9] = Double.Parse(textBox10.Text);

                _wigths[10] = Double.Parse(textBox11.Text);
                _wigths[11] = Double.Parse(textBox12.Text);
                _wigths[12] = Double.Parse(textBox13.Text);
                _wigths[13] = Double.Parse(textBox14.Text);
                Close();
            }
            catch (FormatException)
            {
                MessageBox.Show(@"请确定输入的数值都是小数，并且和为1！");
            }
        }
    }
}
