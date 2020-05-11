/********************************************************************
 * Project: vector_to_raster
 * @file: Form1.cs
 * @说明：
 * 1.Form1为本项目的主窗口类
 * 2.除实现作业的基本要求之外，本项目建立了基本的拓扑关系，以备之后程序开发之用
 * 3.实现了错误文件输入的报错
 * 4.矢量图层数据结构：使用节点、弧段、多边形和拓扑关系四个类实现了拓扑关系，在读入时建立拓扑关系
 *   栅格图层数据结构：使用二维数组grid存储了栅格各点的值，非0的为多边形内部。
 * 5.矢量文件的保存：由于C#没有矢量图形的编码器，无法保存为矢量文件，只能保存为png
 *   栅格文件的保存：栅格文件提供了多种保存方式，有bmp、gif、jpg和txt
 *      其中txt的存储格式为：第一行一次记录像元宽度，列数和行数，之后连续记录每一行中的相同值像元，
 *      两个数为一组，第一个记录值，第二个记录这一行中连续多少个为该值的像元。
 * 6.绘图：矢量图使用metafile图元类记录，可以保证无论放大多大都无锯齿；栅格图使用bitmap位图类记录
 * 
 * *******************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace recommendation_system
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        //变量


        //鼠标拖动整体窗口函数（由于去除了边框）
        //Constants in Windows API
        //0x84 = WM_NCHITTEST - Mouse Capture Test
        //0x1 = HTCLIENT - Application Client Area
        //0x2 = HTCAPTION - Application Title Bar
        public const int WM_NCLBUTTONDOWN = 0xA1;//非客户区
        public const int HT_CAPTION = 0x2;//标题栏
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        #region#界面模块绘制
        //退出按钮
        private void Exit_Button_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
        //文件菜单
        private void File_Button_MouseEnter(object sender, EventArgs e)
        {
            this.file_slide.Visible = true;
            MovePanel(button4);
        }

        private void file_slide_MouseLeave(object sender, EventArgs e)
        {
            if (file_slide.Visible) this.file_slide.Visible = false;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            MovePanel(button5);
            if (file_slide.Visible) file_slide.Visible = false;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            MovePanel(button6);
            if (file_slide.Visible) file_slide.Visible = false;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            MovePanel(button7);
            if (file_slide.Visible) file_slide.Visible = false;
        }
        //选择指示
        private void MovePanel(Control button)
        {
            this.panel5.Top = button.Top;
            //this.Height = button.Height;
        }

        #endregion

       

    }
}
