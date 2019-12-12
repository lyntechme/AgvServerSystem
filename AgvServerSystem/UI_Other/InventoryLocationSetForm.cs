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
    public partial class InventoryLocationSetForm : Form
    {
        /// <summary>
        /// 预估站点编号
        /// </summary>
        public static int InvLocBuffer = 0;
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
        private Dictionary<int, Label> dtInvLocLabel = new Dictionary<int, Label>();
        /// <summary>
        /// 电子地图编号
        /// </summary>
        private int mapNo;
        #endregion

        #region Controls
        Panel panBtn = new Panel();
        Button btnInvLocDelete = new Button();
        Button btnInvLocAdd = new Button();
        Button btnInvLocQuery = new Button();
        Button btnInvLocModify = new Button();
        #endregion


        public InventoryLocationSetForm()
        {
            InitializeComponent();

        }
        /// <summary>
        /// 呼叫站点设定
        /// </summary>
        /// <param name="_location">站点Label位置</param>
        /// <param name="_panMap">站点父控件</param>
        /// <param name="_InvLocLabel">站点Label集合</param>
        public InventoryLocationSetForm(Point _location, Panel _panMap, int mapNo, Dictionary<int, Label> _InvLocLabel)
        {
            InitializeComponent();
            #region 布局
            this.Controls.Add(panBtn);
            panBtn.Height = 60;
            panBtn.Dock = DockStyle.Bottom;
            btnInvLocDelete.Text = "Delete";
            btnInvLocDelete.Click += btnInvLocDelete_Click;
            btnInvLocQuery.Text = "Query";
            btnInvLocQuery.Click += btnInvLocQuery_Click;
            btnInvLocAdd.Text = "Add";
            btnInvLocAdd.Click += btnInvLocAdd_Click;
            btnInvLocModify.Text = "Modify";
            btnInvLocModify.Click += btnInvLocModify_Click;
            btnInvLocDelete.Dock = DockStyle.Left;
            btnInvLocQuery.Dock = DockStyle.Right;
            btnInvLocModify.Dock = DockStyle.Left;
            btnInvLocAdd.Dock = DockStyle.Fill;
            panBtn.Controls.Add(btnInvLocAdd);
            panBtn.Controls.Add(btnInvLocDelete);
            panBtn.Controls.Add(btnInvLocQuery);
            panBtn.Controls.Add(btnInvLocModify);
            #endregion

            this.location.X = Convert.ToInt32(_location.X / Common.sizeMapImage[mapNo].widthScale);
            this.location.Y = Convert.ToInt32(_location.Y / Common.sizeMapImage[mapNo].heightScale);
            this.Left = this.location.X;
            this.Top = this.location.Y;
            this.panMap = _panMap;
            this.dtInvLocLabel = _InvLocLabel;
            this.mapNo = mapNo;
            List<string> typeNameLs = new List<string>();  //站点类型集合
            try
            {
                var b = (from s in Common.Instance.dtInvLocInformation select s.Value.TypeName).Distinct().ToArray();
                cbbInvLocType.DisplayMember = "value";
                cbbInvLocType.ValueMember = "key";
                var c = (from s in Common.Instance.dtInvLocInformation select s.Value.InvLocType).Distinct().ToArray();
                List<KeyValuePair<string, string>> ls = new List<KeyValuePair<string, string>>();
                foreach (string item in c)
                {
                    string typeName = Common.Instance.dtInvLocInformation.FirstOrDefault(o => o.Value.InvLocType == item).Value.TypeName;
                    ls.Add(new KeyValuePair<string, string>(item, typeName));
                }
                cbbInvLocType.DataSource = ls;
                //cbbInvLocType.Items.Clear();
                //cbbInvLocType.DataSource
                //cbbInvLocType.SelectedIndex = 0;
            }
            catch { }
        }
        #region 按钮事件
        void btnInvLocAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(cbbInvLocId.Text);
                int[] InvLocRfids = txtInvLocRfid.Text.Split(',').Select<string, int>(q => int.Parse(q)).ToArray();
                point location = new point(Convert.ToInt32(txtLeft.Text), Convert.ToInt32(txtTop.Text));
                point size = new point(Convert.ToInt32(txtInvLocWidth.Text), Convert.ToInt32(txtInvLocHight.Text));
                int aisle = Convert.ToInt32(txtInvLocAisle.Text);
                int slot =Convert.ToInt32( txtInvLocSlot.Text);
                string wordAddr = txtWordAddress.Text;
                string name = txtInvLocName.Text;
                int bitAddr = Convert.ToInt32(txtBitAddress.Text);

                if (Common.dtInvLocInfo.ContainsKey(id))
                {
                    MessageBox.Show("The InvLoc already exists.");
                }
                else
                {
                    //InveLocConnectInfo scf = new InvLocConnectInfo();
                    InventoryLocationLayoutInfo slf = new InventoryLocationLayoutInfo(name,aisle,slot,location, size, id, InvLocRfids);
                    bool enable = bool.Parse(txtInvLocLabelEnbale.Text);
                    InventoryLocationInfo InvLocInfo = new InventoryLocationInfo(id, name, aisle, slot, location, size, cbbInvLocType.SelectedValue.ToString(), wordAddr,bitAddr, InvLocRfids,new InventoryLocationLayoutInfo());//,   this.mapNo);
                    Dictionary<int, InventoryLocationInfo> dt = new Dictionary<int, InventoryLocationInfo>();
                    dt[id] = InvLocInfo;
                    ControlsOperate.AddLabelInvLocPoint(dt, panMap, this.dtInvLocLabel);
                    Common.dtInvLocInfo[id] = InvLocInfo;
                    Common.sizeInvLocDefault = size;
                    this.Close();
                }

            }
            catch
            {
                MessageBox.Show("Format error.");
            }
        }

        void btnInvLocModify_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Whether to modify the InvLoc?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int InvLocId = int.Parse(cbbInvLocId.Text);
                    if (Common.dtInvLocInfo.ContainsKey(InvLocId))
                    {
                        string _name = txtInvLocName.Text.Trim();
                        int _left = int.Parse(txtLeft.Text);
                        int _top = int.Parse(txtTop.Text);
                        int _width = int.Parse(txtInvLocWidth.Text);
                        int _hight = int.Parse(txtInvLocHight.Text);
                        Common.dtInvLocInfo[InvLocId].Name = _name;
                        //  Common.dtInvLocInfo[InvLocId].LayoutInfo.Location = new point(_left, _top);
                        Common.dtInvLocInfo[InvLocId].LayoutInfo.location.X = _left;
                        Common.dtInvLocInfo[InvLocId].LayoutInfo.location.Y = _top;
                        Common.dtInvLocInfo[InvLocId].LayoutInfo.size.X = _width;
                        Common.dtInvLocInfo[InvLocId].LayoutInfo.size.Y = _hight;
                        //  Common.dtInvLocInfo[InvLocId].LayoutInfo.size = new point(_width, _hight);
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
        void btnInvLocQuery_Click(object sender, EventArgs e)
        {
            try
            {
                int InvLocId = int.Parse(cbbInvLocId.Text);
                if (Common.dtInvLocInfo.ContainsKey(InvLocId))
                {
                    //txtInvLocIp.Text = Common.dtInvLocLabelInfo[InvLocId].InvLocIp;
                    txtInvLocRfid.Text = string.Join(",", Common.dtInvLocInfo[InvLocId].LayoutInfo.RfidLs.ToArray());
                    txtInvLocName.Text = Common.dtInvLocInfo[InvLocId].Name;
                    txtLeft.Text =  Common.dtInvLocInfo[InvLocId].LayoutInfo.location.X.ToString();
                    txtTop.Text = Common.dtInvLocInfo[InvLocId].LayoutInfo.location.Y.ToString();
                    txtInvLocWidth.Text = Common.dtInvLocInfo[InvLocId].LayoutInfo.size.X.ToString();
                    txtInvLocHight.Text = Common.dtInvLocInfo[InvLocId].LayoutInfo.size.Y.ToString();
                    try
                    {
                        cbbInvLocType.SelectedValue = Common.dtInvLocInfo[InvLocId].invType;
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("The InvLoc does not exist", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch
            { }
        }

        void btnInvLocDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Whether to delete the InvLoc?", "Notice", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    int InvLocId = int.Parse(cbbInvLocId.Text);
                    if (Common.dtInvLocInfo.ContainsKey(InvLocId))
                    {
                        Dictionary<int, InventoryLocationInfo> dtInvLoc = new Dictionary<int, InventoryLocationInfo>();
                        dtInvLoc[InvLocId] = Common.dtInvLocInfo[InvLocId];
                        try
                        {
                            this.dtInvLocLabel[InvLocId].Parent = null;
                        }
                        catch { }
                        try
                        {
                            //panMap.Controls.Remove(dtInvLocLabel[InvLocId]); 
                            panMap.Controls.Remove(dtInvLocLabel[InvLocId]);
                        }
                        catch { }
                        try
                        {
                            this.dtInvLocLabel.Remove(InvLocId);
                        }
                        catch { }
                        try
                        {
                            Common.dtInvLocInfo.Remove(InvLocId);
                        }
                        catch { }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("The InvLoc does not exist！", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                catch { }
            }
        }
        #endregion

        private void InventoryLocationSetForm_Load(object sender, EventArgs e)
        {
            txtLeft.Text = this.location.X.ToString();
            txtTop.Text = this.location.Y.ToString();
            txtInvLocWidth.Text = Common.sizeInvLocDefault.X.ToString();
            txtInvLocHight.Text = Common.sizeInvLocDefault.Y.ToString();
           
        }

        private void splitPanInvLoc_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitPanInvLoc_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbbInvLocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string typeName = cbbInvLocType.Text.Trim();
                var b = (from s in Common.Instance.dtInvLocInformation where s.Value.TypeName == typeName select s.Value.InvLocNo.ToString()).Distinct().ToArray();
                cbbInvLocId.Items.Clear();
                cbbInvLocId.Items.AddRange(b);
                cbbInvLocId.SelectedIndex = 0;
            }
            catch { }
        }

        private void cbbInvLocId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int InvLocId = int.Parse(cbbInvLocId.Text);
                InventoryLocationInformation InvLoc = Common.Instance.dtInvLocInformation.First(o => o.Value.InvLocNo == InvLocId).Value;
                txtInvLocName.Text = InvLoc.Name;
                txtInvLocRfid.Text = string.Join(",", InvLoc.InvLocRfidLs.ToArray());
                txtInvLocLabelEnbale.Text = InvLoc.InvLocEnable.ToString();
                if (Common.dtInvLocInfo.ContainsKey(InvLocId))
                {
                    //txtInvLocIp.Text = Common.dtInvLocLabelInfo[InvLocId].InvLocIp;
                    txtInvLocRfid.Text = string.Join(",", Common.dtInvLocInfo[InvLocId].LayoutInfo.RfidLs.ToArray());
                    txtInvLocName.Text = Common.dtInvLocInfo[InvLocId].Name;
                    txtLeft.Text = Common.dtInvLocInfo[InvLocId].LayoutInfo.location.X.ToString();
                    txtTop.Text = Common.dtInvLocInfo[InvLocId].LayoutInfo.location.Y.ToString();
                    txtInvLocWidth.Text = Common.dtInvLocInfo[InvLocId].LayoutInfo.size.X.ToString();
                    txtInvLocHight.Text = Common.dtInvLocInfo[InvLocId].LayoutInfo.size.Y.ToString();
                }
            }
            catch { }
        }

        private void label4_Click(object sender, EventArgs e)
        {

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
