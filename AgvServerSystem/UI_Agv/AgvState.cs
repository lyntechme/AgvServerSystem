using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgvServerSystem
{
    public partial class AgvState : Form
    {
        private int agvNo = 0;
        private Dictionary<int, int> dtIndex = new Dictionary<int, int>();
        public static Form CurrentForm = null;
        public static int bufferGroup = 78;
        public AgvState(int agvNo_)
        {
            CurrentForm = this;
            InitializeComponent();
            agvNo = agvNo_;
            int[] agvList = Common.maiDict.Keys.ToArray();
            agvList = agvList.OrderBy(o => o).ToArray();
            cbAgvNo.Items.Clear();
            int i = 0;
            foreach (int item in agvList)
            {
                cbAgvNo.Items.Add(item.ToString());
                dtIndex[item] = i;
                i++;
            }
            if (agvList.Contains(agvNo))
            {
                cbAgvNo.SelectedIndex = dtIndex[agvNo_];
            }
            RefAgvState();
            if (LoginRoler.U_Level <= 1)
            {
                this.panSpecialOperate.Visible = false;
                this.Width = panState.Width + panRoute.Width + 15;
            }
            try
            {
                //    int max = Common.Instance.dtStationInformation.OrderByDescending(o => o.Value.Group).FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.TestCapcityLeaveUnused).Value.Group;
                //    cbLeaveUnusedStationNo.Items.Clear();
                //    if (max > 0)
                //    {
                //        for (int j = 1; j <= max; j++)
                //        {
                //            cbLeaveUnusedStationNo.Items.Add(j.ToString());
                //        }
                //        cbLeaveUnusedStationNo.SelectedIndex = 0;
                //    }
            }
            catch { }
        }

        private void AgvState_Load(object sender, EventArgs e)
        {
            txtGoWaitGroup.Text = bufferGroup.ToString();
        }

        private void RefAgvState()
        {
            try
            {
                if (LoginRoler.U_Level > 1)
                {
                    btnClearRouteNo.Visible = true;
                }
                else
                {
                    btnClearRouteNo.Visible = false;
                }
                //cbAgvNo.SelectedIndex = dtIndex[agvNo];
                if (Common.maiDict[agvNo].State == (int)Enumerations.AgvStatus.disConnection || Common.maiDict[agvNo].State == (int)Enumerations.AgvStatus.init)
                {
                    this.lblAgvState.Text = "已掉线";
                    this.lblAgvState.BackColor = Color.Silver;
                }
                else if (Common.maiDict[agvNo].State == (int)Enumerations.AgvStatus.running)
                {
                    if (Common.maiDict[agvNo].ControlFlag)
                    {
                        this.lblAgvState.Text = "交通管制";
                        this.lblAgvState.BackColor = Color.Yellow;
                    }
                    else if (Common.maiDict[agvNo].Obstacle)
                    {
                        this.lblAgvState.Text = "障碍物异常";
                        this.lblAgvState.BackColor = Color.Yellow;
                    }
                    else
                    {
                        string status = "正在运行";
                        this.lblAgvState.Text = status;
                        this.lblAgvState.BackColor = Color.Lime;
                    }
                }
                else if (Common.maiDict[agvNo].State == (int)Enumerations.AgvStatus.fixPosition)
                {
                    string status = "正在定位";
                    this.lblAgvState.Text = status;
                    this.lblAgvState.BackColor = Color.SkyBlue;
                }
                else if (Common.maiDict[agvNo].State == (int)Enumerations.AgvStatus.stop)
                {
                    if (Common.maiDict[agvNo].Obstacle)
                    { this.lblAgvState.Text = "障碍物异常"; }
                    else if (Common.maiDict[agvNo].ControlFlag)
                    { this.lblAgvState.Text = "交通管制"; }
                    else
                        this.lblAgvState.Text = "停止";
                    this.lblAgvState.BackColor = Color.SkyBlue;
                }
                else if (Common.maiDict[agvNo].State == (int)Enumerations.AgvStatus.abnormal)
                {
                    this.lblAgvState.Text = Common.Instance.dtAgvAbnormal[Common.maiDict[agvNo].Abnormal];
                    this.lblAgvState.BackColor = Color.Red;
                }
                if (Common.maiDict[agvNo].Mode == (int)Enumerations.AgvMode.ManualOperation)
                {
                    this.lblAgvState.Text = this.lblAgvState.Text + "|手动模式";
                }
                if (Common.maiDict[agvNo].isQRCodeRight == false)
                {
                    this.lblAgvState.Text = "二维码数量不对";
                    this.lblAgvState.BackColor = Color.Red;
                }
                this.lblAgvRfid.Text = string.Format("{0}|{1}|{2}", Common.maiDict[agvNo].Rfid, Common.maiDict[agvNo].ControlRfid, Common.maiDict[agvNo].ControlRfid2);
                this.lblAgvTask.Text = string.Format("当前:{0}\r\n\r\n预定:{1}", Common.maiDict[agvNo].Task1, Common.maiDict[agvNo].Task2);
                this.lblAgvRoute.Text = Common.maiDict[agvNo].Default1.ToString();
                string dirStr = Common.maiDict[agvNo].Direction.ToString().Replace("1", "前向").Replace("2", "后向").Replace("3", "左向").Replace("4", "右向");
                if (Common.maiDict[agvNo].Direction <= 0)
                {
                    dirStr = string.Empty;
                }
                this.lblAgvSpeedAndDir.Text = string.Format("{0}min/m\r\n\r\n{1}", Common.maiDict[agvNo].Speed, dirStr);
                string volStr = string.Empty;
                if (Common.maiDict[agvNo].Voltage > 0)
                {
                    volStr = string.Format("{0}.{1}V", Common.maiDict[agvNo].Voltage / 10, Common.maiDict[agvNo].Voltage % 10);
                    try
                    {
                        int cRfid = Common.maiDict[agvNo].Rfid;
                        int chargeNo = Common.Instance.dtChargeInfo.FirstOrDefault(o => o.Value.Rfid == cRfid && o.Value.BindAgv == agvNo).Key;
                        if (chargeNo > 0)
                        {
                            if (Common.Instance.dtChargeInfo[chargeNo].BeginTime != new DateTime())
                            {
                                volStr += string.Format(" | {0}s", Common.maiDict[agvNo].Default4);
                            }
                        }
                    }
                    catch { }
                }
                this.lblAgvVoltage.Text = volStr;
                if (Common.maiDict[agvNo].VoltageStatus == Enumerations.voltageStatus.normal)
                {
                    this.lblAgvVoltage.BackColor = Color.White;
                }
                else if (Common.maiDict[agvNo].VoltageStatus == Enumerations.voltageStatus.chargVoltage)
                {
                    this.lblAgvVoltage.BackColor = Color.Red;
                }
                else
                {
                    this.lblAgvVoltage.BackColor = Color.Yellow;
                }
                try
                {
                    if (Common.maiDict[agvNo].lsRoutes.Count > 0)
                    {
                        string ss = string.Empty;
                        for (int i = 0; i < Common.maiDict[agvNo].lsRoutes.Count; i++)
                        {
                            string op = string.Empty;
                            switch (Common.maiDict[agvNo].lsRoutes[i].Value.Operate)
                            {
                                case 10:
                                    op = "左转";
                                    break;
                                case 11:
                                    op = "右转";
                                    break;
                                case 231:
                                    op = "掉头";
                                    break;
                                case 28:
                                    op = "充电";
                                    break;
                                default:
                                    op = "    ";
                                    break;
                            }
                            string dicStr = "   ";
                            switch (Common.maiDict[agvNo].lsRoutes[i].Value.Direction)
                            {
                                case 1:
                                    dicStr = "前启";
                                    break;
                                case 2:
                                    dicStr = "后启";
                                    break;
                            }
                            ss += Common.maiDict[agvNo].lsRoutes[i].Key + "->" + Common.maiDict[agvNo].lsRoutes[i].Value.EdgeRfidNum + " " + op + " " + dicStr;
                            if (i < Common.maiDict[agvNo].lsRoutes.Count - 1)
                            {
                                ss += "\r\n";
                            }
                        }
                        txtRoutes.Text = ss;
                    }
                    else
                    {
                        txtRoutes.Text = "Null";
                    }
                    if (Common.maiDict[agvNo].SupportState)
                    {
                        btnAgvSupportUp.BackColor = Color.Lime;
                        btnAgvSupportBack.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        btnAgvSupportUp.BackColor = Color.WhiteSmoke;
                        btnAgvSupportBack.BackColor = Color.Lime;
                    }
                    if (Common.maiDict[agvNo].ChargeState)
                    {
                        btnAgvChargeOpen.BackColor = Color.Lime;
                        btnAgvChargeClose.BackColor = Color.WhiteSmoke;
                    }
                    else
                    {
                        btnAgvChargeOpen.BackColor = Color.WhiteSmoke;
                        btnAgvChargeClose.BackColor = Color.Lime;
                    }
                    lblQRCode.Text = Common.maiDict[agvNo].QRCode;
                    if (Common.maiDict[agvNo].IsRobotArmOrigin)
                    {
                        this.lblIsOrigin.BackColor = Color.Lime;
                    }
                    else
                    {
                        this.lblIsOrigin.BackColor = Color.Red;
                    }
                    if (Common.maiDict[agvNo].IsRobotArmScram)
                    {
                        this.lblIsScram.BackColor = Color.Red;
                    }
                    else
                    {
                        this.lblIsScram.BackColor = Color.Lime;
                    }
                    try
                    {
                        if ((Common.maiDict[agvNo].Default3 & 1) == 0)
                        {
                            lblH1.BackColor = Color.Red;
                        }
                        else
                        {
                            lblH1.BackColor = Color.Lime;
                        }
                        if ((Common.maiDict[agvNo].Default3 >> 1 & 1) == 0)
                        {
                            lblH2.BackColor = Color.Red;
                        }
                        else
                        {
                            lblH2.BackColor = Color.Lime;
                        }
                        if ((Common.maiDict[agvNo].Default3 >> 2 & 1) == 0)
                        {
                            lblH3.BackColor = Color.Red;
                        }
                        else
                        {
                            lblH3.BackColor = Color.Lime;
                        }
                        if ((Common.maiDict[agvNo].Default3 >> 3 & 1) == 0)
                        {
                            lblH4.BackColor = Color.Red;
                        }
                        else
                        {
                            lblH4.BackColor = Color.Lime;
                        }
                        if ((Common.maiDict[agvNo].Default3 >> 4 & 1) == 0)
                        {
                            lblH5.BackColor = Color.Red;
                        }
                        else
                        {
                            lblH5.BackColor = Color.Lime;
                        }
                        if ((Common.maiDict[agvNo].Default3 >> 5 & 1) == 0)
                        {
                            lblH6.BackColor = Color.Red;
                        }
                        else
                        {
                            lblH6.BackColor = Color.Lime;
                        }
                        if ((Common.maiDict[agvNo].Default3 >> 6 & 1) == 0)
                        {
                            lblB.BackColor = Color.Red;
                        }
                        else
                        {
                            lblB.BackColor = Color.Lime;
                        }
                        if ((Common.maiDict[agvNo].Default3 >> 7 & 1) == 0)
                        {
                            lblB2.BackColor = Color.Red;
                        }
                        else
                        {
                            lblB2.BackColor = Color.Lime;
                        }
                    }
                    catch { }
                    string stateStr = "其它异常";
                    try
                    {
                        stateStr = Common.Instance.dtRobotState[Common.maiDict[agvNo].RobotState];
                    }
                    catch { }
                    if (Common.maiDict[agvNo].RobotState <= 0)
                    {
                        lblRobotState.BackColor = Color.Lime;
                        if (!Common.maiDict[agvNo].RobotMode && Common.maiDict[agvNo].SupportState)
                        {
                            stateStr = "机械臂没有开启自动模式";
                            lblRobotState.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        lblRobotState.BackColor = Color.Red;
                    }
                    lblRobotState.Text = stateStr;
                }
                catch { }
            }
            catch { }
        }

        #region AGV操作
        private void btnAgvForward_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(string.Format("是否对[AGV{0}]执行前进动作？", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.Forward);
            }
            catch { }
        }

        private void btnAgvBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(string.Format("是否对[AGV{0}]执行前进动作？", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.Back);
            }
            catch { }
        }

        private void btnAgvRest_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(string.Format("是否对[AGV{0}]执行前进动作？", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.Rest);
            }
            catch { }
        }

        private void btnAgvStop_Click(object sender, EventArgs e)
        {
            try
            {
                //if (MessageBox.Show(string.Format("是否对[AGV{0}]执行前进动作？", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.Stop);
            }
            catch { }
        }
        #endregion

        private void cbAgvNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                agvNo = Convert.ToInt32(cbAgvNo.Text);
            }
            catch { }
        }

        private void tmrRef_Tick(object sender, EventArgs e)
        {
            RefAgvState();
        }

        private void lblAgvRfid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //Label lbl = (Label)sender;
                //int agvNo = Convert.ToInt32(lbl.Tag);
                if (MessageBox.Show(string.Format("是否要清除Agv{0}的RFID卡号?", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    Common.maiDict[agvNo].Rfid = -2;
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

        private void AgvState_FormClosing(object sender, FormClosingEventArgs e)
        {
            CurrentForm = null;
        }

        private void lblAgvVoltage_DoubleClick(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            try
            {
                if (Common.maiDict[agvNo].VoltageStatus == Enumerations.voltageStatus.lowVoltage)
                {
                    if (MessageBox.Show(string.Format("是否要清除AGV{0}低电压标志", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        lock (Common.maiDict[agvNo])
                            Common.maiDict[agvNo].VoltageStatus = Enumerations.voltageStatus.normal;
                    }
                }
                else if (Common.maiDict[agvNo].VoltageStatus == Enumerations.voltageStatus.chargVoltage)
                {
                    if (MessageBox.Show(string.Format("是否要清除AGV{0}充电电压标志", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        lock (Common.maiDict[agvNo])
                            Common.maiDict[agvNo].VoltageStatus = Enumerations.voltageStatus.normal;
                    }
                }
                else if (Common.maiDict[agvNo].VoltageStatus == Enumerations.voltageStatus.normal)
                {
                    if (MessageBox.Show(string.Format("是否要设定AGV{0}充电电压标志", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        lock (Common.maiDict[agvNo])
                        {
                            Common.maiDict[agvNo].VoltageStatus = Enumerations.voltageStatus.chargVoltage;
                            Common.maiDict[agvNo].IsChargeFullTime = false;
                            try
                            {
                                int rfid = Common.maiDict[agvNo].Rfid;
                                int chargeNo = Common.Instance.dtChargeInfo.FirstOrDefault(o => o.Value.Rfid == rfid).Key;
                                if (chargeNo > 0)
                                {
                                    if (Common.Instance.dtChargeInfo[chargeNo].BeginTime != new DateTime())
                                    {
                                        Common.Instance.dtChargeInfo[chargeNo].BeginTime = DateTime.Now;
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
            catch { }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnRouteClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (Common.maiDict[agvNo].Mode == (int)Enumerations.AgvMode.AutoOperation)
                {
                    if (Common.maiDict[agvNo].Task1 == string.Empty)
                    {
                        if (Common.maiDict[agvNo].lsRoutes.Count > 0)
                        {
                            if (MessageBox.Show("是否要清除路段信息", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                            {
                                Common.maiDict[agvNo].lsRoutes.Clear();
                                Common.maiDict[agvNo].isGoAwait = true;
                            }
                        }
                        else if (Common.maiDict[agvNo].Task2 == string.Empty)
                        {
                            try
                            {
                                int group = Convert.ToInt32(txtGoWaitGroup.Text);
                                bool dir = rbtnSouth.Checked;  //true为南面
                                if (Common.Instance.dtStationInformation.Any(o => o.Value.StationType == (int)StationInformation.EStationType.Wait && o.Value.Group == group))
                                {
                                    if (MessageBox.Show("是否要回待命点", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                                    {
                                        CreatTask.CreateGoWaitTaskFuction(DateTime.Now.ToString("MMddHHmmfff"), agvNo, group, dir);
                                        bufferGroup = group;
                                        //MA_AgvTaskInfo taskInfo = new MA_AgvTaskInfo();
                                        //taskInfo.T_Status = Enumerations.TaskStatus.Start;
                                        //taskInfo.IsUpdate = true;
                                        //taskInfo.T_Type = Enumerations.TaskType.Test_GoAwait;
                                        //taskInfo.IsTest = true;
                                        //RouteInfo re;
                                        //taskInfo.T_Load = Common.maiDict[agvNo].Rfid;
                                        //int waitNo = 1;
                                        //waitNo = Common.Instance.dtCapacityTestWait.First(o => o.Value.lsRfids.Any(p => taskInfo.T_Load >= p.X && taskInfo.T_Load <= p.Y)).Key;
                                        //if (waitNo != 2) waitNo = 1;
                                        //re = new RouteInfo(RouteType.GoWait, Common.Instance.dtCapacityTestWait[waitNo].Rfid, 0, string.Format("前往分容测试待机点{0}", waitNo));
                                        ////taskInfo.T_Load = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == 1 && o.Value.StationMatchValue == taskRelease.PlaceSource[0].Trim()).Value.StationNo;
                                        //taskInfo.T_Process.Add(re);
                                        //taskInfo.ProcessIndex = 0;
                                        //taskInfo.T_CreateTime = DateTime.Now;
                                        //taskInfo.T_Level = 0;
                                        //taskInfo.T_AgvNo = agvNo;
                                        //taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff");
                                        //taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                                        //Common.maiDict[agvNo].Task1 = taskInfo.T_Id;
                                        //Common.taskCapacityTestDt[taskInfo.T_Id] = taskInfo;
                                    }
                                }
                                else { MessageBox.Show("通道号不存在"); }
                            }
                            catch
                            {
                                MessageBox.Show("通道号不存在");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Agv{0}已绑定任务，不可清除路段信息,但已设置成回待命点！！！", agvNo));
                        Common.maiDict[agvNo].isGoAwait = true;
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("Agv{0}没有设置成自动模式！！！", agvNo));
                }
            }
            catch { }
        }

        private void btnClearRouteNo_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(string.Format("是否要清除Agv{0}的路段编号", agvNo), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.StationClear);
                }
            }
            catch { }
        }

        private void btnAgvLeft_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                if (MessageBox.Show(string.Format("是否要对 Agv{0} 执行 [{1}] 操作?", agvNo, btn.Text), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.LeftRotate);
            }
            catch { }
        }

        private void btnAgvRight_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                if (MessageBox.Show(string.Format("是否要对 Agv{0} 执行 [{1}] 操作?", agvNo, btn.Text), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.RightRotate);
            }
            catch { }
        }

        private void btnAgvLeftTranslate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                if (MessageBox.Show(string.Format("是否要对 Agv{0} 执行 [{1}] 操作?", agvNo, btn.Text), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.LeftTranslate);
            }
            catch { }
        }

        private void btnAgvRightTranslate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                if (MessageBox.Show(string.Format("是否要对 Agv{0} 执行 [{1}] 操作?", agvNo, btn.Text), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.RightTranslate);
            }
            catch { }
        }

        private void btnAgvChargeOpen_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                if (MessageBox.Show(string.Format("是否要对 Agv{0} 执行 [{1}] 操作?", agvNo, btn.Text), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.ChargeOpen);
            }
            catch { }
        }

        private void btnAgvChargeClose_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                if (MessageBox.Show(string.Format("是否要对 Agv{0} 执行 [{1}] 操作?", agvNo, btn.Text), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.ChargeClose);
            }
            catch { }
        }

        private void btnAgvSupportUp_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                if (MessageBox.Show(string.Format("是否要对 Agv{0} 执行 [{1}] 操作?", agvNo, btn.Text), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.SupportUp);
            }
            catch { }
        }

        private void btnAgvSupportBack_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                if (MessageBox.Show(string.Format("是否要对 Agv{0} 执行 [{1}] 操作?", agvNo, btn.Text), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.SupportBack);
            }
            catch { }
        }

        private void btnAgvObstacle_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                if (MessageBox.Show(string.Format("是否要对 Agv{0} 执行 [{1}] 操作?", agvNo, btn.Text), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.ObstacleClose, new int[] { 0x01 });
            }
            catch { }
        }

        private void btnAgvOperateComplete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            try
            {
                int number = Convert.ToInt32(btnAgvObstacleNumber.Text);
                if (number > 1 && number <= 5)
                    if (MessageBox.Show(string.Format("是否要对 Agv{0} 执行 [{1}] 操作，障碍编号为{2}?", agvNo, btn.Text, number), "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.ObstacleClose, new int[] { number });
            }
            catch { }
        }

        private void lblAgvVoltage_Click(object sender, EventArgs e)
        {

        }

        private void lblAgvState_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (LoginRoler.U_Level > 1)
                {
                    if (Common.maiDict[agvNo].Mode == (int)Enumerations.AgvMode.AutoOperation && Common.maiDict[agvNo].State != (int)Enumerations.AgvStatus.disConnection)
                    {
                        if (MessageBox.Show("是否将自动模式切换为手动模式？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        {
                            BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.ManualMode);
                        }
                    }
                    else if (Common.maiDict[agvNo].Mode == (int)Enumerations.AgvMode.ManualOperation && Common.maiDict[agvNo].State != (int)Enumerations.AgvStatus.disConnection)
                    {
                        if (MessageBox.Show("是否将手动模式切换为自动模式？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                        {
                            BA_AgvCommunicationThread.AgvCommuDt[agvNo].AgvOperate(Enumerations.AgvOperate.AutoMode);
                        }
                    }
                }
            }
            catch { }
        }

        private void btnAgvObstacleNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAgvTask_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lblAgvTask_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Label lbl = (Label)sender;
                if (MessageBox.Show("是否要删除" + agvNo + "的任务", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                {
                    string strTask = string.Empty;
                    if (Common.maiDict[agvNo].Task1 != string.Empty)
                    {
                        strTask = Common.maiDict[agvNo].Task1;
                        Common.maiDict[agvNo].Task1 = string.Empty;
                        if (Common.maiDict[agvNo].IsAgvTest == false)
                        {
                            while (Common.maiDict[agvNo].lsRoutes.Count > 0)
                                Common.maiDict[agvNo].lsRoutes.Clear();
                        }
                    }
                    else if (Common.maiDict[agvNo].Task2 != string.Empty)
                    {
                        strTask = Common.maiDict[agvNo].Task2;
                        Common.maiDict[agvNo].Task2 = string.Empty;
                    }
                    try
                    {
                        if (strTask != string.Empty)
                        {
                            int type = (int)Common.maiDict[agvNo].Type;
                            if (Common.taskDt[type][strTask].IsTest == true)
                            {
                                while (Common.taskDt[type].ContainsKey(strTask))
                                    Common.taskDt[type].Remove(strTask);
                            }
                            else
                            {
                                Common.taskDt[type][strTask].taskOperate = (int)ETaskOperate.delete;
                                Common.taskDt[type][strTask].T_State = Enumerations.TaskStatus.Error;
                            }
                        }
                    }
                    catch { }
                }
            }
        }

        private void lblAgvTask_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                try
                {
                    string strTask = Common.maiDict[agvNo].Task1;
                    Enumerations.TaskType type = Common.taskDt[(int)Enumerations.agvType.type_1][strTask].T_Type;
                    //if (type == Enumerations.TaskType.Test_NullCompartmentRequest || type == Enumerations.TaskType.Test_FullCommparmentRequest || type == Enumerations.TaskType.Test_FullCommparmentRefueling)
                    //{
                    //    ManualQRCode manualQRCode = new ManualQRCode(agvNo);
                    //    try
                    //    {
                    //        manualQRCode.ShowDialog();
                    //    }
                    //    finally
                    //    {
                    //        manualQRCode.Dispose();
                    //    }
                    //}
                }
                catch { }
            }
        }

        private void btnLeaveUnusedStation_Click(object sender, EventArgs e)
        {
            try
            {
                //if (cbLeaveUnusedStationNo.Items.Count > 0)
                //{
                //    if (Common.maiDict[agvNo].Mode == (int)Enumerations.AgvMode.AutoOperation)
                //    {
                //        if (Common.maiDict[agvNo].Task1 == string.Empty && Common.maiDict[agvNo].Task2 == string.Empty)
                //        {
                //            int group = Convert.ToInt32(cbLeaveUnusedStationNo.Text);
                //            if (Common.Instance.dtStationInformation.Any(o => o.Value.StationType == (int)StationInformation.EStationType.TestCapcityLeaveUnused && o.Value.Group == group))
                //            {
                //                if (MessageBox.Show("是否要回闲置点", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                //                {
                //                    MA_AgvTaskInfo taskInfo = new MA_AgvTaskInfo();
                //                    taskInfo.T_State = Enumerations.TaskStatus.Start;
                //                    taskInfo.IsUpdate = true;
                //                    taskInfo.T_Type = Enumerations.TaskType.Test_LeaveUnused;
                //                    taskInfo.IsTest = true;
                //                    RouteInfo re;
                //                    taskInfo.T_Load = Common.maiDict[agvNo].Rfid;
                //                    StationInformation stationInfo = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == (int)StationInformation.EStationType.TestCapcityLeaveUnused && o.Value.Group == group).Value;
                //                    re = new RouteInfo(RouteType.TestCapcityLeaveUnused, stationInfo.StationRfid, 0, string.Format("前往分容闲置点{0}", group));
                //                    taskInfo.T_Process.Add(re);
                //                    taskInfo.ProcessIndex = 0;
                //                    taskInfo.T_CreateTime = DateTime.Now;
                //                    taskInfo.T_Level = 0;
                //                    taskInfo.T_AgvNo = agvNo;
                //                    taskInfo.T_Id = DateTime.Now.ToString("MMddHHmmfff_LeaveUnused");
                //                    taskInfo.T_TaskName = Common.Instance.dtTaskTypeName[taskInfo.T_Type];
                //                    Common.maiDict[agvNo].Task1 = taskInfo.T_Id;
                //                    Common.taskCapacityTestDt[taskInfo.T_Id] = taskInfo;
                //                }
                //            }
                //            else { MessageBox.Show("闲置点不存在"); }
                //        }
                //        else
                //        {
                //            MessageBox.Show(string.Format("Agv{0}为存在任务，不可添加任务", agvNo));
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show(string.Format("Agv{0}为手动模式，不可添加任务", agvNo));
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("无可用闲置点，不能添加回闲置点任务");
                //}
            }
            catch { }
        }

        private void cbLeaveUnusedStationNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
