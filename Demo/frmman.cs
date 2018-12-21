using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;  //用到了线程 
namespace Demo
{
    public partial class frmman : Form
    {
        public frmman()
        {
            InitializeComponent();
        }

        Thread G_th; //定义一个线程
        Random G_random = new Random(); //定一个随机数对象
        int G_int_num; //定义一个变量用存放随机数
        /// <summary>
        /// 开始按钮事件1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            RemoveControl();
            int p_int_x = 15;
            int p_int_y = 78;
            for (int i = 0; i < 100; i++)
            {
                Button bt = new Button();
                bt.Text = (i + 1).ToString();
                bt.Name = (i + 1).ToString();
                bt.Width = 38;
                bt.Height = 38;
                bt.Location = new Point(p_int_x, p_int_y);
                bt.Click += new EventHandler(bt_Click);
                p_int_x += 39;   
                if ((i+1)%10==0)
                {
                    p_int_x = 15;
                    p_int_y += 39;
                }
                Controls.Add(bt);
            }
            G_th = new Thread(  // 新建一个线程 
                     delegate ()      // 使用匿名方法
                {
                         int P_int_count = 0; //初始化 计数器
                    while (true)     //无限循环 
                    {
                             P_int_count = ++P_int_count > 100000000 ? 0 : P_int_count; //计数器累加
                        this.Invoke((MethodInvoker)delegate     //将代码交给主线程 运行 匿名方法
                        {
                                 label2.Text = P_int_count.ToString();  //窗体中 显示 计数  
                        });
                             Thread.Sleep(1000);
                         }
                     }
                     );
            G_th.IsBackground = true;  //设置为 后台 线程
            G_th.Start();              //开始执行
            G_int_num = G_random.Next(1, 100); //生成随机数
            button1.Enabled = false;  //停用 按钮 
        }
        /// <summary>
        /// 按钮的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Click(object sender, EventArgs e)
        {
            Control P_control = sender as Control; //将 sender 转换成 Control

            if (int.Parse(P_control.Name) > G_int_num) //判断是否大于 随机数 

            {
                P_control.BackColor = Color.Red;    //背景 设置 红色
                P_control.Enabled = false;          //按钮停用
                P_control.Text = "大";              //按钮赋值
            }
            if (int.Parse(P_control.Name) < G_int_num)
            {
                P_control.BackColor = Color.Red;    //背景 设置 红色
                P_control.Enabled = false;          //按钮停用
                P_control.Text = "小";              //按钮赋值
            }
            if (int.Parse(P_control.Name) == G_int_num)
            {
                G_th.Abort();  // 线程终止 
                MessageBox.Show(string.Format("恭喜你猜对了，用时{1}秒，共猜了{0}次！", GetCount(), label2.Text), "恭喜");
            }
        }

        /// <summary>
        /// 用于查找窗口中 Enabled 属性为 false 的控件有多少  
        /// 也就是 说 有多少次 么有猜中 
        /// </summary>
        /// <returns> 返回没有猜中的次数 </returns>>
        string GetCount()
        {
            int P_int_temp = 0; //初始化计数器
            foreach (Control c in Controls)
            {
                if (!c.Enabled) P_int_temp++; // 计数器累加 
            }
            return P_int_temp.ToString();
        }

        private void 猜数字小游戏_Shown(object sender, EventArgs e)
        {
            this.Text = "制作一个数字猜猜看小游戏";
        }

        void RemoveControl()
        {
            for (int i = 0; i < 100; i++)  //遍历 100 个按钮
            {
                if (Controls.ContainsKey((i + 1).ToString())) //判断中 是否 有此按钮
                {
                    for (int j = 0; j < Controls.Count; j++)
                    {
                        if (Controls[j].Name == (i + 1).ToString())
                        {
                            Controls.RemoveAt(j);
                            break;
                        }
                    }
                }
            }
        }

        private void 猜数字小游戏_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);    //强行关闭窗体
        }
    }
}
