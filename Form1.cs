/********************************************************************
 * Project: vector_to_raster
 * @file: Form1.cs
 * @说明：
 * @修改：
 *  1.5.14-5.16：使用webbrowser构建地图功能
 *  
 * @TODO：
 * 1. 如何通知客户无法获取坐标
 * *******************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Device.Location;
using System.ComponentModel;

namespace recommendation_system
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //Uri url = new Uri("https://www.baidu.com/");
            //忽略js脚本错误
            map_webbrowser.ScriptErrorsSuppressed = true;
            map_webbrowser.Navigate(Application.StartupPath+@"\map_page.html");
            map_webbrowser.NewWindow += new CancelEventHandler(Web_NewWindow);
            //map_webbrowser.Navigate(url.ToString());
            GetLocationEvent(); 
        }

        #region Web模块
        //防止弹出IE窗口
        private void Web_NewWindow(Object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel);
            messageBoxCS.AppendLine();
            MessageBox.Show(messageBoxCS.ToString(), "NewWindow Event");
        }
        #endregion


        #region 定位模块
        //定位器每次在调用定位函数时建立
        GeoCoordinateWatcher watcher = null;
        //html与winform交互
        private void SetCenter(params object[] args)
        {
            //this.map_webbrowser.Document.InvokeScript("Test");
            this.map_webbrowser.Document.InvokeScript("SetCenter",args);
        }
        //定位函数
        public void GetLocationEvent()
        {
            watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            watcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            bool started = watcher.TryStart(false, TimeSpan.FromMilliseconds(2000));
            if (!started)
            {
                MessageBox.Show("获取坐标超时");
            }
            //else if(watcher.Status!=GeoPositionStatus.Ready)
            //{
            //    MessageBox.Show("无法获取坐标");
            //}
            
        }
        //只有通过异步加载PositionChanged的方式才可以获得坐标
        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            SetCenter(new object[] { Convert.ToDouble(e.Position.Location.Longitude), Convert.ToDouble(e.Position.Location.Latitude) });
            MessageBox.Show($"您的位置：\nLatitude: {e.Position.Location.Latitude}, " +
                $"Longitude {e.Position.Location.Longitude}");
            watcher.PositionChanged -= new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            watcher.Dispose();
            //保证只定位一次

        }
        #endregion


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
