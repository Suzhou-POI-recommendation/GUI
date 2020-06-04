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
using System.Data;
using System.Data.OleDb;
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
            Image.FromFile(Application.StartupPath+"/icon/color0.jpg");

            imageList1.Images.Add(Image.FromFile(Application.StartupPath+"/icon/weibo.jpg"));
            imageList1.Images.Add(Image.FromFile("./icon/color0.jpg"));
            imageList1.Images.Add(Image.FromFile("./icon/color1.jpg"));
            imageList1.Images.Add(Image.FromFile("./icon/color2.jpg"));
            imageList1.Images.Add(Image.FromFile("./icon/color3.jpg"));
            imageList1.Images.Add(Image.FromFile("./icon/color4.jpg"));
            imageList1.Images.Add(Image.FromFile("./icon/color5.jpg"));
            SetCenter(new object[] { Convert.ToDouble(set_lon), Convert.ToDouble(set_lat) });
        }


        double cur_lat= 31.3257923126221, cur_lon= 120.625862121582;
        double set_lat = 31.3257923126221, set_lon = 120.625862121582;//用于周边搜索的点位


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
            //if (cur_lat == 0)
            //{
            //    SetCenter(new object[] { Convert.ToDouble(e.Position.Location.Longitude), Convert.ToDouble(e.Position.Location.Latitude) });
            //}
            //MessageBox.Show($"您的位置：\nLatitude: {e.Position.Location.Latitude}, " +
            //    $"Longitude {e.Position.Location.Longitude}");
            cur_lon = Convert.ToDouble(e.Position.Location.Longitude);
            cur_lat = Convert.ToDouble(e.Position.Location.Latitude);
            SetCenter(new object[] { Convert.ToDouble(set_lon), Convert.ToDouble(set_lat) });
            watcher.PositionChanged -= new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
            watcher.Dispose();
            //保证只定位一次

        }
        private void button6_Click(object sender, EventArgs e)
        {
            set_lat = cur_lat;
            set_lon = cur_lon;
            SetCenter(new object[] { Convert.ToDouble(cur_lon), Convert.ToDouble(cur_lat) });
        }


        #endregion

        #region 周边搜索
        public void LocalSearch()
        {
            string local_sql = $"select title,longitude,latitude,first_category,public_grading " +
                $"from user_view where public_grading<>0 and latitude > {set_lat}-0.01 and " +
                $"latitude < {set_lat}+0.01 and longitude > {set_lon}-0.01 and longitude < {set_lon}+0.01 " +
                $"order by ACOS(SIN(({set_lat} * 3.1415) / 180) * SIN((latitude * 3.1415) / 180) +" +
                $" COS(({set_lat} * 3.1415) / 180) * COS((latitude * 3.1415) / 180) *" +
                $" COS(({set_lon} * 3.1415) / 180 - (longitude * 3.1415) / 180)) * 6380 asc limit 200 ";
            MySqlConnection cnn = new MySqlConnection(connectionString);
            DataTable dt = null;
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(local_sql, cnn);
                DataSet ds = new DataSet();
                if (adapter.Fill(ds) > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            cnn.Close();
            if (dt==null) return;
            //处理成字符串
            string info=string.Empty;
            for(int i=0;i<dt.Rows.Count;++i)
            {
                double[] cord = GPS_transformation(Convert.ToDouble(dt.Rows[i][2]), Convert.ToDouble(dt.Rows[i][1]));
                info += $"{dt.Rows[i][0]},{cord[0]},{cord[1]}," +
                    $"{dt.Rows[i][3]},{dt.Rows[i][4]},";

            }
            ShowLocal(new object[] { info });
            SetCenter(new object[] { Convert.ToDouble(set_lon), Convert.ToDouble(set_lat) });
        }

        private void ShowLocal(params object[] args)
        {
            //this.map_webbrowser.Document.InvokeScript("Test", args);
            try
            {
                this.map_webbrowser.Document.InvokeScript("ShowLocal2", args);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        #region 边框拖动
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
        #endregion



        #region 界面模块绘制
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

        #region 搜索及评分

        //TODO:修改credential！！
        Credential cred = new Credential{ SecretId = "AKIDNWODzVLkhPqKXe7GdldExQbXHK7jKE6j", SecretKey = "VjhPvC72jAKXUActbmeHf99uT0HUYQ4V" };
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
            string query = "select poiid, title, public_grading from user_view " +
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
            "Data Source=127.0.0.1;Database=poi;User ID=root;Password=YYhh220929;Charset=utf8;Allow User Variables=True;SslMode=None"; //连接字符串

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
        #endregion

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
            string query = "select poiid, title, public_grading from user_view where " +
                "first_category = '" +
                category +
                "' order by public_grading desc limit 0, 500; ";//显示太多会炸
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

        private void button5_Click(object sender, EventArgs e)
        {
            LocalSearch();
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


        #region 坐标转换

        //以下是偏移到百度地图的算法
        static double pi = 3.14159265358979324;      //圆周率
        static double ee = 0.00669342162296594323;   //椭球的偏心率
        static double a = 6378245.0;                 //卫星椭球坐标投影到平面地图坐标系的投影因子
        static double x_pi = 3.14159265358979324 * 3000.0 / 180.0;  //圆周率转换量


        // 求弧度
        double radian(double d)
        {
            return d * pi / 180.0;   //角度1? = π / 180
        }


        double transformLat(double lat, double lon)    //纬度转化
        {
            double ret = -100.0 + 2.0 * lat + 3.0 * lon + 0.2 * lon * lon + 0.1 * lat * lon + 0.2 * Math.Sqrt(Math.Abs(lat));
            ret += (20.0 * Math.Sin(6.0 * lat * pi) + 20.0 * Math.Sin(2.0 * lat * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(lon * pi) + 40.0 * Math.Sin(lon / 3.0 * pi)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(lon / 12.0 * pi) + 320 * Math.Sin(lon * pi / 30.0)) * 2.0 / 3.0;
            return ret;
        }


        double transformLon(double lat, double lon)   //经度转化
        {
            double ret = 300.0 + lat + 2.0 * lon + 0.1 * lat * lat + 0.1 * lat * lon + 0.1 * Math.Sqrt(Math.Abs(lat));
            ret += (20.0 * Math.Sin(6.0 * lat * pi) + 20.0 * Math.Sin(2.0 * lat * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(lat * pi) + 40.0 * Math.Sin(lat / 3.0 * pi)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(lat / 12.0 * pi) + 300.0 * Math.Sin(lat / 30.0 * pi)) * 2.0 / 3.0;
            return ret;
        }


        /*****************************************************************************
         * WGS84(GPS坐标系) to 火星坐标系(GCJ-02)
         * 
         * @param lat
         * @param lon
         * @return
         ****************************************************************************/
        double[] GPS84_To_GCJ02(double WGS84_Lat, double WGS84_Lon)
        {
            double dLat;
            double dLon;
            double radLat;
            double magic;
            double sqrtMagic;
            double[] GCJ02=new double[2];
            dLat = transformLat(WGS84_Lon - 105.0, WGS84_Lat - 35.0);
            dLon = transformLon(WGS84_Lon - 105.0, WGS84_Lat - 35.0);
            radLat = WGS84_Lat / 180.0 * pi;
            magic = Math.Sin(radLat);
            magic = 1 - ee * magic * magic;
            sqrtMagic = Math.Sqrt(magic);
            dLat = (dLat * 180.0) / ((a * (1 - ee)) / (magic * sqrtMagic) * pi);
            dLon = (dLon * 180.0) / (a / sqrtMagic * Math.Cos(radLat) * pi);
            GCJ02[1] = WGS84_Lat + dLat;    //GCJ02_Lat是百度纬度存储变量的地址  *GCJ02_Lat就是那个值
            GCJ02[0] = WGS84_Lon + dLon;    //GCJ02_Lon是百度经度存储变量的地址  *GCJ02_Lon
            return GCJ02;
        }

        /*****************************************
         * 火星坐标系 (GCJ-02) 与百度坐标系 (BD-09) 的转换算法 将 GCJ-02 坐标转换成 BD-09 坐标
         * 
         * @param gg_lat
         * @param gg_lon
         *****************************************/
        //传入的参数  	GCJ02_To_BD09(*BD09_Lat,*BD09_Lon,BD09_Lat,BD09_Lon);
        //(*BD09_Lat,*BD09_Lon)火星坐标,(BD09_Lat,BD09_Lon)是变量的地址
        double[] GCJ02_To_BD09(double GCJ02_Lat, double GCJ02_Lon)
        {
            double[] BD_09 = new double[2];
            double x = GCJ02_Lon, y = GCJ02_Lat;
            double z = Math.Sqrt(x * x + y * y) + 0.00002 * Math.Sin(y * x_pi);
            double theta = Math.Atan2(y, x) + 0.000003 * Math.Cos(x * x_pi);
            BD_09[0] = z * Math.Cos(theta) + 0.0065;
            BD_09[1] = z * Math.Sin(theta) + 0.006;
            return BD_09;
        }

        private void map_webbrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        /*************************************************************
        函数名称：GPS_transformation(double WGS84_Lat, double WGS84_Lon,double * BD_09_Lat, double * BD_09_Lon)
        函数功能：GPS坐标转百度地图坐标
        输入参数：WGS84_Lat,WGS84_Lon GPS获取到真实经纬度  储存得到的百度经纬度变量的地址 BD_09_Lat,BD_09_Lon指向那个变量
        输出参数：
        *************************************************************/
        double[] GPS_transformation(double WGS84_Lat, double WGS84_Lon)
        {
            double[] BD_09=new double[2];
            double[] GCJ02 = new double[2];
            GCJ02 = GPS84_To_GCJ02(WGS84_Lat, WGS84_Lon);           //GPS坐标转火星坐标
            BD_09=GCJ02_To_BD09(GCJ02[1], GCJ02[0]);           //火星坐标转百度坐标 
            return BD_09;
        }

        #endregion

        #region 个性化推荐
        public static DataTable ExecuteQuery2(string connectionString, string strSQL)
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            DataTable dt = null;

            try
            {

                MySqlDataAdapter adapter = new MySqlDataAdapter(strSQL, cnn);
                DataSet ds = new DataSet();
                if (adapter.Fill(ds) > 0)
                    dt = ds.Tables[0];
            }
            catch (Exception msg)
            {
                System.Console.WriteLine(msg.ToString());
                return dt;
            }
            cnn.Close();
            return dt;
        }

        private void PersonalRecommandation1(int gender, int local, string Category, string FunctionArea)//用户提供个人信息
        {
            const double level = 0.45;
            string Month = DateTime.Now.Month.ToString();//获取当前月份

            //更改界面状态
            file_slide.Visible = false;
            panelResult.Visible = true;
            map_webbrowser.Visible = false;
            treeView1.Nodes.Clear();
            progressBar1.Visible = true;
            textBoxHint.Visible = true;
            textBoxHint.Text = "应用个性化喜好...";
            textBoxHint.Refresh();

            //建立记录个性化评分的datatable
            DataTable table1;
            if (gender == 1 && local == 1)
            {
                string sql1 = "SELECT poiid, title,gender_ratio*local_ratio*public_grading new_grade,month FROM personal_grading where first_category in (" + Category + ");";
                table1 = ExecuteQuery2(connectionString, sql1);
            }
            else if (gender == 1 && local == 2)
            {
                string sql1 = "SELECT poiid, title,gender_ratio*(1-local_ratio)*public_grading new_grade,month FROM personal_grading where first_category in (" + Category + ");";
                table1 = ExecuteQuery2(connectionString, sql1);
            }
            else if (gender == 2 && local == 1)
            {
                string sql1 = "SELECT poiid, title,(1-gender_ratio)*local_ratio*public_grading new_grade,month FROM personal_grading where first_category in (" + Category + ");";
                table1 = ExecuteQuery2(connectionString, sql1);
            }
            else if (gender == 2 && local == 1)
            {
                string sql1 = "SELECT poiid, title,(1-gender_ratio)*(1-local_ratio)*public_grading new_grade,month FROM personal_grading where first_category in (" + Category + ");";
                table1 = ExecuteQuery2(connectionString, sql1);
            }
            else
            {
                string sql1 = "SELECT poiid, title,(1-local_ratio)*public_grading new_grade,month FROM personal_grading where first_category in ('美食','购物','酒店','休闲娱乐');";
                table1 = ExecuteQuery2(connectionString, sql1);
            }


            int i = 0;
            DataTable functionAreaTable = ExecuteQuery2(connectionString, "SELECT * FROM poi_in_polygon_with_label");
            progressBar1.Maximum = Math.Min(500, table1.Rows.Count);
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            try
            {

                while (i < progressBar1.Maximum)
                {
                    string poiid = Convert.ToString(table1.Rows[i][0]);
                    if (Convert.ToString(table1.Rows[i][3]).Contains(Month))
                    {
                        table1.Rows[i][2] = Convert.ToSingle(table1.Rows[i][2]);
                    }
                    else
                    {
                        table1.Rows[i][2] = Convert.ToSingle(table1.Rows[i][2]) * 0.5;
                    }

                    int label = -1;
                    for (int j = 0; j < functionAreaTable.Rows.Count; j++)
                    {
                        if (Convert.ToString(functionAreaTable.Rows[j][1]).Contains(poiid))
                        {
                            label = Convert.ToInt32(functionAreaTable.Rows[j][2]);
                            break;
                        }
                    }
                    bool has_hotel = FunctionArea.Contains("酒店");
                    bool has_food = FunctionArea.Contains("美食");
                    bool has_nature = FunctionArea.Contains("自然");
                    bool has_culture = FunctionArea.Contains("人文");
                    bool has_tea = FunctionArea.Contains("下午茶");
                    switch (label)
                    {
                        case 0:
                            if (has_hotel && has_food)
                                table1.Rows[i][2] = Convert.ToSingle(table1.Rows[i][2]) * 1.5;
                            break;
                        case 1:
                            if (has_food)
                                table1.Rows[i][2] = Convert.ToSingle(table1.Rows[i][2]) * 1.5;
                            break;
                        case 2:
                            if (has_nature)
                                table1.Rows[i][2] = Convert.ToSingle(table1.Rows[i][2]) * 1.5;
                            break;
                        case 3:
                            if (has_tea)
                                table1.Rows[i][2] = Convert.ToSingle(table1.Rows[i][2]) * 1.5;
                            break;
                        case 4:
                            if (has_culture)
                                table1.Rows[i][2] = Convert.ToSingle(table1.Rows[i][2]) * 1.5;
                            break;
                        case 5:
                            if (has_hotel)
                                table1.Rows[i][2] = Convert.ToSingle(table1.Rows[i][2]) * 1.5;
                            break;
                        case 6:
                            if (has_nature && has_food)
                                table1.Rows[i][2] = Convert.ToSingle(table1.Rows[i][2]) * 1.5;
                            break;
                        case 7:
                            if (has_culture && has_food)
                                table1.Rows[i][2] = Convert.ToSingle(table1.Rows[i][2]) * 1.5;
                            break;
                        case 8:
                            if (has_tea && has_food)
                                table1.Rows[i][2] = Convert.ToSingle(table1.Rows[i][2]) * 1.5;
                            break;
                        default:
                            break;
                    }
                    i++;
                    progressBar1.PerformStep();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DataView dv = table1.DefaultView;
            dv.Sort = "new_grade Desc";
            table1 = dv.ToTable();
            textBoxHint.Text = "尝试建立与数据库的连接...";
            textBoxHint.Refresh();

            //数据库连接模式
            MySqlConnection weibocnn = null;
            weibocnn = new MySqlConnection(connectionString);
            weibocnn.Open();
            MySqlCommand cmd;
            cmd = new MySqlCommand();
            cmd.Connection = weibocnn;
            MySqlDataReader weiboReader = null;

            //逐行处理
            progressBar1.Maximum = Math.Min(500, table1.Rows.Count);
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            textBoxHint.Text = "加载查询中...";
            textBoxHint.Refresh();
            int k = 0;
            while (k < progressBar1.Maximum)
            {
                k++;
                progressBar1.PerformStep();
                //创建新的树节点
                TreeNode treeNode = new TreeNode();
                treeNode.Text = Convert.ToString(table1.Rows[k][1]);

                //确定分级根据分级选择相应图片显示
                int starcount = Convert.ToInt32(Convert.ToSingle(table1.Rows[k][2]) / level) + 1;
                if (starcount > 6)
                    starcount = 6;
                treeNode.ImageIndex = starcount;
                treeNode.SelectedImageIndex = starcount;

                //poi上的部分微博查询
                string weiboQuery = String.Format("SELECT `text`,original_pic FROM travel_poi_weibos_suzhou " +
                    "where annotation_place_poiid = '{0}'Limit 0, 10;", Convert.ToString(table1.Rows[k][0]));//只显示一小部分微博
                try
                {
                    cmd.CommandText = weiboQuery;
                    weiboReader = cmd.ExecuteReader();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //添加微博数据为子节点
                while (weiboReader.Read())
                {
                    TreeNode weiboNode = new TreeNode(weiboReader.GetString(0));
                    weiboNode.Tag = weiboReader.GetString(1);//传递图片url
                    treeNode.Nodes.Add(weiboNode);

                }
                treeView1.Nodes.Add(treeNode);
                weiboReader.Close();
                cmd.Cancel();

            }
            textBoxHint.Text = "显示了评分最高的500个地点";
            textBoxHint.Refresh();
            progressBar1.Visible = false;
        }

        public static int Gender = 0;
        public static int Local = 0;
        public static string Category = string.Empty;
        public static string FunctionArea = "";
        public static bool FirstEnter = true;

        private void button4_Click(object sender, EventArgs e)
        {

        }

        public static bool isCustomized = false;



        private void button7_Click(object sender, EventArgs e)
        {
            if (FirstEnter)
            {
                FirstEnter = false;
                Form2 form = new Form2();
                form.ShowDialog();
            }
            //TODO:Gender默认问题
            if (isCustomized)
                PersonalRecommandation1(Gender, Local, Category, FunctionArea);
        }
        #endregion

    }



}
