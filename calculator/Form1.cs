using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;   //식을 문자열로 받을 변수
            int strIndex1 = s.LastIndexOf('+');
            int strIndex2 = s.LastIndexOf('-');
            string[] number;                  //+ -를 기준으로 나눠 저장
            int count, result = 0;
            if (s.Contains("+"))
            {
                count = s.Count(f => f == '+');
                number = s.Split('+');
                result = Convert.ToInt32(number[0]);
                for (int i = 0; i < count + 1; i++)
                {
                    result += Convert.ToInt32(number[++i]);
                }
                textBox2.Text = result.ToString();
            }
            else if (s.Contains("-"))
            {
                count = s.Count(f => f == '-');
                number = s.Split('-');
                result = Convert.ToInt32(number[0]);
                for (int i = 0; i < count + 1; i++)
                {
                    result -= Convert.ToInt32(number[++i]);
                }
                textBox2.Text = result.ToString();

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
