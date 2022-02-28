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
    public int[] stack = new int[100];
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
            //char[] stack = new char[100];  //후위표기 배열

            bool contNum = false;            //두자릿 수 이상 숫자인지
            bool pointNum = false;
            int count=0;

            
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
            
            
        }
        public static void init(StackType *s) {
            s->top = -1;
        }

        public static void pop()
        {

        }

        public static void push(StackType *s,char item)
        {
            s->stack[++(s->top)] = item;
        }
        public static void prec(char item)
        {
            switch (item)
            {
                case '*': case '/':
                    return 1;
                case '+': case '-':
                    return 2;
            }
        }

        public static void infix_to_postfix(char exp[],char cexp[])     //중위식배열,후위식배열
        {          
            int j=0;
            StackType s;
            init(&s);

            /*후위표기로 바꾸기*/
            for (int i=0; exp[i] != null;i++)
            {
                //bool num = int.TryParse(arrs[i], out 0);
                /*if (num)
                {
                    postfixCalc[i] = arrs[i];   숫자는 스위치 디폴트로
                }*/ 
                switch (arrCalc[i])
                {
                    case '(':
                        push(&s,'(');
                        break;
                    case ')':


                    
                    default:    //숫자
                        cexp[j] = exp[i];
                        j++;
                        break;

                }
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
