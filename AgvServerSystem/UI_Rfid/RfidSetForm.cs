using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;

namespace AgvServerSystem
{
    public partial class RfidSetForm : Form
    {
        /// <summary>
        /// 当前是否全部RFID显式
        /// </summary>
        private bool isAllShow = false;
        /// <summary>
        /// 提示框
        /// </summary>        
        private ToolTip toolTip = new ToolTip();
        /// <summary>
        /// 每个textBox的标识
        /// </summary>
        private string nameString = string.Empty;
        /// <summary>
        /// 方向类型 0:水平，1:垂直
        /// </summary>
        public static string dirType = string.Empty;
        public static int lastGroup = 1;
        private Point rfidPoint = new Point();
        private Panel panMap;
        private int mapNo = 0;
        private List<RfidInfo> lsRfidInfo = new List<RfidInfo>();
        private Dictionary<int, Label> rfidLabelDt = new Dictionary<int, Label>();


        //存储上一次的设定路段参数，方便更改
        public static RfidInfo BufferRfidInfo = new RfidInfo(1, 1, 1, 0, 1, 1, 3, 0, 0, 0, 0, 1, 2, RfidType.type1);
        /// <summary>
        /// 上一次显示RFID
        /// </summary>
        public static int lastShowRfid = -1;

        public RfidSetForm(Point rfid, Panel _panMap, Dictionary<int, Label> _rfidLabelDt, bool _isAllShow)
        {
            try
            {
                InitializeComponent();
                //this.rfidPoint = rfid;
                this.mapNo = (int)_panMap.Tag;
                this.rfidPoint.X = Convert.ToInt32(rfid.X / Common.sizeMapImage[this.mapNo].widthScale);
                this.rfidPoint.Y = Convert.ToInt32(rfid.Y / Common.sizeMapImage[this.mapNo].heightScale);
                this.panMap = _panMap;
                this.rfidLabelDt = _rfidLabelDt;
                this.isAllShow = _isAllShow;
                switch (RfidInfo.pRfidType)
                {
                    case RfidType.type1:
                        rbtnRouteType1.Checked = true;
                        break;
                    case RfidType.type2:
                        rbtnRouteType2.Checked = true;
                        break;
                    case RfidType.type3:
                        rbtnRouteType3.Checked = true;
                        break;
                }
            }
            catch { }
        }

        #region 键入限制
        private void txtRfidX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void txtRfidY_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txtRfidTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void txtRfidBottom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void txtRfidLeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void txtRfidRight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void txtEdgeLengthTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void txtEdgeLengthBottom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void txtEdgeLengthLeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        private void txtEdgeLengthRight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字
                {
                    e.Handled = true;
                }
            }
        }
        #endregion //键入限制

        private void RfidSetForm_Load(object sender, EventArgs e)
        {
            txtRfidX.Text = rfidPoint.X.ToString();
            txtRfidY.Text = rfidPoint.Y.ToString();
            txtRfidNo.Text = Common.rfidAddNo.ToString();
            this.txtRouteNo.Text = BufferRfidInfo.EdgeNum.ToString();
            this.txtRouteRfid.Text = BufferRfidInfo.EdgeRfidNum.ToString();
            this.txtRouteLength.Text = BufferRfidInfo.EdgeLength.ToString();
            this.txtRouteCrossroad.Text = BufferRfidInfo.EdgeCrossroad.ToString();
            this.txtRouteDirection.Text = BufferRfidInfo.Direction.ToString();
            this.txtRouteStopType.Text = BufferRfidInfo.StopType.ToString();
            this.txtRouteStopTime.Text = BufferRfidInfo.StopTime.ToString();
            this.txtRouteobstacleType.Text = BufferRfidInfo.ObstacleType.ToString();
            this.txtRouteSpeed.Text = BufferRfidInfo.Speed.ToString();
            this.txtRouteOperate.Text = BufferRfidInfo.Operate.ToString();
            this.txtRouteDefault1.Text = BufferRfidInfo.Default1.ToString();
            this.txtRouteDefault2.Text = BufferRfidInfo.Default2.ToString();
            this.txtRouteLineStopType.Text = BufferRfidInfo.LineStopType.ToString();
            JudgeLayout();
            txtRfidGroup.Text = lastGroup.ToString();
        }

        private void btnRfidSet_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(txtRfidX.Text);
                int y = Convert.ToInt32(txtRfidY.Text);
                int rfid = Convert.ToInt32(txtRfidNo.Text);
                string layout = dirType;
                int group = Convert.ToInt32(txtRfidGroup.Text);
                if (Common.rfidDt.ContainsKey(rfid))
                {
                    MessageBox.Show("The Rfid already exists！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    dirType = layout;
                    MA_RfidPoint map = new MA_RfidPoint(rfid, x, y, mapNo, layout, group, lsRfidInfo);
                    Dictionary<int, MA_RfidPoint> _rfid = new Dictionary<int, MA_RfidPoint>();
                    _rfid[rfid] = map;
                    ControlsOperate.AddLabelRfidPoint(_rfid, this.panMap, this.rfidLabelDt);
                    Common.rfidAddNo = rfid + 1;
                    //this.panMap = AddControls.AddLabelRfidPoint(_rfid, this.panMap);
                    Common.rfidDt[rfid] = map;
                    lastShowRfid = rfid;
                    lastGroup = group;
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Parameters format error", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRfidDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Whether to delete the rfid?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int rfid = Convert.ToInt32(txtRfidNo.Text);
                    if (Common.rfidDt.ContainsKey(rfid))
                    {
                        Dictionary<int, MA_RfidPoint> _rfid = new Dictionary<int, MA_RfidPoint>();
                        _rfid[rfid] = Common.rfidDt[rfid];
                        Dictionary<int, Label> dl = new Dictionary<int, Label>();
                        dl[rfid] = this.rfidLabelDt[rfid];
                        ControlsOperate.RemoveRfidPoint(_rfid, this.panMap, dl);
                        while (Common.rfidDt.ContainsKey(rfid))
                            Common.rfidDt.Remove(rfid);
                    }
                    else
                    {
                        MessageBox.Show("This rfid does not exist！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Parameters format error", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRfidClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Whether to delete all rfids?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ControlsOperate.RemoveRfidPoint(Common.rfidDt, this.panMap, this.rfidLabelDt);
                Common.rfidDt.Clear();
            }
            this.Close();
        }

        private void btnRfidQuery_Click(object sender, EventArgs e)
        {
            try
            {
                int rfid = Convert.ToInt32(txtRfidNo.Text);
                if (Common.rfidDt.ContainsKey(rfid))
                {
                    txtRfidX.Text = Common.rfidDt[rfid].RfidX.ToString();
                    txtRfidY.Text = Common.rfidDt[rfid].RfidY.ToString();
                    txtRfidGroup.Text = Common.rfidDt[rfid].Group.ToString();
                    dirType = Common.rfidDt[rfid].RfidLayout;
                    JudgeLayout();
                    lsRfidInfo = Common.rfidDt[rfid].RfidInfos.ToList();
                    txtRouteNo.Text = (lsRfidInfo.Count + 1).ToString();
                    ObtaionRfidInfo();
                    this.rfidLabelDt[rfid].BackColor = Color.Red;
                    if (isAllShow == false)
                    {
                        this.rfidLabelDt[rfid].Parent = panMap;
                        this.rfidLabelDt[rfid].Visible = true;
                    }
                    int w = this.rfidLabelDt[rfid].Left;
                    int h = this.rfidLabelDt[rfid].Top;
                    try
                    {
                        if (lastShowRfid > 0 && lastShowRfid != rfid)
                        {
                            rfidLabelDt[lastShowRfid].BackColor = Color.Yellow;
                            if (isAllShow == false)
                            {
                                rfidLabelDt[lastShowRfid].Parent = null;
                                rfidLabelDt[lastShowRfid].Visible = false;
                            }
                        }
                    }
                    catch { }
                    lastShowRfid = rfid;
                    lastGroup = Common.rfidDt[rfid].Group;
                }
                else
                {
                    MessageBox.Show("This rfid does not exist.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            {
                MessageBox.Show("Parameters format error.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btnRfidChange_Click(object sender, EventArgs e)
        {
            try
            {
                int rfidX = Convert.ToInt32(txtRfidX.Text);
                int rfidY = Convert.ToInt32(txtRfidY.Text);
                int rfid = Convert.ToInt32(txtRfidNo.Text);
                int group = Convert.ToInt32(txtRfidGroup.Text);
                if (Common.rfidDt.ContainsKey(rfid))
                {
                    if (MessageBox.Show("Whether to modify the rfid？", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Common.rfidDt[rfid].RfidX = rfidX;
                        Common.rfidDt[rfid].RfidY = rfidY;
                        Common.rfidDt[rfid].RfidLayout = dirType;
                        Common.rfidDt[rfid].RfidInfos = lsRfidInfo;
                        Common.rfidDt[rfid].Group = group;
                        ControlsOperate.ChangeRfidPoint(Common.rfidDt[rfid], this.panMap, this.rfidLabelDt);
                        Common.rfidAddNo = rfid + 1;
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("This rfid does not exist.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            {
                MessageBox.Show("Parameters format error.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void chbLayoutVertical_CheckedChanged(object sender, EventArgs e)
        {
            dirType = "垂直";
        }
        private void JudgeLayout()
        {
            if (dirType == "水平")
                rbtnLayoutHorizontal.Checked = true;
            else if (dirType == "垂直")
                rbtnLayoutVertical.Checked = true;
            else
            {
                dirType = "水平";
                rbtnLayoutHorizontal.Checked = true;
            }
        }

        private void rbtnLayoutHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            dirType = "水平";
        }

        private void rbtnLayoutVertical_CheckedChanged(object sender, EventArgs e)
        {
            dirType = "垂直";
        }

        private void btnRouteObtain_Click(object sender, EventArgs e)
        {
            ObtaionRfidInfo();
        }

        private void btnRouteAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int _routeNo = Convert.ToInt32(txtRouteNo.Text);
                if (lsRfidInfo.Any(o => o.EdgeNum == _routeNo))
                {
                    MessageBox.Show(string.Format("The Rfid[{0}] already exists", _routeNo));
                }
                else
                {
                    int rfid = Convert.ToInt32(txtRouteRfid.Text);
                    RfidInfo _rfidInfo = new RfidInfo(_routeNo, rfid);
                    _rfidInfo.EdgeLength = Convert.ToInt32(txtRouteLength.Text);
                    _rfidInfo.EdgeCrossroad = Convert.ToInt32(txtRouteCrossroad.Text);
                    _rfidInfo.Direction = Convert.ToInt32(txtRouteDirection.Text);
                    _rfidInfo.StopType = Convert.ToInt32(txtRouteStopType.Text);
                    _rfidInfo.StopTime = Convert.ToInt32(txtRouteStopTime.Text);
                    _rfidInfo.ObstacleType = Convert.ToInt32(txtRouteobstacleType.Text);
                    _rfidInfo.Speed = Convert.ToInt32(txtRouteSpeed.Text);
                    _rfidInfo.Operate = Convert.ToInt32(txtRouteOperate.Text);
                    _rfidInfo.Default1 = Convert.ToInt32(txtRouteDefault1.Text);
                    _rfidInfo.Default2 = Convert.ToInt32(txtRouteDefault2.Text);
                    _rfidInfo.LineStopType = Convert.ToInt32(txtRouteLineStopType.Text);
                    lsRfidInfo.Add(_rfidInfo);
                    //缓存一组路段，用于下一次显示 
                    txtRouteNo.Text = (_rfidInfo.EdgeNum + 1).ToString();
                    BufferRfidInfo.EdgeNum = 1;
                    BufferRfidInfo.EdgeRfidNum = _rfidInfo.EdgeRfidNum + 1;
                    BufferRfidInfo.EdgeLength = _rfidInfo.EdgeLength;
                    BufferRfidInfo.EdgeCrossroad = _rfidInfo.EdgeCrossroad;
                    BufferRfidInfo.Direction = _rfidInfo.Direction;
                    BufferRfidInfo.StopType = _rfidInfo.StopType;
                    BufferRfidInfo.StopTime = _rfidInfo.StopTime;
                    BufferRfidInfo.ObstacleType = _rfidInfo.ObstacleType;
                    BufferRfidInfo.Speed = _rfidInfo.Speed;
                    BufferRfidInfo.Operate = _rfidInfo.Operate;
                    BufferRfidInfo.Default1 = _rfidInfo.Default1;
                    BufferRfidInfo.Default2 = _rfidInfo.Default2;
                    BufferRfidInfo.LineStopType = _rfidInfo.LineStopType;
                    ObtaionRfidInfo();
                }

            }
            catch
            {
                MessageBox.Show("Parameters format error.");
            }
        }
        /// <summary>
        /// 获取当前RFID连接RFID集合
        /// </summary>
        private void ObtaionRfidInfo()
        {
            try
            {
                dgvRfidInfo.Rows.Clear();
                if (lsRfidInfo.Count > 0)
                {
                    lsRfidInfo = lsRfidInfo.OrderBy(o => o.EdgeNum).ToList();
                    foreach (RfidInfo item in lsRfidInfo)
                    {

                        DataGridViewRow dr = new DataGridViewRow();
                        dr.CreateCells(dgvRfidInfo);
                        dr.Cells[0].Value = item.EdgeNum;
                        dr.Cells[1].Value = item.EdgeRfidNum;
                        dr.Cells[2].Value = item.EdgeLength;
                        dr.Cells[3].Value = item.EdgeCrossroad;
                        dr.Cells[4].Value = item.Direction;
                        dr.Cells[5].Value = item.ObstacleType;
                        dr.Cells[6].Value = item.Speed;
                        dr.Cells[7].Value = item.Operate;
                        dr.Cells[8].Value = item.Default2;
                        dr.Cells[9].Value = item.StopType;
                        dr.Cells[10].Value = item.StopTime;
                        dr.Cells[11].Value = item.Default1;
                        dr.Cells[12].Value = item.LineStopType;
                        dgvRfidInfo.Rows.Add(dr);
                    }
                }
            }
            catch { }
        }

        private void dgvRfidInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch { }
        }

        private void dgvRfidInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                int rows = e.RowIndex;
                int col = e.ColumnIndex;
                int routeNo = Convert.ToInt32(dgv.Rows[rows].Cells["rNo"].Value.ToString());
                if (col == 13)//修改
                {
                    if (MessageBox.Show(string.Format("Whether to modify the route[{0}]?", routeNo), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            int index = lsRfidInfo.FindIndex(o => o.EdgeNum == routeNo);
                            int rfid = Convert.ToInt32(dgv.Rows[rows].Cells["rRfid"].Value.ToString());
                            RfidInfo rfidInfo = new RfidInfo(routeNo, rfid);
                            rfidInfo.EdgeLength = Convert.ToInt32(dgv.Rows[rows].Cells["rLength"].Value);
                            rfidInfo.EdgeCrossroad = Convert.ToInt32(dgv.Rows[rows].Cells["rCrossroad"].Value);
                            rfidInfo.Direction = Convert.ToInt32(dgv.Rows[rows].Cells["rDirection"].Value);
                            rfidInfo.StopType = Convert.ToInt32(dgv.Rows[rows].Cells["rStopType"].Value);
                            rfidInfo.StopTime = Convert.ToInt32(dgv.Rows[rows].Cells["rStop"].Value);
                            rfidInfo.ObstacleType = Convert.ToInt32(dgv.Rows[rows].Cells["rObstacle"].Value);
                            rfidInfo.Speed = Convert.ToInt32(dgv.Rows[rows].Cells["rSpeed"].Value);
                            rfidInfo.Operate = Convert.ToInt32(dgv.Rows[rows].Cells["rOperate"].Value);
                            rfidInfo.Default1 = Convert.ToInt32(dgv.Rows[rows].Cells["rDefault1"].Value);
                            rfidInfo.Default2 = Convert.ToInt32(dgv.Rows[rows].Cells["rDefault2"].Value);
                            rfidInfo.LineStopType = Convert.ToInt32(dgv.Rows[rows].Cells["rLineStopType"].Value);
                            lsRfidInfo[index] = rfidInfo;

                        }
                        catch
                        {
                            MessageBox.Show("Parameters format error.");
                        }
                    }
                }
                else if (col == 14)  //删除
                {
                    if (MessageBox.Show(string.Format("Whether to delete the route[{0}]?", routeNo), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            while (lsRfidInfo.Any(o => o.EdgeNum == routeNo))
                            {
                                lsRfidInfo.RemoveAll(o => o.EdgeNum == routeNo);
                            }
                            ObtaionRfidInfo();
                        }
                        catch { }
                    }
                }
            }
            catch { }
        }

        private void DisposeTooltip(object sender)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                string name = txt.Name;
                if (nameString == name) nameString = string.Empty;
            }
            catch { }
        }

        private void SetToolTip(object sender, string contents)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                string name = txt.Name;
                if (nameString != name)
                {
                    toolTip.Dispose();
                    toolTip = new ToolTip();
                    toolTip.SetToolTip(txt, contents);
                    nameString = name;
                }
            }
            catch { }
        }

        private void txtRouteRfid_MouseLeave(object sender, EventArgs e)
        {
            DisposeTooltip(sender);
        }

        private void txtRouteRfid_MouseMove(object sender, MouseEventArgs e)
        {
            SetToolTip(sender, "Next route id，numeric type.");
        }

        private void txtRouteLength_MouseLeave(object sender, EventArgs e)
        {
            DisposeTooltip(sender);
        }

        private void txtRouteLength_MouseMove(object sender, MouseEventArgs e)
        {
            SetToolTip(sender, "Length，Default is 1，numeric type.");
        }

        private void txtRouteCrossroad_MouseLeave(object sender, EventArgs e)
        {
            DisposeTooltip(sender);
        }

        private void txtRouteCrossroad_MouseMove(object sender, MouseEventArgs e)
        {
            SetToolTip(sender, "Crossroad：default is 0");
        }

        private void txtRouteDirection_MouseLeave(object sender, EventArgs e)
        {
            DisposeTooltip(sender);
        }

        private void txtRouteDirection_MouseMove(object sender, MouseEventArgs e)
        {
            SetToolTip(sender, "1：forward，2：backward\r\n3：，4：syntropy\r\n5：left，6：right");
        }

        private void txtRouteStopType_MouseLeave(object sender, EventArgs e)
        {
            DisposeTooltip(sender);
        }

        private void txtRouteStopType_MouseMove(object sender, MouseEventArgs e)
        {
            SetToolTip(sender, "1：time，2：magnetic，3：length");
        }

        private void txtRouteStopTime_MouseLeave(object sender, EventArgs e)
        {
            DisposeTooltip(sender);
        }

        private void txtRouteStopTime_MouseMove(object sender, MouseEventArgs e)
        {
            SetToolTip(sender, "1=100ms,and so on");
        }

        private void txtRouteDefault1_MouseLeave(object sender, EventArgs e)
        {
            DisposeTooltip(sender);
        }

        private void txtRouteDefault1_MouseMove(object sender, MouseEventArgs e)
        {
            SetToolTip(sender, "1=100ms,and so on");
        }

        private void txtRouteobstacleType_MouseLeave(object sender, EventArgs e)
        {
            DisposeTooltip(sender);
        }

        private void txtRouteobstacleType_MouseMove(object sender, MouseEventArgs e)
        {
            SetToolTip(sender, "1：");
        }

        private void txtRouteSpeed_MouseLeave(object sender, EventArgs e)
        {
            DisposeTooltip(sender);
        }

        private void txtRouteSpeed_MouseMove(object sender, MouseEventArgs e)
        {
            SetToolTip(sender, "1-5:decrease progressively speed\r\n6：obstacle speed，7crossroad speed,11:stop speed");
        }

        private void txtRouteOperate_MouseLeave(object sender, EventArgs e)
        {
            DisposeTooltip(sender);
        }

        private void txtRouteOperate_MouseMove(object sender, MouseEventArgs e)
        {
            SetToolTip(sender, "Default");
        }

        private void txtRouteDefault2_MouseLeave(object sender, EventArgs e)
        {
            DisposeTooltip(sender);
        }

        private void txtRouteDefault2_MouseMove(object sender, MouseEventArgs e)
        {
            SetToolTip(sender, "1：Forward to start，2：backward to start");
        }

        private void RfidSetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (lastShowRfid > 0)
                {
                    this.rfidLabelDt[lastShowRfid].BackColor = Color.Yellow;
                    if (isAllShow == false)
                    {
                        this.rfidLabelDt[lastShowRfid].Parent = null;
                        this.rfidLabelDt[lastShowRfid].Visible = false;
                    }
                    lastShowRfid = -1;
                }
            }
            catch { }
        }

        private void txtRouteSpeed_TextChanged(object sender, EventArgs e)
        {

        }

        #region 路段类型
        private void rbtnRouteType1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnRouteType1.Checked)
                {
                    RfidInfo.pRfidType = RfidType.type1;
                    RfidType1Method();
                }
            }
            catch { }
        }

        private void rbtnRouteType2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnRouteType2.Checked)
                {
                    RfidInfo.pRfidType = RfidType.type2;
                    RfidType2Method();
                }
            }
            catch { }
        }

        private void rbtnRouteType3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbtnRouteType3.Checked)
                {
                    RfidInfo.pRfidType = RfidType.type3;
                    RfidType3Method();
                }
            }
            catch { }
        }
        private void RfidType1Method()
        {
            try
            {
                lblRouteLength.Text = "length";

                lblRouteCrossroad.Text = "Crossroad";
                lblRouteDirection.Text = "Dircetion";
                lblRouteobstacleType.Text = "Obstacle";
                lblRouteSpeed.Text = "Speed";
                lblRouteOperate.Text = "Action";
                lblRouteDefault2.Text = "ReDirection";
                lblRouteDefault1.Text = "Rest Time";
                lblRouteStopType.Text = "Stop Type";
                lblRouteStopTime.Text = "Stop Time";
                lblRouteLineStopType.Text = "Lineoff Type";


                rCrossroad.HeaderText = "Crossroad";
                rDirection.HeaderText = "Direction";
                rObstacle.HeaderText = "Obstacle";
                rSpeed.HeaderText = "Speed";
                rOperate.HeaderText = "Action";
                rDefault2.HeaderText = "ReDirection";
                rDefault1.HeaderText = "RestTime";
                rStopType.HeaderText = "StopType";
                rStop.HeaderText = "StopTime";
                rLineStopType.HeaderText = "LineoffTime";
            }
            catch { }
        }
        private void RfidType2Method()
        {
            try
            {
                lblRouteLength.Text = "Length";
                lblRouteCrossroad.Text = "Run Angle";
                lblRouteDirection.Text = "Direction";
                lblRouteobstacleType.Text = "Mag Spacing";
                lblRouteSpeed.Text = "Speed";
                lblRouteOperate.Text = "Action";
                lblRouteDefault2.Text = "Fixed Length";
                lblRouteDefault1.Text = "Default";
                lblRouteStopType.Text = "Default";
                lblRouteStopTime.Text = "Default";
                lblRouteLineStopType.Text = "Default";

                rCrossroad.HeaderText = "Run Angle";
                rDirection.HeaderText = "Direction";
                rObstacle.HeaderText = "Mag Spacing";
                rSpeed.HeaderText = "Speed";
                rOperate.HeaderText = "Action";
                rDefault2.HeaderText = "Fixed Length";
                rDefault1.HeaderText = "Defaule";
                rStopType.HeaderText = "Default";
                rStop.HeaderText = "Default";
                rLineStopType.HeaderText = "Default";
            }
            catch { }
        }
        private void RfidType3Method()
        {
            try
            {
                lblRouteLength.Text = "length";

                lblRouteCrossroad.Text = "Crossroad";
                lblRouteDirection.Text = "Dircetion";
                lblRouteobstacleType.Text = "Obstacle";
                lblRouteSpeed.Text = "Speed";
                lblRouteOperate.Text = "Action";
                lblRouteDefault2.Text = "ReDirection";
                lblRouteDefault1.Text = "Rest Time";
                lblRouteStopType.Text = "Stop Type";
                lblRouteStopTime.Text = "Stop Time";
                lblRouteLineStopType.Text = "Lineoff Type";


                rCrossroad.HeaderText = "Crossroad";
                rDirection.HeaderText = "Direction";
                rObstacle.HeaderText = "Obstacle";
                rSpeed.HeaderText = "Speed";
                rOperate.HeaderText = "Action";
                rDefault2.HeaderText = "ReDirection";
                rDefault1.HeaderText = "RestTime";
                rStopType.HeaderText = "StopType";
                rStop.HeaderText = "StopTime";
                rLineStopType.HeaderText = "LineoffTime";
            }
            catch { }
        }
        #endregion

        private void lblRouteobstacleType_Click(object sender, EventArgs e)
        {

        }

        private void txtRouteobstacleType_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblRouteSpeed_Click(object sender, EventArgs e)
        {

        }


    }
}
