/********************************************************************
 * Project: vector_to_raster
 * @file: Form1.cs
 * @说明：
 * 111
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

        private void search_button_Click(object sender, EventArgs e)
        {

        }
    }
}
