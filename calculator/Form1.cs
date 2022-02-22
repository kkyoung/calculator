﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            string str = RemoveNumber(s);   //숫자 없앰
            string multi = "*";
            string division = "/";
            string plus = "+";
            string minus = "-";
            string[] index = {"+", "-", "*", "/","(",")"};
            int indexMulti,indexDivision,indexPlus,indexMinus;

            int strIndex1 = s.LastIndexOf('+');
            int strIndex2 = s.LastIndexOf('-');
            string[] number;                  //+ -를 기준으로 나눠 저장
            int count;
            double result=0;
            //*,/ 만들기
            //
            if (s.Contains("(")){
                int first = s.IndexOf('(');
                int second = s.IndexOf(')');


            }


            if (s.Contains("*") && s.Contains("/")) {
                indexMulti = s.IndexOf('*');
                indexDivision = s.IndexOf('/');
                if (indexMulti<indexDivision)
                {
                    count = s.Count(f => f == '*');
                    number = s.Split('*');
                    result =  Convert.ToDouble(number[0]);


                }
            }
            if (s.Contains("+"))
            {
                count = s.Count(f => f == '+');
                number = s.Split('+');
                result = Convert.ToDouble(number[0]);
                for (int i = 0; i < count + 1; i++)
                {
                    result += Convert.ToDouble(number[++i]);
                }
                textBox2.Text = result.ToString();
            }
            else if (s.Contains("-"))
            {
                count = s.Count(f => f == '-');
                number = s.Split('-');
                result = Convert.ToDouble(number[0]);
                for (int i = 0; i < count + 1; i++)
                {
                    result -= Convert.ToDouble(number[++i]);
                }
                textBox2.Text = result.ToString();

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public static string RemoveNumber(string str)
        {
            return Regex.Replace(str, @"\d", "");
        }

        public static double PlusMinus(double a,double b)
        {
            return 0;
        }

    }
}
