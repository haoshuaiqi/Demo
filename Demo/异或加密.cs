using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class 异或加密 : Form
    {
        public 异或加密()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            int num1, num2;
            if (int.TryParse(txtNum1.Text,out num1)&& int.TryParse(txtNum2.Text, out num2))









            {
                label4.Text = (num1 ^ num2).ToString();
            }
            else
            {
                MessageBox.Show("请输入数字","输入错误!");
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            int num1, num3;
            if (int.TryParse(txtNum2.Text, out num1) && int.TryParse(label4.Text, out num3))
            {
                label6.Text = (num3 ^ num1).ToString();
            }
            else
            {
                MessageBox.Show("请输入数字", "输入错误!");
            }
        }

        private void 异或加密_Load(object sender, EventArgs e)
        {
            /*原理 两者相等为0,不等为1.其中0为假,1为真
             真^假=真  1^0=1
             假^真=真   0^1=1
             真^真=假  1^1=0
             假^假=假  0^0=0
             比如,输入的是23,加密数15,
             那么加密之后为24,运算如下:
             23转化二进制10111,
             15转化二进制位1111,
             对比两个数,从右往左
             为 1^1=0,1^1=0,1^1=0,1^0=1,1^0=1
             得出结果为11000,转化为十进制为24
             */
            /*
             用异或运算符给两个数换位
             如a=9,b=11
             a=a^b,
             b=b^a,
             a=a^b,
             a=11,b=9
            */
            int a = 9, b = 11;
            label7.Text = "a="+a;
            label8.Text = "b=" + b;
            a = a ^ b;
            b = b ^ a;
            a = a ^ b;
            label9.Text = "a=" + a;
            label10.Text = "b=" + b;

        }
    }
}
