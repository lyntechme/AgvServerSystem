using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using System.Threading;

namespace AgvServerSystem
{
    public partial class TaskForm : Form
    {
        /// <summary>
        /// 默认机械臂动作
        /// </summary>
        public static bool isRobot = true;
        /// <summary>
        /// 默认分容柜数量        
        /// </summary>
        public static int counts = 5;
        /// <summary>
        /// 选择AGV编号 
        /// </summary>
        private int selectAgvNo = -1;
        /// <summary>
        /// 任务类型  0：分容测试，1：预充老化，2：分容老化
        /// </summary>
        private int taskAreaType = 0;
        /// <summary>
        /// 当前选择任务类型
        /// </summary>
        private Enumerations.TaskType taskType = Enumerations.TaskType.Init;
        /// <summary>
        /// 路段集合
        /// </summary>
        List<RouteInfo> routeLs = new List<Model.RouteInfo>();
        public TaskForm()
        {
            InitializeComponent();
            rbtnCapTest_CheckedChanged(rbtnCapTest, new EventArgs());
            //lblCapTestSubCount.Visible = false;
            //txtCapTestSubCount.Visible = false;
            txtCapTestSubCount.Text = counts.ToString();
            chbIsRobot.Checked = isRobot;
        }

        private void TaskForm_Load(object sender, EventArgs e)
        {

        }

        #region 区域任务选择
        private void rbtnCapTest_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCapTest.Checked)
            {
                taskAreaType = 0;
                List<KeyValuePair<int, string>> ls = new List<KeyValuePair<int, string>>();
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Test_FullCommparmentRefueling, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Test_FullCommparmentRefueling]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Test_FullCommparmentRequest, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Test_FullCommparmentRequest]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Test_NullCompartmentRequest, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Test_NullCompartmentRequest]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Test_LoadRequestLoad, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Test_LoadRequestLoad]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Test_LoadRequestUnload, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Test_LoadRequestUnload]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Test_LoadLeaveNullTray, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Test_LoadLeaveNullTray]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Test_CommparmentReload, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Test_CommparmentReload]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Charge_CapTest, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Charge_CapTest]));
                //cbTaskType.Items.Clear();
                cbTaskType.DataSource = ls;
                cbTaskType.DisplayMember = "value";
                cbTaskType.ValueMember = "key";
                cbTaskType.SelectedIndex = 0;
                ChangeBindAgv();
            }
        }

        private void rbtnPreAging_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPreAging.Checked)
            {
                taskAreaType = 1;
                List<KeyValuePair<int, string>> ls = new List<KeyValuePair<int, string>>();
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Pre_AgingRoom_AgingRoom, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Pre_AgingRoom_AgingRoom]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Pre_AgingRoom_RestintZone, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Pre_AgingRoom_RestintZone]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Pre_RestingZone_Unload, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Pre_RestingZone_Unload]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Pre_Load_AgingRoom, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Pre_Load_AgingRoom]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Pre_Unload_Load, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Pre_Unload_Load]));
                //cbTaskType.Items.Clear();
                cbTaskType.DataSource = ls;
                cbTaskType.DisplayMember = "value";
                cbTaskType.ValueMember = "key";
                cbTaskType.SelectedIndex = 0;
                ChangeBindAgv();
            }
        }

        private void rbtnCapAging_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnCapAging.Checked)
            {
                taskAreaType = 2;
                List<KeyValuePair<int, string>> ls = new List<KeyValuePair<int, string>>();
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Cap_AgingRoom_AgingRoom, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Cap_AgingRoom_AgingRoom]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Cap_AgingRoom_RestintZone, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Cap_AgingRoom_RestintZone]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Cap_RestingZone_Unload, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Cap_RestingZone_Unload]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Cap_Load_AgingRoom, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Cap_Load_AgingRoom]));
                //ls.Add(new KeyValuePair<int, string>((int)Enumerations.TaskType.Cap_Unload_Load, Common.Instance.dtTaskTypeName[Enumerations.TaskType.Cap_Unload_Load]));
                //cbTaskType.Items.Clear();
                cbTaskType.DataSource = ls;
                cbTaskType.DisplayMember = "value";
                cbTaskType.ValueMember = "key";
                cbTaskType.SelectedIndex = 0;
                ChangeBindAgv();
            }
        }
        private void ChangeBindAgv()
        {
            List<string> ls = new List<string>();
            switch (taskAreaType)
            {
                case 0:
                    cbTaskBindAgv.Items.Clear();
                    cbTaskBindAgv.Items.Add("Null");
                    ls = Common.maiDict.Keys.ToList().FindAll(o => Common.maiDict[o].Type == Enumerations.agvType.type_1).ConvertAll<string>(x => x.ToString());
                    cbTaskBindAgv.Items.AddRange(ls.ToArray());
                    break;
                case 1:
                    cbTaskBindAgv.Items.Clear();
                    cbTaskBindAgv.Items.Add("Null");
                    ls = Common.maiDict.Keys.ToList().FindAll(o => Common.maiDict[o].Type == Enumerations.agvType.type_2).ConvertAll<string>(x => x.ToString());
                    cbTaskBindAgv.Items.AddRange(ls.ToArray());
                    break;
                case 2:
                    cbTaskBindAgv.Items.Clear();
                    cbTaskBindAgv.Items.Add("Null");
                    ls = Common.maiDict.Keys.ToList().FindAll(o => Common.maiDict[o].Type == Enumerations.agvType.type_3).ConvertAll<string>(x => x.ToString());
                    cbTaskBindAgv.Items.AddRange(ls.ToArray());
                    break;
            }
            cbTaskBindAgv.SelectedIndex = 0;
        }
        #endregion

        private void cbTaskType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbSourceGroup.Items.Clear();
                cbTargetGroup.Items.Clear();
                cbSourceStatoin.Items.Clear();
                cbTargetStatoin.Items.Clear();
                KeyValuePair<int, string> kp = (KeyValuePair<int, string>)cbTaskType.SelectedItem;
                taskType = (Enumerations.TaskType)kp.Key;
                bool isCapTestSubCountVisiable = false;
                //switch (taskType)
                //{
                //    //分容测试
                //    case Enumerations.TaskType.Test_CommparmentReload:
                //        cbSourceStatoin.Items.Clear();
                //        cbTargetStatoin.Items.Clear();
                //        break;
                //    case Enumerations.TaskType.Test_FullCommparmentRefueling:
                //    case Enumerations.TaskType.Test_FullCommparmentRequest:
                //    case Enumerations.TaskType.Test_NullCompartmentRequest:
                //        cbSourceGroup.Items.Add("1");
                //        cbSourceGroup.SelectedIndex = 0;
                //        isCapTestSubCountVisiable = true;
                //        int max = Common.Instance.dtStationInformation.OrderByDescending(o => o.Value.Group).FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.SubCabinet).Value.Group;
                //        for (int i = 1; i <= max; i++)
                //        {
                //            cbTargetGroup.Items.Add(i.ToString());
                //        }
                //        cbTargetGroup.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Test_LoadLeaveNullTray:
                //        cbSourceGroup.Items.Add("1");
                //        cbSourceGroup.SelectedIndex = 0;
                //        //cbSourceStatoin.Items.Clear();                        
                //        cbTargetStatoin.Items.Clear();
                //        break;
                //    case Enumerations.TaskType.Test_LoadRequestLoad:
                //        cbSourceGroup.Items.Add("1");
                //        cbSourceGroup.SelectedIndex = 0;
                //        //cbSourceStatoin.Items.Clear();
                //        cbTargetStatoin.Items.Clear();
                //        break;
                //    case Enumerations.TaskType.Test_LoadRequestUnload:
                //        cbSourceGroup.Items.Add("1");
                //        cbSourceGroup.SelectedIndex = 0;
                //        //cbSourceStatoin.Items.Clear();
                //        cbTargetStatoin.Items.Clear();
                //        break;
                //    case Enumerations.TaskType.Charge_CapTest:
                //        cbSourceStatoin.Items.Clear();
                //        cbTargetGroup.Items.Add("1");
                //        cbTargetGroup.Items.Add("2");
                //        cbTargetGroup.SelectedIndex = 0;
                //        break;
                //    //预充老化
                //    case Enumerations.TaskType.Pre_AgingRoom_AgingRoom:
                //        for (int i = 1; i < 11; i++)
                //        {
                //            cbSourceGroup.Items.Add(i.ToString());
                //            cbTargetGroup.Items.Add(i.ToString());
                //        }
                //        cbSourceGroup.SelectedIndex = 0;
                //        cbTargetGroup.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Pre_AgingRoom_RestintZone:
                //        for (int i = 1; i < 11; i++)
                //        {
                //            cbSourceGroup.Items.Add(i.ToString());
                //            //cbTargetGroup.Items.Add(i.ToString());
                //        }
                //        cbTargetGroup.Items.Add("1");
                //        cbSourceGroup.SelectedIndex = 0;
                //        cbTargetGroup.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Pre_RestingZone_Unload:
                //        cbSourceGroup.Items.Add("1");
                //        cbTargetGroup.Items.Add("1");
                //        cbSourceGroup.SelectedIndex = 0;
                //        cbTargetGroup.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Pre_Load_AgingRoom:
                //        cbSourceGroup.Items.Add("1");
                //        cbSourceGroup.SelectedIndex = 0;
                //        for (int i = 1; i < 11; i++)
                //        {
                //            cbTargetGroup.Items.Add(i.ToString());
                //        }
                //        cbTargetGroup.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Pre_Unload_Load:
                //        cbSourceGroup.Items.Add("1");
                //        cbTargetGroup.Items.Add("1");
                //        cbSourceGroup.SelectedIndex = 0;
                //        cbTargetGroup.SelectedIndex = 0;
                //        break;
                //    //分容老化
                //    case Enumerations.TaskType.Cap_AgingRoom_AgingRoom:
                //        for (int i = 11; i < 43; i++)
                //        {
                //            cbSourceGroup.Items.Add(i.ToString());
                //            cbTargetGroup.Items.Add(i.ToString());
                //        }
                //        cbSourceGroup.SelectedIndex = 0;
                //        cbTargetGroup.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Cap_AgingRoom_RestintZone:
                //        for (int i = 11; i < 43; i++)
                //        {
                //            cbSourceGroup.Items.Add(i.ToString());
                //            //cbTargetGroup.Items.Add(i.ToString());
                //        }
                //        cbTargetGroup.Items.Add("1");
                //        cbTargetGroup.Items.Add("2");
                //        cbSourceGroup.SelectedIndex = 0;
                //        cbTargetGroup.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Cap_RestingZone_Unload:
                //        cbSourceGroup.Items.Add("1");
                //        cbSourceGroup.Items.Add("2");
                //        cbTargetGroup.Items.Add("1");
                //        cbSourceGroup.SelectedIndex = 0;
                //        cbTargetGroup.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Cap_Load_AgingRoom:
                //        cbSourceGroup.Items.Add("1");
                //        cbSourceGroup.SelectedIndex = 0;
                //        for (int i = 11; i < 43; i++)
                //        {
                //            cbTargetGroup.Items.Add(i.ToString());
                //        }
                //        cbTargetGroup.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Cap_Unload_Load:
                //        cbSourceGroup.Items.Add("1");
                //        cbTargetGroup.Items.Add("1");
                //        cbSourceGroup.SelectedIndex = 0;
                //        cbTargetGroup.SelectedIndex = 0;
                //        break;
                //}
                if (isCapTestSubCountVisiable)
                {
                    txtCapTestSubCount.Visible = true;
                    lblCapTestSubCount.Visible = true;
                    chbIsRobot.Visible = true;
                }
                else
                {
                    txtCapTestSubCount.Visible = false;
                    lblCapTestSubCount.Visible = false;
                    chbIsRobot.Visible = false;
                }
            }
            catch { }
        }

        private void cbSourceGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cbSourceStatoin.Items.Clear();
                int group = Convert.ToInt32(cbSourceGroup.Text);
                List<string> ls = new List<string>();
                //switch (taskType)
                //{
                //    //分容测试
                //    case Enumerations.TaskType.Test_CommparmentReload:
                //        break;
                //    case Enumerations.TaskType.Test_LoadLeaveNullTray:
                //        ls = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.CapacityTestStation && Common.Instance.dtStationInformation[o].Group == group);
                //        break;
                //    case Enumerations.TaskType.Test_FullCommparmentRefueling:
                //    case Enumerations.TaskType.Test_FullCommparmentRequest:
                //    case Enumerations.TaskType.Test_NullCompartmentRequest:
                //    case Enumerations.TaskType.Test_LoadRequestLoad:
                //    case Enumerations.TaskType.Test_LoadRequestUnload:
                //        ls = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.CapacityTestStation && Common.Instance.dtStationInformation[o].Group == group);
                //        break;
                //    //预充老化
                //    case Enumerations.TaskType.Pre_AgingRoom_AgingRoom:
                //        ls = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.PreAgingRoom && Common.Instance.dtStationInformation[o].Group == group);
                //        break;
                //    case Enumerations.TaskType.Pre_AgingRoom_RestintZone:
                //        ls = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.PreAgingRoom && Common.Instance.dtStationInformation[o].Group == group);
                //        break;
                //    case Enumerations.TaskType.Pre_RestingZone_Unload:
                //        ls = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.PreStaticArea && Common.Instance.dtStationInformation[o].Group == group);
                //        break;
                //    case Enumerations.TaskType.Pre_Load_AgingRoom:
                //        ls = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.PreAgingLoadArea && Common.Instance.dtStationInformation[o].Group == group);
                //        break;
                //    case Enumerations.TaskType.Pre_Unload_Load:
                //        ls = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.PreAgingUnloadArea && Common.Instance.dtStationInformation[o].Group == group);
                //        break;
                //    case Enumerations.TaskType.Charge_CapTest:
                //        ls = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.ChargeCap && Common.Instance.dtStationInformation[o].Group == group);
                //        break;
                //    //分容老化
                //    case Enumerations.TaskType.Cap_AgingRoom_AgingRoom:
                //        ls = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.DCapAgingRoom && Common.Instance.dtStationInformation[o].Group == group);
                //        break;
                //    case Enumerations.TaskType.Cap_AgingRoom_RestintZone:
                //        ls = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.DCapAgingRoom && Common.Instance.dtStationInformation[o].Group == group);
                //        break;
                //    case Enumerations.TaskType.Cap_RestingZone_Unload:
                //        ls = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.DCapStaticArea && Common.Instance.dtStationInformation[o].Group == group);
                //        break;
                //    case Enumerations.TaskType.Cap_Load_AgingRoom:
                //        ls = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.DCapAgingLoadArea && Common.Instance.dtStationInformation[o].Group == group);
                //        break;
                //    case Enumerations.TaskType.Cap_Unload_Load:
                //        ls = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.DCapAgingUnloadArea && Common.Instance.dtStationInformation[o].Group == group);
                //        break;
                //}
                foreach (string item in ls)
                {
                    cbSourceStatoin.Items.Add(Common.Instance.dtStationInformation[item].StationMatchValue);
                }
                cbSourceStatoin.SelectedIndex = 0;
            }
            catch { }
        }

        private void cbSourceStatoin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbTargetGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int group = Convert.ToInt32(cbTargetGroup.Text);
                List<string> lsKey = new List<string>();
                List<string> lsvalue = new List<string>();
                cbTargetStatoin.Items.Clear();
                //switch (taskType)
                //{
                //    //分容测试
                //    case Enumerations.TaskType.Test_CommparmentReload:
                //    case Enumerations.TaskType.Test_LoadLeaveNullTray:
                //    case Enumerations.TaskType.Test_LoadRequestLoad:
                //    case Enumerations.TaskType.Test_LoadRequestUnload:
                //        break;
                //    case Enumerations.TaskType.Test_FullCommparmentRefueling:
                //    case Enumerations.TaskType.Test_FullCommparmentRequest:
                //    case Enumerations.TaskType.Test_NullCompartmentRequest:
                //        lsKey = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.SubCabinet && Common.Instance.dtStationInformation[o].Group == group);
                //        foreach (string item in lsKey)
                //        {
                //            cbTargetStatoin.Items.Add(Common.Instance.dtStationInformation[item].StationMatchValue);
                //        }
                //        cbTargetStatoin.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Charge_CapTest:
                //        lsKey = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.ChargeCap && Common.Instance.dtStationInformation[o].Group == group && Common.Instance.dtChargeInfo.Any(p => p.Value.Rfid == Common.Instance.dtStationInformation[o].StationRfid && p.Value.ChargeComm.Enable));
                //        foreach (string item in lsKey)
                //        {
                //            cbTargetStatoin.Items.Add(Common.Instance.dtStationInformation[item].StationMatchValue);
                //        }
                //        cbTargetStatoin.SelectedIndex = 0;
                //        break;
                //    //预充老化
                //    case Enumerations.TaskType.Pre_AgingRoom_AgingRoom:
                //        lsKey = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.PreAgingRoom && Common.Instance.dtStationInformation[o].Group == group);
                //        foreach (string item in lsKey)
                //        {
                //            cbTargetStatoin.Items.Add(Common.Instance.dtStationInformation[item].StationMatchValue);
                //        }
                //        cbTargetStatoin.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Pre_AgingRoom_RestintZone:
                //        lsKey = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.PreStaticArea && Common.Instance.dtStationInformation[o].Group == group);
                //        foreach (string item in lsKey)
                //        {
                //            cbTargetStatoin.Items.Add(Common.Instance.dtStationInformation[item].StationMatchValue);
                //        }
                //        cbTargetStatoin.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Pre_RestingZone_Unload:
                //        lsKey = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.PreAgingUnloadArea && Common.Instance.dtStationInformation[o].Group == group);
                //        foreach (string item in lsKey)
                //        {
                //            cbTargetStatoin.Items.Add(Common.Instance.dtStationInformation[item].StationMatchValue);
                //        }
                //        cbTargetStatoin.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Pre_Load_AgingRoom:
                //        lsKey = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.PreAgingRoom && Common.Instance.dtStationInformation[o].Group == group);
                //        foreach (string item in lsKey)
                //        {
                //            cbTargetStatoin.Items.Add(Common.Instance.dtStationInformation[item].StationMatchValue);
                //        }
                //        cbTargetStatoin.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Pre_Unload_Load:
                //        lsKey = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.PreAgingLoadArea && Common.Instance.dtStationInformation[o].Group == group);
                //        foreach (string item in lsKey)
                //        {
                //            cbTargetStatoin.Items.Add(Common.Instance.dtStationInformation[item].StationMatchValue);
                //        }
                //        cbTargetStatoin.SelectedIndex = 0;
                //        break;
                //    //分容老化
                //    case Enumerations.TaskType.Cap_AgingRoom_AgingRoom:
                //        lsKey = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.DCapAgingRoom && Common.Instance.dtStationInformation[o].Group == group);
                //        foreach (string item in lsKey)
                //        {
                //            cbTargetStatoin.Items.Add(Common.Instance.dtStationInformation[item].StationMatchValue);
                //        }
                //        cbTargetStatoin.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Cap_AgingRoom_RestintZone:
                //        lsKey = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.DCapStaticArea && Common.Instance.dtStationInformation[o].Group == group);
                //        foreach (string item in lsKey)
                //        {
                //            cbTargetStatoin.Items.Add(Common.Instance.dtStationInformation[item].StationMatchValue);
                //        }
                //        cbTargetStatoin.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Cap_RestingZone_Unload:
                //        lsKey = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.DCapAgingUnloadArea && Common.Instance.dtStationInformation[o].Group == group);
                //        foreach (string item in lsKey)
                //        {
                //            cbTargetStatoin.Items.Add(Common.Instance.dtStationInformation[item].StationMatchValue);
                //        }
                //        cbTargetStatoin.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Cap_Load_AgingRoom:
                //        lsKey = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.DCapAgingRoom && Common.Instance.dtStationInformation[o].Group == group);
                //        foreach (string item in lsKey)
                //        {
                //            cbTargetStatoin.Items.Add(Common.Instance.dtStationInformation[item].StationMatchValue);
                //        }
                //        cbTargetStatoin.SelectedIndex = 0;
                //        break;
                //    case Enumerations.TaskType.Cap_Unload_Load:
                //        lsKey = Common.Instance.dtStationInformation.Keys.ToList().FindAll(o => Common.Instance.dtStationInformation[o].StationType == (int)StationInformation.EStationType.DCapAgingLoadArea && Common.Instance.dtStationInformation[o].Group == group);
                //        foreach (string item in lsKey)
                //        {
                //            cbTargetStatoin.Items.Add(Common.Instance.dtStationInformation[item].StationMatchValue);
                //        }
                //        cbTargetStatoin.SelectedIndex = 0;
                //        break;
                //}
            }
            catch { }
        }

        private void cbTargetStatoin_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbTaskBindAgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbTaskBindAgv.SelectedIndex == 0)
                {
                    selectAgvNo = -1;
                }
                else
                {
                    selectAgvNo = Convert.ToInt32(cbTaskBindAgv.Text);
                }
            }
            catch { }
        }

        private void btnTaskAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("是否添加？"), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    bool isCreateTask = false;
                    if (selectAgvNo <= 0)
                    {
                        isCreateTask = true;
                    }
                    else
                    {
                        isCreateTask = true;
                        //if (Common.maiDict[selectAgvNo].Task2 != string.Empty || Common.maiDict[selectAgvNo].State != (int)Enumerations.AgvStatus.stop)
                        //{
                        //    isCreateTask = false;
                        //    MessageBox.Show(string.Format("Agv{0} 已有预定任务 或 掉线，不可接受任务", selectAgvNo));
                        //}
                        //else
                        //{
                        //    isCreateTask = true;
                        //}
                    }
                    if (isCreateTask)
                    {
                        bool isAdd = true;
                        MA_AgvTaskInfo taskInfo = new MA_AgvTaskInfo();
                        taskInfo.T_State = Enumerations.TaskStatus.Accept;
                        StationInformation stationInformationSource;
                        StationInformation stationInformationTarget;
                        taskInfo.IsUpdate = true;
                        taskInfo.T_Type = taskType;
                        taskInfo.IsTest = true;
                        RouteInfo re;
                        RouteInfo rSource;
                        string sourceMatchValue = string.Empty;
                        string targetMatchValue = string.Empty;
                        //switch (taskType)
                        //{
                        //    //分容测试
                        //    case Enumerations.TaskType.Test_CommparmentReload:
                        //        MessageBox.Show(string.Format("[{0}]类型任务已屏蔽，不可生成模拟任务", Common.Instance.dtTaskTypeName[taskType]));
                        //        break;
                        //    case Enumerations.TaskType.Test_FullCommparmentRefueling:
                        //    case Enumerations.TaskType.Test_FullCommparmentRequest:
                        //    case Enumerations.TaskType.Test_NullCompartmentRequest:
                        //        taskInfo.T_Type = taskType;
                        //        sourceMatchValue = cbSourceStatoin.Text.Trim();
                        //        int sRfid = Common.Instance.dtStationInformation.Values.ToList().Find(o => o.StationMatchValue == sourceMatchValue && o.StationType == (int)StationInformation.EStationType.CapacityTestStation).StationRfid;
                        //        taskInfo.T_Load = sRfid;
                        //        targetMatchValue = cbTargetStatoin.Text.Trim();
                        //        int rfid = Common.Instance.dtStationInformation.Values.ToList().Find(o => o.StationMatchValue == targetMatchValue && o.StationType == (int)StationInformation.EStationType.SubCabinet).StationRfid;
                        //        string operate = Common.Instance.dtStationInformation.Values.ToList().Find(o => o.StationMatchValue == targetMatchValue && o.StationType == (int)StationInformation.EStationType.SubCabinet).StationOperate;
                        //        int waitNo = 1;
                        //        int count = 5;
                        //        try
                        //        {
                        //            count = Convert.ToInt32(txtCapTestSubCount.Text);
                        //            counts = count;
                        //        }
                        //        catch { }
                        //        string[] ss = new string[count];
                        //        for (int i = rfid; i < rfid + count; i++)
                        //        {
                        //            string mv = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationRfid == i && o.Value.StationOperate == operate && o.Value.StationType == (int)StationInformation.EStationType.SubCabinet).Value.StationMatchValue;
                        //            StationInformation stationInformation = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == mv && o.Value.StationType == (int)StationInformation.EStationType.SubCabinet).Value;
                        //            bool isOperate = false;
                        //            try
                        //            {
                        //                isOperate = stationInformation.StationEnable;
                        //            }
                        //            catch { }
                        //            int toperate = OperateTranform(taskType, stationInformation.StationOperate);
                        //            if (chbIsRobot.Checked == false) toperate = 0;
                        //            if (isOperate == false) toperate = 0;
                        //            RouteInfo r = new RouteInfo(RouteType.CapacityUnload, stationInformation.StationRfid, toperate, string.Format("往分容柜{0}填料", mv));
                        //            ss[i - rfid] = mv;
                        //            r.Index = i + 1;
                        //            //r.BackState = (int)EBackState.Accept;
                        //            taskInfo.T_Process.Add(r);
                        //            try
                        //            {
                        //                waitNo = Common.Instance.dtCapacityTestWait.First(o => o.Value.lsRfids.Any(p => stationInformation.StationRfid >= p.X && stationInformation.StationRfid <= p.Y)).Key;
                        //            }
                        //            catch { }
                        //        }
                        //        if (waitNo != 2) waitNo = 1;
                        //        re = new RouteInfo(RouteType.GoWait, Common.Instance.dtCapacityTestWait[waitNo].Rfid, 0, string.Format("前往分容测试待机点{0}", waitNo));
                        //        //taskInfo.T_Load = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == 1 && o.Value.StationMatchValue == taskRelease.PlaceSource[0].Trim()).Value.StationNo;
                        //        taskInfo.T_Process.Add(re);
                        //        taskInfo.ProcessIndex = 0;
                        //        taskInfo.T_CreateTime = DateTime.Now;
                        //        taskInfo.T_Level = 0;
                        //        taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                        //        taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //        try
                        //        {
                        //            taskInfo.T_Description = string.Join("\r\n", ss);
                        //            if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //        }
                        //        catch { }
                        //        taskInfo.T_AgvNo = selectAgvNo;
                        //        if (taskInfo.T_AgvNo > 0)
                        //        {
                        //            if (Common.maiDict[selectAgvNo].Task2 == string.Empty)
                        //                Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //            else
                        //            {
                        //                isAdd = false;
                        //            }
                        //        }
                        //        if (isAdd)
                        //        {
                        //            taskInfo.T_State = Enumerations.TaskStatus.Accept;
                        //            Common.taskCapacityTestDt[taskInfo.T_Id] = taskInfo;
                        //            isRobot = chbIsRobot.Checked;
                        //            MessageBox.Show("添加模拟任务成功");
                        //            this.Close();
                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show(string.Format("Agv{0}已有预定任务，请选择其它AGV", selectAgvNo));
                        //        }
                        //        break;
                        //    case Enumerations.TaskType.Charge_CapTest:  //充电
                        //        if (selectAgvNo > 0)
                        //        {
                        //            targetMatchValue = cbTargetStatoin.Text.Trim();
                        //            StationInformation st = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == targetMatchValue && o.Value.StationType == (int)StationInformation.EStationType.ChargeCap).Value;
                        //            if (Common.Instance.dtChargeInfo.Any(o => o.Value.Rfid == st.StationRfid && o.Value.BindAgv <= 0))
                        //            {
                        //                int chargeNo = Common.Instance.dtChargeInfo.FirstOrDefault(o => o.Value.Rfid == st.StationRfid).Key;
                        //                re = new RouteInfo(RouteType.ChargeCap, st.StationRfid, Convert.ToInt32(st.StationOperate), string.Format("前往充电区{0}充电", targetMatchValue));
                        //                //re.BackState = (int)EBackState.Accept;
                        //                taskInfo.T_Process.Add(re);
                        //                taskInfo.ProcessIndex = 0;
                        //                taskInfo.T_CreateTime = DateTime.Now;
                        //                taskInfo.T_Level = 0;
                        //                taskInfo.T_State = Enumerations.TaskStatus.Book;
                        //                taskInfo.IsTest = true;
                        //                taskInfo.T_Id = string.Format("{0}_{1}", st.StationMatchValue, DateTime.Now.ToString("HHmmfff"));
                        //                taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //                try
                        //                {
                        //                    taskInfo.T_Description = targetMatchValue;
                        //                    if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //                }
                        //                catch { }
                        //                taskInfo.T_AgvNo = selectAgvNo;
                        //                if (taskInfo.T_AgvNo > 0)
                        //                {
                        //                    Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //                    Common.maiDict[selectAgvNo].VoltageStatus = Enumerations.voltageStatus.chargVoltage;
                        //                }
                        //                Common.Instance.dtChargeInfo[chargeNo].BindAgv = selectAgvNo + 100;
                        //                Common.Instance.dtChargeInfo[chargeNo].BeginTime = new DateTime();
                        //                Common.taskCapacityTestDt[taskInfo.T_Id] = taskInfo;
                        //                MessageBox.Show("添加模拟任务成功");
                        //                this.Close();
                        //            }
                        //            else
                        //            {
                        //                MessageBox.Show("该充电桩已经被预定");
                        //            }
                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("充电任务必须选定AGV");
                        //        }
                        //        break;
                        //    case Enumerations.TaskType.Test_LoadLeaveNullTray:
                        //        if (selectAgvNo > 0)
                        //        {
                        //            sourceMatchValue = cbSourceStatoin.Text.Trim();
                        //            StationInformation st = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == sourceMatchValue && o.Value.StationType == (int)StationInformation.EStationType.CapacityTestStation).Value;
                        //            re = new RouteInfo(RouteType.GoWait, Common.Instance.dtCapacityTestWait[2].Rfid, 0, "前往待机位2");
                        //            //re.BackState = (int)EBackState.Accept;
                        //            taskInfo.T_Process.Add(re);
                        //            taskInfo.ProcessIndex = 0;
                        //            taskInfo.T_CreateTime = DateTime.Now;
                        //            taskInfo.T_Level = 0;
                        //            taskInfo.T_State = Enumerations.TaskStatus.Book;
                        //            taskInfo.IsTest = true;
                        //            taskInfo.T_Id = string.Format("{0}_{1}", "Wait2", DateTime.Now.ToString("HHmmfff"));
                        //            taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //            try
                        //            {
                        //                taskInfo.T_Description = targetMatchValue;
                        //                if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //            }
                        //            catch { }
                        //            taskInfo.T_AgvNo = selectAgvNo;
                        //            if (taskInfo.T_AgvNo > 0) Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //            Common.taskCapacityTestDt[taskInfo.T_Id] = taskInfo;
                        //            MessageBox.Show("添加模拟任务成功");
                        //            this.Close();
                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show("回待机点任务必须选定AGV");
                        //        }
                        //        break;
                        //    case Enumerations.TaskType.Test_LoadRequestLoad:
                        //    case Enumerations.TaskType.Test_LoadRequestUnload:
                        //        sourceMatchValue = cbSourceStatoin.Text.Trim();
                        //        //taskInfo.T_Load = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.CapacityTestStation && o.Value.StationMatchValue == taskRelease.PlaceSource[0].Trim()).Value.StationNo;
                        //        re = new RouteInfo(RouteType.CapacityLoad, Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == sourceMatchValue && o.Value.StationType == (int)StationInformation.EStationType.CapacityTestStation).Value.StationRfid, 3, string.Format("前往上下料区{0}装料", sourceMatchValue));
                        //        //re.BackState = (int)EBackState.Accept;
                        //        taskInfo.T_Process.Add(re);
                        //        taskInfo.ProcessIndex = 0;
                        //        taskInfo.T_CreateTime = DateTime.Now;
                        //        taskInfo.T_Level = 0;
                        //        taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                        //        taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //        try
                        //        {
                        //            taskInfo.T_Description = sourceMatchValue;
                        //            if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //        }
                        //        catch { }
                        //        taskInfo.T_AgvNo = selectAgvNo;
                        //        if (taskInfo.T_AgvNo > 0)
                        //        {
                        //            if (Common.maiDict[selectAgvNo].Task2 == string.Empty)
                        //            {
                        //                Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //            }
                        //            else
                        //            {
                        //                isAdd = false;
                        //            }
                        //        }
                        //        if (isAdd)
                        //        {
                        //            Common.taskCapacityTestDt[taskInfo.T_Id] = taskInfo;
                        //            MessageBox.Show("添加模拟任务成功");
                        //            this.Close();
                        //        }
                        //        else
                        //        {
                        //            MessageBox.Show(string.Format("Agv{0}已有预定任务，请选择其它AGV", selectAgvNo));
                        //        }
                        //        break;
                        //    //预充老化
                        //    case Enumerations.TaskType.Pre_AgingRoom_AgingRoom:
                        //        sourceMatchValue = cbSourceStatoin.Text.Trim();
                        //        targetMatchValue = cbTargetStatoin.Text.Trim();
                        //        stationInformationSource = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == sourceMatchValue && o.Value.StationType == (int)StationInformation.EStationType.PreAgingRoom).Value;
                        //        rSource = new RouteInfo(RouteType.PreAgingRoom, stationInformationSource.StationRfid, (int)Enumerations.EOperate.LiftUp, string.Format("前往老化房{0}装料", sourceMatchValue));
                        //        taskInfo.Group = stationInformationSource.Group;
                        //        taskInfo.T_Process.Add(rSource);
                        //        stationInformationTarget = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == targetMatchValue && o.Value.StationType == (int)StationInformation.EStationType.PreAgingRoom).Value;
                        //        re = new RouteInfo(RouteType.PreAgingRoom, stationInformationTarget.StationRfid, (int)Enumerations.EOperate.Decline, string.Format("前往老化房{0}卸料", targetMatchValue));
                        //        re.SourceStation = stationInformationSource.StationRfid;
                        //        //re.BackState = (int)EBackState.Accept;
                        //        taskInfo.T_Process.Add(re);
                        //        //RouteInfo re = new RouteInfo(RouteType.GoWait,
                        //        taskInfo.ProcessIndex = 0;
                        //        taskInfo.T_CreateTime = DateTime.Now;
                        //        taskInfo.T_Level = 0;
                        //        taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                        //        taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //        try
                        //        {
                        //            taskInfo.T_Description = string.Format("{0}\r\n{1}", sourceMatchValue, targetMatchValue);
                        //            if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //        }
                        //        catch { }
                        //        taskInfo.T_AgvNo = selectAgvNo;
                        //        if (taskInfo.T_AgvNo > 0) Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //        Common.taskPreChargeAgingRoomDt[taskInfo.T_Id] = taskInfo;
                        //        MessageBox.Show("添加模拟任务成功");
                        //        this.Close();
                        //        break;
                        //    case Enumerations.TaskType.Pre_AgingRoom_RestintZone:
                        //        sourceMatchValue = cbSourceStatoin.Text.Trim();
                        //        targetMatchValue = cbTargetStatoin.Text.Trim();
                        //        stationInformationSource = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == sourceMatchValue && o.Value.StationType == (int)StationInformation.EStationType.PreAgingRoom).Value;
                        //        taskInfo.Group = stationInformationSource.Group;
                        //        rSource = new RouteInfo(RouteType.PreAgingRoom, stationInformationSource.StationRfid, (int)Enumerations.EOperate.LiftUp, string.Format("前往老化房{0}装料", sourceMatchValue));
                        //        taskInfo.T_Process.Add(rSource);
                        //        stationInformationTarget = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == targetMatchValue && o.Value.StationType == (int)StationInformation.EStationType.PreStaticArea).Value;
                        //        re = new RouteInfo(RouteType.PreStaticArea, stationInformationTarget.StationRfid, (int)Enumerations.EOperate.Decline, string.Format("前往静置区{0}卸料", targetMatchValue));
                        //        re.SourceStation = stationInformationSource.StationRfid;
                        //        //re.BackState = (int)EBackState.Accept;
                        //        taskInfo.T_Process.Add(re);
                        //        //RouteInfo re = new RouteInfo(RouteType.GoWait,
                        //        taskInfo.ProcessIndex = 0;
                        //        taskInfo.T_CreateTime = DateTime.Now;
                        //        taskInfo.T_Level = 0;
                        //        taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                        //        taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //        try
                        //        {
                        //            taskInfo.T_Description = string.Format("{0}\r\n{1}", sourceMatchValue, targetMatchValue);
                        //            if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //        }
                        //        catch { }
                        //        taskInfo.T_AgvNo = selectAgvNo;
                        //        if (taskInfo.T_AgvNo > 0) Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //        Common.taskPreChargeAgingRoomDt[taskInfo.T_Id] = taskInfo;
                        //        MessageBox.Show("添加模拟任务成功");
                        //        this.Close();
                        //        break;
                        //    case Enumerations.TaskType.Pre_RestingZone_Unload:
                        //        sourceMatchValue = cbSourceStatoin.Text.Trim();
                        //        targetMatchValue = cbTargetStatoin.Text.Trim();
                        //        stationInformationSource = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == sourceMatchValue && o.Value.StationType == (int)StationInformation.EStationType.PreStaticArea).Value;
                        //        rSource = new RouteInfo(RouteType.PreStaticArea, stationInformationSource.StationRfid, (int)Enumerations.EOperate.LiftUp, string.Format("前往静置区{0}装料", sourceMatchValue));
                        //        taskInfo.T_Process.Add(rSource);
                        //        stationInformationTarget = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == targetMatchValue && o.Value.StationType == (int)StationInformation.EStationType.PreAgingUnloadArea).Value;
                        //        re = new RouteInfo(RouteType.PreAgingUnloadArea, stationInformationTarget.StationRfid, (int)Enumerations.EOperate.Decline, string.Format("前往下料区{0}卸料", targetMatchValue));
                        //        re.SourceStation = stationInformationSource.StationRfid;
                        //        //re.BackState = (int)EBackState.Accept;
                        //        taskInfo.T_Process.Add(re);
                        //        //RouteInfo re = new RouteInfo(RouteType.GoWait,
                        //        taskInfo.ProcessIndex = 0;
                        //        taskInfo.T_CreateTime = DateTime.Now;
                        //        taskInfo.T_Level = 0;
                        //        taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                        //        taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //        try
                        //        {
                        //            taskInfo.T_Description = string.Format("{0}\r\n{1}", sourceMatchValue, targetMatchValue);
                        //            if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //        }
                        //        catch { }
                        //        taskInfo.T_AgvNo = selectAgvNo;
                        //        if (taskInfo.T_AgvNo > 0) Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //        Common.taskPreChargeAgingRoomDt[taskInfo.T_Id] = taskInfo;
                        //        MessageBox.Show("添加模拟任务成功");
                        //        this.Close();
                        //        break;
                        //    case Enumerations.TaskType.Pre_Load_AgingRoom:
                        //        sourceMatchValue = cbSourceStatoin.Text.Trim();
                        //        targetMatchValue = cbTargetStatoin.Text.Trim();
                        //        stationInformationSource = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == sourceMatchValue && o.Value.StationType == (int)StationInformation.EStationType.PreAgingLoadArea).Value;
                        //        rSource = new RouteInfo(RouteType.PreAgingLoadArea, stationInformationSource.StationRfid, (int)Enumerations.EOperate.LiftUp, string.Format("前往老化上料区{0}装料", sourceMatchValue));
                        //        taskInfo.T_Process.Add(rSource);
                        //        stationInformationTarget = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == targetMatchValue && o.Value.StationType == (int)StationInformation.EStationType.PreAgingRoom).Value;
                        //        taskInfo.Group = stationInformationTarget.Group;
                        //        re = new RouteInfo(RouteType.PreAgingRoom, stationInformationTarget.StationRfid, (int)Enumerations.EOperate.Decline, string.Format("前往老化房{0}卸料", targetMatchValue));
                        //        re.SourceStation = stationInformationSource.StationRfid;
                        //        //re.BackState = (int)EBackState.Accept;
                        //        taskInfo.T_Process.Add(re);
                        //        //RouteInfo re = new RouteInfo(RouteType.GoWait,
                        //        taskInfo.ProcessIndex = 0;
                        //        taskInfo.T_CreateTime = DateTime.Now;
                        //        taskInfo.T_Level = 0;
                        //        taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                        //        taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //        try
                        //        {
                        //            taskInfo.T_Description = string.Format("{0}\r\n{1}", sourceMatchValue, targetMatchValue);
                        //            if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //        }
                        //        catch { }
                        //        taskInfo.T_AgvNo = selectAgvNo;
                        //        if (taskInfo.T_AgvNo > 0) Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //        Common.taskPreChargeAgingRoomDt[taskInfo.T_Id] = taskInfo;
                        //        MessageBox.Show("添加模拟任务成功");
                        //        this.Close();
                        //        break;
                        //    case Enumerations.TaskType.Pre_Unload_Load:
                        //        sourceMatchValue = cbSourceStatoin.Text.Trim();
                        //        targetMatchValue = cbTargetStatoin.Text.Trim();
                        //        stationInformationSource = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == sourceMatchValue && o.Value.StationType == (int)StationInformation.EStationType.PreAgingUnloadArea).Value;
                        //        rSource = new RouteInfo(RouteType.PreAgingUnloadArea, stationInformationSource.StationRfid, (int)Enumerations.EOperate.LiftUp, string.Format("前往老化卸料区{0}装板", sourceMatchValue));
                        //        taskInfo.T_Process.Add(rSource);
                        //        stationInformationTarget = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == targetMatchValue && o.Value.StationType == (int)StationInformation.EStationType.PreAgingLoadArea).Value;
                        //        taskInfo.Group = stationInformationTarget.Group;
                        //        re = new RouteInfo(RouteType.PreAgingLoadArea, stationInformationTarget.StationRfid, (int)Enumerations.EOperate.Decline, string.Format("前往老化装料区{0}卸板", targetMatchValue));
                        //        re.SourceStation = stationInformationSource.StationRfid;
                        //        //re.BackState = (int)EBackState.Accept;
                        //        taskInfo.T_Process.Add(re);
                        //        //RouteInfo re = new RouteInfo(RouteType.GoWait,
                        //        taskInfo.ProcessIndex = 0;
                        //        taskInfo.T_CreateTime = DateTime.Now;
                        //        taskInfo.T_Level = 0;
                        //        taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                        //        taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //        try
                        //        {
                        //            taskInfo.T_Description = string.Format("{0}\r\n{1}", sourceMatchValue, targetMatchValue);
                        //            if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //        }
                        //        catch { }
                        //        taskInfo.T_AgvNo = selectAgvNo;
                        //        if (taskInfo.T_AgvNo > 0) Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //        Common.taskPreChargeAgingRoomDt[taskInfo.T_Id] = taskInfo;
                        //        MessageBox.Show("添加模拟任务成功");
                        //        this.Close();
                        //        break;
                        //    //分容老化
                        //    case Enumerations.TaskType.Cap_AgingRoom_AgingRoom:
                        //        sourceMatchValue = cbSourceStatoin.Text.Trim();
                        //        targetMatchValue = cbTargetStatoin.Text.Trim();
                        //        stationInformationSource = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == sourceMatchValue && o.Value.StationType == (int)StationInformation.EStationType.DCapAgingRoom).Value;
                        //        taskInfo.Group = stationInformationSource.Group;
                        //        rSource = new RouteInfo(RouteType.DCapAgingRoom, stationInformationSource.StationRfid, (int)Enumerations.EOperate.LiftUp, string.Format("前往老化房{0}装料", sourceMatchValue));
                        //        taskInfo.T_Process.Add(rSource);
                        //        stationInformationTarget = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == targetMatchValue && o.Value.StationType == (int)StationInformation.EStationType.DCapAgingRoom).Value;
                        //        re = new RouteInfo(RouteType.DCapAgingRoom, stationInformationTarget.StationRfid, (int)Enumerations.EOperate.Decline, string.Format("前往老化房{0}卸料", targetMatchValue));
                        //        re.SourceStation = stationInformationSource.StationRfid;
                        //        //re.BackState = (int)EBackState.Accept;
                        //        taskInfo.T_Process.Add(re);
                        //        //RouteInfo re = new RouteInfo(RouteType.GoWait,
                        //        taskInfo.ProcessIndex = 0;
                        //        taskInfo.T_CreateTime = DateTime.Now;
                        //        taskInfo.T_Level = 0;
                        //        taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                        //        taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //        try
                        //        {
                        //            taskInfo.T_Description = string.Format("{0}\r\n{1}", sourceMatchValue, targetMatchValue);
                        //            if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //        }
                        //        catch { }
                        //        taskInfo.T_AgvNo = selectAgvNo;
                        //        if (taskInfo.T_AgvNo > 0) Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //        Common.taskCapacityAgingRoomDt[taskInfo.T_Id] = taskInfo;
                        //        MessageBox.Show("添加模拟任务成功");
                        //        this.Close();
                        //        break;
                        //    case Enumerations.TaskType.Cap_AgingRoom_RestintZone:
                        //        sourceMatchValue = cbSourceStatoin.Text.Trim();
                        //        targetMatchValue = cbTargetStatoin.Text.Trim();
                        //        stationInformationSource = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == sourceMatchValue && o.Value.StationType == (int)StationInformation.EStationType.DCapAgingRoom).Value;
                        //        taskInfo.Group = stationInformationSource.Group;
                        //        rSource = new RouteInfo(RouteType.DCapAgingRoom, stationInformationSource.StationRfid, (int)Enumerations.EOperate.LiftUp, string.Format("前往老化房{0}装料", sourceMatchValue));
                        //        taskInfo.T_Process.Add(rSource);
                        //        stationInformationTarget = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == targetMatchValue && o.Value.StationType == (int)StationInformation.EStationType.DCapStaticArea).Value;
                        //        re = new RouteInfo(RouteType.DCapStaticArea, stationInformationTarget.StationRfid, (int)Enumerations.EOperate.Decline, string.Format("前往静置区{0}卸料", targetMatchValue));
                        //        re.SourceStation = stationInformationSource.StationRfid;
                        //        //re.BackState = (int)EBackState.Accept;
                        //        taskInfo.T_Process.Add(re);
                        //        //RouteInfo re = new RouteInfo(RouteType.GoWait,
                        //        taskInfo.ProcessIndex = 0;
                        //        taskInfo.T_CreateTime = DateTime.Now;
                        //        taskInfo.T_Level = 0;
                        //        taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                        //        taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //        try
                        //        {
                        //            taskInfo.T_Description = string.Format("{0}\r\n{1}", sourceMatchValue, targetMatchValue);
                        //            if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //        }
                        //        catch { }
                        //        taskInfo.T_AgvNo = selectAgvNo;
                        //        if (taskInfo.T_AgvNo > 0) Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //        Common.taskCapacityAgingRoomDt[taskInfo.T_Id] = taskInfo;
                        //        MessageBox.Show("添加模拟任务成功");
                        //        this.Close();
                        //        break;
                        //    case Enumerations.TaskType.Cap_RestingZone_Unload:
                        //        sourceMatchValue = cbSourceStatoin.Text.Trim();
                        //        targetMatchValue = cbTargetStatoin.Text.Trim();
                        //        stationInformationSource = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == sourceMatchValue && o.Value.StationType == (int)StationInformation.EStationType.DCapStaticArea).Value;
                        //        rSource = new RouteInfo(RouteType.DCapStaticArea, stationInformationSource.StationRfid, (int)Enumerations.EOperate.LiftUp, string.Format("前往静置区{0}装料", sourceMatchValue));
                        //        taskInfo.T_Process.Add(rSource);
                        //        stationInformationTarget = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == targetMatchValue && o.Value.StationType == (int)StationInformation.EStationType.DCapAgingUnloadArea).Value;
                        //        re = new RouteInfo(RouteType.DCapAgingUnloadArea, stationInformationTarget.StationRfid, (int)Enumerations.EOperate.Decline, string.Format("前往老化下料区{0}卸料", targetMatchValue));
                        //        re.SourceStation = stationInformationSource.StationRfid;
                        //        //re.BackState = (int)EBackState.Accept;
                        //        taskInfo.T_Process.Add(re);
                        //        //RouteInfo re = new RouteInfo(RouteType.GoWait,
                        //        taskInfo.ProcessIndex = 0;
                        //        taskInfo.T_CreateTime = DateTime.Now;
                        //        taskInfo.T_Level = 0;
                        //        taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                        //        taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //        try
                        //        {
                        //            taskInfo.T_Description = string.Format("{0}\r\n{1}", sourceMatchValue, targetMatchValue);
                        //            if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //        }
                        //        catch { }
                        //        taskInfo.T_AgvNo = selectAgvNo;
                        //        if (taskInfo.T_AgvNo > 0) Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //        Common.taskCapacityAgingRoomDt[taskInfo.T_Id] = taskInfo;
                        //        MessageBox.Show("添加模拟任务成功");
                        //        this.Close();
                        //        break;
                        //    case Enumerations.TaskType.Cap_Load_AgingRoom:
                        //        sourceMatchValue = cbSourceStatoin.Text.Trim();
                        //        targetMatchValue = cbTargetStatoin.Text.Trim();
                        //        stationInformationSource = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == sourceMatchValue && o.Value.StationType == (int)StationInformation.EStationType.DCapAgingLoadArea).Value;
                        //        rSource = new RouteInfo(RouteType.DCapAgingLoadArea, stationInformationSource.StationRfid, (int)Enumerations.EOperate.LiftUp, string.Format("前往老化上料区{0}装料", sourceMatchValue));
                        //        taskInfo.T_Process.Add(rSource);
                        //        stationInformationTarget = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == targetMatchValue && o.Value.StationType == (int)StationInformation.EStationType.DCapAgingRoom).Value;
                        //        taskInfo.Group = stationInformationTarget.Group;
                        //        re = new RouteInfo(RouteType.DCapAgingRoom, stationInformationTarget.StationRfid, (int)Enumerations.EOperate.Decline, string.Format("前往老化房{0}卸料", targetMatchValue));
                        //        re.SourceStation = stationInformationSource.StationRfid;
                        //        //re.BackState = (int)EBackState.Accept;
                        //        taskInfo.T_Process.Add(re);
                        //        //RouteInfo re = new RouteInfo(RouteType.GoWait,
                        //        taskInfo.ProcessIndex = 0;
                        //        taskInfo.T_CreateTime = DateTime.Now;
                        //        taskInfo.T_Level = 0;
                        //        taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                        //        taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //        try
                        //        {
                        //            taskInfo.T_Description = string.Format("{0}\r\n{1}", sourceMatchValue, targetMatchValue);
                        //            if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //        }
                        //        catch { }
                        //        taskInfo.T_AgvNo = selectAgvNo;
                        //        if (taskInfo.T_AgvNo > 0) Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //        Common.taskCapacityAgingRoomDt[taskInfo.T_Id] = taskInfo;
                        //        MessageBox.Show("添加模拟任务成功");
                        //        this.Close();
                        //        break;
                        //    case Enumerations.TaskType.Cap_Unload_Load:
                        //        sourceMatchValue = cbSourceStatoin.Text.Trim();
                        //        targetMatchValue = cbTargetStatoin.Text.Trim();
                        //        stationInformationSource = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == sourceMatchValue && o.Value.StationType == (int)StationInformation.EStationType.DCapAgingUnloadArea).Value;
                        //        rSource = new RouteInfo(RouteType.DCapAgingUnloadArea, stationInformationSource.StationRfid, (int)Enumerations.EOperate.LiftUp, string.Format("前往老化卸料区{0}装板", sourceMatchValue));
                        //        taskInfo.T_Process.Add(rSource);
                        //        stationInformationTarget = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == targetMatchValue && o.Value.StationType == (int)StationInformation.EStationType.DCapAgingLoadArea).Value;
                        //        taskInfo.Group = stationInformationTarget.Group;
                        //        re = new RouteInfo(RouteType.DCapAgingLoadArea, stationInformationTarget.StationRfid, (int)Enumerations.EOperate.Decline, string.Format("前往老化装料区{0}卸板", targetMatchValue));
                        //        re.SourceStation = stationInformationSource.StationRfid;
                        //        //re.BackState = (int)EBackState.Accept;
                        //        taskInfo.T_Process.Add(re);
                        //        //RouteInfo re = new RouteInfo(RouteType.GoWait,
                        //        taskInfo.ProcessIndex = 0;
                        //        taskInfo.T_CreateTime = DateTime.Now;
                        //        taskInfo.T_Level = 0;
                        //        taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                        //        taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                        //        try
                        //        {
                        //            taskInfo.T_Description = string.Format("{0}\r\n{1}", sourceMatchValue, targetMatchValue);
                        //            if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                        //        }
                        //        catch { }
                        //        taskInfo.T_AgvNo = selectAgvNo;
                        //        if (taskInfo.T_AgvNo > 0) Common.maiDict[selectAgvNo].Task2 = taskInfo.T_Id;
                        //        Common.taskCapacityAgingRoomDt[taskInfo.T_Id] = taskInfo;
                        //        MessageBox.Show("添加模拟任务成功");
                        //        this.Close();
                        //        break;
                        //}
                    }
                }
                catch { }
            }
        }

        private void btnCalcel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch { }
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

        private void btnTasksAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //if (taskType == Enumerations.TaskType.Test_FullCommparmentRefueling || taskType == Enumerations.TaskType.Test_FullCommparmentRequest || taskType == Enumerations.TaskType.Test_NullCompartmentRequest)
                //{
                //    int count = Convert.ToInt32(txtTasksCount.Text);
                //    string targetMatchValue = cbTargetStatoin.Text.Trim();
                //    string sourceMatchValue = string.Empty;
                //    if (count > 0)
                //    {
                //        for (int i = 1; i < count + 1; i++)
                //        {
                //            for (int j = 1; j < 5; j++)
                //            {
                //                if (j != 2 && j != 3)
                //                {
                //                    MA_AgvTaskInfo taskInfo = new MA_AgvTaskInfo();
                //                    taskInfo.T_State = Enumerations.TaskStatus.Accept;
                //                    sourceMatchValue = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationRfid == 6200 + j && o.Value.StationType == (int)StationInformation.EStationType.CapacityTestStation).Value.StationMatchValue;
                //                    taskInfo.IsUpdate = true;
                //                    taskInfo.T_Type = Enumerations.TaskType.Test_LoadRequestLoad;
                //                    taskInfo.IsTest = true;
                //                    RouteInfo re;
                //                    re = new RouteInfo(RouteType.CapacityLoad, Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == sourceMatchValue && o.Value.StationType == (int)StationInformation.EStationType.CapacityTestStation).Value.StationRfid, 0, string.Format("前往上下料区{0}装料", sourceMatchValue));
                //                    //re.BackState = (int)EBackState.Accept;
                //                    taskInfo.T_Process.Add(re);
                //                    taskInfo.ProcessIndex = 0;
                //                    taskInfo.T_CreateTime = DateTime.Now;
                //                    taskInfo.T_Level = 0;
                //                    taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                //                    taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                //                    try
                //                    {
                //                        taskInfo.T_Description = sourceMatchValue;
                //                        if (taskInfo.T_Description.Trim() == string.Empty) taskInfo.T_Description = "Null";
                //                    }
                //                    catch { }
                //                    taskInfo.T_AgvNo = -1;
                //                    Common.taskCapacityTestDt[taskInfo.T_Id] = taskInfo;
                //                    Thread.Sleep(20);

                //                    MA_AgvTaskInfo taskInfoSu = new MA_AgvTaskInfo();
                //                    taskInfoSu.T_State = Enumerations.TaskStatus.Accept;
                //                    taskInfoSu.IsUpdate = true;
                //                    taskInfoSu.T_Type = taskType;
                //                    taskInfoSu.IsTest = true;
                //                    int sRfid = Common.Instance.dtStationInformation.Values.ToList().Find(o => o.StationMatchValue == sourceMatchValue && o.StationType == (int)StationInformation.EStationType.CapacityTestStation).StationRfid;
                //                    taskInfoSu.T_Load = sRfid;
                //                    targetMatchValue = cbTargetStatoin.Text.Trim();
                //                    int rfid = Common.Instance.dtStationInformation.Values.ToList().Find(o => o.StationMatchValue == targetMatchValue && o.StationType == (int)StationInformation.EStationType.SubCabinet).StationRfid;
                //                    int waitNo = 1;
                //                    string[] ss = new string[5];
                //                    for (int k = rfid; k < rfid + 5; k++)
                //                    {
                //                        string mv = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationRfid == k && o.Value.StationType == (int)StationInformation.EStationType.SubCabinet).Value.StationMatchValue;
                //                        StationInformation stationInformation = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationMatchValue == mv && o.Value.StationType == (int)StationInformation.EStationType.SubCabinet).Value;
                //                        RouteInfo r = new RouteInfo(RouteType.CapacityUnload, stationInformation.StationRfid, OperateTranform(Enumerations.TaskType.Test_NullCompartmentRequest, stationInformation.StationOperate), string.Format("往分容柜{0}填料", mv));
                //                        ss[k - rfid] = mv;
                //                        r.Index = k + 1;
                //                        //r.BackState = (int)EBackState.Accept;
                //                        taskInfoSu.T_Process.Add(r);
                //                        try
                //                        {
                //                            waitNo = Common.Instance.dtCapacityTestWait.First(o => o.Value.lsRfids.Any(p => stationInformation.StationRfid >= p.X && stationInformation.StationRfid <= p.Y)).Key;
                //                        }
                //                        catch { }
                //                    }
                //                    if (waitNo != 2) waitNo = 1;
                //                    RouteInfo reSu;
                //                    reSu = new RouteInfo(RouteType.GoWait, Common.Instance.dtCapacityTestWait[waitNo].Rfid, 0, string.Format("前往分容测试待机点{0}", waitNo));
                //                    taskInfoSu.T_Process.Add(reSu);
                //                    taskInfoSu.ProcessIndex = 0;
                //                    taskInfoSu.T_CreateTime = DateTime.Now;
                //                    taskInfoSu.T_Level = 0;
                //                    taskInfoSu.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                //                    taskInfoSu.T_TaskName = Common.Instance.dtTaskTypeName[taskInfoSu.T_Type];
                //                    try
                //                    {
                //                        taskInfoSu.T_Description = string.Join("\r\n", ss);
                //                        if (taskInfoSu.T_Description.Trim() == string.Empty) taskInfoSu.T_Description = "Null";
                //                    }
                //                    catch { }
                //                    taskInfoSu.T_AgvNo = -1;
                //                    taskInfoSu.T_State = Enumerations.TaskStatus.Accept;
                //                    Common.taskCapacityTestDt[taskInfoSu.T_Id] = taskInfoSu;
                //                    Thread.Sleep(20);
                //                }
                //            }
                //        }
                //        MessageBox.Show("添加成功");
                //        this.Close();
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("一键添加只支持去分容柜上料下料换料任务");
                //}
            }
            catch
            {
                MessageBox.Show("数量只能为数值类型");
            }
        }

    }
}
