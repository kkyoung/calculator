using System;
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
    struct StackType {
    public int stack[100];
    public int top;
    };


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;   //식을 문자열로 받을 변수
            char[] arrs = s.ToCharArray();  // 문자열을 문자 배열로 변경
            char[] arrCalc = new char[100];  // arrs를 정리해 배열
            char[] postfixCalc = new char[100];  //후위표기 배열
            char[] stack = new char[100];  //후위표기 배열

            bool contNum = false;            //두자릿 수 이상 숫자인지
            bool pointNum = false;
            int count=0;


            int strIndex1 = s.LastIndexOf('+');
            int strIndex2 = s.LastIndexOf('-');
            string[] number;                  //+ -를 기준으로 나눠 저장
            
            double result=0;
            //*,/ 만들기
            //

            /*입력 받은 문자열을 숫자와 문자 구분해 배열에 삽입*/
            for (int i=0; i< arrs.Length;i++)
            {
                if ((arrs[i]>='0') && (arrs[i]<='9'))
                {
                    if (pointNum)
                    {
                        for (int j =1;i< arrs.Length;j++,i++)
                        {
                            arrCalc[count] = (double.Parse(arrCalc[count].ToString()) + double.Parse(arrs[i].ToString())*(1/ Math.Pow(100,j))).ToString();
                            if ((arrs[i+1]>='0') && (arrs[i+1]<='9'))   continue;
                            else break;
                        }
                    }
                    else if (contNum) arrCalc[count] = (double.Parse(arrCalc[count].ToString())*10 + double.Parse(arrs[i].ToString())).ToString;    //두자리 이상인 경우
                    else arrCalc[count] = arrCalc[i];           //double.Parse(arrCalc[i].ToString())
                    
                    contNum = true;
                }
                else if (arrs[i] =='.')     //소수점인 경우
                {
                    i++;
                    arrCalc[count] = (double.Parse(arrCalc[count].ToString()) + double.Parse(arrs[i].ToString())*0.1).ToString();
                    pointNum = true;
                    contNum = false;
                }
                else
                {
                    count++;
                    arrCalc[count] = arrs[i];
                    contNum = false;
                    pointNum = false;
                }
            }
            
            /*후위표기로 바꾸기*/
            for (int i=0; arrs[i] != null;i++)
            {
                bool num = int.TryParse(arrs[i], out 0);
                if (num)
                {

                }
                switch (arrCalc[i])
                {


                }
            }

            if (s.Contains("(")){
                int first = s.IndexOf('(');
                int second = s.IndexOf(')');
                string p = s.Substring(first+1,second-1);   //()안 식
                if (p.Contains("*") && p.Contains("/")) {
                    indexMulti = p.IndexOf('*');
                    indexDivision = p.IndexOf('/');

                    if (p.Contains("+"))    indexPlus = p.IndexOf('+');
                    else indexPlus = 0;

                    if(p.Contains("-")) indexMinus = p.IndexOf('-');
                    else indexMinus = 0;

                    if (indexMulti<indexDivision)
                    {
                        string str2 = RemoveNumber(p);
                   
                        for (int i=0; p[i] != null ; i++)
                        {
                            switch (str2[i])
                            {
                                case '*':
                                    result = 
                            }
                        }
                        count = p.Count(f => f == '*');
                        number = p.Split('*');
                        result =  Convert.ToDouble(number[0]);
                        if(indexPlus == 0 || indexMinus == 0)
                        {

                        }
                    }
                }
                else if (p.Contains("*"))
                {

                }
                else if (p.Contains("/")){

                }
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
        public static void init(StackType *s) {
            s->top = -1;
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
