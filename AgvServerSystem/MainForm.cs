using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using BLL;
using System.Net;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AgvServerSystem
{
    public partial class MainForm : Form
    {
        #region properties
        #region 初始化
        /// <summary>
        /// 分容柜任务 站点 数
        /// </summary>
        private int testStations = 5;
        /// <summary>
        /// 查询站点信息
        /// </summary>
        private int stationTypeNO = 0;
        /// <summary>
        /// 是否刷新agv状态
        /// </summary>
        private bool IsRefAgvState = false;
        /// <summary>
        /// 下一组管制集合预测
        /// </summary>
        private List<int> nextControlList = new List<int>();
        /// <summary>
        /// 管制范围编号
        /// </summary>
        private int controlListNo = 1;
        /// <summary>
        /// TABCHECK集合
        /// </summary>
        private MT_TabCheckInfo[] mti;
        /// <summary>
        /// agv通讯参数list
        /// </summary>
        private List<MA_AgvComInfo> maaciList = new List<MA_AgvComInfo>();
        /// <summary>
        /// Agv小车线程集合
        /// </summary>
        private List<Thread> threadLs = new List<Thread>();   //Agv小车线程集合
        #endregion

        #region 电子地图
        /// <summary>
        /// 电子地图集合
        /// </summary>
        private Dictionary<int, MapPanel> mapShow = new Dictionary<int, MapPanel>();
        /// <summary>
        /// 当前上位机显示的地图编号
        /// </summary>
        private int CurrentMapNo = 0;
        /// <summary>
        /// 当前图片已放大倍数
        /// </summary>
        private float zoom = 1;   //当前图片已放大倍数
        /// <summary>
        /// panTabMap的宽
        /// </summary>
        private int pwPan;  //显示panTabMap的宽
        /// <summary>
        /// panTabMap的高
        /// </summary>
        private int phPan;  //显示panTabMap的高
        /// <summary>
        /// 是否左键选中电子地图且没有松开
        /// </summary>
        private bool isLeftMouseSelected = false;  //是否左键选中电子地图且没有松开
        /// <summary>
        /// 记录当左键按下时，该点的位置
        /// </summary>
        private Point mouseDownPoint = new Point(); //记录当左键按下时，该点的位置
        /// <summary>
        /// 是否可对RFID进行设定
        /// </summary>
        private bool isRfidSet = false;  //是否可对Rfid进行设定
        /// <summary>
        /// 是否可对站点进行设定        
        /// </summary>
        private bool isStationSet = false;
        /// <summary>
        /// 站点Label集合
        /// </summary>
        private Dictionary<int, Label> dtStationLabel = new Dictionary<int, Label>();
        /// <summary>
        /// 缩放比例
        /// </summary>
        private double mapScare = 1.0;  //缩放比例
        /// <summary>
        /// panTabMpa基础尺寸
        /// </summary>
        private int baseSize = 1400;  //基本panTabMap比较尺寸
        /// <summary>
        /// agv状态显示窗体
        /// </summary>
        private TableLayoutPanel tlpAgvLight = new TableLayoutPanel();
        /// <summary>
        /// 电子地图切换
        /// </summary>
        private TableLayoutPanel tlpMapBtn = new TableLayoutPanel();
        /// <summary>
        /// 电子地图切换按钮集合
        /// </summary>
        private Dictionary<int, Label> lblMapBtn = new Dictionary<int, Label>();
        /// <summary>
        /// 坐标显示label
        /// </summary>
        private Label lblMapXY = new Label();
        #endregion

        #region agv状态模型
        /// <summary>
        /// rfid地标label集合
        /// </summary>
        private Dictionary<int, Label> rfidLabelDt = new Dictionary<int, Label>();
        /// <summary>
        /// AgvLight控件是否按下鼠标左键
        /// </summary>
        private bool isLeftMouseAgvLight = false;  //在AgvLight控件上是否按下鼠标左键
        /// <summary>
        /// tlpAgv控件内左键按下时，该点的位置
        /// </summary>
        private Point mouseDownAgvPoint = new Point();  //记录在tlpAgv控件内左键按下时，该点的位置 
        /// <summary>
        /// 要显示的agv状态信息
        /// </summary>
        private Dictionary<int, Dictionary<Enumerations.LabelType, DoubleLabel>> showInfo = new Dictionary<int, Dictionary<Enumerations.LabelType, DoubleLabel>>();  //要显示的信息
        /// <summary>
        /// AGV模型存储
        /// </summary>
        private Dictionary<int, Panel> agvModel = new Dictionary<int, Panel>();  //AGV模型存储 
        /// <summary>
        /// agvModel布局 0：水平，1；垂直
        /// </summary>
        private Dictionary<int, int> _agvModelLayout = new Dictionary<int, int>();  //记录AgvModel 布局  0:水平布局，1:垂直布局
        #endregion

        #region 常规
        /// <summary>
        /// 任务查询
        /// </summary>
        string lineNoStr = string.Empty;
        /// <summary>
        /// 自动任务类型，初始为分容柜换料
        /// </summary>
        private Enumerations.TaskType autoTaskType = Enumerations.TaskType.Init;
        /// <summary>
        /// 当前tip进入的AGV模型
        /// </summary>
        private int tipAgvNo = 0;
        /// <summary>
        /// 判断数据是否导入或导出完成
        /// </summary>
        private bool isDataEnd = false;  //判断数据导入或导出是否完成
        /// <summary>
        /// 记录已添加的点位信息
        /// </summary>
        private List<string> stationAdd = new List<string>(); //记录已添加的点位信息
        /// <summary>
        /// 记录上一次读取agv信息数据
        /// </summary>
        private Dictionary<int, M_AgvInfo> _agvInfo = new Dictionary<int, M_AgvInfo>();  //记录上一次的读取数据时的agv信息
        /// <summary>
        /// 记录agv在线编号
        /// </summary>
        private List<int> _agvNoList = new List<int>();  //记录agv在线编号
        private List<string> lines = new List<string>();  //线别集合
        private Dictionary<int, bool> isDisConn = new Dictionary<int, bool>();  //agv掉线是否记录
        /// <summary>
        /// agv异常是否记录
        /// </summary>
        private Dictionary<int, int> isAbnormalWrite = new Dictionary<int, int>();  //agv异常是否已记录
        /// <summary>
        /// 是否有充电桩异常
        /// </summary>
        private Dictionary<int, bool> isChargeStationError = new Dictionary<int, bool>();
        /// <summary>
        /// 显示任务名称集合
        /// </summary>
        private List<string> taskShowKeyLs = new List<string>();  //显示任务名称集合
        #endregion

        #region 布局
        private SplitContainer splitPan = new SplitContainer();
        private SplitContainer splitPanAgv = new SplitContainer();
        /// <summary>
        /// 电子地图/AGV状态
        /// </summary>
        private SplitContainer splitPanMap = new SplitContainer();
        /// <summary>
        /// 电子地图/AGV状态  任务信息
        /// </summary>
        private SplitContainer splitPanAll = new SplitContainer();
        #endregion
        #endregion //变量

        #region Controls
        /// <summary>
        /// 当前测试分容任务
        /// </summary>
        DataGridView dgvType1Task = new DataGridView();
        /// <summary>
        /// 当前预充老化房任务
        /// </summary>
        DataGridView dgvType2Task = new DataGridView();
        /// <summary>
        /// 当前分容老化房任务
        /// </summary>
        DataGridView dgvType3Task = new DataGridView();
        /// <summary>
        /// 是否加载窗体完成
        /// </summary>
        bool isLOadOk = false;
        /// <summary>
        /// 待机充电位状态显示label
        /// </summary>
        Dictionary<Enumerations.OtherStation, ToolStripLabel> dtOtherStationStu = new Dictionary<Enumerations.OtherStation, ToolStripLabel>();
        /// <summary>
        /// 任务总分隔器分容测试任务分离器
        /// </summary>
        SplitContainer splitTask = new SplitContainer();
        /// <summary>
        /// 老化房任务拆分器
        /// </summary>
        SplitContainer splitTaskAgingRoom = new SplitContainer();
        /// <summary>
        /// 房门控制状态Label集合
        /// </summary>
        Dictionary<int, Label> dtDoorStateLabel = new Dictionary<int, Label>();
        /// <summary>
        /// 房门开门按钮集合
        /// </summary>
        Dictionary<int, Button> dtDoorOpenButton = new Dictionary<int, Button>();
        /// <summary>
        /// 房门关门按钮集合
        /// </summary>
        Dictionary<int, Button> dtDoorCloseButton = new Dictionary<int, Button>();
        /// <summary>
        /// 电梯绑定状态集合
        /// </summary>
        Dictionary<int, Label> dtElevatorBindLabel = new Dictionary<int, Label>();
        /// <summary>
        /// 电梯控制状态Label集合
        /// </summary>
        Dictionary<int, Label> dtElevatorStateLabel = new Dictionary<int, Label>();
        /// <summary>
        /// 电梯门开楼层集合
        /// </summary>
        Dictionary<int, Label> dtElevatorOpenLabel = new Dictionary<int, Label>();
        /// <summary>
        /// 电梯开门按钮
        /// </summary>
        Dictionary<int, Button> dtElevatorOpenButton = new Dictionary<int, Button>();
        /// <summary>
        /// 电梯关门按钮
        /// </summary>
        Dictionary<int, Button> dtElevatorCloseButton = new Dictionary<int, Button>();
        /// <summary>
        /// 充电桩控制状态Label集合
        /// </summary>
        Dictionary<int, Label> dtChargeStateLabel = new Dictionary<int, Label>();
        /// <summary>
        /// 充电桩伸出按钮集合
        /// </summary>
        Dictionary<int, Button> dtChargeOutputButton = new Dictionary<int, Button>();
        /// <summary>
        /// 充电桩缩进按钮集合
        /// </summary>
        Dictionary<int, Button> dtChargeInputButton = new Dictionary<int, Button>();
        /// <summary>
        /// 充电桩绑定状态集合
        /// </summary>
        Dictionary<int, Label> dtChargeBindLabel = new Dictionary<int, Label>();
        /// <summary>
        /// 管控集合RFID
        /// </summary>
        Dictionary<int, Label> dtControlsRfids = new Dictionary<int, Label>();
        /// <summary>
        /// 管控集合AGV
        /// </summary>
        Dictionary<int, Label> dtControlsAgvs = new Dictionary<int, Label>();
        /// <summary>
        /// 判断是否为特殊执行方式  当左右键按下间隔为小于1秒时，为真
        /// </summary>
        private bool isSpecialMouseOperate;
        /// <summary>
        /// 特殊操作判断开始时间       
        /// </summary>
        private DateTime mouseJudgeTime;
        #endregion

        public MainForm()
        {
            //Dictionary<int, int> dt = new Dictionary<int, int>();
            //dt[1] = 1;
            //dt[2] = 2;
            //dt[4] = 4;
            //dt[3] = 3;
            //dt = dt.OrderBy(o => o.Value).ToDictionary(o => o.Key, p => p.Value);
            //dt = dt.OrderByDescending(o => o.Value).ToDictionary(o => o.Key, p => p.Value);
            InitializeComponent();
            //System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
        }

        #region AGv窗体拆分事件 splitPanAgv_SplitterMoved
        void splitPanAgv_SplitterMoved(object sender, SplitterEventArgs e)
        {
            try
            {
                if (this.isLOadOk)
                {
                    Common.splitStatusHeight = splitPanAgv.SplitterDistance;
                }
            }
            catch { }
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            this.SendToBack();
            tmrAgvInfo.Enabled = false;
            tmrMapChange.Enabled = false;
            tmrMapRef.Enabled = false;
            tmrRef.Enabled = false;
            tmrTip.Enabled = false;
            WaitFormService.Show();
            WaitFormService.SetText("Agv control system\r\n\r\nLoading...");
            WaitForm.pValue++;
            WaitFormService.SetContents("Read Init parameters...");
            //防休眠
            WinSleepCtr.SleepCtr(true);

            #region 参数初始化 parameters init
            #region 创建显示AGV数据的Label Create show agv datas'label
            tlpAgvLight.BackColor = Color.Transparent;
            tlpAgvLight.AutoSize = true;
            tlpAgvLight.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpAgvLight.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
            tlpAgvLight.ContextMenuStrip = cmnuTlpAgvLight;
            //tlpAgvLight.BackColor = Color.Lime;
            tlpAgvLight.AutoScroll = true;
            panTabMap.Dock = DockStyle.Top;
            tlpAgvLight.MouseMove += new MouseEventHandler(tlpAgvLight_MouseMove);
            tlpAgvLight.MouseDown += new MouseEventHandler(tlpAgvLight_MouseDown);
            tlpAgvLight.MouseUp += new MouseEventHandler(tlpAgvLight_MouseUp);
            #endregion
            #region 坐标显示 coordinate show
            lblMapXY.BackColor = Color.Black;
            lblMapXY.Font = new Font("宋体", 9f, FontStyle.Regular);
            lblMapXY.ForeColor = Color.White;
            lblMapXY.AutoSize = false;
            lblMapXY.Size = new Size(100, 12);
            lblMapXY.Text = "x:    0 y:    0";
            lblMapXY.Parent = panTabMap;
            lblMapXY.BringToFront();
            lblMapXY.Location = new Point(panTabMap.Width - lblMapXY.Width, panTabMap.Height - lblMapXY.Height);
            #endregion
            ParametersOperate.ParameterInit();
            #endregion

            WaitForm.pValue++;
            WaitFormService.SetContents("Creating main form...");

            #region 添加电子地图、AgvModel add map and agv models
            try
            {
                tlpMapBtn = new TableLayoutPanel();
                tlpMapBtn.AutoSize = true;
                tlpMapBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                tlpMapBtn.CellBorderStyle = TableLayoutPanelCellBorderStyle.Outset;
                tlpMapBtn.RowCount = 1;
                tlpMapBtn.ColumnCount = Common.mapInfo.Count;
                tlpMapBtn.Padding = new Padding(0);
                tlpMapBtn.Margin = new Padding(0);
                tlpMapBtn.Parent = panTabMap;
                tlpMapBtn.Location = new Point(0, 0);
                foreach (int i in Common.mapInfo.Keys)
                {
                    try
                    {
                        MapPanel pan = new MapPanel();
                        pan.Parent = panTabMap;
                        pan.BringToFront();
                        pan.BackgroundImageLayout = ImageLayout.Stretch;
                        pan.MouseDown += new MouseEventHandler(panTabMapShow_MouseDown);
                        pan.MouseEnter += new EventHandler(panTabMapShow_MouseEnter);
                        pan.MouseLeave += new EventHandler(panTabMapShow_MouseLeave);
                        pan.MouseMove += new MouseEventHandler(panTabMapShow_MouseMove);
                        pan.MouseUp += new MouseEventHandler(panTabMapShow_MouseUp);
                        pan.Resize += new EventHandler(panTabMapShow_Resize);
                        pan.MouseWheel += new MouseEventHandler(panTabMapShow_MouseWheel);
                        pan.MouseClick += pan_MouseClick;
                        pan.MouseDoubleClick += new MouseEventHandler(panTabMapShow_MouseDoubleClick);
                        pan.Name = Common.mapInfo[i];
                        Label lbl = new Label();
                        lbl.Parent = tlpMapBtn;
                        lbl.Text = pan.Name;
                        lbl.Location = new Point(0, 0);
                        lbl.BorderStyle = BorderStyle.Fixed3D;
                        lbl.Padding = new Padding(0);
                        lbl.Margin = new Padding(0);
                        lbl.TextAlign = ContentAlignment.MiddleCenter;
                        lbl.Font = new Font("宋体", 9f, FontStyle.Bold);
                        //lbl.Visible = false;
                        lblMapBtn[i] = lbl;
                        lbl.Tag = i;
                        lbl.Click += new EventHandler(lbl_Click);
                        pan.Tag = i;
                        string mapName = "map" + i.ToString() + ".jpg";
                        pan.BackgroundImage = Properties.Resources.background;
                        try
                        {
                            pan.BackgroundImage = new Bitmap(Common.Instance.SourcePath + @"\Information\" + mapName);
                        }
                        catch
                        { }
                        mapShow[i] = pan;
                        if (i == 0)
                        {
                            pan.Visible = true;
                            lbl.BackColor = Color.Lime;
                            //tlpAgvLight.Parent = mapShow[i];
                            tlpAgvLight.Location = new Point(Common.tlpPoint.X, Common.tlpPoint.Y);
                        }
                        else
                        {
                            pan.Visible = false;
                            lbl.BackColor = Color.Silver;
                        }
                    }
                    catch
                    { }
                }
                //设定初始Agv Model的图片存储位置
            }
            catch { }
            tlpMapBtn.BringToFront();
            try
            {
                string imagePath = Common.Instance.SourcePath + @"\Information\agv_.gif";
                if (File.Exists(imagePath))
                {
                    Image image = Image.FromFile(imagePath);
                    image.Save(Common.Instance.SourcePath + @"\Information\agv.gif");
                    picConfigMapModel.Image = image;
                }
            }
            catch
            { }
            #endregion //添加电子地图、AgvModel

            WaitForm.pValue++;
            WaitFormService.SetContents("Ui init...");

            #region 电子地图缩放参数初始化 map init 
            ObtainSizeScaleImage();
            pwPan = panTabMap.Width;
            phPan = panTabMap.Height;
            lblMapXY.BringToFront();
            this.DoubleBuffered = true;
            #endregion //电子 地图缩放参数初始化

            WaitForm.pValue++;
            WaitFormService.SetContents("Configuration init...");

            #region 窗体初始化 form init
            mnuInitSetIsDynPwd.Checked = Common.isDynPwd;
            mnuInitSetIsDynPwd.Visible = false;
            chbQRCode.Checked = Common.Instance.isReceiveQRCode;
            mnuSetReceiveMesTask.Checked = Common.Instance.isReceiveOpcTask;
            cbAgvCommonType.SelectedIndex = 0;
            //mnuSetPassEnable.Checked = Common.Instance.passEnable;
            stuLabelTcpStatus.Visible = false;
            stuProDataToSql.Visible = false;
            stuLabelDataToSql.Visible = false;
            tlpAgvLight.ColumnCount = Common.agvstatusLayout.X;
            tlpAgvLight.RowCount = Common.agvstatusLayout.Y;
            mnuLoginChangePassword.Visible = false;  //隐藏修改密码菜单，当登录用户级别为2级以上时显示
            mnuLoginAdd.Visible = false; //隐藏添加用户菜单，当登录用户级别为2级以上时显示
            mnuInitSet.Visible = false;  //隐藏初始化设定菜单，当登录用户级别为3级以上时显示
            mnuSet.Visible = false;    //隐藏设定菜单，当登录用户级别为2级以上时显示
            tabpMap.Parent = null;  //隐藏电子地图Tab
            tabpTask.Parent = null;  //隐藏任务Tab
            tabpQueryAbnormal.Parent = null;  //隐藏异常信息查询Tab
            tabpConfig.Parent = null;  //隐藏设置Tab
            int countTab = mnuInitSetTab.DropDownItems.Count;   //根据上次打开软件时存储的显示哪些Tab记录来打开对应的Tab
            mti = new MT_TabCheckInfo[countTab];
            BT_TabCheckInfo bti = new BT_TabCheckInfo();
            Dictionary<string, string> dtNameswitch = new Dictionary<string, string>();
            dtNameswitch["Map"] = "监控地图";
            dtNameswitch["Task Record"] = "任务记录查询";
            dtNameswitch["Error Record"] = "异常信息查询";
            dtNameswitch["Configuration"] = "配置";
            for (int i = 0; i < countTab; i++)
            {
                mti[i] = new MT_TabCheckInfo();
                mti[i].T_Name = dtNameswitch[mnuInitSetTab.DropDownItems[i].Text];
                mti[i].T_Checked = bti.ExistsChecked(mti[i].T_Name);
                if (mti[i].T_Checked == 1)
                {
                    switch (mti[i].T_Name)
                    {
                        case "监控地图":
                            mnuInitSetTabMap.Checked = true;
                            tabpMap.Parent = tabMain;
                            break;
                        case "任务记录查询":
                            mnuInitSetTabQueryTask.Checked = true;
                            tabpTask.Parent = tabMain;
                            break;
                        case "异常信息查询":
                            mnuInitSetTabQueryAbnormal.Checked = true;
                            tabpQueryAbnormal.Parent = tabMain;
                            break;
                        case "配置":
                            mnuInitSetTabConfig.Checked = true;
                            if (LoginRoler.U_Level == 3)
                            {
                                tabpConfig.Parent = tabMain;
                            }
                            break;
                        default: break;
                    }
                }
                else
                {
                    switch (mti[i].T_Name)
                    {
                        case "监控地图":
                            mnuInitSetTabMap.Checked = false;
                            tabpMap.Parent = null;
                            break;
                        case "任务记录查询":
                            mnuInitSetTabQueryTask.Checked = false;
                            tabpTask.Parent = null;
                            break;
                        case "异常信息查询":
                            mnuInitSetTabQueryAbnormal.Checked = false;
                            tabpQueryAbnormal.Parent = null;
                            break;
                        case "配置":
                            mnuInitSetTabConfig.Checked = false;
                            tabpConfig.Parent = null;
                            break;
                        default: break;
                    }
                }
            }
            IsComm();   //是否开启连接Client
            tabpState.Parent = null;
            tabpState.Parent = tabMain;
            #endregion //窗体初始化

            WaitForm.pValue++;
            WaitFormService.SetContents("Buffer ...");

            #region datagridview闪灯 datagridview optimizer
            dgvType1Task.DoubleBufferDataGridView(true);
            dgvType2Task.DoubleBufferDataGridView(true);
            dgvType3Task.DoubleBufferDataGridView(true);
            #endregion

            WaitForm.pValue++;
            WaitFormService.SetContents("Station init...");

            #region 站点Label初始化 station label init
            List<StationInfo> lsStation = BA_XmlOperate.StationLabelInfoRead();
            foreach (StationInfo item in lsStation)
            {
                Common.dtStationInfo[item.Id] = item;
            }
            #endregion

            WaitForm.pValue++;
            WaitFormService.SetContents("RFID parameters init...");

            #region 其它 agv设置、rfid设置、客户端监听 xml参数 other init
            BA_AgvComInfo bai = new BA_AgvComInfo();  //读取所有已设置的Agv小车
            maaciList = bai.QueryAllAgvComInfo();

            BS_StatioinAddressInfo bsai = new BS_StatioinAddressInfo();  //读取所有线别
            DataSet ds = bsai.QueryAllStationAddressInfo();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (!lines.Contains(ds.Tables[0].Rows[i][0].ToString()))
                {
                    lines.Add(ds.Tables[0].Rows[i][0].ToString());
                }
            }
            List<MA_RfidPoint> rLs = BA_XmlOperate.AgvRfidPointRead();  //读取所有已设置的RFID
            Common.rfidDt = rLs.ToDictionary(o => o.RfidNo, p => p);
            #region rfid阵列
            int max = 1000000;
            List<MA_RfidPoint> lsrfd = Common.rfidDt.Values.ToList();
            DijkstraSolution.graph = new int[lsrfd.Count, lsrfd.Count];
            double interval = 10 / ((double)lsrfd.Count * lsrfd.Count);
            double addIn = WaitForm.pValue;
            DateTime dt = DateTime.Now;
            for (int i = 0; i < lsrfd.Count; i++)
            {
                for (int j = 0; j < lsrfd.Count; j++)
                {
                    if (lsrfd[i].RfidInfos.Any(o => o.EdgeRfidNum == lsrfd[j].RfidNo))
                    {
                        try
                        {
                            DijkstraSolution.graph[i, j] = lsrfd[i].RfidInfos.Find(o => o.EdgeRfidNum == lsrfd[j].RfidNo).EdgeLength;
                        }
                        catch { }
                    }
                    else
                    {
                        DijkstraSolution.graph[i, j] = max;
                    }
                    addIn += interval;
                    //WaitForm.pValue = (int)addIn;
                    if (WaitForm.pValue != (int)addIn)
                    {
                        WaitForm.pValue = (int)addIn;
                        WaitFormService.SetContents("RFID阵列生成...");
                    }
                }
            }
            Debug.Print(DateTime.Now.Subtract(dt).TotalSeconds.ToString());
            //DijkstraSolution di = new DijkstraSolution();
            //di.RouteArray();
            WaitForm.pValue += 10;
            #endregion
            try
            {
                List<DoorInfo> dLs = BA_XmlOperate.DoorInfoRead(); //读取房门参数            
                Common.Instance.dtDoorInfo = dLs.ToDictionary(o => o.DoorNo, p => p);
            }
            catch { }
            try
            {
                List<ElevatorInfo> eLs = BA_XmlOperate.ElevatorInfoRead();  //读取电梯参数
                Common.Instance.dtElevatorInfo = eLs.ToDictionary(o => o.Id, p => p);
                foreach (int item in Common.Instance.dtElevatorInfo.Keys)
                {
                    Common.Instance.dtElevatorInfo[item].ButtonStatus = new List<KeyValuePair<int, bool>>();
                    for (int i = 0; i < Common.Instance.dtElevatorInfo[item].FloorNumber; i++)
                    {
                        Common.Instance.dtElevatorInfo[item].ButtonStatus.Add(new KeyValuePair<int, bool>(i + 1, false));
                    }
                }
            }
            catch { }
            try
            {
                List<ChargeInfo> cLs = BA_XmlOperate.ChargeInfoRead();  //读取充电桩参数
                Common.Instance.dtChargeInfo = cLs.ToDictionary(o => o.ChargeNo, p => p);
                foreach (int item in Common.Instance.dtChargeInfo.Keys)
                {
                    Common.Instance.dtChargeInfo[item].BeginTime = new DateTime();
                }
            }
            catch { }
            try
            {
                List<StationInformation> sLs = BA_XmlOperate.StationInfoRead();
                sLs = sLs.OrderBy(o => o.StationNo).ToList();
                Common.Instance.dtStationInformation = sLs.ToDictionary(o => o.StationType + "_" + o.StationNo + "_" + o.Group, p => p);
                //foreach (string item in Common.Instance.dtStationInformation.Keys)
                //{
                //    if (Common.Instance.dtStationInformation[item].StationRfid > 5000 && Common.Instance.dtStationInformation[item].StationRfid < 5400)
                //    {
                //        Common.Instance.dtStationInformation[item].StationMatchValue = Common.Instance.dtStationInformation[item].StationMatchValue.Replace("FR01", "FR02");
                //        Common.Instance.dtStationInformation[item].StationDescribe = Common.Instance.dtStationInformation[item].StationMatchValue;
                //    }
                //}
                //foreach (string item in Common.Instance.dtStationInformation.Keys)
                //{
                //    if (Common.Instance.dtStationInformation[item].StationType == (int)StationInformation.EStationType.PreAgingRoom)
                //    {
                //        if (Common.Instance.dtStationInformation[item].StationRfid % 200 > 100)
                //        {
                //            Common.Instance.dtStationInformation[item].Group = Common.Instance.dtStationInformation[item].StationRfid / 200 * 2 + 1;
                //        }
                //        else
                //        {
                //            Common.Instance.dtStationInformation[item].Group = Common.Instance.dtStationInformation[item].StationRfid / 200 * 2 + 2;
                //        }
                //    }

                //}
                #region 添加预充老化房1_2站点
                //List<string> keys = Common.Instance.dtStationInformation.Keys.ToList();
                //foreach (string item in keys)
                //{
                //    if (Common.Instance.dtStationInformation[item].StationRfid >= 106 && Common.Instance.dtStationInformation[item].StationRfid <= 110)
                //    {
                //        for (int i = 1; i < 9; i++)
                //        {
                //            string key = string.Format("{0}_{1}", 12, Common.Instance.dtStationInformation[item].StationRfid + i * 5);
                //            Common.Instance.dtStationInformation[key] = new StationInformation();
                //            Common.Instance.dtStationInformation[key].Key = key;
                //            Common.Instance.dtStationInformation[key].StationRfid = Common.Instance.dtStationInformation[item].StationRfid + i * 5;
                //            Common.Instance.dtStationInformation[key].StationNo = Common.Instance.dtStationInformation[item].StationNo + i * 5;
                //            Common.Instance.dtStationInformation[key].StationEnable = true;
                //            Common.Instance.dtStationInformation[key].StationName = Common.Instance.dtStationInformation[item].StationName.Remove(Common.Instance.dtStationInformation[item].StationName.Length - 3) + (Common.Instance.dtStationInformation[item].StationNo + i * 5).ToString("D3");
                //            Common.Instance.dtStationInformation[key].StationOperate = "230";
                //            Common.Instance.dtStationInformation[key].StationType = 12;
                //            Common.Instance.dtStationInformation[key].TypeName = Common.Instance.dtStationInformation[item].TypeName;
                //            Common.Instance.dtStationInformation[key].StationMatchValue = Common.Instance.dtStationInformation[item].StationMatchValue.Replace("_002", "_" + (2 + i).ToString("D3"));
                //            Common.Instance.dtStationInformation[key].StationDescribe = Common.Instance.dtStationInformation[key].StationMatchValue;
                //            Common.Instance.dtStationInformation[key].Group = 1;
                //        }
                //    }
                //}
                #endregion
            }
            catch { }
            try
            {
                List<BatteryCapacityDetectorParameters> detectorLs = BA_XmlOperate.DectectorInfoRead();
                Common.Instance.dtBatteryCapcityDetector = detectorLs.ToDictionary(o => o.DetectorNo, p => p);
            }
            catch { }
            //List<int> rfidLs = Common.rfidDt.Keys.ToList();
            //foreach (int item in rfidLs)
            //{
            //    if (item >= 1 && item <= 30)
            //    {
            //        MA_RfidPoint rfid = Common.rfidDt[item];
            //        Common.rfidDt[item + 1000] = new MA_RfidPoint(item + 1000, rfid.RfidX, rfid.RfidY + 10, rfid.MapNo, rfid.RfidLayout, rfid.RfidTop, rfid.RfidBottom, rfid.RfidLeft, rfid.RfidRight);
            //    }
            //}
            try
            {
                List<MatchStationInfo> matchStationLs = BA_XmlOperate.MatchStationRead();
                Common.matchStations = matchStationLs.ToDictionary(o => o.AgvNo, p => p);
            }
            catch { }
            WaitForm.pValue++;
            WaitFormService.SetContents("agv参数初始化...");
            //启动agv通讯
            AgvThreadStart();
            ////启动客户端监听
            BC_TcpServer bcTcpServer = new BC_TcpServer();
            bcTcpServer.Bc_BeginListen();
            #endregion //其它 agv设置、rfid设置、客户端监听

            //BA_AgvCommunicationThread.AgvCommuDt[37].Lock();

            WaitFormService.SetContents("任务分配线程初始化...");

            #region 任务分配线程 task allocation thread
            Thread thrTaskAllocation = new Thread(TaskAllocation.Instance.TaskAllocationFunction);
            thrTaskAllocation.Name = "taskAllocationThread";
            thrTaskAllocation.IsBackground = true;
            thrTaskAllocation.Start();
            threadLs.Add(thrTaskAllocation);
            #endregion

            WaitForm.pValue++;

            #region 房门通讯线程 Not used thread
            try
            {
                double dInterval = 25 / ((double)Common.Instance.dtDoorInfo.Count);
                double addDInterval = WaitForm.pValue;
                foreach (DoorInfo item in Common.Instance.dtDoorInfo.Values)
                {
                    //if (item.DoorNo != 11 && item.DoorNo != 12)
                    //{
                    //    Common.Instance.dtDoorInfo[item.DoorNo].DoorComm.Enable = false;
                    //}
                    //else
                    //{
                    Common.Instance.dtDoorInfo[item.DoorNo].DoorComm.Enable = true;
                    //}
                    bool isCreateThread = true;
                    if (item.Relation > 0)//存在关联房门
                    {
                        if (DoorUdpClient.dtDoorUdp.ContainsKey(item.Relation))
                        {//存在关联房门，且该关联的房门已经创建的线程，则不重新创建线程
                            isCreateThread = false;
                            DoorUdpClient.dtDoorUdp[item.DoorNo] = DoorUdpClient.dtDoorUdp[item.Relation];
                        }
                    }
                    if (isCreateThread)
                    {
                        DoorUdpClient udpClient = new DoorUdpClient(item.DoorNo);
                        DoorUdpClient.dtDoorUdp[item.DoorNo] = udpClient;
                        Thread thr = new Thread(udpClient.ReadDoorInformation);
                        thr.IsBackground = true;
                        thr.Start();
                    }
                    addDInterval += dInterval;
                    WaitForm.pValue = (int)addDInterval;
                    WaitFormService.SetContents(string.Format("[房门{0}]通讯初始化...", item));
                }
            }
            catch { }
            //创建房门控制控件
            CreateDoorStateControls();
            #endregion

            #region 电梯通讯线程 not used thread
            try
            {
                double dInterval = 5 / ((double)Common.Instance.dtElevatorInfo.Count);
                double addDInterval = WaitForm.pValue;
                foreach (ElevatorInfo item in Common.Instance.dtElevatorInfo.Values)
                {
                    bool isCreateThread = true;
                    ElevatorUdpClient udpClient = new ElevatorUdpClient(item.Id);
                    ElevatorUdpClient.dtElevatorUdp[item.Id] = udpClient;
                    Thread thr = new Thread(udpClient.ReadElevatorInformation);
                    thr.IsBackground = true;
                    thr.Start();
                    addDInterval += dInterval;
                    WaitForm.pValue = (int)addDInterval;
                    WaitFormService.SetContents(string.Format("[电梯{0}]通讯初始化...", item));
                }
            }
            catch { }
            //创建电梯控制控件
            CreateElevatorStateControls();
            #endregion

            #region 充电桩通讯线程 not used thread
            try
            {
                double dInterval = 5 / ((double)Common.Instance.dtChargeInfo.Count);
                double addDInterval = WaitForm.pValue;
                foreach (ChargeInfo item in Common.Instance.dtChargeInfo.Values)
                {
                    bool isCreateThread = true;
                    ChargeUdpClient udpClient = new ChargeUdpClient(item.ChargeNo);
                    ChargeUdpClient.dtChargeUdp[item.ChargeNo] = udpClient;
                    Thread thr = new Thread(udpClient.ReadChargeInformation);
                    thr.IsBackground = true;
                    thr.Start();
                    addDInterval += dInterval;
                    WaitForm.pValue = (int)addDInterval;
                    WaitFormService.SetContents(string.Format("[充电桩{0}]通讯初始化...", item));
                }
            }
            catch { }
            //创建充电桩控制控件
            CreateChargeStateControls();
            #endregion

            #region 读取电梯信号线程 弃用 not used thread
            //ReadElevatorData readElevator = new ReadElevatorData();
            //ReadElevatorData.readElevatorData = readElevator;
            //Thread readElevatorThread = new Thread(readElevator.ReadData);
            //readElevatorThread.Name = "ReadElevatorThread";
            //readElevatorThread.IsBackground = true;
            //readElevatorThread.Start();
            #endregion //读取电梯信号线程

            #region 三菱通讯线程  弃用 not used thread
            //Common.Instance.mitsubishiPLC = new MitsubishiPLC();
            //Common.Instance.mitsubishiPLC.setReadOrea(MitsubishiPLC.oreaType.OreaD);
            //Common.Instance.mitsubishiPLC.setReadOrgin(200);
            //Common.Instance.mitsubishiPLC.setReadLength(50);
            //Thread thrMitsubishiPlc = new Thread(Common.Instance.mitsubishiPLC.setReadStart);
            //thrMitsubishiPlc.IsBackground = true;
            //thrMitsubishiPlc.Start();
            //threadLs.Add(thrMitsubishiPlc);
            #endregion

            #region OPC通讯线程 opc communication thread
            try
            {
                OPCClient opcClient = new OPCClient();
                Thread thrOpc = new Thread(opcClient.OPCClientOperate);
                thrOpc.IsBackground = true;
                thrOpc.Start();
            }
            catch { }
            #endregion

            WaitForm.pValue++;
            WaitFormService.SetContents("agv状态控件生成...");

            #region 创建Agv状态灯、创建AGV模型
            CreateAgvPictureBx();
            #endregion //创建Agv状态灯、创建AGV模型

            WaitForm.pValue++;
            WaitFormService.SetContents("任务列表初始化...");

            #region 当前任务列表初始化
            #region 任务类型1
            //lvCurrentTask
            dgvType1Task.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvType1Task.Tag = 1;
            dgvType1Task.Font = new System.Drawing.Font("宋体", 9f, FontStyle.Regular);
            dgvType1Task.AllowUserToAddRows = false;
            dgvType1Task.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvType1Task.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            dgvType1Task.Dock = DockStyle.Fill;
            dgvType1Task.ReadOnly = true;
            dgvType1Task.RowHeadersVisible = false;
            dgvType1Task.ScrollBars = ScrollBars.Both;
            dgvType1Task.CellDoubleClick += dgvCurrentTask_MouseDoubleClick;
            //dgvCapacityTestTask.Click += lvCurrentTask_Click;
            dgvType1Task.ColumnCount = 7;
            dgvType1Task.MouseDown += dgvCurrentTask_MouseDown;
            dgvType1Task.Columns[0].HeaderText = "TaskId";
            dgvType1Task.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType1Task.Columns[1].HeaderText = "Describe";
            dgvType1Task.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType1Task.Columns[2].HeaderText = "Type";
            dgvType1Task.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType1Task.Columns[3].HeaderText = "StartTime";
            dgvType1Task.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType1Task.Columns[4].HeaderText = "State";
            dgvType1Task.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType1Task.Columns[5].HeaderText = "Bind AGV";
            dgvType1Task.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType1Task.Columns[6].HeaderText = "CreateTime";
            dgvType1Task.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            #endregion
            #region 任务类型2
            dgvType2Task.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvType2Task.Tag = 2;
            dgvType2Task.Font = new System.Drawing.Font("宋体", 9f, FontStyle.Regular);
            dgvType2Task.AllowUserToAddRows = false;
            dgvType2Task.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvType2Task.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            dgvType2Task.Dock = DockStyle.Fill;
            dgvType2Task.ReadOnly = true;
            dgvType2Task.RowHeadersVisible = false;
            dgvType2Task.ScrollBars = ScrollBars.Both;
            dgvType2Task.CellDoubleClick += dgvCurrentTask_MouseDoubleClick;
            //dgvPreAgingRoomTask.Click += lvCurrentTask_Click;
            dgvType2Task.ColumnCount = 7;
            dgvType2Task.MouseDown += dgvCurrentTask_MouseDown;
            dgvType2Task.Columns[0].HeaderText = "TaskId";
            dgvType2Task.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType2Task.Columns[1].HeaderText = "Describe";
            dgvType2Task.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType2Task.Columns[2].HeaderText = "Type";
            dgvType2Task.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType2Task.Columns[3].HeaderText = "StartTime";
            dgvType2Task.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType2Task.Columns[4].HeaderText = "State";
            dgvType2Task.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType2Task.Columns[5].HeaderText = "Bind AGV";
            dgvType2Task.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType2Task.Columns[6].HeaderText = "CreatTime";
            dgvType2Task.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            #endregion
            #region 任务类型3
            //lvCurrentTask            
            dgvType3Task.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvType3Task.Tag = 3;
            dgvType3Task.Font = new System.Drawing.Font("宋体", 9f, FontStyle.Regular);
            dgvType3Task.AllowUserToAddRows = false;
            dgvType3Task.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvType3Task.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            dgvType3Task.Dock = DockStyle.Fill;
            dgvType3Task.ReadOnly = true;
            dgvType3Task.RowHeadersVisible = false;
            dgvType3Task.ScrollBars = ScrollBars.Both;
            dgvType3Task.CellDoubleClick += dgvCurrentTask_MouseDoubleClick;
            //dgvCapAgingRoomTask.Click += lvCurrentTask_Click;
            dgvType3Task.ColumnCount = 7;
            dgvType3Task.MouseDown += dgvCurrentTask_MouseDown;
            dgvType3Task.Columns[0].HeaderText = "TaskId";
            dgvType3Task.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType3Task.Columns[1].HeaderText = "Describe";
            dgvType3Task.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType3Task.Columns[2].HeaderText = "Type";
            dgvType3Task.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType3Task.Columns[3].HeaderText = "StationId";
            dgvType3Task.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType3Task.Columns[4].HeaderText = "State";
            dgvType3Task.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType3Task.Columns[5].HeaderText = "Bind AGV";
            dgvType3Task.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvType3Task.Columns[6].HeaderText = "CreateTime";
            dgvType3Task.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; ;
            #endregion
            #endregion

            #region 创建管控控件
            CreateControlLabel();
            #endregion

            WaitForm.pValue++;

            #region 读取掉线前的任务
            ReceiveTask();
            #endregion

            #region 保存参数线程开启
            Thread thrParameterSave = new Thread(ParametersOperate.LoopSave);
            thrParameterSave.IsBackground = true;
            thrParameterSave.Start();
            #endregion

            #region 自动添加任务
            Thread thrAutoTask = new Thread(AutoTask);
            thrAutoTask.IsBackground = true;
            thrAutoTask.Start();
            #endregion

            WaitForm.pValue++;
            WaitFormService.SetContents("布局调整中...");

            #region MES通讯线程  尚未启用
            //mesInfo MesInfo = new mesInfo();
            ////获取任务线程
            //Thread thrGetTask = new Thread(MesInfo.RecTask);
            //thrGetTask.IsBackground = true;
            //thrGetTask.Start();
            ////更新AGV状态线程
            //Thread thrUpdateAgvState = new Thread(MesInfo.UpdateAgvState);
            //thrUpdateAgvState.IsBackground = true;
            //thrUpdateAgvState.Start();
            ////更新任务状态线程
            //Thread thrUpdateTaskState = new Thread(MesInfo.UpdateTaskState);
            //thrUpdateTaskState.IsBackground = true;
            //thrUpdateTaskState.Start();
            #endregion

            #region 布局
            splitPan.Size = new System.Drawing.Size(this.Width, this.Height);
            splitPanAgv.Size = new System.Drawing.Size(this.Width, this.Height);
            splitPan.SplitterDistance = this.Width + 50;
            splitPanAgv.SplitterDistance = this.Height - tlpAgvLight.Height - 12;
            splitPan.Panel1Collapsed = true;
            splitPan.Panel2Collapsed = true;
            splitPan.Panel2MinSize = 0;
            splitPan.Orientation = Orientation.Vertical;
            splitPan.Dock = DockStyle.Fill;
            tabMain.Dock = DockStyle.Fill;
            splitPan.Panel1.Controls.Add(tabMain);
            this.Controls.Add(splitPan);
            //splitPan.pan2
            splitPanAgv.Orientation = Orientation.Vertical;
            splitPanAgv.Dock = DockStyle.Fill;
            splitPanAgv.SplitterMoved += splitPanAgv_SplitterMoved;
            //splitPan.Panel2.Controls.Add(tlpAgvLight);
            tlpAgvLight.Dock = DockStyle.Fill;
            //tabpState.Controls.Add(lvCurrentCapacityTestTask);
            //tabpState.Controls.Add(tlpAgvLight);
            tabpTaskState.Parent = null;
            //tabpTaskState.Parent = tabMain;
            WaitForm.pValue++;
            #region 任务状态排序
            dgvType1Task.Dock = DockStyle.Fill;
            gbTaskStateCapacityTest.Controls.Add(dgvType1Task);
            gbTaskStateCapacityTest.Controls.Add(panCapTestTask);
            dgvType2Task.Dock = DockStyle.Fill;
            gbTaskStatePreChargeBurnInRoom.Controls.Add(dgvType2Task);
            gbTaskStatePreChargeBurnInRoom.Controls.Add(panPreAgingTask);
            dgvType3Task.Dock = DockStyle.Fill;
            gbTaskStateCapacityBurnInRoom.Controls.Add(dgvType3Task);
            gbTaskStateCapacityBurnInRoom.Controls.Add(panCapAgingTask);
            #endregion
            #region 电子地图/AGV状态/任务状态布局
            this.tabpMap.Controls.Add(splitPanAll);
            splitPanAll.Dock = DockStyle.Fill;
            splitPanAll.Orientation = Orientation.Vertical;
            //splitPanAll.SplitterDistance = 500;
            splitPanAll.SplitterMoved += splitPanAll_SplitterMoved;
            this.splitPanAll.Panel1.Controls.Add(splitPanMap);
            splitPanMap.Dock = DockStyle.Fill;
            splitPanMap.Orientation = Orientation.Horizontal;
            //splitPanMap.SplitterDistance = 500;
            splitPanMap.SplitterMoved += splitPanMap_SplitterMoved;

            tlpAgvLight.Dock = DockStyle.Fill;
            splitPanMap.Panel2.Controls.Add(tlpAgvLight);
            panTabMap.Dock = DockStyle.Fill;
            splitPanMap.Panel1.Controls.Add(panTabMap);
            #endregion
            //splitPanAgv.Panel1.Controls.Add(lvCurrentTask);
            //splitPanAgv.Panel2.Controls.Add(tlpAgvLight);
            //tabpState.Controls.Add(splitPanAgv);
            //splitPanAgv.Panel2.Controls.Add(tlpAgvLight);
            //splitPanAgv.SplitterDistance = tlpAgvLight.Width + 34;

            //stu  mnu
            stu.Dock = DockStyle.Bottom;
            mnu.Dock = DockStyle.Top;
            this.Controls.Add(stu);
            this.Controls.Add(mnu);
            #endregion

            #region 待机充电位状态label初始化
            //stuLabelCharge.Tag = "应急充电位:";
            //this.dtOtherStationStu[Enumerations.OtherStation.charge] = stuLabelCharge;
            //stuLabelChargeFloor1.Tag = "1楼充电:";
            //this.dtOtherStationStu[Enumerations.OtherStation.ChargeFloor1] = stuLabelChargeFloor1;
            //stuLabelWaitFloor2.Tag = "2楼待机:";
            //this.dtOtherStationStu[Enumerations.OtherStation.WaitFloor2] = stuLabelWaitFloor2;
            //stuLabelChargeFloor2.Tag = "2楼充电:";
            //this.dtOtherStationStu[Enumerations.OtherStation.ChargeFloor2] = stuLabelChargeFloor2;
            #endregion

            //MA_AgvTaskInfo task = new MA_AgvTaskInfo();
            //int load = Convert.ToInt32(21);
            //int unload = Convert.ToInt32(24);
            //if (load > 0 && load <= Common.Instance.floorStation)
            //{
            //    task.T_Type = Enumerations.TaskType.TaskType_2;
            //}
            //else
            //{
            //    task.T_Type = Enumerations.TaskType.TaskType_1;
            //}
            #region Load
            try
            {
                if (Common.isMapChange)
                {
                    tmrMapChange.Enabled = true;
                    tmrMapChange.Interval = Common.mapChangeTime;
                }
                else
                {
                    tmrMapChange.Enabled = false;
                }
            }
            catch { }
            foreach (int item in mapShow.Keys)
            {
                ControlsOperate.AddLabelRfidPoint(Common.rfidDt, mapShow[item], this.rfidLabelDt);  //在地图上添加RFID的label控件       
                ControlsOperate.AddLabelStationPoint(Common.dtStationInfo, mapShow[item], this.dtStationLabel);
            }
            Common.isRfidVisible = true;  //Rfid是否可见
            IsRfidVisible(false);  //让Rfid坐标的label不显示
            UpdateRadioButton();
            WaitForm.pValue++;
            WaitForm.IsOpen = true;
            #endregion

            #region 任务分离
            gbTaskStateCapacityTest.Dock = DockStyle.Fill;
            gbTaskStatePreChargeBurnInRoom.Dock = DockStyle.Fill;
            gbTaskStateCapacityBurnInRoom.Dock = DockStyle.Fill;
            splitTask.SplitterMoved += splitTask_SplitterMoved;
            splitTask.Orientation = Orientation.Horizontal;
            splitTask.Dock = DockStyle.Fill;
            splitTask.Parent = splitPanAll.Panel2;
            splitTask.Panel1.Controls.Add(gbTaskStatePreChargeBurnInRoom);
            splitTask.Panel2.Controls.Add(gbTaskStateCapacityTest);
            splitTaskAgingRoom.SplitterMoved += splitTaskBurnInRoom_SplitterMoved;
            splitTaskAgingRoom.Orientation = Orientation.Horizontal;
            splitTaskAgingRoom.Dock = DockStyle.Fill;
            //splitTaskAgingRoom.Panel1.Controls.Add(gbTaskStatePreChargeBurnInRoom);
            splitTaskAgingRoom.Panel2.Controls.Add(gbTaskStateCapacityBurnInRoom);
            #endregion

            tabpDoor.Parent = null;
            tabMain.Controls.Add(tabpDoor);
            tabpControlState.Parent = null;
            tabMain.Controls.Add(tabpControlState);

            tmrAgvInfo.Enabled = true;
            tmrMapChange.Enabled = true;
            tmrMapRef.Enabled = true;
            tmrRef.Enabled = true;
            tmrTip.Enabled = true;
            mapShow[CurrentMapNo].Size = panTabMap.Size;
            this.BringToFront();
            //Common.Instance.isReceiveMesTask = false;//初始化时，将mes通讯断开，必须登录才可使用

            #region DataGridView 颜色设定
            WaitForm.pValue++;
            //管制卡
            dgvConfigControl.RowsDefaultCellStyle.BackColor = Color.White;
            dgvConfigControl.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvConfigControl.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //房门配置
            dgvShutterDoor.RowsDefaultCellStyle.BackColor = Color.White;
            dgvShutterDoor.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvShutterDoor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //充电桩配置
            dgvChargeInfo.RowsDefaultCellStyle.BackColor = Color.White;
            dgvChargeInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvChargeInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //站点配置
            dgvStationInformation.RowsDefaultCellStyle.BackColor = Color.White;
            dgvStationInformation.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvStationInformation.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //agv配置
            dgvAgvInfo.RowsDefaultCellStyle.BackColor = Color.White;
            dgvAgvInfo.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvAgvInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //任务记录
            dgvSqlTaskData.RowsDefaultCellStyle.BackColor = Color.White;
            dgvSqlTaskData.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvSqlTaskData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //异常记录
            dgvSqlData.RowsDefaultCellStyle.BackColor = Color.White;
            dgvSqlData.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvSqlData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //任务1
            dgvType1Task.RowsDefaultCellStyle.BackColor = Color.White;
            dgvType1Task.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvType1Task.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //任务2
            dgvType2Task.RowsDefaultCellStyle.BackColor = Color.White;
            dgvType2Task.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvType2Task.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //任务3
            dgvType3Task.RowsDefaultCellStyle.BackColor = Color.White;
            dgvType3Task.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            dgvType3Task.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            WaitForm.pValue++;
            #endregion

            #region 页面隐藏
            gbAgvOperation.Visible = false;
            groupBox5.Visible = false;
            tabpState.Parent = null;
            tabpTaskState.Parent = null;
            tabpControlState.Parent = null;
            tabpDoor.Parent = null;
            tabConfigCapacityTest.Parent = null;
            tabConfigBurnInRoom.Parent = null;
            tabConfigShutterDoor.Parent = null;
            tabConfigElevator.Parent = null;
            #endregion

            #region 路径查询测试
            //for (int i = 0; i < 60; i++)
            //{
            //    RouteQueryTest rt = new RouteQueryTest(i);
            //    Thread thr = new Thread(rt.QueryRouteTest);
            //    thr.IsBackground = true;
            //    thr.Start();
            //}
            #endregion

            #region 向OPC写入每个站点AGV信息线程
            WriteOpcAgvStates();
            #endregion

            //TestAsync();
            //Debug.Print("加载完毕");
        }

        #region 电子地图分离器设定
        void splitPanMap_SplitterMoved(object sender, SplitterEventArgs e)
        {
            try
            {
                if (this.isLOadOk)
                {
                    Common.splitMap.Y = splitPanMap.SplitterDistance;
                }
            }
            catch { }
        }

        void splitPanAll_SplitterMoved(object sender, SplitterEventArgs e)
        {
            try
            {
                if (this.isLOadOk)
                {
                    Common.splitMap.X = splitPanAll.SplitterDistance;
                }
            }
            catch { }
        }
        #endregion

        //private async void TestAsync()
        //{
        //    await TestAsync2();
        //}
        //private async Task TestAsync2()
        //{
        //    while (true)
        //    {
        //        Debug.Print(DateTime.Now.ToString("yyyyMMddHHmmss"));
        //        //UpdateElevatorState();
        //        await Task.Delay(500);
        //    }
        //}

        #region 任务分离器
        void splitTaskBurnInRoom_SplitterMoved(object sender, SplitterEventArgs e)
        {
            try
            {
                if (this.isLOadOk)
                {
                    Common.splitTask.Y = splitTaskAgingRoom.SplitterDistance;
                }
            }
            catch { }
        }

        void splitTask_SplitterMoved(object sender, SplitterEventArgs e)
        {
            try
            {
                if (this.isLOadOk)
                {
                    Common.splitTask.X = splitTask.SplitterDistance;
                }
            }
            catch { }
        }
        #endregion

        #region 切换电子地图按钮事件
        private void lbl_Click(object sender, EventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                int i = (int)lbl.Tag;
                lblMapBtn[i].BackColor = Color.Lime;
                mapShow[i].Visible = true;
                //tlpAgvLight.Parent = mapShow[i];
                this.CurrentMapNo = i;
                if (Common.mapInfo.ContainsKey(i))
                {
                    foreach (int item in lblMapBtn.Keys)
                    {
                        if (item != i)
                        {
                            lblMapBtn[item].BackColor = Color.Silver;
                            mapShow[item].Visible = false;
                        }
                    }
                }
            }
            catch { }
        }
        #endregion //切换电子地图按钮

        #region Agv通讯的线程操作
        private void AgvThreadStart()
        {
            Common.maiDict.Clear();
            double dAgvCount = 1;
            if (maaciList.Count > 0)
                dAgvCount = maaciList.Count;
            double interval = 15 / ((double)dAgvCount);
            double addIn = WaitForm.pValue;
            for (int i = 0; i < maaciList.Count; i++)
            {
                //if (maaciList[i].A_Id != 2)
                //    maaciList[i].A_IsUsing = false;
                BA_AgvCommunicationThread bacommt = new BA_AgvCommunicationThread(maaciList[i], maaciList[i].A_IsUsing);
                BA_AgvCommunicationThread.AgvCommuDt[maaciList[i].A_Id] = bacommt;
                Thread thr = new Thread(bacommt.ReadAgvData);
                thr.Name = "thr" + maaciList[i].A_Id.ToString();
                thr.IsBackground = true;
                thr.Start();
                threadLs.Add(thr);
                Common.maiDict[maaciList[i].A_Id] = new M_AgvInfo();
                if (Common.bufferShowRfidDt.ContainsKey(maaciList[i].A_Id)) Common.maiDict[maaciList[i].A_Id].ShowRfid = Common.bufferShowRfidDt[maaciList[i].A_Id];
                Common.maiDict[maaciList[i].A_Id].AgvNo = maaciList[i].A_Id;
                Common.maiDict[maaciList[i].A_Id].Type = (Enumerations.agvType)maaciList[i].A_AgvCommonType;
                Common.objLock[maaciList[i].A_Id] = new object();
                this._agvInfo[maaciList[i].A_Id] = new M_AgvInfo();
                this._agvModelLayout[maaciList[i].A_Id] = 0;
                addIn += interval;
                WaitForm.pValue = (int)addIn;
                WaitFormService.SetContents(string.Format("获取[Agv{0}]参数...", maaciList[i].A_Id));
            }

        }
        //关闭所有Agv通讯线程，并根据新的Agv配置生成新的线程
        private void AgvThreadRestStart()
        {
            foreach (Thread item in threadLs)
            {
                try
                {
                    Common.isLoop = false;
                    item.Abort();
                }
                catch
                { }
            }
            threadLs.Clear();
            Thread.Sleep(400);
            AgvThreadStart();
        }
        #endregion //Agv通讯的线程操作

        #region 用户添加
        private void mnuLoginAdd_Click(object sender, EventArgs e)
        {
            AddUserForm adf = new AddUserForm();
            try
            {
                if (LoginRoler.U_Level >= 4)
                    adf.ShowDialog();
            }
            finally
            {
                adf.Dispose();
            }
        }

        private void mnuLgoinUser_Click(object sender, EventArgs e)
        {
            if (LoginRoler.U_Id == -1)
            {
                LoginForm lf = new LoginForm();
                try
                {
                    lf.ShowDialog();
                }
                finally
                {
                    lf.Dispose();
                }
            }
            else
            {
                MessageBox.Show("User logged in!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void mnuLoginChangePassword_Click(object sender, EventArgs e)
        {
            PasswordForm pf = new PasswordForm();
            try
            {
                if (LoginRoler.U_Name != Common.dynName)//非动态登录用户
                    pf.ShowDialog();
            }
            finally
            {
                pf.Dispose();
            }
        }
        #endregion //创建新窗体

        #region 定时器
        private void tmrAgvInfo_Tick(object sender, EventArgs e)
        {
            try
            {
                #region 所有代码
                //在晚上12点时，将会自动退出登录
                string s = DateTime.Now.ToString("hhmmss");
                if (s == "000000" || s == "000001" || s == "000002")
                {
                    LoginRoler.U_Id = -1;
                    LoginRoler.U_Level = 0;
                    LoginRoler.U_Name = "";
                    LoginRoler.U_Password = "";
                    //Common.Instance.isReceiveMesTask = false;//退出登录,mes通讯断开
                }

                mnuSetReceiveMesTask.Checked = Common.Instance.isReceiveOpcTask;
                try
                {
                    txtTestTaskCurrentIndex.Text = Common.taskTest.ProcessIndex.ToString();
                }
                catch { }
                //if (IsRefAgvState)
                //{
                lock (Common.maiDict)
                {
                    foreach (int item in Common.maiDict.Keys)
                    {
                        bool isUsing = false;
                        foreach (MA_AgvComInfo _mai in maaciList)
                        {
                            if (_mai.A_Id == item)
                            {
                                isUsing = _mai.A_IsUsing;
                                break;
                            }
                        }
                        if (isUsing)
                        {
                            //状态灯，状态信息显示
                            if (Common.maiDict[item].State == (int)Enumerations.AgvStatus.disConnection || Common.maiDict[item].State == (int)Enumerations.AgvStatus.init)
                            {
                                Common.maiDict[item].StateMessage = "lineoff";
                                Common.maiDict[item].AbnormalMessage = "lineoff";
                                this.showInfo[item][Enumerations.LabelType.AgvStatusLight].Label1Image = Properties.Resources.line;
                                this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1Text = "lineoff";
                                this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1BackColor = Color.Silver;
                                this.agvModel[item].BackColor = Color.Silver;
                                this.agvModel[item].SendToBack();
                                bool isWrite = false;
                                if (isDisConn.ContainsKey(item) == false)
                                {
                                    isWrite = true;
                                }
                                else
                                {
                                    if (isDisConn[item] == false)
                                    {
                                        isWrite = true;
                                    }
                                }
                                if (isWrite)
                                {
                                    BA_AgvErrorInfo agvErrorInfo = new BA_AgvErrorInfo();
                                    MA_AgvError agvError = new MA_AgvError(0, item, "lineoff", -1, string.Format("{0}.{1}V", Common.maiDict[item].Voltage / 10, Common.maiDict[item].Voltage % 10), Common.maiDict[item].Rfid, Common.maiDict[item].Task1, DateTime.Now);
                                    if (agvErrorInfo.InsertAgvErrorInfo(agvError) > 0)
                                    {
                                        isDisConn[item] = true;
                                    }
                                }
                            }
                            else if (Common.maiDict[item].State == (int)Enumerations.AgvStatus.running)
                            {
                                isDisConn[item] = false;
                                Common.maiDict[item].StateMessage = "running";
                                if (Common.maiDict[item].Obstacle)
                                {
                                    this.showInfo[item][Enumerations.LabelType.AgvStatusLight].Label1Image = Properties.Resources.barrier;
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1Text = "obstacles";
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1BackColor = Color.Yellow;
                                    this.agvModel[item].BackColor = Color.Yellow;
                                    Common.maiDict[item].AbnormalMessage = "obstacles";
                                }
                                else
                                {
                                    this.showInfo[item][Enumerations.LabelType.AgvStatusLight].Label1Image = Properties.Resources.ok;
                                    string status = "running";
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1Text = status;
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1BackColor = Color.Lime;
                                    this.agvModel[item].BackColor = Color.Lime;
                                    Common.maiDict[item].AbnormalMessage = string.Empty;
                                }
                                if (Common.maiDict[item].ControlFlag)
                                {
                                    this.showInfo[item][Enumerations.LabelType.AgvStatusLight].Label1Image = Properties.Resources.barrier;
                                    string status = "locking";
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1Text = status;
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1BackColor = Color.Yellow;
                                    this.agvModel[item].BackColor = Color.Yellow;
                                    Common.maiDict[item].AbnormalMessage = string.Empty;
                                }
                            }
                            else if (Common.maiDict[item].State == (int)Enumerations.AgvStatus.fixPosition)
                            {
                                if (Common.maiDict[item].Obstacle)
                                {
                                    Common.maiDict[item].AbnormalMessage = "obstacles";
                                    //this.showInfo[item][Enumerations.LabelType.AgvStatusLight].Image = Properties.Resources.barrier;
                                    //this.showInfo[item][Enumerations.LabelType.AgvStatus].Text = "障碍物异常";
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1BackColor = Color.Yellow;
                                    this.agvModel[item].BackColor = Color.Yellow;
                                }
                                else
                                {
                                    isDisConn[item] = false;
                                    this.showInfo[item][Enumerations.LabelType.AgvStatusLight].Label1Image = Properties.Resources.lineok;
                                    string status = "positioning";
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1Text = status;
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1BackColor = Color.SkyBlue;
                                    this.agvModel[item].BackColor = Color.CornflowerBlue;
                                    Common.maiDict[item].StateMessage = "positioning";
                                    Common.maiDict[item].AbnormalMessage = string.Empty;
                                }
                            }
                            else if (Common.maiDict[item].State == (int)Enumerations.AgvStatus.stop)
                            {
                                if (Common.maiDict[item].Obstacle)
                                {
                                    Common.maiDict[item].AbnormalMessage = "obstacles";
                                    //this.showInfo[item][Enumerations.LabelType.AgvStatusLight].Image = Properties.Resources.barrier;
                                    //this.showInfo[item][Enumerations.LabelType.AgvStatus].Text = "障碍物异常";
                                    //this.showInfo[item][Enumerations.LabelType.AgvStatus].BackColor = Color.Yellow;
                                    //this.agvModel[item].BackColor = Color.Yellow;
                                }
                                else if (Common.maiDict[item].ControlFlag)
                                {
                                    Common.maiDict[item].AbnormalMessage = "locking";
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1Text = Common.maiDict[item].AbnormalMessage;
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1BackColor = Color.SkyBlue;
                                    this.agvModel[item].BackColor = Color.CornflowerBlue;
                                }
                                else if (Common.maiDict[item].Retention != string.Empty)
                                {
                                    this.agvModel[item].BackColor = Color.HotPink;
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1BackColor = Color.HotPink;
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1Text = Common.maiDict[item].Retention;
                                }
                                else if (Common.maiDict[item].chargeAbnormal)
                                {
                                    if (Common.maiDict[item].ChargeAbnormalString == string.Empty)
                                    {
                                        Common.maiDict[item].ChargeAbnormalString = "ChargeAnomaly";
                                        BA_AgvErrorInfo agvErrorInfo = new BA_AgvErrorInfo();
                                        MA_AgvError agvError = new MA_AgvError(0, item, "ChargeAnomaly", 100, string.Format("{0}.{1}V", Common.maiDict[item].Voltage / 10, Common.maiDict[item].Voltage % 10), Common.maiDict[item].Rfid, Common.maiDict[item].Task1, DateTime.Now);
                                        agvErrorInfo.InsertAgvErrorInfo(agvError);

                                    }
                                    this.agvModel[item].BackColor = Color.HotPink;
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1BackColor = Color.HotPink;
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1Text = Common.maiDict[item].ChargeAbnormalString;
                                    if (Common.maiDict[item].ChargeStation1Error || Common.maiDict[item].ChargeStation2Error)
                                    {
                                        if (isChargeStationError.ContainsKey(item) == false)
                                        {
                                            isChargeStationError[item] = false;
                                        }
                                        if (isChargeStationError[item] == false)
                                        {
                                            string sChargeStationError = "ChargeStation2Error";
                                            if (Common.maiDict[item].ChargeStation1Error)
                                            {
                                                sChargeStationError = "ChargeStation1Error";
                                            }
                                            BA_AgvErrorInfo agvErrorInfo = new BA_AgvErrorInfo();
                                            MA_AgvError agvError = new MA_AgvError(0, item, sChargeStationError, 100, string.Format("{0}.{1}V", Common.maiDict[item].Voltage / 10, Common.maiDict[item].Voltage % 10), Common.maiDict[item].Rfid, Common.maiDict[item].Task1, DateTime.Now);
                                            agvErrorInfo.InsertAgvErrorInfo(agvError);
                                            isChargeStationError[item] = true;
                                        }
                                    }
                                }
                                else if (Common.maiDict[item].RouteError)
                                {
                                    if (Common.maiDict[item].RouteErrorString == string.Empty)
                                    {
                                        Common.maiDict[item].RouteErrorString = "RouteError";
                                        BA_AgvErrorInfo agvErrorInfo = new BA_AgvErrorInfo();
                                        MA_AgvError agvError = new MA_AgvError(0, item, "RouteError", 100, string.Format("{0}.{1}V", Common.maiDict[item].Voltage / 10, Common.maiDict[item].Voltage % 10), Common.maiDict[item].Rfid, Common.maiDict[item].Task1, DateTime.Now);
                                        agvErrorInfo.InsertAgvErrorInfo(agvError);

                                    }
                                    this.agvModel[item].BackColor = Color.HotPink;
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1BackColor = Color.HotPink;
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1Text = Common.maiDict[item].RouteErrorString;
                                }
                                else
                                {
                                    isChargeStationError[item] = false;
                                    isDisConn[item] = false;
                                    this.showInfo[item][Enumerations.LabelType.AgvStatusLight].Label1Image = Properties.Resources.lineok;
                                    //if (Common.maiDict[item].StationStopState)
                                    //{
                                    //    this.showInfo[item][Enumerations.LabelType.AgvStatus].Text = "工位禁止";
                                    //}
                                    //else
                                    //{
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1Text = "Stop";
                                    //}
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1BackColor = Color.SkyBlue;
                                    this.agvModel[item].BackColor = Color.CornflowerBlue;
                                    Common.maiDict[item].StateMessage = "Stop";
                                    Common.maiDict[item].AbnormalMessage = string.Empty;
                                }
                                if (Common.maiDict[item].VoltageStatus == Enumerations.voltageStatus.chargVoltage || Common.maiDict[item].VoltageStatus == Enumerations.voltageStatus.lowVoltage)
                                {
                                    this.agvModel[item].BackColor = Color.Aqua;
                                }
                            }
                            else if (Common.maiDict[item].State == (int)Enumerations.AgvStatus.abnormal)
                            {
                                isDisConn[item] = false;
                                //if (Common.maiDict[item].Abnormal != 3)
                                //{
                                Common.maiDict[item].StateMessage = "Abnormal";
                                if (Common.Instance.dtAgvAbnormal.ContainsKey(Common.maiDict[item].Abnormal))
                                {
                                    Common.maiDict[item].AbnormalMessage = Common.Instance.dtAgvAbnormal[Common.maiDict[item].Abnormal];
                                    this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1Text = Common.Instance.dtAgvAbnormal[Common.maiDict[item].Abnormal];
                                }
                                this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1BackColor = Color.Red;
                                this.showInfo[item][Enumerations.LabelType.AgvStatusLight].Label1Image = Properties.Resources.err;
                                this.agvModel[item].BackColor = Color.DarkRed;
                                bool isWrite = false;
                                if (!isAbnormalWrite.ContainsKey(item))
                                {
                                    isWrite = true;
                                }
                                else
                                {
                                    if (isAbnormalWrite[item] != Common.maiDict[item].Abnormal)
                                    {
                                        isWrite = true;
                                    }
                                }
                                if (isWrite)
                                {
                                    if (Common.Instance.dtAgvAbnormal.ContainsKey(Common.maiDict[item].Abnormal))
                                    {
                                        try
                                        {
                                            BA_AgvErrorInfo agvErrorInfo = new BA_AgvErrorInfo();
                                            MA_AgvError agvError = new MA_AgvError(0, item, Common.Instance.dtAgvAbnormal[Common.maiDict[item].Abnormal], Common.maiDict[item].Abnormal, string.Format("{0}.{1}V", Common.maiDict[item].Voltage / 10, Common.maiDict[item].Voltage % 10), Common.maiDict[item].Rfid, Common.maiDict[item].Task1, DateTime.Now);
                                            if (agvErrorInfo.InsertAgvErrorInfo(agvError) > 0)
                                            {
                                                isAbnormalWrite[item] = Common.maiDict[item].Abnormal;
                                            }
                                        }
                                        catch { }
                                    }
                                }
                                //}
                                //else
                                //{
                                //    this.showInfo[item]["AgvStu"].Image = Properties.Resources.barrier;
                                //    this.showInfo[item]["AgvAbn"].Text = Common.Instance.dtAgvAbnormal[Common.maiDict[item].Abnormal];
                                //    this.showInfo[item]["AgvAbn"].BackColor = Color.Yellow;
                                //    this.agvModel[item].BackColor = Color.Yellow;
                                //}
                            }
                            //Rfid
                            this.showInfo[item][Enumerations.LabelType.AgvRfid].Label1Text = Common.maiDict[item].VirtualRfid.ToString(); ;   //"卡号:\r\n" + Common.maiDict[item].Rfid.ToString();
                            this.showInfo[item][Enumerations.LabelType.AgvRfid].Label2Text = Common.maiDict[item].Rfid.ToString();
                            //命令状态
                            //string operateStr = string.Empty;
                            //try
                            //{
                            //    operateStr = Common.agvOperateStatus[Common.maiDict[item].Operate];
                            //}
                            //catch { }
                            //agv类型
                            string typeString = Common.maiDict[item].Type.ToString().Replace(Enumerations.agvType.type_1.ToString(), "Type1").Replace(Enumerations.agvType.type_2.ToString(), "Type2").Replace(Enumerations.agvType.type_3.ToString(), "Type3");
                            bool isNeedInit = false;//是否需要初始化
                            try
                            {
                                if (Common.maiDict[item].Task1 == string.Empty && Common.maiDict[item].Task2 == string.Empty && Common.maiDict[item].Default7 == 0 && Common.maiDict[item].Default8 == 0 && Common.maiDict[item].State == (int)Enumerations.AgvStatus.stop)
                                {
                                    int _virtualRfid = Common.maiDict[item].VirtualRfid;
                                    if (Common.Instance.dtStationInformation.Any(o => (o.Value.StationType == (int)StationInformation.EStationType.Wait || o.Value.StationType == (int)StationInformation.EStationType.Charge) && o.Value.StationRfidLs.Contains(_virtualRfid)))
                                    {//AGV在待机点或充电点 
                                        isNeedInit = !Common.maiDict[item].IsCanReceiveTask;
                                    }
                                }
                            }
                            catch { }
                            if (isNeedInit == false)
                            {
                                this.showInfo[item][Enumerations.LabelType.AgvType].Label1Text = typeString;
                                this.showInfo[item][Enumerations.LabelType.AgvType].BackColor = Color.Silver;
                            }
                            else
                            {
                                typeString = typeString + "\r\nInit";
                                this.showInfo[item][Enumerations.LabelType.AgvType].Label1Text = typeString;
                                this.showInfo[item][Enumerations.LabelType.AgvType].BackColor = Color.Red;
                            }
                            if (Common.maiDict[item].IsAgvTest == false)
                            {
                                //当前任务
                                this.showInfo[item][Enumerations.LabelType.CurrentTask].Label1Text = "Current Task";
                                this.showInfo[item][Enumerations.LabelType.CurrentTask].Label2Text = Common.maiDict[item].Task1;
                            }
                            else
                            {
                                this.showInfo[item][Enumerations.LabelType.CurrentTask].Label1Text = "Test model";
                                this.showInfo[item][Enumerations.LabelType.CurrentTask].Label2Text = "Null";
                            }
                            //预定任务
                            this.showInfo[item][Enumerations.LabelType.BookTask].Label1Text = "Next Task";
                            this.showInfo[item][Enumerations.LabelType.BookTask].Label2Text = Common.maiDict[item].Task2;
                            string vol = string.Empty;
                            if (Common.maiDict[item].Voltage <= 0)
                            {
                                vol = "vol  :unknown";
                            }
                            else
                            {
                                vol = string.Format("vol  :{0}.{1}V {2}", Common.maiDict[item].Voltage / 10, Common.maiDict[item].Voltage % 10, Common.maiDict[item].ChargeSeconds);
                            }
                            this.showInfo[item][Enumerations.LabelType.VolAndPull].Label1Text = vol;
                            if (Common.maiDict[item].VoltageStatus == Enumerations.voltageStatus.chargVoltage)
                            {
                                this.showInfo[item][Enumerations.LabelType.VolAndPull].Label1BackColor = Color.Red;
                            }
                            else if (Common.maiDict[item].VoltageStatus == Enumerations.voltageStatus.lowVoltage)
                            {
                                this.showInfo[item][Enumerations.LabelType.VolAndPull].Label1BackColor = Color.Yellow;
                            }
                            else
                            {
                                this.showInfo[item][Enumerations.LabelType.VolAndPull].Label1BackColor = Color.Gainsboro;
                            }
                            string speedString = string.Format("speed:{0}m/min", Common.maiDict[item].Speed / 10);
                            //速度                      
                            this.showInfo[item][Enumerations.LabelType.VolAndPull].Label2Text = speedString;
                            //if (Common.maiDict[item].VoltageStatus == Enumerations.voltageStatus.lowVoltage && Common.maiDict[item].Default5 == 0)
                            //{
                            //    this.showInfo[item][Enumerations.LabelType.VolAndPull].Image = Properties.Resources.low;
                            //}
                            //else if (Common.maiDict[item].VoltageStatus == Enumerations.voltageStatus.normal && Common.maiDict[item].Default5 == 1)
                            //{
                            //    this.showInfo[item][Enumerations.LabelType.VolAndPull].Image = Properties.Resources.Up;
                            //}
                            //else if (Common.maiDict[item].VoltageStatus == Enumerations.voltageStatus.lowVoltage && Common.maiDict[item].Default5 == 1)
                            //{
                            //    this.showInfo[item][Enumerations.LabelType.VolAndPull].Image = Properties.Resources.UpAndLow;
                            //}
                            //else
                            //{
                            //    this.showInfo[item][Enumerations.LabelType.VolAndPull].Image = Properties.Resources.split;
                            //}
                            //上下料点
                            this.showInfo[item][Enumerations.LabelType.Station].Label1Text = string.Format("Load  :{0}", Common.maiDict[item].Default7);
                            this.showInfo[item][Enumerations.LabelType.Station].Label2Text = string.Format("Unload:{0}", Common.maiDict[item].Default8);
                            if (Common.maiDict[item].QuestPass)
                            {
                                this.showInfo[item][Enumerations.LabelType.Station].Label2BackColor = Color.Lime;
                            }
                            else
                            {
                                this.showInfo[item][Enumerations.LabelType.Station].Label2BackColor = Color.White;
                            }
                            //AGV方向  空闲状态
                            string agvDirStr = string.Empty;
                            if (Common.maiDict[item].Direction == 1)
                            {
                                agvDirStr = "forward ";
                            }
                            else if (Common.maiDict[item].Direction == 2)
                            {
                                agvDirStr = "backward";
                            }
                            else if (Common.maiDict[item].Direction == 3)
                            {
                                agvDirStr = "left";
                            }
                            else if (Common.maiDict[item].Direction == 4)
                            {
                                agvDirStr = "right";
                            }
                            else
                            {
                                agvDirStr = "unknown";
                            }

                            this.showInfo[item][Enumerations.LabelType.DirAndBusy].Label1Text = agvDirStr;
                            this.showInfo[item][Enumerations.LabelType.DirAndBusy].Label2Text = Common.maiDict[item].DragState == 0 ? "Decline" : "LiftUp";
                            Common.maiDict[item].StatusInfo = this.showInfo[item][Enumerations.LabelType.AgvStatus].Label1Text;
                        }
                    }
                }
                //} 
                #endregion
            }
            catch (Exception ex)
            { }
        }

        private void tmrRef_Tick(object sender, EventArgs e)
        {
            #region 系统工作模式
            if (Common.Instance.isReceiveOpcTask)
            {
                mnuWorkMode.Text = "Work|Rest";
                mnuWorkMode.BackColor = Color.Lime;
            }
            else
            {
                mnuWorkMode.Text = "Rest|Work";
                mnuWorkMode.BackColor = Color.Red;
            }
            #endregion
            //textBox1.Text = Common.testData;
            #region 刷新当前尚未完成任务
            if (Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_1].TaskRefreshEnable)
            {
                if (DateTime.Now.Subtract(Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_1].TaskRefreshLastTime).TotalSeconds > Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_1].TaskRefreshTime)
                {

                    Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_1].TaskRefreshLastTime = DateTime.Now;
                    RefCapTestCurrentTask();
                }
            }
            if (Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_2].TaskRefreshEnable)
            {
                if (DateTime.Now.Subtract(Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_2].TaskRefreshLastTime).TotalSeconds > Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_2].TaskRefreshTime)
                {
                    Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_2].TaskRefreshLastTime = DateTime.Now;
                    RefPreAgingCurrentTask();
                }
            }
            if (Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_3].TaskRefreshEnable)
            {
                if (DateTime.Now.Subtract(Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_3].TaskRefreshLastTime).TotalSeconds > Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_3].TaskRefreshTime)
                {
                    Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_3].TaskRefreshLastTime = DateTime.Now;
                    RefCapAgingCurrentTask();
                }
            }
            #endregion

            #region 房门状态
            UpdateDoorState();
            #endregion

            #region 充电桩状态
            UpdateChargeState();
            #endregion
            #region 电梯状态
            UpdateElevatorState();
            #endregion

            #region 更新StatusStrip
            //待机充电位状态
            List<Enumerations.OtherStation> lsOthers = Common.Instance.dtOtherStations.Keys.ToList();
            foreach (Enumerations.OtherStation item in lsOthers)
            {
                try
                {
                    string name = this.dtOtherStationStu[item].Tag.ToString();
                    if (Common.Instance.dtOtherStations[item].Status <= 0)
                    {
                        this.dtOtherStationStu[item].Text = string.Format("{0}  None  ", name);
                        this.dtOtherStationStu[item].BackColor = Color.Lime;
                    }
                    else if (Common.Instance.dtOtherStations[item].Status > 0 && Common.Instance.dtOtherStations[item].Status <= 100)
                    {
                        this.dtOtherStationStu[item].Text = string.Format("{0}Bind Agv{1}", name, Common.Instance.dtOtherStations[item].Status);
                        this.dtOtherStationStu[item].BackColor = Color.Red;
                    }
                    else if (Common.Instance.dtOtherStations[item].Status > 100)
                    {
                        this.dtOtherStationStu[item].Text = string.Format("{0}Book Agv{1}", name, Common.Instance.dtOtherStations[item].Status - 100);
                        this.dtOtherStationStu[item].BackColor = Color.Yellow;
                    }
                }
                catch { }
            }
            if (LoginRoler.U_Id == -1)
            {
                stuLblUser.Text = LoginRoler.CurrentUser + "None";
            }
            else
            {
                stuLblUser.Text = LoginRoler.CurrentUser + LoginRoler.U_Name;
            }
            //数据库连接状态
            stuLabelSql.Text = OPCClient.opcInformation.ConnectContents;
            if (OPCClient.opcInformation.ConnectState)
            {
                stuLabelSql.BackColor = Color.Lime;
                if (OPCClient.opcInformation.ConnectContents != "OPC Running")
                {
                    stuLabelSql.BackColor = Color.Yellow;
                }
            }
            else
            {
                stuLabelSql.BackColor = Color.Red;
            }
            #endregion //更新StatusStrip

            #region TabControl选卡显示
            if (mnuInitSetTabMap.Checked)
            {
                tabpMap.Parent = tabMain;
            }
            else
            {
                tabpMap.Parent = null;
            }
            if (mnuInitSetTabQueryAbnormal.Checked)
            {
                tabpQueryAbnormal.Parent = tabMain;
            }
            else
            {
                tabpQueryAbnormal.Parent = null;
            }
            if (mnuInitSetTabQueryTask.Checked)
            {
                tabpTask.Parent = tabMain;
            }
            else
            {
                tabpTask.Parent = null;
            }
            if (mnuInitSetTabConfig.Checked)
            {
                if (LoginRoler.U_Level >= 3)
                {
                    tabpConfig.Parent = tabMain;
                }
                else
                {
                    tabpConfig.Parent = null;
                }
            }
            else
            {
                tabpConfig.Parent = null;
            }
            #endregion //TabControl选卡显示

            #region 修改密码菜单显示
            if (LoginRoler.U_Level < 1)
            {
                mnuLoginChangePassword.Visible = false;
            }
            else
            {
                mnuLoginChangePassword.Visible = true;
            }
            #endregion //修改密码菜单显示

            #region 添加用户菜单显示
            if (LoginRoler.U_Level < 2)
            {
                mnuLoginAdd.Visible = false;
                mnuSet.Visible = false;
            }
            else
            {
                mnuLoginAdd.Visible = true;
                mnuSet.Visible = true;
            }
            #endregion //添加用户菜单显示

            #region 初始化设定菜单显示
            if (LoginRoler.U_Level >= 3)
            {
                mnuInitSet.Visible = true;
            }
            else
            {
                mnuInitSet.Visible = false;
            }
            if (LoginRoler.U_Level >= 4)
                mnuInitSetIsDynPwd.Visible = true;
            #endregion //初始化设定菜单显示

            #region 站点状态更新
            RefreshStationStatus();
            #endregion

            #region 状态数量更新
            try
            {
                int stopCount = Common.maiDict.Count(o => o.Value.State == (int)Enumerations.AgvStatus.stop && o.Value.Type == Enumerations.agvType.type_1);
                int runCount = Common.maiDict.Count(o => o.Value.State == (int)Enumerations.AgvStatus.running && o.Value.Type == Enumerations.agvType.type_1);
                int errCount = Common.maiDict.Count(o => o.Value.State == (int)Enumerations.AgvStatus.abnormal && o.Value.Type == Enumerations.agvType.type_1);
                int lowVoltageCount = Common.maiDict.Count(o => o.Value.VoltageStatus != Enumerations.voltageStatus.normal && o.Value.State != (int)Enumerations.AgvStatus.disConnection && o.Value.Type == Enumerations.agvType.type_1);
                int lineCount = Common.maiDict.Count(o => o.Value.State == (int)Enumerations.AgvStatus.disConnection && o.Value.Type == Enumerations.agvType.type_1);
                int obstacleCount = Common.maiDict.Count(o => (o.Value.Obstacle || o.Value.ControlFlag) && o.Value.Type == Enumerations.agvType.type_1);
                tsslAgvRun.Text = string.Format("运行(绿色)[{0}]", runCount);
                tsslAgvStop.Text = string.Format("停止(蓝色) [{0}]", stopCount);
                tsslAgvError.Text = string.Format("异常(红色) [{0}]", errCount);
                tsslAgvLine.Text = string.Format("掉线(灰色) [{0}]", lineCount);
                tsslAgvLowVoltage.Text = string.Format("低电压(浅蓝色) [{0}]", lowVoltageCount);
                tsslAgvObstacle.Text = string.Format("障碍/管制(黄色) [{0}]", obstacleCount);
            }
            catch { }
            #endregion
        }
        //电子地图自动切换
        private void tmrMapChange_Tick(object sender, EventArgs e)
        {
            try
            {
                if (this.isRfidSet == false && Common.isMapChange)
                {
                    int mapNo = -1;
                    try
                    {
                        mapNo = lblMapBtn.First(o => o.Key > this.CurrentMapNo).Key;
                    }
                    catch
                    {
                        mapNo = 0;
                    }
                    if (mapNo >= 0)
                    {
                        lbl_Click(this.lblMapBtn[mapNo], e);
                    }
                }
            }
            catch { }
        }
        //Agv编号提示框
        private void tmrTip_Tick(object sender, EventArgs e)
        {
            //ReadElevatorData.readElevatorData.CallElevator(2);

            try
            {
                if (this.isRfidSet)
                {
                    tmrMapChange.Stop();
                }
                else
                {
                    tmrMapChange.Start();
                }
            }
            catch { }

            try
            {
                if (LoginRoler.U_Level > 1 && mnuInitSetAdminRfidSet.Checked)
                {
                    if (!Common.isRfidVisible)
                    {
                        IsRfidVisible(true);
                    }
                }
                else
                {
                    if (Common.isRfidVisible)
                    {
                        IsRfidVisible(false);
                    }
                }
                //if (this._agvNoTip == this._agvNoList.Count)
                //{
                //    this._agvNoTip = 0;
                //}
                //Point p = agvModel[this._agvNoList[this._agvNoTip]].Location;
                //lblTip.Location = new Point(p.X + this.agvModel[this._agvNoList[this._agvNoTip]].Width, p.Y - lblTip.Height);
                //lblTip.Text = this._agvNoList[this._agvNoTip].ToString();
                //this._agvNoTip += 1;
            }
            catch (Exception ex)
            {

            }
        }
        //更新地图界面
        private void tmrMapRef_Tick(object sender, EventArgs e)
        {
            #region 刷新管制信息
            if (cbhAutoRefControlsState.Checked)
            {
                RefControlState();
            }
            #endregion
            ////测试
            //try
            //{
            //    List<int> lsControls = Common.controlPointsStatus.Keys.ToList().OrderBy(o => o).ToList();
            //    string statusC = string.Empty;
            //    foreach (int item in lsControls)
            //    {
            //        string agvs = string.Empty;
            //        try
            //        {
            //            agvs = string.Join(",", Common.controlPointsStatus[item]);
            //        }
            //        catch { }
            //        statusC += string.Format("{0}:{1}\r\n", item, agvs);
            //    }
            //    txtTest.Text = statusC;
            //}
            //catch
            //{ }        
            #region 站点允许状态更新

            #endregion
            #region 状态栏更新
            //进度条滚动
            if (isDataEnd)
            {
                stuProDataToSql.Visible = true;
                stuLabelDataToSql.Visible = true;
            }
            else
            {
                stuProDataToSql.Visible = false;
                stuLabelDataToSql.Visible = false;
            }
            if (stuProDataToSql.Value >= 100)
            {
                stuProDataToSql.Value = 0;
            }
            stuProDataToSql.PerformStep();
            //if (Common.Instance.elevatorInfo.OpenStatus[1])
            //{
            //    stuLabelElevatorStatus.Text = "电梯1楼门开";
            //    stuLabelElevatorStatus.BackColor = Color.Lime;
            //}
            //else if (Common.Instance.elevatorInfo.OpenStatus[2])
            //{
            //    stuLabelElevatorStatus.Text = "电梯2楼门开";
            //    stuLabelElevatorStatus.BackColor = Color.Lime;
            //}
            //else
            //{ }
            #region 电梯状态 已弃用
            //switch (Common.Instance.elevatorInfo.status)
            //{
            //    case Enumerations.EleVatorStatus.init:
            //        if (Common.Instance.elevatorInfo.BindAgv > 0)
            //        {
            //            stuLabelElevatorStatus.Text = string.Format("电梯:Agv{0}", Common.Instance.elevatorInfo.BindAgv);
            //            stuLabelElevatorStatus.BackColor = Color.Silver;
            //        }
            //        else
            //        {
            //            stuLabelElevatorStatus.Text = "电梯状态未知";
            //            stuLabelElevatorStatus.BackColor = Color.Silver;
            //        }
            //        break;
            //    case Enumerations.EleVatorStatus.elevatorBeginOpen:
            //        if (Common.Instance.elevatorInfo.BeginFloor == 1)
            //        {
            //            stuLabelElevatorStatus.Text = "电梯1楼门开";
            //            stuLabelElevatorStatus.BackColor = Color.Lime;
            //        }
            //        else
            //        {
            //            stuLabelElevatorStatus.Text = "电梯2楼门开";
            //            stuLabelElevatorStatus.BackColor = Color.Lime;
            //        }
            //        break;
            //    case Enumerations.EleVatorStatus.elevatorEndOpen:
            //        if (Common.Instance.elevatorInfo.EndFloor == 1)
            //        {
            //            stuLabelElevatorStatus.Text = "电梯1楼门开";
            //            stuLabelElevatorStatus.BackColor = Color.Lime;
            //        }
            //        else
            //        {
            //            stuLabelElevatorStatus.Text = "电梯2楼门开";
            //            stuLabelElevatorStatus.BackColor = Color.Lime;
            //        }
            //        break;
            //    case Enumerations.EleVatorStatus.agvInFinish:
            //        stuLabelElevatorStatus.Text = string.Format("电梯:Agv{0}", Common.Instance.elevatorInfo.BindAgv);
            //        stuLabelElevatorStatus.BackColor = Color.Lime;
            //        break;
            //    case Enumerations.EleVatorStatus.agvOutFinish:
            //        break;
            //}
            //if (Common.Instance.elevatorInfo.OpenStatus[1])
            //{
            //    stuLabelElevatorStatus.Text = "电梯1楼门开";
            //    stuLabelElevatorStatus.BackColor = Color.Lime;
            //}
            //else if (Common.Instance.elevatorInfo.OpenStatus[2])
            //{
            //    stuLabelElevatorStatus.Text = "电梯2楼门开";
            //    stuLabelElevatorStatus.BackColor = Color.Lime;
            //} 
            #endregion
            #endregion

            //更新记录Agv的各种状态
            BA_AgvErrorInfo baei = new BA_AgvErrorInfo();
            string _task1 = "";
            lock (Common.maiDict)
            {
                foreach (int item in Common.maiDict.Keys)
                {
                    _task1 += _agvInfo[item].Task1.ToString() + " ";
                    string lineName = "";
                    if (Common.lineNameDt.ContainsKey(_agvInfo[item].Task2.ToString()))
                    {
                        lineName = Common.lineNameDt[_agvInfo[item].Task2.ToString()];
                    }
                    else
                    {
                        lineName = "unknown";
                    }
                    //判断是否对定位时间进行记录
                    if (Common.maiDict[item].State == (int)Enumerations.AgvStatus.disConnection)
                    {
                        if (isDisConn.ContainsKey(item) == false)
                        {
                            isDisConn[item] = false;
                        }
                        if (!isDisConn[item])
                        {
                            MA_AgvError mae = new MA_AgvError(0, item, "lineoff", 0, string.Format("{0}.{1}V", Common.maiDict[item].Voltage / 10, Common.maiDict[item].Voltage % 10), Common.maiDict[item].Rfid, Common.maiDict[item].Task1, DateTime.Now);   //添加最新异常信息
                            baei.InsertAgvErrorInfo(mae);   //添加至数据库
                            isDisConn[item] = true;
                        }
                    }
                    else
                    {
                        if (Common.maiDict[item].isOnline)
                        {
                            MA_AgvError mae = new MA_AgvError(0, item, "online", 0, string.Format("{0}.{1}V", Common.maiDict[item].Voltage / 10, Common.maiDict[item].Voltage % 10), Common.maiDict[item].Rfid, Common.maiDict[item].Task1, DateTime.Now);   //添加最新异常信息
                            baei.InsertAgvErrorInfo(mae);   //添加至数据库
                            Common.maiDict[item].isOnline = false;
                        }
                    }
                    _agvInfo[item].Rfid = Common.maiDict[item].Rfid;
                    _agvInfo[item].Task1 = Common.maiDict[item].Task1;
                    _agvInfo[item].Abnormal = Common.maiDict[item].Abnormal;
                    _agvInfo[item].Task2 = Common.maiDict[item].Task2;

                    //更新AgvModel的位置
                    try
                    {
                        Point point = new Point();
                        int mapNo = -1;
                        if (Common.rfidDt.ContainsKey(Common.maiDict[item].ShowRfid))
                        {
                            MA_RfidPoint mp = Common.rfidDt[Common.maiDict[item].ShowRfid];//AGV当前位置
                            Image _image = agvModel[item].BackgroundImage;
                            if (mp.RfidLayout == "水平")
                            {
                                if (this._agvModelLayout[item] != 0)
                                {
                                    _image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    agvModel[item].BackgroundImage = _image;
                                    //agvModel[item].Size = new Size(Convert.ToInt32(_image.Width * Common.sizeMapImage.widthScale), Convert.ToInt32(_image.Height * Common.sizeMapImage.heightScale));
                                    //agvModel[item].Size = new Size(Convert.ToInt32(_image.Width * this.mapScare), Convert.ToInt32(_image.Height * this.mapScare));
                                    this._agvModelLayout[item] = 0;
                                }
                            }
                            else if (mp.RfidLayout == "垂直")
                            {
                                if (this._agvModelLayout[item] != 1)
                                {
                                    //Image _image = agvModel[item].BackgroundImage;
                                    _image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                                    agvModel[item].BackgroundImage = _image;
                                    //agvModel[item].Size = new Size(Convert.ToInt32(_image.Width * Common.sizeMapImage.widthScale), Convert.ToInt32(_image.Height * Common.sizeMapImage.heightScale));
                                    //agvModel[item].Size = new Size(Convert.ToInt32(_image.Width * this.mapScare), Convert.ToInt32(_image.Height * this.mapScare));
                                    this._agvModelLayout[item] = 1;
                                }
                            }
                            agvModel[item].Size = new Size(Convert.ToInt32(_image.Width * this.mapScare * Common.agvModelScale), Convert.ToInt32(_image.Height * this.mapScare * Common.agvModelScale));
                            agvModel[item].Parent = mapShow[mp.MapNo];
                            point = new Point(mp.RfidX, mp.RfidY);
                            mapNo = mp.MapNo;
                            //}
                        }
                        if (point.X != 0 && point.Y != 0)
                        {

                            agvModel[item].Location = new Point(Convert.ToInt32(point.X * Common.sizeMapImage[mapNo].widthScale) - agvModel[item].Width / 2, Convert.ToInt32(point.Y * Common.sizeMapImage[mapNo].heightScale) - agvModel[item].Height / 2);
                        }
                    }
                    catch (Exception exagvModel)
                    { }
                }
            }
        }
        #endregion //定时器

        #region 退出登录
        private void mnuLoginEsc_Click(object sender, EventArgs e)
        {
            LoginRoler.U_Id = -1;
            LoginRoler.U_Level = 0;
            LoginRoler.U_Name = "";
            LoginRoler.U_Password = "";
            //Common.Instance.isReceiveMesTask = false;//退出登录,mes通讯断开
        }
        #endregion //退出登录

        #region 选卡是否显示记录
        private void mnuInitSetTabMap_Click(object sender, EventArgs e)
        {
            BT_TabCheckInfo bti = new BT_TabCheckInfo();
            if (mnuInitSetTabMap.Checked)
            {
                bti.UpdateChecked("监控地图", 1);
            }
            else
            {
                bti.UpdateChecked("监控地图", 0);
            }
        }

        private void mnuInitSetTabQueryTask_Click(object sender, EventArgs e)
        {
            BT_TabCheckInfo bti = new BT_TabCheckInfo();
            if (mnuInitSetTabQueryTask.Checked)
            {
                bti.UpdateChecked("任务记录查询", 1);
            }
            else
            {
                bti.UpdateChecked("任务记录查询", 0);
            }
        }
        private void mnuInitSetTabQuery_Click(object sender, EventArgs e)
        {
            BT_TabCheckInfo bti = new BT_TabCheckInfo();
            if (mnuInitSetTabQueryAbnormal.Checked)
            {
                bti.UpdateChecked("异常记录查询", 1);
            }
            else
            {
                bti.UpdateChecked("异常记录查询", 0);
            }
        }
        private void mnuInitSetTabConfig_Click(object sender, EventArgs e)
        {
            BT_TabCheckInfo bti = new BT_TabCheckInfo();
            if (mnuInitSetTabConfig.Checked)
            {
                bti.UpdateChecked("配置", 1);
            }
            else
            {
                bti.UpdateChecked("配置", 0);
            }
        }
        #endregion //选卡是否显示记录

        #region Agv配置
        private void btnAgvInfoAdd_Click(object sender, EventArgs e)
        {
            BA_AgvComInfo baci = new BA_AgvComInfo();
            string strIP = mtxtIp.Text.Replace(" ", "");
            try
            {
                IPAddress ip = IPAddress.Parse(strIP);
                if (txtAgvInfoId.Text == "")
                {
                    MessageBox.Show("Agv Id cannot be null.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (txtAgvInfoDescription.Text == "")
                {
                    MessageBox.Show("Describe canot be null.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (txtAgvInfoNetNo.Text == "")
                {
                    MessageBox.Show("Network node cannot be null.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (txtAgvInfoLocalPort.Text == "")
                {
                    MessageBox.Show("Local port cannot be null.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else if (txtAgvInfoDesPort.Text == "")
                {
                    MessageBox.Show("Destination port cannot be null.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    int A_Id = Convert.ToInt32(txtAgvInfoId.Text);
                    int a = baci.ExistsId(A_Id);
                    if (a != 0)
                    {
                        txtAgvInfoId.Text = "";
                        MessageBox.Show("The agv id already exists.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        bool isUsing = false;
                        if (cbIsUsing.Text == Common.agvIsUsingStr[0])
                        {
                            isUsing = true;
                        }
                        else
                        {
                            isUsing = false;
                        }
                        MA_AgvComInfo maci = new MA_AgvComInfo();
                        maci.A_Id = A_Id;
                        maci.A_Description = txtAgvInfoDescription.Text;
                        maci.A_IpAddress = strIP;
                        maci.A_NetNo = Convert.ToInt32(txtAgvInfoNetNo.Text);
                        maci.A_LocalPort = Convert.ToInt32(txtAgvInfoLocalPort.Text);
                        maci.A_DesPort = Convert.ToInt32(txtAgvInfoDesPort.Text);
                        maci.A_AgvConnectType = cbAgvConnectType.Text;
                        maci.A_AgvCommonType = cbAgvCommonType.SelectedIndex;
                        maci.A_IsUsing = isUsing;
                        int b = baci.AddAgvComInfo(maci);
                        if (b == 0)
                        {
                            MessageBox.Show("Addition failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            DgvAgvInfoRef();
                            MessageBox.Show("Successfully added!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            txtAgvInfoId.Text = (maci.A_Id + 1).ToString();
                            txtAgvInfoDescription.Text = txtAgvInfoDescription.Text.Remove(txtAgvInfoDescription.Text.Length - 2) + (maci.A_Id + 1).ToString();
                            string[] sips = strIP.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                            int ipLastNum = Convert.ToInt32(sips[sips.Length - 1]);
                            sips[sips.Length - 1] = (ipLastNum + 1).ToString();
                            for (int i = 0; i < sips.Length; i++)
                            {
                                if (sips[i].Length < 3)
                                {
                                    sips[i] = sips[i].PadLeft(3, ' ');
                                }
                            }
                            mtxtIp.Text = string.Join(".", sips);
                            txtAgvInfoNetNo.Text = (maci.A_NetNo + 1).ToString();
                            txtAgvInfoLocalPort.Text = (maci.A_LocalPort + 1).ToString();
                            txtAgvInfoDesPort.Text = (maci.A_DesPort + 1).ToString();
                        }
                    }
                }

            }
            catch
            {
                MessageBox.Show("IP error", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
        private void mtxtIp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                int pos = mtxtIp.SelectionStart;
                int max = (mtxtIp.MaskedTextProvider.Length - mtxtIp.MaskedTextProvider.EditPositionCount);
                int nextField = 0;

                for (int i = 0; i < mtxtIp.MaskedTextProvider.Length; i++)
                {
                    if (!mtxtIp.MaskedTextProvider.IsEditPosition(i) && (pos + max) >= i)
                        nextField = i;
                }
                nextField += 1;

                // We're done, enable the TabStop property again   


                mtxtIp.SelectionStart = nextField;

            }
        }
        /// <summary>
        /// "获取"按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgvComInfoObtain_Click(object sender, EventArgs e)
        {
            DgvAgvInfoRef();
        }
        /// <summary>
        /// 更新dgvAgvInfo列表
        /// </summary>
        private void DgvAgvInfoRef()
        {
            try
            {
                dgvAgvInfo.Rows.Clear();
                BA_AgvComInfo baci = new BA_AgvComInfo();
                lock (maaciList)
                {
                    maaciList.Clear();
                    maaciList = baci.QueryAllAgvComInfo();
                }
                if (maaciList.Count != 0)
                {
                    for (int i = 0; i < maaciList.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dr.CreateCells(dgvAgvInfo);
                        dr.Cells[0].Value = maaciList[i].A_Id;
                        dr.Cells[1].Value = maaciList[i].A_Description;
                        dr.Cells[2].Value = maaciList[i].A_IpAddress;
                        dr.Cells[3].Value = maaciList[i].A_NetNo;
                        dr.Cells[4].Value = maaciList[i].A_LocalPort;
                        dr.Cells[5].Value = maaciList[i].A_DesPort;
                        if (cCbAgvConnectType.Items.Contains(maaciList[i].A_AgvConnectType))
                        {
                            dr.Cells[6].Value = maaciList[i].A_AgvConnectType;
                        }
                        else
                        {
                            dr.Cells[6].Value = cCbAgvConnectType.Items[0];
                        }
                        dr.Cells[7].Value = cCbAgvCommonType.Items[0];
                        try
                        {
                            dr.Cells[7].Value = cCbAgvCommonType.Items[maaciList[i].A_AgvCommonType];
                        }
                        catch { }
                        dr.Cells[8].Value = maaciList[i].A_IsUsing;
                        dgvAgvInfo.Rows.Add(dr);
                    }
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 删除agv对象/修改agv对象
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAgvInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rows = e.RowIndex;
                if (e.ColumnIndex == 9)
                {
                    if (MessageBox.Show("Whether to delete the agv information?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        BA_AgvComInfo baci = new BA_AgvComInfo();
                        int id = Convert.ToInt32(dgvAgvInfo[0, rows].Value.ToString());
                        if (baci.DeleteAgvComInfo(id))
                        {
                            DgvAgvInfoRef();
                            MessageBox.Show("Successfully delete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Fail to delete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                else if (e.ColumnIndex == 10)
                {
                    if (MessageBox.Show("Whether to change the agv information?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        MA_AgvComInfo mai = new MA_AgvComInfo();
                        try
                        {
                            mai.A_Id = Convert.ToInt32(dgvAgvInfo.Rows[rows].Cells[0].Value.ToString());
                            if (dgvAgvInfo.Rows[rows].Cells[1].Value.ToString() == "")
                            {
                                MessageBox.Show("Describe canot be null!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            }
                            else
                            {
                                bool isRight = true;
                                mai.A_Description = dgvAgvInfo.Rows[rows].Cells[1].Value.ToString();
                                try
                                {
                                    IPAddress ip = IPAddress.Parse(dgvAgvInfo.Rows[rows].Cells[2].Value.ToString());
                                    mai.A_IpAddress = dgvAgvInfo.Rows[rows].Cells[2].Value.ToString();
                                }
                                catch
                                {
                                    isRight = false;
                                    MessageBox.Show("Ip canot be null!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                try
                                {
                                    mai.A_NetNo = Convert.ToInt32(dgvAgvInfo.Rows[rows].Cells[3].Value.ToString());
                                }
                                catch
                                {
                                    isRight = false;
                                    MessageBox.Show("Network node can only be of numerical type!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                try
                                {
                                    mai.A_LocalPort = Convert.ToInt32(dgvAgvInfo.Rows[rows].Cells[4].Value.ToString());
                                }
                                catch
                                {
                                    isRight = false;
                                    MessageBox.Show("Local port can only be of numerical type!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                try
                                {
                                    mai.A_DesPort = Convert.ToInt32(dgvAgvInfo.Rows[rows].Cells[5].Value.ToString());
                                }
                                catch
                                {
                                    isRight = false;
                                    MessageBox.Show("Destination port can only be of numerical type!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                }
                                if (isRight)
                                {
                                    mai.A_AgvConnectType = dgvAgvInfo.Rows[rows].Cells[6].Value.ToString() + "," + cCbAgvCommonType.Items.IndexOf(dgvAgvInfo.Rows[rows].Cells[7].Value);
                                    mai.A_IsUsing = Convert.ToBoolean(dgvAgvInfo.Rows[rows].Cells[8].Value);
                                    BA_AgvComInfo baci = new BA_AgvComInfo();
                                    if (baci.UpdateAgvComInfo(mai))
                                    {
                                        DgvAgvInfoRef();
                                        MessageBox.Show("Modify successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Unknown error!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    }
                                }


                            }
                        }
                        catch
                        {
                            MessageBox.Show("Unknown error!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
            catch (Exception eChange)
            { }
        }
        /// <summary>
        /// Agv配置窗体初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbStationTypeShow.SelectedIndex = 0;
                cbAgvConnectType.Items.Clear();
                cbAgvConnectType.Items.AddRange(Common.agvTypeStr);
                cbAgvConnectType.SelectedIndex = 0;
                cbIsUsing.Items.Clear();
                cbIsUsing.Items.AddRange(Common.agvIsUsingStr);
                cbIsUsing.SelectedIndex = 0;
                //DataGridView 
                cCbAgvConnectType.Items.Clear();
                cCbAgvConnectType.Items.AddRange(Common.agvTypeStr);
                //cCbIsUsing.Items.Clear();
                //cCbIsUsing.Items.AddRange(Common.agvIsUsingStr);
                //QueryCombox
                cbQueryAbnormalAgvNo.Items.Clear();
                cbQueryAbnormalAgvNo.Items.AddRange(Common.agvQueryContent);
                cbQueryAbnormalAgvNo.SelectedIndex = 0;

                //异常信息查询窗体初始化
                List<string> statusType = new List<string>();
                //foreach (string item in Common.pNameDt.Values)
                //{
                //    if (!statusType.Contains(item))
                //    {
                //        statusType.Add(item);
                //    }
                //}
                statusType.AddRange(Common.Instance.dtAgvAbnormal.Values);
                statusType.Add("lineoff");
                statusType.Add("online");
                statusType.Add("ChargeAnomaly");
                statusType.Add("ChargeStation1Error");
                statusType.Add("ChargeStation2Error");
                statusType.Add("RouteError");
                statusType.Add("All");
                cbQueryAbnormalInfo.Items.Clear();
                cbQueryAbnormalInfo.Items.AddRange(statusType.ToArray());
                cbQueryAbnormalInfo.SelectedIndex = statusType.Count - 1;
                string[] strAgvNo = new string[maaciList.Count + 1];
                for (int i = 0; i < maaciList.Count; i++)
                {
                    strAgvNo[i] = maaciList[i].A_Id.ToString();
                }
                strAgvNo[strAgvNo.Length - 1] = "All";
                cbQueryAbnormalAgvNo.Items.Clear();
                cbQueryAbnormalAgvNo.Items.AddRange(strAgvNo);
                cbQueryAbnormalAgvNo.SelectedIndex = strAgvNo.Length - 1;
                //任务信息查询窗体初始化
                cbQueryTaskAgvNo.Items.Clear();
                cbQueryTaskAgvNo.Items.AddRange(strAgvNo);
                cbQueryTaskAgvNo.SelectedIndex = strAgvNo.Length - 1;
                ////任务信息查询窗体线别初始化
                //List<string> lsLine = new List<string>();
                //foreach (string item in Common.lineNameDt.Values)
                //{
                //    lsLine.Add(item);
                //}
                //cbQueryTaskLineNo.Items.Clear();
                //cbQueryTaskLineNo.Items.Add("全部");
                //cbQueryTaskLineNo.Items.AddRange(lsLine.ToArray());
                cbQueryTaskLineNo.SelectedIndex = 0;
                if (isLOadOk)
                    LoadingFormService.Close();
                try
                {
                    cbCapTestTaskRefEnable.Checked = Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_1].TaskRefreshEnable;
                    txtCapTestTaskTime.Text = Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_1].TaskRefreshTime.ToString();

                    cbPreAgingTaskRefEnable.Checked = Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_2].TaskRefreshEnable;
                    txtPreAgingTaskTime.Text = Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_2].TaskRefreshTime.ToString();

                    cbCapAgingTaskRefEnable.Checked = Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_3].TaskRefreshEnable;
                    txtCapAgingTaskTime.Text = Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_3].TaskRefreshTime.ToString();
                }
                catch { }
            }
            catch
            { }
        }
        private void tabMain_Selected(object sender, TabControlEventArgs e)
        {
            try
            {
                if (tabMain.SelectedTab == tabpState)
                {
                    IsRefAgvState = true;
                }
                else
                {
                    IsRefAgvState = false;
                }
                if (isLOadOk)
                {
                    LoadingFormService.Show();
                    LoadingFormService.SetText("Page switching...");
                }
            }
            catch { }
        }
        private void txtAgvInfoId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void txtAgvInfoNetNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void txtAgvInfoLocalPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void txtAgvInfoDesPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        #endregion //Agv配置

        #region 管理员用户管理
        private void mnuInitSetAdminManageUser_Click(object sender, EventArgs e)
        {
            ManageUserInfoForm muif = new ManageUserInfoForm();
            try
            {
                if (LoginRoler.U_Level >= 4)
                    muif.ShowDialog();
            }
            finally
            {
                muif.Dispose();
            }
        }
        private void mnuInitSetAdminRfidSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (mnuInitSetAdminRfidSet.Checked)
                {
                    mnuSetRfid.Checked = true;
                    this.isRfidSet = true;
                    if (mnuInitSetAdminRfidSet.Checked)
                    {
                        mnuInitSetAdminStationSet.Checked = false;
                        this.isStationSet = false;
                    }
                }
                else
                {
                    mnuSetRfid.Checked = false;
                    this.isRfidSet = false;
                }
            }
            catch { }
        }
        private void mnuInitSetAdminStationSet_Click(object sender, EventArgs e)
        {
            try
            {
                if (mnuInitSetAdminStationSet.Checked)
                {
                    this.isStationSet = true;
                    if (mnuInitSetAdminRfidSet.Checked)
                    {
                        this.isRfidSet = false;
                        mnuInitSetAdminRfidSet.Checked = false;
                        mnuSetRfid.Checked = false;
                    }
                }
                else
                {
                    this.isStationSet = false;
                }
            }
            catch { }
        }
        private void mnuInitSetAdminStationHide_Click(object sender, EventArgs e)
        {
            try
            {
                if (mnuInitSetAdminStationHide.Checked)
                {
                    foreach (Label item in this.dtStationLabel.Values)
                    {
                        item.Visible = false;
                    }
                }
                else
                {
                    foreach (Label item in this.dtStationLabel.Values)
                    {
                        item.Visible = true;
                    }
                }
            }
            catch { }
        }
        private void mnuInitSetIsDynPwd_Click(object sender, EventArgs e)
        {
            Common.isDynPwd = mnuInitSetIsDynPwd.Checked;
        }
        #endregion //管理员用户管理

        #region 版本信息
        private void mnuVersion_Click(object sender, EventArgs e)
        {
            //string v1002 = "版本号：V1.0.0.2 \r\n修改内容：\r\n1、调整AGV显示的大小，调整AGV编号提示框的大小\r\n2、添加通过双击任务记录直接显示对应的定位信息的辅助功能\r\n3、添加6号车的任务记录\r\n4、添加AGV显示可手动调整大小\r\n\r\n制造商：深圳市欧铠机器人有限公司\r\n\r\n更新日期：2015-12-28";
            //string v1002 = "版本号：V1.0.0.3 \r\n修改内容：\r\n1、修改扫码成功不显示站点信息BUG\r\n2、优化读取物料信息流程\r\n3、修正AGV初始状态显示RFID位置为-1，不再是默认55\r\n4、当AGV被选定为可扫码对象时，状态栏的背景色为黑色\r\n\r\n制造商：深圳市欧铠机器人有限公司\r\n\r\n更新日期：2016-02-25";
            string v1002 = "Version number:V2.1.0.1\r\n\rManufacturer：www.okagv.com\r\n\r\nUpdate Date：2018-07-10";
            MessageBox.Show(v1002, "Version information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion //版本信息

        #region 窗体关闭时关闭所有进程
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Is close the form？", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                WinSleepCtr.SleepCtr(false);
                e.Cancel = true;
            }
            else
            {
                CloseForm();
            }
        }
        private void mnuEsc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Is Exit？", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                WinSleepCtr.SleepCtr(false);
                CloseForm();
            }
        }

        private void CloseForm()
        {
            Common.tlpPoint.X = tlpAgvLight.Left;
            Common.tlpPoint.Y = tlpAgvLight.Top;
            ParametersOperate.ParametersSave(true);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        #endregion //窗体关闭时关闭所有进程

        #region 按钮事件
        /// <summary>
        /// "重启连接"按钮操作事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRestThread_Click(object sender, EventArgs e)
        {
            AgvThreadRestStart();
        }
        #endregion //按钮事件

        #region 信息查询方法
        //信息查询按钮事件
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.pbAbn.Value = 0;
            this.btnQuery.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnExport.Enabled = false;
            this.lblAbnWaitShow.Visible = true;
            this.pbAbn.Visible = true;
            dgvSqlData.Rows.Clear();
            dgvSqlData.ColumnCount = 7;
            dgvSqlData.Columns[0].HeaderText = "Index";
            dgvSqlData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvSqlData.Columns[1].HeaderText = "Agv number";
            dgvSqlData.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSqlData.Columns[2].HeaderText = "State";
            dgvSqlData.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSqlData.Columns[3].HeaderText = "Rfid";
            dgvSqlData.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSqlData.Columns[4].HeaderText = "Default1";
            dgvSqlData.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSqlData.Columns[5].HeaderText = "Default2";
            dgvSqlData.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSqlData.Columns[6].HeaderText = "Occurrence time";
            dgvSqlData.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvSqlData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            Thread t = new Thread(new ThreadStart(AbnormalQueryAsync));
            t.IsBackground = true;
            t.Start();
        }
        private void AbnormalQueryAsync()
        {
            try
            {
                string strQueryAgvNo = cbQueryAbnormalAgvNo.Text;
                bool isAgvNo = false;
                int AgvNo = 0;
                try
                {
                    AgvNo = Convert.ToInt32(strQueryAgvNo);
                    isAgvNo = true;
                }
                catch
                {
                    isAgvNo = false;
                }
                string strQueryAbnormalInfo = cbQueryAbnormalInfo.Text;
                bool isInfo = false;
                if (strQueryAbnormalInfo == "All")
                {
                    isInfo = false;
                }
                else
                {
                    isInfo = true;
                }
                string strQueryAbnormalRfid = txtQueryAbnormalRfid.Text;
                bool isRfid = false;
                int Rfid = 0;
                try
                {
                    Rfid = Convert.ToInt32(strQueryAbnormalRfid);
                    isRfid = true;
                }
                catch
                {
                    isRfid = false;
                }
                string time1 = "";
                string time2 = "";
                if (chbDateSelect.Checked)
                {
                    time1 = dtpBegin.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    time2 = dtpEnd.Value.Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    time1 = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                    time2 = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                }
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                BA_AgvErrorInfo bae = new BA_AgvErrorInfo();
                DataSet ds = new DataSet();
                if (!isAgvNo && !isInfo && !isRfid)
                {
                    ds = bae.QueryConditionAgvErrorInfo(time1, time2);
                }
                else if (isAgvNo && !isInfo && !isRfid)
                {
                    ds = bae.QueryConditionAgvErrorInfo(AgvNo, time1, time2);
                }
                else if (!isAgvNo && isInfo && !isRfid)
                {
                    ds = bae.QueryConditionAgvErrorInfo(strQueryAbnormalInfo, time1, time2);
                }
                else if (!isAgvNo && !isInfo && isRfid)
                {
                    ds = bae.QueryConditionAgvErrorInfo(true, Rfid, time1, time2);
                }
                else if (isAgvNo && isInfo && !isRfid)
                {
                    ds = bae.QueryConditionAgvErrorInfo(AgvNo, strQueryAbnormalInfo, time1, time2);
                }
                else if (!isAgvNo && isInfo && isRfid)
                {
                    ds = bae.QueryConditionAgvErrorInfo(true, Rfid, strQueryAbnormalInfo, time1, time2);
                }
                else if (isAgvNo && !isInfo && isRfid)
                {
                    ds = bae.QueryConditionAgvErrorInfo(AgvNo, Rfid, time1, time2);
                }
                else if (isAgvNo && isInfo && isRfid)
                {
                    ds = bae.QueryConditionAgvErrorInfo(AgvNo, strQueryAbnormalInfo, Rfid, time1, time2);
                }

                this.Invoke(new MethodInvoker(delegate() { this.pbAbn.Value = 10; }));
                stopwatch.Stop();
                Debug.Print("异常从数据库获取耗时 ：{0}", stopwatch.Elapsed.TotalSeconds.ToString());
                AbnormalQuery(ds);
            }
            catch { }
        }
        //异常信息显示
        private void AbnormalQuery(DataSet ds)
        {
            Stopwatch stopwatch = new Stopwatch();
            try
            {
                if (ds != null)
                {
                    List<DataGridViewRow> lsdgvr = new List<DataGridViewRow>();
                    stopwatch.Start();
                    int index = 0;
                    int d = ds.Tables[0].Rows.Count / 40;
                    if (d == 0) d = 1;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dr.CreateCells(dgvSqlData);
                        dr.Cells[0].Value = ds.Tables[0].Rows[i][0];
                        dr.Cells[1].Value = ds.Tables[0].Rows[i][1];
                        dr.Cells[2].Value = ds.Tables[0].Rows[i][2];
                        dr.Cells[3].Value = ds.Tables[0].Rows[i][5];
                        dr.Cells[4].Value = ds.Tables[0].Rows[i][6];
                        dr.Cells[5].Value = ds.Tables[0].Rows[i][4];
                        dr.Cells[6].Value = Convert.ToDateTime(ds.Tables[0].Rows[i][7]).ToString("yyyy-MM-dd HH:mm:ss");
                        //dgvSqlData.Rows.Add(dr);  
                        if (index == 39)
                        { }
                        if (i / d != index)
                        {
                            index = i / d;
                            this.Invoke(new MethodInvoker(delegate() { this.pbAbn.Value = index + 10; }));
                            this.Invoke(new MethodInvoker(delegate() { this.lblAbnWaitShow.Text = string.Format("The data is loading... {0}%", index + 10); }));
                        }
                        lsdgvr.Add(dr);
                    }
                    stopwatch.Stop();
                    Debug.Print("异常列表加载耗时 ：{0}", stopwatch.Elapsed.TotalSeconds.ToString());
                    stopwatch.Reset();
                    stopwatch.Start();
                    this.Invoke(new MethodInvoker(delegate() { this.dgvSqlData.Rows.AddRange(lsdgvr.ToArray()); this.dgvSqlData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); }));
                    stopwatch.Stop();
                    Debug.Print("异常加载的datagridview耗时 ：{0}", stopwatch.Elapsed.TotalSeconds.ToString());
                }
            }
            catch (Exception eAbn)
            { }
            this.Invoke(new MethodInvoker(delegate() { this.btnQuery.Enabled = true; }));
            this.Invoke(new MethodInvoker(delegate() { this.btnDelete.Enabled = true; }));
            this.Invoke(new MethodInvoker(delegate() { this.btnExport.Enabled = true; }));
            this.Invoke(new MethodInvoker(delegate() { this.lblAbnWaitShow.Visible = false; }));
            this.Invoke(new MethodInvoker(delegate() { this.pbAbn.Visible = false; }));

        }
        //将数据导出到Excel
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataToExcel daExcel = new DataToExcel();
                daExcel.DataToExcelDataGridView(dgvSqlData, "Abnormal data export");
            }
            catch { }
        }
        private void txtQueryAbnormalRfid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (chbDateSelect.Checked)
                {
                    string time1 = dtpBegin.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    string time2 = dtpEnd.Value.Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                    if (MessageBox.Show("Is delete" + time1 + "--" + time2 + " data?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        BA_AgvErrorInfo bae = new BA_AgvErrorInfo();
                        if (bae.DeleteTimeAgvErrorInfo(time1, time2) >= 0)
                        {
                            MessageBox.Show("Successfully delete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Default error!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check the date option!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            {
                MessageBox.Show("Default error!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion //信息查询方法

        #region 任务记录查询
        //双击对应任务时显示对应时间任务的定位信息
        private void dgvSqlTaskData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //int rows = e.RowIndex;
                //int agvNo = Convert.ToInt32(dgvSqlTaskData.Rows[rows].Cells[2].Value);
                //DateTime time1 = Convert.ToDateTime(dgvSqlTaskData.Rows[rows].Cells[4].Value.ToString());
                //string[] worktime = dgvSqlTaskData.Rows[rows].Cells[3].Value.ToString().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                //int sec = Convert.ToInt32(worktime[0]) * 3600 + Convert.ToInt32(worktime[1]) * 60 + Convert.ToInt32(worktime[2]);
                //string time1s = time1.ToString("yyyy-MM-dd HH:mm:ss");
                //string time2s = time1.AddSeconds(Convert.ToDouble(sec)).ToString("yyyy-MM-dd HH:mm:ss");
                //BA_AgvErrorInfo bae = new BA_AgvErrorInfo();
                //DataSet ds = bae.QueryConditionAgvErrorInfo(agvNo, time1s, time2s);
                //tabMain.SelectedTab = tabpQueryAbnormal;
                //AbnormalQuery(ds);

            }
            catch (Exception ex)
            {

            }
        }
        private void btnTaskExport_Click(object sender, EventArgs e)
        {
            DataToExcel daExcel = new DataToExcel();
            daExcel.DataToExcelDataGridView(dgvSqlTaskData, "Task record export");
        }
        private void cbQueryTaskLineNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lineNoStr = string.Empty;
                int lineNo = cbQueryTaskLineNo.SelectedIndex;
                cbQueryTaskTaskType.Items.Clear();
                //cbQueryTaskTaskType.Items.Add("全部");
                switch (lineNo)
                {
                    case 0:
                        lineNoStr = "All";
                        break;
                    case 1:
                    case 2:
                        cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Transport_A_F]);
                        cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Transport_A_C]);
                        cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Transport_C_F]);
                        cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Transport_E_A]);
                        cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Transport_B_E]);
                        cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Transport_B_D]);
                        cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Transport_D_E]);
                        cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Transport_F_B]);
                        cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Chareg_Leave]);
                        cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Charge_Go]);
                        lineNoStr = string.Empty;
                        break;
                    case 3:
                        //cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Chareg_CapAging]);
                        //cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Cap_AgingRoom_AgingRoom]);
                        //cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Cap_AgingRoom_RestintZone]);
                        //cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Cap_Load_AgingRoom]);
                        //cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Cap_RestingZone_Unload]);
                        //cbQueryTaskTaskType.Items.Add(Common.Instance.dtTaskTypeName[Enumerations.TaskType.Cap_Unload_Load]);
                        lineNoStr = string.Empty;
                        break;
                }
                cbQueryTaskTaskType.SelectedIndex = 0;
            }
            catch { }
        }
        private void btnQueryTask_Click(object sender, EventArgs e)
        {
            this.pbQueryTask.Value = 0;
            this.btnQueryTask.Enabled = false;
            this.btnTaskExport.Enabled = false;
            this.btnDeleteTask.Enabled = false;
            this.lblQueryTaskShow.Visible = true;
            this.pbQueryTask.Visible = true;
            dgvSqlTaskData.Rows.Clear();
            dgvSqlTaskData.ColumnCount = 12;
            string[] headerTextStrs = new string[] { "Index", "Id", "AgvId", "Type", "Level", "State", "Name", "Describ", "CreateTime", "StartTime", "FinishTime", "UpdateTime" };
            for (int i = 0; i < 12; i++)
            {
                dgvSqlTaskData.Columns[i].HeaderText = headerTextStrs[i];
                dgvSqlTaskData.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            dgvSqlTaskData.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            Thread t = new Thread(new ThreadStart(QueryTask));
            t.IsBackground = true;
            t.Start();
        }
        private void QueryTask()
        {
            try
            {
                bool isAgvNo = false;
                int agvNo = 0;
                try
                {
                    agvNo = Convert.ToInt32(cbQueryTaskAgvNo.Text);
                    isAgvNo = true;
                }
                catch
                {
                    isAgvNo = false;
                }
                int lineNo = cbQueryTaskLineNo.SelectedIndex;
                if (lineNoStr != "All")
                {
                    lineNoStr = cbQueryTaskTaskType.Text.Trim();
                    if (chbTaskMes.Checked) lineNoStr += "[";
                }
                string time1 = "";
                string time2 = "";
                if (chbTaskDateSelect.Checked)
                {
                    time1 = dtTaskBegin.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    time2 = dtTaskEnd.Value.Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    time1 = DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss");
                    time2 = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                }
                BA_AgvTaskInfo bati = new BA_AgvTaskInfo();
                DataSet ds = new DataSet();
                if (!isAgvNo && lineNoStr == "All")
                {
                    ds = bati.QueryConditionAgvTaskInfo(time1, time2);
                }
                else if (isAgvNo && lineNoStr == "All")
                {
                    ds = bati.QueryConditionAgvTaskInfo(agvNo, time1, time2);
                }
                else if (!isAgvNo && lineNoStr != "All")
                {
                    ds = bati.QueryConditionAgvTaskInfo(lineNoStr, time1, time2);
                }
                else if (isAgvNo && lineNoStr != "All")
                {
                    ds = bati.QueryConditionAgvTaskInfo(agvNo, lineNoStr, time1, time2);
                }
                this.Invoke(new MethodInvoker(delegate() { this.pbQueryTask.Value = 10; }));
                bool isSift = false;
                int siftMintues = 0;
                try
                {
                    //siftMintues = Convert.ToInt32(txtQueryTaskSift.Text);
                    //isSift = true;
                }
                catch { isSift = false; }
                try
                {
                    int countTask = 0;
                    if (ds != null)
                    {
                        countTask = ds.Tables[0].Rows.Count;
                        int index = 0;
                        int d = countTask / 40;
                        if (d == 0) d = 1;
                        List<DataGridViewRow> lsdgvr = new List<DataGridViewRow>();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            DataGridViewRow dr = new DataGridViewRow();
                            dr.CreateCells(dgvSqlTaskData);
                            for (int j = 0; j < 12; j++)
                            {
                                dr.Cells[j].Value = ds.Tables[0].Rows[i][j].ToString();
                            }
                            lsdgvr.Add(dr);
                            if (i / d != index)
                            {
                                index = i / d;
                                this.Invoke(new MethodInvoker(delegate() { this.pbQueryTask.Value = index + 10; }));
                                this.Invoke(new MethodInvoker(delegate() { this.lblQueryTaskShow.Text = string.Format("The data is loading... {0}%", index + 10); }));
                            }
                        }
                        this.Invoke(new MethodInvoker(delegate() { this.dgvSqlTaskData.Rows.AddRange(lsdgvr.ToArray()); this.dgvSqlTaskData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells); }));
                    }
                    this.Invoke(new MethodInvoker(delegate() { this.lblTaskCount.Text = string.Format("Count:{0}", countTask); }));
                }
                catch (Exception extask)
                { }
            }
            catch { }
            this.Invoke(new MethodInvoker(delegate() { this.btnQueryTask.Enabled = true; }));
            this.Invoke(new MethodInvoker(delegate() { this.btnTaskExport.Enabled = true; }));
            this.Invoke(new MethodInvoker(delegate() { this.btnDeleteTask.Enabled = true; }));
            this.Invoke(new MethodInvoker(delegate() { this.lblQueryTaskShow.Visible = false; }));
            this.Invoke(new MethodInvoker(delegate() { this.pbQueryTask.Visible = false; }));
        }
        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (chbTaskDateSelect.Checked)
                {
                    string time1 = dtTaskBegin.Value.Date.ToString("yyyy-MM-dd HH:mm:ss");
                    string time2 = dtTaskEnd.Value.Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
                    if (MessageBox.Show("Is delete" + time1 + "--" + time2 + " datas", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        BA_AgvTaskInfo bti = new BA_AgvTaskInfo();
                        if (bti.DeleteTimeAgvTaskInfo(time1, time2) >= 0)
                        {
                            MessageBox.Show("Successfully delete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Default error!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please check the date option!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            {
                MessageBox.Show("Default error!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion //任务记录查询

        #region statusStrip控件事件
        private void stuLabelCommStatus_Click(object sender, EventArgs e)
        {
            //    Common.isComm = !Common.isComm;
            //    IsComm();
        }
        private void IsComm()
        {
            if (Common.isComm)
            {
                stuLabelCommStatus.Text = "Agv：Open";
                stuLabelCommStatus.BackColor = Color.Lime;
            }
            else
            {
                stuLabelCommStatus.Text = "Agv：Close";
                stuLabelCommStatus.BackColor = Color.Red;
            }
        }
        private void stuLabelTcpStatus_Click(object sender, EventArgs e)
        {
            if (!Common.isTcpComm)
            {
                if (Common.clientThreadDt.Count <= 0)
                {
                    BC_TcpServer bcTcpServer = new BC_TcpServer();
                    bcTcpServer.Bc_BeginListen();
                    stuLabelTcpStatus.Text = "客户端连接：开启";
                    stuLabelTcpStatus.BackColor = Color.Lime;
                    Common.isTcpComm = !Common.isTcpComm;
                }
            }
            else
            {
                try
                {
                    foreach (string item in Common.clientDt.Keys)
                    {
                        Common.clientDt[item].Close();
                    }
                    foreach (Thread item in Common.clientThreadDt.Values)
                    {
                        item.Abort();
                    }
                    Common.clientThreadDt.Clear();
                    Common.clientDt.Clear();
                    stuLabelTcpStatus.Text = "客户端连接：关闭";
                    stuLabelTcpStatus.BackColor = Color.Red;
                    Common.isTcpComm = !Common.isTcpComm;
                }
                catch
                {

                }
            }
        }

        private void stuLabelTcpStatus_MouseHover(object sender, EventArgs e)
        {
            if (Common.isTcpComm)
            {
                if (Common.clientDt.Count > 0)
                {
                    StringBuilder str = new StringBuilder();
                    foreach (string item in Common.clientDt.Keys)
                    {
                        str.Append(item + "\n");
                    }
                    tooltip.Show(str.ToString(), stu);
                }
            }
        }

        private void stuLabelTcpStatus_MouseLeave(object sender, EventArgs e)
        {
            tooltip.RemoveAll();
        }
        #endregion //statusStrip控件事件

        #region 资料文件夹
        private void mnuOpenInformation_Click(object sender, EventArgs e)
        {
            string abnFilesStr = Common.Instance.SourcePath + @"\Information";
            try
            {
                if (!Directory.Exists(abnFilesStr))
                {
                    Directory.CreateDirectory(abnFilesStr);
                }
                System.Diagnostics.Process.Start("explorer.exe", abnFilesStr);
            }
            catch
            {
                MessageBox.Show("打开失败！");
            }
        }
        #endregion //资料文件夹

        #region 地图存储
        private void btnMapConfigImport_Click(object sender, EventArgs e)
        {
            try
            {

                ImageToByteOperate itbo = new ImageToByteOperate();
                List<byte> lsImage = itbo.ImageToByte("导入电子地图");
                if (lsImage != null)
                {
                    try
                    {
                        MemoryStream ms = new MemoryStream(lsImage.ToArray());
                        Image backBitmap = System.Drawing.Image.FromStream(ms);
                        string path = Common.Instance.SourcePath + @"\Information\";
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        picConfigMap.Image = backBitmap;
                        //MessageBox.Show("导入成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("导入失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("导入失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }
        /// <summary>
        /// 电子地图导入
        /// </summary>
        /// <param name="mapNo">电子地图编号</param>
        private void MapImport(int mapNo)
        {
            ImageToByteOperate itbo = new ImageToByteOperate();
            List<byte> lsImage = itbo.ImageToByte("Import map background");
            if (lsImage != null)
            {
                try
                {
                    MemoryStream ms = new MemoryStream(lsImage.ToArray());
                    Image backBitmap = System.Drawing.Image.FromStream(ms);
                    string path = Common.Instance.SourcePath + @"\Information\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    try
                    {
                        mapShow[mapNo].BackgroundImage.Dispose();
                    }
                    catch { }
                    backBitmap.Save(path + "Map" + mapNo + ".jpg");
                    mapShow[mapNo].BackgroundImage = backBitmap;
                    MessageBox.Show("Import successfully！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Import Failed！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        private void btnMapConfigPreview_Click(object sender, EventArgs e)
        {
            try
            {
                KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)cbMapSel.SelectedItem;
                int i = kvp.Key;
                picConfigMap.Image = mapShow[i].BackgroundImage;
            }
            catch { }
        }
        private void btnMapConfigPreviewClear_Click(object sender, EventArgs e)
        {
            try
            {
                picConfigMap.BackgroundImage = null;
            }
            catch { }
        }
        private void btnMapConfigRef_Click(object sender, EventArgs e)
        {
            try
            {
                KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)cbMapSel.SelectedItem;
                int mapNo = kvp.Key;
                if (MessageBox.Show("Is Update [" + kvp.Value + "]?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    Image backBitmap = picConfigMap.Image;
                    string path = Common.Instance.SourcePath + @"\Information\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    mapShow[mapNo].BackgroundImage.Dispose();
                    backBitmap.Save(path + "Map" + mapNo + ".jpg");
                    mapShow[mapNo].BackgroundImage = backBitmap;
                    MessageBox.Show("Update successfully！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch { }
        }
        //电子地图设定
        private void mnuSetMapSet_Click(object sender, EventArgs e)
        {
            try
            {
                MapForm mapForm = new MapForm(this.tmrMapChange);
                try
                {
                    mapForm.ShowDialog();
                }
                finally
                {
                    mapForm.Dispose();
                }
            }
            catch { }
        }
        //地图导出
        private void btnMapConfigExport_Click(object sender, EventArgs e)
        {
            int mapNo = -1;
            try
            {
                KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)cbMapSel.SelectedItem;
                mapNo = kvp.Key;
                //mapNo = Convert.ToInt32(cbMapSel.SelectedText);
            }
            catch
            { }
            MapExport(mapNo);
        }
        /// <summary>
        /// 电子地图导出
        /// </summary>
        /// <param name="mapNo">电子地图编号</param>
        private void MapExport(int mapNo)
        {
            if (mapNo != -1)
            {
                SaveFileDialog ofd = new SaveFileDialog();
                string path = path = Common.Instance.SourcePath + @"\Image\Map.jpg";
                ofd.Title = "Save image file";
                ofd.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP|*.PNG|*.PNG";
                ofd.AddExtension = true;
                ofd.FileName = "Map" + mapNo.ToString() + ".jpg";
                ofd.InitialDirectory = @"D:\";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image saveImage = (Image)new Bitmap(Common.Instance.SourcePath + @"\Image\Map" + mapNo.ToString() + ".jpg");
                        saveImage.Save(ofd.FileName);
                        MessageBox.Show("Export successfully！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    catch
                    {
                        MessageBox.Show("Export Failed！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                try
                {
                    ofd.Dispose();
                }
                catch { }
            }
        }
        #endregion //地图存储

        #region 电子地图缩放、拖动
        private void panTabMap_Resize(object sender, EventArgs e)
        {
            try
            {
                foreach (Panel pan in mapShow.Values)
                {
                    pan.Width = panTabMap.Width;
                    pan.Height = panTabMap.Height;
                    pan.Left = 0;
                    pan.Top = 0;
                    pwPan = pan.Width;
                    phPan = pan.Height;
                }
                lblMapXY.Location = new Point(panTabMap.Width - lblMapXY.Width, panTabMap.Height - lblMapXY.Height);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }
        private void panTabMapShow_MouseWheel(object sender, MouseEventArgs e)
        {
            Panel pan = (Panel)sender;
            Point wheelPoint = new Point();
            wheelPoint.X = Cursor.Position.X;
            wheelPoint.Y = Cursor.Position.Y;
            //wheelPoint.X = e.X;
            //wheelPoint.Y = e.Y;
            int panXc = panTabMap.Width / 2;
            int panYc = panTabMap.Height / 2;
            try
            {
                int mapNo = (int)pan.Tag;
                if (e.Delta > 0)
                {
                    if (zoom < 10)
                    {
                        zoom += 0.1f;
                    }
                }
                if (e.Delta < 1)
                {
                    if (zoom > 1)
                    {
                        zoom -= 0.1f;
                    }
                }
                pan.Width = Convert.ToInt32(pwPan * zoom);
                pan.Height = Convert.ToInt32(phPan * zoom);
                wheelPoint.X = Convert.ToInt32(wheelPoint.X * zoom);
                wheelPoint.Y = Convert.ToInt32(wheelPoint.Y * zoom);
                panXc -= wheelPoint.X;
                panYc -= wheelPoint.Y;
                if (panXc > 0)
                {
                    pan.Left = 0;
                }
                else if (pan.Width + panXc < panTabMap.Width)
                {
                    pan.Left = panTabMap.Width - pan.Width;
                }
                else
                {
                    pan.Left = panXc;
                }
                if (panYc > 0)
                {
                    pan.Top = 0;
                }
                else if (pan.Height + panYc < panTabMap.Height)
                {
                    pan.Top = panTabMap.Height - pan.Height;
                }
                else
                {
                    pan.Top = panYc;
                }
            }
            catch (Exception ex)
            {

            }
            lblMapXY.Parent = pan;
            lblMapXY.Left = panTabMap.Width - pan.Left - lblMapXY.Width;
            lblMapXY.Top = panTabMap.Height - pan.Top - lblMapXY.Height;
        }
        private void panTabMapShow_MouseEnter(object sender, EventArgs e)
        {
            Panel pan = (Panel)sender;
            pan.Focus();
        }
        private void panTabMapShow_MouseLeave(object sender, EventArgs e)
        {
            //txtBarCode.Focus();
        }
        private void panTabMapShow_MouseDown(object sender, MouseEventArgs e)
        {
            Panel pan = (Panel)sender;

            if (e.Button == MouseButtons.Left)
            {
                mouseDownPoint.X = Cursor.Position.X;
                mouseDownPoint.Y = Cursor.Position.Y;
                isLeftMouseSelected = true;
            }
            //else if (e.Button == MouseButtons.Right)
            //{
            //    if (isRfidSet && LoginRoler.U_Level > 1)
            //    {
            //        RfidSetForm rsf = new RfidSetForm(new Point(e.X, e.Y), pan, this.rfidLabelDt, true);
            //        rsf.ShowDialog();
            //    }
            //    else if (isStationSet && LoginRoler.U_Level > 1)
            //    {
            //        StationSetForm ssForm = new StationSetForm(new Point(e.X, e.Y), pan, (int)pan.Tag, this.dtStationLabel);
            //        ssForm.ShowDialog();
            //    }
            //    else
            //    {
            //        TaskForm tf = new TaskForm();
            //        tf.ShowDialog();
            //    }
            //}
        }
        void pan_MouseClick(object sender, MouseEventArgs e)
        {

            Panel pan = (Panel)sender;


            if (e.Button == MouseButtons.Right)
            {
                if (isRfidSet && LoginRoler.U_Level > 1)
                {
                    RfidSetForm rsf = new RfidSetForm(new Point(e.X, e.Y), pan, this.rfidLabelDt, true);
                    try
                    {
                        rsf.ShowDialog();
                    }
                    finally
                    {
                        rsf.Dispose();
                    }
                }
                else if (isStationSet && LoginRoler.U_Level > 1)
                {
                    StationSetForm ssForm = new StationSetForm(new Point(e.X, e.Y), pan, (int)pan.Tag, this.dtStationLabel);
                    try
                    {
                        ssForm.ShowDialog();
                    }
                    finally
                    {
                        ssForm.Dispose();
                    }
                }
                else
                {
                    if (isSpecialMouseOperate && DateTime.Now.Subtract(mouseJudgeTime).TotalSeconds < 1 && LoginRoler.U_Level > 1)
                    {
                        RfidSetForm rsf = new RfidSetForm(new Point(e.X, e.Y), pan, this.rfidLabelDt, false);
                        try
                        {
                            rsf.ShowDialog();
                        }
                        finally
                        {
                            rsf.Dispose();
                        }
                    }
                    else
                    {
                        //TaskForm tf = new TaskForm();
                        //try
                        //{
                        //    tf.ShowDialog();
                        //}
                        //finally
                        //{
                        //    tf.Dispose();
                        //}
                    }
                }
                isSpecialMouseOperate = false;
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                isSpecialMouseOperate = true;
                mouseJudgeTime = DateTime.Now;
            }
        }
        private void panTabMapShow_MouseUp(object sender, MouseEventArgs e)
        {
            isLeftMouseSelected = false;
        }
        private void panTabMapShow_MouseMove(object sender, MouseEventArgs e)
        {
            Panel pan = (Panel)sender;
            int i = (int)pan.Tag;
            lblMapXY.Text = "x:" + Convert.ToInt32(e.X / Common.sizeMapImage[i].widthScale).ToString().PadLeft(5, ' ') + " y:" + Convert.ToInt32(e.Y / Common.sizeMapImage[i].heightScale).ToString().PadLeft(5, ' ');
            if (isLeftMouseSelected)
            {
                Point movPoint = new Point();
                movPoint.X = Cursor.Position.X - mouseDownPoint.X;
                movPoint.Y = Cursor.Position.Y - mouseDownPoint.Y;
                if (IsOutPanTabMap(movPoint, i))
                {
                    if ((this.mapShow[i].Left + movPoint.X) > 0 && movPoint.X > 0)
                    {
                        movPoint.X = 0 - pan.Left;
                    }
                    else if ((this.mapShow[i].Right + movPoint.X) < this.mapShow[i].Width && movPoint.X < 0)
                    {
                        movPoint.X = this.panTabMap.Width - this.mapShow[i].Right;
                    }
                    if ((this.mapShow[i].Top + movPoint.Y) > 0 && movPoint.Y > 0)
                    {
                        movPoint.Y = 0 - this.mapShow[i].Top;
                    }
                    else if ((this.mapShow[i].Bottom + movPoint.Y) < this.panTabMap.Height && movPoint.Y < 0)
                    {
                        movPoint.Y = this.panTabMap.Height - this.mapShow[i].Bottom;
                    }
                    //coorX += movPoint.X;
                    //coorY += movPoint.Y;
                    this.mapShow[i].Left += movPoint.X;
                    this.mapShow[i].Top += movPoint.Y;
                    mouseDownPoint.X += movPoint.X;
                    mouseDownPoint.Y += movPoint.Y;
                }
            }
            lblMapXY.Parent = pan;
            lblMapXY.Left = panTabMap.Width - pan.Left - lblMapXY.Width;
            lblMapXY.Top = panTabMap.Height - pan.Top - lblMapXY.Height;
        }
        private void panTabMapShow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //if (LoginRoler.U_Level > 1)
            //{
            //    MapImport(this.CurrentMapNo);
            //}
            try
            {
                //int agvNo = Common.maiDict.FirstOrDefault(o => o.Value.AgvNo > 0).Key;
                //AgvState agvState = new AgvState(agvNo);
                //try
                //{
                //    agvState.ShowDialog();
                //}
                //finally
                //{
                //    agvState.Dispose();
                //}
            }
            catch { }
        }
        private void panTabMapShow_Resize(object sender, EventArgs e)
        {
            try
            {
                Panel pan = (Panel)sender;
                int i = (int)pan.Tag;
                ObtainSizeScaleImage();
                //当电子地图Size改变时，更新RFID地标卡的位置
                foreach (int item in rfidLabelDt.Keys)
                {
                    try
                    {
                        if (Common.rfidDt.ContainsKey(item))
                        {
                            if (Common.rfidDt[item].MapNo == this.CurrentMapNo)
                            {
                                rfidLabelDt[item].Location = new Point(Convert.ToInt32(Common.rfidDt[item].RfidX * Common.sizeMapImage[this.CurrentMapNo].widthScale) - 10, Convert.ToInt32(Common.rfidDt[item].RfidY * Common.sizeMapImage[this.CurrentMapNo].heightScale) - 10);
                            }
                        }
                    }
                    catch { }
                }
                foreach (Control item in pan.Controls)
                {
                    //foreach (MA_RfidPoint rfid in Common.rfidDt.Values)
                    //{
                    //    if (item is Label && item.Name == "lblr" + rfid.RfidNo.ToString())
                    //    {
                    //        item.Location = new Point(Convert.ToInt32(rfid.RfidX * Common.sizeMapImage[this.CurrentMapNo].widthScale) - 10, Convert.ToInt32(rfid.RfidY * Common.sizeMapImage[this.CurrentMapNo].heightScale) - 10);
                    //    }
                    //}
                    foreach (StationInfo station in Common.dtStationInfo.Values)
                    {
                        if (item is Label && item.Name == "lblSP" + station.Id.ToString())
                        {
                            item.Location = new Point(Convert.ToInt32(station.LayoutInfo.Location.X * Common.sizeMapImage[this.CurrentMapNo].widthScale), Convert.ToInt32(station.LayoutInfo.Location.Y * Common.sizeMapImage[this.CurrentMapNo].heightScale));
                            //item.BringToFront();
                            item.Size = new Size(Convert.ToInt32(station.LayoutInfo.Size.X * Common.sizeMapImage[this.CurrentMapNo].widthScale), Convert.ToInt32(station.LayoutInfo.Size.Y * Common.sizeMapImage[this.CurrentMapNo].heightScale));
                        }
                    }
                }
                //当电子地图Size改变时，更新Agv Model的Size
                foreach (Panel item in agvModel.Values)
                {
                    if (item.BackgroundImage != null)
                    {
                        item.Size = new Size(Convert.ToInt32(item.BackgroundImage.Width * Common.sizeMapImage[this.CurrentMapNo].widthScale), Convert.ToInt32(item.BackgroundImage.Height * Common.sizeMapImage[this.CurrentMapNo].heightScale));
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }
        private void ObtainSizeScaleImage() //获取电子地图与pictureBox的比例
        {
            foreach (int item in mapShow.Keys)
            {
                Common.sizeMapImage[item] = new SizeScale();
                Common.sizeMapImage[item].Width = mapShow[item].BackgroundImage.Width;
                Common.sizeMapImage[item].Height = mapShow[item].BackgroundImage.Height;
                Common.sizeMapImage[item].widthScale = ((float)mapShow[item].Width) / ((float)mapShow[item].BackgroundImage.Width);
                Common.sizeMapImage[item].heightScale = ((float)mapShow[item].Height) / ((float)mapShow[item].BackgroundImage.Height);
            }
        }
        private bool IsOutPanTabMap(Point movePoint, int i) //判断panTabMapShow的拖动是否已经超出指定范围，若超出则不能移动
        {
            bool x = false;
            bool y = false;
            if (movePoint.X > 0)
            {
                if (mapShow[i].Left > 0)
                {
                    x = false;
                }
                else
                {
                    x = true;
                }
            }
            else if (movePoint.X < 0)
            {
                if (mapShow[i].Right < panTabMap.Width)
                {
                    x = false;
                }
                else
                {
                    x = true;
                }
            }
            else
            {
                x = true;
            }
            if (movePoint.Y > 0)
            {
                if (mapShow[i].Top > 0)
                {
                    y = false;
                }
                else
                {
                    y = true;
                }
            }
            else if (movePoint.Y < 0)
            {
                if (mapShow[i].Bottom < panTabMap.Height)
                {
                    y = false;
                }
                else
                {
                    y = true;
                }
            }
            else
            {
                y = true;
            }
            if (x && y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void mnutlpAgvChnage_Click(object sender, EventArgs e)  //设定Agv状态灯的排列方式
        {
            try
            {
                int row = Convert.ToInt32(mnutlpAgvRow.Text);
                int col = Convert.ToInt32(mnutlpAgvCol.Text);
                tlpAgvLight.RowCount = row;
                tlpAgvLight.ColumnCount = col;
                Common.agvstatusLayout.X = col;
                Common.agvstatusLayout.Y = row;
            }
            catch
            { }
        }
        private void tlpAgvLight_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseDownAgvPoint.X = Cursor.Position.X;
                mouseDownAgvPoint.Y = Cursor.Position.Y;
                isLeftMouseAgvLight = true;
            }
        }   //tlpAgvLight控件的拖动
        private void tlpAgvLight_MouseUp(object sender, MouseEventArgs e)
        {
            isLeftMouseAgvLight = false;
            Debug.Print(string.Format("X:{0},Y:{1},tlp X:{2},Y:{3}", Common.tlpPoint.X, Common.tlpPoint.Y, tlpAgvLight.Left, tlpAgvLight.Top));
        }
        private void tlpAgvLight_MouseMove(object sender, MouseEventArgs e)
        {
            if (isLeftMouseAgvLight)
            {
                Point movPoint = new Point();
                movPoint.X = Cursor.Position.X - mouseDownAgvPoint.X;
                movPoint.Y = Cursor.Position.Y - mouseDownAgvPoint.Y;
                mouseDownAgvPoint.X = Cursor.Position.X;
                mouseDownAgvPoint.Y = Cursor.Position.Y;
                tlpAgvLight.Left += movPoint.X;
                tlpAgvLight.Top += movPoint.Y;
                Common.tlpPoint.X = tlpAgvLight.Left;// / Common.sizeMapImage.widthScale);
                Common.tlpPoint.Y = tlpAgvLight.Top;// / Common.sizeMapImage.heightScale);
            }
        }
        #endregion //电子地图缩放、拖动

        #region 创建Agv状态灯、AGV模型
        private void CreateAgvPictureBx()
        {
            tlpAgvLight.Controls.Clear();
            int count = 0;

            //tlpAgvLight.RowCount = 1;
            //tlpAgvLight.ColumnCount = maaciList.Count;
            mnutlpAgvRow.Text = tlpAgvLight.RowCount.ToString();
            mnutlpAgvCol.Text = tlpAgvLight.ColumnCount.ToString();
            if (Common.tlpPoint != null)
            {
                tlpAgvLight.Location = new Point(Common.tlpPoint.X, Common.tlpPoint.Y);
            }
            else
            {
                tlpAgvLight.Location = new Point(0, 0);
            }
            this._agvNoList.Clear();
            showInfo.Clear();
            double dAgvCount = 1;
            if (maaciList.Count > 0)
                dAgvCount = maaciList.Count;
            double interval = (100 - WaitForm.pValue - 5) / ((double)dAgvCount);
            double addIn = WaitForm.pValue;
            for (int i = 0; i < maaciList.Count; i++)
            {
                if (maaciList[i].A_IsUsing)
                {
                    try
                    {
                        this._agvNoList.Add(maaciList[i].A_Id);
                        Dictionary<Enumerations.LabelType, DoubleLabel> statusInfo = new Dictionary<Enumerations.LabelType, DoubleLabel>();
                        //状态灯
                        TableLayoutPanel tlp = new TableLayoutPanel();
                        //tlp.BackColor = this.lineColor[maaciList[i].A_Id - 1];
                        tlp.Margin = new Padding(3, 0, 0, 0);
                        tlp.AutoSize = true;
                        tlp.RowCount = 1;
                        tlp.ColumnCount = 9;
                        //状态显示灯
                        DoubleLabel lbl = new DoubleLabel();
                        lbl.Size = new Size(30, 40);
                        lbl.Label1Height = 40;
                        lbl.Label1BackColor = Color.Gainsboro;
                        lbl.Label1Image = Properties.Resources.line;
                        lbl.Label1ImageAlign = ContentAlignment.MiddleCenter;
                        lbl.Text = maaciList[i].A_Id.ToString();// +"#";
                        lbl.Label1TextAlign = ContentAlignment.MiddleCenter;
                        lbl.Name = "lblAgvStu" + maaciList[i].A_Id.ToString();
                        lbl.Label1Font = new Font("宋体", 10.5f, FontStyle.Bold);
                        lbl.Margin = new Padding(0);
                        lbl.Parent = tlp;
                        statusInfo[Enumerations.LabelType.AgvStatusLight] = lbl;
                        //Agv类型
                        DoubleLabel lblType = new DoubleLabel();
                        lblType.Size = new Size(80, 40);
                        lblType.Label1BackColor = Color.Gainsboro;
                        lblType.Label1Height = 40;
                        lblType.Label1TextAlign = ContentAlignment.MiddleCenter;
                        lblType.Name = "lblAgvType" + maaciList[i].A_Id.ToString();
                        lblType.Label1Font = new Font("宋体", 10.5f, FontStyle.Bold);
                        lblType.Margin = new Padding(0);
                        lblType.Parent = tlp;
                        statusInfo[Enumerations.LabelType.AgvType] = lblType;
                        //RFID卡号
                        DoubleLabel lblRfid = new DoubleLabel();
                        lblRfid.Size = new Size(60, 40);
                        lblRfid.Label1Height = 20;
                        lblRfid.Label1TextAlign = lblRfid.Label2TextAlign = ContentAlignment.MiddleLeft;
                        lblRfid.Name = "lblRfid" + maaciList[i].ToString();
                        lblRfid.Label1Font = lblRfid.Label2Font = new Font("宋体", 9f, FontStyle.Regular);
                        lblRfid.Label1Margin = lblRfid.Label2Margin = new Padding(0);
                        lblRfid.Label1BackColor = Color.Gainsboro;
                        lblRfid.Label2BackColor = Color.White;
                        lblRfid.Margin = new Padding(0);
                        lblRfid.Parent = tlp;
                        lblRfid.Tag = maaciList[i].A_Id;
                        lblRfid.DoubleClick += lblRfid_DoubleClick;
                        lblRfid.Label2.Tag = lblRfid.Tag;
                        lblRfid.Label2.DoubleClick += lblRfid_DoubleClick;
                        statusInfo[Enumerations.LabelType.AgvRfid] = lblRfid;
                        //Agv状态显示
                        DoubleLabel lblAgvAbn = new DoubleLabel();
                        lblAgvAbn.Size = new Size(100, 40);
                        lblAgvAbn.Label1Height = 40;
                        lblAgvAbn.Label1BackColor = Color.Gainsboro;
                        lblAgvAbn.Label1TextAlign = ContentAlignment.MiddleCenter;
                        lblAgvAbn.Name = "lblAgvPos" + maaciList[i].ToString();
                        lblAgvAbn.Label1Font = new Font("宋体", 10.5f, FontStyle.Bold);
                        lblAgvAbn.Margin = new Padding(0);
                        lblAgvAbn.Parent = tlp;
                        statusInfo[Enumerations.LabelType.AgvStatus] = lblAgvAbn;
                        //Agv当前任务
                        DoubleLabel lblTask1 = new DoubleLabel();
                        lblTask1.Size = new Size(120, 40);
                        lblTask1.Label1Height = 20;
                        lblTask1.Label1TextAlign = lblTask1.Label2TextAlign = ContentAlignment.MiddleLeft;
                        lblTask1.Name = "lblTask1" + maaciList[i].ToString();
                        lblTask1.Label1Font = lblTask1.Label2Font = new Font("宋体", 9f, FontStyle.Regular);
                        lblTask1.Label1BackColor = Color.Gainsboro;
                        lblTask1.Label2BackColor = Color.White;
                        lblTask1.Margin = new Padding(0);
                        lblTask1.Parent = tlp;
                        statusInfo[Enumerations.LabelType.CurrentTask] = lblTask1;
                        //Agv预定任务
                        DoubleLabel lblTask2 = new DoubleLabel();
                        lblTask2.Size = new Size(120, 40);
                        lblTask2.Label1Height = 20;
                        lblTask2.Label1TextAlign = lblTask2.Label2TextAlign = ContentAlignment.MiddleLeft;
                        lblTask2.Name = "lblTask2" + maaciList[i].ToString();
                        lblTask2.Label1Font = lblTask2.Label2Font = new Font("宋体", 9f, FontStyle.Regular);
                        lblTask2.Label1BackColor = Color.Gainsboro;
                        lblTask2.Label2BackColor = Color.White;
                        lblTask2.Margin = new Padding(0);
                        lblTask2.Parent = tlp;
                        statusInfo[Enumerations.LabelType.BookTask] = lblTask2;
                        //Agv电压，牵引棒状态
                        DoubleLabel lblStation = new DoubleLabel();
                        lblStation.Size = new Size(120, 40);
                        lblStation.Label1Height = 20;
                        lblStation.Label1TextAlign = lblStation.Label2TextAlign = ContentAlignment.MiddleLeft;
                        lblStation.Name = "lblStation" + maaciList[i].ToString();
                        lblStation.Label1Font = lblStation.Label2Font = new Font("宋体", 9f, FontStyle.Regular);
                        lblStation.Label1BackColor = Color.Gainsboro;
                        lblStation.Label2BackColor = Color.White;
                        lblStation.Margin = new Padding(0);
                        lblStation.Parent = tlp;
                        lblStation.Tag = maaciList[i].A_Id;
                        lblStation.DoubleClick += lblStation_DoubleClick;
                        lblStation.Label1.Tag = maaciList[i].A_Id;
                        lblStation.Label1.DoubleClick += lblStation_DoubleClick;
                        statusInfo[Enumerations.LabelType.VolAndPull] = lblStation;
                        tlp.Parent = tlpAgvLight;
                        //Agv料点号
                        DoubleLabel lblPallet = new DoubleLabel();
                        lblPallet.Size = new Size(70, 40);
                        lblPallet.Label1Height = 20;
                        lblPallet.Label1TextAlign = lblPallet.Label2TextAlign = ContentAlignment.MiddleLeft;
                        lblPallet.Name = "lblPallet" + maaciList[i].ToString();
                        lblPallet.Label1Font = lblPallet.Label2Font = new Font("宋体", 9f, FontStyle.Regular);
                        lblPallet.Label1BackColor = Color.Gainsboro;
                        lblPallet.Label2BackColor = Color.White;
                        lblPallet.Margin = new Padding(0);
                        lblPallet.Parent = tlp;
                        lblPallet.Label2.Tag = lblRfid.Tag;
                        lblPallet.Label2.DoubleClick += lblPallet_DoubleClick;
                        statusInfo[Enumerations.LabelType.Station] = lblPallet;
                        tlp.Parent = tlpAgvLight;
                        //Agv方向 空闲标志
                        DoubleLabel lblDir = new DoubleLabel();
                        lblDir.Size = new Size(80, 40);
                        lblDir.Label1Height = 20;
                        lblDir.Label1TextAlign = lblDir.Label2TextAlign = ContentAlignment.MiddleLeft;
                        lblDir.Name = "lblDir" + maaciList[i].ToString();
                        lblDir.Label1Font = lblDir.Label2Font = new Font("宋体", 9f, FontStyle.Regular);
                        lblDir.Label1BackColor = Color.Gainsboro;
                        lblDir.Label2BackColor = Color.White;
                        lblDir.Margin = new Padding(0);
                        lblDir.Parent = tlp;
                        statusInfo[Enumerations.LabelType.DirAndBusy] = lblDir;
                        tlp.Parent = tlpAgvLight;
                        this.showInfo[maaciList[i].A_Id] = statusInfo;

                        #region 按钮
                        //Panel panRun = new Panel();
                        //panRun.Size = new System.Drawing.Size(60, 40);
                        //panRun.Margin = new System.Windows.Forms.Padding(0);
                        //panRun.Parent = tlp;
                        ////前进
                        //Button btnForward = new Button();
                        //btnForward.Dock = DockStyle.Top;
                        //btnForward.Text = "forward";
                        //btnForward.Click += btnForward_Click;
                        //btnForward.Font = new Font("宋体", 9f, FontStyle.Regular);
                        //btnForward.Parent = panRun;
                        //btnForward.Size = new Size(60, 20);
                        //btnForward.Tag = maaciList[i].A_Id;
                        //btnForward.Margin = new System.Windows.Forms.Padding(0);
                        ////后退
                        //Button btnBack = new Button();
                        //btnBack.Dock = DockStyle.Bottom;
                        //btnBack.Text = "retreat";
                        //btnBack.Click += btnBack_Click;
                        //btnBack.Font = new Font("宋体", 9f, FontStyle.Regular);
                        //btnBack.Parent = panRun;
                        //btnBack.Size = new Size(60, 20);
                        //btnBack.Tag = maaciList[i].A_Id;
                        //btnBack.Margin = new System.Windows.Forms.Padding(0);

                        //Panel panOprate = new Panel();
                        //panOprate.Size = new System.Drawing.Size(60, 40);
                        //panOprate.Margin = new System.Windows.Forms.Padding(0);
                        //panOprate.Parent = tlp;
                        ////复位
                        //Button btnRest = new Button();
                        //btnRest.Dock = DockStyle.Top;
                        //btnRest.Text = "rest";
                        //btnRest.Click += btnRest_Click;
                        //btnRest.Font = new Font("宋体", 9f, FontStyle.Regular);
                        //btnRest.Parent = panOprate;
                        //btnRest.Size = new Size(60, 20);
                        //btnRest.Tag = maaciList[i].A_Id;
                        //btnRest.Margin = new System.Windows.Forms.Padding(0);
                        ////停止
                        //Button btnStop = new Button();
                        //btnStop.Dock = DockStyle.Bottom;
                        //btnStop.Text = "stop";
                        //btnStop.Click += btnStop_Click;
                        //btnStop.Font = new Font("宋体", 9f, FontStyle.Regular);
                        //btnStop.Parent = panOprate;
                        //btnStop.Size = new Size(60, 20);
                        //btnStop.Tag = maaciList[i].A_Id;
                        //btnStop.Margin = new System.Windows.Forms.Padding(0);

                        //Panel panPull = new Panel();
                        //panPull.Size = new System.Drawing.Size(40, 40);
                        //panPull.Margin = new System.Windows.Forms.Padding(0);
                        //panPull.Parent = tlp;
                        ////举升
                        //Button btnUp = new Button();
                        //btnUp.Dock = DockStyle.Top;
                        //btnUp.Text = "举升";
                        //btnUp.Click += btnUp_Click;
                        //btnUp.Font = new Font("宋体", 9f, FontStyle.Regular);
                        //btnUp.Parent = panPull;
                        //btnUp.Size = new Size(40, 20);
                        //btnUp.Tag = maaciList[i].A_Id;
                        //btnUp.Margin = new System.Windows.Forms.Padding(0);
                        ////下降
                        //Button btnDown = new Button();
                        //btnDown.Dock = DockStyle.Bottom;
                        //btnDown.Text = "下降";
                        //btnDown.Click += btnDown_Click;
                        //btnDown.Font = new Font("宋体", 9f, FontStyle.Regular);
                        //btnDown.Parent = panPull;
                        //btnDown.Size = new Size(40, 20);
                        //btnDown.Tag = maaciList[i].A_Id;
                        //btnDown.Margin = new System.Windows.Forms.Padding(0); 
                        #endregion
                        count += 1;
                    }
                    catch
                    {

                    }
                    try
                    {
                        Panel panAgv = new Panel();
                        string path = Common.Instance.SourcePath + @"\Information\agv.gif";  //@"\Information
                        Image agvImage;
                        if (File.Exists(path))
                        {
                            Bitmap bpm = new Bitmap(path);
                            agvImage = (Image)bpm;
                            //agvImage.
                            panAgv.BackgroundImage = agvImage;
                            panAgv.Size = new Size(Convert.ToInt32(agvImage.Width * Common.sizeMapImage[this.CurrentMapNo].widthScale), Convert.ToInt32(agvImage.Height * Common.sizeMapImage[this.CurrentMapNo].heightScale));
                        }

                        panAgv.BackgroundImageLayout = ImageLayout.Stretch;
                        panAgv.Location = new Point(-50, -50);
                        panAgv.BackColor = Color.Transparent;
                        panAgv.Name = "agvModel" + maaciList[i].A_Id.ToString();
                        Label lbl_ = new Label();
                        //lbl_.Text = maaciList[i].A_Id.ToString() + "#";
                        lbl_.Text = maaciList[i].A_Id.ToString();
                        lbl_.Dock = DockStyle.Fill;
                        lbl_.TextAlign = ContentAlignment.MiddleCenter;
                        lbl_.AutoSize = false;
                        lbl_.BackColor = Color.Transparent;
                        lbl_.Font = new Font("宋体", 9f, FontStyle.Bold);
                        lbl_.Parent = panAgv;
                        lbl_.Tag = maaciList[i].A_Id;
                        lbl_.MouseMove += lbl__MouseMove;
                        lbl_.MouseLeave += lbl__MouseLeave;
                        //lbl_.MouseClick += lbl__MouseClick;
                        panAgv.Parent = mapShow[CurrentMapNo];
                        agvModel[maaciList[i].A_Id] = panAgv;
                    }
                    catch
                    { }
                }
                addIn += interval;
                WaitForm.pValue = (int)addIn;
                WaitFormService.SetContents(string.Format("[Agv{0}]状态控件生成完毕...", maaciList[i].A_Id));
            }
        }

        private void lblPallet_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                int agvNo = Convert.ToInt32(lbl.Tag);
                if (Common.maiDict[agvNo].QuestPass)
                {
                    if (MessageBox.Show(string.Format("Is manual release Agv{0}?", agvNo), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.Pass);
                    }
                }
            }
            catch { }
        }

        void lblRfid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                int agvNo = Convert.ToInt32(lbl.Tag);
                if (MessageBox.Show(string.Format("Is clear Agv{0}'s Rfid?", agvNo), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    Common.maiDict[agvNo].Rfid = -1;
                    Common.maiDict[agvNo].ControlRfid = -1;
                    Common.maiDict[agvNo].ControlRfid2 = -1;
                    while (Common.controlPointsStatus.Any(o => o.Value == agvNo))
                    {
                        try
                        {
                            int id = Common.controlPointsStatus.First(o => o.Value == agvNo).Key;
                            Common.controlPointsStatus[id] = -1;
                        }
                        catch { }
                    }
                    while (Common.controlPointAgvList.Any(o => o.Value.Contains(agvNo)))
                    {
                        try
                        {
                            int id = Common.controlPointAgvList.First(o => o.Value.Contains(agvNo)).Key;
                            Common.controlPointAgvList[id].Remove(agvNo);
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }

        void lbl__MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                int agvNo = Convert.ToInt32(lbl.Tag);
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    if (AgvState.CurrentForm == null)
                    {
                        AgvState agvForm = new AgvState(agvNo);
                        agvForm.BringToFront();
                        try
                        {
                            agvForm.ShowDialog();
                        }
                        finally
                        {
                            agvForm.Dispose();
                        }
                    }
                    else
                    {
                        AgvState.CurrentForm.Close();
                        AgvState agvForm = new AgvState(agvNo);
                        agvForm.BringToFront();
                        try
                        {
                            agvForm.ShowDialog();
                        }
                        finally
                        {
                            agvForm.Dispose();
                        }
                    }
                }
            }
            catch { }
        }

        void lbl__MouseLeave(object sender, EventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                int agvNo = Convert.ToInt32(lbl.Tag);
                if (tipAgvNo == agvNo) tipAgvNo = 0;
            }
            catch { }
        }

        void lbl__MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                int agvNo = Convert.ToInt32(lbl.Tag);
                if (agvNo != tipAgvNo)
                {
                    string volStr = string.Empty;
                    if (Common.maiDict[agvNo].Voltage > 0)
                    {
                        volStr = string.Format("{0}.{1}V", Common.maiDict[agvNo].Voltage / 10, Common.maiDict[agvNo].Voltage % 10);
                    }
                    switch (Common.maiDict[agvNo].VoltageStatus)
                    {
                        case Enumerations.voltageStatus.normal:
                            break;
                        case Enumerations.voltageStatus.chargVoltage:
                            volStr += "|low voltage";
                            break;
                        case Enumerations.voltageStatus.lowVoltage:
                            volStr += "|low voltage";
                            break;
                    }
                    if (Common.maiDict[agvNo].Default4 > 0)
                        volStr += string.Format("|{0}s", Common.maiDict[agvNo].Default4);
                    string robotStr = "unknown";
                    try
                    {
                        robotStr = Common.Instance.dtRobotState[Common.maiDict[agvNo].RobotState];
                    }
                    catch { }
                    string contents = string.Format("Id : Agv{0}\r\nState : {1}\r\nRFID : {2}\r\nVol : {3}\r\nTask : {4}\r\nLoad : {5}\r\nUnload : {6}\r\nQuestPass: {7}\r\nIsPass: {8}\r\nArrived: {9}\r\nIsPassPlatform: {10}\r\nIsTask: {11}\r\nOperationComplete: {12}", agvNo, this.showInfo[agvNo][Enumerations.LabelType.AgvStatus].Label1Text, Common.maiDict[agvNo].Rfid, volStr, Common.maiDict[agvNo].Task1, Common.maiDict[agvNo].Default7, Common.maiDict[agvNo].Default8, Common.maiDict[agvNo].QuestPass, Common.maiDict[agvNo].IsPass, Common.maiDict[agvNo].Arrived, Common.maiDict[agvNo].IsPassPlatform, Common.maiDict[agvNo].IsCanReceiveTask, Common.maiDict[agvNo].OperationComplete);
                    tooltip.Dispose();
                    tooltip = new ToolTip();
                    tooltip.BackColor = agvModel[agvNo].BackColor;
                    tooltip.SetToolTip(lbl, contents);
                    tipAgvNo = agvNo;
                }
            }
            catch { }
        }
        //双击电压控件是
        void lblStation_DoubleClick(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            try
            {
                int agvNo = Convert.ToInt32(lbl.Tag);
                if (Common.maiDict[agvNo].VoltageStatus == Enumerations.voltageStatus.chargVoltage)
                {
                    if (MessageBox.Show(string.Format("Is clear AGV{0} charging flag", agvNo), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        lock (Common.maiDict[agvNo])
                            Common.maiDict[agvNo].VoltageStatus = Enumerations.voltageStatus.normal;
                    }
                }
                else if (Common.maiDict[agvNo].VoltageStatus == Enumerations.voltageStatus.lowVoltage)
                {
                    if (MessageBox.Show(string.Format("Is clear AGV{0} low voltage flag", agvNo), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        lock (Common.maiDict[agvNo])
                            Common.maiDict[agvNo].VoltageStatus = Enumerations.voltageStatus.normal;
                    }
                }
                else if (Common.maiDict[agvNo].VoltageStatus == Enumerations.voltageStatus.normal)
                {
                    if (MessageBox.Show(string.Format("Is set AGV{0} charging flag", agvNo), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        lock (Common.maiDict[agvNo])
                        {
                            Common.maiDict[agvNo].VoltageStatus = Enumerations.voltageStatus.chargVoltage;
                            Common.maiDict[agvNo].IsChargeFullTime = false;
                        }
                    }
                }
            }
            catch { }
        }

        #region 手动操作
        void btnDown_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                int agvNo = (int)btn.Tag;
                if (MessageBox.Show(string.Format("是否对[AGV{0}]执行牵引棒下降动作？", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.PullDown, new int[] { Common.maiDict[agvNo].Rfid, 2 });
            }
            catch { }
        }

        void btnUp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                int agvNo = (int)btn.Tag;
                if (MessageBox.Show(string.Format("是否对[AGV{0}]执行牵引棒举升动作？", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.PullUp, new int[] { Common.maiDict[agvNo].Rfid, 1 });
            }
            catch { }
        }

        void btnStop_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                int agvNo = (int)btn.Tag;
                //if (MessageBox.Show(string.Format("是否对[AGV{0}]执行停止动作？", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.Stop);
            }
            catch { }
        }

        void btnRest_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                int agvNo = (int)btn.Tag;
                if (MessageBox.Show(string.Format("IS [AGV{0}] rest？", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.Rest);
            }
            catch { }
        }

        void btnBack_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                int agvNo = (int)btn.Tag;
                if (MessageBox.Show(string.Format("Is [AGV{0}] retreat？", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.Back);
            }
            catch { }
        }

        void btnForward_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                int agvNo = (int)btn.Tag;
                if (MessageBox.Show(string.Format("IS [AGV{0}] forward？", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.Forward);
            }
            catch { }
        }
        #endregion
        #endregion //创建Agv状态灯、AGV模型

        #region 判断是否显示Rfid坐标label
        private void IsRfidVisible(bool isShow)
        {
            try
            {
                try
                {
                    if (isLOadOk)
                    {
                        LoadingFormService.Show();
                        if (isShow)
                            LoadingFormService.SetText("RFID loading，please wait a moment");
                        else
                            LoadingFormService.SetText("RFID removing，please wait a moment");
                    }
                }
                catch { }
                //foreach (int i in mapShow.Keys)
                //{
                //Label lblSreen = new Label();
                //lblSreen.Dock = DockStyle.Fill;
                //lblSreen.Text = "正在刷新界面，请稍候！";
                //lblSreen.TextAlign = ContentAlignment.MiddleCenter;
                //lblSreen.Parent = mapShow[i];
                if (isShow)
                {
                    if (!Common.isRfidVisible)
                    {
                        foreach (int item in rfidLabelDt.Keys)
                        {
                            try
                            {
                                if (rfidLabelDt[item].Parent == null)
                                {
                                    if (Common.rfidDt.ContainsKey(item))
                                    {
                                        rfidLabelDt[item].Parent = this.mapShow[Common.rfidDt[item].MapNo];
                                        rfidLabelDt[item].Visible = true;
                                    }
                                }
                            }
                            catch { }
                        }
                        //foreach (Control item in mapShow[i].Controls)
                        //{
                        //    foreach (MA_RfidPoint rf in Common.rfidDt.Values)
                        //    {
                        //        if (item is Label && item.Name == "lblr" + rf.RfidNo.ToString())
                        //        {
                        //            item.Visible = true;
                        //        }
                        //    }
                        //}
                        //Common.isRfidVisible = true;
                    }
                }
                else
                {
                    if (Common.isRfidVisible)
                    {
                        foreach (int item in rfidLabelDt.Keys)
                        {
                            rfidLabelDt[item].Parent = null;
                            rfidLabelDt[item].Visible = false;
                        }
                        //foreach (Control item in mapShow[i].Controls)
                        //{
                        //    foreach (MA_RfidPoint rf in Common.rfidDt.Values)
                        //    {
                        //        if (item is Label && item.Name == "lblr" + rf.RfidNo.ToString())
                        //        {
                        //            item.Visible = false;
                        //        }
                        //    }
                        //}
                        //Common.isRfidVisible = false;
                    }
                }
                //if (mapShow[i].Controls.Contains(lblSreen))
                //{
                //    mapShow[i].Controls.Remove(lblSreen);
                //}
                //}
                if (isShow != Common.isRfidVisible)
                {
                    Common.isRfidVisible = !Common.isRfidVisible;
                }
                if (isLOadOk)
                    LoadingFormService.Close();
            }
            catch { }
        }
        #endregion //判断是否显示Rfid坐标label

        #region 最短路径测试
        private void btnShortPath_Click(object sender, EventArgs e)
        {
            DijkstraSolution dij = new DijkstraSolution();
            int startId = Convert.ToInt32(txtStartId.Text);
            int endId = Convert.ToInt32(txtEndId.Text);
            List<int> lsPoints = dij.FindRfid(startId, endId);
            txtPathShow.Text = string.Join("->", lsPoints);
            //string startId = txtStartId.Text;
            //string endId = txtEndId.Text;
            //List<ILine> lsResult = new List<ILine>();
            //if (RoadFinder.CalculatePath(startId, endId, out lsResult))
            //{
            //    txtPathShow.Clear();
            //    foreach (ILine item in lsResult)
            //    {
            //        txtPathShow.Text += item + "\r\n";
            //    }
            //}
        }
        #endregion //最短路径测试

        #region 数据库连接参数
        private void btnConfigSqlRec_Click(object sender, EventArgs e)
        {
            lock (Common.lsXmlPParameter)
            {
                try
                {
                    txtConfigSqlAddress.Text = Common.sqlCommInfo.Address;
                    txtConfigSqlDatabase.Text = Common.sqlCommInfo.Database;
                    txtConfigUserName.Text = Common.sqlCommInfo.Name;
                    txtConfigSqlUserPwd.Text = Common.sqlCommInfo.Passward;
                }
                catch
                {

                }
            }
        }

        private void btnConfigSqlRef_Click(object sender, EventArgs e)
        {
            try
            {
                Common.sqlCommInfo.Address = txtConfigSqlAddress.Text;
                Common.sqlCommInfo.Database = txtConfigSqlDatabase.Text;
                Common.sqlCommInfo.Name = txtConfigUserName.Text;
                Common.sqlCommInfo.Passward = txtConfigSqlUserPwd.Text;
                MessageBox.Show("Update successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Update Failed!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void btnConfigDataType_Click(object sender, EventArgs e)
        {
            try
            {
                KeyValuePair<int, string> item = new KeyValuePair<int, string>();
                item = (KeyValuePair<int, string>)cbConfigDataType.SelectedItem;
                if (item.Key != Common.dataSaveType)
                {
                    if (MessageBox.Show("Whether to modify database type?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Common.dataSaveType = item.Key;
                        MessageBox.Show("Update successfully!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        CloseForm();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Unknown error", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void tabConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbChargeType.SelectedIndex = 0;
            if (nextControlList.Count > 0)
            {
                string strs = string.Join(",", nextControlList.ToArray());
                txtConfigControlPoint.Text = strs;
            }
            txtConfigControlNo.Text = this.controlListNo.ToString();
            Common.dataType.AddRange(new KeyValuePair<int, string>[] { new KeyValuePair<int, string>((int)Enumerations.DataType.SqlLite, "SqlLite"), new KeyValuePair<int, string>((int)Enumerations.DataType.MsSql, "MsSql") });
            cbConfigDataType.DataSource = Common.dataType;
            cbConfigDataType.DisplayMember = "value";
            cbConfigDataType.ValueMember = "key";
            cbConfigDataType.SelectedValue = Common.dataSaveType;
            //电子地图下拉框更新
            List<KeyValuePair<int, string>> ls = new List<KeyValuePair<int, string>>();
            foreach (int item in mapShow.Keys)
            {
                KeyValuePair<int, string> kvp = new KeyValuePair<int, string>(item, mapShow[item].Name);
                ls.Add(kvp);
            }
            cbMapSel.DataSource = ls;
            cbMapSel.DisplayMember = "value";
            cbMapSel.ValueMember = "key";
            if (cbMapSel.Items.Count > 0)
            {
                cbMapSel.SelectedIndex = 0;
            }
            cbChargeEnable.SelectedIndex = 0;
            cbShutterDoorEnable.SelectedIndex = 0;
            cbElevatorEnable.SelectedIndex = 0;
            cbStationEnable.SelectedIndex = 0;
            txtGroupMesTask.Text = Common.bufferGroup.ToString();
            txtTestSubStayTime.Text = (((double)Common.subStayTime) / 1000).ToString();
            try
            {
                txtCapacityTestLeftLoad.Text = Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftLoad].ToString();
                txtCapacityTestRightLoad.Text = Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightLoad].ToString();
                txtCapacityTestLeftUnload.Text = Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftUnload].ToString();
                txtCapacityTestRightUnload.Text = Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightUnload].ToString();
                txtCapacityTestLeftRefueling.Text = Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftRefueling].ToString();
                txtCapacityTestRightRefueling.Text = Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightRefueling].ToString();
            }
            catch { }
            try
            {
                txtCapacityTestWait1Rfid.Text = Common.Instance.dtCapacityTestWait[1].Rfid.ToString();
                string stationsStr = string.Empty;
                foreach (point item in Common.Instance.dtCapacityTestWait[1].lsStations)
                {
                    stationsStr += string.Format("{0}_{1},", item.X, item.Y);
                }
                txtCapacityTestWait1Stations.Text = stationsStr;
                string rfidsStr = string.Empty;
                foreach (point item in Common.Instance.dtCapacityTestWait[1].lsRfids)
                {
                    rfidsStr += string.Format("{0}_{1},", item.X, item.Y);
                }
                txtCapacityTestWait1Rfids.Text = rfidsStr;
            }
            catch { }
            try
            {
                txtCapacityTestWait2Rfid.Text = Common.Instance.dtCapacityTestWait[2].Rfid.ToString();
                string stationsStr = string.Empty;
                foreach (point item in Common.Instance.dtCapacityTestWait[2].lsStations)
                {
                    stationsStr += string.Format("{0}_{1},", item.X, item.Y);
                }
                txtCapacityTestWait2Stations.Text = stationsStr;
                string rfidsStr = string.Empty;
                foreach (point item in Common.Instance.dtCapacityTestWait[2].lsRfids)
                {
                    rfidsStr += string.Format("{0}_{1},", item.X, item.Y);
                }
                txtCapacityTestWait2Rfids.Text = rfidsStr;
            }
            catch { }
        }
        #endregion //数据库连接参数

        #region AGV模型更新、导入
        private void btnConfigMapAgvModelRecevied_Click(object sender, EventArgs e)
        {
            string path = Common.Instance.SourcePath + @"\Information\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            try
            {
                picConfigMapModel.Image.Dispose();
                Image openImage = Image.FromFile(path + @"\agv_.gif");
                picConfigMapModel.Image = openImage;
            }
            catch
            {
                MessageBox.Show("AGV model falut ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfigMapAgvModelRef_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Common.Instance.SourcePath + @"\Information\agv_.gif";
                Image saveImage = picConfigMapModel.Image;
                saveImage.Save(path);
                MessageBox.Show("AGV model update successful", "NOtice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AGV model update falut", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblConfigMapModelInsert_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "打开图片文件";
            ofd.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP|*.PNG|*.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fullpath = ofd.FileName;//文件路径

                    FileStream fs = new FileStream(fullpath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    byte[] imagebytes = new byte[fs.Length];

                    BinaryReader br = new BinaryReader(fs);

                    imagebytes = br.ReadBytes(Convert.ToInt32(fs.Length));
                    MemoryStream ms = new MemoryStream(imagebytes);
                    Image backBitmap = System.Drawing.Image.FromStream(ms);
                    picConfigMapModel.Image = backBitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导入失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            try
            {
                ofd.Dispose();
            }
            catch { }
        }
        #endregion //AGV模型更新、导入

        #region 外部设定RFID、电子地图
        private void mnuSetRfid_Click(object sender, EventArgs e)
        {
            if (mnuSetRfid.Checked)
            {
                mnuInitSetAdminRfidSet.Checked = true;
                this.isRfidSet = true;
                if (mnuInitSetAdminStationSet.Checked)
                {
                    mnuInitSetAdminStationSet.Checked = false;
                    this.isStationSet = false;
                }
            }
            else
            {
                mnuInitSetAdminRfidSet.Checked = false;
                this.isRfidSet = false;
            }
        }
        private void mnuSetMapIn_Click(object sender, EventArgs e)
        {
            try
            {
                MapImport(this.CurrentMapNo);
            }
            catch { }
        }
        private void mnuSetMapOut_Click(object sender, EventArgs e)
        {
            try
            {
                MapExport(this.CurrentMapNo);
            }
            catch { }
        }
        private void mnuSetMaterialExport_Click(object sender, EventArgs e)
        {
            try
            {
                BS_MaterialInfo bmi = new BS_MaterialInfo();
                DataSet ds = bmi.QueryAllMaterialInfo();
                DataToExcel dte = new DataToExcel();
                dte.DataToExcelTable(ds.Tables[0], "Data export");
                //MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Export Failed！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mnuSetStationAddressExport_Click(object sender, EventArgs e)
        {
            try
            {
                BS_StatioinAddressInfo bsai = new BS_StatioinAddressInfo();
                DataSet ds = bsai.QueryAllStationAddressInfo();
                DataToExcel dte = new DataToExcel();
                dte.DataToExcelTable(ds.Tables[0], "Table export");
                //MessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exStationExport)
            {
                MessageBox.Show("Export failed！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mnuSetAgvSelect_Click(object sender, EventArgs e)
        {
            AgvShowForm asf = new AgvShowForm(this.maaciList);
            try
            {
                asf.ShowDialog();
            }
            finally
            {
                asf.Dispose();
            }
        }
        private void mnuSetLineNameSet_Click(object sender, EventArgs e)
        {
            TaskLineForm tlf = new TaskLineForm();
            try
            {
                tlf.ShowDialog();
            }
            finally
            {
                tlf.Dispose();
            }
        }
        private void mnuSetPositionName_Click(object sender, EventArgs e)
        {
            PositionNameForm pnf = new PositionNameForm();
            try
            {
                pnf.ShowDialog();
            }
            finally
            {
                pnf.Dispose();
            }
        }
        private void mnuSetTimeSet_Click(object sender, EventArgs e)
        {
            StationTimeForm stf = new StationTimeForm();
            try
            {
                stf.ShowDialog();
            }
            finally
            {
                stf.Dispose();
            }
        }
        private void mnuSetAgvModelSet_Click(object sender, EventArgs e)
        {
            AgvModelSetForm amsf = new AgvModelSetForm();
            try
            {
                amsf.ShowDialog();
            }
            finally
            {
                amsf.Dispose();
            }
        }
        private void mnuSetPassEnable_Click(object sender, EventArgs e)
        {
            try
            {
                //Common.Instance.passEnable = mnuSetPassEnable.Checked;
                DijkstraSolution di = new DijkstraSolution();
                di.RouteArray();
            }
            catch { }
        }
        private void mnuSetClearLoadTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否清除上一个上料任务的编号，以使系统能重新接受任务？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    Common.Instance.dtRoutePass[RouteType.CapacityLoad].TestStationNo = 0;
                }
            }
            catch { }
        }
        private void mnuSetMes_Click(object sender, EventArgs e)
        {
            try
            {
                MESForm mesForm = new MESForm();
                try
                {
                    mesForm.ShowDialog();
                }
                finally
                {
                    mesForm.Dispose();
                }
            }
            catch { }
        }
        private void mnuSetClearUnloadTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否清除上一个下料任务的编号，以使系统能重新接受任务？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    Common.Instance.dtRoutePass[RouteType.CapacityUnload].TestStationNo = 0;
                }
            }
            catch { }
        }
        private void mnuSetReceiveMesTask_Click(object sender, EventArgs e)
        {
            try
            {
                Common.Instance.isReceiveOpcTask = mnuSetReceiveMesTask.Checked;
            }
            catch { }
        }
        #endregion //外部设定RFID、电子地图

        #region 保存参数
        private void mnuSetSaveParameter_Click(object sender, EventArgs e)
        {
            Common.tlpPoint.X = tlpAgvLight.Left;
            Common.tlpPoint.Y = tlpAgvLight.Top;
            ParametersOperate.ParametersSave(true);
        }
        #endregion

        #region 当前任务操作
        private void dgvCurrentTask_MouseDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                int tag = Convert.ToInt32(dgv.Tag);
                //MessageBox.Show("测试ing.......", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                string task = dgv.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                //if (Common.taskCapacityTestDt.ContainsKey(task))
                //{
                if (MessageBox.Show("Is delete Id's [" + task + "]", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    MA_AgvTaskInfo taskInfo = new MA_AgvTaskInfo();
                    switch (tag)
                    {
                        case 1:
                            taskInfo = Common.taskDt[(int)Enumerations.agvType.type_1][task];
                            break;
                        case 2:
                            taskInfo = Common.taskDt[(int)Enumerations.agvType.type_2][task];
                            break;
                        case 3:
                            taskInfo = Common.taskDt[(int)Enumerations.agvType.type_3][task];
                            break;
                    }
                    if (taskInfo.T_AgvNo > 0)
                    {
                        try
                        {
                            if (Common.maiDict[taskInfo.T_AgvNo].Task2 == task)
                            {
                                Common.maiDict[taskInfo.T_AgvNo].Task2 = string.Empty;
                            }
                            if (Common.maiDict[taskInfo.T_AgvNo].Task1 == task)
                            {
                                Common.maiDict[taskInfo.T_AgvNo].Task1 = string.Empty;
                                if (Common.maiDict[taskInfo.T_AgvNo].IsAgvTest == false)
                                {
                                    while (Common.maiDict[taskInfo.T_AgvNo].lsRoutes.Count > 0)
                                        Common.maiDict[taskInfo.T_AgvNo].lsRoutes.Clear();
                                }
                            }
                        }
                        catch { }
                    }
                    try
                    {
                        switch (tag)
                        {
                            case 1:
                                Common.taskDt[(int)Enumerations.agvType.type_1].Remove(task);
                                break;
                            case 2:
                                Common.taskDt[(int)Enumerations.agvType.type_2].Remove(task);
                                break;
                            case 3:
                                Common.taskDt[(int)Enumerations.agvType.type_3].Remove(task);
                                break;
                        }
                    }
                    catch { }
                }
                //}
            }
            catch { }
        }
        void dgvCurrentTask_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                //if (e.Button == System.Windows.Forms.MouseButtons.Right)
                //{
                //    ListView lv = (ListView)sender;
                //    ListViewHitTestInfo lvInfo = lv.HitTest(e.X, e.Y);
                //    if (lvInfo.Item != null || lvInfo.SubItem != null)
                //    {
                //        //MessageBox.Show("测试ing.......", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //        string task = lvInfo.Item.Text;
                //        if (Common.taskCapacityTestDt.ContainsKey(task))
                //        {
                //            if (Common.taskCapacityTestDt[task].T_Status == Enumerations.TaskStatus.Accept && Common.taskCapacityTestDt[task].T_AgvNo > 0)
                //            {
                //                if (MessageBox.Show("是否要清除Id为[" + task + "]的任务所绑定的AGV", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                //                {
                //                    try
                //                    {
                //                        lock (Common.maiDict[Common.taskCapacityTestDt[task].T_AgvNo])
                //                        {
                //                            if (Common.maiDict[Common.taskCapacityTestDt[task].T_AgvNo].Task2 != string.Empty)
                //                            {
                //                                Common.maiDict[Common.taskCapacityTestDt[task].T_AgvNo].Task2 = string.Empty;
                //                                Common.taskCapacityTestDt[task].T_AgvNo = -1;
                //                            }
                //                        }
                //                    }
                //                    catch { }
                //                }
                //            }
                //        }
                //    }
                //}
            }
            catch { }
        }
        #endregion

        #region 尚未完成任务刷新
        private void RefCapTestCurrentTask()
        {
            #region 任务类型1
            try
            {
                dgvType1Task.Rows.Clear();
                List<string> lsTaskKey = Common.taskDt[(int)Enumerations.agvType.type_1].OrderBy(o => o.Value.T_CreateTime).ToDictionary(o => o.Key, p => p.Value).Keys.ToList();
                foreach (string task in lsTaskKey)
                {
                    if (Common.taskDt[(int)Enumerations.agvType.type_1].ContainsKey(task))
                    {
                        try
                        {
                            //if (Common.taskType1Dt[task].T_AgvNo > 0 && Common.taskType1Dt[task].IsTest == true)
                            //{
                            //    int _agvNo = Common.taskType1Dt[task].T_AgvNo;
                            //    try
                            //    {
                            //        if (Common.maiDict[_agvNo].Task1 != task && Common.maiDict[_agvNo].Task2 != task)
                            //        {
                            //            Common.taskType1Dt.Remove(task);
                            //        }
                            //    }
                            //    catch { }
                            //}
                            MA_AgvTaskInfo item = Common.taskDt[(int)Enumerations.agvType.type_1][task];
                            DataGridViewRow dr = new DataGridViewRow();
                            dr.CreateCells(dgvType1Task);
                            dr.Cells[0].Value = item.T_Id;
                            dr.Cells[1].Value = item.T_Description;
                            dr.Cells[2].Value = Common.Instance.dtTaskTypeName[item.T_Type];
                            if (item.T_Load > 0)
                            {
                                dr.Cells[2].Value = string.Format("{0}_{1}", Common.Instance.dtTaskTypeName[item.T_Type], item.T_Load);
                            }
                            dr.Cells[3].Value = item.T_StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                            string taskStateString = string.Empty;
                            if (item.T_State == Enumerations.TaskStatus.Accept) taskStateString = "Null";
                            else if (item.T_State == Enumerations.TaskStatus.Book) taskStateString = "Bind Agv";
                            else taskStateString = item.T_Process[item.ProcessIndex].Description + "_" + item.T_Process[item.ProcessIndex].State.ToString();
                            dr.Cells[4].Value = taskStateString;
                            dr.Cells[5].Value = item.T_AgvNo.ToString();
                            dr.Cells[6].Value = item.T_CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                            dgvType1Task.Rows.Add(dr);
                        }
                        catch { }
                    }
                }
                dgvType1Task.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            }
            catch { }
            #endregion
        }
        private void RefPreAgingCurrentTask()
        {
            #region 任务类型2
            try
            {
                dgvType2Task.Rows.Clear();
                List<string> lsTaskKey = Common.taskDt[(int)Enumerations.agvType.type_2].OrderBy(o => o.Value.T_CreateTime).ToDictionary(o => o.Key, p => p.Value).Keys.ToList();
                foreach (string task in lsTaskKey)
                {
                    if (Common.taskDt[(int)Enumerations.agvType.type_2].ContainsKey(task))
                    {
                        try
                        {
                            //if (Common.taskType2Dt[task].T_AgvNo > 0 && Common.taskType2Dt[task].IsTest == true)
                            //{
                            //    int _agvNo = Common.taskType2Dt[task].T_AgvNo;
                            //    try
                            //    {
                            //        if (Common.maiDict[_agvNo].Task1 != task && Common.maiDict[_agvNo].Task2 != task)
                            //        {
                            //            Common.taskType2Dt.Remove(task);
                            //        }
                            //    }
                            //    catch { }
                            //}
                            MA_AgvTaskInfo item = Common.taskDt[(int)Enumerations.agvType.type_2][task];
                            DataGridViewRow dr = new DataGridViewRow();
                            dr.CreateCells(dgvType2Task);
                            dr.Cells[0].Value = item.T_Id;
                            dr.Cells[1].Value = item.T_Description;
                            dr.Cells[2].Value = Common.Instance.dtTaskTypeName[item.T_Type];
                            if (item.T_Load > 0)
                            {
                                dr.Cells[2].Value = string.Format("{0}_{1}", Common.Instance.dtTaskTypeName[item.T_Type], item.T_Load);
                            }
                            dr.Cells[3].Value = item.T_StartTime.ToString("yyyy-MM-dd HH:mm:ss");
                            string taskStateString = string.Empty;
                            if (item.T_State == Enumerations.TaskStatus.Accept) taskStateString = "Null";
                            else if (item.T_State == Enumerations.TaskStatus.Book) taskStateString = "Bind Agv";
                            else taskStateString = item.T_Process[item.ProcessIndex].Description + "_" + item.T_Process[item.ProcessIndex].State.ToString();
                            dr.Cells[4].Value = taskStateString;
                            dr.Cells[5].Value = item.T_AgvNo.ToString();
                            dr.Cells[6].Value = item.T_CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                            dgvType2Task.Rows.Add(dr);
                        }
                        catch { }
                    }
                }
                dgvType2Task.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            }
            catch { }
            #endregion
        }
        private void RefCapAgingCurrentTask()
        {
            #region 任务类型3

            try
            {
                dgvType3Task.Rows.Clear();
                List<string> lsTaskKey = Common.taskDt[(int)Enumerations.agvType.type_3].OrderBy(o => o.Value.T_CreateTime).ToDictionary(o => o.Key, p => p.Value).Keys.ToList();
                foreach (string task in lsTaskKey)
                {
                    if (Common.taskDt[(int)Enumerations.agvType.type_3].ContainsKey(task))
                    {
                        try
                        {
                            MA_AgvTaskInfo item = Common.taskDt[(int)Enumerations.agvType.type_3][task];
                            DataGridViewRow dr = new DataGridViewRow();
                            dr.CreateCells(dgvType3Task);
                            dr.Cells[0].Value = item.T_Id;
                            dr.Cells[1].Value = item.T_Description;
                            dr.Cells[2].Value = Common.Instance.dtTaskTypeName[item.T_Type];
                            dr.Cells[3].Value = item.T_Process[item.ProcessIndex].Station.ToString();
                            dr.Cells[4].Value = item.T_State.ToString().Replace(Enumerations.TaskStatus.Accept.ToString(), "接受任务尚未派车").Replace(Enumerations.TaskStatus.Book.ToString(), "预定AGV").Replace(Enumerations.TaskStatus.LoadMaterial.ToString(), "前往取货点").Replace(Enumerations.TaskStatus.UnloadMaterial.ToString(), "前往卸货点").Replace(Enumerations.TaskStatus.End.ToString(), "任务结束");
                            dr.Cells[5].Value = item.T_AgvNo.ToString();
                            dr.Cells[6].Value = item.T_CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
                            dgvType3Task.Rows.Add(dr);
                        }
                        catch { }
                    }
                }
                dgvType3Task.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            }
            catch { }
            #endregion
        }
        #endregion

        #region 交通管制
        private void btnConfigControlAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int controlNo = Convert.ToInt32(txtConfigControlNo.Text);
                if (Common.controlPointsDict.ContainsKey(controlNo))
                {
                    MessageBox.Show("The id already exists", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    string[] controlPoints = txtConfigControlPoint.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    List<int> ls = new List<int>();
                    nextControlList = new List<int>();
                    for (int i = 0; i < controlPoints.Length; i++)
                    {
                        ls.Add(Convert.ToInt32(controlPoints[i]));
                        nextControlList.Add(Convert.ToInt32(controlPoints[i]) + 1);
                    }
                    Common.controlPointsDict[controlNo] = ls;
                    btnConfigControlObtain_Click(sender, e);
                    txtConfigControlPoint.Text = string.Join(",", nextControlList.ToArray());
                    this.controlListNo = controlNo;
                    this.controlListNo++;
                    txtConfigControlNo.Text = this.controlListNo.ToString();
                    Common.controlPointAgvList[controlNo] = new List<int>();
                    Common.controlPointsStatus[controlNo] = 0;
                    MessageBox.Show("Add successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch { }
        }

        private void btnConfigControlObtain_Click(object sender, EventArgs e)
        {
            try
            {
                dgvConfigControl.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvConfigControl.Rows.Clear();
                foreach (int item in Common.controlPointsDict.Keys)
                {
                    string pointStr = string.Empty;
                    for (int i = 0; i < Common.controlPointsDict[item].Count; i++)
                    {
                        pointStr += Common.controlPointsDict[item][i].ToString();
                        if (i < Common.controlPointsDict[item].Count - 1)
                        {
                            pointStr += ",";
                        }
                    }
                    DataGridViewRow dr = new DataGridViewRow();
                    dr.CreateCells(dgvConfigControl);
                    dr.Cells[0].Value = item;
                    dr.Cells[1].Value = pointStr;
                    dgvConfigControl.Rows.Add(dr);
                }
            }
            catch { }
        }

        private void dgvConfigControl_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int row = e.RowIndex;
                int col = e.ColumnIndex;
                DataGridView dgv = (DataGridView)sender;
                if (col == 2)
                {
                    if (MessageBox.Show("Whether to delete this control information?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (Common.controlPointsDict.Remove(Convert.ToInt32(dgv.Rows[row].Cells[0].Value)) && Common.controlPointAgvList.Remove(Convert.ToInt32(dgv.Rows[row].Cells[0].Value)))
                        {
                            btnConfigControlObtain_Click(sender, e);
                            MessageBox.Show("Delete successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show("Delete failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                else if (col == 3)
                {
                    if (MessageBox.Show("Whether to modify this control information?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string[] points = dgv.Rows[row].Cells[1].Value.ToString().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        try
                        {
                            List<int> ls = new List<int>();
                            for (int i = 0; i < points.Length; i++)
                            {
                                ls.Add(Convert.ToInt32(points[i]));
                            }
                            int pointNo = Convert.ToInt32(dgv.Rows[row].Cells[0].Value);
                            Common.controlPointsDict[pointNo] = ls;
                            //btnConfigControlObtain_Click(sender, e);
                            MessageBox.Show("Modify successfully", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        catch
                        {
                            MessageBox.Show("Modify failed", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }

            }
            catch { }
        }
        #endregion

        #region 窗体加载完成后事件
        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                if (Common.splitStatusHeight > 0)
                {
                    splitPanAgv.SplitterDistance = Common.splitStatusHeight;
                }
                if (Common.splitTask.X > 0)
                {
                    splitTask.SplitterDistance = Common.splitTask.X;
                }
                if (Common.splitTask.Y > 0)
                {
                    splitTaskAgingRoom.SplitterDistance = Common.splitTask.Y;
                    splitTaskAgingRoom.FixedPanel = FixedPanel.Panel1;
                }
                if (Common.splitMap.X > 0)
                {
                    splitPanAll.SplitterDistance = Common.splitMap.X;
                }
                if (Common.splitMap.Y > 0)
                {
                    splitPanMap.SplitterDistance = Common.splitMap.Y;
                    splitPanMap.FixedPanel = FixedPanel.Panel1;
                }
                this.isLOadOk = true;
                Common.isLoadedOk = true;
                //Thread.Sleep(1000);
                WaitFormService.Close();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            Debug.Print("等待窗口关闭");
        }
        #endregion

        #region 管制排除点
        //private void btnRepeatRfidRec_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtRepeatRfid.Text = string.Join(",", Common.Instance.RepeatRfids);
        //    }
        //    catch { }
        //}

        //private void btnRepeatRfidUpdate_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string[] rfidStr = txtRepeatRfid.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        //        int[] rfids = new int[rfidStr.Length];
        //        for (int i = 0; i < rfidStr.Length; i++)
        //        {
        //            rfids[i] = Convert.ToInt32(rfidStr[i]);
        //        }
        //        Common.Instance.RepeatRfids.Clear();
        //        Common.Instance.RepeatRfids.AddRange(rfids);
        //        MessageBox.Show("修改成功！");
        //    }
        //    catch
        //    {
        //        MessageBox.Show("参数格式错误，修改失败");
        //    }
        //}
        #endregion

        #region 充电阀值设定
        private void mnuSetVoltageLimited_Click(object sender, EventArgs e)
        {
            try
            {
                ChargeLimitedForm chargeLimitedForm = new ChargeLimitedForm();
                try
                {
                    chargeLimitedForm.ShowDialog();
                }
                finally
                {
                    chargeLimitedForm.Dispose();
                }
            }
            catch { }
        }
        #endregion

        #region 站点匹配
        private void btnStationRec_Click(object sender, EventArgs e)
        {
            try
            {
                dgvStation.Rows.Clear();
                foreach (int item in Common.Instance.dtStationTransform.Keys)
                {
                    DataGridViewRow dr = new DataGridViewRow();
                    dr.CreateCells(dgvStation);
                    dr.Cells[0].Value = item;
                    dr.Cells[1].Value = Common.Instance.dtStationTransform[item];
                    dgvStation.Rows.Add(dr);
                }
            }
            catch { }
        }

        private void btnStationRef_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否要对匹配进行修改？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        Common.Instance.dtStationTransform.Clear();
                        for (int i = 0; i < dgvStation.Rows.Count; i++)
                        {
                            try
                            {
                                int key = Convert.ToInt32(dgvStation.Rows[i].Cells[0].Value);
                                int value = Convert.ToInt32(dgvStation.Rows[i].Cells[1].Value);
                                //if (Common.Instance.dtStationTransform.ContainsKey(key))
                                //{
                                Common.Instance.dtStationTransform[key] = value;
                                //}
                            }
                            catch { }
                        }
                    }
                    catch { }
                }
            }
            catch { }

        }
        #endregion

        #region OPC通讯参数
        private void btnPlcClientRec_Click(object sender, EventArgs e)
        {
            try
            {
                txtOpcIp.Text = OPCClient.opcInformation.Ip;
                txtOpcHostName.Text = OPCClient.opcInformation.HostName;
            }
            catch { }
        }

        private void btnPlcClientRef_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress.Parse(txtOpcIp.Text);
                OPCClient.opcInformation.Ip = txtOpcIp.Text.Trim();
                OPCClient.opcInformation.HostName = txtOpcHostName.Text.Trim();
                MessageBox.Show("Modify successfully!");
            }
            catch
            {
                MessageBox.Show("It's not the right format");
            }
        }
        #endregion

        #region 上下料位手动放行
        private void stuLabelLoadPass_Click(object sender, EventArgs e)
        {
            try
            {
                if (Common.Instance.dtRoutePass[RouteType.CapacityLoad].OutPass)
                {
                    if (MessageBox.Show("是否将上料位放行状态清除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Common.Instance.dtRoutePass[RouteType.CapacityLoad].OutPass = false;
                    }
                }
                else
                {
                    if (MessageBox.Show("是否将上料位放行状态添加？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Common.Instance.dtRoutePass[RouteType.CapacityLoad].OutPass = true;
                    }
                }
            }
            catch { }
        }

        private void stuLabelUnloadPass_Click(object sender, EventArgs e)
        {
            try
            {
                if (Common.Instance.dtRoutePass[RouteType.CapacityUnload].OutPass)
                {
                    if (MessageBox.Show("是否将下料位放行状态清除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Common.Instance.dtRoutePass[RouteType.CapacityUnload].OutPass = false;
                    }
                }
                else
                {
                    if (MessageBox.Show("是否将下料位放行状态添加？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Common.Instance.dtRoutePass[RouteType.CapacityUnload].OutPass = true;
                    }
                }
            }
            catch { }
        }
        #endregion

        #region 充电桩配置
        private void btnChargeAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int chargeNo = Convert.ToInt32(txtChargeNo.Text);
                if (Common.Instance.dtChargeInfo.ContainsKey(chargeNo) == false)
                {
                    ChargeInfo chargeInfo = new ChargeInfo();
                    chargeInfo.ChargeNo = chargeNo;
                    chargeInfo.ChargeName = txtChargeName.Text;
                    chargeInfo.ChargeType = (EChargeType)cbChargeType.SelectedIndex;
                    chargeInfo.ChargeComm = new ChargeCommunication();
                    IPAddress ip = IPAddress.Parse(txtChargeIp.Text);
                    chargeInfo.ChargeComm.IpString = txtChargeIp.Text.Trim();
                    chargeInfo.ChargeComm.Port = Convert.ToInt32(txtChargePort.Text);
                    chargeInfo.Rfid = Convert.ToInt32(txtChargeRfid.Text);
                    chargeInfo.ChargeComm.Enable = cbChargeEnable.SelectedIndex == 0 ? true : false;
                    chargeInfo.Group = Convert.ToInt32(txtChargedescribe.Text.Trim());
                    Common.Instance.dtChargeInfo[chargeNo] = chargeInfo;
                    UpdateChargeInfo();
                }
                else
                {
                    MessageBox.Show(string.Format("Charge id[{0}] already exists.", chargeNo));
                }

            }
            catch { MessageBox.Show("Wrong format，Port、Id、Group、Bind rfid must be numeric."); }
        }

        private void btnChargeRec_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateChargeInfo();
            }
            catch { }
        }
        private void dgvChargeInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                int row = e.RowIndex;
                int col = e.ColumnIndex;
                int chargeNo = Convert.ToInt32(dgv.Rows[row].Cells[0].Value.ToString());
                if (col == 8)
                {
                    if (MessageBox.Show(string.Format("Whether to modify Charge[{0}] information？", chargeNo), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            ChargeInfo chargeInfo = new ChargeInfo();
                            chargeInfo.ChargeNo = chargeNo;
                            chargeInfo.ChargeComm = new ChargeCommunication();
                            chargeInfo.ChargeName = dgv.Rows[row].Cells[1].Value.ToString().Trim();
                            IPAddress ip = IPAddress.Parse(dgv.Rows[row].Cells[2].Value.ToString());
                            chargeInfo.ChargeComm.IpString = dgv.Rows[row].Cells[2].Value.ToString().Trim();
                            chargeInfo.ChargeComm.Port = Convert.ToInt32(dgv.Rows[row].Cells[3].Value.ToString());
                            chargeInfo.Rfid = Convert.ToInt32(dgv.Rows[row].Cells[4].Value.ToString());
                            chargeInfo.ChargeType = (EChargeType)ccbChargeType.Items.IndexOf(dgv.Rows[row].Cells[5].Value);
                            chargeInfo.ChargeComm.Enable = Convert.ToBoolean(dgv.Rows[row].Cells[6].Value);
                            chargeInfo.Group = Convert.ToInt32(dgv.Rows[row].Cells[7].Value.ToString().Trim());
                            Common.Instance.dtChargeInfo[chargeNo] = chargeInfo;
                            UpdateChargeInfo();
                            MessageBox.Show("Modify successully！");
                        }
                        catch { MessageBox.Show("Wrong format，Port、Id、Group、Bind rfid must be numeric."); }
                    }
                }
                else if (col == 9)
                {
                    if (MessageBox.Show(string.Format("Whether to delete Charge[{0}] information？", chargeNo), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        lock (Common.Instance.dtChargeInfo)
                        {
                            while (Common.Instance.dtChargeInfo.ContainsKey(chargeNo))
                            {
                                Common.Instance.dtChargeInfo.Remove(chargeNo);
                            }
                        }
                        UpdateShutterDoor();
                        MessageBox.Show("Delete successully！");
                    }
                }
            }
            catch { }
        }
        private void UpdateChargeInfo()
        {
            try
            {
                dgvChargeInfo.Rows.Clear();
                if (Common.Instance.dtChargeInfo.Count > 0)
                {
                    List<int> ls = Common.Instance.dtChargeInfo.Keys.ToList();
                    foreach (int item in ls)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dr.CreateCells(dgvChargeInfo);
                        dr.Cells[0].Value = Common.Instance.dtChargeInfo[item].ChargeNo;
                        dr.Cells[1].Value = Common.Instance.dtChargeInfo[item].ChargeName;
                        dr.Cells[2].Value = Common.Instance.dtChargeInfo[item].ChargeComm.IpString;
                        dr.Cells[3].Value = Common.Instance.dtChargeInfo[item].ChargeComm.Port;
                        dr.Cells[4].Value = Common.Instance.dtChargeInfo[item].Rfid;
                        dr.Cells[5].Value = ccbChargeType.Items[(int)Common.Instance.dtChargeInfo[item].ChargeType];
                        dr.Cells[6].Value = Common.Instance.dtChargeInfo[item].ChargeComm.Enable;
                        dr.Cells[7].Value = Common.Instance.dtChargeInfo[item].Group;
                        if (Common.Instance.dtChargeInfo[item].ChargeComm.Enable == false) dr.DefaultCellStyle.BackColor = Color.Silver;
                        dgvChargeInfo.Rows.Add(dr);
                    }
                    dgvChargeInfo.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch { }
        }
        #endregion

        #region 房门配置
        private void btnShutterDoorAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DoorInfo doorInfo = new DoorInfo();
                doorInfo.DoorComm = new DoorCommunication();
                doorInfo.DoorNo = Convert.ToInt32(txtShutterDoorNo.Text);
                if (Common.Instance.dtDoorInfo.ContainsKey(doorInfo.DoorNo) == false)
                {
                    IPAddress ip = IPAddress.Parse(txtShutterDoorIp.Text);
                    doorInfo.Name = txtShutterDoorName.Text.Trim();
                    doorInfo.DoorComm.Ip = txtShutterDoorIp.Text.Trim();
                    doorInfo.DoorComm.Port = Convert.ToInt32(txtShutterPort.Text);
                    doorInfo.StopRfids = Array.ConvertAll<string, int>(txtShutterStopRfids.Text.Split(','), s => int.Parse(s)).ToList();
                    doorInfo.CallRfids = Array.ConvertAll<string, int>(txtShutterCallRfids.Text.Split(','), s => int.Parse(s)).ToList();
                    doorInfo.DoorComm.Enable = cbShutterDoorEnable.SelectedIndex == 0 ? true : false;
                    doorInfo.Relation = Convert.ToInt32(txtShutterRelation.Text.Trim());
                    doorInfo.RelationNumber = Convert.ToByte(txtShutterRelationNumber.Text);
                    Common.Instance.dtDoorInfo[doorInfo.DoorNo] = doorInfo;
                    UpdateShutterDoor();
                }
                else
                {
                    MessageBox.Show(string.Format("房门编号{0} 已经存在，不可重复添加", doorInfo.DoorNo));
                }
            }
            catch { MessageBox.Show("输入参数格式不对，ip地址必须满足标准模式，编号和端口号必须为数值，RFID集合单个RFID请用英文逗号(',')隔开"); }
        }

        private void btnShutterDoorRec_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateShutterDoor();
            }
            catch { }
        }
        /// <summary>
        /// 刷新房门信息
        /// </summary>
        private void UpdateShutterDoor()
        {
            try
            {
                dgvShutterDoor.Rows.Clear();
                if (Common.Instance.dtDoorInfo.Count > 0)
                {
                    List<int> ls = Common.Instance.dtDoorInfo.Keys.ToList();
                    foreach (int item in ls)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dr.CreateCells(dgvShutterDoor);
                        dr.Cells[0].Value = Common.Instance.dtDoorInfo[item].DoorNo;
                        dr.Cells[1].Value = Common.Instance.dtDoorInfo[item].Name;
                        dr.Cells[2].Value = Common.Instance.dtDoorInfo[item].DoorComm.Ip;
                        dr.Cells[3].Value = Common.Instance.dtDoorInfo[item].DoorComm.Port;
                        string stopRfidsStr = string.Empty;
                        if (Common.Instance.dtDoorInfo[item].StopRfids.Count > 0)
                        {
                            stopRfidsStr = string.Join(",", Common.Instance.dtDoorInfo[item].StopRfids);
                        }
                        dr.Cells[4].Value = stopRfidsStr;
                        string callRfidsStr = string.Empty;
                        if (Common.Instance.dtDoorInfo[item].CallRfids.Count > 0)
                        {
                            callRfidsStr = string.Join(",", Common.Instance.dtDoorInfo[item].CallRfids);
                        }
                        dr.Cells[5].Value = callRfidsStr;
                        dr.Cells[6].Value = Common.Instance.dtDoorInfo[item].DoorComm.Enable;
                        dr.Cells[7].Value = Common.Instance.dtDoorInfo[item].Relation;
                        dr.Cells[8].Value = Common.Instance.dtDoorInfo[item].RelationNumber;
                        dgvShutterDoor.Rows.Add(dr);
                    }
                }
            }
            catch { }
        }
        private void dgvShutterDoor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                int row = e.RowIndex;
                int col = e.ColumnIndex;
                int doorNo = Convert.ToInt32(dgv.Rows[row].Cells[0].Value);
                if (col == 9)
                {
                    if (MessageBox.Show(string.Format("是否要对房门{0}的参数进行修改？", doorNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            DoorInfo doorInfo = new DoorInfo();
                            doorInfo.DoorComm = new DoorCommunication();
                            doorInfo.DoorNo = doorNo;
                            doorInfo.Name = dgv.Rows[row].Cells[1].Value.ToString();
                            IPAddress ip = IPAddress.Parse(dgv.Rows[row].Cells[2].Value.ToString());
                            doorInfo.DoorComm.Ip = dgv.Rows[row].Cells[2].Value.ToString().Trim();
                            doorInfo.DoorComm.Port = Convert.ToInt32(dgv.Rows[row].Cells[3].Value.ToString());
                            doorInfo.StopRfids = Array.ConvertAll<string, int>(dgv.Rows[row].Cells[4].Value.ToString().Split(','), s => int.Parse(s)).ToList();
                            doorInfo.CallRfids = Array.ConvertAll<string, int>(dgv.Rows[row].Cells[5].Value.ToString().Split(','), s => int.Parse(s)).ToList();
                            doorInfo.DoorComm.Enable = Convert.ToBoolean(dgv.Rows[row].Cells[6].Value);
                            doorInfo.Relation = Convert.ToInt32(dgv.Rows[row].Cells[7].Value.ToString().Trim());
                            doorInfo.RelationNumber = Convert.ToByte(dgv.Rows[row].Cells[8].Value.ToString());
                            Common.Instance.dtDoorInfo[doorNo] = doorInfo;
                            MessageBox.Show("修改成功！");

                        }
                        catch { MessageBox.Show("输入参数格式不对，ip地址必须满足标准模式，编号和端口号必须为数值，RFID集合单个RFID请用英文逗号(',')隔开"); }
                    }
                }
                else if (col == 10)
                {
                    if (MessageBox.Show(string.Format("是否要删除房门{0}的参数？", doorNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        lock (Common.Instance.dtDoorInfo)
                        {
                            while (Common.Instance.dtDoorInfo.ContainsKey(doorNo))
                            {
                                Common.Instance.dtDoorInfo.Remove(doorNo);
                            }
                        }
                        UpdateShutterDoor();
                        MessageBox.Show("删除成功！");
                    }
                }
            }
            catch { }
        }
        #endregion

        #region 电梯配置
        /// <summary>
        /// 电梯添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnElevatorAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int eleCount = Convert.ToInt32(txtElevatorNumber.Text);
                ElevatorInfo elevatorInfo = new ElevatorInfo(eleCount);
                elevatorInfo.ElevatorComm = new ElevatorCommunication();
                int eleNo = Convert.ToInt32(txtElevatorNo.Text);
                if (!Common.Instance.dtElevatorInfo.ContainsKey(eleNo))
                {
                    IPAddress.Parse(txtElevatorIp.Text);
                    elevatorInfo.Id = eleNo;
                    elevatorInfo.ElevatorComm.ElevatorNo = eleNo;
                    elevatorInfo.ElevatorComm.Ip = txtElevatorIp.Text.Trim();
                    elevatorInfo.ElevatorComm.Port = Convert.ToInt32(txtElevatorPort.Text);
                    elevatorInfo.Name = txtElevatorName.Text.Trim();
                    elevatorInfo.StopRfids = Array.ConvertAll<string, int>(txtElevatorStopRfids.Text.Split(','), s => int.Parse(s)).ToList();
                    elevatorInfo.CallRfids = Array.ConvertAll<string, int>(txtElevatorCallRfids.Text.Split(','), s => int.Parse(s)).ToList();
                    elevatorInfo.ElevatorComm.Enable = cbElevatorEnable.SelectedIndex == 0 ? true : false;
                    elevatorInfo.FloorNumber = eleCount;
                    Common.Instance.dtElevatorInfo[eleNo] = elevatorInfo;
                    MessageBox.Show("修改成功！");
                    RefreshElevator();
                }
                else
                {
                    MessageBox.Show(string.Format("电梯编号{0} 已存在，不可重复添加", eleNo));
                }

            }
            catch
            {
                MessageBox.Show("参数格式错误，请输入正确的参数！");
            }
        }
        /// <summary>
        /// 电梯配置获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnElevatorReceive_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshElevator();
            }
            catch { }
        }
        /// <summary>
        /// 刷新电梯配置
        /// </summary>
        private void RefreshElevator()
        {
            try
            {
                dgvElevator.Rows.Clear();
                if (Common.Instance.dtElevatorInfo.Count > 0)
                {
                    List<int> ls = Common.Instance.dtElevatorInfo.Keys.ToList();
                    foreach (int item in ls)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dr.CreateCells(dgvElevator);
                        dr.Cells[0].Value = Common.Instance.dtElevatorInfo[item].Id;
                        dr.Cells[1].Value = Common.Instance.dtElevatorInfo[item].Name;
                        dr.Cells[2].Value = Common.Instance.dtElevatorInfo[item].ElevatorComm.Ip;
                        dr.Cells[3].Value = Common.Instance.dtElevatorInfo[item].ElevatorComm.Port;
                        if (Common.Instance.dtElevatorInfo[item].StopRfids.Count > 0)
                            dr.Cells[4].Value = string.Join(",", Common.Instance.dtElevatorInfo[item].StopRfids);
                        else dr.Cells[4].Value = string.Empty;
                        if (Common.Instance.dtElevatorInfo[item].CallRfids.Count > 0)
                            dr.Cells[5].Value = string.Join(",", Common.Instance.dtElevatorInfo[item].CallRfids);
                        else dr.Cells[5].Value = string.Empty;
                        dr.Cells[6].Value = Common.Instance.dtElevatorInfo[item].FloorNumber;
                        dr.Cells[7].Value = Common.Instance.dtElevatorInfo[item].ElevatorComm.Enable;
                        dgvElevator.Rows.Add(dr);
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// 电梯参数修改/删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvElevator_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                int row = e.RowIndex;
                int col = e.ColumnIndex;
                int eleNo = Convert.ToInt32(dgv.Rows[row].Cells[0].Value);
                if (col == dgv.ColumnCount - 2)
                {
                    if (MessageBox.Show(string.Format("是否要对电梯{0}的参数进行修改?", eleNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        try
                        {
                            int floorNum = Convert.ToInt32(dgv.Rows[row].Cells["dtxtElevatorFloorNumber"].Value.ToString());
                            ElevatorInfo elevatorInfo = new ElevatorInfo(floorNum);
                            elevatorInfo.ElevatorComm = new ElevatorCommunication();
                            IPAddress.Parse(dgv.Rows[row].Cells["dtxtElevatorIp"].Value.ToString());
                            elevatorInfo.ElevatorComm.Ip = dgv.Rows[row].Cells["dtxtElevatorIp"].Value.ToString();
                            elevatorInfo.ElevatorComm.Port = Convert.ToInt32(dgv.Rows[row].Cells["dtxtElevatorPort"].Value.ToString());
                            elevatorInfo.ElevatorComm.Enable = Convert.ToBoolean(dgv.Rows[row].Cells["dchbElevatorEnable"].Value.ToString());
                            elevatorInfo.StopRfids = Array.ConvertAll<string, int>(dgv.Rows[row].Cells["dtxtElevatorStopRfids"].Value.ToString().Split(','), s => int.Parse(s)).ToList();
                            elevatorInfo.CallRfids = Array.ConvertAll<string, int>(dgv.Rows[row].Cells["dtxtElevatorCallRfids"].Value.ToString().Split(','), s => int.Parse(s)).ToList();
                            elevatorInfo.Name = dgv.Rows[row].Cells["dtxtElevatorName"].Value.ToString().Trim();
                            Common.Instance.dtElevatorInfo[eleNo] = elevatorInfo;
                            MessageBox.Show("修改成功！");

                        }
                        catch { MessageBox.Show("输入参数格式不对，ip地址必须满足标准模式，编号和端口号必须为数值，RFID集合单个RFID请用英文逗号(',')隔开"); }
                    }
                }
                else if (col == dgv.ColumnCount - 1)
                {
                    if (MessageBox.Show(string.Format("是否要删除电梯{0}的参数？", eleNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        lock (Common.Instance.dtElevatorInfo)
                        {
                            while (Common.Instance.dtElevatorInfo.ContainsKey(eleNo))
                            {
                                Common.Instance.dtElevatorInfo.Remove(eleNo);
                            }
                        }
                        RefreshElevator();
                        MessageBox.Show("删除成功！");
                    }
                }
            }
            catch { }
        }
        #endregion

        #region 测试模式配置
        private void chbIsTest_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbIsTest.Checked == false)
                {
                    while (Common.maiDict.Any(o => o.Value.IsAgvTest))
                    {
                        int agvNo = Common.maiDict.FirstOrDefault(o => o.Value.IsAgvTest).Key;
                        Common.maiDict[agvNo].IsAgvTest = false;
                        Common.maiDict[agvNo].lsRoutes.Clear();
                    }
                    txtTestRoutes.Text = string.Empty;
                    try
                    {
                        Common.taskTest.T_Process = new List<RouteInfo>();
                    }
                    catch { }
                    Common.taskTest.ProcessIndex = 0;
                }
                else
                {
                    Common.maiDict[Common.Instance.TestAgvNo].IsAgvTest = true;
                    //Common.maiDict[Common.Instance.TestAgvNo].lsRoutes.Clear();
                    //Common.taskTest.T_Process = new List<RouteInfo>();
                }
            }
            catch { }
        }

        private void btnTestRouteAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int source = Convert.ToInt32(txtTestRouteSource.Text);
                int target = Convert.ToInt32(txtTestRouteTarget.Text);
                int operate = Convert.ToInt32(txtTestRouteTargetOperate.Text);
                //if (Common.maiDict[Common.Instance.TestAgvNo].IsTest)
                //{
                DijkstraSolution dijkstraSolution = new DijkstraSolution();
                List<KeyValuePair<int, RfidInfo>> ls = dijkstraSolution.FindRoute(source, target);
                if (ls.Count > 0)
                {
                    RouteInfo re = new RouteInfo(RouteType.TestRoute, target, 0, string.Format("前往测试RFID:{0}", target));
                    re.SourceStation = source;
                    re.Operation = operate;
                    Common.taskTest.T_Process.Add(re);
                    txtTestRouteSource.Text = target.ToString();
                    txtTestRouteTarget.Text = (target + 1).ToString();
                    ReceiveTestRoutes();
                }
                else
                {
                    MessageBox.Show(string.Format("由RFID:{0}->RFID:{1}的路径不存在，请输入其它路径", source, target));
                }
                //}
                //else
                //{
                //    MessageBox.Show(string.Format("测试Agv{0}的测试使能没有打开，请勾选测试使能", Common.Instance.TestAgvNo));
                //}
            }
            catch { }
        }
        private void ReceiveTestRoutes()
        {
            try
            {
                //if (Common.maiDict[Common.Instance.TestAgvNo].IsTest)
                //{
                string ss = string.Empty;
                for (int i = 0; i < Common.taskTest.T_Process.Count; i++)
                {
                    ss += string.Format("索引[{0}] 起始RFID:{1},前往测试RFID:{2},操作{3}\r\n", i, Common.taskTest.T_Process[i].SourceStation, Common.taskTest.T_Process[i].Station, Common.taskTest.T_Process[i].Operation);
                }
                txtTestRoutes.Text = ss;
                //}
                //else
                //{
                //    MessageBox.Show(string.Format("测试Agv{0}的测试使能没有打开，请勾选测试使能", Common.Instance.TestAgvNo));
                //}
            }
            catch { }
        }
        private void btnTestRouteReceive_Click(object sender, EventArgs e)
        {
            ReceiveTestRoutes();
        }

        private void btnTestRouteClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (Common.maiDict[Common.Instance.TestAgvNo].IsAgvTest)
                {
                    Common.maiDict[Common.Instance.TestAgvNo].lsRoutes.Clear();
                    txtTestRoutes.Text = string.Empty;
                }
                Common.taskTest.ProcessIndex = 0;
                Common.taskTest.T_Process = new List<RouteInfo>();
                ReceiveTestRoutes();
            }
            catch { }
        }
        /// <summary>
        /// 添加RadioButton控件
        /// </summary>
        private void UpdateRadioButton()
        {
            try
            {
                List<int> agvList = Common.maiDict.Keys.OrderBy(o => o).ToList();
                int row = 0;
                int col = 0;
                for (int i = 0; i < agvList.Count; i++)
                {
                    int item = agvList[i];
                    RadioButton rdbtn = new RadioButton();
                    rdbtn.Size = new Size(70, 40);
                    rdbtn.Text = string.Format("Agv{0}", item);
                    rdbtn.Tag = item;
                    rdbtn.FlatStyle = FlatStyle.Flat;
                    row = i / 5;
                    col = i % 5;
                    rdbtn.Location = new Point(col * 70, row * 40);
                    rdbtn.CheckedChanged += rdbtn_CheckedChanged;
                    panTestAgvGroup.Controls.Add(rdbtn);
                    if (i == 0) rdbtn.Checked = true;
                    else rdbtn.Checked = false;
                }
            }
            catch { }
        }

        void rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rdbtn = (RadioButton)sender;
                int agvNo = (int)rdbtn.Tag;
                if (rdbtn.Checked) Common.Instance.TestAgvNo = agvNo;
                chbIsTest.Checked = false;
            }
            catch { }
        }
        private void chbTestLoop_CheckedChanged(object sender, EventArgs e)
        {
            Common.IsTestLoop = chbTestLoop.Checked;
        }
        private void btnTestRouteNoClear_Click(object sender, EventArgs e)
        {
            try
            {
                BA_AgvCommunicationThread.AgvCommuDt[Common.Instance.TestAgvNo].AgvOperate(Enumerations.AgvOperate.StationClear);
            }
            catch { }
        }
        //一键添加
        private void btnTestRouteAll_Click(object sender, EventArgs e)
        {
            try
            {
                int source = Convert.ToInt32(txtTestRouteSourceAll.Text);
                int target = Convert.ToInt32(txtTestRouteTargetAll.Text);
                int operate = Convert.ToInt32(txtTestRouteOperateAll.Text);
                int count = Convert.ToInt32(txtTestRouteAllCount.Text);
                bool isRight = false;
                int _source = source % 100;
                int _target = target % 100;
                if (count == 4)
                {
                    if (source % 4 == 1 && target % 4 == 0 && source < target)
                    {
                        if (_source >= 1 && _source <= 40 && _target >= 1 && _target <= 40 && (source / 100 == target / 100) && _source < _target)
                        {
                            isRight = true;
                        }
                        if (isRight)
                        {
                            for (int i = source; i < target; i += 4)
                            {
                                RouteInfo re0 = new RouteInfo(RouteType.TestRoute, i + 2, 0, string.Format("前往测试RFID:{0}", target));
                                re0.SourceStation = i;
                                re0.Operation = operate;
                                Common.taskTest.T_Process.Add(re0);
                                RouteInfo re1 = new RouteInfo(RouteType.TestRoute, i + 2 + 1, 0, string.Format("前往测试RFID:{0}", target));
                                re1.SourceStation = i + 2;
                                re1.Operation = operate;
                                if (re1.Station <= target)
                                    Common.taskTest.T_Process.Add(re1);
                                RouteInfo re2 = new RouteInfo(RouteType.TestRoute, i + 2 + 1 + 2, 0, string.Format("前往测试RFID:{0}", target));
                                re2.SourceStation = i + 2 + 1;
                                re2.Operation = operate;
                                if (re2.Station <= target)
                                    Common.taskTest.T_Process.Add(re2);
                                RouteInfo re3 = new RouteInfo(RouteType.TestRoute, i + 2 + 1 + 2 - 1, 0, string.Format("前往测试RFID:{0}", target));
                                re3.SourceStation = i + 2 + 1 + 2;
                                re3.Operation = operate;
                                if (re3.Station <= target)
                                    Common.taskTest.T_Process.Add(re3);
                            }
                            ReceiveTestRoutes();
                        }
                        else
                        {
                            MessageBox.Show("起始目的必须同一组别");
                        }
                    }
                    else
                    {
                        MessageBox.Show("起始必须为4的倍数+1,目的必须为4的倍数，起始 必须小于目的");
                    }
                }
                else if (count == 5)
                {

                    if (source % 5 == 1 && target % 5 == 0 && source < target)
                    {
                        if (_source >= 1 && _source <= 50 && _target >= 1 && _target <= 50 && (source / 100 == target / 100) && _source < _target)
                        {
                            isRight = true;
                        }
                        if (isRight)
                        {
                            for (int i = source; i < target; i += 5)
                            {
                                if (source % 200 <= 100)
                                {
                                    RouteInfo re0 = new RouteInfo(RouteType.TestRoute, i + 3, 0, string.Format("前往测试RFID:{0}", target));
                                    re0.SourceStation = i;
                                    re0.Operation = operate;
                                    Common.taskTest.T_Process.Add(re0);
                                    RouteInfo re1 = new RouteInfo(RouteType.TestRoute, i + 3 + 1, 0, string.Format("前往测试RFID:{0}", target));
                                    re1.SourceStation = i + 3;
                                    re1.Operation = operate;
                                    if (re1.Station <= target)
                                        Common.taskTest.T_Process.Add(re1);
                                    RouteInfo re2 = new RouteInfo(RouteType.TestRoute, i + 3 + 1 + 3, 0, string.Format("前往测试RFID:{0}", target));
                                    re2.SourceStation = i + 3 + 1;
                                    re2.Operation = operate;
                                    if (re2.Station <= target)
                                        Common.taskTest.T_Process.Add(re2);
                                    RouteInfo re3 = new RouteInfo(RouteType.TestRoute, i + 3 + 1 + 3 - 1, 0, string.Format("前往测试RFID:{0}", target));
                                    re3.SourceStation = i + 3 + 1 + 3;
                                    re3.Operation = operate;
                                    if (re3.Station <= target)
                                        Common.taskTest.T_Process.Add(re3);
                                    RouteInfo re4 = new RouteInfo(RouteType.TestRoute, i + 3 + 1 + 3 - 1 - 1, 0, string.Format("前往测试RFID:{0}", target));
                                    re4.SourceStation = i + 3 + 1 + 3 - 1;
                                    re4.Operation = operate;
                                    if (re4.Station <= target)
                                        Common.taskTest.T_Process.Add(re4);
                                }
                                else
                                {
                                    RouteInfo re0 = new RouteInfo(RouteType.TestRoute, i + 2, 0, string.Format("前往测试RFID:{0}", target));
                                    re0.SourceStation = i;
                                    re0.Operation = operate;
                                    Common.taskTest.T_Process.Add(re0);
                                    RouteInfo re1 = new RouteInfo(RouteType.TestRoute, i + 2 + 1, 0, string.Format("前往测试RFID:{0}", target));
                                    re1.SourceStation = i + 2;
                                    re1.Operation = operate;
                                    if (re1.Station <= target)
                                        Common.taskTest.T_Process.Add(re1);
                                    RouteInfo re2 = new RouteInfo(RouteType.TestRoute, i + 2 + 1 + 1, 0, string.Format("前往测试RFID:{0}", target));
                                    re2.SourceStation = i + 2 + 1;
                                    re2.Operation = operate;
                                    if (re2.Station <= target)
                                        Common.taskTest.T_Process.Add(re2);
                                    RouteInfo re3 = new RouteInfo(RouteType.TestRoute, i + 2 + 1 + 1 + 2, 0, string.Format("前往测试RFID:{0}", target));
                                    re3.SourceStation = i + 2 + 1 + 1;
                                    re3.Operation = operate;
                                    if (re3.Station <= target)
                                        Common.taskTest.T_Process.Add(re3);
                                    RouteInfo re4 = new RouteInfo(RouteType.TestRoute, i + 2 + 1 + 1 + 2 - 1, 0, string.Format("前往测试RFID:{0}", target));
                                    re4.SourceStation = i + 2 + 1 + 1 + 2;
                                    re4.Operation = operate;
                                    if (re4.Station <= target)
                                        Common.taskTest.T_Process.Add(re4);
                                }
                            }
                            ReceiveTestRoutes();
                        }
                        else
                        {
                            MessageBox.Show("起始目的必须同一组别");
                        }
                    }
                    else
                    {
                        MessageBox.Show("起始必须为5的倍数+1,目的必须为5的倍数，起始 必须小于目的");
                    }
                }
                else
                {
                    MessageBox.Show("数量只能为4或5");
                }
            }
            catch
            {
                MessageBox.Show("输入参数错误，参数格式只能为整数");
            }
        }
        #endregion

        #region 站点配置
        //右键进行10个整列添加
        private void btnCellsStationAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //int type = Convert.ToInt32(txtStationType.Text);
                //if (type == (int)StationInformation.EStationType.Wait)
                //{
                //    if (MessageBox.Show("是否执行对分容柜进行整列添加操作？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                //    {
                //        string typeName = txtStationTypeName.Text.Trim();
                //        int no = Convert.ToInt32(txtStationNo.Text);
                //        string name = txtStationName.Text.Trim();
                //        int operate = Convert.ToInt32(txtStationOperate.Text);
                //        int group = Convert.ToInt32(txtStationGroup.Text.ToString());
                //        string matchValue = txtStationMatchValue.Text.Trim();
                //        string key = string.Format("{0}_{1}_{2}", type, no, group);
                //        if (Common.Instance.dtStationInformation.ContainsKey(key) || Common.Instance.dtStationInformation.Any(o => o.Value.StationMatchValue == matchValue))
                //        {
                //            MessageBox.Show("该站点信息已经存在，请核实站点类型及站点编号是否重复");
                //        }
                //        else
                //        {
                //            int rfid = Convert.ToInt32(txtStationRfid.Text);
                //            string infoString = txtStationOperate.Text.Trim();
                //            bool enable = cbStationEnable.SelectedIndex == 0 ? true : false;
                //            string describe = txtStationDescribe.Text.Trim();
                //            StationInformation stationInformation = new StationInformation(key, type, typeName, no, name, rfid, matchValue, infoString, enable, describe, group);
                //            Common.Instance.dtStationInformation[key] = stationInformation;
                //            string[] smv = matchValue.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                //            int noSu = Convert.ToInt32(smv[3]);
                //            for (int i = 2; i < 11; i++)
                //            {
                //                string _matchValue = string.Empty;
                //                string _nosu = (noSu + (i + 1) % 2).ToString("D2");
                //                //int _operateStr = noSu == 1 ? 1 : 2;
                //                _matchValue = smv[0] + "_" + smv[1] + "_" + ((i + 1) / 2).ToString("D2") + "_" + _nosu;
                //                StationInformation _station = new StationInformation(string.Format("{0}_{1}_{2}", type, no - 1 + i, group), type, typeName, no - 1 + i, typeName + "_" + (no - 1 + i).ToString(), no - 1 + i, _matchValue, infoString, true, _matchValue, group);
                //                Common.Instance.dtStationInformation[_station.Key] = _station;

                //            }
                //            UpdateStationInformation();
                //            if (noSu == 1)
                //            {
                //                string _matchValue = smv[0] + "_" + smv[1] + "_01_03";
                //                txtStationDescribe.Text = _matchValue;
                //                txtStationMatchValue.Text = _matchValue;
                //            }
                //            else if (noSu == 3)
                //            {
                //                string _matchValue = smv[0] + "_" + (Convert.ToInt32(smv[1]) + 1).ToString("D3") + "_01_01";
                //                txtStationDescribe.Text = _matchValue;
                //                txtStationMatchValue.Text = _matchValue;
                //            }
                //            if (Convert.ToInt32(infoString) == 1)
                //            {
                //                txtStationOperate.Text = "2";
                //            }
                //            else txtStationOperate.Text = "1";
                //            txtStationGroup.Text = (group + 1).ToString();
                //            txtStationRfid.Text = rfid.ToString();
                //            txtStationNo.Text = no.ToString();
                //        }
                //    }
                //}
            }
            catch
            {
                MessageBox.Show("输入站点参数格式不对，站点类型、站点编号、站点RFID为数值类型");
            }
        }
        private void btnStationAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int type = Convert.ToInt32(txtStationType.Text);
                string typeName = txtStationTypeName.Text.Trim();
                int no = Convert.ToInt32(txtStationNo.Text);
                string name = txtStationName.Text.Trim();
                int operate = Convert.ToInt32(txtStationOperate.Text);
                int group = Convert.ToInt32(txtStationGroup.Text.ToString());
                string key = string.Format("{0}_{1}_{2}", type, no, group);
                string matchValue = txtStationMatchValue.Text.Trim();
                if (Common.Instance.dtStationInformation.ContainsKey(key) || Common.Instance.dtStationInformation.Any(o => o.Value.StationMatchValue == matchValue))
                {
                    MessageBox.Show("The site already exists!");
                }
                else
                {
                    int[] rfids = txtStationRfid.Text.Split(',').Select<string, int>(q => int.Parse(q)).ToArray();
                    string infoString = txtStationOperate.Text.Trim();
                    bool enable = cbStationEnable.SelectedIndex == 0 ? true : false;
                    string describe = txtStationDescribe.Text.Trim();
                    StationInformation stationInformation = new StationInformation(key, type, typeName, no, name, rfids, matchValue, infoString, enable, describe, group);
                    Common.Instance.dtStationInformation[key] = stationInformation;
                    UpdateStationInformation();
                    //txtStationRfid.Text = (rfids + 1).ToString();
                    txtStationNo.Text = (no + 1).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Wrong format，Type、Id、Bind rfid must be numeric.");
            }
        }

        private void btnStationReceive_Click(object sender, EventArgs e)
        {
            UpdateStationInformation();
        }
        private void cbbStationTypeShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbbStationTypeShow1.Items.Clear();
                int index = cbbStationTypeShow.SelectedIndex;
                List<string> itemLs = new List<string>();
                switch (index)
                {
                    case 0:
                        stationTypeNO = 0;
                        break;
                    case 1:
                        stationTypeNO = 2;
                        cbbStationTypeShow1.Items.Add("1");
                        break;
                    case 2:
                        stationTypeNO = 1;
                        int max = Common.Instance.dtStationInformation.OrderByDescending(o => o.Value.Group).FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.Wait).Value.Group;
                        for (int i = 1; i <= max; i++)
                        {
                            itemLs.Add(i.ToString());
                        }
                        cbbStationTypeShow1.Items.AddRange(itemLs.ToArray());
                        break;
                    case 3:
                        stationTypeNO = 11;
                        cbbStationTypeShow1.Items.Add("1");
                        break;
                    case 4:
                        stationTypeNO = 12;
                        for (int i = 1; i < 11; i++)
                        {
                            itemLs.Add(i.ToString());
                        }
                        cbbStationTypeShow1.Items.AddRange(itemLs.ToArray());
                        break;
                    case 5:
                        stationTypeNO = 13;
                        cbbStationTypeShow1.Items.Add("1");
                        break;
                    case 6:
                        stationTypeNO = 14;
                        cbbStationTypeShow1.Items.Add("1");
                        break;
                    case 7:
                        stationTypeNO = 21;
                        cbbStationTypeShow1.Items.Add("1");
                        break;
                    case 8:
                        stationTypeNO = 22;
                        for (int i = 11; i < 43; i++)
                        {
                            itemLs.Add(i.ToString());
                        }
                        cbbStationTypeShow1.Items.AddRange(itemLs.ToArray());
                        break;
                    case 9:
                        stationTypeNO = 23;
                        cbbStationTypeShow1.Items.Add("1");
                        cbbStationTypeShow1.Items.Add("2");
                        break;
                    case 10:
                        stationTypeNO = 24;
                        cbbStationTypeShow1.Items.Add("1");
                        break;
                    case 11:
                        stationTypeNO = 31;
                        cbbStationTypeShow1.Items.Add("1");
                        cbbStationTypeShow1.Items.Add("2");
                        break;
                    case 12:
                        stationTypeNO = 32;
                        cbbStationTypeShow1.Items.Add("1");
                        break;
                    case 13:
                        stationTypeNO = 33;
                        cbbStationTypeShow1.Items.Add("1");
                        break;
                    case 14:
                        stationTypeNO = 41;
                        break;
                }
                try
                {
                    cbbStationTypeShow1.SelectedIndex = 0;
                }
                catch { }
            }
            catch { }
        }
        /// <summary>
        /// 修改/删除站点信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStationInformation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                int row = e.RowIndex;
                int col = e.ColumnIndex;
                string key = dgv.Rows[row].Cells[0].Value.ToString().Trim() + "_" + dgv.Rows[row].Cells[2].Value.ToString().Trim() + "_" + dgv.Rows[row].Cells[7].Value.ToString().Trim();
                if (col == dgv.ColumnCount - 2)
                {//修改 
                    if (MessageBox.Show(string.Format("Whether to modify the site who is type[{0}] and id[{1}]？", Common.Instance.dtStationInformation[key].StationType, Common.Instance.dtStationInformation[key].StationNo), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            Common.Instance.dtStationInformation[key].TypeName = dgv.Rows[row].Cells[1].Value.ToString().Trim();
                            Common.Instance.dtStationInformation[key].StationName = dgv.Rows[row].Cells[3].Value.ToString().Trim();
                            Common.Instance.dtStationInformation[key].StationRfidLs = dgv.Rows[row].Cells[4].Value.ToString().Split(',').Select<string, int>(q => int.Parse(q)).ToList();
                            Common.Instance.dtStationInformation[key].StationMatchValue = dgv.Rows[row].Cells[5].Value.ToString().Trim();
                            Common.Instance.dtStationInformation[key].StationOperate = dgv.Rows[row].Cells[6].Value.ToString().Trim();
                            Common.Instance.dtStationInformation[key].Group = Convert.ToInt32(dgv.Rows[row].Cells[7].Value.ToString().Trim());
                            Common.Instance.dtStationInformation[key].StationEnable = Convert.ToBoolean(dgv.Rows[row].Cells[8].Value);
                            Common.Instance.dtStationInformation[key].StationDescribe = dgv.Rows[row].Cells[9].Value.ToString().Trim();
                            Common.Instance.dtStationInformation[key].PassRfid = int.Parse(dgv.Rows[row].Cells[10].Value.ToString().Trim());
                            Common.Instance.dtStationInformation[key].State = int.Parse(dgv.Rows[row].Cells[11].Value.ToString().Trim());
                            Common.Instance.dtStationInformation[key].Handle = int.Parse(dgv.Rows[row].Cells[12].Value.ToString().Trim());
                            Common.Instance.dtStationInformation[key].UpdateTime = DateTime.Parse(dgv.Rows[row].Cells[13].Value.ToString().Trim());
                            UpdateStationInformation();
                        }
                        catch
                        {
                            MessageBox.Show("Wrong format，Type、Id、Bind rfid、Handle must be numeric.");
                        }
                    }
                }
                else if (col == dgv.ColumnCount - 1)
                {//删除 
                    if (MessageBox.Show(string.Format("Whether to delete the site who is type[{0}] and id[{1}]？", Common.Instance.dtStationInformation[key].StationType, Common.Instance.dtStationInformation[key].StationNo), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            while (Common.Instance.dtStationInformation.ContainsKey(key))
                            {
                                Common.Instance.dtStationInformation.Remove(key);
                            }
                        }
                        catch { }
                        UpdateStationInformation();
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// 更新站点信息
        /// </summary>
        private void UpdateStationInformation()
        {
            try
            {
                dgvStationInformation.Rows.Clear();
                if (Common.Instance.dtStationInformation.Count > 0)
                {
                    List<string> ls = new List<string>();
                    ls = Common.Instance.dtStationInformation.Keys.ToList();
                    if (stationTypeNO > 0)
                    {
                        try
                        {
                            int group = Convert.ToInt32(cbbStationTypeShow1.Text);
                            ls = ls.FindAll(o => Common.Instance.dtStationInformation[o].StationType == stationTypeNO && Common.Instance.dtStationInformation[o].Group == group);
                        }
                        catch { }
                    }
                    foreach (string item in ls)
                    {
                        DataGridViewRow dr = new DataGridViewRow();
                        dr.CreateCells(dgvStationInformation);
                        dr.Cells[0].Value = Common.Instance.dtStationInformation[item].StationType;
                        dr.Cells[1].Value = Common.Instance.dtStationInformation[item].TypeName;
                        dr.Cells[2].Value = Common.Instance.dtStationInformation[item].StationNo;
                        dr.Cells[3].Value = Common.Instance.dtStationInformation[item].StationName;
                        dr.Cells[4].Value = string.Join(",", Common.Instance.dtStationInformation[item].StationRfidLs.ToArray());
                        dr.Cells[5].Value = Common.Instance.dtStationInformation[item].StationMatchValue;
                        dr.Cells[6].Value = Common.Instance.dtStationInformation[item].StationOperate;
                        dr.Cells[7].Value = Common.Instance.dtStationInformation[item].Group;
                        dr.Cells[8].Value = Common.Instance.dtStationInformation[item].StationEnable;
                        dr.Cells[9].Value = Common.Instance.dtStationInformation[item].StationDescribe;
                        dr.Cells[10].Value = Common.Instance.dtStationInformation[item].PassRfid;
                        dr.Cells[11].Value = Common.Instance.dtStationInformation[item].State;
                        dr.Cells[12].Value = Common.Instance.dtStationInformation[item].Handle;
                        dr.Cells[13].Value = Common.Instance.dtStationInformation[item].UpdateTime;

                        if (Common.Instance.dtStationInformation[item].StationEnable == false) dr.DefaultCellStyle.BackColor = Color.Silver;
                        else
                        {
                            switch (Common.Instance.dtStationInformation[item].State)
                            {
                                case (int)EStationState.Free:
                                    dr.DefaultCellStyle.BackColor = Color.Lime;
                                    break;
                                case (int)EStationState.Busy:
                                    dr.DefaultCellStyle.BackColor = Color.Red;
                                    break;
                                case (int)EStationState.Book:
                                    dr.DefaultCellStyle.BackColor = Color.Yellow;
                                    break;
                            }
                        }
                        dgvStationInformation.Rows.Add(dr);
                    }
                    dgvStationInformation.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch { }
        }
        #endregion

        #region 分容测试Agv配置
        private void btnCapacityTestWait1Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否要更新分容测试待机点1的参数？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    int rfid = Convert.ToInt32(txtCapacityTestWait1Rfid.Text);
                    string[] stationStr = txtCapacityTestWait1Stations.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    List<point> stations = new List<point>();
                    foreach (string item in stationStr)
                    {
                        int[] p = Array.ConvertAll<string, int>(item.Split('_'), s => int.Parse(s)).ToArray();
                        stations.Add(new point(p[0], p[1]));
                    }
                    string[] rfidStr = txtCapacityTestWait1Rfids.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    List<point> rfids = new List<point>();
                    foreach (string item in rfidStr)
                    {
                        int[] p = Array.ConvertAll<string, int>(item.Split('_'), s => int.Parse(s)).ToArray();
                        rfids.Add(new point(p[0], p[1]));
                    }
                    Common.Instance.dtCapacityTestWait[1] = new CapacityTestWaitInfo(1, rfid, stations, rfids);
                }
            }
            catch
            {
                MessageBox.Show("参数格式错误，RFID必须为数值类型，站点范围/RFID范围的格式为‘1_5,7_10’，即包含的范围为1到5，以及7到10");
            }
        }

        private void btnCapacityTestWait1Receive_Click(object sender, EventArgs e)
        {
            try
            {
                txtCapacityTestWait1Rfid.Text = Common.Instance.dtCapacityTestWait[1].Rfid.ToString();
                string stationsStr = string.Empty;
                foreach (point item in Common.Instance.dtCapacityTestWait[1].lsStations)
                {
                    stationsStr += string.Format("{0}_{1},", item.X, item.Y);
                }
                txtCapacityTestWait1Stations.Text = stationsStr;
                string rfidsStr = string.Empty;
                foreach (point item in Common.Instance.dtCapacityTestWait[1].lsRfids)
                {
                    rfidsStr += string.Format("{0}_{1},", item.X, item.Y);
                }
                txtCapacityTestWait1Rfids.Text = rfidsStr;
            }
            catch { }
        }

        private void btnCapacityTestWait2update_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否要更新分容测试待机点2的参数？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    int rfid = Convert.ToInt32(txtCapacityTestWait2Rfid.Text);
                    string[] stationStr = txtCapacityTestWait2Stations.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    List<point> stations = new List<point>();
                    foreach (string item in stationStr)
                    {
                        int[] p = Array.ConvertAll<string, int>(item.Split('_'), s => int.Parse(s)).ToArray();
                        stations.Add(new point(p[0], p[1]));
                    }
                    string[] rfidStr = txtCapacityTestWait2Rfids.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    List<point> rfids = new List<point>();
                    foreach (string item in rfidStr)
                    {
                        int[] p = Array.ConvertAll<string, int>(item.Split('_'), s => int.Parse(s)).ToArray();
                        rfids.Add(new point(p[0], p[1]));
                    }
                    Common.Instance.dtCapacityTestWait[2] = new CapacityTestWaitInfo(2, rfid, stations, rfids);
                }
            }
            catch
            {
                MessageBox.Show("参数格式错误，RFID必须为数值类型，站点范围/RFID范围的格式为‘1_5,7_10’，即包含的范围为1到5，以及7到10");
            }
        }

        private void btnCapacityTestWait2Receive_Click(object sender, EventArgs e)
        {
            try
            {
                txtCapacityTestWait2Rfid.Text = Common.Instance.dtCapacityTestWait[2].Rfid.ToString();
                string stationsStr = string.Empty;
                foreach (point item in Common.Instance.dtCapacityTestWait[2].lsStations)
                {
                    stationsStr += string.Format("{0}_{1},", item.X, item.Y);
                }
                txtCapacityTestWait2Stations.Text = stationsStr;
                string rfidsStr = string.Empty;
                foreach (point item in Common.Instance.dtCapacityTestWait[2].lsRfids)
                {
                    rfidsStr += string.Format("{0}_{1},", item.X, item.Y);
                }
                txtCapacityTestWait2Rfids.Text = rfidsStr;
            }
            catch { }
        }
        private void btnCapacityTestOperateRef_Click(object sender, EventArgs e)
        {
            try
            {
                int ll = Convert.ToInt32(txtCapacityTestLeftLoad.Text);
                int rl = Convert.ToInt32(txtCapacityTestRightLoad.Text);
                int lu = Convert.ToInt32(txtCapacityTestLeftUnload.Text);
                int ru = Convert.ToInt32(txtCapacityTestRightUnload.Text);
                int lr = Convert.ToInt32(txtCapacityTestLeftRefueling.Text);
                int rr = Convert.ToInt32(txtCapacityTestRightRefueling.Text);

                Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftLoad] = ll;
                Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightLoad] = rl;
                Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftUnload] = lu;
                Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightUnload] = ru;
                Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftRefueling] = lr;
                Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightRefueling] = rr;
            }
            catch
            {
                MessageBox.Show("输入数据只能为数值类型");
            }
        }

        private void btnCapacityTestOperateRec_Click(object sender, EventArgs e)
        {
            try
            {
                txtCapacityTestLeftLoad.Text = Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftLoad].ToString();
                txtCapacityTestRightLoad.Text = Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightLoad].ToString();
                txtCapacityTestLeftUnload.Text = Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftUnload].ToString();
                txtCapacityTestRightUnload.Text = Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightUnload].ToString();
                txtCapacityTestLeftRefueling.Text = Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftRefueling].ToString();
                txtCapacityTestRightRefueling.Text = Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightRefueling].ToString();
            }
            catch { }
        }
        private void btnAgvLimitedRef_Click(object sender, EventArgs e)
        {
            try
            {
                string[] sagvLimited = txtAgvLimited.Text.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Common.Instance.dtAgvLimited = new Dictionary<int, List<int>>();
                if (sagvLimited.Length > 0)
                {
                    foreach (string item in sagvLimited)
                    {
                        try
                        {
                            string[] agvlimiteds = item.Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                            int value = Convert.ToInt32(agvlimiteds[0]);
                            int key = Convert.ToInt32(agvlimiteds[1]);
                            if (Common.Instance.dtAgvLimited.ContainsKey(key) == false) Common.Instance.dtAgvLimited[key] = new List<int>();
                            if (Common.Instance.dtAgvLimited[key].Contains(value) == false)
                            {
                                Common.Instance.dtAgvLimited[key].Add(value);
                                Common.Instance.dtAgvLimited[key].OrderBy(o => o);
                            }
                        }
                        catch { }
                    }
                }
                RefAgvlimited();
            }
            catch { }
        }

        private void btnAgvLimitedRec_Click(object sender, EventArgs e)
        {
            RefAgvlimited();
        }
        private void RefAgvlimited()
        {
            try
            {
                int[] keys = Common.Instance.dtAgvLimited.Keys.ToArray();
                string sAgvLimiteds = string.Empty;
                foreach (int item in keys)
                {
                    if (Common.Instance.dtAgvLimited[item].Count > 0)
                    {
                        string sInsert = string.Format("_{0},", item);
                        sAgvLimiteds += string.Join(sInsert, Common.Instance.dtAgvLimited[item]);
                        sAgvLimiteds += string.Format("_{0},", item);
                    }
                }
                txtAgvLimited.Text = sAgvLimiteds;
            }
            catch { }
        }
        #endregion

        #region 全部显示
        private void mnuFullSrceen_Click(object sender, EventArgs e)
        {
            try
            {
                if (mnuFullSrceen.Checked)
                {
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                }
                else
                {
                    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                }
            }
            catch { }
        }
        #endregion

        #region 房门状态控件创建
        private void CreateDoorStateControls()
        {
            try
            {
                if (Common.Instance.dtDoorInfo.Count > 0)
                {//存在房门控制，可创建控件组 
                    int i = 0;
                    Common.Instance.dtDoorInfo = Common.Instance.dtDoorInfo.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
                    double dAgvCount = 1;
                    if (maaciList.Count > 0)
                        dAgvCount = maaciList.Count;
                    double interval = 10 / ((double)dAgvCount);
                    double addIn = WaitForm.pValue;
                    foreach (int item in Common.Instance.dtDoorInfo.Keys)
                    {
                        Panel panDoor = new Panel();
                        panDoor.BorderStyle = BorderStyle.FixedSingle;
                        panDoor.Size = new Size(180, 80);
                        panDoor.Parent = panDoorState;
                        panDoor.Location = new Point(i % 10 * 180, i / 10 * 85);
                        if (Common.Instance.dtDoorInfo[item].Relation > 0)
                        {
                            i++;
                        }
                        else
                        {
                            if (item == 27)
                                i += 10 - i % 10;
                            else i++;
                        }
                        //label 门信息
                        Label lblDoorName = new Label();
                        lblDoorName.AutoSize = false;
                        lblDoorName.Size = new Size(180, 40);
                        lblDoorName.BackColor = Color.Azure;
                        lblDoorName.BorderStyle = BorderStyle.FixedSingle;
                        lblDoorName.Location = new Point(0, 0);
                        lblDoorName.TextAlign = ContentAlignment.MiddleLeft;
                        lblDoorName.Text = string.Format("{0}\r\nIP:{1}", Common.Instance.dtDoorInfo[item].Name, Common.Instance.dtDoorInfo[item].DoorComm.Ip);
                        lblDoorName.Parent = panDoor;
                        //label 门状态
                        Label lblDoorState = new Label();
                        lblDoorState.AutoSize = false;
                        lblDoorState.Size = new Size(100, 40);
                        lblDoorState.BorderStyle = BorderStyle.FixedSingle;
                        lblDoorState.Location = new Point(0, 40);
                        lblDoorState.TextAlign = ContentAlignment.MiddleCenter;
                        lblDoorState.BackColor = Color.Silver;
                        lblDoorState.Text = "通讯异常";
                        dtDoorStateLabel[item] = lblDoorState;
                        lblDoorState.Parent = panDoor;
                        //开门按钮
                        Button btnDoorOpen = new Button();
                        btnDoorOpen.Size = new Size(40, 40);
                        btnDoorOpen.Location = new Point(100, 40);
                        btnDoorOpen.Text = "开门";
                        btnDoorOpen.Tag = item;
                        dtDoorOpenButton[item] = btnDoorOpen;
                        btnDoorOpen.Click += btnDoorControl_Click;
                        btnDoorOpen.Parent = panDoor;
                        //关门按钮                        
                        Button btnDoorClose = new Button();
                        btnDoorClose.Size = new Size(40, 40);
                        btnDoorClose.Location = new Point(140, 40);
                        btnDoorClose.Text = "关门";
                        btnDoorClose.Tag = item;
                        dtDoorCloseButton[item] = btnDoorClose;
                        btnDoorClose.Click += btnDoorClose_Click;
                        btnDoorClose.Parent = panDoor;
                        addIn += interval;
                        WaitForm.pValue = (int)addIn;
                        WaitFormService.SetContents(string.Format("[房门{0}]状态控件生成完毕...", Common.Instance.dtDoorInfo[item].Name));
                    }
                }
            }
            catch { }
        }
        //关门请求
        void btnDoorClose_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int doorNo = Convert.ToInt32(btn.Tag.ToString());
                byte relationNumber = 1;
                if (Common.Instance.dtDoorInfo[doorNo].Relation > 0)
                {
                    relationNumber = Common.Instance.dtDoorInfo[doorNo].RelationNumber;
                }
                //if (Common.Instance.dtDoorInfo[doorNo].State == (int)DoorInfo.EDoorState.Close)
                //{//开门 
                DoorUdpClient.dtDoorUdp[doorNo].WriteDoorOperate(DoorUdpClient.EDoorOperate.Close, relationNumber);
                //}
                //else if (Common.Instance.dtDoorInfo[doorNo].State == (int)DoorInfo.EDoorState.Loading) { }

            }
            catch { }
        }
        /// <summary>
        /// 实时更新房门状态
        /// </summary>
        private void UpdateDoorState()
        {
            try
            {
                if (Common.Instance.dtDoorInfo.Count > 0)
                {
                    List<int> keyLs = Common.Instance.dtDoorInfo.Keys.ToList();
                    foreach (int item in keyLs)
                    {
                        try
                        {
                            if (dtDoorStateLabel.ContainsKey(item))
                            {
                                switch (Common.Instance.dtDoorInfo[item].State)
                                {
                                    case (int)DoorInfo.EDoorState.OffLine:
                                        dtDoorStateLabel[item].Text = "通讯异常";
                                        dtDoorStateLabel[item].BackColor = Color.Silver;
                                        dtDoorOpenButton[item].Enabled = false;
                                        dtDoorOpenButton[item].BackColor = Color.Silver;
                                        dtDoorCloseButton[item].Enabled = false;
                                        dtDoorCloseButton[item].BackColor = Color.Silver;
                                        break;
                                    case (int)DoorInfo.EDoorState.Open:
                                        dtDoorStateLabel[item].Text = "开门到位";
                                        dtDoorStateLabel[item].BackColor = Color.Lime;
                                        dtDoorOpenButton[item].Enabled = false;
                                        dtDoorOpenButton[item].BackColor = Color.Silver;
                                        dtDoorCloseButton[item].Enabled = true;
                                        dtDoorCloseButton[item].BackColor = Color.White;
                                        break;
                                    case (int)DoorInfo.EDoorState.Close:
                                        dtDoorStateLabel[item].Text = "房门关闭";
                                        dtDoorStateLabel[item].BackColor = Color.Azure;
                                        dtDoorOpenButton[item].Enabled = true;
                                        dtDoorOpenButton[item].BackColor = Color.White;
                                        dtDoorCloseButton[item].Enabled = false;
                                        dtDoorCloseButton[item].BackColor = Color.Silver;
                                        break;
                                    case (int)DoorInfo.EDoorState.Loading:
                                        dtDoorStateLabel[item].Text = "门未到位";
                                        dtDoorStateLabel[item].BackColor = Color.Yellow;
                                        dtDoorOpenButton[item].Enabled = true;
                                        dtDoorOpenButton[item].BackColor = Color.White;
                                        dtDoorCloseButton[item].Enabled = true;
                                        dtDoorCloseButton[item].BackColor = Color.White;
                                        break;
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }
        //房门控制按钮
        void btnDoorControl_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int doorNo = Convert.ToInt32(btn.Tag.ToString());
                byte relationNumber = 1;
                if (Common.Instance.dtDoorInfo[doorNo].Relation > 0)
                {
                    relationNumber = Common.Instance.dtDoorInfo[doorNo].RelationNumber;
                }
                //if (Common.Instance.dtDoorInfo[doorNo].State == (int)DoorInfo.EDoorState.Close)
                //{//开门 
                DoorUdpClient.dtDoorUdp[doorNo].WriteDoorOperate(DoorUdpClient.EDoorOperate.Open, relationNumber);
                //}
                //else if (Common.Instance.dtDoorInfo[doorNo].State == (int)DoorInfo.EDoorState.Loading) { }

            }
            catch { }
        }
        #endregion

        #region 电梯状态控件创建
        private void CreateElevatorStateControls()
        {
            try
            {
                if (Common.Instance.dtElevatorInfo.Count > 0)
                {//存在房门控制，可创建控件组 
                    int i = 0;
                    //Common.Instance.dtElevatorInfo = Common.Instance.dtElevatorInfo.OrderBy(o => o.Value.ChargeType).ToDictionary(o => o.Key, p => p.Value);
                    double dAgvCount = 1;
                    if (maaciList.Count > 0)
                        dAgvCount = maaciList.Count;
                    double interval = 10 / ((double)dAgvCount);
                    double addIn = WaitForm.pValue;
                    //EChargeType ctype = EChargeType.PreAging;
                    List<int> dkey = Common.Instance.dtElevatorInfo.Keys.ToList();
                    for (int j = 0; j < dkey.Count; j++)
                    {
                        int item = dkey[j];
                        Panel panElevator = new Panel();
                        panElevator.BorderStyle = BorderStyle.FixedSingle;
                        panElevator.Size = new Size(180, 80);
                        panElevator.Parent = panElevatorState;
                        panElevator.Location = new Point(i % 10 * 180, i / 10 * 85);
                        i++;
                        //label 电梯信息
                        Label lblElevatorName = new Label();
                        lblElevatorName.AutoSize = false;
                        lblElevatorName.Size = new Size(180, 40);
                        lblElevatorName.BackColor = Color.Azure;
                        lblElevatorName.BorderStyle = BorderStyle.FixedSingle;
                        lblElevatorName.Location = new Point(0, 0);
                        lblElevatorName.TextAlign = ContentAlignment.MiddleLeft;
                        lblElevatorName.Text = string.Format("{0}\r\nIP:{1}", Common.Instance.dtElevatorInfo[item].Name, Common.Instance.dtElevatorInfo[item].ElevatorComm.Ip);
                        lblElevatorName.Parent = panElevator;
                        //label 电梯状态
                        Label lblElevatorState = new Label();
                        lblElevatorState.AutoSize = false;
                        lblElevatorState.Size = new Size(40, 40);
                        lblElevatorState.Font = new Font("宋体", 9f, FontStyle.Regular);
                        lblElevatorState.BorderStyle = BorderStyle.FixedSingle;
                        lblElevatorState.Location = new Point(0, 40);
                        lblElevatorState.TextAlign = ContentAlignment.MiddleCenter;
                        lblElevatorState.BackColor = Color.Silver;
                        lblElevatorState.Text = "通讯异常";
                        dtElevatorStateLabel[item] = lblElevatorState;
                        lblElevatorState.Parent = panElevator;
                        //label 电梯绑定状态
                        Label lblElevatotBind = new Label();
                        lblElevatotBind.AutoSize = false;
                        lblElevatotBind.Font = new Font("宋体", 9f, FontStyle.Regular);
                        lblElevatotBind.Size = new Size(40, 40);
                        lblElevatotBind.BorderStyle = BorderStyle.FixedSingle;
                        lblElevatotBind.Location = new Point(40, 40);
                        lblElevatotBind.TextAlign = ContentAlignment.MiddleCenter;
                        lblElevatotBind.BackColor = Color.Silver;
                        lblElevatotBind.Text = "null";
                        lblElevatotBind.Tag = item;
                        lblElevatotBind.DoubleClick += LblElevatotBind_DoubleClick;
                        dtElevatorBindLabel[item] = lblElevatotBind;
                        lblElevatotBind.Parent = panElevator;
                        //label 电梯门开楼层
                        Label lblElevatorOpenFloor = new Label();
                        lblElevatorOpenFloor.AutoSize = false;
                        lblElevatorOpenFloor.Size = new Size(40, 40);
                        lblElevatorOpenFloor.Font = new Font("宋体", 9f, FontStyle.Regular);
                        lblElevatorOpenFloor.BorderStyle = BorderStyle.FixedSingle;
                        lblElevatorOpenFloor.Location = new Point(0, 40);
                        lblElevatorOpenFloor.TextAlign = ContentAlignment.MiddleCenter;
                        lblElevatorOpenFloor.BackColor = Color.Silver;
                        lblElevatorOpenFloor.Text = "门关闭";
                        dtElevatorOpenLabel[item] = lblElevatorOpenFloor;
                        lblElevatorOpenFloor.Parent = panElevator;
                        //开门按钮
                        Button btnElevatorOpen = new Button();
                        btnElevatorOpen.Size = new Size(30, 40);
                        btnElevatorOpen.Location = new Point(120, 40);
                        btnElevatorOpen.Text = "开门";
                        btnElevatorOpen.Tag = item;
                        btnElevatorOpen.Enabled = false;
                        dtElevatorOpenButton[item] = btnElevatorOpen;
                        btnElevatorOpen.Click += BtnElevatorOpen_Click;
                        btnElevatorOpen.Parent = panElevator;
                        //关闭按钮                        
                        Button btnElevatorClose = new Button();
                        btnElevatorClose.Size = new Size(30, 40);
                        btnElevatorClose.Location = new Point(150, 40);
                        btnElevatorClose.Text = "关门";
                        btnElevatorClose.Tag = item;
                        btnElevatorClose.Enabled = false;
                        dtElevatorCloseButton[item] = btnElevatorClose;
                        btnElevatorClose.Click += BtnElevatorClose_Click;
                        btnElevatorClose.Parent = panElevator;
                        addIn += interval;
                        WaitForm.pValue = (int)addIn;
                        WaitFormService.SetContents(string.Format("电梯{0}]状态控件生成完毕...", Common.Instance.dtChargeInfo[item].ChargeName));
                    }
                }
            }
            catch { }
        }

        private void BtnElevatorClose_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int eleNo = Convert.ToInt32(btn.Tag.ToString());
                ElevatorUdpClient.dtElevatorUdp[eleNo].WriteElevatorOperate(ElevatorUdpClient.EElevatorOperate.CloseElevator, 0);
            }
            catch { }
        }

        private void BtnElevatorOpen_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int eleNo = Convert.ToInt32(btn.Tag.ToString());
                ElevatorUdpClient.dtElevatorUdp[eleNo].WriteElevatorOperate(ElevatorUdpClient.EElevatorOperate.CloseElevator, 0);
            }
            catch { }
        }

        private void LblElevatotBind_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (LoginRoler.U_Level > 1)
                {
                    Label lbl = (Label)sender;
                    int chargeNo = Convert.ToInt32(lbl.Tag.ToString());
                    if (Common.Instance.dtElevatorInfo[chargeNo].BindAgv > 0)
                    {
                        if (MessageBox.Show(string.Format("是否要清除 {0} 状态", lbl.Text), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Common.Instance.dtElevatorInfo[chargeNo].BindAgv = 0;
                        }
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// 刷新电梯状态
        /// </summary>
        private void UpdateElevatorState()
        {
            try
            {
                if (Common.Instance.dtElevatorInfo.Count > 0)
                {
                    List<int> keyLs = Common.Instance.dtElevatorInfo.Keys.ToList();
                    foreach (int item in keyLs)
                    {
                        try
                        {
                            if (Common.Instance.dtElevatorInfo.ContainsKey(item))
                            {
                                string callButtonStr = string.Empty;
                                if (Common.Instance.dtElevatorInfo[item].ButtonStatus.Count > 0)
                                {
                                    try
                                    {
                                        foreach (KeyValuePair<int, bool> bs in Common.Instance.dtElevatorInfo[item].ButtonStatus)
                                        {
                                            if (bs.Value) callButtonStr += bs.Key.ToString() + ",";
                                        }
                                        callButtonStr = callButtonStr.Trim(',');
                                    }
                                    catch { }
                                }
                                switch (Common.Instance.dtElevatorInfo[item].state)
                                {
                                    case ElevatorStatus.Line:
                                        dtElevatorCloseButton[item].Enabled = false;
                                        dtElevatorOpenButton[item].Enabled = false;
                                        dtElevatorStateLabel[item].BackColor = Color.Silver;
                                        dtElevatorStateLabel[item].Text = "通讯异常";
                                        break;
                                    case ElevatorStatus.init:
                                        dtElevatorCloseButton[item].Enabled = true;
                                        dtElevatorOpenButton[item].Enabled = true;
                                        dtElevatorStateLabel[item].BackColor = Color.Lime;
                                        dtElevatorStateLabel[item].Text = string.Format("初始化\r\n{0}", string.Join(",", callButtonStr));
                                        break;
                                    case ElevatorStatus.elevatorBeginOpen:
                                        dtElevatorCloseButton[item].Enabled = true;
                                        dtElevatorOpenButton[item].Enabled = true;
                                        dtElevatorStateLabel[item].BackColor = Color.Lime;
                                        dtElevatorStateLabel[item].Text = string.Format("楼{0}开\r\n{1}", string.Join(",", Common.Instance.dtElevatorInfo[item].BeginFloor, callButtonStr));
                                        break;
                                    case ElevatorStatus.agvInFinish:
                                        dtElevatorCloseButton[item].Enabled = true;
                                        dtElevatorOpenButton[item].Enabled = true;
                                        dtElevatorStateLabel[item].BackColor = Color.Lime;
                                        dtElevatorStateLabel[item].Text = string.Format("进入电梯\r\n{0}", string.Join(",", callButtonStr));
                                        break;
                                    case ElevatorStatus.elevatorEndOpen:
                                        dtElevatorCloseButton[item].Enabled = true;
                                        dtElevatorOpenButton[item].Enabled = true;
                                        dtElevatorStateLabel[item].BackColor = Color.Lime;
                                        dtElevatorStateLabel[item].Text = string.Format("楼{0}开\r\n{1}", string.Join(",", Common.Instance.dtElevatorInfo[item].EndFloor, callButtonStr));
                                        break;
                                    case ElevatorStatus.agvOutFinish:
                                        dtElevatorCloseButton[item].Enabled = true;
                                        dtElevatorOpenButton[item].Enabled = true;
                                        dtElevatorStateLabel[item].BackColor = Color.Lime;
                                        dtElevatorStateLabel[item].Text = string.Format("移出电梯\r\n{0}", string.Join(",", callButtonStr));
                                        break;
                                }
                                if (Common.Instance.dtElevatorInfo[item].BindAgv > 0)
                                {
                                    dtElevatorBindLabel[item].BackColor = Color.Red;
                                    dtElevatorBindLabel[item].Text = string.Format("AGV{0}\r\n{1}_{2}", Common.Instance.dtElevatorInfo[item].BindAgv, Common.Instance.dtElevatorInfo[item].BeginFloor, Common.Instance.dtElevatorInfo[item].EndFloor);
                                }
                                else
                                {
                                    dtElevatorBindLabel[item].BackColor = Color.Lime;
                                    dtElevatorBindLabel[item].Text = "Null";
                                }
                                if (Common.Instance.dtElevatorInfo[item].OpenFloor > 0)
                                {
                                    dtElevatorOpenLabel[item].BackColor = Color.Lime;
                                    dtElevatorOpenLabel[item].Text = string.Format("楼{0}门开", Common.Instance.dtElevatorInfo[item].OpenFloor);
                                }
                                else
                                {
                                    dtElevatorOpenLabel[item].BackColor = Color.White;
                                    dtElevatorOpenLabel[item].Text = "电梯门关";
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }
        #endregion

        #region 充电桩状态控件创建
        private void CreateChargeStateControls()
        {
            try
            {
                if (Common.Instance.dtChargeInfo.Count > 0)
                {//存在房门控制，可创建控件组 
                    int i = 0;
                    Common.Instance.dtChargeInfo = Common.Instance.dtChargeInfo.OrderBy(o => o.Value.ChargeType).ToDictionary(o => o.Key, p => p.Value);
                    double dAgvCount = 1;
                    if (maaciList.Count > 0)
                        dAgvCount = maaciList.Count;
                    double interval = 10 / ((double)dAgvCount);
                    double addIn = WaitForm.pValue;
                    //EChargeType ctype = EChargeType.PreAging;
                    List<int> dkey = Common.Instance.dtChargeInfo.Keys.ToList();
                    for (int j = 0; j < dkey.Count; j++)
                    {
                        int item = dkey[j];
                        Panel panCharge = new Panel();
                        panCharge.BorderStyle = BorderStyle.FixedSingle;
                        panCharge.Size = new Size(180, 80);
                        panCharge.Parent = panChargeInfoState;
                        panCharge.Location = new Point(i % 10 * 180, i / 10 * 85);
                        if (j < dkey.Count - 1)
                        {
                            if (Common.Instance.dtChargeInfo[item].ChargeType != Common.Instance.dtChargeInfo[dkey[j + 1]].ChargeType && i != 0 && Common.Instance.dtChargeInfo[item].ChargeType != EChargeType.PreAging)
                            {
                                i = i + 10 - i % 10;
                            }
                            else
                            { i++; }
                        }
                        else
                        {
                            i++;
                        }
                        //label 充电桩信息
                        Label lblChargerName = new Label();
                        lblChargerName.AutoSize = false;
                        lblChargerName.Size = new Size(180, 40);
                        lblChargerName.BackColor = Color.Azure;
                        lblChargerName.BorderStyle = BorderStyle.FixedSingle;
                        lblChargerName.Location = new Point(0, 0);
                        lblChargerName.TextAlign = ContentAlignment.MiddleLeft;
                        lblChargerName.Text = string.Format("{0}\r\nIP:{1}", Common.Instance.dtChargeInfo[item].ChargeName, Common.Instance.dtChargeInfo[item].ChargeComm.IpString);
                        lblChargerName.Parent = panCharge;
                        //label 充电桩状态
                        Label lblChargeState = new Label();
                        lblChargeState.AutoSize = false;
                        lblChargeState.Size = new Size(80, 40);
                        lblChargeState.BorderStyle = BorderStyle.FixedSingle;
                        lblChargeState.Location = new Point(0, 40);
                        lblChargeState.TextAlign = ContentAlignment.MiddleCenter;
                        lblChargeState.BackColor = Color.Silver;
                        lblChargeState.Text = "通讯异常";
                        dtChargeStateLabel[item] = lblChargeState;
                        lblChargeState.Parent = panCharge;
                        //label 充电桩绑定状态
                        Label lblChargeBind = new Label();
                        lblChargeBind.AutoSize = false;
                        lblChargeBind.Font = new Font("宋体", 9f, FontStyle.Regular);
                        lblChargeBind.Size = new Size(40, 40);
                        lblChargeBind.BorderStyle = BorderStyle.FixedSingle;
                        lblChargeBind.Location = new Point(80, 40);
                        lblChargeBind.TextAlign = ContentAlignment.MiddleCenter;
                        lblChargeBind.BackColor = Color.Silver;
                        lblChargeBind.Text = "null";
                        lblChargeBind.Tag = item;
                        lblChargeBind.DoubleClick += lblChargeBind_DoubleClick;
                        dtChargeBindLabel[item] = lblChargeBind;
                        lblChargeBind.Parent = panCharge;
                        //充电桩伸出按钮
                        Button btnChargeOutput = new Button();
                        btnChargeOutput.Size = new Size(30, 40);
                        btnChargeOutput.Location = new Point(120, 40);
                        btnChargeOutput.Text = "伸出";
                        btnChargeOutput.Tag = item;
                        btnChargeOutput.Enabled = false;
                        dtChargeOutputButton[item] = btnChargeOutput;
                        btnChargeOutput.Click += btnChargeOutput_Click;
                        btnChargeOutput.Parent = panCharge;
                        //充电桩缩进按钮                        
                        Button btnChargeInput = new Button();
                        btnChargeInput.Size = new Size(30, 40);
                        btnChargeInput.Location = new Point(150, 40);
                        btnChargeInput.Text = "缩进";
                        btnChargeInput.Tag = item;
                        btnChargeInput.Enabled = false;
                        dtChargeInputButton[item] = btnChargeInput;
                        btnChargeInput.Click += btnChargeInput_Click;
                        btnChargeInput.Parent = panCharge;
                        addIn += interval;
                        WaitForm.pValue = (int)addIn;
                        WaitFormService.SetContents(string.Format("[充电桩{0}]状态控件生成完毕...", Common.Instance.dtChargeInfo[item].ChargeName));
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// 清除绑定信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lblChargeBind_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (LoginRoler.U_Level > 1)
                {
                    Label lbl = (Label)sender;
                    int chargeNo = Convert.ToInt32(lbl.Tag.ToString());
                    if (Common.Instance.dtChargeInfo[chargeNo].BindAgv > 0)
                    {
                        if (MessageBox.Show(string.Format("是否要清除 {0} 状态", lbl.Text), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Common.Instance.dtChargeInfo[chargeNo].BindAgv = 0;
                        }
                    }
                }
            }
            catch { }
        }

        void btnChargeInput_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int chargeNo = Convert.ToInt32(btn.Tag.ToString());
                ChargeUdpClient.dtChargeUdp[chargeNo].WriteChargeOperate(ChargeUdpClient.EChargeOperate.Input);

            }
            catch { }
        }

        void btnChargeOutput_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int chargeNo = Convert.ToInt32(btn.Tag.ToString());
                ChargeUdpClient.dtChargeUdp[chargeNo].WriteChargeOperate(ChargeUdpClient.EChargeOperate.Output);

            }
            catch { }
        }
        /// <summary>
        /// 实时更新房门状态
        /// </summary>
        private void UpdateChargeState()
        {
            try
            {
                if (Common.Instance.dtChargeInfo.Count > 0)
                {
                    List<int> keyLs = Common.Instance.dtChargeInfo.Keys.ToList();
                    foreach (int item in keyLs)
                    {
                        try
                        {
                            //chargeOutputButton   
                            //chargeInputButton
                            if (dtChargeStateLabel.ContainsKey(item))
                            {
                                switch (Common.Instance.dtChargeInfo[item].State)
                                {
                                    case (int)EChargeCommState.OffLine:
                                        dtChargeStateLabel[item].Text = "通讯异常";
                                        dtChargeStateLabel[item].BackColor = Color.Silver;
                                        dtChargeOutputButton[item].Enabled = false;
                                        dtChargeOutputButton[item].BackColor = Color.Silver;
                                        dtChargeInputButton[item].Enabled = false;
                                        dtChargeInputButton[item].BackColor = Color.Silver;
                                        break;
                                    case (int)EChargeCommState.Output:
                                        dtChargeStateLabel[item].Text = "伸出到位";
                                        dtChargeStateLabel[item].BackColor = Color.Lime;
                                        dtChargeOutputButton[item].Enabled = false;
                                        dtChargeOutputButton[item].BackColor = Color.Silver;
                                        dtChargeInputButton[item].Enabled = true;
                                        dtChargeInputButton[item].BackColor = Color.White;
                                        break;
                                    case (int)EChargeCommState.Input:
                                        dtChargeStateLabel[item].Text = "缩进到位";
                                        dtChargeStateLabel[item].BackColor = Color.Lime;
                                        dtChargeOutputButton[item].Enabled = true;
                                        dtChargeOutputButton[item].BackColor = Color.White;
                                        dtChargeInputButton[item].Enabled = false;
                                        dtChargeInputButton[item].BackColor = Color.Silver;
                                        break;
                                    case (int)EChargeCommState.Loading:
                                        dtChargeStateLabel[item].Text = "执行中";
                                        dtChargeStateLabel[item].BackColor = Color.Lime;
                                        dtChargeOutputButton[item].Enabled = true;
                                        dtChargeOutputButton[item].BackColor = Color.White;
                                        dtChargeInputButton[item].Enabled = true;
                                        dtChargeInputButton[item].BackColor = Color.White;
                                        break;
                                }
                                //if (Common.Instance.dtChargeInfo[item].ChargeComm.Enable == false)
                                //{
                                //    dtChargeStateLabel[item].Text = "禁用";
                                //    dtChargeStateLabel[item].BackColor = Color.Red;
                                //    dtChargeOutputButton[item].Enabled = false;
                                //    dtChargeOutputButton[item].BackColor = Color.Silver;
                                //    dtChargeInputButton[item].Enabled = false;
                                //    dtChargeInputButton[item].BackColor = Color.Silver;
                                //}
                                if (Common.Instance.dtChargeInfo[item].BindAgv <= 0)
                                {
                                    dtChargeBindLabel[item].BackColor = Color.Lime;
                                    dtChargeBindLabel[item].Text = "Null";
                                }
                                else if (Common.Instance.dtChargeInfo[item].BindAgv > 0 && Common.Instance.dtChargeInfo[item].BindAgv < 100)
                                {
                                    dtChargeBindLabel[item].BackColor = Color.Red;
                                    dtChargeBindLabel[item].Text = string.Format("Agv{0}", Common.Instance.dtChargeInfo[item].BindAgv);
                                }
                                else if (Common.Instance.dtChargeInfo[item].BindAgv >= 100)
                                {
                                    dtChargeBindLabel[item].BackColor = Color.Yellow;
                                    dtChargeBindLabel[item].Text = string.Format("Bind[Agv{0}]", Common.Instance.dtChargeInfo[item].BindAgv - 100);
                                }
                            }
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }
        #endregion

        #region 站点操作提示
        private void txtStationOperate_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void txtStationOperate_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                tooltip.Dispose();
                tooltip = new ToolTip();
                //tooltip.BackColor = agvModel[agvNo].BackColor;
                tooltip.SetToolTip((Control)sender, "分容柜站点 0:左边，1：右边\r\n其它：0");
            }
            catch { }
        }
        #endregion

        #region 老化房agv配置
        private void btnPreAgingRoomRfidReceive_Click(object sender, EventArgs e)
        {
            try
            {
                txtPreAgingRoomLoadAreaRfid.Text = Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].LoadRfid.ToString();
                txtPreAgingRoomStaticAreaRfid.Text = Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].StaticArea1Rfid.ToString();
                txtPreAgingRoomUnloadAreaRfid.Text = Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].UnloadRfid.ToString();
            }
            catch { }
        }

        private void btnPreAgingRoomUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].LoadRfid = Convert.ToInt32(txtPreAgingRoomLoadAreaRfid.Text);
                Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].StaticArea1Rfid = Convert.ToInt32(txtPreAgingRoomStaticAreaRfid.Text);
                Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_2].UnloadRfid = Convert.ToInt32(txtPreAgingRoomUnloadAreaRfid.Text);
            }
            catch
            {
                MessageBox.Show("输入参数格式不对，值只能为数字类型");
            }
        }

        private void btnCapAgingRoomRfidReceive_Click(object sender, EventArgs e)
        {
            try
            {
                txtCapAgingRoomLoadAreaRfid.Text = Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].LoadRfid.ToString();
                txtCapAgingRoomStaticArea1Rfid.Text = Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].StaticArea1Rfid.ToString();
                txtCapAgingRoomStaticArea2Rfid.Text = Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].StaticArea2Rfid.ToString();
                txtCapAgingRoomUnloadAreaRfid.Text = Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].UnloadRfid.ToString();
            }
            catch { }
        }

        private void btnCapAgingRoomUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].LoadRfid = Convert.ToInt32(txtCapAgingRoomLoadAreaRfid.Text);
                Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].StaticArea1Rfid = Convert.ToInt32(txtCapAgingRoomStaticArea1Rfid.Text);
                Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].StaticArea2Rfid = Convert.ToInt32(txtCapAgingRoomStaticArea2Rfid.Text);
                Common.Instance.dtAgingRoomInfo[Enumerations.agvType.type_3].UnloadRfid = Convert.ToInt32(txtCapAgingRoomUnloadAreaRfid.Text);
            }
            catch
            {
                MessageBox.Show("输入参数格式不对，值只能为数字类型");
            }
        }
        #endregion

        #region 掉线前任务获取
        private void ReceiveTask()
        {
            try
            {
                List<MA_AgvTaskInfo> lsTask = BA_XmlOperate.TaskInfoRead();
                foreach (MA_AgvTaskInfo item in lsTask)
                {
                    switch (item.T_Type)
                    {
                        case Enumerations.TaskType.Transport_A_F:
                        case Enumerations.TaskType.Transport_A_C:
                        case Enumerations.TaskType.Transport_C_F:
                        case Enumerations.TaskType.Transport_E_A:
                        case Enumerations.TaskType.Transport_B_E:
                        case Enumerations.TaskType.Transport_B_D:
                        case Enumerations.TaskType.Transport_D_E:
                        case Enumerations.TaskType.Transport_F_B:
                        case Enumerations.TaskType.Charge_Go:
                        case Enumerations.TaskType.Chareg_Leave:
                            Common.taskDt[item.Group].Add(item.T_Id, item);
                            break;
                    }
                    if (item.T_AgvNo > 0)
                    {
                        if (Common.maiDict.ContainsKey(item.T_AgvNo))
                        {
                            if (item.T_State == Enumerations.TaskStatus.Book || item.T_State == Enumerations.TaskStatus.Accept) Common.maiDict[item.T_AgvNo].Task2 = item.T_Id;
                            else Common.maiDict[item.T_AgvNo].Task1 = item.T_Id;
                        }
                    }
                }
            }
            catch { }
        }
        #endregion

        #region 任务刷新设定
        private void cbCapTestTaskRefEnable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (isLOadOk)
                {
                    Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_1].TaskRefreshEnable = cbCapTestTaskRefEnable.Checked;
                }
            }
            catch { }
        }

        private void btnCapTestTaskSet_Click(object sender, EventArgs e)
        {
            try
            {
                int time = Convert.ToInt32(txtCapTestTaskTime.Text);
                if (time > 0)
                {
                    Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_1].TaskRefreshTime = time;
                    MessageBox.Show("Modify successfully!");
                }
                else
                {
                    MessageBox.Show("The value needs to be greater than zero");
                }
            }
            catch
            {
                MessageBox.Show("Values need to be numeric");
            }
        }

        private void cbPreAgingTaskRefEnable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (isLOadOk)
                {
                    Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_2].TaskRefreshEnable = cbPreAgingTaskRefEnable.Checked;
                }
            }
            catch { }
        }

        private void btnPreAgingTaskSet_Click(object sender, EventArgs e)
        {
            try
            {
                int time = Convert.ToInt32(txtPreAgingTaskTime.Text);
                if (time > 0)
                {
                    Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_2].TaskRefreshTime = time;
                    MessageBox.Show("Modify successfully!");
                }
                else
                {
                    MessageBox.Show("The value needs to be greater than zero");
                }
            }
            catch
            {
                MessageBox.Show("Values need to be numeric");
            }
        }

        private void cbCapAgingTaskRefEnable_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (isLOadOk)
                {
                    Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_3].TaskRefreshEnable = cbCapAgingTaskRefEnable.Checked;
                }
            }
            catch { }
        }

        private void btnCapAgingTaskSet_Click(object sender, EventArgs e)
        {
            try
            {
                int time = Convert.ToInt32(txtCapAgingTaskTime.Text);
                if (time > 0)
                {
                    Common.Instance.dtAgvTypeInfo[Enumerations.agvType.type_3].TaskRefreshTime = time;
                    MessageBox.Show("Modify successfully!");
                }
                else
                {
                    MessageBox.Show("The value needs to be greater than zero");
                }
            }
            catch
            {
                MessageBox.Show("Values need to be numeric");
            }
        }
        private void btnCapTestTaskManualRef_Click(object sender, EventArgs e)
        {
            RefCapTestCurrentTask();
        }
        private void btnPreAgingTaskManualRef_Click(object sender, EventArgs e)
        {
            RefPreAgingCurrentTask();
        }
        private void btnCapAgingTaskManualRef_Click(object sender, EventArgs e)
        {
            RefCapAgingCurrentTask();
        }
        #endregion

        #region 交通管制控制
        private void btnAgvLock_Click(object sender, EventArgs e)
        {
            try
            {
                BA_AgvCommunicationThread.AgvCommuDt[Common.Instance.TestAgvNo].Lock();
            }
            catch { }
        }

        private void btnAgvUnlock_Click(object sender, EventArgs e)
        {
            try
            {
                BA_AgvCommunicationThread.AgvCommuDt[Common.Instance.TestAgvNo].Unlock();
            }
            catch { }
        }
        #endregion

        #region 交通管控控件
        private void CreateControlLabel()
        {
            try
            {
                if (Common.controlPointsDict.Count > 0)
                {//存在房门控制，可创建控件组 
                    int i = 0;
                    Common.controlPointsDict = Common.controlPointsDict.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);
                    //double interval = 5 / ((double)maaciList.Count);
                    //double addIn = WaitForm.pValue;
                    //EChargeType ctype = EChargeType.PreAging;
                    List<int> dkey = Common.controlPointsDict.Keys.ToList();
                    for (int j = 0; j < dkey.Count; j++)
                    {
                        int item = dkey[j];
                        Panel panControls = new Panel();
                        panControls.BorderStyle = BorderStyle.FixedSingle;
                        panControls.Size = new Size(180, 70);
                        panControls.Parent = panAgvControls;
                        panControls.Location = new Point(i % 10 * 180, i / 10 * 75);
                        i++;
                        //label 管控RFID集合
                        Label lblContolsRfids = new Label();
                        lblContolsRfids.AutoSize = false;
                        lblContolsRfids.Size = new Size(140, 70);
                        lblContolsRfids.BackColor = Color.Azure;
                        lblContolsRfids.BorderStyle = BorderStyle.FixedSingle;
                        lblContolsRfids.Location = new Point(0, 0);
                        lblContolsRfids.TextAlign = ContentAlignment.MiddleLeft;
                        lblContolsRfids.Text = string.Format("[{0}]  {1}", item, string.Join(",", Common.controlPointsDict[item]));
                        lblContolsRfids.Font = new Font("宋体", 7.5f, FontStyle.Regular);
                        dtControlsRfids[item] = lblContolsRfids;
                        lblContolsRfids.Parent = panControls;
                        //label 进入管控AGV
                        Label lblControlsAgvs = new Label();
                        lblControlsAgvs.AutoSize = false;
                        lblControlsAgvs.Size = new Size(40, 70);
                        lblControlsAgvs.BorderStyle = BorderStyle.FixedSingle;
                        lblControlsAgvs.Location = new Point(140, 0);
                        lblControlsAgvs.TextAlign = ContentAlignment.MiddleCenter;
                        lblControlsAgvs.BackColor = Color.White;
                        lblControlsAgvs.Text = string.Empty;
                        lblControlsAgvs.Tag = item;
                        lblControlsAgvs.Click += lblControlsAgvs_Click;
                        lblControlsAgvs.DoubleClick += lblControlsAgvs_DoubleClick;
                        dtControlsAgvs[item] = lblControlsAgvs;
                        lblControlsAgvs.Parent = panControls;

                        //addIn += interval;
                        //WaitForm.pValue = (int)addIn;
                        //WaitFormService.SetContents(string.Format("[管控{0}]状态控件生成完毕...", item));
                    }
                }
            }
            catch { }
        }

        void lblControlsAgvs_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (LoginRoler.U_Level > 1)
                {
                    Label lbl = (Label)sender;
                    int item = Convert.ToInt32(lbl.Tag);
                    if (Common.controlPointAgvList[item].Count > 0)
                    {
                        if (MessageBox.Show(string.Format("是否清除管控[{0}]当前AGV", item), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        {
                            int agvNo = Common.controlPointAgvList[item][0];
                            while (Common.controlPointAgvList[item].Contains(agvNo)) Common.controlPointAgvList[item].Remove(agvNo);
                        }
                    }
                }
            }
            catch { }
        }

        void lblControlsAgvs_Click(object sender, EventArgs e)
        {

        }
        private void RefControlState()
        {
            try
            {
                List<int> cLs = Common.controlPointsDict.Keys.ToList();
                foreach (int item in cLs)
                {
                    if (Common.controlPointsDict[item].Count > 0)
                        dtControlsRfids[item].Text = string.Format("[{0}]  {1}", item, string.Join(",", Common.controlPointsDict[item]));
                    else
                        dtControlsRfids[item].Text = string.Format("[{0}]", item);
                    if (Common.controlPointAgvList[item].Count > 0)
                        dtControlsAgvs[item].Text = string.Join(",", Common.controlPointAgvList[item]);
                    else
                        dtControlsAgvs[item].Text = string.Empty;
                }
            }
            catch { }
        }
        private void btnManualRefControlState_Click(object sender, EventArgs e)
        {
            RefControlState();
        }
        #endregion

        #region 自动添加任务
        private void btnCapTestStationsRec_Click(object sender, EventArgs e)
        {
            try
            {
                txtCapTestStations.Text = testStations.ToString();
            }
            catch { }
        }

        private void btnCapTestStationsRef_Click(object sender, EventArgs e)
        {
            try
            {
                int count = Convert.ToInt32(txtCapTestStations.Text);
                if (count > 0 && count <= 10)
                {
                    testStations = count;
                    Common.testStations = testStations;
                    MessageBox.Show("设定成功!");
                }
                else
                {
                    MessageBox.Show("只能为1－5");
                }
            }
            catch
            {
                MessageBox.Show("只能为数值类型");
            }
        }
        private void AutoTask()
        {
            while (true)
            {
                if (Common.isAutoTask)
                {
                    try
                    {

                    }
                    catch { }
                }
                Thread.Sleep(20);
            }
        }
        /// <summary>
        /// 操作转换
        /// </summary>
        /// <param name="taskType">任务类型</param>
        /// <param name="stationInformation">站点信息，记录站点的操作信息</param>
        /// <returns></returns>
        private int OperateTranform(Enumerations.TaskType taskType, string stationInformation)
        {
            int operate = 0;
            try
            {
                int sti = Convert.ToInt32(stationInformation); ;
                //switch (taskType)
                //{
                //    case Enumerations.TaskType.Test_FullCommparmentRefueling:
                //        operate = sti == 1 ? Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftRefueling] : Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightRefueling];
                //        break;
                //    case Enumerations.TaskType.Test_FullCommparmentRequest:
                //        operate = sti == 1 ? Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftUnload] : Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightUnload];
                //        break;
                //    case Enumerations.TaskType.Test_NullCompartmentRequest:
                //        operate = sti == 1 ? Common.Instance.dtStationOperate[StationInformation.EStationOperate.LeftLoad] : Common.Instance.dtStationOperate[StationInformation.EStationOperate.RightLoad];
                //        break;
                //    //case Enumerations.TaskType.Pre_RestingZone_Load:
                //    //    operate
                //}
            }
            catch { }
            return operate;
        }
        private void btnTestSubRec_Click(object sender, EventArgs e)
        {
            try
            {
                txtTestSub.Text = string.Empty;
                for (int i = 0; i < Common.subCabinetLs.Count; i++)
                {
                    txtTestSub.Text += Common.subCabinetLs[i].GroupValue;
                    txtTestSub.Text += ",";
                }
            }
            catch { }
        }

        private void btnTestSutSet_Click(object sender, EventArgs e)
        {
            try
            {
                string[] ss = txtTestSub.Text.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                Common.subCabinetLs.Clear();
                if (ss.Length > 0)
                {
                    foreach (string item in ss)
                    {
                        string[] sss = item.Trim().Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                        if (sss.Length == 2)
                        {
                            if (Convert.ToInt32(sss[0]) <= 78 && Convert.ToInt32(sss[0]) >= 1)
                            {
                                if (Convert.ToInt32(sss[1]) >= 1 && Convert.ToInt32(sss[1]) <= 20)
                                {
                                    try
                                    {
                                        int agvNo = -1;
                                        int group = Convert.ToInt32(sss[0]);
                                        int index = Convert.ToInt32(sss[1]);
                                        int command = -1;
                                        int count = Common.testStations;
                                        bool enable = false;
                                        string match = string.Empty;
                                        bool isCreate = true;
                                        //if (index > 10)
                                        //{
                                        //    match = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationRfidLs < 5500 && o.Value.StationRfidLs % 10 == index % 10).Value.StationMatchValue;
                                        //    if (index - 10 + count > 11) isCreate = false;
                                        //}
                                        //else
                                        //{
                                        //    match = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationRfidLs >= 5500 && o.Value.StationRfidLs % 10 == index % 10).Value.StationMatchValue;
                                        //    if (index + count > 11) isCreate = false;
                                        //}
                                        //if (match != string.Empty && isCreate)
                                        //{
                                        //    int rfid = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == match).Value.StationRfidLs;
                                        //    Common.subCabinetLs.Add(new MatchStationInfo(agvNo, match, rfid, count, command, enable, item));
                                        //}
                                    }
                                    catch { }
                                }
                                else
                                {
                                    MessageBox.Show("南边或北边填错（10以上：南边, 10以下:北边）");
                                }
                            }
                            else
                            {
                                MessageBox.Show("组别填错,范围为（1--78）");
                            }
                        }
                        else
                        {
                            MessageBox.Show("格式有误");
                        }
                    }
                }
                try
                {
                    txtTestSub.Text = string.Empty;
                    for (int i = 0; i < Common.subCabinetLs.Count; i++)
                    {
                        txtTestSub.Text += Common.subCabinetLs[i].GroupValue;
                        txtTestSub.Text += ",";
                    }
                }
                catch { }
            }
            catch
            {
                MessageBox.Show("类型只能为数值类型，用','隔开");
            }
        }
        private void btnAutoTaskAgvsRec_Click(object sender, EventArgs e)
        {
            try
            {
                txtAutoTaskAgvs.Text = string.Join(",", Common.subCabinetAutoTaskAgvLs);
            }
            catch { }
        }

        private void btnAutoTaskAgvsRef_Click(object sender, EventArgs e)
        {
            try
            {
                Common.subCabinetAutoTaskAgvLs.Clear();
                string[] ss = txtAutoTaskAgvs.Text.Trim().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in ss)
                {
                    string[] sas = item.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                    if (sas.Length == 1)
                    {
                        int agvNo = Convert.ToInt32(item);
                        if (agvNo > 0 && agvNo <= 54)
                        {
                            if (Common.subCabinetAutoTaskAgvLs.Contains(agvNo) == false)
                            {
                                Common.subCabinetAutoTaskAgvLs.Add(agvNo);
                            }
                        }
                    }
                    else if (sas.Length == 2)
                    {
                        try
                        {
                            int a1 = Convert.ToInt32(sas[0]);
                            int a2 = Convert.ToInt32(sas[1]);
                            if (a1 < a2 && a1 > 0 && a1 < 54 && a2 > 0 && a2 <= 54)
                            {
                                for (int i = a1; i < a2 + 1; i++)
                                {
                                    if (Common.subCabinetAutoTaskAgvLs.Contains(i) == false)
                                    {
                                        Common.subCabinetAutoTaskAgvLs.Add(i);
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                }
                Common.subCabinetAutoTaskAgvLs.OrderBy(o => o);
                MessageBox.Show("修改成功！");
                txtAutoTaskAgvs.Text = string.Join(",", Common.subCabinetAutoTaskAgvLs);
                Common.subCabinetAutoTaskAgvLs.Sort((o, p) => o.CompareTo(p));
            }
            catch { }
        }

        private void chbTestLoad1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbTestLoad1.Checked)
                {
                    if (Common.subLoadLs.Contains(6201) == false)
                    {
                        Common.subLoadLs.Add(6201);
                    }
                }
                else
                {
                    while (Common.subLoadLs.Contains(6201))
                    {
                        Common.subLoadLs.Remove(6201);
                    }
                }
            }
            catch { }
        }

        private void chbTestLoad2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbTestLoad2.Checked)
                {
                    if (Common.subLoadLs.Contains(6202) == false)
                    {
                        Common.subLoadLs.Add(6202);
                    }
                }
                else
                {
                    while (Common.subLoadLs.Contains(6202))
                    {
                        Common.subLoadLs.Remove(6202);
                    }
                }
            }
            catch { }
        }

        private void chbTestLoad3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbTestLoad3.Checked)
                {
                    if (Common.subLoadLs.Contains(6203) == false)
                    {
                        Common.subLoadLs.Add(6203);
                    }
                }
                else
                {
                    while (Common.subLoadLs.Contains(6203))
                    {
                        Common.subLoadLs.Remove(6203);
                    }
                }
            }
            catch { }
        }

        private void chbTestLoad4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbTestLoad4.Checked)
                {
                    if (Common.subLoadLs.Contains(6204) == false)
                    {
                        Common.subLoadLs.Add(6204);
                    }
                }
                else
                {
                    while (Common.subLoadLs.Contains(6204))
                    {
                        Common.subLoadLs.Remove(6204);
                    }
                }
            }
            catch { }
        }
        private void chbRandomSelect_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Common.isRandomSelect = chbRandomSelect.Checked;
            }
            catch (Exception)
            {
                //throw;
            }
        }
        private void chbRandomRobotOperate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Common.isRandomRobotOperate = chbRandomRobotOperate.Checked;
            }
            catch { }
        }
        private void btnTestSubStayRef_Click(object sender, EventArgs e)
        {
            try
            {
                Common.subStayTime = Convert.ToInt32((Convert.ToDouble(txtTestSubStayTime.Text) * 1000));
                MessageBox.Show("更新成功");
            }
            catch { }
        }

        private void txtTestSubStayRec_Click(object sender, EventArgs e)
        {
            txtTestSubStayTime.Text = (((double)Common.subStayTime) / 1000).ToString();
        }

        private void chbTestSubRefu_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbTestSubRefu.Checked)
                {
                    autoTaskType = Enumerations.TaskType.Init;
                    Common.autoTaskType = autoTaskType;
                    chbTestSubLoad.Checked = false;
                    chbTestSubUnload.Checked = false;
                }
            }
            catch { }
        }

        private void chbTestSubLoad_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbTestSubLoad.Checked)
                {
                    autoTaskType = Enumerations.TaskType.Init;
                    Common.autoTaskType = autoTaskType;
                    chbTestSubRefu.Checked = false;
                    chbTestSubUnload.Checked = false;
                }
            }
            catch { }
        }

        private void chbTestSubUnload_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbTestSubUnload.Checked)
                {
                    autoTaskType = Enumerations.TaskType.Init;
                    Common.autoTaskType = autoTaskType;
                    chbTestSubRefu.Checked = false;
                    chbTestSubLoad.Checked = false;
                }
            }
            catch { }
        }
        private void chbQRCode_CheckedChanged(object sender, EventArgs e)
        {
            Common.Instance.isReceiveQRCode = chbQRCode.Checked;
        }
        private void btnGroupMesTaskRef_Click(object sender, EventArgs e)
        {
            try
            {
                Common.bufferGroup = Convert.ToInt32(txtGroupMesTask.Text);
                MessageBox.Show("更新成功!");
            }
            catch { }
        }

        private void btnGroupMesTaskRec_Click(object sender, EventArgs e)
        {
            try
            {
                txtGroupMesTask.Text = Common.bufferGroup.ToString();
            }
            catch { }
        }
        #endregion

        #region 参数备份
        private void mnuSaveOther_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog kk = new FolderBrowserDialog())
            {
                //SaveFileDialog kk = new SaveFileDialog();
                kk.Description = "参数备份";
                //kk.Title = "参数备份";
                //kk.Filter = "所有文件(*.*) |*.*";
                //kk.FilterIndex = 1;
                if (kk.ShowDialog() == DialogResult.OK)
                {
                    string FileName = kk.SelectedPath;
                    if (FolderHelper.Copy(Common.Instance.SourcePath + @"\Information", FileName)) MessageBox.Show("备份完成");
                    else MessageBox.Show("未知原因，备份失败，请重新尝试");
                }
            }
        }
        #endregion

        #region 掉线时长设定
        private void btnLineTimeRec_Click(object sender, EventArgs e)
        {
            txtLineTime.Text = Common.Instance.AgvLineTime.ToString();
            txtClearLineTime.Text = (Common.Instance.AgvClearLineTime / 60).ToString();
        }

        private void btnLineTimeRef_Click(object sender, EventArgs e)
        {
            try
            {
                int l = Convert.ToInt32(txtLineTime.Text);
                int cl = Convert.ToInt32(txtClearLineTime.Text);
                if (l <= 0 || cl <= 0)
                {
                    MessageBox.Show("数值必须大于0");
                }
                else
                {
                    Common.Instance.AgvLineTime = l;
                    Common.Instance.AgvClearLineTime = cl * 60;
                    MessageBox.Show("修改成功！");
                }
            }
            catch
            {
                MessageBox.Show("输入必须为数值类型");
            }
        }
        #endregion

        private void chbSaveRoute_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Common.isSaveRoute = chbSaveRoute.Checked;
            }
            catch { }
        }

        #region 指定通道、指定AGV 自动任务
        private void btnAgvMatchStationRec_Click(object sender, EventArgs e)
        {
            RefMatchStation();
        }
        private void btnAgvMatchStationRef_Click(object sender, EventArgs e)
        {
            try
            {
                if (Common.isAgvMatchStationTask == false)
                {
                    if (MessageBox.Show("是否要更新指定匹配信息？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Common.matchStations.Clear();//清除全部信息
                        if (dgvAgvMatchStation.Rows.Count > 1)
                        {
                            for (int i = 0; i < dgvAgvMatchStation.Rows.Count - 1; i++)
                            {
                                try
                                {
                                    int agvNo = Convert.ToInt32(dgvAgvMatchStation.Rows[i].Cells[0].Value);
                                    int group = Convert.ToInt32(dgvAgvMatchStation.Rows[i].Cells[1].Value);
                                    int index = Convert.ToInt32(dgvAgvMatchStation.Rows[i].Cells[2].Value);
                                    int command = Convert.ToInt32(dgvAgvMatchStation.Rows[i].Cells[3].Value);
                                    int count = Convert.ToInt32(dgvAgvMatchStation.Rows[i].Cells[4].Value);
                                    DataGridViewCheckBoxCell dgvcb = (DataGridViewCheckBoxCell)dgvAgvMatchStation.Rows[i].Cells[5];
                                    //bool enable = Convert.ToBoolean(dgvcb.Value);
                                    bool enable = Convert.ToBoolean(dgvAgvMatchStation.Rows[i].Cells[5].Value);
                                    string groupValue = dgvAgvMatchStation.Rows[i].Cells[1].ToString() + "_" + dgvAgvMatchStation.Rows[i].Cells[2].ToString();
                                    string match = string.Empty;
                                    bool isCreate = true;
                                    //if (index > 10)
                                    //{
                                    //    match = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationRfidLs < 5500 && o.Value.StationRfidLs % 10 == index % 10).Value.StationMatchValue;
                                    //    if (index - 10 + count > 11) isCreate = false;
                                    //}
                                    //else
                                    //{
                                    //    match = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == group && o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.StationRfidLs >= 5500 && o.Value.StationRfidLs % 10 == index % 10).Value.StationMatchValue;
                                    //    if (index + count > 11) isCreate = false;
                                    //}
                                    //if (match != string.Empty && isCreate)
                                    //{
                                    //    int rfid = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == match).Value.StationRfidLs;
                                    //    Common.matchStations[agvNo] = new MatchStationInfo(agvNo, match, rfid, count, command, enable, groupValue);
                                    //}
                                }
                                catch { }
                            }
                        }
                        RefMatchStation();
                        BA_XmlOperate.MatchStationSave(Common.matchStations.Values.ToList());
                        MessageBox.Show("更新成功");
                    }
                }
                else
                {
                    MessageBox.Show("对匹配信息进行修改时，请停止自动指定匹配任务");
                }
            }
            catch { }
        }
        private void RefMatchStation()
        {
            try
            {
                dgvAgvMatchStation.Rows.Clear();
                if (Common.matchStations.Count > 0)
                {
                    foreach (int item in Common.matchStations.Keys)
                    {
                        //MatchStationInfo matchStation = Common.matchStations[item];
                        //StationInformation s = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == matchStation.MatchValue).Value;
                        //DataGridViewRow dr = new DataGridViewRow();
                        //dr.CreateCells(dgvAgvMatchStation);
                        //dr.Cells[0].Value = matchStation.AgvNo;
                        //dr.Cells[1].Value = s.Group;
                        //int index = s.StationRfidLs % 10;
                        //if (index == 0) index = 10;
                        //if (s.StationRfidLs < 5500) index = index + 10;
                        //dr.Cells[2].Value = index;
                        //dr.Cells[3].Value = Common.matchStations[item].StationCommand;
                        //dr.Cells[4].Value = Common.matchStations[item].StationCount;

                        //dr.Cells[5].Value = Common.matchStations[item].Enable;
                        //dgvAgvMatchStation.Rows.Add(dr);
                    }
                }
            }
            catch { }
        }
        private void chbMatchTask_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Common.isAgvMatchStationTask = chbMatchTask.Checked;
            }
            catch { }
        }
        #endregion


        #region OPC对应表
        private void btnRobotStateReceive_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateOpcParameter();
            }
            catch { }
        }
        private void UpdateOpcParameter()
        {
            try
            {
                dgvOpcState.Rows.Clear();
                foreach (OPCItemParameter item in OPCClient.dtOpcToPlc.Values)
                {
                    DataGridViewRow dr = new DataGridViewRow();
                    dr.CreateCells(dgvOpcState);
                    dr.Cells[0].Value = item.ParameterName;
                    dr.Cells[1].Value = item.PLCName;
                    dr.Cells[2].Value = item.ItemHandle.ToString();
                    dr.Cells[3].Value = item.Value.ToString();
                    dgvOpcState.Rows.Add(dr);
                }
            }
            catch { }
        }
        private void btnRobotRefence_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Is Change？", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        OPCClient.dtOpcToPlc.Clear();
                        for (int i = 0; i < dgvOpcState.Rows.Count; i++)
                        {
                            try
                            {
                                string pName = dgvOpcState.Rows[i].Cells[0].Value.ToString().Trim();
                                string key = dgvOpcState.Rows[i].Cells[1].Value.ToString().Trim();
                                int handle = int.Parse(dgvOpcState.Rows[i].Cells[2].Value.ToString());
                                int value = int.Parse(dgvOpcState.Rows[i].Cells[3].Value.ToString());
                                OPCClient.dtOpcToPlc[key] = new OPCItemParameter(pName, key, handle, value);
                            }
                            catch { }
                        }
                    }
                    catch { }
                    UpdateOpcParameter();
                    MessageBox.Show("Modify successfully!");
                }
            }
            catch { }
        }
        private void UpdateRobotState()
        {
            try
            {
                dgvOpcState.Rows.Clear();
                foreach (int item in Common.Instance.dtRobotState.Keys)
                {
                    DataGridViewRow dr = new DataGridViewRow();
                    dr.CreateCells(dgvOpcState);
                    dr.Cells[0].Value = item;
                    dr.Cells[1].Value = Common.Instance.dtRobotState[item];
                    dgvOpcState.Rows.Add(dr);
                }
            }
            catch { }
        }
        private void btnOpcValue_Click(object sender, EventArgs e)
        {
            try
            {
                int handle = int.Parse(txtHandle.Text);
                int value = int.Parse(txtHandleValue.Text);
                string val = string.Empty;
                if (handle < 80)
                {
                    if (handle % 9 == 1)
                    {
                        val = value.ToString();
                    }
                    else
                    {
                        if (value == 0)
                        {
                            val = "False";
                        }
                        else
                        {
                            val = "True";
                        }
                    }
                }
                else if (handle >= 81 && handle <= 83)
                {
                    if (value == 0)
                    {
                        val = "False";
                    }
                    else
                    {
                        val = "True";
                    }
                }
                OPCItemParameter opcItem = OPCClient.dtOpcToPlc.First(o => o.Value.ItemHandle == handle).Value;
                OPCClient.WriteOpc(value, opcItem);
                //UpdateOpcParameter();
            }
            catch
            {
                MessageBox.Show("Format error.");
            }
        }
        #endregion


        #region 站点信息刷新
        private void RefreshStationStatus()
        {
            try
            {
                List<int> sKeys = Common.dtStationInfo.Keys.ToList();
                foreach (int item in sKeys)
                {
                    try
                    {
                        int stationState = Common.Instance.dtStationInformation.First(o => o.Value.StationNo == item).Value.State;
                        switch (stationState)
                        {
                            case (int)EStationState.Init:
                                this.dtStationLabel[item].BackColor = Color.White;
                                break;
                            case (int)EStationState.Free:
                                this.dtStationLabel[item].BackColor = Color.Lime;
                                break;
                            case (int)EStationState.Busy:
                                this.dtStationLabel[item].BackColor = Color.Red;
                                break;
                            case (int)EStationState.Book:
                                this.dtStationLabel[item].BackColor = Color.Yellow;
                                break;
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }
        #endregion

        #region 向OPC写入对应站点AGV信息线程
        private void WriteOpcAgvStates()
        {
            Task task = new Task(() =>
                {
                    while (true)
                    {
                        #region 更新站点信息
                        try
                        {
                            List<string> opckeys = OPCClient.dtOpcToPlc.Keys.ToList();
                            foreach (var key in opckeys)
                            {
                                int handle = OPCClient.dtOpcToPlc[key].ItemHandle;
                                int stationNo = (handle - 1) / 9;
                                int offset = handle % 9;
                                if (handle == 72)
                                { }
                                if (handle < 80)
                                {//站点信息
                                    StationInformation s = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Handle > 0 && (o.Value.Handle / 9 == stationNo)).Value;
                                    switch (offset)
                                    {
                                        case 1:
                                            s.WriteValue = OPCClient.dtOpcToPlc[key].Value;
                                            break;
                                        case 2:
                                            s.LoadReady = OPCClient.dtOpcToPlc[key].Value == 1 ? true : false;
                                            break;
                                        case 3:
                                            s.UnloadReady = OPCClient.dtOpcToPlc[key].Value == 1 ? true : false;
                                            break;
                                        case 4:
                                            s.Dock = OPCClient.dtOpcToPlc[key].Value == 1 ? true : false;
                                            break;
                                        case 5:
                                            s.Undock = OPCClient.dtOpcToPlc[key].Value == 1 ? true : false;
                                            break;
                                    }
                                    if (s.LoadReady == false && s.UnloadReady && s.Dock && s.Undock == false)
                                    {
                                        s.State = (int)EStationState.Busy;
                                    }
                                    else if (s.LoadReady && s.UnloadReady == false && s.Dock && s.Undock == false)
                                    {
                                        s.State = (int)EStationState.Busy;
                                    }
                                    else
                                    {
                                        s.State = (int)EStationState.Free;
                                    }
                                }
                                else
                                {//一键工作/收工信息
                                    if (handle == 81)
                                    {//Idle,请求收工
                                        Common.Instance.opcIdleRequest = OPCClient.dtOpcToPlc[key].Value == 1 ? true : false;
                                        if (Common.Instance.opcIdleRequest)
                                        {//收工请求 
                                            Common.Instance.isReceiveOpcTask = false;
                                        }
                                    }
                                    else if (handle == 82)
                                    {//
                                        Common.Instance.opcStartRequest = OPCClient.dtOpcToPlc[key].Value == 1 ? true : false;
                                        if (Common.Instance.opcStartRequest)
                                        {//开始请求 
                                            Common.Instance.isReceiveOpcTask = true;
                                        }
                                    }
                                    else if (handle == 83)
                                    {
                                        Common.Instance.writeOpcReceiveState = OPCClient.dtOpcToPlc[key].Value == 1 ? true : false;
                                    }
                                }
                            }
                        }
                        catch { }
                        #endregion
                        #region 向OPC写入当前开工/收工状态
                        try
                        {
                            if (Common.Instance.isReceiveOpcTask && Common.Instance.writeOpcReceiveState == false)
                            {
                                OPCClient.WriteOpc(1, 83);
                            }
                            else if (Common.Instance.isReceiveOpcTask == false && Common.Instance.writeOpcReceiveState)
                            {
                                OPCClient.WriteOpc(0, 83);
                            }
                        }
                        catch { }
                        #endregion
                        #region 写入AGV信息
                        try
                        {
                            List<string> stationKeys = Common.Instance.dtStationInformation.Values.ToList().FindAll(o => o.Handle > 0).Select(o => o.Key).ToList();
                            foreach (var item in stationKeys)
                            {
                                try
                                {
                                    StationInformation s = Common.Instance.dtStationInformation[item];
                                    int taskAgvType = s.Group == 1 ? (int)Enumerations.agvType.type_1 : (int)Enumerations.agvType.type_2;
                                    int writeValue = -1;
                                    bool isCheck = false;//是否已经获得writeValue
                                    int waitRfid = 0;
                                    int judgeDirection = 1;//判断方向,A站点和B站点不一样
                                    MA_AgvTaskInfo taskInfo = null;
                                    if (s.StationType == 2)
                                    {//A类型站点 
                                        waitRfid = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == s.Group && o.Value.StationMatchValue.ToLowerInvariant().Contains("wait1")).Value.StationRfidLs[0];
                                        taskInfo = Common.taskDt[taskAgvType].FirstOrDefault(o => o.Value.T_Type == Enumerations.TaskType.Transport_A_C || o.Value.T_Type == Enumerations.TaskType.Transport_A_F || o.Value.T_Type == Enumerations.TaskType.Transport_C_F || o.Value.T_Type == Enumerations.TaskType.Transport_E_A).Value;
                                    }
                                    else if (s.StationType == 3)
                                    {//B类型站点 
                                        waitRfid = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.Group == s.Group && o.Value.StationMatchValue.ToLowerInvariant().Contains("wait2")).Value.StationRfidLs[0];
                                        taskInfo = Common.taskDt[taskAgvType].FirstOrDefault(o => o.Value.T_Type == Enumerations.TaskType.Transport_B_D || o.Value.T_Type == Enumerations.TaskType.Transport_B_E || o.Value.T_Type == Enumerations.TaskType.Transport_D_E || o.Value.T_Type == Enumerations.TaskType.Transport_F_B).Value;
                                    }
                                    if (isCheck == false)
                                    {//是否有AGV有任务，且处于异常状态
                                        if (taskInfo != null)
                                        {
                                            int _agvNo = taskInfo.T_AgvNo;
                                            if (Common.maiDict[_agvNo].State == (int)Enumerations.AgvStatus.abnormal)
                                            {
                                                writeValue = 100 + Common.maiDict[_agvNo].Abnormal;
                                                isCheck = true;
                                            }
                                        }
                                    }
                                    if (isCheck == false)
                                    {
                                        if (Common.maiDict.Any(o => o.Value.VirtualRfid == waitRfid && taskAgvType == (int)o.Value.Type && o.Value.Task1 == string.Empty && o.Value.Task2 == string.Empty && o.Value.State == (int)Enumerations.AgvStatus.abnormal))
                                        {//AGV处于待机点，且出现异常
                                            int _agvNo = Common.maiDict.FirstOrDefault(o => o.Value.VirtualRfid == waitRfid && taskAgvType == (int)o.Value.Type && o.Value.Task1 == string.Empty && o.Value.Task2 == string.Empty && o.Value.State == (int)Enumerations.AgvStatus.abnormal).Key;
                                            writeValue = 100 + Common.maiDict[_agvNo].Abnormal;
                                            isCheck = true;
                                        }
                                    }
                                    if (isCheck == false)
                                    {
                                        if (Common.maiDict.Any(o => o.Value.VirtualRfid == waitRfid && taskAgvType == (int)o.Value.Type && o.Value.Task1 == string.Empty && o.Value.Task2 == string.Empty && o.Value.State != (int)Enumerations.AgvStatus.abnormal))
                                        {//AGV处于idle(空闲)状态
                                            writeValue = (int)Enumerations.EAgvStateToPlc.Idle;
                                            isCheck = true;
                                        }
                                    }
                                    //if (isCheck == false)
                                    //{
                                    //    if (Common.maiDict.Any(o => (int)o.Value.Type == taskAgvType && (o.Value.Default7 > 0 || o.Value.Default8 > 0) && (int.Parse(s.StationOperate) == o.Value.Default7 || int.Parse(s.StationOperate) == o.Value.Default8) == false))
                                    //    {//判断当前AGV
                                    //        writeValue = (int)Enumerations.EAgvStateToPlc.Idle;
                                    //        isCheck = true;
                                    //    }
                                    //}
                                    if (isCheck == false)
                                    {//检测是否为正在前往           
                                        judgeDirection = s.StationType == 2 ? 1 : 2;
                                        if (Common.maiDict.Any(o => o.Value.VirtualRfid == s.PassRfid && o.Value.Direction == judgeDirection && taskAgvType == (int)o.Value.Type && ((s.LoadReady == false && s.UnloadReady && s.Dock && s.Undock == false && o.Value.DragState == (int)Enumerations.EDragState.Decline) || (s.LoadReady && s.UnloadReady == false && s.Dock && s.Undock == false && o.Value.DragState == (int)Enumerations.EDragState.LiftUp))))
                                        {//AGV正在前往站点 
                                            writeValue = (int)Enumerations.EAgvStateToPlc.Arriving;
                                            isCheck = true;
                                        }
                                    }
                                    if (isCheck == false)
                                    {
                                        if (Common.maiDict.Any(o => (int)o.Value.Type == taskAgvType && s.StationRfidLs.Contains(o.Value.VirtualRfid) && o.Value.Arrived))
                                        {//AGV到达升降平台
                                            writeValue = (int)Enumerations.EAgvStateToPlc.Present;
                                            isCheck = true;
                                        }
                                    }
                                    if (isCheck == false)
                                    {
                                        judgeDirection = s.StationType == 2 ? 2 : 1;
                                        if (Common.maiDict.Any(o => (int)o.Value.Type == taskAgvType && s.StationRfidLs.Contains(o.Value.VirtualRfid) && o.Value.Arrived == false && o.Value.Direction == judgeDirection && o.Value.Speed > 0))
                                        {//AGV正在离开
                                            writeValue = (int)Enumerations.EAgvStateToPlc.Departing;
                                            isCheck = true;
                                        }
                                    }
                                    if (isCheck == false)
                                    {
                                        judgeDirection = s.StationType == 2 ? 2 : 1;
                                        if (Common.maiDict.Any(o => (int)o.Value.Type == taskAgvType && o.Value.VirtualRfid == s.PassRfid && o.Value.Arrived == false && o.Value.Direction == judgeDirection))
                                        {//AGV已经离开
                                            if (s.WriteValue != (int)Enumerations.EAgvStateToPlc.Transferring)
                                            {
                                                writeValue = (int)Enumerations.EAgvStateToPlc.Departed;
                                                if (writeValue != s.WriteValue && Common.maiDict.Any(o => (int)o.Value.Type == taskAgvType && o.Value.VirtualRfid == s.PassRfid && o.Value.Arrived == false && o.Value.Direction == judgeDirection && o.Value.DragState == (int)Enumerations.EDragState.LiftUp))//AGV处于牵引棒上升状态
                                                {
                                                    s.DepartedTime = DateTime.Now;
                                                }
                                                else
                                                {//已经更新为Departed状态时，1秒后，将其更新为Transferring
                                                    if (DateTime.Now.Subtract(s.DepartedTime).TotalSeconds > 1 && Common.maiDict.Any(o => (int)o.Value.Type == taskAgvType && o.Value.VirtualRfid == s.PassRfid && o.Value.Arrived == false && o.Value.Direction == judgeDirection && o.Value.DragState == (int)Enumerations.EDragState.LiftUp))//AGV处于牵引棒上升状态
                                                    {
                                                        writeValue = (int)Enumerations.EAgvStateToPlc.Transferring;
                                                    }
                                                }
                                            }
                                            isCheck = true;
                                        }
                                    }
                                    if (isCheck == false)
                                    {
                                        if (taskInfo != null)
                                        {//判断有该类型站点的任务
                                            bool isQuery = false;//判断是否需要查询Transferring/TransferComplete
                                            if (s.StationType == 2)
                                            {//A类型站点
                                                if (taskInfo.T_Type == Enumerations.TaskType.Transport_C_F)
                                                {
                                                    isQuery = true;
                                                }
                                                else
                                                {
                                                    if ((taskInfo.T_Process[0].SourceStation == int.Parse(s.StationOperate) || taskInfo.T_Process[0].Station == int.Parse(s.StationOperate)) == false)
                                                    {//该任务不是去现在所在的站点
                                                        writeValue = (int)Enumerations.EAgvStateToPlc.Idle;
                                                        isCheck = true;
                                                        isQuery = true;
                                                    }
                                                    else
                                                    {
                                                        if (taskInfo.T_Type == Enumerations.TaskType.Transport_E_A)
                                                        {//从交换区拉物料到A站点
                                                            int _agvNo = taskInfo.T_AgvNo;
                                                            if (_agvNo > 0)
                                                            {
                                                                if (Common.maiDict[_agvNo].Default7 > 0 && Common.maiDict[_agvNo].Default8 > 0)
                                                                {//正在前往交换区，将状态更新为Transferring
                                                                    writeValue = (int)Enumerations.EAgvStateToPlc.Transferring;
                                                                    isCheck = true;
                                                                }
                                                                else if (Common.maiDict[_agvNo].Default7 <= 0 && Common.maiDict[_agvNo].Default8 > 0)
                                                                {//AGV正在前往呼叫工位
                                                                    if ((s.WriteValue == (int)Enumerations.EAgvStateToPlc.Arriving || s.WriteValue == (int)Enumerations.EAgvStateToPlc.Present || s.WriteValue == (int)Enumerations.EAgvStateToPlc.Departing || s.WriteValue == (int)Enumerations.EAgvStateToPlc.Departed) == false)
                                                                    {//当不为正在前往，正在离开，已经离开，到达料点状态时，更新为TransferComplete
                                                                        writeValue = (int)Enumerations.EAgvStateToPlc.TransferComplete;
                                                                        isCheck = true;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else if (taskInfo.T_Type == Enumerations.TaskType.Transport_A_F || taskInfo.T_Type == Enumerations.TaskType.Transport_A_C)
                                                        {
                                                            if (taskInfo.T_Process[taskInfo.ProcessIndex].Route == RouteType.GoWait1 || taskInfo.T_Process[taskInfo.ProcessIndex].Route == RouteType.GoWait2)
                                                            {//回待机点，将状态更新为TransferComplete
                                                                writeValue = (int)Enumerations.EAgvStateToPlc.TransferComplete;
                                                                isCheck = true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else if (s.StationType == 3)
                                            {//B类型站点
                                                if (taskInfo.T_Type == Enumerations.TaskType.Transport_D_E)
                                                {
                                                    isQuery = true;
                                                }
                                                else
                                                {
                                                    if ((taskInfo.T_Process[0].SourceStation == int.Parse(s.StationOperate) || taskInfo.T_Process[0].Station == int.Parse(s.StationOperate)) == false)
                                                    {//该任务不是去现在所在的站点
                                                        writeValue = (int)Enumerations.EAgvStateToPlc.Idle;
                                                        isCheck = true;
                                                        isQuery = true;
                                                    }
                                                    else
                                                    {
                                                        if (taskInfo.T_Type == Enumerations.TaskType.Transport_F_B)
                                                        {//从交换区拉物料到B站点
                                                            int _agvNo = taskInfo.T_AgvNo;
                                                            if (_agvNo > 0)
                                                            {
                                                                if (Common.maiDict[_agvNo].Default7 > 0 && Common.maiDict[_agvNo].Default8 > 0)
                                                                {//正在前往交换区，将状态更新为Transferring
                                                                    writeValue = (int)Enumerations.EAgvStateToPlc.Transferring;
                                                                    isCheck = true;
                                                                }
                                                                else if (Common.maiDict[_agvNo].Default7 <= 0 && Common.maiDict[_agvNo].Default8 > 0)
                                                                {
                                                                    if ((s.WriteValue == (int)Enumerations.EAgvStateToPlc.Arriving || s.WriteValue == (int)Enumerations.EAgvStateToPlc.Present || s.WriteValue == (int)Enumerations.EAgvStateToPlc.Departing || s.WriteValue == (int)Enumerations.EAgvStateToPlc.Departed) == false)
                                                                    {//当不为正在前往，正在离开，已经离开，到达料点状态时，更新为TransferComplete
                                                                        writeValue = (int)Enumerations.EAgvStateToPlc.TransferComplete;
                                                                        isCheck = true;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else if (taskInfo.T_Type == Enumerations.TaskType.Transport_B_E || taskInfo.T_Type == Enumerations.TaskType.Transport_B_D)
                                                        {
                                                            if (taskInfo.T_Process[taskInfo.ProcessIndex].Route == RouteType.GoWait1 || taskInfo.T_Process[taskInfo.ProcessIndex].Route == RouteType.GoWait2)
                                                            {//回待机点，将状态更新为TransferComplete
                                                                writeValue = (int)Enumerations.EAgvStateToPlc.TransferComplete;
                                                                isCheck = true;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            if (isQuery && isCheck == false)
                                            {
                                                if (taskInfo.T_Process[taskInfo.ProcessIndex].Route == RouteType.GoWait1 || taskInfo.T_Process[taskInfo.ProcessIndex].Route == RouteType.GoWait2)
                                                {//回待机点，将状态更新为TransferComplete
                                                    writeValue = (int)Enumerations.EAgvStateToPlc.TransferComplete;
                                                    isCheck = true;
                                                }
                                                else
                                                {
                                                    writeValue = (int)Enumerations.EAgvStateToPlc.Transferring;
                                                    isCheck = true;
                                                }
                                            }
                                        }
                                    }
                                    if (isCheck == false)
                                    {
                                        if (s.LoadReady == false && s.UnloadReady && s.Dock && s.Undock == false && taskInfo == null)
                                        {//有物料需要拉走，且当前没有关于该站点的任务 
                                            int st1 = 0;
                                            int st2 = 0;
                                            if (s.StationType == 2)
                                            {
                                                st1 = 6;
                                                st2 = 5;
                                            }
                                            else if (s.StationType == 3)
                                            {
                                                st1 = 7;
                                                st2 = 4;
                                            }
                                            if (Common.Instance.dtStationInformation.Any(o => o.Value.Group == s.Group && (o.Value.StationType == st1 || o.Value.StationType == st2) && o.Value.StationEnable && o.Value.State == (int)EStationState.Free) == false)
                                            {//对应缓存区和交换区都已经满了，更新为满状态
                                                writeValue = (int)Enumerations.EAgvStateToPlc.StationFull;
                                                isCheck = true;
                                            }
                                        }
                                    }
                                    if (OPCClient.opcInformation.ConnectState)
                                    {//opc处于正常连接状态 
                                        if (s.WriteValue != writeValue && isCheck && writeValue >= 0)
                                        {
                                            OPCClient.WriteOpc(writeValue, item);
                                        }
                                    }
                                }
                                catch { }

                            }
                        }
                        catch { }
                        #endregion
                        Thread.Sleep(30);
                    }
                });
            task.Start();
        }
        #endregion


        #region 测试任务
        private void testTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                TestTask tt = new TestTask();
                tt.ShowDialog();
            }
            catch { }
        }
        #endregion

        #region 充电时长设定
        private void btnChargeTimeReceive_Click(object sender, EventArgs e)
        {
            txtChargeTime.Text = Common.Instance.chargeTime.ToString();
        }

        private void btnChargeTimeUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int _chargeTime = int.Parse(txtChargeTime.Text);
                if (_chargeTime > 0)
                {
                    Common.Instance.chargeTime = _chargeTime;
                    MessageBox.Show("Update charge time successful");
                }
                else
                {
                    MessageBox.Show("The value must be greater than zero");
                }
            }
            catch
            {
                MessageBox.Show("Parameters must be of numeric type");
            }
        }
        #endregion

        #region 待机模式下充电时长设定
        private void btnStandbyChargeTimeReceive_Click(object sender, EventArgs e)
        {
            txtStanbyChargeTime.Text = Common.Instance.standbyChargeTime.ToString();
        }

        private void btnStandbyChargeTimeUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int _chargeTime = int.Parse(txtStanbyChargeTime.Text);
                if (_chargeTime > 0)
                {
                    Common.Instance.standbyChargeTime = _chargeTime;
                    MessageBox.Show("Update charge time successful");
                }
                else
                {
                    MessageBox.Show("The value must be greater than zero");
                }
            }
            catch
            {
                MessageBox.Show("Parameters must be of numeric type");
            }
        }
        #endregion

        #region 工作模式切换
        private void mnuWorkMode_Click(object sender, EventArgs e)
        {
            try
            {
                if (Common.Instance.isReceiveOpcTask)
                {
                    if (MessageBox.Show("Whether to set the software to rest state?", "Tip", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Common.Instance.isReceiveOpcTask = false;
                        mnuWorkMode.Text = "Rest|Work";
                        mnuWorkMode.BackColor = Color.Red;
                    }
                }
                else
                {
                    if (MessageBox.Show("Whether to set the software to working state?", "Tip", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Common.Instance.isReceiveOpcTask = true;
                        mnuWorkMode.Text = "Work|Rest";
                        mnuWorkMode.BackColor = Color.Lime;
                    }
                }
            }
            catch { }
        }
        #endregion

        #region AGV一键初始化
        private void mnuAgvInit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Whether to initialize all agvs", "Tip", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    List<int> agvKeys = Common.maiDict.Keys.ToList();
                    List<int> initAgvs = new List<int>();
                    foreach (var item in agvKeys)
                    {
                        try
                        {
                            if (Common.maiDict[item].Task1 == string.Empty && Common.maiDict[item].Task2 == string.Empty && Common.maiDict[item].Default7 == 0 && Common.maiDict[item].Default8 == 0 && Common.maiDict[item].State == (int)Enumerations.AgvStatus.stop)
                            {
                                int _virtualRfid = Common.maiDict[item].VirtualRfid;
                                if (Common.Instance.dtStationInformation.Any(o => (o.Value.StationType == (int)StationInformation.EStationType.Wait || o.Value.StationType == (int)StationInformation.EStationType.Charge) && o.Value.StationRfidLs.Contains(_virtualRfid)))
                                {//AGV在待机点或充电点 
                                    if (Common.maiDict[item].IsCanReceiveTask == false)
                                    {
                                        initAgvs.Add(item);
                                        BA_AgvCommunicationThread.AgvCommuDt[item].AgvOperate(Enumerations.AgvOperate.Init);
                                    }
                                }
                            }
                        }
                        catch { }
                    }
                    string _message = string.Format("AGVs [{0}] has been initialized,Other agvs do not meet the initialization conditions", string.Join(",", initAgvs.ToArray()));
                    MessageBox.Show(_message);
                }
                catch { }
            }
        }
        #endregion

        private void mnuSetInvLoc_Click(object sender, EventArgs e)
        {
            try
            {
                InventoryLocationSetForm invLocForm = new InventoryLocationSetForm();
                invLocForm.Show();

                //MapForm mapForm = new MapForm(this.tmrMapChange);
                //try
                //{
                //    mapForm.ShowDialog();
                //}
                //finally
                //{
                //    mapForm.Dispose();
                //}
            }
            catch { }
        }
    }
}
