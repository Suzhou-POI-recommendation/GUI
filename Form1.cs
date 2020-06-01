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
using MySql.Data.MySqlClient;
using MySql.Data.MySqlClient.Memcached;
using MySqlX.XDevAPI.Common;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Nlp.V20190408;
using TencentCloud.Nlp.V20190408.Models;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

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
            Image.FromFile("../icon/color0.jpg");

            imageList1.Images.Add(Image.FromFile("../icon/weibo.jpg"));
            imageList1.Images.Add(Image.FromFile("../icon/color0.jpg"));
            imageList1.Images.Add(Image.FromFile("../icon/color1.jpg"));
            imageList1.Images.Add(Image.FromFile("../icon/color2.jpg"));
            imageList1.Images.Add(Image.FromFile("../icon/color3.jpg"));
            imageList1.Images.Add(Image.FromFile("../icon/color4.jpg"));
            imageList1.Images.Add(Image.FromFile("../icon/color5.jpg"));
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



        //TODO:修改credential！！
        Credential cred = new Credential();
        
        private void search_button_Click(object sender, EventArgs e)
            //搜索功能
        {
            //更改界面状态
            file_slide.Visible = false;
            panelResult.Visible = true;
            map_webbrowser.Visible = false;
            treeView1.Nodes.Clear();
            
            //进度显示
            textBoxHint.Visible = true;
            textBoxHint.Text = "加载中...";
            textBoxHint.Refresh();
            
            //nlp分析器创建
            ClientProfile clientProfile = new ClientProfile();
            HttpProfile httpProfile = new HttpProfile();
            httpProfile.Endpoint = ("nlp.tencentcloudapi.com");
            clientProfile.HttpProfile = httpProfile;
            NlpClient client = new NlpClient(cred, "ap-guangzhou", clientProfile);
            SimilarWordsRequest req;
            SimilarWordsResponse resp;
            string[] seperator = { " ", ",", ";" };
            string[] keywords = bunifuMaterialTextbox1.Text.Split(seperator,15,StringSplitOptions.RemoveEmptyEntries);
            string regexp = "";
            for (int i = 0; i < keywords.Length; i++)
            {
                try
                {
                    textBoxHint.Text = String.Format("检索第{0}个关键词，共{1}个", i+1, keywords.Length);
                    textBoxHint.Refresh();
                    req = new SimilarWordsRequest();
                    string strParams = "{\"Text\":\"" + keywords[i] + "\",\"WordNumber\":20}";
                    req = SimilarWordsRequest.FromJsonString<SimilarWordsRequest>(strParams);
                    resp = client.SimilarWordsSync(req);
                    if (i > 0)
                        regexp += "|";
                    regexp += keywords[i] + "|" + string.Join("|", resp.SimilarWords);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            string query = "select poiid, title, public_grading from public_grading " +
                        "where poiid in " +
                        "(SELECT poiid FROM poi.pois_features where keywords regexp '" +
                        regexp +
                        "') order by public_grading desc";
            textBoxHint.Text = "加载查询中...";
            textBoxHint.Refresh();
            SelectinGeneral(query);
            textBoxHint.Text = String.Format("查询得到{0}个地点", progressBar1.Maximum);
            textBoxHint.Refresh();
        }
        
        //TODO：修改连接字符串！
        public string connectionString =
            "Data Source=127.0.0.1;Database=poi;User ID=root;Password=duhaode520;Charset=utf8;Allow User Variables=True;SslMode=None"; //连接字符串

        private void SelectinGeneral(string query)
        // 通用评分查询
        {
            try
            {
                const double level = 0.45;
                progressBar1.Visible = true;
                //查询对应分类的poi
                MySqlConnection cnn = null;
                MySqlConnection weibocnn = null;
                MySqlCommand cmd = null;
                MySqlDataReader dataReader = null;
                MySqlDataReader weiboReader = null;
                progressBar1.Maximum = 0;

                //建立poi查询连接
                textBoxHint.Text = "尝试建立与数据库的连接...";
                textBoxHint.Refresh();
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                weibocnn = new MySqlConnection(connectionString);
                weibocnn.Open();
                cmd = new MySqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = query;
                
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                    progressBar1.Maximum++;
                dataReader.Close();
                dataReader = cmd.ExecuteReader();

                //创建进度条
                progressBar1.Value = 0;
                progressBar1.Step = 1;
                textBoxHint.Text = "加载查询中...";
                textBoxHint.Refresh();

                //逐行处理
                while (dataReader.Read())
                {
                    //创建新的树节点
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = dataReader.GetString(1);

                    //确定分级根据分级选择相应图片显示
                    int starcount = Convert.ToInt32(dataReader.GetDouble(2) / level) + 1;
                    if (starcount > 6)
                        starcount = 6;
                    treeNode.ImageIndex = starcount;
                    treeNode.SelectedImageIndex = starcount;

                    //poi上的部分微博查询
                    string weiboQuery = String.Format("SELECT `text`,original_pic FROM poi.travel_poi_weibos_suzhou " +
                        "where annotation_place_poiid = '{0}'Limit 0, 20;", dataReader.GetString(0));//只显示一小部分微博
                    cmd = new MySqlCommand();
                    cmd.Connection = weibocnn;
                    cmd.CommandText = weiboQuery;
                    weiboReader = cmd.ExecuteReader();

                    //添加微博数据为子节点
                    while (weiboReader.Read())
                    {
                        TreeNode weiboNode = new TreeNode(weiboReader.GetString(0));
                        weiboNode.Tag = weiboReader.GetString(1);//传递图片url
                        treeNode.Nodes.Add(weiboNode);
                    }
                    treeView1.Nodes.Add(treeNode);
                    progressBar1.PerformStep();
                    weiboReader.Close();
                }
                dataReader.Close();
                cnn.Close();
                weibocnn.Close();
                progressBar1.Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        #region 分类推荐

        private void RecommendByCategory(string category)
        {
            //更改界面状态
            file_slide.Visible = false;
            panelResult.Visible = true;
            map_webbrowser.Visible = false;
            treeView1.Nodes.Clear();
            textBoxHint.Visible = true;
            textBoxHint.Text = "加载查询中...";
            textBoxHint.Refresh();
            //查询对应分类的poi
            string query = "select poiid, title, public_grading from public_grading where poiid in" +
                "(SELECT poiid FROM poi.pois_primary_category_suzhou where first_category = '" +
                category +
                "') order by public_grading desc limit 0, 500; ";//显示太多会炸
            SelectinGeneral(query);
            textBoxHint.Text = "显示了评分最高的500个地点";
            textBoxHint.Refresh();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            panelResult.Visible = false;
            map_webbrowser.Visible = true;
            textBoxHint.Visible = false;
        }

        private void btnCategory1_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory1.Text);
        }

        private void btnCategory2_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory2.Text);
        }

        private void btnCategory3_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory3.Text);
        }

        private void btnCategory4_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory4.Text);
        }

        private void btnCategory5_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory5.Text);
        }

        private void btnCategory6_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory6.Text);
        }

        private void btnCategory7_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory7.Text);
        }

        private void btnCategory8_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory8.Text);
        }

        private void btnCategory9_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory9.Text);
        }

        private void btnCategory10_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory10.Text);
        }

        private void btnCategory11_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory11.Text);
        }

        private void btnCategory12_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory12.Text);
        }

        private void btnCategory13_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory13.Text);
        }

        private void btnCategory14_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory14.Text);
        }

        private void btnCategory15_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory15.Text);
        }

        private void btnCategory16_Click(object sender, EventArgs e)
        {
            RecommendByCategory(btnCategory16.Text);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        //控制显示图片按钮的可用性
        {

            if (treeView1.SelectedNode.Tag!= null && !treeView1.SelectedNode.Tag.Equals(""))
                btnShowPicture.Enabled = true;
            else
                btnShowPicture.Enabled = false;
        }

        private void btnShowPicture_Click(object sender, EventArgs e)
            //显示微博中的图片
        {
            string url = (string)treeView1.SelectedNode.Tag;
            System.Net.WebRequest webreq = System.Net.WebRequest.Create(url);
            System.Net.WebResponse webres = webreq.GetResponse();
            using (System.IO.Stream stream = webres.GetResponseStream())
            {
                pictureBox1.Image = Image.FromStream(stream);
            }
        }

        #endregion

    }
}
