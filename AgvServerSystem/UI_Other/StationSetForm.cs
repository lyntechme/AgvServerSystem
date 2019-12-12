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

namespace AgvServerSystem
{
    public partial class StationSetForm : Form
    {
        /// <summary>
        /// 预估站点编号
        /// </summary>
        public static int stationBuffer = 0;
        /// <summary>
        /// 预估名称
        /// </summary>
        public static string nameBuffer = string.Empty;

        #region properties
        /// <summary>
        /// 站点Label位置
        /// </summary>
        private Point location = new Point();
        /// <summary>
        /// 站点父控件
        /// </summary>
        private Panel panMap;
        /// <summary>
        /// 站点Labe集合
        /// </summary>
        private Dictionary<int, Label> dtStationLabel = new Dictionary<int, Label>();
        /// <summary>
        /// 电子地图编号
        /// </summary>
        private int mapNo;
        #endregion

        #region Controls
        Panel panBtn = new Panel();
        Button btnStationDelete = new Button();
        Button btnStationAdd = new Button();
        Button btnStationQuery = new Button();
        Button btnStationModify = new Button();
        #endregion

        /// <summary>
        /// 呼叫站点设定
        /// </summary>
        /// <param name="_location">站点Label位置</param>
        /// <param name="_panMap">站点父控件</param>
        /// <param name="_stationLabel">站点Label集合</param>
        public StationSetForm(Point _location, Panel _panMap, int mapNo, Dictionary<int, Label> _stationLabel)
        {
            InitializeComponent();
            #region 布局
            this.Controls.Add(panBtn);
            panBtn.Height = 60;
            panBtn.Dock = DockStyle.Bottom;
            btnStationDelete.Text = "Delete";
            btnStationDelete.Click += btnStationDelete_Click;
            btnStationQuery.Text = "Query";
            btnStationQuery.Click += btnStationQuery_Click;
            btnStationAdd.Text = "Add";
            btnStationAdd.Click += btnStationAdd_Click;
            btnStationModify.Text = "Modify";
            btnStationModify.Click += btnStationModify_Click;
            btnStationDelete.Dock = DockStyle.Left;
            btnStationQuery.Dock = DockStyle.Right;
            btnStationModify.Dock = DockStyle.Left;
            btnStationAdd.Dock = DockStyle.Fill;
            panBtn.Controls.Add(btnStationAdd);
            panBtn.Controls.Add(btnStationDelete);
            panBtn.Controls.Add(btnStationQuery);
            panBtn.Controls.Add(btnStationModify);
            #endregion

            this.location.X = Convert.ToInt32(_location.X / Common.sizeMapImage[mapNo].widthScale);
            this.location.Y = Convert.ToInt32(_location.Y / Common.sizeMapImage[mapNo].heightScale);
            this.Left = this.location.X;
            this.Top = this.location.Y;
            this.panMap = _panMap;
            this.dtStationLabel = _stationLabel;
            this.mapNo = mapNo;
            List<string> typeNameLs = new List<string>();  //站点类型集合
            try
            {
                var b = (from s in Common.Instance.dtStationInformation select s.Value.TypeName).Distinct().ToArray();
                cbbStationType.DisplayMember = "value";
                cbbStationType.ValueMember = "key";
                var c = (from s in Common.Instance.dtStationInformation select s.Value.StationType).Distinct().ToArray();
                List<KeyValuePair<int, string>> ls = new List<KeyValuePair<int, string>>();
                foreach (int item in c)
                {
                    string typeName = Common.Instance.dtStationInformation.FirstOrDefault(o => o.Value.StationType == item).Value.TypeName;
                    ls.Add(new KeyValuePair<int, string>(item, typeName));
                }
                cbbStationType.DataSource = ls;
                //cbbStationType.Items.Clear();
                //cbbStationType.DataSource
                //cbbStationType.SelectedIndex = 0;
            }
            catch { }
        }
        #region 按钮事件
        void btnStationAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(cbbStationId.Text);
                int[] stationRfids = txtStationRfid.Text.Split(',').Select<string, int>(q => int.Parse(q)).ToArray();
                point location = new point(Convert.ToInt32(txtLeft.Text), Convert.ToInt32(txtTop.Text));
                point size = new point(Convert.ToInt32(txtStationWidth.Text), Convert.ToInt32(txtStationHight.Text));
                string name = txtStationName.Text;

                if (Common.dtStationInfo.ContainsKey(id))
                {
                    MessageBox.Show("The station already exists.");
                }
                else
                {
                    StationConnectInfo scf = new StationConnectInfo();
                    StationLayoutInfo slf = new StationLayoutInfo(location, size, id, stationRfids);
                    bool enable = bool.Parse(txtStationLabelEnbale.Text);
                    StationInfo stationInfo = new StationInfo(id, stationRfids, name, int.Parse(cbbStationType.SelectedValue.ToString()), enable, scf, slf, this.mapNo);
                    Dictionary<int, StationInfo> dt = new Dictionary<int, StationInfo>();
                    dt[id] = stationInfo;
                    ControlsOperate.AddLabelStationPoint(dt, panMap, this.dtStationLabel);
                    Common.dtStationInfo[id] = stationInfo;
                    Common.sizeStationDefault = size;
                    this.Close();
                }

            }
            catch
            {
                MessageBox.Show("Format error.");
            }
        }

        void btnStationModify_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Whether to modify the station?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int stationId = int.Parse(cbbStationId.Text);
                    if (Common.dtStationInfo.ContainsKey(stationId))
                    {
                        string _name = txtStationName.Text.Trim();
                        int _left = int.Parse(txtLeft.Text);
                        int _top = int.Parse(txtTop.Text);
                        int _width = int.Parse(txtStationWidth.Text);
                        int _hight = int.Parse(txtStationHight.Text);
                        Common.dtStationInfo[stationId].Name = _name;
                        Common.dtStationInfo[stationId].LayoutInfo.Location.X = _left;
                        Common.dtStationInfo[stationId].LayoutInfo.Location.Y = _top;
                        Common.dtStationInfo[stationId].LayoutInfo.Size.X = _width;
                        Common.dtStationInfo[stationId].LayoutInfo.Size.Y = _hight;
                        MessageBox.Show("Modified success.");
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Parameter format error, please reenter.");
                }
            }
        }
        void btnStationQuery_Click(object sender, EventArgs e)
        {
            try
            {
                int stationId = int.Parse(cbbStationId.Text);
                if (Common.dtStationInfo.ContainsKey(stationId))
                {
                    //txtStationIp.Text = Common.dtStationLabelInfo[stationId].StationIp;
                    txtStationRfid.Text = string.Join(",", Common.dtStationInfo[stationId].LayoutInfo.RfidLs.ToArray());
                    txtStationName.Text = Common.dtStationInfo[stationId].Name;
                    txtLeft.Text = Common.dtStationInfo[stationId].LayoutInfo.Location.X.ToString();
                    txtTop.Text = Common.dtStationInfo[stationId].LayoutInfo.Location.Y.ToString();
                    txtStationWidth.Text = Common.dtStationInfo[stationId].LayoutInfo.Size.X.ToString();
                    txtStationHight.Text = Common.dtStationInfo[stationId].LayoutInfo.Size.Y.ToString();
                    try
                    {
                        cbbStationType.SelectedValue = (int)Common.dtStationInfo[stationId].Type;
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("The station does not exist", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            { }
        }

        void btnStationDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Whether to delete the station?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int stationId = int.Parse(cbbStationId.Text);
                    if (Common.dtStationInfo.ContainsKey(stationId))
                    {
                        Dictionary<int, StationInfo> dtStation = new Dictionary<int, StationInfo>();
                        dtStation[stationId] = Common.dtStationInfo[stationId];
                        try
                        {
                            this.dtStationLabel[stationId].Parent = null;
                        }
                        catch { }
                        try
                        {
                            //panMap.Controls.Remove(dtStationLabel[stationId]); 
                            panMap.Controls.Remove(dtStationLabel[stationId]);
                        }
                        catch { }
                        try
                        {
                            this.dtStationLabel.Remove(stationId);
                        }
                        catch { }
                        try
                        {
                            Common.dtStationInfo.Remove(stationId);
                        }
                        catch { }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The station does not exist！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch { }
            }
        }
        #endregion

        private void StationSetForm_Load(object sender, EventArgs e)
        {
            txtLeft.Text = this.location.X.ToString();
            txtTop.Text = this.location.Y.ToString();
            txtStationWidth.Text = Common.sizeStationDefault.X.ToString();
            txtStationHight.Text = Common.sizeStationDefault.Y.ToString();
        }

        private void splitPanStation_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitPanStation_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbStationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string typeName = cbbStationType.Text.Trim();
                var b = (from s in Common.Instance.dtStationInformation where s.Value.TypeName == typeName select s.Value.StationNo.ToString()).Distinct().ToArray();
                cbbStationId.Items.Clear();
                cbbStationId.Items.AddRange(b);
                cbbStationId.SelectedIndex = 0;
            }
            catch { }
        }

        private void cbbStationId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int stationId = int.Parse(cbbStationId.Text);
                StationInformation station = Common.Instance.dtStationInformation.First(o => o.Value.StationNo == stationId).Value;
                txtStationName.Text = station.StationName;
                txtStationRfid.Text = string.Join(",", station.StationRfidLs.ToArray());
                txtStationLabelEnbale.Text = station.StationEnable.ToString();
                if (Common.dtStationInfo.ContainsKey(stationId))
                {
                    //txtStationIp.Text = Common.dtStationLabelInfo[stationId].StationIp;
                    txtStationRfid.Text = string.Join(",", Common.dtStationInfo[stationId].LayoutInfo.RfidLs.ToArray());
                    txtStationName.Text = Common.dtStationInfo[stationId].Name;
                    txtLeft.Text = Common.dtStationInfo[stationId].LayoutInfo.Location.X.ToString();
                    txtTop.Text = Common.dtStationInfo[stationId].LayoutInfo.Location.Y.ToString();
                    txtStationWidth.Text = Common.dtStationInfo[stationId].LayoutInfo.Size.X.ToString();
                    txtStationHight.Text = Common.dtStationInfo[stationId].LayoutInfo.Size.Y.ToString();
                }
            }
            catch { }
        }
    }
    //public partial class TextPanel : Panel
    //{
    //    private Label lblText = new Label();
    //    private TextBox txtContent = new TextBox();

    //    public TextPanel()
    //    {
    //        this.Size = new Size(160, 30);
    //        lblText.Dock = DockStyle.Left;
    //        txtContent.Dock = DockStyle.Fill;
    //        lblText.Size = new Size(80, 30);
    //        this.Controls.Add(txtContent);
    //        this.Controls.Add(lblText);
    //    }
    //    /// <summary>
    //    /// 是否只读
    //    /// </summary>
    //    public bool ReadOnly
    //    {
    //        get
    //        {
    //            return txtContent.Enabled;
    //        }
    //        set
    //        {
    //            txtContent.Enabled = value;
    //        }
    //    }
    //    /// <summary>
    //    /// 标题
    //    /// </summary>
    //    public string Title
    //    {
    //        get
    //        {
    //            return lblText.Text;
    //        }
    //        set
    //        {
    //            lblText.Text = value;
    //        }
    //    }
    //    /// <summary>
    //    /// 内容
    //    /// </summary>
    //    public string Content
    //    {
    //        get
    //        {
    //            return txtContent.Text;
    //        }
    //        set
    //        {

    //            txtContent.Text = value;
    //        }
    //    }
    //}
}
