using System;
using System.Linq;
using System.Windows.Forms;

namespace RToast
{
    public partial class Form1 : Form
    {

        Toaster t;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.comboBox1.Enabled = false;
            this.panel1.Enabled = false;
            this.panel2.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 0;
            this.comboBox1.Enabled = true;
            this.panel1.Enabled = true;
            this.panel2.Enabled = true;
            this.button2.Enabled = true;
            this.button3.Enabled = true;
            t = new Toaster();
            t.add_heading(textBox1.Text);
            t.add_text(textBox2.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var check = this.panel2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;
            switch (check.ToString())
            {
                case "rb_short":
                    t.set_duration(Toaster.Duration.Short);
                    break;
                case "rb_long":
                    t.set_duration(Toaster.Duration.Long);
                    break;
                case "rb_stay":
                    t.set_duration(Toaster.Duration.Stay);
                    break;
            }
            //Console.WriteLine(check.ToString());

            t.show_toast();
            this.panel1.Enabled = false;
            this.panel2.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.comboBox1.Enabled = false;
            t = null;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            t.add_heading(textBox1.Text);
            label6.Text = textBox1.Text.Length.ToString();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            t.add_text(textBox2.Text);
            label7.Text = textBox2.Text.Length.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var check = this.panel2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Name;
            switch (check.ToString())
            {
                case "rb_short":
                    t.set_duration(Toaster.Duration.Short);
                    break;
                case "rb_long":
                    t.set_duration(Toaster.Duration.Long);
                    break;
                case "rb_stay":
                    t.set_duration(Toaster.Duration.Stay);
                    break;
            }
            t.schedule_toast(DateTime.Now.AddSeconds(Convert.ToDouble(this.comboBox1.SelectedItem.ToString())));
            //Console.WriteLine(this.comboBox1.SelectedItem.ToString());
            //return;
            this.panel1.Enabled = false;
            this.panel2.Enabled = false;
            this.button2.Enabled = false;
            this.button3.Enabled = false;
            this.comboBox1.Enabled = false;
            t = null;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

       
    }
}
