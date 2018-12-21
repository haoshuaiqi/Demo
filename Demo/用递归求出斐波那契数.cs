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
    public partial class 用递归求出斐波那契数 : Form
    {
        public 用递归求出斐波那契数()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (int.TryParse(textBox1.Text,out a))
            {
                label3.Text = Fei(a).ToString();
            }
            else
            {
                MessageBox.Show("请输入正确的数值","错误提示");
            }
        }
        /// <summary>
        /// 斐波那契数列递归运算
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public int Fei(int a)
        {
            if (a <= 0)
            {
                return 0;
            }
            else if (a >0 && a <= 2)
            {
                return 1;
            }
            else
            {
                return Fei(a - 1) + Fei(a - 2);
            }
        }
    
    }
}
