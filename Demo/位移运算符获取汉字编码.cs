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
    public partial class 位移运算符获取汉字编码 : Form
    {
        public 位移运算符获取汉字编码()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Encoding.GetEncoding 编码列表,简体中文为	gb2312
            
            try
            {
                char chr = textBox1.Text[0];
                byte[] gb = Encoding.GetEncoding("gb2312").GetBytes(new char[] { chr });
                int n = (int)gb[0] << 8;
                n += (int)gb[1];
                textBox2.Text = n.ToString ();
            }
            catch (Exception)
            {
                MessageBox.Show("请输入汉字字符","错误提示");
            }
        }
    }
}
