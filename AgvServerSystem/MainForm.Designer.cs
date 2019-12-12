namespace AgvServerSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mnu = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFullSrceen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveOther = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEsc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetRfid = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetMapIn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetMapOut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetMapSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetAgvSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetPositionName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetVoltageLimited = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetAgvModelSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetPassEnable = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetReceiveMesTask = new System.Windows.Forms.ToolStripMenuItem();
            this.testTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSetSaveParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLgoinUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoginChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoginAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoginEsc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInitSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInitSetTab = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInitSetTabMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInitSetTabQueryTask = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInitSetTabQueryAbnormal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInitSetTabConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInitSetAdmin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInitSetAdminManageUser = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInitSetAdminRfidSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInitSetAdminStationSet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInitSetAdminStationHide = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInitSetIsDynPwd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVersion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWorkMode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAgvInit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabpMap = new System.Windows.Forms.TabPage();
            this.panTabMap = new System.Windows.Forms.Panel();
            this.tabpTask = new System.Windows.Forms.TabPage();
            this.dgvSqlTaskData = new System.Windows.Forms.DataGridView();
            this.panQueryTaskTitle = new System.Windows.Forms.Panel();
            this.pbQueryTask = new System.Windows.Forms.ProgressBar();
            this.lblQueryTaskShow = new System.Windows.Forms.Label();
            this.lblTaskCount = new System.Windows.Forms.Label();
            this.chbTaskMes = new System.Windows.Forms.CheckBox();
            this.chbTaskDateSelect = new System.Windows.Forms.CheckBox();
            this.dtTaskBegin = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtTaskEnd = new System.Windows.Forms.DateTimePicker();
            this.panel93 = new System.Windows.Forms.Panel();
            this.cbQueryTaskTaskType = new System.Windows.Forms.ComboBox();
            this.label87 = new System.Windows.Forms.Label();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.cbQueryTaskLineNo = new System.Windows.Forms.ComboBox();
            this.lblQueryTaskLineNo = new System.Windows.Forms.Label();
            this.btnQueryTask = new System.Windows.Forms.Button();
            this.btnTaskExport = new System.Windows.Forms.Button();
            this.cbQueryTaskAgvNo = new System.Windows.Forms.ComboBox();
            this.lblQueryTaskAgvNo = new System.Windows.Forms.Label();
            this.tabpQueryAbnormal = new System.Windows.Forms.TabPage();
            this.dgvSqlData = new System.Windows.Forms.DataGridView();
            this.panQueryAbnormalTitle = new System.Windows.Forms.Panel();
            this.pbAbn = new System.Windows.Forms.ProgressBar();
            this.lblAbnWaitShow = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtQueryAbnormalRfid = new System.Windows.Forms.TextBox();
            this.lblQueryAbnormalRfid = new System.Windows.Forms.Label();
            this.lblQueryAbnormalInfo = new System.Windows.Forms.Label();
            this.cbQueryAbnormalInfo = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.lblAnd = new System.Windows.Forms.Label();
            this.chbDateSelect = new System.Windows.Forms.CheckBox();
            this.lblQueryAbnormalAgvNo = new System.Windows.Forms.Label();
            this.cbQueryAbnormalAgvNo = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.tabpConfig = new System.Windows.Forms.TabPage();
            this.tabConfig = new System.Windows.Forms.TabControl();
            this.tabConfigAgvInfo = new System.Windows.Forms.TabPage();
            this.panTabConfigAgvInfo = new System.Windows.Forms.Panel();
            this.panTabConfigAgvInfoList = new System.Windows.Forms.Panel();
            this.btnRestThread = new System.Windows.Forms.Button();
            this.btnAgvComInfoObtain = new System.Windows.Forms.Button();
            this.dgvAgvInfo = new System.Windows.Forms.DataGridView();
            this.cTxtAgvId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTxtDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTxtAgvAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTxtAgvNetNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTxtLocalPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTxtDesPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCbAgvConnectType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cCbAgvCommonType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cCbIsUsing = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cCbDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cCbChange = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lblAgvConfigList = new System.Windows.Forms.Label();
            this.panTabConfigAgvInfoAdd = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbAgvCommonType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panAgvComInfoLine8 = new System.Windows.Forms.Panel();
            this.panAgvComInfoLine9 = new System.Windows.Forms.Panel();
            this.panAgvComInfoLine7 = new System.Windows.Forms.Panel();
            this.panAgvComInfoLine6 = new System.Windows.Forms.Panel();
            this.panAgvComInfoLine5 = new System.Windows.Forms.Panel();
            this.panAgvComInfoLine4 = new System.Windows.Forms.Panel();
            this.panAgvComInfoLine3 = new System.Windows.Forms.Panel();
            this.panAgvComInfoLine2 = new System.Windows.Forms.Panel();
            this.panAgvComInfoLine1 = new System.Windows.Forms.Panel();
            this.cbIsUsing = new System.Windows.Forms.ComboBox();
            this.lblIsUsing = new System.Windows.Forms.Label();
            this.txtAgvInfoDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.mtxtIp = new System.Windows.Forms.MaskedTextBox();
            this.btnAgvInfoAdd = new System.Windows.Forms.Button();
            this.cbAgvConnectType = new System.Windows.Forms.ComboBox();
            this.lblAgvType = new System.Windows.Forms.Label();
            this.lblDesPort = new System.Windows.Forms.Label();
            this.txtAgvInfoDesPort = new System.Windows.Forms.TextBox();
            this.lblLocalPort = new System.Windows.Forms.Label();
            this.txtAgvInfoLocalPort = new System.Windows.Forms.TextBox();
            this.lblAgvNetNo = new System.Windows.Forms.Label();
            this.txtAgvInfoNetNo = new System.Windows.Forms.TextBox();
            this.txtAgvInfoId = new System.Windows.Forms.TextBox();
            this.lblAgvIpAddress = new System.Windows.Forms.Label();
            this.lblAgvId = new System.Windows.Forms.Label();
            this.tabConfigMapSet = new System.Windows.Forms.TabPage();
            this.panMapConfig = new System.Windows.Forms.Panel();
            this.panConfigMapAgvModel = new System.Windows.Forms.Panel();
            this.picConfigMapModel = new System.Windows.Forms.PictureBox();
            this.llblConfigMapModelInsert = new System.Windows.Forms.LinkLabel();
            this.btnConfigMapAgvModelRef = new System.Windows.Forms.Button();
            this.btnConfigMapAgvModelRecevied = new System.Windows.Forms.Button();
            this.lblConfigMapAgvModel = new System.Windows.Forms.Label();
            this.panConfigMapShortPathTest = new System.Windows.Forms.Panel();
            this.lblConfigMapShortPathTest = new System.Windows.Forms.Label();
            this.txtPathShow = new System.Windows.Forms.TextBox();
            this.btnShortPath = new System.Windows.Forms.Button();
            this.txtStartId = new System.Windows.Forms.TextBox();
            this.lblEndId = new System.Windows.Forms.Label();
            this.txtEndId = new System.Windows.Forms.TextBox();
            this.lblStartId = new System.Windows.Forms.Label();
            this.panConfigMapBackgroundImageSet = new System.Windows.Forms.Panel();
            this.cbMapSel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMapConfigRef = new System.Windows.Forms.Button();
            this.btnMapConfigPreviewClear = new System.Windows.Forms.Button();
            this.btnMapConfigPreview = new System.Windows.Forms.Button();
            this.picConfigMap = new System.Windows.Forms.PictureBox();
            this.lblConfigMapBackgroundImage = new System.Windows.Forms.Label();
            this.btnMapConfigImport = new System.Windows.Forms.Button();
            this.btnMapConfigExport = new System.Windows.Forms.Button();
            this.tabConfigSql = new System.Windows.Forms.TabPage();
            this.panConfigSqlConfig = new System.Windows.Forms.Panel();
            this.panConfigSQLSet1 = new System.Windows.Forms.Panel();
            this.lblConfigSqlTItle1 = new System.Windows.Forms.Label();
            this.btnConfigDataType = new System.Windows.Forms.Button();
            this.cbConfigDataType = new System.Windows.Forms.ComboBox();
            this.panConfigSQLSet = new System.Windows.Forms.Panel();
            this.lblConfigSqlTItle = new System.Windows.Forms.Label();
            this.txtConfigSqlDatabase = new System.Windows.Forms.TextBox();
            this.txtConfigSqlUserPwd = new System.Windows.Forms.TextBox();
            this.txtConfigUserName = new System.Windows.Forms.TextBox();
            this.txtConfigSqlAddress = new System.Windows.Forms.TextBox();
            this.btnConfigSqlRef = new System.Windows.Forms.Button();
            this.btnConfigSqlRec = new System.Windows.Forms.Button();
            this.lblConfigSqlDataBase = new System.Windows.Forms.Label();
            this.lblConfigSqlUserPwd = new System.Windows.Forms.Label();
            this.lblConfigUserName = new System.Windows.Forms.Label();
            this.lblConfigSqlAddress = new System.Windows.Forms.Label();
            this.tabConfigBasic = new System.Windows.Forms.TabPage();
            this.panConfigBasic = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvConfigControl = new System.Windows.Forms.DataGridView();
            this.ctxtConfigControlNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtConfigControlPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn17 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn18 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnConfigControlAdd = new System.Windows.Forms.Button();
            this.lblConfigControlPoint = new System.Windows.Forms.Label();
            this.txtConfigControlPoint = new System.Windows.Forms.TextBox();
            this.lblConfigControlNo = new System.Windows.Forms.Label();
            this.txtConfigControlNo = new System.Windows.Forms.TextBox();
            this.btnConfigControlObtain = new System.Windows.Forms.Button();
            this.lblConfigControlPoints = new System.Windows.Forms.Label();
            this.panConfigBasicParameter = new System.Windows.Forms.Panel();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label94 = new System.Windows.Forms.Label();
            this.btnStandbyChargeTimeUpdate = new System.Windows.Forms.Button();
            this.btnStandbyChargeTimeReceive = new System.Windows.Forms.Button();
            this.txtStanbyChargeTime = new System.Windows.Forms.TextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label92 = new System.Windows.Forms.Label();
            this.btnChargeTimeUpdate = new System.Windows.Forms.Button();
            this.btnChargeTimeReceive = new System.Windows.Forms.Button();
            this.txtChargeTime = new System.Windows.Forms.TextBox();
            this.label93 = new System.Windows.Forms.Label();
            this.btnOpcValue = new System.Windows.Forms.Button();
            this.txtHandleValue = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtHandle = new System.Windows.Forms.TextBox();
            this.lblHandle = new System.Windows.Forms.Label();
            this.btnRobotRefence = new System.Windows.Forms.Button();
            this.btnRobotStateReceive = new System.Windows.Forms.Button();
            this.dgvOpcState = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Handle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpcParameterValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label86 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtClearLineTime = new System.Windows.Forms.TextBox();
            this.btnLineTimeRef = new System.Windows.Forms.Button();
            this.btnLineTimeRec = new System.Windows.Forms.Button();
            this.label84 = new System.Windows.Forms.Label();
            this.txtLineTime = new System.Windows.Forms.TextBox();
            this.gbTaskClient = new System.Windows.Forms.GroupBox();
            this.btnPlcClientRef = new System.Windows.Forms.Button();
            this.btnPlcClientRec = new System.Windows.Forms.Button();
            this.txtOpcHostName = new System.Windows.Forms.TextBox();
            this.txtOpcIp = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btnStationRef = new System.Windows.Forms.Button();
            this.btnStationRec = new System.Windows.Forms.Button();
            this.dgvStation = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblConfigBasicParameter = new System.Windows.Forms.Label();
            this.tabConfigStation = new System.Windows.Forms.TabPage();
            this.panel12 = new System.Windows.Forms.Panel();
            this.dgvStationInformation = new System.Windows.Forms.DataGridView();
            this.ctxtStationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtStationNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtStationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtStationRfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtStationMatchValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtStationInformation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtStationGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccbStationEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ctxtStationDescribe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtStationBindAgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStationState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStationHandle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtStationUpdateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbtnStationOperate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbtnStationDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnStationReceive = new System.Windows.Forms.Button();
            this.panel45 = new System.Windows.Forms.Panel();
            this.cbbStationTypeShow1 = new System.Windows.Forms.ComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.cbbStationTypeShow = new System.Windows.Forms.ComboBox();
            this.panel70 = new System.Windows.Forms.Panel();
            this.btnCellsStationAdd = new System.Windows.Forms.Button();
            this.btnStationAdd = new System.Windows.Forms.Button();
            this.txtStationDescribe = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.cbStationEnable = new System.Windows.Forms.ComboBox();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.panel41 = new System.Windows.Forms.Panel();
            this.panel42 = new System.Windows.Forms.Panel();
            this.txtStationGroup = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel43 = new System.Windows.Forms.Panel();
            this.txtStationOperate = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.panel22 = new System.Windows.Forms.Panel();
            this.panel23 = new System.Windows.Forms.Panel();
            this.txtStationMatchValue = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.panel24 = new System.Windows.Forms.Panel();
            this.txtStationRfid = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.txtStationName = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.panel18 = new System.Windows.Forms.Panel();
            this.txtStationNo = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.txtStationTypeName = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.panel21 = new System.Windows.Forms.Panel();
            this.txtStationType = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tabConfigCharge = new System.Windows.Forms.TabPage();
            this.panCharge = new System.Windows.Forms.Panel();
            this.dgvChargeInfo = new System.Windows.Forms.DataGridView();
            this.ctxtChargeNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccbChargeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtChargeIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtChargePort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtChargeRfid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccbChargeType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ccbChargeEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ctxtChargeDescribe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbtnChargeOperate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cbtnChargeDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panChargeAdd = new System.Windows.Forms.Panel();
            this.btnChargeRec = new System.Windows.Forms.Button();
            this.btnChargeAdd = new System.Windows.Forms.Button();
            this.txtChargedescribe = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.panChargeEnable = new System.Windows.Forms.Panel();
            this.cbChargeEnable = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panel52 = new System.Windows.Forms.Panel();
            this.cbChargeType = new System.Windows.Forms.ComboBox();
            this.panel53 = new System.Windows.Forms.Panel();
            this.label55 = new System.Windows.Forms.Label();
            this.txtChargeRfid = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel49 = new System.Windows.Forms.Panel();
            this.panel50 = new System.Windows.Forms.Panel();
            this.txtChargePort = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel51 = new System.Windows.Forms.Panel();
            this.txtChargeIp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel46 = new System.Windows.Forms.Panel();
            this.panel47 = new System.Windows.Forms.Panel();
            this.txtChargeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel48 = new System.Windows.Forms.Panel();
            this.txtChargeNo = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.tabConfigElevator = new System.Windows.Forms.TabPage();
            this.panel25 = new System.Windows.Forms.Panel();
            this.dgvElevator = new System.Windows.Forms.DataGridView();
            this.dtxtElevatorNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtxtElevatorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtxtElevatorIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtxtElevatorPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtxtElevatorStopRfids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtxtElevatorCallRfids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtxtElevatorFloorNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dchbElevatorEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dbtnOperate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dbtnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel26 = new System.Windows.Forms.Panel();
            this.btnElevatorReceive = new System.Windows.Forms.Button();
            this.btnElevatorAdd = new System.Windows.Forms.Button();
            this.txtElevatorNumber = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.panel95 = new System.Windows.Forms.Panel();
            this.cbElevatorEnable = new System.Windows.Forms.ComboBox();
            this.panel96 = new System.Windows.Forms.Panel();
            this.label34 = new System.Windows.Forms.Label();
            this.txtElevatorCallRfids = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtElevatorStopRfids = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.panel97 = new System.Windows.Forms.Panel();
            this.panel98 = new System.Windows.Forms.Panel();
            this.txtElevatorPort = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.panel101 = new System.Windows.Forms.Panel();
            this.txtElevatorIp = new System.Windows.Forms.TextBox();
            this.label89 = new System.Windows.Forms.Label();
            this.panel102 = new System.Windows.Forms.Panel();
            this.panel103 = new System.Windows.Forms.Panel();
            this.txtElevatorName = new System.Windows.Forms.TextBox();
            this.label90 = new System.Windows.Forms.Label();
            this.panel104 = new System.Windows.Forms.Panel();
            this.txtElevatorNo = new System.Windows.Forms.TextBox();
            this.label91 = new System.Windows.Forms.Label();
            this.tabConfigShutterDoor = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvShutterDoor = new System.Windows.Forms.DataGridView();
            this.ctxtDoorNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtDoorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtDoorIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtDoorPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtDoorStopRfids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtDoorCallRfids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ccbDoorEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ctxtDoorRelation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ctxtDoorRelationNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cbtnDoorOperate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cBtnDoorDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnShutterDoorReceive = new System.Windows.Forms.Button();
            this.btnShutterDoorAdd = new System.Windows.Forms.Button();
            this.panel33 = new System.Windows.Forms.Panel();
            this.panel34 = new System.Windows.Forms.Panel();
            this.txtShutterRelationNumber = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.panel35 = new System.Windows.Forms.Panel();
            this.txtShutterRelation = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cbShutterDoorEnable = new System.Windows.Forms.ComboBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.txtShutterCallRfids = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtShutterStopRfids = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtShutterPort = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtShutterDoorIp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel38 = new System.Windows.Forms.Panel();
            this.panel39 = new System.Windows.Forms.Panel();
            this.txtShutterDoorName = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.panel40 = new System.Windows.Forms.Panel();
            this.txtShutterDoorNo = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.tabConfigCapacityTest = new System.Windows.Forms.TabPage();
            this.panCapaCityTest = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.panel99 = new System.Windows.Forms.Panel();
            this.panel100 = new System.Windows.Forms.Panel();
            this.btnAgvLimitedRec = new System.Windows.Forms.Button();
            this.btnAgvLimitedRef = new System.Windows.Forms.Button();
            this.panel106 = new System.Windows.Forms.Panel();
            this.txtAgvLimited = new System.Windows.Forms.TextBox();
            this.label97 = new System.Windows.Forms.Label();
            this.gbxCapacityTestOperate = new System.Windows.Forms.GroupBox();
            this.panel92 = new System.Windows.Forms.Panel();
            this.btnGroupMesTaskRec = new System.Windows.Forms.Button();
            this.btnGroupMesTaskRef = new System.Windows.Forms.Button();
            this.panel91 = new System.Windows.Forms.Panel();
            this.txtGroupMesTask = new System.Windows.Forms.TextBox();
            this.label88 = new System.Windows.Forms.Label();
            this.panel87 = new System.Windows.Forms.Panel();
            this.chbQRCode = new System.Windows.Forms.CheckBox();
            this.panel83 = new System.Windows.Forms.Panel();
            this.txtTestSubStayRec = new System.Windows.Forms.Button();
            this.btnTestSubStayRef = new System.Windows.Forms.Button();
            this.panel82 = new System.Windows.Forms.Panel();
            this.label80 = new System.Windows.Forms.Label();
            this.txtTestSubStayTime = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.panel74 = new System.Windows.Forms.Panel();
            this.panel81 = new System.Windows.Forms.Panel();
            this.btnCapacityTestOperateRec = new System.Windows.Forms.Button();
            this.btnCapacityTestOperateRef = new System.Windows.Forms.Button();
            this.panel80 = new System.Windows.Forms.Panel();
            this.txtCapacityTestRightUnload = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.panel79 = new System.Windows.Forms.Panel();
            this.txtCapacityTestLeftUnload = new System.Windows.Forms.TextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.panel78 = new System.Windows.Forms.Panel();
            this.txtCapacityTestRightRefueling = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.panel77 = new System.Windows.Forms.Panel();
            this.txtCapacityTestLeftRefueling = new System.Windows.Forms.TextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.panel76 = new System.Windows.Forms.Panel();
            this.txtCapacityTestRightLoad = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.panel75 = new System.Windows.Forms.Panel();
            this.txtCapacityTestLeftLoad = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.gbCapacityTestWaitPoint = new System.Windows.Forms.GroupBox();
            this.gbCapacityTestWait2 = new System.Windows.Forms.GroupBox();
            this.panel31 = new System.Windows.Forms.Panel();
            this.btnCapacityTestWait2Receive = new System.Windows.Forms.Button();
            this.btnCapacityTestWait2update = new System.Windows.Forms.Button();
            this.txtCapacityTestWait2Rfids = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtCapacityTestWait2Stations = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.panel32 = new System.Windows.Forms.Panel();
            this.txtCapacityTestWait2Rfid = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.gbCapacityTestWait1 = new System.Windows.Forms.GroupBox();
            this.panel28 = new System.Windows.Forms.Panel();
            this.btnCapacityTestWait1Receive = new System.Windows.Forms.Button();
            this.btnCapacityTestWait1Update = new System.Windows.Forms.Button();
            this.txtCapacityTestWait1Rfids = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.txtCapacityTestWait1Stations = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.panel27 = new System.Windows.Forms.Panel();
            this.txtCapacityTestWait1Rfid = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tabConfigBurnInRoom = new System.Windows.Forms.TabPage();
            this.panAgingRoom = new System.Windows.Forms.Panel();
            this.gbxCapAgingRoom = new System.Windows.Forms.GroupBox();
            this.panel62 = new System.Windows.Forms.Panel();
            this.btnCapAgingRoomUpdate = new System.Windows.Forms.Button();
            this.panel63 = new System.Windows.Forms.Panel();
            this.btnCapAgingRoomRfidReceive = new System.Windows.Forms.Button();
            this.panel64 = new System.Windows.Forms.Panel();
            this.panel65 = new System.Windows.Forms.Panel();
            this.txtCapAgingRoomUnloadAreaRfid = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.panel66 = new System.Windows.Forms.Panel();
            this.panel67 = new System.Windows.Forms.Panel();
            this.txtCapAgingRoomStaticArea2Rfid = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.txtCapAgingRoomStaticArea1Rfid = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.panel68 = new System.Windows.Forms.Panel();
            this.panel69 = new System.Windows.Forms.Panel();
            this.txtCapAgingRoomLoadAreaRfid = new System.Windows.Forms.TextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.gbxPreAgingRoom = new System.Windows.Forms.GroupBox();
            this.panel60 = new System.Windows.Forms.Panel();
            this.btnPreAgingRoomUpdate = new System.Windows.Forms.Button();
            this.panel61 = new System.Windows.Forms.Panel();
            this.btnPreAgingRoomRfidReceive = new System.Windows.Forms.Button();
            this.panel59 = new System.Windows.Forms.Panel();
            this.panel58 = new System.Windows.Forms.Panel();
            this.txtPreAgingRoomUnloadAreaRfid = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.panel57 = new System.Windows.Forms.Panel();
            this.panel56 = new System.Windows.Forms.Panel();
            this.txtPreAgingRoomStaticAreaRfid = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.panel55 = new System.Windows.Forms.Panel();
            this.panel54 = new System.Windows.Forms.Panel();
            this.txtPreAgingRoomLoadAreaRfid = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.tabConfigTest = new System.Windows.Forms.TabPage();
            this.panConfigTest = new System.Windows.Forms.Panel();
            this.panel88 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel90 = new System.Windows.Forms.Panel();
            this.chbMatchTask = new System.Windows.Forms.CheckBox();
            this.panel89 = new System.Windows.Forms.Panel();
            this.btnAgvMatchStationRef = new System.Windows.Forms.Button();
            this.btnAgvMatchStationRec = new System.Windows.Forms.Button();
            this.dgvAgvMatchStation = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gbAgvOperation = new System.Windows.Forms.GroupBox();
            this.panel71 = new System.Windows.Forms.Panel();
            this.chbSaveRoute = new System.Windows.Forms.CheckBox();
            this.panel86 = new System.Windows.Forms.Panel();
            this.btnAutoTaskAgvsRef = new System.Windows.Forms.Button();
            this.btnAutoTaskAgvsRec = new System.Windows.Forms.Button();
            this.label83 = new System.Windows.Forms.Label();
            this.txtAutoTaskAgvs = new System.Windows.Forms.TextBox();
            this.panel85 = new System.Windows.Forms.Panel();
            this.label82 = new System.Windows.Forms.Label();
            this.panel84 = new System.Windows.Forms.Panel();
            this.btnCapTestStationsRef = new System.Windows.Forms.Button();
            this.btnCapTestStationsRec = new System.Windows.Forms.Button();
            this.txtCapTestStations = new System.Windows.Forms.TextBox();
            this.label81 = new System.Windows.Forms.Label();
            this.chbTestSubUnload = new System.Windows.Forms.CheckBox();
            this.chbTestSubLoad = new System.Windows.Forms.CheckBox();
            this.chbTestSubRefu = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chbRandomRobotOperate = new System.Windows.Forms.CheckBox();
            this.chbRandomSelect = new System.Windows.Forms.CheckBox();
            this.btnTestSutSet = new System.Windows.Forms.Button();
            this.btnTestSubRec = new System.Windows.Forms.Button();
            this.label72 = new System.Windows.Forms.Label();
            this.txtTestSub = new System.Windows.Forms.TextBox();
            this.panel73 = new System.Windows.Forms.Panel();
            this.chbTestLoad4 = new System.Windows.Forms.CheckBox();
            this.chbTestLoad3 = new System.Windows.Forms.CheckBox();
            this.chbTestLoad2 = new System.Windows.Forms.CheckBox();
            this.chbTestLoad1 = new System.Windows.Forms.CheckBox();
            this.gbRouteTest = new System.Windows.Forms.GroupBox();
            this.panTestRouteS = new System.Windows.Forms.Panel();
            this.txtTestRoutes = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnTestRouteNoClear = new System.Windows.Forms.Button();
            this.btnTestRouteClear = new System.Windows.Forms.Button();
            this.btnTestRouteReceive = new System.Windows.Forms.Button();
            this.btnTestRouteAdd = new System.Windows.Forms.Button();
            this.panTestRouteSet = new System.Windows.Forms.Panel();
            this.panel37 = new System.Windows.Forms.Panel();
            this.txtTestRouteTargetOperate = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTestRouteSourceOperate = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.panel36 = new System.Windows.Forms.Panel();
            this.txtTestRouteTarget = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtTestRouteSource = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel44 = new System.Windows.Forms.Panel();
            this.btnTestRouteAll = new System.Windows.Forms.Button();
            this.txtTestRouteAllCount = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.txtTestRouteOperateAll = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.txtTestRouteTargetAll = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.txtTestRouteSourceAll = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.panIsTest = new System.Windows.Forms.Panel();
            this.txtTestTaskCurrentIndex = new System.Windows.Forms.TextBox();
            this.chbTestLoop = new System.Windows.Forms.CheckBox();
            this.chbIsTest = new System.Windows.Forms.CheckBox();
            this.panTestAgvGroup = new System.Windows.Forms.Panel();
            this.tabpState = new System.Windows.Forms.TabPage();
            this.tabpTaskState = new System.Windows.Forms.TabPage();
            this.gbTaskStateCapacityBurnInRoom = new System.Windows.Forms.GroupBox();
            this.panCapAgingTask = new System.Windows.Forms.Panel();
            this.btnCapAgingTaskManualRef = new System.Windows.Forms.Button();
            this.label71 = new System.Windows.Forms.Label();
            this.btnCapAgingTaskSet = new System.Windows.Forms.Button();
            this.label67 = new System.Windows.Forms.Label();
            this.txtCapAgingTaskTime = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.cbCapAgingTaskRefEnable = new System.Windows.Forms.CheckBox();
            this.gbTaskStatePreChargeBurnInRoom = new System.Windows.Forms.GroupBox();
            this.panPreAgingTask = new System.Windows.Forms.Panel();
            this.btnPreAgingTaskManualRef = new System.Windows.Forms.Button();
            this.label70 = new System.Windows.Forms.Label();
            this.btnPreAgingTaskSet = new System.Windows.Forms.Button();
            this.label65 = new System.Windows.Forms.Label();
            this.txtPreAgingTaskTime = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.cbPreAgingTaskRefEnable = new System.Windows.Forms.CheckBox();
            this.gbTaskStateCapacityTest = new System.Windows.Forms.GroupBox();
            this.panCapTestTask = new System.Windows.Forms.Panel();
            this.btnCapTestTaskManualRef = new System.Windows.Forms.Button();
            this.label69 = new System.Windows.Forms.Label();
            this.btnCapTestTaskSet = new System.Windows.Forms.Button();
            this.label64 = new System.Windows.Forms.Label();
            this.txtCapTestTaskTime = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.cbCapTestTaskRefEnable = new System.Windows.Forms.CheckBox();
            this.tabpDoor = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panChargeInfoState = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.panElevatorState = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panDoorState = new System.Windows.Forms.Panel();
            this.tabpControlState = new System.Windows.Forms.TabPage();
            this.panControlState = new System.Windows.Forms.Panel();
            this.panAgvControls = new System.Windows.Forms.Panel();
            this.panel72 = new System.Windows.Forms.Panel();
            this.btnManualRefControlState = new System.Windows.Forms.Button();
            this.cbhAutoRefControlsState = new System.Windows.Forms.CheckBox();
            this.cmnuTlpAgvLight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnutlpAgvCol = new System.Windows.Forms.ToolStripTextBox();
            this.mnutlpAgvRow = new System.Windows.Forms.ToolStripTextBox();
            this.mnutlpAgvChnage = new System.Windows.Forms.ToolStripMenuItem();
            this.stu = new System.Windows.Forms.StatusStrip();
            this.stuLblUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.stuLsplit = new System.Windows.Forms.ToolStripStatusLabel();
            this.stuLabelCommStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stuLabelTcpStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.stuLsplit1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stuLabelDataToSql = new System.Windows.Forms.ToolStripStatusLabel();
            this.stuProDataToSql = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stuLabelSql = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAgvRun = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAgvStop = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAgvError = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAgvLine = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAgvObstacle = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslAgvLowVoltage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrRef = new System.Windows.Forms.Timer(this.components);
            this.tmrMapRef = new System.Windows.Forms.Timer(this.components);
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tmrMapChange = new System.Windows.Forms.Timer(this.components);
            this.tmrTip = new System.Windows.Forms.Timer(this.components);
            this.tmrAgvInfo = new System.Windows.Forms.Timer(this.components);
            this.mnuSetInvLoc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabpMap.SuspendLayout();
            this.tabpTask.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSqlTaskData)).BeginInit();
            this.panQueryTaskTitle.SuspendLayout();
            this.tabpQueryAbnormal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSqlData)).BeginInit();
            this.panQueryAbnormalTitle.SuspendLayout();
            this.tabpConfig.SuspendLayout();
            this.tabConfig.SuspendLayout();
            this.tabConfigAgvInfo.SuspendLayout();
            this.panTabConfigAgvInfo.SuspendLayout();
            this.panTabConfigAgvInfoList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgvInfo)).BeginInit();
            this.panTabConfigAgvInfoAdd.SuspendLayout();
            this.tabConfigMapSet.SuspendLayout();
            this.panMapConfig.SuspendLayout();
            this.panConfigMapAgvModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConfigMapModel)).BeginInit();
            this.panConfigMapShortPathTest.SuspendLayout();
            this.panConfigMapBackgroundImageSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConfigMap)).BeginInit();
            this.tabConfigSql.SuspendLayout();
            this.panConfigSqlConfig.SuspendLayout();
            this.panConfigSQLSet1.SuspendLayout();
            this.panConfigSQLSet.SuspendLayout();
            this.tabConfigBasic.SuspendLayout();
            this.panConfigBasic.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigControl)).BeginInit();
            this.panConfigBasicParameter.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcState)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.gbTaskClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStation)).BeginInit();
            this.tabConfigStation.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStationInformation)).BeginInit();
            this.panel13.SuspendLayout();
            this.panel45.SuspendLayout();
            this.panel70.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel41.SuspendLayout();
            this.panel42.SuspendLayout();
            this.panel43.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel23.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel19.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel21.SuspendLayout();
            this.tabConfigCharge.SuspendLayout();
            this.panCharge.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChargeInfo)).BeginInit();
            this.panChargeAdd.SuspendLayout();
            this.panChargeEnable.SuspendLayout();
            this.panel52.SuspendLayout();
            this.panel49.SuspendLayout();
            this.panel50.SuspendLayout();
            this.panel51.SuspendLayout();
            this.panel46.SuspendLayout();
            this.panel47.SuspendLayout();
            this.panel48.SuspendLayout();
            this.tabConfigElevator.SuspendLayout();
            this.panel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvElevator)).BeginInit();
            this.panel26.SuspendLayout();
            this.panel95.SuspendLayout();
            this.panel97.SuspendLayout();
            this.panel98.SuspendLayout();
            this.panel101.SuspendLayout();
            this.panel102.SuspendLayout();
            this.panel103.SuspendLayout();
            this.panel104.SuspendLayout();
            this.tabConfigShutterDoor.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShutterDoor)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel33.SuspendLayout();
            this.panel34.SuspendLayout();
            this.panel35.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel38.SuspendLayout();
            this.panel39.SuspendLayout();
            this.panel40.SuspendLayout();
            this.tabConfigCapacityTest.SuspendLayout();
            this.panCapaCityTest.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel99.SuspendLayout();
            this.panel100.SuspendLayout();
            this.panel106.SuspendLayout();
            this.gbxCapacityTestOperate.SuspendLayout();
            this.panel92.SuspendLayout();
            this.panel91.SuspendLayout();
            this.panel87.SuspendLayout();
            this.panel83.SuspendLayout();
            this.panel82.SuspendLayout();
            this.panel74.SuspendLayout();
            this.panel81.SuspendLayout();
            this.panel80.SuspendLayout();
            this.panel79.SuspendLayout();
            this.panel78.SuspendLayout();
            this.panel77.SuspendLayout();
            this.panel76.SuspendLayout();
            this.panel75.SuspendLayout();
            this.gbCapacityTestWaitPoint.SuspendLayout();
            this.gbCapacityTestWait2.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel32.SuspendLayout();
            this.gbCapacityTestWait1.SuspendLayout();
            this.panel28.SuspendLayout();
            this.panel27.SuspendLayout();
            this.tabConfigBurnInRoom.SuspendLayout();
            this.panAgingRoom.SuspendLayout();
            this.gbxCapAgingRoom.SuspendLayout();
            this.panel62.SuspendLayout();
            this.panel65.SuspendLayout();
            this.panel67.SuspendLayout();
            this.panel69.SuspendLayout();
            this.gbxPreAgingRoom.SuspendLayout();
            this.panel60.SuspendLayout();
            this.panel58.SuspendLayout();
            this.panel56.SuspendLayout();
            this.panel54.SuspendLayout();
            this.tabConfigTest.SuspendLayout();
            this.panConfigTest.SuspendLayout();
            this.panel88.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel90.SuspendLayout();
            this.panel89.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgvMatchStation)).BeginInit();
            this.gbAgvOperation.SuspendLayout();
            this.panel71.SuspendLayout();
            this.panel86.SuspendLayout();
            this.panel85.SuspendLayout();
            this.panel84.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel73.SuspendLayout();
            this.gbRouteTest.SuspendLayout();
            this.panTestRouteS.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panTestRouteSet.SuspendLayout();
            this.panel37.SuspendLayout();
            this.panel36.SuspendLayout();
            this.panel44.SuspendLayout();
            this.panIsTest.SuspendLayout();
            this.tabpTaskState.SuspendLayout();
            this.gbTaskStateCapacityBurnInRoom.SuspendLayout();
            this.panCapAgingTask.SuspendLayout();
            this.gbTaskStatePreChargeBurnInRoom.SuspendLayout();
            this.panPreAgingTask.SuspendLayout();
            this.gbTaskStateCapacityTest.SuspendLayout();
            this.panCapTestTask.SuspendLayout();
            this.tabpDoor.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabpControlState.SuspendLayout();
            this.panControlState.SuspendLayout();
            this.panel72.SuspendLayout();
            this.cmnuTlpAgvLight.SuspendLayout();
            this.stu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu
            // 
            this.mnu.BackColor = System.Drawing.Color.White;
            this.mnu.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuSet,
            this.mnuLogin,
            this.mnuInitSet,
            this.mnuVersion,
            this.mnuWorkMode,
            this.mnuAgvInit});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(1817, 27);
            this.mnu.TabIndex = 0;
            this.mnu.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuFullSrceen,
            this.mnuSaveOther,
            this.mnuEsc});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuFile.Size = new System.Drawing.Size(56, 23);
            this.mnuFile.Text = "File(F)";
            // 
            // mnuOpen
            // 
            this.mnuOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenInformation});
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpen.Size = new System.Drawing.Size(197, 24);
            this.mnuOpen.Text = "Open(O)";
            // 
            // mnuOpenInformation
            // 
            this.mnuOpenInformation.Name = "mnuOpenInformation";
            this.mnuOpenInformation.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mnuOpenInformation.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.I)));
            this.mnuOpenInformation.Size = new System.Drawing.Size(220, 24);
            this.mnuOpenInformation.Text = "Data folder";
            this.mnuOpenInformation.Click += new System.EventHandler(this.mnuOpenInformation_Click);
            // 
            // mnuFullSrceen
            // 
            this.mnuFullSrceen.CheckOnClick = true;
            this.mnuFullSrceen.Name = "mnuFullSrceen";
            this.mnuFullSrceen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuFullSrceen.Size = new System.Drawing.Size(197, 24);
            this.mnuFullSrceen.Text = "Full screen";
            this.mnuFullSrceen.Click += new System.EventHandler(this.mnuFullSrceen_Click);
            // 
            // mnuSaveOther
            // 
            this.mnuSaveOther.Name = "mnuSaveOther";
            this.mnuSaveOther.Size = new System.Drawing.Size(197, 24);
            this.mnuSaveOther.Text = "Backup parameters";
            this.mnuSaveOther.Click += new System.EventHandler(this.mnuSaveOther_Click);
            // 
            // mnuEsc
            // 
            this.mnuEsc.Name = "mnuEsc";
            this.mnuEsc.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuEsc.Size = new System.Drawing.Size(197, 24);
            this.mnuEsc.Text = "Exit(X)";
            this.mnuEsc.Click += new System.EventHandler(this.mnuEsc_Click);
            // 
            // mnuSet
            // 
            this.mnuSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetRfid,
            this.mnuSetMap,
            this.mnuSetAgvSelect,
            this.mnuSetPositionName,
            this.mnuSetVoltageLimited,
            this.mnuSetAgvModelSet,
            this.mnuSetPassEnable,
            this.mnuSetReceiveMesTask,
            this.testTaskToolStripMenuItem,
            this.mnuSetSaveParameter,
            this.mnuSetInvLoc});
            this.mnuSet.Name = "mnuSet";
            this.mnuSet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSet.Size = new System.Drawing.Size(55, 23);
            this.mnuSet.Text = "Set(S)";
            // 
            // mnuSetRfid
            // 
            this.mnuSetRfid.CheckOnClick = true;
            this.mnuSetRfid.Name = "mnuSetRfid";
            this.mnuSetRfid.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.mnuSetRfid.Size = new System.Drawing.Size(254, 24);
            this.mnuSetRfid.Text = "Rfid setting(P)";
            this.mnuSetRfid.Click += new System.EventHandler(this.mnuSetRfid_Click);
            // 
            // mnuSetMap
            // 
            this.mnuSetMap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSetMapIn,
            this.mnuSetMapOut,
            this.mnuSetMapSet});
            this.mnuSetMap.Name = "mnuSetMap";
            this.mnuSetMap.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mnuSetMap.Size = new System.Drawing.Size(254, 24);
            this.mnuSetMap.Text = "Map(S)";
            // 
            // mnuSetMapIn
            // 
            this.mnuSetMapIn.Name = "mnuSetMapIn";
            this.mnuSetMapIn.Size = new System.Drawing.Size(199, 24);
            this.mnuSetMapIn.Text = "Import Background";
            this.mnuSetMapIn.Click += new System.EventHandler(this.mnuSetMapIn_Click);
            // 
            // mnuSetMapOut
            // 
            this.mnuSetMapOut.Name = "mnuSetMapOut";
            this.mnuSetMapOut.Size = new System.Drawing.Size(199, 24);
            this.mnuSetMapOut.Text = "Export Background";
            this.mnuSetMapOut.Click += new System.EventHandler(this.mnuSetMapOut_Click);
            // 
            // mnuSetMapSet
            // 
            this.mnuSetMapSet.Name = "mnuSetMapSet";
            this.mnuSetMapSet.Size = new System.Drawing.Size(199, 24);
            this.mnuSetMapSet.Text = "Map Setting";
            this.mnuSetMapSet.Click += new System.EventHandler(this.mnuSetMapSet_Click);
            // 
            // mnuSetAgvSelect
            // 
            this.mnuSetAgvSelect.Name = "mnuSetAgvSelect";
            this.mnuSetAgvSelect.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.mnuSetAgvSelect.Size = new System.Drawing.Size(254, 24);
            this.mnuSetAgvSelect.Text = "Agv visible(S)";
            this.mnuSetAgvSelect.Click += new System.EventHandler(this.mnuSetAgvSelect_Click);
            // 
            // mnuSetPositionName
            // 
            this.mnuSetPositionName.Name = "mnuSetPositionName";
            this.mnuSetPositionName.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.mnuSetPositionName.Size = new System.Drawing.Size(254, 24);
            this.mnuSetPositionName.Text = "Position Name";
            this.mnuSetPositionName.Click += new System.EventHandler(this.mnuSetPositionName_Click);
            // 
            // mnuSetVoltageLimited
            // 
            this.mnuSetVoltageLimited.Name = "mnuSetVoltageLimited";
            this.mnuSetVoltageLimited.Size = new System.Drawing.Size(254, 24);
            this.mnuSetVoltageLimited.Text = "Charge Limited";
            this.mnuSetVoltageLimited.Visible = false;
            this.mnuSetVoltageLimited.Click += new System.EventHandler(this.mnuSetVoltageLimited_Click);
            // 
            // mnuSetAgvModelSet
            // 
            this.mnuSetAgvModelSet.Name = "mnuSetAgvModelSet";
            this.mnuSetAgvModelSet.Size = new System.Drawing.Size(254, 24);
            this.mnuSetAgvModelSet.Text = "Agv Model";
            this.mnuSetAgvModelSet.Click += new System.EventHandler(this.mnuSetAgvModelSet_Click);
            // 
            // mnuSetPassEnable
            // 
            this.mnuSetPassEnable.Name = "mnuSetPassEnable";
            this.mnuSetPassEnable.Size = new System.Drawing.Size(254, 24);
            this.mnuSetPassEnable.Text = "rfid List Update";
            this.mnuSetPassEnable.Click += new System.EventHandler(this.mnuSetPassEnable_Click);
            // 
            // mnuSetReceiveMesTask
            // 
            this.mnuSetReceiveMesTask.CheckOnClick = true;
            this.mnuSetReceiveMesTask.Name = "mnuSetReceiveMesTask";
            this.mnuSetReceiveMesTask.Size = new System.Drawing.Size(254, 24);
            this.mnuSetReceiveMesTask.Text = "Receive Task";
            this.mnuSetReceiveMesTask.Click += new System.EventHandler(this.mnuSetReceiveMesTask_Click);
            // 
            // testTaskToolStripMenuItem
            // 
            this.testTaskToolStripMenuItem.Name = "testTaskToolStripMenuItem";
            this.testTaskToolStripMenuItem.Size = new System.Drawing.Size(254, 24);
            this.testTaskToolStripMenuItem.Text = "TestTask";
            this.testTaskToolStripMenuItem.Click += new System.EventHandler(this.testTaskToolStripMenuItem_Click);
            // 
            // mnuSetSaveParameter
            // 
            this.mnuSetSaveParameter.Name = "mnuSetSaveParameter";
            this.mnuSetSaveParameter.Size = new System.Drawing.Size(254, 24);
            this.mnuSetSaveParameter.Text = "Save Init Parameter";
            this.mnuSetSaveParameter.Click += new System.EventHandler(this.mnuSetSaveParameter_Click);
            // 
            // mnuLogin
            // 
            this.mnuLogin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLgoinUser,
            this.mnuLoginChangePassword,
            this.mnuLoginAdd,
            this.mnuLoginEsc});
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.mnuLogin.Size = new System.Drawing.Size(70, 23);
            this.mnuLogin.Text = "Login(L)";
            // 
            // mnuLgoinUser
            // 
            this.mnuLgoinUser.Name = "mnuLgoinUser";
            this.mnuLgoinUser.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.U)));
            this.mnuLgoinUser.Size = new System.Drawing.Size(291, 24);
            this.mnuLgoinUser.Text = "User Login(&U)";
            this.mnuLgoinUser.Click += new System.EventHandler(this.mnuLgoinUser_Click);
            // 
            // mnuLoginChangePassword
            // 
            this.mnuLoginChangePassword.Name = "mnuLoginChangePassword";
            this.mnuLoginChangePassword.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
            this.mnuLoginChangePassword.Size = new System.Drawing.Size(291, 24);
            this.mnuLoginChangePassword.Text = "Change password(&P)";
            this.mnuLoginChangePassword.Click += new System.EventHandler(this.mnuLoginChangePassword_Click);
            // 
            // mnuLoginAdd
            // 
            this.mnuLoginAdd.Name = "mnuLoginAdd";
            this.mnuLoginAdd.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.mnuLoginAdd.Size = new System.Drawing.Size(291, 24);
            this.mnuLoginAdd.Text = "Add user(A)";
            this.mnuLoginAdd.Click += new System.EventHandler(this.mnuLoginAdd_Click);
            // 
            // mnuLoginEsc
            // 
            this.mnuLoginEsc.Name = "mnuLoginEsc";
            this.mnuLoginEsc.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.mnuLoginEsc.Size = new System.Drawing.Size(291, 24);
            this.mnuLoginEsc.Text = "Log out(&E)";
            this.mnuLoginEsc.Click += new System.EventHandler(this.mnuLoginEsc_Click);
            // 
            // mnuInitSet
            // 
            this.mnuInitSet.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInitSetTab,
            this.mnuInitSetAdmin});
            this.mnuInitSet.Name = "mnuInitSet";
            this.mnuInitSet.Size = new System.Drawing.Size(124, 23);
            this.mnuInitSet.Text = "Default Setting(I)";
            // 
            // mnuInitSetTab
            // 
            this.mnuInitSetTab.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInitSetTabMap,
            this.mnuInitSetTabQueryTask,
            this.mnuInitSetTabQueryAbnormal,
            this.mnuInitSetTabConfig});
            this.mnuInitSetTab.Name = "mnuInitSetTab";
            this.mnuInitSetTab.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.mnuInitSetTab.Size = new System.Drawing.Size(276, 24);
            this.mnuInitSetTab.Text = "Show items(&S)";
            // 
            // mnuInitSetTabMap
            // 
            this.mnuInitSetTabMap.Checked = true;
            this.mnuInitSetTabMap.CheckOnClick = true;
            this.mnuInitSetTabMap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuInitSetTabMap.Name = "mnuInitSetTabMap";
            this.mnuInitSetTabMap.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.M)));
            this.mnuInitSetTabMap.Size = new System.Drawing.Size(241, 24);
            this.mnuInitSetTabMap.Text = "Map";
            this.mnuInitSetTabMap.Click += new System.EventHandler(this.mnuInitSetTabMap_Click);
            // 
            // mnuInitSetTabQueryTask
            // 
            this.mnuInitSetTabQueryTask.CheckOnClick = true;
            this.mnuInitSetTabQueryTask.Name = "mnuInitSetTabQueryTask";
            this.mnuInitSetTabQueryTask.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.T)));
            this.mnuInitSetTabQueryTask.Size = new System.Drawing.Size(241, 24);
            this.mnuInitSetTabQueryTask.Text = "Task Record";
            this.mnuInitSetTabQueryTask.Click += new System.EventHandler(this.mnuInitSetTabQueryTask_Click);
            // 
            // mnuInitSetTabQueryAbnormal
            // 
            this.mnuInitSetTabQueryAbnormal.CheckOnClick = true;
            this.mnuInitSetTabQueryAbnormal.Name = "mnuInitSetTabQueryAbnormal";
            this.mnuInitSetTabQueryAbnormal.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Q)));
            this.mnuInitSetTabQueryAbnormal.Size = new System.Drawing.Size(241, 24);
            this.mnuInitSetTabQueryAbnormal.Text = "Error Record";
            this.mnuInitSetTabQueryAbnormal.Click += new System.EventHandler(this.mnuInitSetTabQuery_Click);
            // 
            // mnuInitSetTabConfig
            // 
            this.mnuInitSetTabConfig.CheckOnClick = true;
            this.mnuInitSetTabConfig.Name = "mnuInitSetTabConfig";
            this.mnuInitSetTabConfig.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.C)));
            this.mnuInitSetTabConfig.Size = new System.Drawing.Size(241, 24);
            this.mnuInitSetTabConfig.Text = "Configuration";
            this.mnuInitSetTabConfig.Click += new System.EventHandler(this.mnuInitSetTabConfig_Click);
            // 
            // mnuInitSetAdmin
            // 
            this.mnuInitSetAdmin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInitSetAdminManageUser,
            this.mnuInitSetAdminRfidSet,
            this.mnuInitSetAdminStationSet,
            this.mnuInitSetAdminStationHide,
            this.mnuInitSetIsDynPwd});
            this.mnuInitSetAdmin.Name = "mnuInitSetAdmin";
            this.mnuInitSetAdmin.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.M)));
            this.mnuInitSetAdmin.Size = new System.Drawing.Size(276, 24);
            this.mnuInitSetAdmin.Text = "Administrator(&M)";
            // 
            // mnuInitSetAdminManageUser
            // 
            this.mnuInitSetAdminManageUser.Name = "mnuInitSetAdminManageUser";
            this.mnuInitSetAdminManageUser.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.M)));
            this.mnuInitSetAdminManageUser.Size = new System.Drawing.Size(275, 24);
            this.mnuInitSetAdminManageUser.Text = "User Management";
            this.mnuInitSetAdminManageUser.Click += new System.EventHandler(this.mnuInitSetAdminManageUser_Click);
            // 
            // mnuInitSetAdminRfidSet
            // 
            this.mnuInitSetAdminRfidSet.CheckOnClick = true;
            this.mnuInitSetAdminRfidSet.Name = "mnuInitSetAdminRfidSet";
            this.mnuInitSetAdminRfidSet.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.R)));
            this.mnuInitSetAdminRfidSet.Size = new System.Drawing.Size(275, 24);
            this.mnuInitSetAdminRfidSet.Text = "Rfid Setting";
            this.mnuInitSetAdminRfidSet.Click += new System.EventHandler(this.mnuInitSetAdminRfidSet_Click);
            // 
            // mnuInitSetAdminStationSet
            // 
            this.mnuInitSetAdminStationSet.CheckOnClick = true;
            this.mnuInitSetAdminStationSet.Name = "mnuInitSetAdminStationSet";
            this.mnuInitSetAdminStationSet.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.mnuInitSetAdminStationSet.Size = new System.Drawing.Size(275, 24);
            this.mnuInitSetAdminStationSet.Text = "Site Setting";
            this.mnuInitSetAdminStationSet.Click += new System.EventHandler(this.mnuInitSetAdminStationSet_Click);
            // 
            // mnuInitSetAdminStationHide
            // 
            this.mnuInitSetAdminStationHide.CheckOnClick = true;
            this.mnuInitSetAdminStationHide.Name = "mnuInitSetAdminStationHide";
            this.mnuInitSetAdminStationHide.Size = new System.Drawing.Size(275, 24);
            this.mnuInitSetAdminStationHide.Text = "Site Visible";
            this.mnuInitSetAdminStationHide.Click += new System.EventHandler(this.mnuInitSetAdminStationHide_Click);
            // 
            // mnuInitSetIsDynPwd
            // 
            this.mnuInitSetIsDynPwd.CheckOnClick = true;
            this.mnuInitSetIsDynPwd.Name = "mnuInitSetIsDynPwd";
            this.mnuInitSetIsDynPwd.Size = new System.Drawing.Size(275, 24);
            this.mnuInitSetIsDynPwd.Text = "Dynamic Password";
            this.mnuInitSetIsDynPwd.Click += new System.EventHandler(this.mnuInitSetIsDynPwd_Click);
            // 
            // mnuVersion
            // 
            this.mnuVersion.Name = "mnuVersion";
            this.mnuVersion.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
            this.mnuVersion.Size = new System.Drawing.Size(83, 23);
            this.mnuVersion.Text = "Version(V)";
            this.mnuVersion.Click += new System.EventHandler(this.mnuVersion_Click);
            // 
            // mnuWorkMode
            // 
            this.mnuWorkMode.AutoSize = false;
            this.mnuWorkMode.Name = "mnuWorkMode";
            this.mnuWorkMode.Size = new System.Drawing.Size(80, 23);
            this.mnuWorkMode.Click += new System.EventHandler(this.mnuWorkMode_Click);
            // 
            // mnuAgvInit
            // 
            this.mnuAgvInit.Name = "mnuAgvInit";
            this.mnuAgvInit.Size = new System.Drawing.Size(73, 23);
            this.mnuAgvInit.Text = "AGV Init";
            this.mnuAgvInit.Click += new System.EventHandler(this.mnuAgvInit_Click);
            // 
            // tabMain
            // 
            this.tabMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabMain.Controls.Add(this.tabpMap);
            this.tabMain.Controls.Add(this.tabpTask);
            this.tabMain.Controls.Add(this.tabpQueryAbnormal);
            this.tabMain.Controls.Add(this.tabpConfig);
            this.tabMain.Controls.Add(this.tabpState);
            this.tabMain.Controls.Add(this.tabpTaskState);
            this.tabMain.Controls.Add(this.tabpDoor);
            this.tabMain.Controls.Add(this.tabpControlState);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabMain.HotTrack = true;
            this.tabMain.Location = new System.Drawing.Point(0, 27);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1817, 884);
            this.tabMain.TabIndex = 1;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            this.tabMain.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabMain_Selected);
            // 
            // tabpMap
            // 
            this.tabpMap.BackColor = System.Drawing.SystemColors.Control;
            this.tabpMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabpMap.Controls.Add(this.panTabMap);
            this.tabpMap.Location = new System.Drawing.Point(4, 31);
            this.tabpMap.Name = "tabpMap";
            this.tabpMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabpMap.Size = new System.Drawing.Size(1809, 849);
            this.tabpMap.TabIndex = 0;
            this.tabpMap.Text = "Map";
            // 
            // panTabMap
            // 
            this.panTabMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTabMap.BackColor = System.Drawing.Color.White;
            this.panTabMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panTabMap.Location = new System.Drawing.Point(0, 0);
            this.panTabMap.Name = "panTabMap";
            this.panTabMap.Size = new System.Drawing.Size(1664, 670);
            this.panTabMap.TabIndex = 0;
            this.panTabMap.Resize += new System.EventHandler(this.panTabMap_Resize);
            // 
            // tabpTask
            // 
            this.tabpTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabpTask.Controls.Add(this.dgvSqlTaskData);
            this.tabpTask.Controls.Add(this.panQueryTaskTitle);
            this.tabpTask.Location = new System.Drawing.Point(4, 31);
            this.tabpTask.Name = "tabpTask";
            this.tabpTask.Size = new System.Drawing.Size(1809, 849);
            this.tabpTask.TabIndex = 3;
            this.tabpTask.Text = "Task record";
            this.tabpTask.UseVisualStyleBackColor = true;
            // 
            // dgvSqlTaskData
            // 
            this.dgvSqlTaskData.AllowUserToAddRows = false;
            this.dgvSqlTaskData.BackgroundColor = System.Drawing.Color.White;
            this.dgvSqlTaskData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSqlTaskData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSqlTaskData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSqlTaskData.Location = new System.Drawing.Point(0, 26);
            this.dgvSqlTaskData.Name = "dgvSqlTaskData";
            this.dgvSqlTaskData.ReadOnly = true;
            this.dgvSqlTaskData.RowTemplate.Height = 23;
            this.dgvSqlTaskData.Size = new System.Drawing.Size(1807, 821);
            this.dgvSqlTaskData.TabIndex = 7;
            this.dgvSqlTaskData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSqlTaskData_CellDoubleClick);
            // 
            // panQueryTaskTitle
            // 
            this.panQueryTaskTitle.BackColor = System.Drawing.Color.White;
            this.panQueryTaskTitle.Controls.Add(this.pbQueryTask);
            this.panQueryTaskTitle.Controls.Add(this.lblQueryTaskShow);
            this.panQueryTaskTitle.Controls.Add(this.lblTaskCount);
            this.panQueryTaskTitle.Controls.Add(this.chbTaskMes);
            this.panQueryTaskTitle.Controls.Add(this.chbTaskDateSelect);
            this.panQueryTaskTitle.Controls.Add(this.dtTaskBegin);
            this.panQueryTaskTitle.Controls.Add(this.label3);
            this.panQueryTaskTitle.Controls.Add(this.dtTaskEnd);
            this.panQueryTaskTitle.Controls.Add(this.panel93);
            this.panQueryTaskTitle.Controls.Add(this.cbQueryTaskTaskType);
            this.panQueryTaskTitle.Controls.Add(this.label87);
            this.panQueryTaskTitle.Controls.Add(this.btnDeleteTask);
            this.panQueryTaskTitle.Controls.Add(this.cbQueryTaskLineNo);
            this.panQueryTaskTitle.Controls.Add(this.lblQueryTaskLineNo);
            this.panQueryTaskTitle.Controls.Add(this.btnQueryTask);
            this.panQueryTaskTitle.Controls.Add(this.btnTaskExport);
            this.panQueryTaskTitle.Controls.Add(this.cbQueryTaskAgvNo);
            this.panQueryTaskTitle.Controls.Add(this.lblQueryTaskAgvNo);
            this.panQueryTaskTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panQueryTaskTitle.Location = new System.Drawing.Point(0, 0);
            this.panQueryTaskTitle.Name = "panQueryTaskTitle";
            this.panQueryTaskTitle.Size = new System.Drawing.Size(1807, 26);
            this.panQueryTaskTitle.TabIndex = 6;
            // 
            // pbQueryTask
            // 
            this.pbQueryTask.Location = new System.Drawing.Point(1060, 2);
            this.pbQueryTask.Name = "pbQueryTask";
            this.pbQueryTask.Size = new System.Drawing.Size(153, 21);
            this.pbQueryTask.TabIndex = 22;
            this.pbQueryTask.Visible = false;
            // 
            // lblQueryTaskShow
            // 
            this.lblQueryTaskShow.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryTaskShow.Location = new System.Drawing.Point(837, 4);
            this.lblQueryTaskShow.Name = "lblQueryTaskShow";
            this.lblQueryTaskShow.Size = new System.Drawing.Size(217, 18);
            this.lblQueryTaskShow.TabIndex = 21;
            this.lblQueryTaskShow.Text = "The data is loading...";
            this.lblQueryTaskShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblQueryTaskShow.Visible = false;
            // 
            // lblTaskCount
            // 
            this.lblTaskCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTaskCount.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTaskCount.Location = new System.Drawing.Point(744, 0);
            this.lblTaskCount.Name = "lblTaskCount";
            this.lblTaskCount.Size = new System.Drawing.Size(100, 26);
            this.lblTaskCount.TabIndex = 20;
            this.lblTaskCount.Text = "count:";
            this.lblTaskCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chbTaskMes
            // 
            this.chbTaskMes.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbTaskMes.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbTaskMes.Location = new System.Drawing.Point(600, 0);
            this.chbTaskMes.Name = "chbTaskMes";
            this.chbTaskMes.Size = new System.Drawing.Size(144, 26);
            this.chbTaskMes.TabIndex = 19;
            this.chbTaskMes.Text = "只查询MES任务";
            this.chbTaskMes.UseVisualStyleBackColor = true;
            this.chbTaskMes.Visible = false;
            // 
            // chbTaskDateSelect
            // 
            this.chbTaskDateSelect.AutoSize = true;
            this.chbTaskDateSelect.Checked = true;
            this.chbTaskDateSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTaskDateSelect.Dock = System.Windows.Forms.DockStyle.Right;
            this.chbTaskDateSelect.Location = new System.Drawing.Point(1239, 0);
            this.chbTaskDateSelect.Name = "chbTaskDateSelect";
            this.chbTaskDateSelect.Size = new System.Drawing.Size(15, 26);
            this.chbTaskDateSelect.TabIndex = 5;
            this.chbTaskDateSelect.UseVisualStyleBackColor = true;
            // 
            // dtTaskBegin
            // 
            this.dtTaskBegin.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtTaskBegin.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtTaskBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTaskBegin.Location = new System.Drawing.Point(1254, 0);
            this.dtTaskBegin.Name = "dtTaskBegin";
            this.dtTaskBegin.Size = new System.Drawing.Size(110, 25);
            this.dtTaskBegin.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(1364, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "~";
            // 
            // dtTaskEnd
            // 
            this.dtTaskEnd.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtTaskEnd.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtTaskEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTaskEnd.Location = new System.Drawing.Point(1380, 0);
            this.dtTaskEnd.Name = "dtTaskEnd";
            this.dtTaskEnd.Size = new System.Drawing.Size(110, 25);
            this.dtTaskEnd.TabIndex = 2;
            // 
            // panel93
            // 
            this.panel93.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel93.Location = new System.Drawing.Point(1490, 0);
            this.panel93.Name = "panel93";
            this.panel93.Size = new System.Drawing.Size(92, 26);
            this.panel93.TabIndex = 18;
            // 
            // cbQueryTaskTaskType
            // 
            this.cbQueryTaskTaskType.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbQueryTaskTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQueryTaskTaskType.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbQueryTaskTaskType.FormattingEnabled = true;
            this.cbQueryTaskTaskType.Location = new System.Drawing.Point(479, 0);
            this.cbQueryTaskTaskType.Name = "cbQueryTaskTaskType";
            this.cbQueryTaskTaskType.Size = new System.Drawing.Size(121, 23);
            this.cbQueryTaskTaskType.TabIndex = 16;
            // 
            // label87
            // 
            this.label87.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label87.Dock = System.Windows.Forms.DockStyle.Left;
            this.label87.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label87.Location = new System.Drawing.Point(395, 0);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(84, 26);
            this.label87.TabIndex = 17;
            this.label87.Text = "Task type:";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDeleteTask.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDeleteTask.Location = new System.Drawing.Point(1582, 0);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(75, 26);
            this.btnDeleteTask.TabIndex = 15;
            this.btnDeleteTask.Text = "Delete";
            this.btnDeleteTask.UseVisualStyleBackColor = true;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // cbQueryTaskLineNo
            // 
            this.cbQueryTaskLineNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbQueryTaskLineNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQueryTaskLineNo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbQueryTaskLineNo.FormattingEnabled = true;
            this.cbQueryTaskLineNo.Items.AddRange(new object[] {
            "All",
            "Agv type1",
            "Agv type2"});
            this.cbQueryTaskLineNo.Location = new System.Drawing.Point(274, 0);
            this.cbQueryTaskLineNo.Name = "cbQueryTaskLineNo";
            this.cbQueryTaskLineNo.Size = new System.Drawing.Size(121, 23);
            this.cbQueryTaskLineNo.TabIndex = 9;
            this.cbQueryTaskLineNo.SelectedIndexChanged += new System.EventHandler(this.cbQueryTaskLineNo_SelectedIndexChanged);
            // 
            // lblQueryTaskLineNo
            // 
            this.lblQueryTaskLineNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQueryTaskLineNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQueryTaskLineNo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryTaskLineNo.Location = new System.Drawing.Point(182, 0);
            this.lblQueryTaskLineNo.Name = "lblQueryTaskLineNo";
            this.lblQueryTaskLineNo.Size = new System.Drawing.Size(92, 26);
            this.lblQueryTaskLineNo.TabIndex = 10;
            this.lblQueryTaskLineNo.Text = "Agv type:";
            this.lblQueryTaskLineNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQueryTask
            // 
            this.btnQueryTask.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnQueryTask.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQueryTask.Location = new System.Drawing.Point(1657, 0);
            this.btnQueryTask.Name = "btnQueryTask";
            this.btnQueryTask.Size = new System.Drawing.Size(75, 26);
            this.btnQueryTask.TabIndex = 7;
            this.btnQueryTask.Text = "Query";
            this.btnQueryTask.UseVisualStyleBackColor = true;
            this.btnQueryTask.Click += new System.EventHandler(this.btnQueryTask_Click);
            // 
            // btnTaskExport
            // 
            this.btnTaskExport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnTaskExport.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnTaskExport.Location = new System.Drawing.Point(1732, 0);
            this.btnTaskExport.Name = "btnTaskExport";
            this.btnTaskExport.Size = new System.Drawing.Size(75, 26);
            this.btnTaskExport.TabIndex = 8;
            this.btnTaskExport.Text = "Export";
            this.btnTaskExport.UseVisualStyleBackColor = true;
            this.btnTaskExport.Click += new System.EventHandler(this.btnTaskExport_Click);
            // 
            // cbQueryTaskAgvNo
            // 
            this.cbQueryTaskAgvNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbQueryTaskAgvNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQueryTaskAgvNo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbQueryTaskAgvNo.FormattingEnabled = true;
            this.cbQueryTaskAgvNo.Items.AddRange(new object[] {
            "任务信息",
            "异常信息",
            "错误信息",
            "操作记录"});
            this.cbQueryTaskAgvNo.Location = new System.Drawing.Point(98, 0);
            this.cbQueryTaskAgvNo.Name = "cbQueryTaskAgvNo";
            this.cbQueryTaskAgvNo.Size = new System.Drawing.Size(84, 23);
            this.cbQueryTaskAgvNo.TabIndex = 4;
            // 
            // lblQueryTaskAgvNo
            // 
            this.lblQueryTaskAgvNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQueryTaskAgvNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblQueryTaskAgvNo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryTaskAgvNo.Location = new System.Drawing.Point(0, 0);
            this.lblQueryTaskAgvNo.Name = "lblQueryTaskAgvNo";
            this.lblQueryTaskAgvNo.Size = new System.Drawing.Size(98, 26);
            this.lblQueryTaskAgvNo.TabIndex = 4;
            this.lblQueryTaskAgvNo.Text = "Agv Number:";
            this.lblQueryTaskAgvNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabpQueryAbnormal
            // 
            this.tabpQueryAbnormal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabpQueryAbnormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabpQueryAbnormal.Controls.Add(this.dgvSqlData);
            this.tabpQueryAbnormal.Controls.Add(this.panQueryAbnormalTitle);
            this.tabpQueryAbnormal.Location = new System.Drawing.Point(4, 31);
            this.tabpQueryAbnormal.Name = "tabpQueryAbnormal";
            this.tabpQueryAbnormal.Padding = new System.Windows.Forms.Padding(3);
            this.tabpQueryAbnormal.Size = new System.Drawing.Size(1809, 849);
            this.tabpQueryAbnormal.TabIndex = 1;
            this.tabpQueryAbnormal.Text = "Error record";
            this.tabpQueryAbnormal.UseVisualStyleBackColor = true;
            // 
            // dgvSqlData
            // 
            this.dgvSqlData.AllowUserToAddRows = false;
            this.dgvSqlData.BackgroundColor = System.Drawing.Color.White;
            this.dgvSqlData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSqlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSqlData.Location = new System.Drawing.Point(3, 36);
            this.dgvSqlData.Name = "dgvSqlData";
            this.dgvSqlData.ReadOnly = true;
            this.dgvSqlData.RowTemplate.Height = 23;
            this.dgvSqlData.Size = new System.Drawing.Size(1801, 808);
            this.dgvSqlData.TabIndex = 5;
            // 
            // panQueryAbnormalTitle
            // 
            this.panQueryAbnormalTitle.BackColor = System.Drawing.Color.White;
            this.panQueryAbnormalTitle.Controls.Add(this.pbAbn);
            this.panQueryAbnormalTitle.Controls.Add(this.lblAbnWaitShow);
            this.panQueryAbnormalTitle.Controls.Add(this.btnDelete);
            this.panQueryAbnormalTitle.Controls.Add(this.txtQueryAbnormalRfid);
            this.panQueryAbnormalTitle.Controls.Add(this.lblQueryAbnormalRfid);
            this.panQueryAbnormalTitle.Controls.Add(this.lblQueryAbnormalInfo);
            this.panQueryAbnormalTitle.Controls.Add(this.cbQueryAbnormalInfo);
            this.panQueryAbnormalTitle.Controls.Add(this.btnExport);
            this.panQueryAbnormalTitle.Controls.Add(this.btnQuery);
            this.panQueryAbnormalTitle.Controls.Add(this.lblAnd);
            this.panQueryAbnormalTitle.Controls.Add(this.chbDateSelect);
            this.panQueryAbnormalTitle.Controls.Add(this.lblQueryAbnormalAgvNo);
            this.panQueryAbnormalTitle.Controls.Add(this.cbQueryAbnormalAgvNo);
            this.panQueryAbnormalTitle.Controls.Add(this.dtpEnd);
            this.panQueryAbnormalTitle.Controls.Add(this.dtpBegin);
            this.panQueryAbnormalTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panQueryAbnormalTitle.Location = new System.Drawing.Point(3, 3);
            this.panQueryAbnormalTitle.Name = "panQueryAbnormalTitle";
            this.panQueryAbnormalTitle.Size = new System.Drawing.Size(1801, 33);
            this.panQueryAbnormalTitle.TabIndex = 4;
            // 
            // pbAbn
            // 
            this.pbAbn.Location = new System.Drawing.Point(1116, 7);
            this.pbAbn.Name = "pbAbn";
            this.pbAbn.Size = new System.Drawing.Size(153, 21);
            this.pbAbn.TabIndex = 16;
            this.pbAbn.Visible = false;
            // 
            // lblAbnWaitShow
            // 
            this.lblAbnWaitShow.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAbnWaitShow.Location = new System.Drawing.Point(893, 9);
            this.lblAbnWaitShow.Name = "lblAbnWaitShow";
            this.lblAbnWaitShow.Size = new System.Drawing.Size(217, 18);
            this.lblAbnWaitShow.TabIndex = 15;
            this.lblAbnWaitShow.Text = "The data is loading...";
            this.lblAbnWaitShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAbnWaitShow.Visible = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Location = new System.Drawing.Point(1510, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtQueryAbnormalRfid
            // 
            this.txtQueryAbnormalRfid.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtQueryAbnormalRfid.Location = new System.Drawing.Point(502, 3);
            this.txtQueryAbnormalRfid.MaxLength = 3;
            this.txtQueryAbnormalRfid.Name = "txtQueryAbnormalRfid";
            this.txtQueryAbnormalRfid.Size = new System.Drawing.Size(75, 25);
            this.txtQueryAbnormalRfid.TabIndex = 13;
            this.txtQueryAbnormalRfid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQueryAbnormalRfid_KeyPress);
            // 
            // lblQueryAbnormalRfid
            // 
            this.lblQueryAbnormalRfid.AutoSize = true;
            this.lblQueryAbnormalRfid.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryAbnormalRfid.Location = new System.Drawing.Point(426, 9);
            this.lblQueryAbnormalRfid.Name = "lblQueryAbnormalRfid";
            this.lblQueryAbnormalRfid.Size = new System.Drawing.Size(48, 16);
            this.lblQueryAbnormalRfid.TabIndex = 12;
            this.lblQueryAbnormalRfid.Text = "Rfid:";
            // 
            // lblQueryAbnormalInfo
            // 
            this.lblQueryAbnormalInfo.AutoSize = true;
            this.lblQueryAbnormalInfo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryAbnormalInfo.Location = new System.Drawing.Point(197, 9);
            this.lblQueryAbnormalInfo.Name = "lblQueryAbnormalInfo";
            this.lblQueryAbnormalInfo.Size = new System.Drawing.Size(96, 16);
            this.lblQueryAbnormalInfo.TabIndex = 10;
            this.lblQueryAbnormalInfo.Text = "Error type:";
            // 
            // cbQueryAbnormalInfo
            // 
            this.cbQueryAbnormalInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQueryAbnormalInfo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbQueryAbnormalInfo.FormattingEnabled = true;
            this.cbQueryAbnormalInfo.Location = new System.Drawing.Point(288, 3);
            this.cbQueryAbnormalInfo.Name = "cbQueryAbnormalInfo";
            this.cbQueryAbnormalInfo.Size = new System.Drawing.Size(121, 23);
            this.cbQueryAbnormalInfo.TabIndex = 9;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Location = new System.Drawing.Point(1708, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 25);
            this.btnExport.TabIndex = 8;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuery.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(1609, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 25);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lblAnd
            // 
            this.lblAnd.AutoSize = true;
            this.lblAnd.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAnd.Location = new System.Drawing.Point(735, 8);
            this.lblAnd.Name = "lblAnd";
            this.lblAnd.Size = new System.Drawing.Size(16, 16);
            this.lblAnd.TabIndex = 6;
            this.lblAnd.Text = "~";
            // 
            // chbDateSelect
            // 
            this.chbDateSelect.AutoSize = true;
            this.chbDateSelect.Checked = true;
            this.chbDateSelect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbDateSelect.Location = new System.Drawing.Point(593, 8);
            this.chbDateSelect.Name = "chbDateSelect";
            this.chbDateSelect.Size = new System.Drawing.Size(15, 14);
            this.chbDateSelect.TabIndex = 5;
            this.chbDateSelect.UseVisualStyleBackColor = true;
            // 
            // lblQueryAbnormalAgvNo
            // 
            this.lblQueryAbnormalAgvNo.AutoSize = true;
            this.lblQueryAbnormalAgvNo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblQueryAbnormalAgvNo.Location = new System.Drawing.Point(6, 9);
            this.lblQueryAbnormalAgvNo.Name = "lblQueryAbnormalAgvNo";
            this.lblQueryAbnormalAgvNo.Size = new System.Drawing.Size(96, 16);
            this.lblQueryAbnormalAgvNo.TabIndex = 4;
            this.lblQueryAbnormalAgvNo.Text = "Agv number:";
            // 
            // cbQueryAbnormalAgvNo
            // 
            this.cbQueryAbnormalAgvNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQueryAbnormalAgvNo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbQueryAbnormalAgvNo.FormattingEnabled = true;
            this.cbQueryAbnormalAgvNo.Items.AddRange(new object[] {
            "任务信息",
            "异常信息",
            "错误信息",
            "操作记录"});
            this.cbQueryAbnormalAgvNo.Location = new System.Drawing.Point(91, 3);
            this.cbQueryAbnormalAgvNo.Name = "cbQueryAbnormalAgvNo";
            this.cbQueryAbnormalAgvNo.Size = new System.Drawing.Size(93, 23);
            this.cbQueryAbnormalAgvNo.TabIndex = 4;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(757, 2);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(110, 25);
            this.dtpEnd.TabIndex = 2;
            // 
            // dtpBegin
            // 
            this.dtpBegin.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBegin.Location = new System.Drawing.Point(614, 2);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(110, 25);
            this.dtpBegin.TabIndex = 1;
            // 
            // tabpConfig
            // 
            this.tabpConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabpConfig.Controls.Add(this.tabConfig);
            this.tabpConfig.Location = new System.Drawing.Point(4, 31);
            this.tabpConfig.Name = "tabpConfig";
            this.tabpConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabpConfig.Size = new System.Drawing.Size(1809, 849);
            this.tabpConfig.TabIndex = 2;
            this.tabpConfig.Text = "Configuration";
            this.tabpConfig.UseVisualStyleBackColor = true;
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.tabConfigAgvInfo);
            this.tabConfig.Controls.Add(this.tabConfigMapSet);
            this.tabConfig.Controls.Add(this.tabConfigSql);
            this.tabConfig.Controls.Add(this.tabConfigBasic);
            this.tabConfig.Controls.Add(this.tabConfigStation);
            this.tabConfig.Controls.Add(this.tabConfigCharge);
            this.tabConfig.Controls.Add(this.tabConfigElevator);
            this.tabConfig.Controls.Add(this.tabConfigShutterDoor);
            this.tabConfig.Controls.Add(this.tabConfigCapacityTest);
            this.tabConfig.Controls.Add(this.tabConfigBurnInRoom);
            this.tabConfig.Controls.Add(this.tabConfigTest);
            this.tabConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabConfig.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabConfig.Location = new System.Drawing.Point(3, 3);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.SelectedIndex = 0;
            this.tabConfig.Size = new System.Drawing.Size(1801, 841);
            this.tabConfig.TabIndex = 0;
            this.tabConfig.SelectedIndexChanged += new System.EventHandler(this.tabConfig_SelectedIndexChanged);
            // 
            // tabConfigAgvInfo
            // 
            this.tabConfigAgvInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tabConfigAgvInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabConfigAgvInfo.Controls.Add(this.panTabConfigAgvInfo);
            this.tabConfigAgvInfo.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabConfigAgvInfo.Location = new System.Drawing.Point(4, 25);
            this.tabConfigAgvInfo.Name = "tabConfigAgvInfo";
            this.tabConfigAgvInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfigAgvInfo.Size = new System.Drawing.Size(1793, 812);
            this.tabConfigAgvInfo.TabIndex = 0;
            this.tabConfigAgvInfo.Text = "Agv Configuration";
            this.tabConfigAgvInfo.UseVisualStyleBackColor = true;
            // 
            // panTabConfigAgvInfo
            // 
            this.panTabConfigAgvInfo.BackColor = System.Drawing.Color.Transparent;
            this.panTabConfigAgvInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panTabConfigAgvInfo.Controls.Add(this.panTabConfigAgvInfoList);
            this.panTabConfigAgvInfo.Controls.Add(this.panTabConfigAgvInfoAdd);
            this.panTabConfigAgvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTabConfigAgvInfo.Location = new System.Drawing.Point(3, 3);
            this.panTabConfigAgvInfo.Name = "panTabConfigAgvInfo";
            this.panTabConfigAgvInfo.Size = new System.Drawing.Size(1787, 806);
            this.panTabConfigAgvInfo.TabIndex = 0;
            // 
            // panTabConfigAgvInfoList
            // 
            this.panTabConfigAgvInfoList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panTabConfigAgvInfoList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panTabConfigAgvInfoList.Controls.Add(this.btnRestThread);
            this.panTabConfigAgvInfoList.Controls.Add(this.btnAgvComInfoObtain);
            this.panTabConfigAgvInfoList.Controls.Add(this.dgvAgvInfo);
            this.panTabConfigAgvInfoList.Controls.Add(this.lblAgvConfigList);
            this.panTabConfigAgvInfoList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTabConfigAgvInfoList.Location = new System.Drawing.Point(0, 86);
            this.panTabConfigAgvInfoList.Name = "panTabConfigAgvInfoList";
            this.panTabConfigAgvInfoList.Size = new System.Drawing.Size(1787, 720);
            this.panTabConfigAgvInfoList.TabIndex = 5;
            // 
            // btnRestThread
            // 
            this.btnRestThread.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestThread.Location = new System.Drawing.Point(1233, 12);
            this.btnRestThread.Name = "btnRestThread";
            this.btnRestThread.Size = new System.Drawing.Size(94, 28);
            this.btnRestThread.TabIndex = 11;
            this.btnRestThread.Text = "重启连接";
            this.btnRestThread.UseVisualStyleBackColor = true;
            this.btnRestThread.Visible = false;
            this.btnRestThread.Click += new System.EventHandler(this.btnRestThread_Click);
            // 
            // btnAgvComInfoObtain
            // 
            this.btnAgvComInfoObtain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgvComInfoObtain.Location = new System.Drawing.Point(1681, 12);
            this.btnAgvComInfoObtain.Name = "btnAgvComInfoObtain";
            this.btnAgvComInfoObtain.Size = new System.Drawing.Size(87, 28);
            this.btnAgvComInfoObtain.TabIndex = 10;
            this.btnAgvComInfoObtain.Text = "Receive";
            this.btnAgvComInfoObtain.UseVisualStyleBackColor = true;
            this.btnAgvComInfoObtain.Click += new System.EventHandler(this.btnAgvComInfoObtain_Click);
            // 
            // dgvAgvInfo
            // 
            this.dgvAgvInfo.AllowUserToAddRows = false;
            this.dgvAgvInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAgvInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgvInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cTxtAgvId,
            this.cTxtDescription,
            this.cTxtAgvAddress,
            this.cTxtAgvNetNo,
            this.cTxtLocalPort,
            this.cTxtDesPort,
            this.cCbAgvConnectType,
            this.cCbAgvCommonType,
            this.cCbIsUsing,
            this.cCbDelete,
            this.cCbChange});
            this.dgvAgvInfo.Location = new System.Drawing.Point(0, 47);
            this.dgvAgvInfo.Name = "dgvAgvInfo";
            this.dgvAgvInfo.RowTemplate.Height = 23;
            this.dgvAgvInfo.Size = new System.Drawing.Size(1783, 669);
            this.dgvAgvInfo.TabIndex = 10;
            this.dgvAgvInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAgvInfo_CellClick);
            // 
            // cTxtAgvId
            // 
            this.cTxtAgvId.HeaderText = "AgvId";
            this.cTxtAgvId.Name = "cTxtAgvId";
            this.cTxtAgvId.ReadOnly = true;
            // 
            // cTxtDescription
            // 
            this.cTxtDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cTxtDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.cTxtDescription.FillWeight = 50F;
            this.cTxtDescription.HeaderText = "Describe";
            this.cTxtDescription.MinimumWidth = 50;
            this.cTxtDescription.Name = "cTxtDescription";
            // 
            // cTxtAgvAddress
            // 
            this.cTxtAgvAddress.HeaderText = "IP Address";
            this.cTxtAgvAddress.MaxInputLength = 15;
            this.cTxtAgvAddress.Name = "cTxtAgvAddress";
            this.cTxtAgvAddress.Width = 150;
            // 
            // cTxtAgvNetNo
            // 
            this.cTxtAgvNetNo.HeaderText = "Network node";
            this.cTxtAgvNetNo.MaxInputLength = 3;
            this.cTxtAgvNetNo.Name = "cTxtAgvNetNo";
            // 
            // cTxtLocalPort
            // 
            this.cTxtLocalPort.HeaderText = "Local port";
            this.cTxtLocalPort.MaxInputLength = 5;
            this.cTxtLocalPort.Name = "cTxtLocalPort";
            // 
            // cTxtDesPort
            // 
            this.cTxtDesPort.HeaderText = "Destination port";
            this.cTxtDesPort.MaxInputLength = 5;
            this.cTxtDesPort.Name = "cTxtDesPort";
            // 
            // cCbAgvConnectType
            // 
            this.cCbAgvConnectType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cCbAgvConnectType.HeaderText = "Connect type";
            this.cCbAgvConnectType.Name = "cCbAgvConnectType";
            this.cCbAgvConnectType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cCbAgvConnectType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cCbAgvCommonType
            // 
            this.cCbAgvCommonType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cCbAgvCommonType.HeaderText = "Agv type";
            this.cCbAgvCommonType.Items.AddRange(new object[] {
            "Type1",
            "Type2",
            "Type3"});
            this.cCbAgvCommonType.Name = "cCbAgvCommonType";
            this.cCbAgvCommonType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cCbAgvCommonType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // cCbIsUsing
            // 
            this.cCbIsUsing.FalseValue = "False";
            this.cCbIsUsing.HeaderText = "Enable";
            this.cCbIsUsing.Name = "cCbIsUsing";
            this.cCbIsUsing.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cCbIsUsing.TrueValue = "True";
            this.cCbIsUsing.Width = 80;
            // 
            // cCbDelete
            // 
            this.cCbDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cCbDelete.HeaderText = "Operation";
            this.cCbDelete.Name = "cCbDelete";
            this.cCbDelete.Text = "Delete";
            this.cCbDelete.UseColumnTextForButtonValue = true;
            this.cCbDelete.Width = 60;
            // 
            // cCbChange
            // 
            this.cCbChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cCbChange.HeaderText = "Update";
            this.cCbChange.Name = "cCbChange";
            this.cCbChange.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cCbChange.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cCbChange.Text = "Modify";
            this.cCbChange.UseColumnTextForButtonValue = true;
            this.cCbChange.Width = 60;
            // 
            // lblAgvConfigList
            // 
            this.lblAgvConfigList.AutoSize = true;
            this.lblAgvConfigList.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAgvConfigList.Location = new System.Drawing.Point(13, 18);
            this.lblAgvConfigList.Name = "lblAgvConfigList";
            this.lblAgvConfigList.Size = new System.Drawing.Size(206, 16);
            this.lblAgvConfigList.TabIndex = 0;
            this.lblAgvConfigList.Text = "Agv Configuration List";
            // 
            // panTabConfigAgvInfoAdd
            // 
            this.panTabConfigAgvInfoAdd.AutoScroll = true;
            this.panTabConfigAgvInfoAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panTabConfigAgvInfoAdd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panTabConfigAgvInfoAdd.Controls.Add(this.panel2);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.cbAgvCommonType);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.label2);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.panAgvComInfoLine8);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.panAgvComInfoLine9);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.panAgvComInfoLine7);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.panAgvComInfoLine6);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.panAgvComInfoLine5);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.panAgvComInfoLine4);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.panAgvComInfoLine3);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.panAgvComInfoLine2);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.panAgvComInfoLine1);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.cbIsUsing);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.lblIsUsing);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.txtAgvInfoDescription);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.lblDescription);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.mtxtIp);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.btnAgvInfoAdd);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.cbAgvConnectType);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.lblAgvType);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.lblDesPort);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.txtAgvInfoDesPort);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.lblLocalPort);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.txtAgvInfoLocalPort);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.lblAgvNetNo);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.txtAgvInfoNetNo);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.txtAgvInfoId);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.lblAgvIpAddress);
            this.panTabConfigAgvInfoAdd.Controls.Add(this.lblAgvId);
            this.panTabConfigAgvInfoAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTabConfigAgvInfoAdd.Location = new System.Drawing.Point(0, 0);
            this.panTabConfigAgvInfoAdd.Name = "panTabConfigAgvInfoAdd";
            this.panTabConfigAgvInfoAdd.Size = new System.Drawing.Size(1787, 86);
            this.panTabConfigAgvInfoAdd.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(1132, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 82);
            this.panel2.TabIndex = 25;
            // 
            // cbAgvCommonType
            // 
            this.cbAgvCommonType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAgvCommonType.FormattingEnabled = true;
            this.cbAgvCommonType.ItemHeight = 15;
            this.cbAgvCommonType.Items.AddRange(new object[] {
            "agv type1",
            "agv type2",
            "agv type3"});
            this.cbAgvCommonType.Location = new System.Drawing.Point(1007, 42);
            this.cbAgvCommonType.Name = "cbAgvCommonType";
            this.cbAgvCommonType.Size = new System.Drawing.Size(121, 23);
            this.cbAgvCommonType.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1004, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Agv type";
            // 
            // panAgvComInfoLine8
            // 
            this.panAgvComInfoLine8.BackColor = System.Drawing.Color.White;
            this.panAgvComInfoLine8.Location = new System.Drawing.Point(895, 0);
            this.panAgvComInfoLine8.Name = "panAgvComInfoLine8";
            this.panAgvComInfoLine8.Size = new System.Drawing.Size(2, 82);
            this.panAgvComInfoLine8.TabIndex = 17;
            // 
            // panAgvComInfoLine9
            // 
            this.panAgvComInfoLine9.BackColor = System.Drawing.Color.White;
            this.panAgvComInfoLine9.Location = new System.Drawing.Point(999, 0);
            this.panAgvComInfoLine9.Name = "panAgvComInfoLine9";
            this.panAgvComInfoLine9.Size = new System.Drawing.Size(2, 82);
            this.panAgvComInfoLine9.TabIndex = 22;
            // 
            // panAgvComInfoLine7
            // 
            this.panAgvComInfoLine7.BackColor = System.Drawing.Color.White;
            this.panAgvComInfoLine7.Location = new System.Drawing.Point(772, 0);
            this.panAgvComInfoLine7.Name = "panAgvComInfoLine7";
            this.panAgvComInfoLine7.Size = new System.Drawing.Size(2, 82);
            this.panAgvComInfoLine7.TabIndex = 21;
            // 
            // panAgvComInfoLine6
            // 
            this.panAgvComInfoLine6.BackColor = System.Drawing.Color.White;
            this.panAgvComInfoLine6.Location = new System.Drawing.Point(649, 0);
            this.panAgvComInfoLine6.Name = "panAgvComInfoLine6";
            this.panAgvComInfoLine6.Size = new System.Drawing.Size(2, 82);
            this.panAgvComInfoLine6.TabIndex = 20;
            // 
            // panAgvComInfoLine5
            // 
            this.panAgvComInfoLine5.BackColor = System.Drawing.Color.White;
            this.panAgvComInfoLine5.Location = new System.Drawing.Point(536, 0);
            this.panAgvComInfoLine5.Name = "panAgvComInfoLine5";
            this.panAgvComInfoLine5.Size = new System.Drawing.Size(2, 82);
            this.panAgvComInfoLine5.TabIndex = 19;
            // 
            // panAgvComInfoLine4
            // 
            this.panAgvComInfoLine4.BackColor = System.Drawing.Color.White;
            this.panAgvComInfoLine4.Location = new System.Drawing.Point(423, 0);
            this.panAgvComInfoLine4.Name = "panAgvComInfoLine4";
            this.panAgvComInfoLine4.Size = new System.Drawing.Size(2, 82);
            this.panAgvComInfoLine4.TabIndex = 18;
            // 
            // panAgvComInfoLine3
            // 
            this.panAgvComInfoLine3.BackColor = System.Drawing.Color.White;
            this.panAgvComInfoLine3.Location = new System.Drawing.Point(299, 0);
            this.panAgvComInfoLine3.Name = "panAgvComInfoLine3";
            this.panAgvComInfoLine3.Size = new System.Drawing.Size(2, 82);
            this.panAgvComInfoLine3.TabIndex = 17;
            // 
            // panAgvComInfoLine2
            // 
            this.panAgvComInfoLine2.BackColor = System.Drawing.Color.White;
            this.panAgvComInfoLine2.Location = new System.Drawing.Point(116, 0);
            this.panAgvComInfoLine2.Name = "panAgvComInfoLine2";
            this.panAgvComInfoLine2.Size = new System.Drawing.Size(2, 82);
            this.panAgvComInfoLine2.TabIndex = 16;
            // 
            // panAgvComInfoLine1
            // 
            this.panAgvComInfoLine1.BackColor = System.Drawing.Color.White;
            this.panAgvComInfoLine1.Location = new System.Drawing.Point(0, 31);
            this.panAgvComInfoLine1.Name = "panAgvComInfoLine1";
            this.panAgvComInfoLine1.Size = new System.Drawing.Size(1135, 2);
            this.panAgvComInfoLine1.TabIndex = 15;
            // 
            // cbIsUsing
            // 
            this.cbIsUsing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsUsing.FormattingEnabled = true;
            this.cbIsUsing.ItemHeight = 15;
            this.cbIsUsing.Items.AddRange(new object[] {
            "Enable",
            "Disable"});
            this.cbIsUsing.Location = new System.Drawing.Point(905, 42);
            this.cbIsUsing.Name = "cbIsUsing";
            this.cbIsUsing.Size = new System.Drawing.Size(88, 23);
            this.cbIsUsing.TabIndex = 7;
            // 
            // lblIsUsing
            // 
            this.lblIsUsing.AutoSize = true;
            this.lblIsUsing.Location = new System.Drawing.Point(902, 10);
            this.lblIsUsing.Name = "lblIsUsing";
            this.lblIsUsing.Size = new System.Drawing.Size(56, 16);
            this.lblIsUsing.TabIndex = 14;
            this.lblIsUsing.Text = "Enable";
            // 
            // txtAgvInfoDescription
            // 
            this.txtAgvInfoDescription.Location = new System.Drawing.Point(124, 42);
            this.txtAgvInfoDescription.MaxLength = 10000;
            this.txtAgvInfoDescription.Name = "txtAgvInfoDescription";
            this.txtAgvInfoDescription.Size = new System.Drawing.Size(169, 25);
            this.txtAgvInfoDescription.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(121, 10);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(72, 16);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "Describe";
            // 
            // mtxtIp
            // 
            this.mtxtIp.Location = new System.Drawing.Point(306, 42);
            this.mtxtIp.Mask = "999.999.999.999";
            this.mtxtIp.Name = "mtxtIp";
            this.mtxtIp.PromptChar = ' ';
            this.mtxtIp.Size = new System.Drawing.Size(112, 25);
            this.mtxtIp.TabIndex = 2;
            this.mtxtIp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.mtxtIp_KeyPress);
            // 
            // btnAgvInfoAdd
            // 
            this.btnAgvInfoAdd.Location = new System.Drawing.Point(1171, 11);
            this.btnAgvInfoAdd.Name = "btnAgvInfoAdd";
            this.btnAgvInfoAdd.Size = new System.Drawing.Size(103, 56);
            this.btnAgvInfoAdd.TabIndex = 9;
            this.btnAgvInfoAdd.Text = "Add";
            this.btnAgvInfoAdd.UseVisualStyleBackColor = true;
            this.btnAgvInfoAdd.Click += new System.EventHandler(this.btnAgvInfoAdd_Click);
            // 
            // cbAgvConnectType
            // 
            this.cbAgvConnectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAgvConnectType.FormattingEnabled = true;
            this.cbAgvConnectType.ItemHeight = 15;
            this.cbAgvConnectType.Items.AddRange(new object[] {
            "OrmonPlc",
            "Stm32"});
            this.cbAgvConnectType.Location = new System.Drawing.Point(780, 42);
            this.cbAgvConnectType.Name = "cbAgvConnectType";
            this.cbAgvConnectType.Size = new System.Drawing.Size(111, 23);
            this.cbAgvConnectType.TabIndex = 6;
            // 
            // lblAgvType
            // 
            this.lblAgvType.AutoSize = true;
            this.lblAgvType.Location = new System.Drawing.Point(779, 11);
            this.lblAgvType.Name = "lblAgvType";
            this.lblAgvType.Size = new System.Drawing.Size(104, 16);
            this.lblAgvType.TabIndex = 10;
            this.lblAgvType.Text = "Connect type";
            // 
            // lblDesPort
            // 
            this.lblDesPort.AutoSize = true;
            this.lblDesPort.Location = new System.Drawing.Point(654, 10);
            this.lblDesPort.Name = "lblDesPort";
            this.lblDesPort.Size = new System.Drawing.Size(136, 16);
            this.lblDesPort.TabIndex = 9;
            this.lblDesPort.Text = "Destination port";
            // 
            // txtAgvInfoDesPort
            // 
            this.txtAgvInfoDesPort.Location = new System.Drawing.Point(657, 42);
            this.txtAgvInfoDesPort.MaxLength = 5;
            this.txtAgvInfoDesPort.Name = "txtAgvInfoDesPort";
            this.txtAgvInfoDesPort.Size = new System.Drawing.Size(100, 25);
            this.txtAgvInfoDesPort.TabIndex = 5;
            this.txtAgvInfoDesPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAgvInfoDesPort_KeyPress);
            // 
            // lblLocalPort
            // 
            this.lblLocalPort.AutoSize = true;
            this.lblLocalPort.Location = new System.Drawing.Point(541, 10);
            this.lblLocalPort.Name = "lblLocalPort";
            this.lblLocalPort.Size = new System.Drawing.Size(88, 16);
            this.lblLocalPort.TabIndex = 7;
            this.lblLocalPort.Text = "Local port";
            // 
            // txtAgvInfoLocalPort
            // 
            this.txtAgvInfoLocalPort.Location = new System.Drawing.Point(544, 42);
            this.txtAgvInfoLocalPort.MaxLength = 5;
            this.txtAgvInfoLocalPort.Name = "txtAgvInfoLocalPort";
            this.txtAgvInfoLocalPort.Size = new System.Drawing.Size(100, 25);
            this.txtAgvInfoLocalPort.TabIndex = 4;
            this.txtAgvInfoLocalPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAgvInfoLocalPort_KeyPress);
            // 
            // lblAgvNetNo
            // 
            this.lblAgvNetNo.AutoSize = true;
            this.lblAgvNetNo.Location = new System.Drawing.Point(428, 10);
            this.lblAgvNetNo.Name = "lblAgvNetNo";
            this.lblAgvNetNo.Size = new System.Drawing.Size(104, 16);
            this.lblAgvNetNo.TabIndex = 5;
            this.lblAgvNetNo.Text = "Network node";
            // 
            // txtAgvInfoNetNo
            // 
            this.txtAgvInfoNetNo.Location = new System.Drawing.Point(431, 42);
            this.txtAgvInfoNetNo.MaxLength = 3;
            this.txtAgvInfoNetNo.Name = "txtAgvInfoNetNo";
            this.txtAgvInfoNetNo.Size = new System.Drawing.Size(100, 25);
            this.txtAgvInfoNetNo.TabIndex = 3;
            this.txtAgvInfoNetNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAgvInfoNetNo_KeyPress);
            // 
            // txtAgvInfoId
            // 
            this.txtAgvInfoId.Location = new System.Drawing.Point(11, 42);
            this.txtAgvInfoId.MaxLength = 3;
            this.txtAgvInfoId.Name = "txtAgvInfoId";
            this.txtAgvInfoId.Size = new System.Drawing.Size(100, 25);
            this.txtAgvInfoId.TabIndex = 0;
            this.txtAgvInfoId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAgvInfoId_KeyPress);
            // 
            // lblAgvIpAddress
            // 
            this.lblAgvIpAddress.AutoSize = true;
            this.lblAgvIpAddress.Location = new System.Drawing.Point(303, 10);
            this.lblAgvIpAddress.Name = "lblAgvIpAddress";
            this.lblAgvIpAddress.Size = new System.Drawing.Size(24, 16);
            this.lblAgvIpAddress.TabIndex = 3;
            this.lblAgvIpAddress.Text = "IP";
            // 
            // lblAgvId
            // 
            this.lblAgvId.AutoSize = true;
            this.lblAgvId.Location = new System.Drawing.Point(8, 10);
            this.lblAgvId.Name = "lblAgvId";
            this.lblAgvId.Size = new System.Drawing.Size(56, 16);
            this.lblAgvId.TabIndex = 1;
            this.lblAgvId.Text = "Agv Id";
            // 
            // tabConfigMapSet
            // 
            this.tabConfigMapSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabConfigMapSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabConfigMapSet.Controls.Add(this.panMapConfig);
            this.tabConfigMapSet.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabConfigMapSet.Location = new System.Drawing.Point(4, 25);
            this.tabConfigMapSet.Name = "tabConfigMapSet";
            this.tabConfigMapSet.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfigMapSet.Size = new System.Drawing.Size(1793, 812);
            this.tabConfigMapSet.TabIndex = 1;
            this.tabConfigMapSet.Text = "Map Configuration";
            this.tabConfigMapSet.UseVisualStyleBackColor = true;
            // 
            // panMapConfig
            // 
            this.panMapConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panMapConfig.Controls.Add(this.panConfigMapAgvModel);
            this.panMapConfig.Controls.Add(this.panConfigMapShortPathTest);
            this.panMapConfig.Controls.Add(this.panConfigMapBackgroundImageSet);
            this.panMapConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMapConfig.Location = new System.Drawing.Point(3, 3);
            this.panMapConfig.Name = "panMapConfig";
            this.panMapConfig.Size = new System.Drawing.Size(1787, 806);
            this.panMapConfig.TabIndex = 0;
            // 
            // panConfigMapAgvModel
            // 
            this.panConfigMapAgvModel.AutoScroll = true;
            this.panConfigMapAgvModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panConfigMapAgvModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panConfigMapAgvModel.Controls.Add(this.picConfigMapModel);
            this.panConfigMapAgvModel.Controls.Add(this.llblConfigMapModelInsert);
            this.panConfigMapAgvModel.Controls.Add(this.btnConfigMapAgvModelRef);
            this.panConfigMapAgvModel.Controls.Add(this.btnConfigMapAgvModelRecevied);
            this.panConfigMapAgvModel.Controls.Add(this.lblConfigMapAgvModel);
            this.panConfigMapAgvModel.Dock = System.Windows.Forms.DockStyle.Left;
            this.panConfigMapAgvModel.Location = new System.Drawing.Point(340, 0);
            this.panConfigMapAgvModel.Name = "panConfigMapAgvModel";
            this.panConfigMapAgvModel.Size = new System.Drawing.Size(340, 806);
            this.panConfigMapAgvModel.TabIndex = 13;
            // 
            // picConfigMapModel
            // 
            this.picConfigMapModel.BackColor = System.Drawing.Color.White;
            this.picConfigMapModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picConfigMapModel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picConfigMapModel.Location = new System.Drawing.Point(44, 155);
            this.picConfigMapModel.Name = "picConfigMapModel";
            this.picConfigMapModel.Size = new System.Drawing.Size(167, 114);
            this.picConfigMapModel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picConfigMapModel.TabIndex = 16;
            this.picConfigMapModel.TabStop = false;
            // 
            // llblConfigMapModelInsert
            // 
            this.llblConfigMapModelInsert.AutoSize = true;
            this.llblConfigMapModelInsert.Location = new System.Drawing.Point(41, 127);
            this.llblConfigMapModelInsert.Name = "llblConfigMapModelInsert";
            this.llblConfigMapModelInsert.Size = new System.Drawing.Size(136, 16);
            this.llblConfigMapModelInsert.TabIndex = 15;
            this.llblConfigMapModelInsert.TabStop = true;
            this.llblConfigMapModelInsert.Text = "Import agv model";
            this.llblConfigMapModelInsert.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblConfigMapModelInsert_LinkClicked);
            // 
            // btnConfigMapAgvModelRef
            // 
            this.btnConfigMapAgvModelRef.Location = new System.Drawing.Point(44, 291);
            this.btnConfigMapAgvModelRef.Name = "btnConfigMapAgvModelRef";
            this.btnConfigMapAgvModelRef.Size = new System.Drawing.Size(156, 25);
            this.btnConfigMapAgvModelRef.TabIndex = 14;
            this.btnConfigMapAgvModelRef.Text = "Update";
            this.btnConfigMapAgvModelRef.UseVisualStyleBackColor = true;
            this.btnConfigMapAgvModelRef.Click += new System.EventHandler(this.btnConfigMapAgvModelRef_Click);
            // 
            // btnConfigMapAgvModelRecevied
            // 
            this.btnConfigMapAgvModelRecevied.Location = new System.Drawing.Point(44, 332);
            this.btnConfigMapAgvModelRecevied.Name = "btnConfigMapAgvModelRecevied";
            this.btnConfigMapAgvModelRecevied.Size = new System.Drawing.Size(156, 25);
            this.btnConfigMapAgvModelRecevied.TabIndex = 13;
            this.btnConfigMapAgvModelRecevied.Text = "Receive";
            this.btnConfigMapAgvModelRecevied.UseVisualStyleBackColor = true;
            this.btnConfigMapAgvModelRecevied.Click += new System.EventHandler(this.btnConfigMapAgvModelRecevied_Click);
            // 
            // lblConfigMapAgvModel
            // 
            this.lblConfigMapAgvModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblConfigMapAgvModel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblConfigMapAgvModel.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConfigMapAgvModel.Location = new System.Drawing.Point(44, 26);
            this.lblConfigMapAgvModel.Name = "lblConfigMapAgvModel";
            this.lblConfigMapAgvModel.Size = new System.Drawing.Size(242, 49);
            this.lblConfigMapAgvModel.TabIndex = 12;
            this.lblConfigMapAgvModel.Text = "Agv model";
            this.lblConfigMapAgvModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panConfigMapShortPathTest
            // 
            this.panConfigMapShortPathTest.AutoScroll = true;
            this.panConfigMapShortPathTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panConfigMapShortPathTest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panConfigMapShortPathTest.Controls.Add(this.lblConfigMapShortPathTest);
            this.panConfigMapShortPathTest.Controls.Add(this.txtPathShow);
            this.panConfigMapShortPathTest.Controls.Add(this.btnShortPath);
            this.panConfigMapShortPathTest.Controls.Add(this.txtStartId);
            this.panConfigMapShortPathTest.Controls.Add(this.lblEndId);
            this.panConfigMapShortPathTest.Controls.Add(this.txtEndId);
            this.panConfigMapShortPathTest.Controls.Add(this.lblStartId);
            this.panConfigMapShortPathTest.Dock = System.Windows.Forms.DockStyle.Left;
            this.panConfigMapShortPathTest.Location = new System.Drawing.Point(0, 0);
            this.panConfigMapShortPathTest.Name = "panConfigMapShortPathTest";
            this.panConfigMapShortPathTest.Size = new System.Drawing.Size(340, 806);
            this.panConfigMapShortPathTest.TabIndex = 11;
            // 
            // lblConfigMapShortPathTest
            // 
            this.lblConfigMapShortPathTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblConfigMapShortPathTest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblConfigMapShortPathTest.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConfigMapShortPathTest.Location = new System.Drawing.Point(44, 26);
            this.lblConfigMapShortPathTest.Name = "lblConfigMapShortPathTest";
            this.lblConfigMapShortPathTest.Size = new System.Drawing.Size(242, 49);
            this.lblConfigMapShortPathTest.TabIndex = 12;
            this.lblConfigMapShortPathTest.Text = "Shortest path";
            this.lblConfigMapShortPathTest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPathShow
            // 
            this.txtPathShow.Location = new System.Drawing.Point(45, 200);
            this.txtPathShow.Multiline = true;
            this.txtPathShow.Name = "txtPathShow";
            this.txtPathShow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPathShow.Size = new System.Drawing.Size(268, 246);
            this.txtPathShow.TabIndex = 9;
            // 
            // btnShortPath
            // 
            this.btnShortPath.Location = new System.Drawing.Point(63, 169);
            this.btnShortPath.Name = "btnShortPath";
            this.btnShortPath.Size = new System.Drawing.Size(240, 25);
            this.btnShortPath.TabIndex = 4;
            this.btnShortPath.Text = "Update";
            this.btnShortPath.UseVisualStyleBackColor = true;
            this.btnShortPath.Click += new System.EventHandler(this.btnShortPath_Click);
            // 
            // txtStartId
            // 
            this.txtStartId.Location = new System.Drawing.Point(153, 89);
            this.txtStartId.Name = "txtStartId";
            this.txtStartId.Size = new System.Drawing.Size(100, 25);
            this.txtStartId.TabIndex = 5;
            // 
            // lblEndId
            // 
            this.lblEndId.AutoSize = true;
            this.lblEndId.Location = new System.Drawing.Point(64, 138);
            this.lblEndId.Name = "lblEndId";
            this.lblEndId.Size = new System.Drawing.Size(80, 16);
            this.lblEndId.TabIndex = 8;
            this.lblEndId.Text = "End point";
            // 
            // txtEndId
            // 
            this.txtEndId.Location = new System.Drawing.Point(153, 138);
            this.txtEndId.Name = "txtEndId";
            this.txtEndId.Size = new System.Drawing.Size(100, 25);
            this.txtEndId.TabIndex = 6;
            // 
            // lblStartId
            // 
            this.lblStartId.AutoSize = true;
            this.lblStartId.Location = new System.Drawing.Point(64, 90);
            this.lblStartId.Name = "lblStartId";
            this.lblStartId.Size = new System.Drawing.Size(96, 16);
            this.lblStartId.TabIndex = 7;
            this.lblStartId.Text = "Start point";
            // 
            // panConfigMapBackgroundImageSet
            // 
            this.panConfigMapBackgroundImageSet.AutoScroll = true;
            this.panConfigMapBackgroundImageSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panConfigMapBackgroundImageSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panConfigMapBackgroundImageSet.Controls.Add(this.cbMapSel);
            this.panConfigMapBackgroundImageSet.Controls.Add(this.label1);
            this.panConfigMapBackgroundImageSet.Controls.Add(this.btnMapConfigRef);
            this.panConfigMapBackgroundImageSet.Controls.Add(this.btnMapConfigPreviewClear);
            this.panConfigMapBackgroundImageSet.Controls.Add(this.btnMapConfigPreview);
            this.panConfigMapBackgroundImageSet.Controls.Add(this.picConfigMap);
            this.panConfigMapBackgroundImageSet.Controls.Add(this.lblConfigMapBackgroundImage);
            this.panConfigMapBackgroundImageSet.Controls.Add(this.btnMapConfigImport);
            this.panConfigMapBackgroundImageSet.Controls.Add(this.btnMapConfigExport);
            this.panConfigMapBackgroundImageSet.Location = new System.Drawing.Point(685, 3);
            this.panConfigMapBackgroundImageSet.Name = "panConfigMapBackgroundImageSet";
            this.panConfigMapBackgroundImageSet.Size = new System.Drawing.Size(647, 663);
            this.panConfigMapBackgroundImageSet.TabIndex = 10;
            // 
            // cbMapSel
            // 
            this.cbMapSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMapSel.FormattingEnabled = true;
            this.cbMapSel.Location = new System.Drawing.Point(139, 122);
            this.cbMapSel.Name = "cbMapSel";
            this.cbMapSel.Size = new System.Drawing.Size(121, 23);
            this.cbMapSel.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Map";
            // 
            // btnMapConfigRef
            // 
            this.btnMapConfigRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapConfigRef.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMapConfigRef.Location = new System.Drawing.Point(440, 195);
            this.btnMapConfigRef.Name = "btnMapConfigRef";
            this.btnMapConfigRef.Size = new System.Drawing.Size(76, 33);
            this.btnMapConfigRef.TabIndex = 20;
            this.btnMapConfigRef.Text = "Update";
            this.btnMapConfigRef.UseVisualStyleBackColor = true;
            this.btnMapConfigRef.Click += new System.EventHandler(this.btnMapConfigRef_Click);
            // 
            // btnMapConfigPreviewClear
            // 
            this.btnMapConfigPreviewClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapConfigPreviewClear.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMapConfigPreviewClear.Location = new System.Drawing.Point(529, 195);
            this.btnMapConfigPreviewClear.Name = "btnMapConfigPreviewClear";
            this.btnMapConfigPreviewClear.Size = new System.Drawing.Size(76, 33);
            this.btnMapConfigPreviewClear.TabIndex = 19;
            this.btnMapConfigPreviewClear.Text = "Clear";
            this.btnMapConfigPreviewClear.UseVisualStyleBackColor = true;
            this.btnMapConfigPreviewClear.Click += new System.EventHandler(this.btnMapConfigPreviewClear_Click);
            // 
            // btnMapConfigPreview
            // 
            this.btnMapConfigPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapConfigPreview.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMapConfigPreview.Location = new System.Drawing.Point(292, 118);
            this.btnMapConfigPreview.Name = "btnMapConfigPreview";
            this.btnMapConfigPreview.Size = new System.Drawing.Size(76, 33);
            this.btnMapConfigPreview.TabIndex = 18;
            this.btnMapConfigPreview.Text = "Preview";
            this.btnMapConfigPreview.UseVisualStyleBackColor = true;
            this.btnMapConfigPreview.Click += new System.EventHandler(this.btnMapConfigPreview_Click);
            // 
            // picConfigMap
            // 
            this.picConfigMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picConfigMap.BackColor = System.Drawing.Color.White;
            this.picConfigMap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picConfigMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picConfigMap.Location = new System.Drawing.Point(21, 238);
            this.picConfigMap.Name = "picConfigMap";
            this.picConfigMap.Size = new System.Drawing.Size(608, 402);
            this.picConfigMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picConfigMap.TabIndex = 17;
            this.picConfigMap.TabStop = false;
            // 
            // lblConfigMapBackgroundImage
            // 
            this.lblConfigMapBackgroundImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfigMapBackgroundImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblConfigMapBackgroundImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblConfigMapBackgroundImage.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConfigMapBackgroundImage.Location = new System.Drawing.Point(219, 26);
            this.lblConfigMapBackgroundImage.Name = "lblConfigMapBackgroundImage";
            this.lblConfigMapBackgroundImage.Size = new System.Drawing.Size(232, 49);
            this.lblConfigMapBackgroundImage.TabIndex = 11;
            this.lblConfigMapBackgroundImage.Text = "Map background";
            this.lblConfigMapBackgroundImage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMapConfigImport
            // 
            this.btnMapConfigImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapConfigImport.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMapConfigImport.Location = new System.Drawing.Point(351, 195);
            this.btnMapConfigImport.Name = "btnMapConfigImport";
            this.btnMapConfigImport.Size = new System.Drawing.Size(76, 33);
            this.btnMapConfigImport.TabIndex = 2;
            this.btnMapConfigImport.Text = "Import";
            this.btnMapConfigImport.UseVisualStyleBackColor = true;
            this.btnMapConfigImport.Click += new System.EventHandler(this.btnMapConfigImport_Click);
            // 
            // btnMapConfigExport
            // 
            this.btnMapConfigExport.Location = new System.Drawing.Point(420, 117);
            this.btnMapConfigExport.Name = "btnMapConfigExport";
            this.btnMapConfigExport.Size = new System.Drawing.Size(76, 33);
            this.btnMapConfigExport.TabIndex = 3;
            this.btnMapConfigExport.Text = "Export";
            this.btnMapConfigExport.UseVisualStyleBackColor = true;
            this.btnMapConfigExport.Click += new System.EventHandler(this.btnMapConfigExport_Click);
            // 
            // tabConfigSql
            // 
            this.tabConfigSql.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabConfigSql.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabConfigSql.Controls.Add(this.panConfigSqlConfig);
            this.tabConfigSql.Location = new System.Drawing.Point(4, 25);
            this.tabConfigSql.Name = "tabConfigSql";
            this.tabConfigSql.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfigSql.Size = new System.Drawing.Size(1793, 812);
            this.tabConfigSql.TabIndex = 2;
            this.tabConfigSql.Text = "Database Configuration";
            this.tabConfigSql.UseVisualStyleBackColor = true;
            // 
            // panConfigSqlConfig
            // 
            this.panConfigSqlConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panConfigSqlConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panConfigSqlConfig.Controls.Add(this.panConfigSQLSet1);
            this.panConfigSqlConfig.Controls.Add(this.panConfigSQLSet);
            this.panConfigSqlConfig.Location = new System.Drawing.Point(0, 0);
            this.panConfigSqlConfig.Name = "panConfigSqlConfig";
            this.panConfigSqlConfig.Size = new System.Drawing.Size(1794, 815);
            this.panConfigSqlConfig.TabIndex = 0;
            // 
            // panConfigSQLSet1
            // 
            this.panConfigSQLSet1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panConfigSQLSet1.AutoScroll = true;
            this.panConfigSQLSet1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panConfigSQLSet1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panConfigSQLSet1.Controls.Add(this.lblConfigSqlTItle1);
            this.panConfigSQLSet1.Controls.Add(this.btnConfigDataType);
            this.panConfigSQLSet1.Controls.Add(this.cbConfigDataType);
            this.panConfigSQLSet1.Location = new System.Drawing.Point(346, 3);
            this.panConfigSQLSet1.Name = "panConfigSQLSet1";
            this.panConfigSQLSet1.Size = new System.Drawing.Size(340, 805);
            this.panConfigSQLSet1.TabIndex = 1;
            // 
            // lblConfigSqlTItle1
            // 
            this.lblConfigSqlTItle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblConfigSqlTItle1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblConfigSqlTItle1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConfigSqlTItle1.Location = new System.Drawing.Point(44, 26);
            this.lblConfigSqlTItle1.Name = "lblConfigSqlTItle1";
            this.lblConfigSqlTItle1.Size = new System.Drawing.Size(242, 49);
            this.lblConfigSqlTItle1.TabIndex = 11;
            this.lblConfigSqlTItle1.Text = "Database Type";
            this.lblConfigSqlTItle1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnConfigDataType
            // 
            this.btnConfigDataType.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfigDataType.Location = new System.Drawing.Point(57, 196);
            this.btnConfigDataType.Name = "btnConfigDataType";
            this.btnConfigDataType.Size = new System.Drawing.Size(191, 49);
            this.btnConfigDataType.TabIndex = 1;
            this.btnConfigDataType.Text = "Update";
            this.btnConfigDataType.UseVisualStyleBackColor = true;
            this.btnConfigDataType.Click += new System.EventHandler(this.btnConfigDataType_Click);
            // 
            // cbConfigDataType
            // 
            this.cbConfigDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConfigDataType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbConfigDataType.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbConfigDataType.ForeColor = System.Drawing.Color.Black;
            this.cbConfigDataType.FormattingEnabled = true;
            this.cbConfigDataType.Location = new System.Drawing.Point(57, 132);
            this.cbConfigDataType.Name = "cbConfigDataType";
            this.cbConfigDataType.Size = new System.Drawing.Size(191, 30);
            this.cbConfigDataType.TabIndex = 0;
            // 
            // panConfigSQLSet
            // 
            this.panConfigSQLSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panConfigSQLSet.AutoScroll = true;
            this.panConfigSQLSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panConfigSQLSet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panConfigSQLSet.Controls.Add(this.lblConfigSqlTItle);
            this.panConfigSQLSet.Controls.Add(this.txtConfigSqlDatabase);
            this.panConfigSQLSet.Controls.Add(this.txtConfigSqlUserPwd);
            this.panConfigSQLSet.Controls.Add(this.txtConfigUserName);
            this.panConfigSQLSet.Controls.Add(this.txtConfigSqlAddress);
            this.panConfigSQLSet.Controls.Add(this.btnConfigSqlRef);
            this.panConfigSQLSet.Controls.Add(this.btnConfigSqlRec);
            this.panConfigSQLSet.Controls.Add(this.lblConfigSqlDataBase);
            this.panConfigSQLSet.Controls.Add(this.lblConfigSqlUserPwd);
            this.panConfigSQLSet.Controls.Add(this.lblConfigUserName);
            this.panConfigSQLSet.Controls.Add(this.lblConfigSqlAddress);
            this.panConfigSQLSet.Location = new System.Drawing.Point(6, 3);
            this.panConfigSQLSet.Name = "panConfigSQLSet";
            this.panConfigSQLSet.Size = new System.Drawing.Size(340, 805);
            this.panConfigSQLSet.TabIndex = 0;
            // 
            // lblConfigSqlTItle
            // 
            this.lblConfigSqlTItle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblConfigSqlTItle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblConfigSqlTItle.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConfigSqlTItle.Location = new System.Drawing.Point(44, 26);
            this.lblConfigSqlTItle.Name = "lblConfigSqlTItle";
            this.lblConfigSqlTItle.Size = new System.Drawing.Size(242, 49);
            this.lblConfigSqlTItle.TabIndex = 10;
            this.lblConfigSqlTItle.Text = "Database Parameters";
            this.lblConfigSqlTItle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtConfigSqlDatabase
            // 
            this.txtConfigSqlDatabase.Location = new System.Drawing.Point(128, 265);
            this.txtConfigSqlDatabase.MaxLength = 30;
            this.txtConfigSqlDatabase.Name = "txtConfigSqlDatabase";
            this.txtConfigSqlDatabase.Size = new System.Drawing.Size(183, 25);
            this.txtConfigSqlDatabase.TabIndex = 9;
            // 
            // txtConfigSqlUserPwd
            // 
            this.txtConfigSqlUserPwd.Location = new System.Drawing.Point(128, 220);
            this.txtConfigSqlUserPwd.MaxLength = 20;
            this.txtConfigSqlUserPwd.Name = "txtConfigSqlUserPwd";
            this.txtConfigSqlUserPwd.Size = new System.Drawing.Size(183, 25);
            this.txtConfigSqlUserPwd.TabIndex = 8;
            // 
            // txtConfigUserName
            // 
            this.txtConfigUserName.Location = new System.Drawing.Point(128, 174);
            this.txtConfigUserName.MaxLength = 20;
            this.txtConfigUserName.Name = "txtConfigUserName";
            this.txtConfigUserName.Size = new System.Drawing.Size(183, 25);
            this.txtConfigUserName.TabIndex = 7;
            // 
            // txtConfigSqlAddress
            // 
            this.txtConfigSqlAddress.Location = new System.Drawing.Point(128, 129);
            this.txtConfigSqlAddress.MaxLength = 15;
            this.txtConfigSqlAddress.Name = "txtConfigSqlAddress";
            this.txtConfigSqlAddress.Size = new System.Drawing.Size(183, 25);
            this.txtConfigSqlAddress.TabIndex = 6;
            // 
            // btnConfigSqlRef
            // 
            this.btnConfigSqlRef.Location = new System.Drawing.Point(153, 368);
            this.btnConfigSqlRef.Name = "btnConfigSqlRef";
            this.btnConfigSqlRef.Size = new System.Drawing.Size(75, 25);
            this.btnConfigSqlRef.TabIndex = 5;
            this.btnConfigSqlRef.Text = "Update";
            this.btnConfigSqlRef.UseVisualStyleBackColor = true;
            this.btnConfigSqlRef.Click += new System.EventHandler(this.btnConfigSqlRef_Click);
            // 
            // btnConfigSqlRec
            // 
            this.btnConfigSqlRec.Location = new System.Drawing.Point(33, 368);
            this.btnConfigSqlRec.Name = "btnConfigSqlRec";
            this.btnConfigSqlRec.Size = new System.Drawing.Size(75, 25);
            this.btnConfigSqlRec.TabIndex = 4;
            this.btnConfigSqlRec.Text = "Receive";
            this.btnConfigSqlRec.UseVisualStyleBackColor = true;
            this.btnConfigSqlRec.Click += new System.EventHandler(this.btnConfigSqlRec_Click);
            // 
            // lblConfigSqlDataBase
            // 
            this.lblConfigSqlDataBase.AutoSize = true;
            this.lblConfigSqlDataBase.Location = new System.Drawing.Point(11, 269);
            this.lblConfigSqlDataBase.Name = "lblConfigSqlDataBase";
            this.lblConfigSqlDataBase.Size = new System.Drawing.Size(120, 16);
            this.lblConfigSqlDataBase.TabIndex = 3;
            this.lblConfigSqlDataBase.Text = "Database Name:";
            // 
            // lblConfigSqlUserPwd
            // 
            this.lblConfigSqlUserPwd.AutoSize = true;
            this.lblConfigSqlUserPwd.Location = new System.Drawing.Point(39, 223);
            this.lblConfigSqlUserPwd.Name = "lblConfigSqlUserPwd";
            this.lblConfigSqlUserPwd.Size = new System.Drawing.Size(88, 16);
            this.lblConfigSqlUserPwd.TabIndex = 2;
            this.lblConfigSqlUserPwd.Text = "Password：";
            // 
            // lblConfigUserName
            // 
            this.lblConfigUserName.AutoSize = true;
            this.lblConfigUserName.Location = new System.Drawing.Point(67, 178);
            this.lblConfigUserName.Name = "lblConfigUserName";
            this.lblConfigUserName.Size = new System.Drawing.Size(56, 16);
            this.lblConfigUserName.TabIndex = 1;
            this.lblConfigUserName.Text = "User：";
            // 
            // lblConfigSqlAddress
            // 
            this.lblConfigSqlAddress.AutoSize = true;
            this.lblConfigSqlAddress.Location = new System.Drawing.Point(46, 132);
            this.lblConfigSqlAddress.Name = "lblConfigSqlAddress";
            this.lblConfigSqlAddress.Size = new System.Drawing.Size(80, 16);
            this.lblConfigSqlAddress.TabIndex = 0;
            this.lblConfigSqlAddress.Text = "Address：";
            // 
            // tabConfigBasic
            // 
            this.tabConfigBasic.Controls.Add(this.panConfigBasic);
            this.tabConfigBasic.Location = new System.Drawing.Point(4, 25);
            this.tabConfigBasic.Name = "tabConfigBasic";
            this.tabConfigBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tabConfigBasic.Size = new System.Drawing.Size(1793, 812);
            this.tabConfigBasic.TabIndex = 3;
            this.tabConfigBasic.Text = "Base configuration";
            this.tabConfigBasic.UseVisualStyleBackColor = true;
            // 
            // panConfigBasic
            // 
            this.panConfigBasic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panConfigBasic.Controls.Add(this.panel1);
            this.panConfigBasic.Controls.Add(this.panConfigBasicParameter);
            this.panConfigBasic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panConfigBasic.Location = new System.Drawing.Point(3, 3);
            this.panConfigBasic.Name = "panConfigBasic";
            this.panConfigBasic.Size = new System.Drawing.Size(1787, 806);
            this.panConfigBasic.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgvConfigControl);
            this.panel1.Controls.Add(this.btnConfigControlAdd);
            this.panel1.Controls.Add(this.lblConfigControlPoint);
            this.panel1.Controls.Add(this.txtConfigControlPoint);
            this.panel1.Controls.Add(this.lblConfigControlNo);
            this.panel1.Controls.Add(this.txtConfigControlNo);
            this.panel1.Controls.Add(this.btnConfigControlObtain);
            this.panel1.Controls.Add(this.lblConfigControlPoints);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1144, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 806);
            this.panel1.TabIndex = 13;
            // 
            // dgvConfigControl
            // 
            this.dgvConfigControl.AllowUserToAddRows = false;
            this.dgvConfigControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConfigControl.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvConfigControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfigControl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctxtConfigControlNo,
            this.ctxtConfigControlPoint,
            this.dataGridViewButtonColumn17,
            this.dataGridViewButtonColumn18});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConfigControl.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvConfigControl.Location = new System.Drawing.Point(13, 193);
            this.dgvConfigControl.Name = "dgvConfigControl";
            this.dgvConfigControl.RowHeadersVisible = false;
            this.dgvConfigControl.RowTemplate.Height = 23;
            this.dgvConfigControl.Size = new System.Drawing.Size(596, 603);
            this.dgvConfigControl.TabIndex = 42;
            this.dgvConfigControl.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConfigControl_CellContentClick);
            // 
            // ctxtConfigControlNo
            // 
            this.ctxtConfigControlNo.HeaderText = "Control id";
            this.ctxtConfigControlNo.Name = "ctxtConfigControlNo";
            this.ctxtConfigControlNo.ReadOnly = true;
            // 
            // ctxtConfigControlPoint
            // 
            this.ctxtConfigControlPoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ctxtConfigControlPoint.DefaultCellStyle = dataGridViewCellStyle3;
            this.ctxtConfigControlPoint.HeaderText = "Rfids";
            this.ctxtConfigControlPoint.MinimumWidth = 100;
            this.ctxtConfigControlPoint.Name = "ctxtConfigControlPoint";
            // 
            // dataGridViewButtonColumn17
            // 
            this.dataGridViewButtonColumn17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewButtonColumn17.HeaderText = "Operation";
            this.dataGridViewButtonColumn17.Name = "dataGridViewButtonColumn17";
            this.dataGridViewButtonColumn17.Text = "Delete";
            this.dataGridViewButtonColumn17.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn17.Width = 80;
            // 
            // dataGridViewButtonColumn18
            // 
            this.dataGridViewButtonColumn18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewButtonColumn18.HeaderText = "Update";
            this.dataGridViewButtonColumn18.Name = "dataGridViewButtonColumn18";
            this.dataGridViewButtonColumn18.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewButtonColumn18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewButtonColumn18.Text = "Change";
            this.dataGridViewButtonColumn18.UseColumnTextForButtonValue = true;
            this.dataGridViewButtonColumn18.Width = 60;
            // 
            // btnConfigControlAdd
            // 
            this.btnConfigControlAdd.Location = new System.Drawing.Point(514, 126);
            this.btnConfigControlAdd.Name = "btnConfigControlAdd";
            this.btnConfigControlAdd.Size = new System.Drawing.Size(75, 25);
            this.btnConfigControlAdd.TabIndex = 37;
            this.btnConfigControlAdd.Text = "Add";
            this.btnConfigControlAdd.UseVisualStyleBackColor = true;
            this.btnConfigControlAdd.Click += new System.EventHandler(this.btnConfigControlAdd_Click);
            // 
            // lblConfigControlPoint
            // 
            this.lblConfigControlPoint.AutoSize = true;
            this.lblConfigControlPoint.Location = new System.Drawing.Point(122, 104);
            this.lblConfigControlPoint.Name = "lblConfigControlPoint";
            this.lblConfigControlPoint.Size = new System.Drawing.Size(56, 16);
            this.lblConfigControlPoint.TabIndex = 41;
            this.lblConfigControlPoint.Text = "Rfids:";
            // 
            // txtConfigControlPoint
            // 
            this.txtConfigControlPoint.Location = new System.Drawing.Point(125, 126);
            this.txtConfigControlPoint.Multiline = true;
            this.txtConfigControlPoint.Name = "txtConfigControlPoint";
            this.txtConfigControlPoint.Size = new System.Drawing.Size(367, 63);
            this.txtConfigControlPoint.TabIndex = 40;
            // 
            // lblConfigControlNo
            // 
            this.lblConfigControlNo.AutoSize = true;
            this.lblConfigControlNo.Location = new System.Drawing.Point(10, 104);
            this.lblConfigControlNo.Name = "lblConfigControlNo";
            this.lblConfigControlNo.Size = new System.Drawing.Size(32, 16);
            this.lblConfigControlNo.TabIndex = 39;
            this.lblConfigControlNo.Text = "Id:";
            // 
            // txtConfigControlNo
            // 
            this.txtConfigControlNo.Location = new System.Drawing.Point(13, 126);
            this.txtConfigControlNo.Name = "txtConfigControlNo";
            this.txtConfigControlNo.Size = new System.Drawing.Size(70, 25);
            this.txtConfigControlNo.TabIndex = 38;
            // 
            // btnConfigControlObtain
            // 
            this.btnConfigControlObtain.Location = new System.Drawing.Point(514, 161);
            this.btnConfigControlObtain.Name = "btnConfigControlObtain";
            this.btnConfigControlObtain.Size = new System.Drawing.Size(75, 25);
            this.btnConfigControlObtain.TabIndex = 36;
            this.btnConfigControlObtain.Text = "Receive";
            this.btnConfigControlObtain.UseVisualStyleBackColor = true;
            this.btnConfigControlObtain.Click += new System.EventHandler(this.btnConfigControlObtain_Click);
            // 
            // lblConfigControlPoints
            // 
            this.lblConfigControlPoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblConfigControlPoints.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblConfigControlPoints.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConfigControlPoints.Location = new System.Drawing.Point(136, 13);
            this.lblConfigControlPoints.Name = "lblConfigControlPoints";
            this.lblConfigControlPoints.Size = new System.Drawing.Size(365, 49);
            this.lblConfigControlPoints.TabIndex = 10;
            this.lblConfigControlPoints.Text = "Control point Configuration";
            this.lblConfigControlPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panConfigBasicParameter
            // 
            this.panConfigBasicParameter.AutoScroll = true;
            this.panConfigBasicParameter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panConfigBasicParameter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panConfigBasicParameter.Controls.Add(this.groupBox9);
            this.panConfigBasicParameter.Controls.Add(this.groupBox8);
            this.panConfigBasicParameter.Controls.Add(this.btnOpcValue);
            this.panConfigBasicParameter.Controls.Add(this.txtHandleValue);
            this.panConfigBasicParameter.Controls.Add(this.label33);
            this.panConfigBasicParameter.Controls.Add(this.txtHandle);
            this.panConfigBasicParameter.Controls.Add(this.lblHandle);
            this.panConfigBasicParameter.Controls.Add(this.btnRobotRefence);
            this.panConfigBasicParameter.Controls.Add(this.btnRobotStateReceive);
            this.panConfigBasicParameter.Controls.Add(this.dgvOpcState);
            this.panConfigBasicParameter.Controls.Add(this.groupBox4);
            this.panConfigBasicParameter.Controls.Add(this.gbTaskClient);
            this.panConfigBasicParameter.Controls.Add(this.btnStationRef);
            this.panConfigBasicParameter.Controls.Add(this.btnStationRec);
            this.panConfigBasicParameter.Controls.Add(this.dgvStation);
            this.panConfigBasicParameter.Controls.Add(this.lblConfigBasicParameter);
            this.panConfigBasicParameter.Dock = System.Windows.Forms.DockStyle.Left;
            this.panConfigBasicParameter.Location = new System.Drawing.Point(0, 0);
            this.panConfigBasicParameter.Name = "panConfigBasicParameter";
            this.panConfigBasicParameter.Size = new System.Drawing.Size(1144, 806);
            this.panConfigBasicParameter.TabIndex = 1;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label94);
            this.groupBox9.Controls.Add(this.btnStandbyChargeTimeUpdate);
            this.groupBox9.Controls.Add(this.btnStandbyChargeTimeReceive);
            this.groupBox9.Controls.Add(this.txtStanbyChargeTime);
            this.groupBox9.Controls.Add(this.label95);
            this.groupBox9.Location = new System.Drawing.Point(26, 626);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(200, 135);
            this.groupBox9.TabIndex = 57;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Standby mode Charge Time";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(110, 53);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(64, 16);
            this.label94.TabIndex = 12;
            this.label94.Text = "seconds";
            // 
            // btnStandbyChargeTimeUpdate
            // 
            this.btnStandbyChargeTimeUpdate.Location = new System.Drawing.Point(102, 91);
            this.btnStandbyChargeTimeUpdate.Name = "btnStandbyChargeTimeUpdate";
            this.btnStandbyChargeTimeUpdate.Size = new System.Drawing.Size(75, 25);
            this.btnStandbyChargeTimeUpdate.TabIndex = 5;
            this.btnStandbyChargeTimeUpdate.Text = "Update";
            this.btnStandbyChargeTimeUpdate.UseVisualStyleBackColor = true;
            this.btnStandbyChargeTimeUpdate.Click += new System.EventHandler(this.btnStandbyChargeTimeUpdate_Click);
            // 
            // btnStandbyChargeTimeReceive
            // 
            this.btnStandbyChargeTimeReceive.Location = new System.Drawing.Point(7, 91);
            this.btnStandbyChargeTimeReceive.Name = "btnStandbyChargeTimeReceive";
            this.btnStandbyChargeTimeReceive.Size = new System.Drawing.Size(75, 25);
            this.btnStandbyChargeTimeReceive.TabIndex = 4;
            this.btnStandbyChargeTimeReceive.Text = "Receive";
            this.btnStandbyChargeTimeReceive.UseVisualStyleBackColor = true;
            this.btnStandbyChargeTimeReceive.Click += new System.EventHandler(this.btnStandbyChargeTimeReceive_Click);
            // 
            // txtStanbyChargeTime
            // 
            this.txtStanbyChargeTime.Location = new System.Drawing.Point(22, 50);
            this.txtStanbyChargeTime.Name = "txtStanbyChargeTime";
            this.txtStanbyChargeTime.Size = new System.Drawing.Size(82, 25);
            this.txtStanbyChargeTime.TabIndex = 2;
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(19, 28);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(104, 16);
            this.label95.TabIndex = 0;
            this.label95.Text = "Charge Time:";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label92);
            this.groupBox8.Controls.Add(this.btnChargeTimeUpdate);
            this.groupBox8.Controls.Add(this.btnChargeTimeReceive);
            this.groupBox8.Controls.Add(this.txtChargeTime);
            this.groupBox8.Controls.Add(this.label93);
            this.groupBox8.Location = new System.Drawing.Point(26, 484);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(200, 135);
            this.groupBox8.TabIndex = 56;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "ChargeTime";
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(110, 53);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(64, 16);
            this.label92.TabIndex = 12;
            this.label92.Text = "seconds";
            // 
            // btnChargeTimeUpdate
            // 
            this.btnChargeTimeUpdate.Location = new System.Drawing.Point(102, 91);
            this.btnChargeTimeUpdate.Name = "btnChargeTimeUpdate";
            this.btnChargeTimeUpdate.Size = new System.Drawing.Size(75, 25);
            this.btnChargeTimeUpdate.TabIndex = 5;
            this.btnChargeTimeUpdate.Text = "Update";
            this.btnChargeTimeUpdate.UseVisualStyleBackColor = true;
            this.btnChargeTimeUpdate.Click += new System.EventHandler(this.btnChargeTimeUpdate_Click);
            // 
            // btnChargeTimeReceive
            // 
            this.btnChargeTimeReceive.Location = new System.Drawing.Point(7, 91);
            this.btnChargeTimeReceive.Name = "btnChargeTimeReceive";
            this.btnChargeTimeReceive.Size = new System.Drawing.Size(75, 25);
            this.btnChargeTimeReceive.TabIndex = 4;
            this.btnChargeTimeReceive.Text = "Receive";
            this.btnChargeTimeReceive.UseVisualStyleBackColor = true;
            this.btnChargeTimeReceive.Click += new System.EventHandler(this.btnChargeTimeReceive_Click);
            // 
            // txtChargeTime
            // 
            this.txtChargeTime.Location = new System.Drawing.Point(22, 50);
            this.txtChargeTime.Name = "txtChargeTime";
            this.txtChargeTime.Size = new System.Drawing.Size(82, 25);
            this.txtChargeTime.TabIndex = 2;
            // 
            // label93
            // 
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(19, 28);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(104, 16);
            this.label93.TabIndex = 0;
            this.label93.Text = "Charge Time:";
            // 
            // btnOpcValue
            // 
            this.btnOpcValue.Location = new System.Drawing.Point(606, 762);
            this.btnOpcValue.Name = "btnOpcValue";
            this.btnOpcValue.Size = new System.Drawing.Size(75, 25);
            this.btnOpcValue.TabIndex = 55;
            this.btnOpcValue.Text = "Update";
            this.btnOpcValue.UseVisualStyleBackColor = true;
            this.btnOpcValue.Click += new System.EventHandler(this.btnOpcValue_Click);
            // 
            // txtHandleValue
            // 
            this.txtHandleValue.Location = new System.Drawing.Point(461, 762);
            this.txtHandleValue.Name = "txtHandleValue";
            this.txtHandleValue.Size = new System.Drawing.Size(100, 25);
            this.txtHandleValue.TabIndex = 54;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(406, 762);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(48, 16);
            this.label33.TabIndex = 53;
            this.label33.Text = "Value";
            // 
            // txtHandle
            // 
            this.txtHandle.Location = new System.Drawing.Point(292, 762);
            this.txtHandle.Name = "txtHandle";
            this.txtHandle.Size = new System.Drawing.Size(100, 25);
            this.txtHandle.TabIndex = 52;
            // 
            // lblHandle
            // 
            this.lblHandle.AutoSize = true;
            this.lblHandle.Location = new System.Drawing.Point(237, 762);
            this.lblHandle.Name = "lblHandle";
            this.lblHandle.Size = new System.Drawing.Size(56, 16);
            this.lblHandle.TabIndex = 51;
            this.lblHandle.Text = "Handle";
            // 
            // btnRobotRefence
            // 
            this.btnRobotRefence.Location = new System.Drawing.Point(340, 720);
            this.btnRobotRefence.Name = "btnRobotRefence";
            this.btnRobotRefence.Size = new System.Drawing.Size(75, 25);
            this.btnRobotRefence.TabIndex = 50;
            this.btnRobotRefence.Text = "Update";
            this.btnRobotRefence.UseVisualStyleBackColor = true;
            this.btnRobotRefence.Click += new System.EventHandler(this.btnRobotRefence_Click);
            // 
            // btnRobotStateReceive
            // 
            this.btnRobotStateReceive.Location = new System.Drawing.Point(233, 720);
            this.btnRobotStateReceive.Name = "btnRobotStateReceive";
            this.btnRobotStateReceive.Size = new System.Drawing.Size(75, 25);
            this.btnRobotStateReceive.TabIndex = 49;
            this.btnRobotStateReceive.Text = "Receive";
            this.btnRobotStateReceive.UseVisualStyleBackColor = true;
            this.btnRobotStateReceive.Click += new System.EventHandler(this.btnRobotStateReceive_Click);
            // 
            // dgvOpcState
            // 
            this.dgvOpcState.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOpcState.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.Handle,
            this.OpcParameterValue});
            this.dgvOpcState.Location = new System.Drawing.Point(233, 126);
            this.dgvOpcState.Name = "dgvOpcState";
            this.dgvOpcState.RowHeadersVisible = false;
            this.dgvOpcState.RowTemplate.Height = 23;
            this.dgvOpcState.Size = new System.Drawing.Size(877, 588);
            this.dgvOpcState.TabIndex = 48;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.HeaderText = "OPC Tag";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn9.HeaderText = "AB PLC area";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // Handle
            // 
            this.Handle.HeaderText = "Handle";
            this.Handle.Name = "Handle";
            // 
            // OpcParameterValue
            // 
            this.OpcParameterValue.HeaderText = "Value";
            this.OpcParameterValue.Name = "OpcParameterValue";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label86);
            this.groupBox4.Controls.Add(this.label85);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.txtClearLineTime);
            this.groupBox4.Controls.Add(this.btnLineTimeRef);
            this.groupBox4.Controls.Add(this.btnLineTimeRec);
            this.groupBox4.Controls.Add(this.label84);
            this.groupBox4.Controls.Add(this.txtLineTime);
            this.groupBox4.Location = new System.Drawing.Point(26, 300);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(202, 178);
            this.groupBox4.TabIndex = 47;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Lineoff";
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(11, 75);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(168, 16);
            this.label86.TabIndex = 11;
            this.label86.Text = "Clear state duration";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(11, 18);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(184, 16);
            this.label85.TabIndex = 10;
            this.label85.Text = "Lineoff judge duration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "min";
            // 
            // txtClearLineTime
            // 
            this.txtClearLineTime.Location = new System.Drawing.Point(14, 100);
            this.txtClearLineTime.Name = "txtClearLineTime";
            this.txtClearLineTime.Size = new System.Drawing.Size(100, 25);
            this.txtClearLineTime.TabIndex = 8;
            // 
            // btnLineTimeRef
            // 
            this.btnLineTimeRef.Location = new System.Drawing.Point(101, 138);
            this.btnLineTimeRef.Name = "btnLineTimeRef";
            this.btnLineTimeRef.Size = new System.Drawing.Size(75, 25);
            this.btnLineTimeRef.TabIndex = 7;
            this.btnLineTimeRef.Text = "Update";
            this.btnLineTimeRef.UseVisualStyleBackColor = true;
            this.btnLineTimeRef.Click += new System.EventHandler(this.btnLineTimeRef_Click);
            // 
            // btnLineTimeRec
            // 
            this.btnLineTimeRec.Location = new System.Drawing.Point(6, 138);
            this.btnLineTimeRec.Name = "btnLineTimeRec";
            this.btnLineTimeRec.Size = new System.Drawing.Size(75, 25);
            this.btnLineTimeRec.TabIndex = 6;
            this.btnLineTimeRec.Text = "Receive";
            this.btnLineTimeRec.UseVisualStyleBackColor = true;
            this.btnLineTimeRec.Click += new System.EventHandler(this.btnLineTimeRec_Click);
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(125, 48);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(32, 16);
            this.label84.TabIndex = 1;
            this.label84.Text = "sec";
            // 
            // txtLineTime
            // 
            this.txtLineTime.Location = new System.Drawing.Point(14, 44);
            this.txtLineTime.Name = "txtLineTime";
            this.txtLineTime.Size = new System.Drawing.Size(100, 25);
            this.txtLineTime.TabIndex = 0;
            // 
            // gbTaskClient
            // 
            this.gbTaskClient.Controls.Add(this.btnPlcClientRef);
            this.gbTaskClient.Controls.Add(this.btnPlcClientRec);
            this.gbTaskClient.Controls.Add(this.txtOpcHostName);
            this.gbTaskClient.Controls.Add(this.txtOpcIp);
            this.gbTaskClient.Controls.Add(this.label27);
            this.gbTaskClient.Controls.Add(this.label26);
            this.gbTaskClient.Location = new System.Drawing.Point(26, 126);
            this.gbTaskClient.Name = "gbTaskClient";
            this.gbTaskClient.Size = new System.Drawing.Size(201, 168);
            this.gbTaskClient.TabIndex = 46;
            this.gbTaskClient.TabStop = false;
            this.gbTaskClient.Text = "OPC configuration";
            // 
            // btnPlcClientRef
            // 
            this.btnPlcClientRef.Location = new System.Drawing.Point(101, 130);
            this.btnPlcClientRef.Name = "btnPlcClientRef";
            this.btnPlcClientRef.Size = new System.Drawing.Size(75, 25);
            this.btnPlcClientRef.TabIndex = 5;
            this.btnPlcClientRef.Text = "Update";
            this.btnPlcClientRef.UseVisualStyleBackColor = true;
            this.btnPlcClientRef.Click += new System.EventHandler(this.btnPlcClientRef_Click);
            // 
            // btnPlcClientRec
            // 
            this.btnPlcClientRec.Location = new System.Drawing.Point(6, 130);
            this.btnPlcClientRec.Name = "btnPlcClientRec";
            this.btnPlcClientRec.Size = new System.Drawing.Size(75, 25);
            this.btnPlcClientRec.TabIndex = 4;
            this.btnPlcClientRec.Text = "Receive";
            this.btnPlcClientRec.UseVisualStyleBackColor = true;
            this.btnPlcClientRec.Click += new System.EventHandler(this.btnPlcClientRec_Click);
            // 
            // txtOpcHostName
            // 
            this.txtOpcHostName.Location = new System.Drawing.Point(22, 95);
            this.txtOpcHostName.Name = "txtOpcHostName";
            this.txtOpcHostName.Size = new System.Drawing.Size(138, 25);
            this.txtOpcHostName.TabIndex = 3;
            // 
            // txtOpcIp
            // 
            this.txtOpcIp.Location = new System.Drawing.Point(22, 41);
            this.txtOpcIp.Name = "txtOpcIp";
            this.txtOpcIp.Size = new System.Drawing.Size(138, 25);
            this.txtOpcIp.TabIndex = 2;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(19, 73);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(80, 16);
            this.label27.TabIndex = 1;
            this.label27.Text = "OPC Name:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(19, 20);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(96, 16);
            this.label26.TabIndex = 0;
            this.label26.Text = "IP Address:";
            // 
            // btnStationRef
            // 
            this.btnStationRef.Location = new System.Drawing.Point(461, 81);
            this.btnStationRef.Name = "btnStationRef";
            this.btnStationRef.Size = new System.Drawing.Size(75, 25);
            this.btnStationRef.TabIndex = 45;
            this.btnStationRef.Text = "更新";
            this.btnStationRef.UseVisualStyleBackColor = true;
            this.btnStationRef.Visible = false;
            this.btnStationRef.Click += new System.EventHandler(this.btnStationRef_Click);
            // 
            // btnStationRec
            // 
            this.btnStationRec.Location = new System.Drawing.Point(356, 81);
            this.btnStationRec.Name = "btnStationRec";
            this.btnStationRec.Size = new System.Drawing.Size(75, 25);
            this.btnStationRec.TabIndex = 44;
            this.btnStationRec.Text = "获取";
            this.btnStationRec.UseVisualStyleBackColor = true;
            this.btnStationRec.Visible = false;
            this.btnStationRec.Click += new System.EventHandler(this.btnStationRec_Click);
            // 
            // dgvStation
            // 
            this.dgvStation.AllowUserToAddRows = false;
            this.dgvStation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvStation.Location = new System.Drawing.Point(340, 13);
            this.dgvStation.Name = "dgvStation";
            this.dgvStation.RowHeadersVisible = false;
            this.dgvStation.RowTemplate.Height = 23;
            this.dgvStation.Size = new System.Drawing.Size(222, 62);
            this.dgvStation.TabIndex = 43;
            this.dgvStation.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "MES站点";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn2.HeaderText = "AGV站点";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // lblConfigBasicParameter
            // 
            this.lblConfigBasicParameter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.lblConfigBasicParameter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblConfigBasicParameter.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConfigBasicParameter.Location = new System.Drawing.Point(44, 26);
            this.lblConfigBasicParameter.Name = "lblConfigBasicParameter";
            this.lblConfigBasicParameter.Size = new System.Drawing.Size(242, 49);
            this.lblConfigBasicParameter.TabIndex = 10;
            this.lblConfigBasicParameter.Text = "Base Configuration";
            this.lblConfigBasicParameter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabConfigStation
            // 
            this.tabConfigStation.Controls.Add(this.panel12);
            this.tabConfigStation.Location = new System.Drawing.Point(4, 25);
            this.tabConfigStation.Name = "tabConfigStation";
            this.tabConfigStation.Size = new System.Drawing.Size(1793, 812);
            this.tabConfigStation.TabIndex = 8;
            this.tabConfigStation.Text = "Station Configuration";
            this.tabConfigStation.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel12.Controls.Add(this.dgvStationInformation);
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1793, 812);
            this.panel12.TabIndex = 2;
            // 
            // dgvStationInformation
            // 
            this.dgvStationInformation.AllowUserToAddRows = false;
            this.dgvStationInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStationInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctxtStationType,
            this.ctxtTypeName,
            this.ctxtStationNo,
            this.ctxtStationName,
            this.ctxtStationRfid,
            this.ctxtStationMatchValue,
            this.ctxtStationInformation,
            this.ctxtStationGroup,
            this.ccbStationEnable,
            this.ctxtStationDescribe,
            this.ctxtStationBindAgv,
            this.txtStationState,
            this.txtStationHandle,
            this.txtStationUpdateTime,
            this.cbtnStationOperate,
            this.cbtnStationDelete});
            this.dgvStationInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStationInformation.Location = new System.Drawing.Point(0, 80);
            this.dgvStationInformation.Name = "dgvStationInformation";
            this.dgvStationInformation.RowHeadersVisible = false;
            this.dgvStationInformation.RowTemplate.Height = 23;
            this.dgvStationInformation.Size = new System.Drawing.Size(1793, 732);
            this.dgvStationInformation.TabIndex = 10;
            this.dgvStationInformation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStationInformation_CellClick);
            // 
            // ctxtStationType
            // 
            this.ctxtStationType.HeaderText = "Type";
            this.ctxtStationType.Name = "ctxtStationType";
            this.ctxtStationType.ReadOnly = true;
            // 
            // ctxtTypeName
            // 
            this.ctxtTypeName.HeaderText = "Type name";
            this.ctxtTypeName.Name = "ctxtTypeName";
            // 
            // ctxtStationNo
            // 
            this.ctxtStationNo.HeaderText = "Id";
            this.ctxtStationNo.Name = "ctxtStationNo";
            this.ctxtStationNo.ReadOnly = true;
            // 
            // ctxtStationName
            // 
            this.ctxtStationName.HeaderText = "Name";
            this.ctxtStationName.Name = "ctxtStationName";
            // 
            // ctxtStationRfid
            // 
            this.ctxtStationRfid.HeaderText = "Bind rfid";
            this.ctxtStationRfid.Name = "ctxtStationRfid";
            // 
            // ctxtStationMatchValue
            // 
            this.ctxtStationMatchValue.HeaderText = "Match value";
            this.ctxtStationMatchValue.Name = "ctxtStationMatchValue";
            // 
            // ctxtStationInformation
            // 
            this.ctxtStationInformation.HeaderText = "Site operation";
            this.ctxtStationInformation.Name = "ctxtStationInformation";
            this.ctxtStationInformation.Width = 150;
            // 
            // ctxtStationGroup
            // 
            this.ctxtStationGroup.HeaderText = "Group";
            this.ctxtStationGroup.Name = "ctxtStationGroup";
            // 
            // ccbStationEnable
            // 
            this.ccbStationEnable.FalseValue = "False";
            this.ccbStationEnable.HeaderText = "Enable";
            this.ccbStationEnable.Name = "ccbStationEnable";
            this.ccbStationEnable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ccbStationEnable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ccbStationEnable.TrueValue = "True";
            // 
            // ctxtStationDescribe
            // 
            this.ctxtStationDescribe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ctxtStationDescribe.HeaderText = "Describe";
            this.ctxtStationDescribe.Name = "ctxtStationDescribe";
            // 
            // ctxtStationBindAgv
            // 
            this.ctxtStationBindAgv.HeaderText = "PassRfid";
            this.ctxtStationBindAgv.Name = "ctxtStationBindAgv";
            // 
            // txtStationState
            // 
            this.txtStationState.HeaderText = "State";
            this.txtStationState.Name = "txtStationState";
            // 
            // txtStationHandle
            // 
            this.txtStationHandle.HeaderText = "Handle";
            this.txtStationHandle.Name = "txtStationHandle";
            // 
            // txtStationUpdateTime
            // 
            this.txtStationUpdateTime.HeaderText = "UpdateTime";
            this.txtStationUpdateTime.Name = "txtStationUpdateTime";
            // 
            // cbtnStationOperate
            // 
            this.cbtnStationOperate.HeaderText = "Operation";
            this.cbtnStationOperate.Name = "cbtnStationOperate";
            this.cbtnStationOperate.Text = "Modify";
            this.cbtnStationOperate.UseColumnTextForButtonValue = true;
            // 
            // cbtnStationDelete
            // 
            this.cbtnStationDelete.HeaderText = "Delete";
            this.cbtnStationDelete.Name = "cbtnStationDelete";
            this.cbtnStationDelete.Text = "Delete";
            this.cbtnStationDelete.UseColumnTextForButtonValue = true;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel13.Controls.Add(this.btnStationReceive);
            this.panel13.Controls.Add(this.panel45);
            this.panel13.Controls.Add(this.panel70);
            this.panel13.Controls.Add(this.txtStationDescribe);
            this.panel13.Controls.Add(this.label21);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Controls.Add(this.label22);
            this.panel13.Controls.Add(this.panel41);
            this.panel13.Controls.Add(this.panel22);
            this.panel13.Controls.Add(this.panel16);
            this.panel13.Controls.Add(this.panel19);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1793, 80);
            this.panel13.TabIndex = 0;
            // 
            // btnStationReceive
            // 
            this.btnStationReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStationReceive.Location = new System.Drawing.Point(1284, 0);
            this.btnStationReceive.Name = "btnStationReceive";
            this.btnStationReceive.Size = new System.Drawing.Size(507, 78);
            this.btnStationReceive.TabIndex = 8;
            this.btnStationReceive.Text = "Receive";
            this.btnStationReceive.UseVisualStyleBackColor = true;
            this.btnStationReceive.Click += new System.EventHandler(this.btnStationReceive_Click);
            // 
            // panel45
            // 
            this.panel45.Controls.Add(this.cbbStationTypeShow1);
            this.panel45.Controls.Add(this.label53);
            this.panel45.Controls.Add(this.cbbStationTypeShow);
            this.panel45.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel45.Location = new System.Drawing.Point(1160, 0);
            this.panel45.Name = "panel45";
            this.panel45.Size = new System.Drawing.Size(124, 78);
            this.panel45.TabIndex = 12;
            // 
            // cbbStationTypeShow1
            // 
            this.cbbStationTypeShow1.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbStationTypeShow1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStationTypeShow1.FormattingEnabled = true;
            this.cbbStationTypeShow1.Items.AddRange(new object[] {
            "全部",
            "分容测试上下料区",
            "分容柜",
            "预充老化装料区",
            "预充老化房",
            "预充老化静置区",
            "预充老化卸料区",
            "分容老化装料区",
            "分容老化房",
            "分容老化静置区",
            "分容老化卸料区"});
            this.cbbStationTypeShow1.Location = new System.Drawing.Point(0, 50);
            this.cbbStationTypeShow1.Name = "cbbStationTypeShow1";
            this.cbbStationTypeShow1.Size = new System.Drawing.Size(124, 23);
            this.cbbStationTypeShow1.TabIndex = 8;
            // 
            // label53
            // 
            this.label53.Dock = System.Windows.Forms.DockStyle.Top;
            this.label53.Location = new System.Drawing.Point(0, 23);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(124, 27);
            this.label53.TabIndex = 7;
            this.label53.Text = "Group";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbStationTypeShow
            // 
            this.cbbStationTypeShow.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbbStationTypeShow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStationTypeShow.FormattingEnabled = true;
            this.cbbStationTypeShow.Items.AddRange(new object[] {
            "All",
            "Type1",
            "Type2",
            "Type3",
            "Type4",
            "Type5",
            "Type6",
            "Type7",
            "Type8",
            "Type9",
            "Type10",
            "Type11",
            "Type12",
            "Type13",
            "Type14"});
            this.cbbStationTypeShow.Location = new System.Drawing.Point(0, 0);
            this.cbbStationTypeShow.Name = "cbbStationTypeShow";
            this.cbbStationTypeShow.Size = new System.Drawing.Size(124, 23);
            this.cbbStationTypeShow.TabIndex = 6;
            this.cbbStationTypeShow.SelectedIndexChanged += new System.EventHandler(this.cbbStationTypeShow_SelectedIndexChanged);
            // 
            // panel70
            // 
            this.panel70.Controls.Add(this.btnCellsStationAdd);
            this.panel70.Controls.Add(this.btnStationAdd);
            this.panel70.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel70.Location = new System.Drawing.Point(1082, 0);
            this.panel70.Name = "panel70";
            this.panel70.Size = new System.Drawing.Size(78, 78);
            this.panel70.TabIndex = 13;
            // 
            // btnCellsStationAdd
            // 
            this.btnCellsStationAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCellsStationAdd.Font = new System.Drawing.Font("SimSun", 9F);
            this.btnCellsStationAdd.Location = new System.Drawing.Point(0, 42);
            this.btnCellsStationAdd.Name = "btnCellsStationAdd";
            this.btnCellsStationAdd.Size = new System.Drawing.Size(78, 36);
            this.btnCellsStationAdd.TabIndex = 9;
            this.btnCellsStationAdd.Text = "Column add";
            this.btnCellsStationAdd.UseVisualStyleBackColor = true;
            this.btnCellsStationAdd.Visible = false;
            this.btnCellsStationAdd.Click += new System.EventHandler(this.btnCellsStationAdd_Click);
            // 
            // btnStationAdd
            // 
            this.btnStationAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStationAdd.Location = new System.Drawing.Point(0, 0);
            this.btnStationAdd.Name = "btnStationAdd";
            this.btnStationAdd.Size = new System.Drawing.Size(78, 42);
            this.btnStationAdd.TabIndex = 8;
            this.btnStationAdd.Text = "Add";
            this.btnStationAdd.UseVisualStyleBackColor = true;
            this.btnStationAdd.Click += new System.EventHandler(this.btnStationAdd_Click);
            // 
            // txtStationDescribe
            // 
            this.txtStationDescribe.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtStationDescribe.Location = new System.Drawing.Point(950, 0);
            this.txtStationDescribe.Multiline = true;
            this.txtStationDescribe.Name = "txtStationDescribe";
            this.txtStationDescribe.Size = new System.Drawing.Size(132, 78);
            this.txtStationDescribe.TabIndex = 6;
            this.txtStationDescribe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label21
            // 
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Dock = System.Windows.Forms.DockStyle.Left;
            this.label21.Location = new System.Drawing.Point(885, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(65, 78);
            this.label21.TabIndex = 11;
            this.label21.Text = "Describe";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.cbStationEnable);
            this.panel14.Controls.Add(this.panel15);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(807, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(78, 78);
            this.panel14.TabIndex = 5;
            // 
            // cbStationEnable
            // 
            this.cbStationEnable.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbStationEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStationEnable.FormattingEnabled = true;
            this.cbStationEnable.Items.AddRange(new object[] {
            "Enable",
            "disable"});
            this.cbStationEnable.Location = new System.Drawing.Point(0, 18);
            this.cbStationEnable.Name = "cbStationEnable";
            this.cbStationEnable.Size = new System.Drawing.Size(78, 23);
            this.cbStationEnable.TabIndex = 6;
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(78, 18);
            this.panel15.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label22.Dock = System.Windows.Forms.DockStyle.Left;
            this.label22.Location = new System.Drawing.Point(742, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 78);
            this.label22.TabIndex = 8;
            this.label22.Text = "Enable";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel41
            // 
            this.panel41.Controls.Add(this.panel42);
            this.panel41.Controls.Add(this.panel43);
            this.panel41.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel41.Location = new System.Drawing.Point(600, 0);
            this.panel41.Name = "panel41";
            this.panel41.Size = new System.Drawing.Size(142, 78);
            this.panel41.TabIndex = 4;
            // 
            // panel42
            // 
            this.panel42.Controls.Add(this.txtStationGroup);
            this.panel42.Controls.Add(this.label15);
            this.panel42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel42.Location = new System.Drawing.Point(0, 42);
            this.panel42.Name = "panel42";
            this.panel42.Size = new System.Drawing.Size(142, 36);
            this.panel42.TabIndex = 2;
            // 
            // txtStationGroup
            // 
            this.txtStationGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStationGroup.Location = new System.Drawing.Point(79, 0);
            this.txtStationGroup.Multiline = true;
            this.txtStationGroup.Name = "txtStationGroup";
            this.txtStationGroup.Size = new System.Drawing.Size(63, 36);
            this.txtStationGroup.TabIndex = 3;
            this.txtStationGroup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.label15.Location = new System.Drawing.Point(0, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 36);
            this.label15.TabIndex = 5;
            this.label15.Text = "Group";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel43
            // 
            this.panel43.Controls.Add(this.txtStationOperate);
            this.panel43.Controls.Add(this.label49);
            this.panel43.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel43.Location = new System.Drawing.Point(0, 0);
            this.panel43.Name = "panel43";
            this.panel43.Size = new System.Drawing.Size(142, 42);
            this.panel43.TabIndex = 1;
            // 
            // txtStationOperate
            // 
            this.txtStationOperate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStationOperate.Location = new System.Drawing.Point(79, 0);
            this.txtStationOperate.Multiline = true;
            this.txtStationOperate.Name = "txtStationOperate";
            this.txtStationOperate.Size = new System.Drawing.Size(63, 42);
            this.txtStationOperate.TabIndex = 2;
            this.txtStationOperate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtStationOperate.MouseLeave += new System.EventHandler(this.txtStationOperate_MouseLeave);
            this.txtStationOperate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtStationOperate_MouseMove);
            // 
            // label49
            // 
            this.label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label49.Dock = System.Windows.Forms.DockStyle.Left;
            this.label49.Location = new System.Drawing.Point(0, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(79, 42);
            this.label49.TabIndex = 3;
            this.label49.Text = "Operation";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.panel23);
            this.panel22.Controls.Add(this.panel24);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel22.Location = new System.Drawing.Point(400, 0);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(200, 78);
            this.panel22.TabIndex = 3;
            // 
            // panel23
            // 
            this.panel23.Controls.Add(this.txtStationMatchValue);
            this.panel23.Controls.Add(this.label31);
            this.panel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel23.Location = new System.Drawing.Point(0, 42);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(200, 36);
            this.panel23.TabIndex = 2;
            // 
            // txtStationMatchValue
            // 
            this.txtStationMatchValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStationMatchValue.Location = new System.Drawing.Point(85, 0);
            this.txtStationMatchValue.Multiline = true;
            this.txtStationMatchValue.Name = "txtStationMatchValue";
            this.txtStationMatchValue.Size = new System.Drawing.Size(115, 36);
            this.txtStationMatchValue.TabIndex = 3;
            this.txtStationMatchValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label31
            // 
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label31.Dock = System.Windows.Forms.DockStyle.Left;
            this.label31.Location = new System.Drawing.Point(0, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(85, 36);
            this.label31.TabIndex = 5;
            this.label31.Text = "Match value";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.txtStationRfid);
            this.panel24.Controls.Add(this.label32);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(0, 0);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(200, 42);
            this.panel24.TabIndex = 1;
            // 
            // txtStationRfid
            // 
            this.txtStationRfid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStationRfid.Location = new System.Drawing.Point(85, 0);
            this.txtStationRfid.Multiline = true;
            this.txtStationRfid.Name = "txtStationRfid";
            this.txtStationRfid.Size = new System.Drawing.Size(115, 42);
            this.txtStationRfid.TabIndex = 2;
            this.txtStationRfid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label32
            // 
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label32.Dock = System.Windows.Forms.DockStyle.Left;
            this.label32.Location = new System.Drawing.Point(0, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(85, 42);
            this.label32.TabIndex = 3;
            this.label32.Text = "Bind Rfid";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.panel17);
            this.panel16.Controls.Add(this.panel18);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel16.Location = new System.Drawing.Point(200, 0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(200, 78);
            this.panel16.TabIndex = 2;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.txtStationName);
            this.panel17.Controls.Add(this.label25);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(0, 42);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(200, 36);
            this.panel17.TabIndex = 2;
            // 
            // txtStationName
            // 
            this.txtStationName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStationName.Location = new System.Drawing.Point(85, 0);
            this.txtStationName.Multiline = true;
            this.txtStationName.Name = "txtStationName";
            this.txtStationName.Size = new System.Drawing.Size(115, 36);
            this.txtStationName.TabIndex = 3;
            this.txtStationName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Dock = System.Windows.Forms.DockStyle.Left;
            this.label25.Location = new System.Drawing.Point(0, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(85, 36);
            this.label25.TabIndex = 5;
            this.label25.Text = "Name";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.txtStationNo);
            this.panel18.Controls.Add(this.label28);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(0, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(200, 42);
            this.panel18.TabIndex = 1;
            // 
            // txtStationNo
            // 
            this.txtStationNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStationNo.Location = new System.Drawing.Point(85, 0);
            this.txtStationNo.Multiline = true;
            this.txtStationNo.Name = "txtStationNo";
            this.txtStationNo.Size = new System.Drawing.Size(115, 42);
            this.txtStationNo.TabIndex = 2;
            this.txtStationNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label28
            // 
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Dock = System.Windows.Forms.DockStyle.Left;
            this.label28.Location = new System.Drawing.Point(0, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(85, 42);
            this.label28.TabIndex = 3;
            this.label28.Text = "Id";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel19
            // 
            this.panel19.Controls.Add(this.panel20);
            this.panel19.Controls.Add(this.panel21);
            this.panel19.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel19.Location = new System.Drawing.Point(0, 0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(200, 78);
            this.panel19.TabIndex = 1;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.txtStationTypeName);
            this.panel20.Controls.Add(this.label29);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel20.Location = new System.Drawing.Point(0, 42);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(200, 36);
            this.panel20.TabIndex = 2;
            // 
            // txtStationTypeName
            // 
            this.txtStationTypeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStationTypeName.Location = new System.Drawing.Point(85, 0);
            this.txtStationTypeName.Multiline = true;
            this.txtStationTypeName.Name = "txtStationTypeName";
            this.txtStationTypeName.Size = new System.Drawing.Size(115, 36);
            this.txtStationTypeName.TabIndex = 3;
            this.txtStationTypeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label29
            // 
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label29.Dock = System.Windows.Forms.DockStyle.Left;
            this.label29.Location = new System.Drawing.Point(0, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(85, 36);
            this.label29.TabIndex = 5;
            this.label29.Text = "Type name";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel21
            // 
            this.panel21.Controls.Add(this.txtStationType);
            this.panel21.Controls.Add(this.label30);
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(0, 0);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(200, 42);
            this.panel21.TabIndex = 1;
            // 
            // txtStationType
            // 
            this.txtStationType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtStationType.Location = new System.Drawing.Point(85, 0);
            this.txtStationType.Multiline = true;
            this.txtStationType.Name = "txtStationType";
            this.txtStationType.Size = new System.Drawing.Size(115, 42);
            this.txtStationType.TabIndex = 2;
            this.txtStationType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tooltip.SetToolTip(this.txtStationType, "1 :分容柜位置\r\n2 :分容上下料点\r\n11:预充老化上料点\r\n12:预充老化存储点\r\n13:预充老化静置区\r\n14:预充老化下料点\r\n21:分容老化上料点\r\n" +
        "22:分容老化存储点\r\n23:分容老化静置区\r\n24:分容老化下料点\r\n31:分容测试充电区\r\n32:预充老化充电区\r\n33:分容老化充电区\r\n41:分容测试闲" +
        "置区");
            // 
            // label30
            // 
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label30.Dock = System.Windows.Forms.DockStyle.Left;
            this.label30.Location = new System.Drawing.Point(0, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(85, 42);
            this.label30.TabIndex = 3;
            this.label30.Text = "Type";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabConfigCharge
            // 
            this.tabConfigCharge.Controls.Add(this.panCharge);
            this.tabConfigCharge.Location = new System.Drawing.Point(4, 25);
            this.tabConfigCharge.Name = "tabConfigCharge";
            this.tabConfigCharge.Size = new System.Drawing.Size(1793, 812);
            this.tabConfigCharge.TabIndex = 6;
            this.tabConfigCharge.Text = "Charge Configuration";
            this.tabConfigCharge.UseVisualStyleBackColor = true;
            // 
            // panCharge
            // 
            this.panCharge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panCharge.Controls.Add(this.dgvChargeInfo);
            this.panCharge.Controls.Add(this.panChargeAdd);
            this.panCharge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panCharge.Location = new System.Drawing.Point(0, 0);
            this.panCharge.Name = "panCharge";
            this.panCharge.Size = new System.Drawing.Size(1793, 812);
            this.panCharge.TabIndex = 0;
            // 
            // dgvChargeInfo
            // 
            this.dgvChargeInfo.AllowUserToAddRows = false;
            this.dgvChargeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChargeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctxtChargeNo,
            this.ccbChargeName,
            this.ctxtChargeIp,
            this.ctxtChargePort,
            this.ctxtChargeRfid,
            this.ccbChargeType,
            this.ccbChargeEnable,
            this.ctxtChargeDescribe,
            this.cbtnChargeOperate,
            this.cbtnChargeDelete});
            this.dgvChargeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChargeInfo.Location = new System.Drawing.Point(0, 61);
            this.dgvChargeInfo.Name = "dgvChargeInfo";
            this.dgvChargeInfo.RowHeadersVisible = false;
            this.dgvChargeInfo.RowTemplate.Height = 23;
            this.dgvChargeInfo.Size = new System.Drawing.Size(1793, 751);
            this.dgvChargeInfo.TabIndex = 1;
            this.dgvChargeInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChargeInfo_CellContentClick);
            // 
            // ctxtChargeNo
            // 
            this.ctxtChargeNo.HeaderText = "Id";
            this.ctxtChargeNo.Name = "ctxtChargeNo";
            this.ctxtChargeNo.ReadOnly = true;
            // 
            // ccbChargeName
            // 
            this.ccbChargeName.HeaderText = "Name";
            this.ccbChargeName.Name = "ccbChargeName";
            // 
            // ctxtChargeIp
            // 
            this.ctxtChargeIp.HeaderText = "Ip";
            this.ctxtChargeIp.Name = "ctxtChargeIp";
            this.ctxtChargeIp.Width = 150;
            // 
            // ctxtChargePort
            // 
            this.ctxtChargePort.HeaderText = "Port";
            this.ctxtChargePort.Name = "ctxtChargePort";
            this.ctxtChargePort.Width = 150;
            // 
            // ctxtChargeRfid
            // 
            this.ctxtChargeRfid.HeaderText = "RFID";
            this.ctxtChargeRfid.Name = "ctxtChargeRfid";
            // 
            // ccbChargeType
            // 
            this.ccbChargeType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ccbChargeType.HeaderText = "Type";
            this.ccbChargeType.Items.AddRange(new object[] {
            "Type1",
            "Type2",
            "Type3"});
            this.ccbChargeType.Name = "ccbChargeType";
            this.ccbChargeType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ccbChargeType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ccbChargeEnable
            // 
            this.ccbChargeEnable.FalseValue = "False";
            this.ccbChargeEnable.HeaderText = "Enable";
            this.ccbChargeEnable.Name = "ccbChargeEnable";
            this.ccbChargeEnable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ccbChargeEnable.TrueValue = "True";
            // 
            // ctxtChargeDescribe
            // 
            this.ctxtChargeDescribe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ctxtChargeDescribe.HeaderText = "Group";
            this.ctxtChargeDescribe.Name = "ctxtChargeDescribe";
            // 
            // cbtnChargeOperate
            // 
            this.cbtnChargeOperate.HeaderText = "Operate";
            this.cbtnChargeOperate.Name = "cbtnChargeOperate";
            this.cbtnChargeOperate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cbtnChargeOperate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cbtnChargeOperate.Text = "Modify";
            this.cbtnChargeOperate.UseColumnTextForButtonValue = true;
            // 
            // cbtnChargeDelete
            // 
            this.cbtnChargeDelete.HeaderText = "Delete";
            this.cbtnChargeDelete.Name = "cbtnChargeDelete";
            this.cbtnChargeDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cbtnChargeDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.cbtnChargeDelete.Text = "Delete";
            this.cbtnChargeDelete.UseColumnTextForButtonValue = true;
            // 
            // panChargeAdd
            // 
            this.panChargeAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panChargeAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panChargeAdd.Controls.Add(this.btnChargeRec);
            this.panChargeAdd.Controls.Add(this.btnChargeAdd);
            this.panChargeAdd.Controls.Add(this.txtChargedescribe);
            this.panChargeAdd.Controls.Add(this.label17);
            this.panChargeAdd.Controls.Add(this.panChargeEnable);
            this.panChargeAdd.Controls.Add(this.label10);
            this.panChargeAdd.Controls.Add(this.panel52);
            this.panChargeAdd.Controls.Add(this.label55);
            this.panChargeAdd.Controls.Add(this.txtChargeRfid);
            this.panChargeAdd.Controls.Add(this.label9);
            this.panChargeAdd.Controls.Add(this.panel49);
            this.panChargeAdd.Controls.Add(this.panel46);
            this.panChargeAdd.Dock = System.Windows.Forms.DockStyle.Top;
            this.panChargeAdd.Location = new System.Drawing.Point(0, 0);
            this.panChargeAdd.Name = "panChargeAdd";
            this.panChargeAdd.Size = new System.Drawing.Size(1793, 61);
            this.panChargeAdd.TabIndex = 0;
            // 
            // btnChargeRec
            // 
            this.btnChargeRec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChargeRec.Location = new System.Drawing.Point(1198, 0);
            this.btnChargeRec.Name = "btnChargeRec";
            this.btnChargeRec.Size = new System.Drawing.Size(593, 59);
            this.btnChargeRec.TabIndex = 8;
            this.btnChargeRec.Text = "Receive";
            this.btnChargeRec.UseVisualStyleBackColor = true;
            this.btnChargeRec.Click += new System.EventHandler(this.btnChargeRec_Click);
            // 
            // btnChargeAdd
            // 
            this.btnChargeAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnChargeAdd.Location = new System.Drawing.Point(1116, 0);
            this.btnChargeAdd.Name = "btnChargeAdd";
            this.btnChargeAdd.Size = new System.Drawing.Size(82, 59);
            this.btnChargeAdd.TabIndex = 7;
            this.btnChargeAdd.Text = "Add";
            this.btnChargeAdd.UseVisualStyleBackColor = true;
            this.btnChargeAdd.Click += new System.EventHandler(this.btnChargeAdd_Click);
            // 
            // txtChargedescribe
            // 
            this.txtChargedescribe.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtChargedescribe.Location = new System.Drawing.Point(1016, 0);
            this.txtChargedescribe.Multiline = true;
            this.txtChargedescribe.Name = "txtChargedescribe";
            this.txtChargedescribe.Size = new System.Drawing.Size(100, 59);
            this.txtChargedescribe.TabIndex = 6;
            this.txtChargedescribe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Location = new System.Drawing.Point(931, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 59);
            this.label17.TabIndex = 11;
            this.label17.Text = "Group";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panChargeEnable
            // 
            this.panChargeEnable.Controls.Add(this.cbChargeEnable);
            this.panChargeEnable.Controls.Add(this.panel3);
            this.panChargeEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.panChargeEnable.Location = new System.Drawing.Point(843, 0);
            this.panChargeEnable.Name = "panChargeEnable";
            this.panChargeEnable.Size = new System.Drawing.Size(88, 59);
            this.panChargeEnable.TabIndex = 5;
            // 
            // cbChargeEnable
            // 
            this.cbChargeEnable.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbChargeEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChargeEnable.FormattingEnabled = true;
            this.cbChargeEnable.Items.AddRange(new object[] {
            "Enable",
            "Disable"});
            this.cbChargeEnable.Location = new System.Drawing.Point(0, 18);
            this.cbChargeEnable.Name = "cbChargeEnable";
            this.cbChargeEnable.Size = new System.Drawing.Size(88, 23);
            this.cbChargeEnable.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(88, 18);
            this.panel3.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(758, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 59);
            this.label10.TabIndex = 8;
            this.label10.Text = "Enable";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel52
            // 
            this.panel52.Controls.Add(this.cbChargeType);
            this.panel52.Controls.Add(this.panel53);
            this.panel52.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel52.Location = new System.Drawing.Point(670, 0);
            this.panel52.Name = "panel52";
            this.panel52.Size = new System.Drawing.Size(88, 59);
            this.panel52.TabIndex = 23;
            // 
            // cbChargeType
            // 
            this.cbChargeType.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbChargeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChargeType.FormattingEnabled = true;
            this.cbChargeType.Items.AddRange(new object[] {
            "Type1",
            "Type2",
            "Type3"});
            this.cbChargeType.Location = new System.Drawing.Point(0, 18);
            this.cbChargeType.Name = "cbChargeType";
            this.cbChargeType.Size = new System.Drawing.Size(88, 23);
            this.cbChargeType.TabIndex = 1;
            // 
            // panel53
            // 
            this.panel53.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel53.Location = new System.Drawing.Point(0, 0);
            this.panel53.Name = "panel53";
            this.panel53.Size = new System.Drawing.Size(88, 18);
            this.panel53.TabIndex = 0;
            // 
            // label55
            // 
            this.label55.Dock = System.Windows.Forms.DockStyle.Left;
            this.label55.Location = new System.Drawing.Point(585, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(85, 59);
            this.label55.TabIndex = 24;
            this.label55.Text = "Type";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChargeRfid
            // 
            this.txtChargeRfid.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtChargeRfid.Location = new System.Drawing.Point(485, 0);
            this.txtChargeRfid.Multiline = true;
            this.txtChargeRfid.Name = "txtChargeRfid";
            this.txtChargeRfid.Size = new System.Drawing.Size(100, 59);
            this.txtChargeRfid.TabIndex = 4;
            this.txtChargeRfid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(400, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 59);
            this.label9.TabIndex = 6;
            this.label9.Text = "Bind rfid";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel49
            // 
            this.panel49.Controls.Add(this.panel50);
            this.panel49.Controls.Add(this.panel51);
            this.panel49.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel49.Location = new System.Drawing.Point(200, 0);
            this.panel49.Name = "panel49";
            this.panel49.Size = new System.Drawing.Size(200, 59);
            this.panel49.TabIndex = 22;
            // 
            // panel50
            // 
            this.panel50.Controls.Add(this.txtChargePort);
            this.panel50.Controls.Add(this.label7);
            this.panel50.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel50.Location = new System.Drawing.Point(0, 33);
            this.panel50.Name = "panel50";
            this.panel50.Size = new System.Drawing.Size(200, 26);
            this.panel50.TabIndex = 2;
            // 
            // txtChargePort
            // 
            this.txtChargePort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChargePort.Location = new System.Drawing.Point(85, 0);
            this.txtChargePort.Multiline = true;
            this.txtChargePort.Name = "txtChargePort";
            this.txtChargePort.Size = new System.Drawing.Size(115, 26);
            this.txtChargePort.TabIndex = 3;
            this.txtChargePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 26);
            this.label7.TabIndex = 5;
            this.label7.Text = "Port";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel51
            // 
            this.panel51.Controls.Add(this.txtChargeIp);
            this.panel51.Controls.Add(this.label8);
            this.panel51.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel51.Location = new System.Drawing.Point(0, 0);
            this.panel51.Name = "panel51";
            this.panel51.Size = new System.Drawing.Size(200, 33);
            this.panel51.TabIndex = 1;
            // 
            // txtChargeIp
            // 
            this.txtChargeIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChargeIp.Location = new System.Drawing.Point(85, 0);
            this.txtChargeIp.Multiline = true;
            this.txtChargeIp.Name = "txtChargeIp";
            this.txtChargeIp.Size = new System.Drawing.Size(115, 33);
            this.txtChargeIp.TabIndex = 2;
            this.txtChargeIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 33);
            this.label8.TabIndex = 3;
            this.label8.Text = "Ip";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel46
            // 
            this.panel46.Controls.Add(this.panel47);
            this.panel46.Controls.Add(this.panel48);
            this.panel46.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel46.Location = new System.Drawing.Point(0, 0);
            this.panel46.Name = "panel46";
            this.panel46.Size = new System.Drawing.Size(200, 59);
            this.panel46.TabIndex = 21;
            // 
            // panel47
            // 
            this.panel47.Controls.Add(this.txtChargeName);
            this.panel47.Controls.Add(this.label4);
            this.panel47.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel47.Location = new System.Drawing.Point(0, 33);
            this.panel47.Name = "panel47";
            this.panel47.Size = new System.Drawing.Size(200, 26);
            this.panel47.TabIndex = 2;
            // 
            // txtChargeName
            // 
            this.txtChargeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChargeName.Location = new System.Drawing.Point(85, 0);
            this.txtChargeName.Multiline = true;
            this.txtChargeName.Name = "txtChargeName";
            this.txtChargeName.Size = new System.Drawing.Size(115, 26);
            this.txtChargeName.TabIndex = 3;
            this.txtChargeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel48
            // 
            this.panel48.Controls.Add(this.txtChargeNo);
            this.panel48.Controls.Add(this.label54);
            this.panel48.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel48.Location = new System.Drawing.Point(0, 0);
            this.panel48.Name = "panel48";
            this.panel48.Size = new System.Drawing.Size(200, 33);
            this.panel48.TabIndex = 1;
            // 
            // txtChargeNo
            // 
            this.txtChargeNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtChargeNo.Location = new System.Drawing.Point(85, 0);
            this.txtChargeNo.Multiline = true;
            this.txtChargeNo.Name = "txtChargeNo";
            this.txtChargeNo.Size = new System.Drawing.Size(115, 33);
            this.txtChargeNo.TabIndex = 2;
            this.txtChargeNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label54
            // 
            this.label54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label54.Dock = System.Windows.Forms.DockStyle.Left;
            this.label54.Location = new System.Drawing.Point(0, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(85, 33);
            this.label54.TabIndex = 3;
            this.label54.Text = "Id";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabConfigElevator
            // 
            this.tabConfigElevator.Controls.Add(this.panel25);
            this.tabConfigElevator.Location = new System.Drawing.Point(4, 25);
            this.tabConfigElevator.Name = "tabConfigElevator";
            this.tabConfigElevator.Size = new System.Drawing.Size(1793, 812);
            this.tabConfigElevator.TabIndex = 11;
            this.tabConfigElevator.Text = "电梯配置";
            this.tabConfigElevator.UseVisualStyleBackColor = true;
            // 
            // panel25
            // 
            this.panel25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel25.Controls.Add(this.dgvElevator);
            this.panel25.Controls.Add(this.panel26);
            this.panel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel25.Location = new System.Drawing.Point(0, 0);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(1793, 812);
            this.panel25.TabIndex = 2;
            // 
            // dgvElevator
            // 
            this.dgvElevator.AllowUserToAddRows = false;
            this.dgvElevator.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvElevator.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dtxtElevatorNo,
            this.dtxtElevatorName,
            this.dtxtElevatorIp,
            this.dtxtElevatorPort,
            this.dtxtElevatorStopRfids,
            this.dtxtElevatorCallRfids,
            this.dtxtElevatorFloorNumber,
            this.dchbElevatorEnable,
            this.dbtnOperate,
            this.dbtnDelete});
            this.dgvElevator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvElevator.Location = new System.Drawing.Point(0, 61);
            this.dgvElevator.Name = "dgvElevator";
            this.dgvElevator.RowHeadersVisible = false;
            this.dgvElevator.RowTemplate.Height = 23;
            this.dgvElevator.Size = new System.Drawing.Size(1793, 751);
            this.dgvElevator.TabIndex = 10;
            this.dgvElevator.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvElevator_CellClick);
            // 
            // dtxtElevatorNo
            // 
            this.dtxtElevatorNo.HeaderText = "编号";
            this.dtxtElevatorNo.Name = "dtxtElevatorNo";
            this.dtxtElevatorNo.ReadOnly = true;
            // 
            // dtxtElevatorName
            // 
            this.dtxtElevatorName.HeaderText = "名称";
            this.dtxtElevatorName.Name = "dtxtElevatorName";
            // 
            // dtxtElevatorIp
            // 
            this.dtxtElevatorIp.HeaderText = "ip地址";
            this.dtxtElevatorIp.Name = "dtxtElevatorIp";
            // 
            // dtxtElevatorPort
            // 
            this.dtxtElevatorPort.HeaderText = "端口号";
            this.dtxtElevatorPort.Name = "dtxtElevatorPort";
            // 
            // dtxtElevatorStopRfids
            // 
            this.dtxtElevatorStopRfids.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dtxtElevatorStopRfids.HeaderText = "停止RFID";
            this.dtxtElevatorStopRfids.Name = "dtxtElevatorStopRfids";
            // 
            // dtxtElevatorCallRfids
            // 
            this.dtxtElevatorCallRfids.HeaderText = "呼叫RFID";
            this.dtxtElevatorCallRfids.Name = "dtxtElevatorCallRfids";
            this.dtxtElevatorCallRfids.Width = 200;
            // 
            // dtxtElevatorFloorNumber
            // 
            this.dtxtElevatorFloorNumber.HeaderText = "楼层数量";
            this.dtxtElevatorFloorNumber.Name = "dtxtElevatorFloorNumber";
            // 
            // dchbElevatorEnable
            // 
            this.dchbElevatorEnable.FalseValue = "False";
            this.dchbElevatorEnable.HeaderText = "是否启用";
            this.dchbElevatorEnable.Name = "dchbElevatorEnable";
            this.dchbElevatorEnable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dchbElevatorEnable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dchbElevatorEnable.TrueValue = "True";
            // 
            // dbtnOperate
            // 
            this.dbtnOperate.HeaderText = "操作";
            this.dbtnOperate.Name = "dbtnOperate";
            this.dbtnOperate.Text = "修改";
            this.dbtnOperate.UseColumnTextForButtonValue = true;
            // 
            // dbtnDelete
            // 
            this.dbtnDelete.HeaderText = "删除";
            this.dbtnDelete.Name = "dbtnDelete";
            this.dbtnDelete.Text = "删除";
            this.dbtnDelete.UseColumnTextForButtonValue = true;
            // 
            // panel26
            // 
            this.panel26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel26.Controls.Add(this.btnElevatorReceive);
            this.panel26.Controls.Add(this.btnElevatorAdd);
            this.panel26.Controls.Add(this.txtElevatorNumber);
            this.panel26.Controls.Add(this.label24);
            this.panel26.Controls.Add(this.panel95);
            this.panel26.Controls.Add(this.label34);
            this.panel26.Controls.Add(this.txtElevatorCallRfids);
            this.panel26.Controls.Add(this.label35);
            this.panel26.Controls.Add(this.txtElevatorStopRfids);
            this.panel26.Controls.Add(this.label36);
            this.panel26.Controls.Add(this.panel97);
            this.panel26.Controls.Add(this.panel102);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel26.Location = new System.Drawing.Point(0, 0);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(1793, 61);
            this.panel26.TabIndex = 0;
            // 
            // btnElevatorReceive
            // 
            this.btnElevatorReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnElevatorReceive.Location = new System.Drawing.Point(1367, 0);
            this.btnElevatorReceive.Name = "btnElevatorReceive";
            this.btnElevatorReceive.Size = new System.Drawing.Size(424, 59);
            this.btnElevatorReceive.TabIndex = 9;
            this.btnElevatorReceive.Text = "获取";
            this.btnElevatorReceive.UseVisualStyleBackColor = true;
            this.btnElevatorReceive.Click += new System.EventHandler(this.btnElevatorReceive_Click);
            // 
            // btnElevatorAdd
            // 
            this.btnElevatorAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnElevatorAdd.Location = new System.Drawing.Point(1162, 0);
            this.btnElevatorAdd.Name = "btnElevatorAdd";
            this.btnElevatorAdd.Size = new System.Drawing.Size(205, 59);
            this.btnElevatorAdd.TabIndex = 8;
            this.btnElevatorAdd.Text = "添加";
            this.btnElevatorAdd.UseVisualStyleBackColor = true;
            this.btnElevatorAdd.Click += new System.EventHandler(this.btnElevatorAdd_Click);
            // 
            // txtElevatorNumber
            // 
            this.txtElevatorNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtElevatorNumber.Location = new System.Drawing.Point(1062, 0);
            this.txtElevatorNumber.Multiline = true;
            this.txtElevatorNumber.Name = "txtElevatorNumber";
            this.txtElevatorNumber.Size = new System.Drawing.Size(100, 59);
            this.txtElevatorNumber.TabIndex = 21;
            this.txtElevatorNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label24
            // 
            this.label24.Dock = System.Windows.Forms.DockStyle.Left;
            this.label24.Location = new System.Drawing.Point(977, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(85, 59);
            this.label24.TabIndex = 22;
            this.label24.Text = "电梯\r\n楼层数量";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel95
            // 
            this.panel95.Controls.Add(this.cbElevatorEnable);
            this.panel95.Controls.Add(this.panel96);
            this.panel95.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel95.Location = new System.Drawing.Point(855, 0);
            this.panel95.Name = "panel95";
            this.panel95.Size = new System.Drawing.Size(122, 59);
            this.panel95.TabIndex = 6;
            // 
            // cbElevatorEnable
            // 
            this.cbElevatorEnable.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbElevatorEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbElevatorEnable.FormattingEnabled = true;
            this.cbElevatorEnable.Items.AddRange(new object[] {
            "启用",
            "禁用"});
            this.cbElevatorEnable.Location = new System.Drawing.Point(0, 18);
            this.cbElevatorEnable.Name = "cbElevatorEnable";
            this.cbElevatorEnable.Size = new System.Drawing.Size(122, 23);
            this.cbElevatorEnable.TabIndex = 6;
            // 
            // panel96
            // 
            this.panel96.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel96.Location = new System.Drawing.Point(0, 0);
            this.panel96.Name = "panel96";
            this.panel96.Size = new System.Drawing.Size(122, 18);
            this.panel96.TabIndex = 0;
            // 
            // label34
            // 
            this.label34.Dock = System.Windows.Forms.DockStyle.Left;
            this.label34.Location = new System.Drawing.Point(770, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(85, 59);
            this.label34.TabIndex = 8;
            this.label34.Text = "电梯使能";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtElevatorCallRfids
            // 
            this.txtElevatorCallRfids.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtElevatorCallRfids.Location = new System.Drawing.Point(670, 0);
            this.txtElevatorCallRfids.Multiline = true;
            this.txtElevatorCallRfids.Name = "txtElevatorCallRfids";
            this.txtElevatorCallRfids.Size = new System.Drawing.Size(100, 59);
            this.txtElevatorCallRfids.TabIndex = 5;
            this.txtElevatorCallRfids.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label35
            // 
            this.label35.Dock = System.Windows.Forms.DockStyle.Left;
            this.label35.Location = new System.Drawing.Point(585, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(85, 59);
            this.label35.TabIndex = 18;
            this.label35.Text = "电梯呼叫RFID集合";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtElevatorStopRfids
            // 
            this.txtElevatorStopRfids.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtElevatorStopRfids.Location = new System.Drawing.Point(485, 0);
            this.txtElevatorStopRfids.Multiline = true;
            this.txtElevatorStopRfids.Name = "txtElevatorStopRfids";
            this.txtElevatorStopRfids.Size = new System.Drawing.Size(100, 59);
            this.txtElevatorStopRfids.TabIndex = 4;
            this.txtElevatorStopRfids.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label36
            // 
            this.label36.Dock = System.Windows.Forms.DockStyle.Left;
            this.label36.Location = new System.Drawing.Point(400, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(85, 59);
            this.label36.TabIndex = 6;
            this.label36.Text = "电梯停止\r\nRFID集合";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel97
            // 
            this.panel97.Controls.Add(this.panel98);
            this.panel97.Controls.Add(this.panel101);
            this.panel97.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel97.Location = new System.Drawing.Point(200, 0);
            this.panel97.Name = "panel97";
            this.panel97.Size = new System.Drawing.Size(200, 59);
            this.panel97.TabIndex = 2;
            // 
            // panel98
            // 
            this.panel98.Controls.Add(this.txtElevatorPort);
            this.panel98.Controls.Add(this.label38);
            this.panel98.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel98.Location = new System.Drawing.Point(0, 33);
            this.panel98.Name = "panel98";
            this.panel98.Size = new System.Drawing.Size(200, 26);
            this.panel98.TabIndex = 2;
            // 
            // txtElevatorPort
            // 
            this.txtElevatorPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtElevatorPort.Location = new System.Drawing.Point(85, 0);
            this.txtElevatorPort.Multiline = true;
            this.txtElevatorPort.Name = "txtElevatorPort";
            this.txtElevatorPort.Size = new System.Drawing.Size(115, 26);
            this.txtElevatorPort.TabIndex = 3;
            this.txtElevatorPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label38
            // 
            this.label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label38.Dock = System.Windows.Forms.DockStyle.Left;
            this.label38.Location = new System.Drawing.Point(0, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(85, 26);
            this.label38.TabIndex = 5;
            this.label38.Text = "电梯端口";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel101
            // 
            this.panel101.Controls.Add(this.txtElevatorIp);
            this.panel101.Controls.Add(this.label89);
            this.panel101.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel101.Location = new System.Drawing.Point(0, 0);
            this.panel101.Name = "panel101";
            this.panel101.Size = new System.Drawing.Size(200, 33);
            this.panel101.TabIndex = 1;
            // 
            // txtElevatorIp
            // 
            this.txtElevatorIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtElevatorIp.Location = new System.Drawing.Point(85, 0);
            this.txtElevatorIp.Multiline = true;
            this.txtElevatorIp.Name = "txtElevatorIp";
            this.txtElevatorIp.Size = new System.Drawing.Size(115, 33);
            this.txtElevatorIp.TabIndex = 2;
            this.txtElevatorIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label89
            // 
            this.label89.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label89.Dock = System.Windows.Forms.DockStyle.Left;
            this.label89.Location = new System.Drawing.Point(0, 0);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(85, 33);
            this.label89.TabIndex = 3;
            this.label89.Text = "电梯IP";
            this.label89.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel102
            // 
            this.panel102.Controls.Add(this.panel103);
            this.panel102.Controls.Add(this.panel104);
            this.panel102.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel102.Location = new System.Drawing.Point(0, 0);
            this.panel102.Name = "panel102";
            this.panel102.Size = new System.Drawing.Size(200, 59);
            this.panel102.TabIndex = 20;
            // 
            // panel103
            // 
            this.panel103.Controls.Add(this.txtElevatorName);
            this.panel103.Controls.Add(this.label90);
            this.panel103.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel103.Location = new System.Drawing.Point(0, 33);
            this.panel103.Name = "panel103";
            this.panel103.Size = new System.Drawing.Size(200, 26);
            this.panel103.TabIndex = 2;
            // 
            // txtElevatorName
            // 
            this.txtElevatorName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtElevatorName.Location = new System.Drawing.Point(85, 0);
            this.txtElevatorName.Multiline = true;
            this.txtElevatorName.Name = "txtElevatorName";
            this.txtElevatorName.Size = new System.Drawing.Size(115, 26);
            this.txtElevatorName.TabIndex = 3;
            this.txtElevatorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label90
            // 
            this.label90.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label90.Dock = System.Windows.Forms.DockStyle.Left;
            this.label90.Location = new System.Drawing.Point(0, 0);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(85, 26);
            this.label90.TabIndex = 5;
            this.label90.Text = "电梯名称";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel104
            // 
            this.panel104.Controls.Add(this.txtElevatorNo);
            this.panel104.Controls.Add(this.label91);
            this.panel104.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel104.Location = new System.Drawing.Point(0, 0);
            this.panel104.Name = "panel104";
            this.panel104.Size = new System.Drawing.Size(200, 33);
            this.panel104.TabIndex = 1;
            // 
            // txtElevatorNo
            // 
            this.txtElevatorNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtElevatorNo.Location = new System.Drawing.Point(85, 0);
            this.txtElevatorNo.Multiline = true;
            this.txtElevatorNo.Name = "txtElevatorNo";
            this.txtElevatorNo.Size = new System.Drawing.Size(115, 33);
            this.txtElevatorNo.TabIndex = 2;
            this.txtElevatorNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label91
            // 
            this.label91.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label91.Dock = System.Windows.Forms.DockStyle.Left;
            this.label91.Location = new System.Drawing.Point(0, 0);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(85, 33);
            this.label91.TabIndex = 3;
            this.label91.Text = "电梯编号";
            this.label91.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabConfigShutterDoor
            // 
            this.tabConfigShutterDoor.Controls.Add(this.panel4);
            this.tabConfigShutterDoor.Location = new System.Drawing.Point(4, 25);
            this.tabConfigShutterDoor.Name = "tabConfigShutterDoor";
            this.tabConfigShutterDoor.Size = new System.Drawing.Size(1793, 812);
            this.tabConfigShutterDoor.TabIndex = 7;
            this.tabConfigShutterDoor.Text = "房门配置";
            this.tabConfigShutterDoor.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel4.Controls.Add(this.dgvShutterDoor);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1793, 812);
            this.panel4.TabIndex = 1;
            // 
            // dgvShutterDoor
            // 
            this.dgvShutterDoor.AllowUserToAddRows = false;
            this.dgvShutterDoor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShutterDoor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ctxtDoorNo,
            this.ctxtDoorName,
            this.ctxtDoorIp,
            this.ctxtDoorPort,
            this.ctxtDoorStopRfids,
            this.ctxtDoorCallRfids,
            this.ccbDoorEnable,
            this.ctxtDoorRelation,
            this.ctxtDoorRelationNumber,
            this.cbtnDoorOperate,
            this.cBtnDoorDelete});
            this.dgvShutterDoor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShutterDoor.Location = new System.Drawing.Point(0, 61);
            this.dgvShutterDoor.Name = "dgvShutterDoor";
            this.dgvShutterDoor.RowHeadersVisible = false;
            this.dgvShutterDoor.RowTemplate.Height = 23;
            this.dgvShutterDoor.Size = new System.Drawing.Size(1793, 751);
            this.dgvShutterDoor.TabIndex = 10;
            this.dgvShutterDoor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShutterDoor_CellClick);
            // 
            // ctxtDoorNo
            // 
            this.ctxtDoorNo.HeaderText = "编号";
            this.ctxtDoorNo.Name = "ctxtDoorNo";
            this.ctxtDoorNo.ReadOnly = true;
            // 
            // ctxtDoorName
            // 
            this.ctxtDoorName.HeaderText = "名称";
            this.ctxtDoorName.Name = "ctxtDoorName";
            // 
            // ctxtDoorIp
            // 
            this.ctxtDoorIp.HeaderText = "ip地址";
            this.ctxtDoorIp.Name = "ctxtDoorIp";
            // 
            // ctxtDoorPort
            // 
            this.ctxtDoorPort.HeaderText = "端口号";
            this.ctxtDoorPort.Name = "ctxtDoorPort";
            // 
            // ctxtDoorStopRfids
            // 
            this.ctxtDoorStopRfids.HeaderText = "停止RFID";
            this.ctxtDoorStopRfids.Name = "ctxtDoorStopRfids";
            this.ctxtDoorStopRfids.Width = 200;
            // 
            // ctxtDoorCallRfids
            // 
            this.ctxtDoorCallRfids.HeaderText = "呼叫RFID";
            this.ctxtDoorCallRfids.Name = "ctxtDoorCallRfids";
            this.ctxtDoorCallRfids.Width = 200;
            // 
            // ccbDoorEnable
            // 
            this.ccbDoorEnable.FalseValue = "False";
            this.ccbDoorEnable.HeaderText = "是否启用";
            this.ccbDoorEnable.Name = "ccbDoorEnable";
            this.ccbDoorEnable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ccbDoorEnable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ccbDoorEnable.TrueValue = "True";
            // 
            // ctxtDoorRelation
            // 
            this.ctxtDoorRelation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ctxtDoorRelation.HeaderText = "关联房门";
            this.ctxtDoorRelation.Name = "ctxtDoorRelation";
            // 
            // ctxtDoorRelationNumber
            // 
            this.ctxtDoorRelationNumber.HeaderText = "关联序号";
            this.ctxtDoorRelationNumber.Name = "ctxtDoorRelationNumber";
            // 
            // cbtnDoorOperate
            // 
            this.cbtnDoorOperate.HeaderText = "操作";
            this.cbtnDoorOperate.Name = "cbtnDoorOperate";
            this.cbtnDoorOperate.Text = "修改";
            this.cbtnDoorOperate.UseColumnTextForButtonValue = true;
            // 
            // cBtnDoorDelete
            // 
            this.cBtnDoorDelete.HeaderText = "删除";
            this.cBtnDoorDelete.Name = "cBtnDoorDelete";
            this.cBtnDoorDelete.Text = "删除";
            this.cBtnDoorDelete.UseColumnTextForButtonValue = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnShutterDoorReceive);
            this.panel5.Controls.Add(this.btnShutterDoorAdd);
            this.panel5.Controls.Add(this.panel33);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.txtShutterCallRfids);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Controls.Add(this.txtShutterStopRfids);
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Controls.Add(this.panel38);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1793, 61);
            this.panel5.TabIndex = 0;
            // 
            // btnShutterDoorReceive
            // 
            this.btnShutterDoorReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnShutterDoorReceive.Location = new System.Drawing.Point(1259, 0);
            this.btnShutterDoorReceive.Name = "btnShutterDoorReceive";
            this.btnShutterDoorReceive.Size = new System.Drawing.Size(532, 59);
            this.btnShutterDoorReceive.TabIndex = 9;
            this.btnShutterDoorReceive.Text = "获取";
            this.btnShutterDoorReceive.UseVisualStyleBackColor = true;
            this.btnShutterDoorReceive.Click += new System.EventHandler(this.btnShutterDoorRec_Click);
            // 
            // btnShutterDoorAdd
            // 
            this.btnShutterDoorAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnShutterDoorAdd.Location = new System.Drawing.Point(1177, 0);
            this.btnShutterDoorAdd.Name = "btnShutterDoorAdd";
            this.btnShutterDoorAdd.Size = new System.Drawing.Size(82, 59);
            this.btnShutterDoorAdd.TabIndex = 8;
            this.btnShutterDoorAdd.Text = "添加";
            this.btnShutterDoorAdd.UseVisualStyleBackColor = true;
            this.btnShutterDoorAdd.Click += new System.EventHandler(this.btnShutterDoorAdd_Click);
            // 
            // panel33
            // 
            this.panel33.Controls.Add(this.panel34);
            this.panel33.Controls.Add(this.panel35);
            this.panel33.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel33.Location = new System.Drawing.Point(977, 0);
            this.panel33.Name = "panel33";
            this.panel33.Size = new System.Drawing.Size(200, 59);
            this.panel33.TabIndex = 19;
            // 
            // panel34
            // 
            this.panel34.Controls.Add(this.txtShutterRelationNumber);
            this.panel34.Controls.Add(this.label44);
            this.panel34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel34.Location = new System.Drawing.Point(0, 33);
            this.panel34.Name = "panel34";
            this.panel34.Size = new System.Drawing.Size(200, 26);
            this.panel34.TabIndex = 2;
            // 
            // txtShutterRelationNumber
            // 
            this.txtShutterRelationNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShutterRelationNumber.Location = new System.Drawing.Point(85, 0);
            this.txtShutterRelationNumber.Multiline = true;
            this.txtShutterRelationNumber.Name = "txtShutterRelationNumber";
            this.txtShutterRelationNumber.Size = new System.Drawing.Size(115, 26);
            this.txtShutterRelationNumber.TabIndex = 3;
            this.txtShutterRelationNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label44
            // 
            this.label44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label44.Dock = System.Windows.Forms.DockStyle.Left;
            this.label44.Location = new System.Drawing.Point(0, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(85, 26);
            this.label44.TabIndex = 5;
            this.label44.Text = "关联序号";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel35
            // 
            this.panel35.Controls.Add(this.txtShutterRelation);
            this.panel35.Controls.Add(this.label45);
            this.panel35.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel35.Location = new System.Drawing.Point(0, 0);
            this.panel35.Name = "panel35";
            this.panel35.Size = new System.Drawing.Size(200, 33);
            this.panel35.TabIndex = 1;
            // 
            // txtShutterRelation
            // 
            this.txtShutterRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShutterRelation.Location = new System.Drawing.Point(85, 0);
            this.txtShutterRelation.Multiline = true;
            this.txtShutterRelation.Name = "txtShutterRelation";
            this.txtShutterRelation.Size = new System.Drawing.Size(115, 33);
            this.txtShutterRelation.TabIndex = 2;
            this.txtShutterRelation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label45
            // 
            this.label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label45.Dock = System.Windows.Forms.DockStyle.Left;
            this.label45.Location = new System.Drawing.Point(0, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(85, 33);
            this.label45.TabIndex = 3;
            this.label45.Text = "关联房门";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cbShutterDoorEnable);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(855, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(122, 59);
            this.panel6.TabIndex = 6;
            // 
            // cbShutterDoorEnable
            // 
            this.cbShutterDoorEnable.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbShutterDoorEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShutterDoorEnable.FormattingEnabled = true;
            this.cbShutterDoorEnable.Items.AddRange(new object[] {
            "启用",
            "禁用"});
            this.cbShutterDoorEnable.Location = new System.Drawing.Point(0, 18);
            this.cbShutterDoorEnable.Name = "cbShutterDoorEnable";
            this.cbShutterDoorEnable.Size = new System.Drawing.Size(122, 23);
            this.cbShutterDoorEnable.TabIndex = 6;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(122, 18);
            this.panel7.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Left;
            this.label11.Location = new System.Drawing.Point(770, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 59);
            this.label11.TabIndex = 8;
            this.label11.Text = "房门使能";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtShutterCallRfids
            // 
            this.txtShutterCallRfids.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtShutterCallRfids.Location = new System.Drawing.Point(670, 0);
            this.txtShutterCallRfids.Multiline = true;
            this.txtShutterCallRfids.Name = "txtShutterCallRfids";
            this.txtShutterCallRfids.Size = new System.Drawing.Size(100, 59);
            this.txtShutterCallRfids.TabIndex = 5;
            this.txtShutterCallRfids.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.Location = new System.Drawing.Point(585, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 59);
            this.label18.TabIndex = 18;
            this.label18.Text = "房门呼叫RFID集合";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtShutterStopRfids
            // 
            this.txtShutterStopRfids.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtShutterStopRfids.Location = new System.Drawing.Point(485, 0);
            this.txtShutterStopRfids.Multiline = true;
            this.txtShutterStopRfids.Name = "txtShutterStopRfids";
            this.txtShutterStopRfids.Size = new System.Drawing.Size(100, 59);
            this.txtShutterStopRfids.TabIndex = 4;
            this.txtShutterStopRfids.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Location = new System.Drawing.Point(400, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(85, 59);
            this.label12.TabIndex = 6;
            this.label12.Text = "房门停止\r\nRFID集合";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel9);
            this.panel10.Controls.Add(this.panel8);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(200, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(200, 59);
            this.panel10.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txtShutterPort);
            this.panel9.Controls.Add(this.label13);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 33);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(200, 26);
            this.panel9.TabIndex = 2;
            // 
            // txtShutterPort
            // 
            this.txtShutterPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShutterPort.Location = new System.Drawing.Point(85, 0);
            this.txtShutterPort.Multiline = true;
            this.txtShutterPort.Name = "txtShutterPort";
            this.txtShutterPort.Size = new System.Drawing.Size(115, 26);
            this.txtShutterPort.TabIndex = 3;
            this.txtShutterPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Dock = System.Windows.Forms.DockStyle.Left;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 26);
            this.label13.TabIndex = 5;
            this.label13.Text = "房门端口";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtShutterDoorIp);
            this.panel8.Controls.Add(this.label14);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(200, 33);
            this.panel8.TabIndex = 1;
            // 
            // txtShutterDoorIp
            // 
            this.txtShutterDoorIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShutterDoorIp.Location = new System.Drawing.Point(85, 0);
            this.txtShutterDoorIp.Multiline = true;
            this.txtShutterDoorIp.Name = "txtShutterDoorIp";
            this.txtShutterDoorIp.Size = new System.Drawing.Size(115, 33);
            this.txtShutterDoorIp.TabIndex = 2;
            this.txtShutterDoorIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.label14.Location = new System.Drawing.Point(0, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(85, 33);
            this.label14.TabIndex = 3;
            this.label14.Text = "房门IP";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel38
            // 
            this.panel38.Controls.Add(this.panel39);
            this.panel38.Controls.Add(this.panel40);
            this.panel38.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel38.Location = new System.Drawing.Point(0, 0);
            this.panel38.Name = "panel38";
            this.panel38.Size = new System.Drawing.Size(200, 59);
            this.panel38.TabIndex = 20;
            // 
            // panel39
            // 
            this.panel39.Controls.Add(this.txtShutterDoorName);
            this.panel39.Controls.Add(this.label47);
            this.panel39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel39.Location = new System.Drawing.Point(0, 33);
            this.panel39.Name = "panel39";
            this.panel39.Size = new System.Drawing.Size(200, 26);
            this.panel39.TabIndex = 2;
            // 
            // txtShutterDoorName
            // 
            this.txtShutterDoorName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShutterDoorName.Location = new System.Drawing.Point(85, 0);
            this.txtShutterDoorName.Multiline = true;
            this.txtShutterDoorName.Name = "txtShutterDoorName";
            this.txtShutterDoorName.Size = new System.Drawing.Size(115, 26);
            this.txtShutterDoorName.TabIndex = 3;
            this.txtShutterDoorName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label47
            // 
            this.label47.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label47.Dock = System.Windows.Forms.DockStyle.Left;
            this.label47.Location = new System.Drawing.Point(0, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(85, 26);
            this.label47.TabIndex = 5;
            this.label47.Text = "房门名称";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel40
            // 
            this.panel40.Controls.Add(this.txtShutterDoorNo);
            this.panel40.Controls.Add(this.label48);
            this.panel40.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel40.Location = new System.Drawing.Point(0, 0);
            this.panel40.Name = "panel40";
            this.panel40.Size = new System.Drawing.Size(200, 33);
            this.panel40.TabIndex = 1;
            // 
            // txtShutterDoorNo
            // 
            this.txtShutterDoorNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShutterDoorNo.Location = new System.Drawing.Point(85, 0);
            this.txtShutterDoorNo.Multiline = true;
            this.txtShutterDoorNo.Name = "txtShutterDoorNo";
            this.txtShutterDoorNo.Size = new System.Drawing.Size(115, 33);
            this.txtShutterDoorNo.TabIndex = 2;
            this.txtShutterDoorNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label48
            // 
            this.label48.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label48.Dock = System.Windows.Forms.DockStyle.Left;
            this.label48.Location = new System.Drawing.Point(0, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(85, 33);
            this.label48.TabIndex = 3;
            this.label48.Text = "房门编号";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabConfigCapacityTest
            // 
            this.tabConfigCapacityTest.Controls.Add(this.panCapaCityTest);
            this.tabConfigCapacityTest.Location = new System.Drawing.Point(4, 25);
            this.tabConfigCapacityTest.Name = "tabConfigCapacityTest";
            this.tabConfigCapacityTest.Size = new System.Drawing.Size(1793, 812);
            this.tabConfigCapacityTest.TabIndex = 9;
            this.tabConfigCapacityTest.Text = "分容测试Agv配置";
            this.tabConfigCapacityTest.UseVisualStyleBackColor = true;
            // 
            // panCapaCityTest
            // 
            this.panCapaCityTest.BackColor = System.Drawing.Color.Azure;
            this.panCapaCityTest.Controls.Add(this.groupBox6);
            this.panCapaCityTest.Controls.Add(this.gbxCapacityTestOperate);
            this.panCapaCityTest.Controls.Add(this.gbCapacityTestWaitPoint);
            this.panCapaCityTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panCapaCityTest.Location = new System.Drawing.Point(0, 0);
            this.panCapaCityTest.Name = "panCapaCityTest";
            this.panCapaCityTest.Size = new System.Drawing.Size(1793, 812);
            this.panCapaCityTest.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.panel99);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox6.Location = new System.Drawing.Point(480, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(280, 812);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "上下料区设定";
            // 
            // panel99
            // 
            this.panel99.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel99.Controls.Add(this.panel100);
            this.panel99.Controls.Add(this.panel106);
            this.panel99.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel99.Location = new System.Drawing.Point(3, 21);
            this.panel99.Name = "panel99";
            this.panel99.Size = new System.Drawing.Size(274, 245);
            this.panel99.TabIndex = 0;
            // 
            // panel100
            // 
            this.panel100.Controls.Add(this.btnAgvLimitedRec);
            this.panel100.Controls.Add(this.btnAgvLimitedRef);
            this.panel100.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel100.Location = new System.Drawing.Point(0, 195);
            this.panel100.Name = "panel100";
            this.panel100.Size = new System.Drawing.Size(272, 48);
            this.panel100.TabIndex = 6;
            // 
            // btnAgvLimitedRec
            // 
            this.btnAgvLimitedRec.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAgvLimitedRec.Location = new System.Drawing.Point(110, 0);
            this.btnAgvLimitedRec.Name = "btnAgvLimitedRec";
            this.btnAgvLimitedRec.Size = new System.Drawing.Size(110, 48);
            this.btnAgvLimitedRec.TabIndex = 1;
            this.btnAgvLimitedRec.Text = "获取";
            this.btnAgvLimitedRec.UseVisualStyleBackColor = true;
            this.btnAgvLimitedRec.Click += new System.EventHandler(this.btnAgvLimitedRec_Click);
            // 
            // btnAgvLimitedRef
            // 
            this.btnAgvLimitedRef.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAgvLimitedRef.Location = new System.Drawing.Point(0, 0);
            this.btnAgvLimitedRef.Name = "btnAgvLimitedRef";
            this.btnAgvLimitedRef.Size = new System.Drawing.Size(110, 48);
            this.btnAgvLimitedRef.TabIndex = 0;
            this.btnAgvLimitedRef.Text = "更新";
            this.btnAgvLimitedRef.UseVisualStyleBackColor = true;
            this.btnAgvLimitedRef.Click += new System.EventHandler(this.btnAgvLimitedRef_Click);
            // 
            // panel106
            // 
            this.panel106.Controls.Add(this.txtAgvLimited);
            this.panel106.Controls.Add(this.label97);
            this.panel106.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel106.Location = new System.Drawing.Point(0, 0);
            this.panel106.Name = "panel106";
            this.panel106.Size = new System.Drawing.Size(272, 195);
            this.panel106.TabIndex = 0;
            // 
            // txtAgvLimited
            // 
            this.txtAgvLimited.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAgvLimited.Location = new System.Drawing.Point(125, 0);
            this.txtAgvLimited.Multiline = true;
            this.txtAgvLimited.Name = "txtAgvLimited";
            this.txtAgvLimited.Size = new System.Drawing.Size(147, 195);
            this.txtAgvLimited.TabIndex = 1;
            // 
            // label97
            // 
            this.label97.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label97.Dock = System.Windows.Forms.DockStyle.Left;
            this.label97.Location = new System.Drawing.Point(0, 0);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(125, 195);
            this.label97.TabIndex = 0;
            this.label97.Text = "上下料区AGV限定\r\n\r\nAGV编号_料点编号[44_3]，即指定该AGV不去该料点工作.用\',\'号隔开";
            this.label97.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxCapacityTestOperate
            // 
            this.gbxCapacityTestOperate.Controls.Add(this.panel92);
            this.gbxCapacityTestOperate.Controls.Add(this.panel91);
            this.gbxCapacityTestOperate.Controls.Add(this.panel87);
            this.gbxCapacityTestOperate.Controls.Add(this.panel83);
            this.gbxCapacityTestOperate.Controls.Add(this.panel82);
            this.gbxCapacityTestOperate.Controls.Add(this.panel74);
            this.gbxCapacityTestOperate.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbxCapacityTestOperate.Location = new System.Drawing.Point(200, 0);
            this.gbxCapacityTestOperate.Name = "gbxCapacityTestOperate";
            this.gbxCapacityTestOperate.Size = new System.Drawing.Size(280, 812);
            this.gbxCapacityTestOperate.TabIndex = 1;
            this.gbxCapacityTestOperate.TabStop = false;
            this.gbxCapacityTestOperate.Text = "分容柜站点操作命令";
            // 
            // panel92
            // 
            this.panel92.Controls.Add(this.btnGroupMesTaskRec);
            this.panel92.Controls.Add(this.btnGroupMesTaskRef);
            this.panel92.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel92.Location = new System.Drawing.Point(3, 585);
            this.panel92.Name = "panel92";
            this.panel92.Size = new System.Drawing.Size(274, 51);
            this.panel92.TabIndex = 10;
            // 
            // btnGroupMesTaskRec
            // 
            this.btnGroupMesTaskRec.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGroupMesTaskRec.Location = new System.Drawing.Point(110, 0);
            this.btnGroupMesTaskRec.Name = "btnGroupMesTaskRec";
            this.btnGroupMesTaskRec.Size = new System.Drawing.Size(110, 51);
            this.btnGroupMesTaskRec.TabIndex = 1;
            this.btnGroupMesTaskRec.Text = "获取";
            this.btnGroupMesTaskRec.UseVisualStyleBackColor = true;
            this.btnGroupMesTaskRec.Click += new System.EventHandler(this.btnGroupMesTaskRec_Click);
            // 
            // btnGroupMesTaskRef
            // 
            this.btnGroupMesTaskRef.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnGroupMesTaskRef.Location = new System.Drawing.Point(0, 0);
            this.btnGroupMesTaskRef.Name = "btnGroupMesTaskRef";
            this.btnGroupMesTaskRef.Size = new System.Drawing.Size(110, 51);
            this.btnGroupMesTaskRef.TabIndex = 0;
            this.btnGroupMesTaskRef.Text = "更新";
            this.btnGroupMesTaskRef.UseVisualStyleBackColor = true;
            this.btnGroupMesTaskRef.Click += new System.EventHandler(this.btnGroupMesTaskRef_Click);
            // 
            // panel91
            // 
            this.panel91.Controls.Add(this.txtGroupMesTask);
            this.panel91.Controls.Add(this.label88);
            this.panel91.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel91.Location = new System.Drawing.Point(3, 535);
            this.panel91.Name = "panel91";
            this.panel91.Size = new System.Drawing.Size(274, 50);
            this.panel91.TabIndex = 9;
            // 
            // txtGroupMesTask
            // 
            this.txtGroupMesTask.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtGroupMesTask.Location = new System.Drawing.Point(104, 0);
            this.txtGroupMesTask.Multiline = true;
            this.txtGroupMesTask.Name = "txtGroupMesTask";
            this.txtGroupMesTask.Size = new System.Drawing.Size(143, 50);
            this.txtGroupMesTask.TabIndex = 2;
            this.txtGroupMesTask.Text = "78";
            // 
            // label88
            // 
            this.label88.Dock = System.Windows.Forms.DockStyle.Left;
            this.label88.Location = new System.Drawing.Point(0, 0);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(104, 50);
            this.label88.TabIndex = 0;
            this.label88.Text = "空车回待机点通道号";
            this.label88.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel87
            // 
            this.panel87.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel87.Controls.Add(this.chbQRCode);
            this.panel87.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel87.Location = new System.Drawing.Point(3, 485);
            this.panel87.Name = "panel87";
            this.panel87.Size = new System.Drawing.Size(274, 50);
            this.panel87.TabIndex = 8;
            // 
            // chbQRCode
            // 
            this.chbQRCode.Checked = true;
            this.chbQRCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbQRCode.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbQRCode.Location = new System.Drawing.Point(0, 0);
            this.chbQRCode.Name = "chbQRCode";
            this.chbQRCode.Size = new System.Drawing.Size(125, 48);
            this.chbQRCode.TabIndex = 0;
            this.chbQRCode.Text = "二维码回传";
            this.chbQRCode.UseVisualStyleBackColor = true;
            this.chbQRCode.CheckedChanged += new System.EventHandler(this.chbQRCode_CheckedChanged);
            // 
            // panel83
            // 
            this.panel83.Controls.Add(this.txtTestSubStayRec);
            this.panel83.Controls.Add(this.btnTestSubStayRef);
            this.panel83.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel83.Location = new System.Drawing.Point(3, 434);
            this.panel83.Name = "panel83";
            this.panel83.Size = new System.Drawing.Size(274, 51);
            this.panel83.TabIndex = 7;
            // 
            // txtTestSubStayRec
            // 
            this.txtTestSubStayRec.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestSubStayRec.Location = new System.Drawing.Point(110, 0);
            this.txtTestSubStayRec.Name = "txtTestSubStayRec";
            this.txtTestSubStayRec.Size = new System.Drawing.Size(110, 51);
            this.txtTestSubStayRec.TabIndex = 1;
            this.txtTestSubStayRec.Text = "获取";
            this.txtTestSubStayRec.UseVisualStyleBackColor = true;
            this.txtTestSubStayRec.Click += new System.EventHandler(this.txtTestSubStayRec_Click);
            // 
            // btnTestSubStayRef
            // 
            this.btnTestSubStayRef.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTestSubStayRef.Location = new System.Drawing.Point(0, 0);
            this.btnTestSubStayRef.Name = "btnTestSubStayRef";
            this.btnTestSubStayRef.Size = new System.Drawing.Size(110, 51);
            this.btnTestSubStayRef.TabIndex = 0;
            this.btnTestSubStayRef.Text = "更新";
            this.btnTestSubStayRef.UseVisualStyleBackColor = true;
            this.btnTestSubStayRef.Click += new System.EventHandler(this.btnTestSubStayRef_Click);
            // 
            // panel82
            // 
            this.panel82.Controls.Add(this.label80);
            this.panel82.Controls.Add(this.txtTestSubStayTime);
            this.panel82.Controls.Add(this.label79);
            this.panel82.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel82.Location = new System.Drawing.Point(3, 384);
            this.panel82.Name = "panel82";
            this.panel82.Size = new System.Drawing.Size(274, 50);
            this.panel82.TabIndex = 1;
            // 
            // label80
            // 
            this.label80.Dock = System.Windows.Forms.DockStyle.Left;
            this.label80.Location = new System.Drawing.Point(208, 0);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(65, 50);
            this.label80.TabIndex = 3;
            this.label80.Text = "秒";
            this.label80.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTestSubStayTime
            // 
            this.txtTestSubStayTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestSubStayTime.Location = new System.Drawing.Point(65, 0);
            this.txtTestSubStayTime.Multiline = true;
            this.txtTestSubStayTime.Name = "txtTestSubStayTime";
            this.txtTestSubStayTime.Size = new System.Drawing.Size(143, 50);
            this.txtTestSubStayTime.TabIndex = 2;
            // 
            // label79
            // 
            this.label79.Dock = System.Windows.Forms.DockStyle.Left;
            this.label79.Location = new System.Drawing.Point(0, 0);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(65, 50);
            this.label79.TabIndex = 0;
            this.label79.Text = "分容柜停留时间";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel74
            // 
            this.panel74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel74.Controls.Add(this.panel81);
            this.panel74.Controls.Add(this.panel80);
            this.panel74.Controls.Add(this.panel79);
            this.panel74.Controls.Add(this.panel78);
            this.panel74.Controls.Add(this.panel77);
            this.panel74.Controls.Add(this.panel76);
            this.panel74.Controls.Add(this.panel75);
            this.panel74.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel74.Location = new System.Drawing.Point(3, 21);
            this.panel74.Name = "panel74";
            this.panel74.Size = new System.Drawing.Size(274, 363);
            this.panel74.TabIndex = 0;
            // 
            // panel81
            // 
            this.panel81.Controls.Add(this.btnCapacityTestOperateRec);
            this.panel81.Controls.Add(this.btnCapacityTestOperateRef);
            this.panel81.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel81.Location = new System.Drawing.Point(0, 294);
            this.panel81.Name = "panel81";
            this.panel81.Size = new System.Drawing.Size(272, 67);
            this.panel81.TabIndex = 6;
            // 
            // btnCapacityTestOperateRec
            // 
            this.btnCapacityTestOperateRec.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCapacityTestOperateRec.Location = new System.Drawing.Point(110, 0);
            this.btnCapacityTestOperateRec.Name = "btnCapacityTestOperateRec";
            this.btnCapacityTestOperateRec.Size = new System.Drawing.Size(110, 67);
            this.btnCapacityTestOperateRec.TabIndex = 1;
            this.btnCapacityTestOperateRec.Text = "获取";
            this.btnCapacityTestOperateRec.UseVisualStyleBackColor = true;
            this.btnCapacityTestOperateRec.Click += new System.EventHandler(this.btnCapacityTestOperateRec_Click);
            // 
            // btnCapacityTestOperateRef
            // 
            this.btnCapacityTestOperateRef.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCapacityTestOperateRef.Location = new System.Drawing.Point(0, 0);
            this.btnCapacityTestOperateRef.Name = "btnCapacityTestOperateRef";
            this.btnCapacityTestOperateRef.Size = new System.Drawing.Size(110, 67);
            this.btnCapacityTestOperateRef.TabIndex = 0;
            this.btnCapacityTestOperateRef.Text = "更新";
            this.btnCapacityTestOperateRef.UseVisualStyleBackColor = true;
            this.btnCapacityTestOperateRef.Click += new System.EventHandler(this.btnCapacityTestOperateRef_Click);
            // 
            // panel80
            // 
            this.panel80.Controls.Add(this.txtCapacityTestRightUnload);
            this.panel80.Controls.Add(this.label78);
            this.panel80.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel80.Location = new System.Drawing.Point(0, 245);
            this.panel80.Name = "panel80";
            this.panel80.Size = new System.Drawing.Size(272, 49);
            this.panel80.TabIndex = 5;
            // 
            // txtCapacityTestRightUnload
            // 
            this.txtCapacityTestRightUnload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCapacityTestRightUnload.Location = new System.Drawing.Point(110, 0);
            this.txtCapacityTestRightUnload.Multiline = true;
            this.txtCapacityTestRightUnload.Name = "txtCapacityTestRightUnload";
            this.txtCapacityTestRightUnload.Size = new System.Drawing.Size(162, 49);
            this.txtCapacityTestRightUnload.TabIndex = 1;
            // 
            // label78
            // 
            this.label78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label78.Dock = System.Windows.Forms.DockStyle.Left;
            this.label78.Location = new System.Drawing.Point(0, 0);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(110, 49);
            this.label78.TabIndex = 0;
            this.label78.Text = "右侧下料";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel79
            // 
            this.panel79.Controls.Add(this.txtCapacityTestLeftUnload);
            this.panel79.Controls.Add(this.label77);
            this.panel79.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel79.Location = new System.Drawing.Point(0, 196);
            this.panel79.Name = "panel79";
            this.panel79.Size = new System.Drawing.Size(272, 49);
            this.panel79.TabIndex = 4;
            // 
            // txtCapacityTestLeftUnload
            // 
            this.txtCapacityTestLeftUnload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCapacityTestLeftUnload.Location = new System.Drawing.Point(110, 0);
            this.txtCapacityTestLeftUnload.Multiline = true;
            this.txtCapacityTestLeftUnload.Name = "txtCapacityTestLeftUnload";
            this.txtCapacityTestLeftUnload.Size = new System.Drawing.Size(162, 49);
            this.txtCapacityTestLeftUnload.TabIndex = 1;
            // 
            // label77
            // 
            this.label77.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label77.Dock = System.Windows.Forms.DockStyle.Left;
            this.label77.Location = new System.Drawing.Point(0, 0);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(110, 49);
            this.label77.TabIndex = 0;
            this.label77.Text = "左侧下料";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel78
            // 
            this.panel78.Controls.Add(this.txtCapacityTestRightRefueling);
            this.panel78.Controls.Add(this.label76);
            this.panel78.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel78.Location = new System.Drawing.Point(0, 147);
            this.panel78.Name = "panel78";
            this.panel78.Size = new System.Drawing.Size(272, 49);
            this.panel78.TabIndex = 3;
            // 
            // txtCapacityTestRightRefueling
            // 
            this.txtCapacityTestRightRefueling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCapacityTestRightRefueling.Location = new System.Drawing.Point(110, 0);
            this.txtCapacityTestRightRefueling.Multiline = true;
            this.txtCapacityTestRightRefueling.Name = "txtCapacityTestRightRefueling";
            this.txtCapacityTestRightRefueling.Size = new System.Drawing.Size(162, 49);
            this.txtCapacityTestRightRefueling.TabIndex = 1;
            // 
            // label76
            // 
            this.label76.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label76.Dock = System.Windows.Forms.DockStyle.Left;
            this.label76.Location = new System.Drawing.Point(0, 0);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(110, 49);
            this.label76.TabIndex = 0;
            this.label76.Text = "右侧换料";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel77
            // 
            this.panel77.Controls.Add(this.txtCapacityTestLeftRefueling);
            this.panel77.Controls.Add(this.label75);
            this.panel77.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel77.Location = new System.Drawing.Point(0, 98);
            this.panel77.Name = "panel77";
            this.panel77.Size = new System.Drawing.Size(272, 49);
            this.panel77.TabIndex = 2;
            // 
            // txtCapacityTestLeftRefueling
            // 
            this.txtCapacityTestLeftRefueling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCapacityTestLeftRefueling.Location = new System.Drawing.Point(110, 0);
            this.txtCapacityTestLeftRefueling.Multiline = true;
            this.txtCapacityTestLeftRefueling.Name = "txtCapacityTestLeftRefueling";
            this.txtCapacityTestLeftRefueling.Size = new System.Drawing.Size(162, 49);
            this.txtCapacityTestLeftRefueling.TabIndex = 1;
            // 
            // label75
            // 
            this.label75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label75.Dock = System.Windows.Forms.DockStyle.Left;
            this.label75.Location = new System.Drawing.Point(0, 0);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(110, 49);
            this.label75.TabIndex = 0;
            this.label75.Text = "左侧换料";
            this.label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel76
            // 
            this.panel76.Controls.Add(this.txtCapacityTestRightLoad);
            this.panel76.Controls.Add(this.label74);
            this.panel76.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel76.Location = new System.Drawing.Point(0, 49);
            this.panel76.Name = "panel76";
            this.panel76.Size = new System.Drawing.Size(272, 49);
            this.panel76.TabIndex = 1;
            // 
            // txtCapacityTestRightLoad
            // 
            this.txtCapacityTestRightLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCapacityTestRightLoad.Location = new System.Drawing.Point(110, 0);
            this.txtCapacityTestRightLoad.Multiline = true;
            this.txtCapacityTestRightLoad.Name = "txtCapacityTestRightLoad";
            this.txtCapacityTestRightLoad.Size = new System.Drawing.Size(162, 49);
            this.txtCapacityTestRightLoad.TabIndex = 1;
            // 
            // label74
            // 
            this.label74.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label74.Dock = System.Windows.Forms.DockStyle.Left;
            this.label74.Location = new System.Drawing.Point(0, 0);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(110, 49);
            this.label74.TabIndex = 0;
            this.label74.Text = "右侧上料";
            this.label74.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel75
            // 
            this.panel75.Controls.Add(this.txtCapacityTestLeftLoad);
            this.panel75.Controls.Add(this.label73);
            this.panel75.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel75.Location = new System.Drawing.Point(0, 0);
            this.panel75.Name = "panel75";
            this.panel75.Size = new System.Drawing.Size(272, 49);
            this.panel75.TabIndex = 0;
            // 
            // txtCapacityTestLeftLoad
            // 
            this.txtCapacityTestLeftLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCapacityTestLeftLoad.Location = new System.Drawing.Point(110, 0);
            this.txtCapacityTestLeftLoad.Multiline = true;
            this.txtCapacityTestLeftLoad.Name = "txtCapacityTestLeftLoad";
            this.txtCapacityTestLeftLoad.Size = new System.Drawing.Size(162, 49);
            this.txtCapacityTestLeftLoad.TabIndex = 1;
            // 
            // label73
            // 
            this.label73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label73.Dock = System.Windows.Forms.DockStyle.Left;
            this.label73.Location = new System.Drawing.Point(0, 0);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(110, 49);
            this.label73.TabIndex = 0;
            this.label73.Text = "左侧上料";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbCapacityTestWaitPoint
            // 
            this.gbCapacityTestWaitPoint.Controls.Add(this.gbCapacityTestWait2);
            this.gbCapacityTestWaitPoint.Controls.Add(this.gbCapacityTestWait1);
            this.gbCapacityTestWaitPoint.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbCapacityTestWaitPoint.Location = new System.Drawing.Point(0, 0);
            this.gbCapacityTestWaitPoint.Name = "gbCapacityTestWaitPoint";
            this.gbCapacityTestWaitPoint.Size = new System.Drawing.Size(200, 812);
            this.gbCapacityTestWaitPoint.TabIndex = 0;
            this.gbCapacityTestWaitPoint.TabStop = false;
            this.gbCapacityTestWaitPoint.Text = "分容测试Agv待机点";
            // 
            // gbCapacityTestWait2
            // 
            this.gbCapacityTestWait2.Controls.Add(this.panel31);
            this.gbCapacityTestWait2.Controls.Add(this.txtCapacityTestWait2Rfids);
            this.gbCapacityTestWait2.Controls.Add(this.label41);
            this.gbCapacityTestWait2.Controls.Add(this.txtCapacityTestWait2Stations);
            this.gbCapacityTestWait2.Controls.Add(this.label42);
            this.gbCapacityTestWait2.Controls.Add(this.panel32);
            this.gbCapacityTestWait2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCapacityTestWait2.Location = new System.Drawing.Point(3, 311);
            this.gbCapacityTestWait2.Name = "gbCapacityTestWait2";
            this.gbCapacityTestWait2.Size = new System.Drawing.Size(194, 290);
            this.gbCapacityTestWait2.TabIndex = 1;
            this.gbCapacityTestWait2.TabStop = false;
            this.gbCapacityTestWait2.Text = "待机点2";
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.btnCapacityTestWait2Receive);
            this.panel31.Controls.Add(this.btnCapacityTestWait2update);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel31.Location = new System.Drawing.Point(3, 251);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(188, 36);
            this.panel31.TabIndex = 6;
            // 
            // btnCapacityTestWait2Receive
            // 
            this.btnCapacityTestWait2Receive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCapacityTestWait2Receive.Location = new System.Drawing.Point(98, 0);
            this.btnCapacityTestWait2Receive.Name = "btnCapacityTestWait2Receive";
            this.btnCapacityTestWait2Receive.Size = new System.Drawing.Size(90, 36);
            this.btnCapacityTestWait2Receive.TabIndex = 1;
            this.btnCapacityTestWait2Receive.Text = "获取";
            this.btnCapacityTestWait2Receive.UseVisualStyleBackColor = true;
            this.btnCapacityTestWait2Receive.Click += new System.EventHandler(this.btnCapacityTestWait2Receive_Click);
            // 
            // btnCapacityTestWait2update
            // 
            this.btnCapacityTestWait2update.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCapacityTestWait2update.Location = new System.Drawing.Point(0, 0);
            this.btnCapacityTestWait2update.Name = "btnCapacityTestWait2update";
            this.btnCapacityTestWait2update.Size = new System.Drawing.Size(98, 36);
            this.btnCapacityTestWait2update.TabIndex = 0;
            this.btnCapacityTestWait2update.Text = "更新";
            this.btnCapacityTestWait2update.UseVisualStyleBackColor = true;
            this.btnCapacityTestWait2update.Click += new System.EventHandler(this.btnCapacityTestWait2update_Click);
            // 
            // txtCapacityTestWait2Rfids
            // 
            this.txtCapacityTestWait2Rfids.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCapacityTestWait2Rfids.Location = new System.Drawing.Point(3, 174);
            this.txtCapacityTestWait2Rfids.Multiline = true;
            this.txtCapacityTestWait2Rfids.Name = "txtCapacityTestWait2Rfids";
            this.txtCapacityTestWait2Rfids.Size = new System.Drawing.Size(188, 77);
            this.txtCapacityTestWait2Rfids.TabIndex = 5;
            // 
            // label41
            // 
            this.label41.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label41.Dock = System.Windows.Forms.DockStyle.Top;
            this.label41.Location = new System.Drawing.Point(3, 150);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(188, 24);
            this.label41.TabIndex = 4;
            this.label41.Text = "RFID范围";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCapacityTestWait2Stations
            // 
            this.txtCapacityTestWait2Stations.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCapacityTestWait2Stations.Location = new System.Drawing.Point(3, 73);
            this.txtCapacityTestWait2Stations.Multiline = true;
            this.txtCapacityTestWait2Stations.Name = "txtCapacityTestWait2Stations";
            this.txtCapacityTestWait2Stations.Size = new System.Drawing.Size(188, 77);
            this.txtCapacityTestWait2Stations.TabIndex = 3;
            // 
            // label42
            // 
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label42.Dock = System.Windows.Forms.DockStyle.Top;
            this.label42.Location = new System.Drawing.Point(3, 49);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(188, 24);
            this.label42.TabIndex = 2;
            this.label42.Text = "站点范围";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.txtCapacityTestWait2Rfid);
            this.panel32.Controls.Add(this.label43);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel32.Location = new System.Drawing.Point(3, 21);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(188, 28);
            this.panel32.TabIndex = 1;
            // 
            // txtCapacityTestWait2Rfid
            // 
            this.txtCapacityTestWait2Rfid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCapacityTestWait2Rfid.Location = new System.Drawing.Point(77, 0);
            this.txtCapacityTestWait2Rfid.Name = "txtCapacityTestWait2Rfid";
            this.txtCapacityTestWait2Rfid.Size = new System.Drawing.Size(111, 25);
            this.txtCapacityTestWait2Rfid.TabIndex = 1;
            // 
            // label43
            // 
            this.label43.Dock = System.Windows.Forms.DockStyle.Left;
            this.label43.Location = new System.Drawing.Point(0, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(77, 28);
            this.label43.TabIndex = 0;
            this.label43.Text = "RFID编号";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbCapacityTestWait1
            // 
            this.gbCapacityTestWait1.Controls.Add(this.panel28);
            this.gbCapacityTestWait1.Controls.Add(this.txtCapacityTestWait1Rfids);
            this.gbCapacityTestWait1.Controls.Add(this.label40);
            this.gbCapacityTestWait1.Controls.Add(this.txtCapacityTestWait1Stations);
            this.gbCapacityTestWait1.Controls.Add(this.label39);
            this.gbCapacityTestWait1.Controls.Add(this.panel27);
            this.gbCapacityTestWait1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCapacityTestWait1.Location = new System.Drawing.Point(3, 21);
            this.gbCapacityTestWait1.Name = "gbCapacityTestWait1";
            this.gbCapacityTestWait1.Size = new System.Drawing.Size(194, 290);
            this.gbCapacityTestWait1.TabIndex = 0;
            this.gbCapacityTestWait1.TabStop = false;
            this.gbCapacityTestWait1.Text = "待机点1";
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.btnCapacityTestWait1Receive);
            this.panel28.Controls.Add(this.btnCapacityTestWait1Update);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel28.Location = new System.Drawing.Point(3, 251);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(188, 36);
            this.panel28.TabIndex = 6;
            // 
            // btnCapacityTestWait1Receive
            // 
            this.btnCapacityTestWait1Receive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCapacityTestWait1Receive.Location = new System.Drawing.Point(98, 0);
            this.btnCapacityTestWait1Receive.Name = "btnCapacityTestWait1Receive";
            this.btnCapacityTestWait1Receive.Size = new System.Drawing.Size(90, 36);
            this.btnCapacityTestWait1Receive.TabIndex = 1;
            this.btnCapacityTestWait1Receive.Text = "获取";
            this.btnCapacityTestWait1Receive.UseVisualStyleBackColor = true;
            this.btnCapacityTestWait1Receive.Click += new System.EventHandler(this.btnCapacityTestWait1Receive_Click);
            // 
            // btnCapacityTestWait1Update
            // 
            this.btnCapacityTestWait1Update.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCapacityTestWait1Update.Location = new System.Drawing.Point(0, 0);
            this.btnCapacityTestWait1Update.Name = "btnCapacityTestWait1Update";
            this.btnCapacityTestWait1Update.Size = new System.Drawing.Size(98, 36);
            this.btnCapacityTestWait1Update.TabIndex = 0;
            this.btnCapacityTestWait1Update.Text = "更新";
            this.btnCapacityTestWait1Update.UseVisualStyleBackColor = true;
            this.btnCapacityTestWait1Update.Click += new System.EventHandler(this.btnCapacityTestWait1Update_Click);
            // 
            // txtCapacityTestWait1Rfids
            // 
            this.txtCapacityTestWait1Rfids.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCapacityTestWait1Rfids.Location = new System.Drawing.Point(3, 174);
            this.txtCapacityTestWait1Rfids.Multiline = true;
            this.txtCapacityTestWait1Rfids.Name = "txtCapacityTestWait1Rfids";
            this.txtCapacityTestWait1Rfids.Size = new System.Drawing.Size(188, 77);
            this.txtCapacityTestWait1Rfids.TabIndex = 5;
            // 
            // label40
            // 
            this.label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label40.Dock = System.Windows.Forms.DockStyle.Top;
            this.label40.Location = new System.Drawing.Point(3, 150);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(188, 24);
            this.label40.TabIndex = 4;
            this.label40.Text = "RFID范围";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCapacityTestWait1Stations
            // 
            this.txtCapacityTestWait1Stations.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCapacityTestWait1Stations.Location = new System.Drawing.Point(3, 73);
            this.txtCapacityTestWait1Stations.Multiline = true;
            this.txtCapacityTestWait1Stations.Name = "txtCapacityTestWait1Stations";
            this.txtCapacityTestWait1Stations.Size = new System.Drawing.Size(188, 77);
            this.txtCapacityTestWait1Stations.TabIndex = 3;
            // 
            // label39
            // 
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label39.Dock = System.Windows.Forms.DockStyle.Top;
            this.label39.Location = new System.Drawing.Point(3, 49);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(188, 24);
            this.label39.TabIndex = 2;
            this.label39.Text = "站点范围";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel27
            // 
            this.panel27.Controls.Add(this.txtCapacityTestWait1Rfid);
            this.panel27.Controls.Add(this.label37);
            this.panel27.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel27.Location = new System.Drawing.Point(3, 21);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(188, 28);
            this.panel27.TabIndex = 1;
            // 
            // txtCapacityTestWait1Rfid
            // 
            this.txtCapacityTestWait1Rfid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCapacityTestWait1Rfid.Location = new System.Drawing.Point(77, 0);
            this.txtCapacityTestWait1Rfid.Name = "txtCapacityTestWait1Rfid";
            this.txtCapacityTestWait1Rfid.Size = new System.Drawing.Size(111, 25);
            this.txtCapacityTestWait1Rfid.TabIndex = 1;
            // 
            // label37
            // 
            this.label37.Dock = System.Windows.Forms.DockStyle.Left;
            this.label37.Location = new System.Drawing.Point(0, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(77, 28);
            this.label37.TabIndex = 0;
            this.label37.Text = "RFID编号";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabConfigBurnInRoom
            // 
            this.tabConfigBurnInRoom.Controls.Add(this.panAgingRoom);
            this.tabConfigBurnInRoom.Location = new System.Drawing.Point(4, 25);
            this.tabConfigBurnInRoom.Name = "tabConfigBurnInRoom";
            this.tabConfigBurnInRoom.Size = new System.Drawing.Size(1793, 812);
            this.tabConfigBurnInRoom.TabIndex = 10;
            this.tabConfigBurnInRoom.Text = "老化房Agv配置";
            this.tabConfigBurnInRoom.UseVisualStyleBackColor = true;
            // 
            // panAgingRoom
            // 
            this.panAgingRoom.BackColor = System.Drawing.Color.Azure;
            this.panAgingRoom.Controls.Add(this.gbxCapAgingRoom);
            this.panAgingRoom.Controls.Add(this.gbxPreAgingRoom);
            this.panAgingRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAgingRoom.Location = new System.Drawing.Point(0, 0);
            this.panAgingRoom.Name = "panAgingRoom";
            this.panAgingRoom.Size = new System.Drawing.Size(1793, 812);
            this.panAgingRoom.TabIndex = 0;
            // 
            // gbxCapAgingRoom
            // 
            this.gbxCapAgingRoom.Controls.Add(this.panel62);
            this.gbxCapAgingRoom.Controls.Add(this.panel64);
            this.gbxCapAgingRoom.Controls.Add(this.panel65);
            this.gbxCapAgingRoom.Controls.Add(this.panel66);
            this.gbxCapAgingRoom.Controls.Add(this.panel67);
            this.gbxCapAgingRoom.Controls.Add(this.panel68);
            this.gbxCapAgingRoom.Controls.Add(this.panel69);
            this.gbxCapAgingRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxCapAgingRoom.Location = new System.Drawing.Point(568, 0);
            this.gbxCapAgingRoom.Name = "gbxCapAgingRoom";
            this.gbxCapAgingRoom.Size = new System.Drawing.Size(1225, 812);
            this.gbxCapAgingRoom.TabIndex = 1;
            this.gbxCapAgingRoom.TabStop = false;
            this.gbxCapAgingRoom.Text = "分容老化房Agv配置";
            // 
            // panel62
            // 
            this.panel62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel62.Controls.Add(this.btnCapAgingRoomUpdate);
            this.panel62.Controls.Add(this.panel63);
            this.panel62.Controls.Add(this.btnCapAgingRoomRfidReceive);
            this.panel62.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel62.Location = new System.Drawing.Point(3, 189);
            this.panel62.Name = "panel62";
            this.panel62.Size = new System.Drawing.Size(1219, 46);
            this.panel62.TabIndex = 15;
            // 
            // btnCapAgingRoomUpdate
            // 
            this.btnCapAgingRoomUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCapAgingRoomUpdate.Location = new System.Drawing.Point(376, 0);
            this.btnCapAgingRoomUpdate.Name = "btnCapAgingRoomUpdate";
            this.btnCapAgingRoomUpdate.Size = new System.Drawing.Size(841, 44);
            this.btnCapAgingRoomUpdate.TabIndex = 2;
            this.btnCapAgingRoomUpdate.Text = "更新";
            this.btnCapAgingRoomUpdate.UseVisualStyleBackColor = true;
            this.btnCapAgingRoomUpdate.Click += new System.EventHandler(this.btnCapAgingRoomUpdate_Click);
            // 
            // panel63
            // 
            this.panel63.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel63.Location = new System.Drawing.Point(285, 0);
            this.panel63.Name = "panel63";
            this.panel63.Size = new System.Drawing.Size(91, 44);
            this.panel63.TabIndex = 1;
            // 
            // btnCapAgingRoomRfidReceive
            // 
            this.btnCapAgingRoomRfidReceive.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCapAgingRoomRfidReceive.Location = new System.Drawing.Point(0, 0);
            this.btnCapAgingRoomRfidReceive.Name = "btnCapAgingRoomRfidReceive";
            this.btnCapAgingRoomRfidReceive.Size = new System.Drawing.Size(285, 44);
            this.btnCapAgingRoomRfidReceive.TabIndex = 0;
            this.btnCapAgingRoomRfidReceive.Text = "获取";
            this.btnCapAgingRoomRfidReceive.UseVisualStyleBackColor = true;
            this.btnCapAgingRoomRfidReceive.Click += new System.EventHandler(this.btnCapAgingRoomRfidReceive_Click);
            // 
            // panel64
            // 
            this.panel64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel64.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel64.Location = new System.Drawing.Point(3, 161);
            this.panel64.Name = "panel64";
            this.panel64.Size = new System.Drawing.Size(1219, 28);
            this.panel64.TabIndex = 14;
            // 
            // panel65
            // 
            this.panel65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel65.Controls.Add(this.txtCapAgingRoomUnloadAreaRfid);
            this.panel65.Controls.Add(this.label59);
            this.panel65.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel65.Location = new System.Drawing.Point(3, 133);
            this.panel65.Name = "panel65";
            this.panel65.Size = new System.Drawing.Size(1219, 28);
            this.panel65.TabIndex = 13;
            // 
            // txtCapAgingRoomUnloadAreaRfid
            // 
            this.txtCapAgingRoomUnloadAreaRfid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCapAgingRoomUnloadAreaRfid.Location = new System.Drawing.Point(221, 0);
            this.txtCapAgingRoomUnloadAreaRfid.Name = "txtCapAgingRoomUnloadAreaRfid";
            this.txtCapAgingRoomUnloadAreaRfid.Size = new System.Drawing.Size(996, 25);
            this.txtCapAgingRoomUnloadAreaRfid.TabIndex = 1;
            this.txtCapAgingRoomUnloadAreaRfid.Text = "0";
            // 
            // label59
            // 
            this.label59.Dock = System.Windows.Forms.DockStyle.Left;
            this.label59.Location = new System.Drawing.Point(0, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(221, 26);
            this.label59.TabIndex = 0;
            this.label59.Text = "下料区待机位RFID";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel66
            // 
            this.panel66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel66.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel66.Location = new System.Drawing.Point(3, 105);
            this.panel66.Name = "panel66";
            this.panel66.Size = new System.Drawing.Size(1219, 28);
            this.panel66.TabIndex = 12;
            // 
            // panel67
            // 
            this.panel67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel67.Controls.Add(this.txtCapAgingRoomStaticArea2Rfid);
            this.panel67.Controls.Add(this.label62);
            this.panel67.Controls.Add(this.txtCapAgingRoomStaticArea1Rfid);
            this.panel67.Controls.Add(this.label60);
            this.panel67.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel67.Location = new System.Drawing.Point(3, 77);
            this.panel67.Name = "panel67";
            this.panel67.Size = new System.Drawing.Size(1219, 28);
            this.panel67.TabIndex = 11;
            // 
            // txtCapAgingRoomStaticArea2Rfid
            // 
            this.txtCapAgingRoomStaticArea2Rfid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCapAgingRoomStaticArea2Rfid.Location = new System.Drawing.Point(541, 0);
            this.txtCapAgingRoomStaticArea2Rfid.Name = "txtCapAgingRoomStaticArea2Rfid";
            this.txtCapAgingRoomStaticArea2Rfid.Size = new System.Drawing.Size(676, 25);
            this.txtCapAgingRoomStaticArea2Rfid.TabIndex = 3;
            this.txtCapAgingRoomStaticArea2Rfid.Text = "0";
            // 
            // label62
            // 
            this.label62.Dock = System.Windows.Forms.DockStyle.Left;
            this.label62.Location = new System.Drawing.Point(353, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(188, 26);
            this.label62.TabIndex = 2;
            this.label62.Text = "14-21静置区任务RFID";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCapAgingRoomStaticArea1Rfid
            // 
            this.txtCapAgingRoomStaticArea1Rfid.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCapAgingRoomStaticArea1Rfid.Location = new System.Drawing.Point(187, 0);
            this.txtCapAgingRoomStaticArea1Rfid.Name = "txtCapAgingRoomStaticArea1Rfid";
            this.txtCapAgingRoomStaticArea1Rfid.Size = new System.Drawing.Size(166, 25);
            this.txtCapAgingRoomStaticArea1Rfid.TabIndex = 1;
            this.txtCapAgingRoomStaticArea1Rfid.Text = "0";
            // 
            // label60
            // 
            this.label60.Dock = System.Windows.Forms.DockStyle.Left;
            this.label60.Location = new System.Drawing.Point(0, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(187, 26);
            this.label60.TabIndex = 0;
            this.label60.Text = "6-13静置区任务RFID";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel68
            // 
            this.panel68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel68.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel68.Location = new System.Drawing.Point(3, 49);
            this.panel68.Name = "panel68";
            this.panel68.Size = new System.Drawing.Size(1219, 28);
            this.panel68.TabIndex = 10;
            // 
            // panel69
            // 
            this.panel69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel69.Controls.Add(this.txtCapAgingRoomLoadAreaRfid);
            this.panel69.Controls.Add(this.label61);
            this.panel69.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel69.Location = new System.Drawing.Point(3, 21);
            this.panel69.Name = "panel69";
            this.panel69.Size = new System.Drawing.Size(1219, 28);
            this.panel69.TabIndex = 9;
            // 
            // txtCapAgingRoomLoadAreaRfid
            // 
            this.txtCapAgingRoomLoadAreaRfid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCapAgingRoomLoadAreaRfid.Location = new System.Drawing.Point(221, 0);
            this.txtCapAgingRoomLoadAreaRfid.Name = "txtCapAgingRoomLoadAreaRfid";
            this.txtCapAgingRoomLoadAreaRfid.Size = new System.Drawing.Size(996, 25);
            this.txtCapAgingRoomLoadAreaRfid.TabIndex = 1;
            this.txtCapAgingRoomLoadAreaRfid.Text = "0";
            // 
            // label61
            // 
            this.label61.Dock = System.Windows.Forms.DockStyle.Left;
            this.label61.Location = new System.Drawing.Point(0, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(221, 26);
            this.label61.TabIndex = 0;
            this.label61.Text = "上料区待机位RFID";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxPreAgingRoom
            // 
            this.gbxPreAgingRoom.Controls.Add(this.panel60);
            this.gbxPreAgingRoom.Controls.Add(this.panel59);
            this.gbxPreAgingRoom.Controls.Add(this.panel58);
            this.gbxPreAgingRoom.Controls.Add(this.panel57);
            this.gbxPreAgingRoom.Controls.Add(this.panel56);
            this.gbxPreAgingRoom.Controls.Add(this.panel55);
            this.gbxPreAgingRoom.Controls.Add(this.panel54);
            this.gbxPreAgingRoom.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbxPreAgingRoom.Location = new System.Drawing.Point(0, 0);
            this.gbxPreAgingRoom.Name = "gbxPreAgingRoom";
            this.gbxPreAgingRoom.Size = new System.Drawing.Size(568, 812);
            this.gbxPreAgingRoom.TabIndex = 0;
            this.gbxPreAgingRoom.TabStop = false;
            this.gbxPreAgingRoom.Text = "预充老化房Agv配置";
            // 
            // panel60
            // 
            this.panel60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel60.Controls.Add(this.btnPreAgingRoomUpdate);
            this.panel60.Controls.Add(this.panel61);
            this.panel60.Controls.Add(this.btnPreAgingRoomRfidReceive);
            this.panel60.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel60.Location = new System.Drawing.Point(3, 189);
            this.panel60.Name = "panel60";
            this.panel60.Size = new System.Drawing.Size(562, 46);
            this.panel60.TabIndex = 8;
            // 
            // btnPreAgingRoomUpdate
            // 
            this.btnPreAgingRoomUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPreAgingRoomUpdate.Location = new System.Drawing.Point(285, 0);
            this.btnPreAgingRoomUpdate.Name = "btnPreAgingRoomUpdate";
            this.btnPreAgingRoomUpdate.Size = new System.Drawing.Size(275, 44);
            this.btnPreAgingRoomUpdate.TabIndex = 2;
            this.btnPreAgingRoomUpdate.Text = "更新";
            this.btnPreAgingRoomUpdate.UseVisualStyleBackColor = true;
            this.btnPreAgingRoomUpdate.Click += new System.EventHandler(this.btnPreAgingRoomUpdate_Click);
            // 
            // panel61
            // 
            this.panel61.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel61.Location = new System.Drawing.Point(194, 0);
            this.panel61.Name = "panel61";
            this.panel61.Size = new System.Drawing.Size(91, 44);
            this.panel61.TabIndex = 1;
            // 
            // btnPreAgingRoomRfidReceive
            // 
            this.btnPreAgingRoomRfidReceive.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPreAgingRoomRfidReceive.Location = new System.Drawing.Point(0, 0);
            this.btnPreAgingRoomRfidReceive.Name = "btnPreAgingRoomRfidReceive";
            this.btnPreAgingRoomRfidReceive.Size = new System.Drawing.Size(194, 44);
            this.btnPreAgingRoomRfidReceive.TabIndex = 0;
            this.btnPreAgingRoomRfidReceive.Text = "获取";
            this.btnPreAgingRoomRfidReceive.UseVisualStyleBackColor = true;
            this.btnPreAgingRoomRfidReceive.Click += new System.EventHandler(this.btnPreAgingRoomRfidReceive_Click);
            // 
            // panel59
            // 
            this.panel59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel59.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel59.Location = new System.Drawing.Point(3, 161);
            this.panel59.Name = "panel59";
            this.panel59.Size = new System.Drawing.Size(562, 28);
            this.panel59.TabIndex = 7;
            // 
            // panel58
            // 
            this.panel58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel58.Controls.Add(this.txtPreAgingRoomUnloadAreaRfid);
            this.panel58.Controls.Add(this.label57);
            this.panel58.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel58.Location = new System.Drawing.Point(3, 133);
            this.panel58.Name = "panel58";
            this.panel58.Size = new System.Drawing.Size(562, 28);
            this.panel58.TabIndex = 6;
            // 
            // txtPreAgingRoomUnloadAreaRfid
            // 
            this.txtPreAgingRoomUnloadAreaRfid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreAgingRoomUnloadAreaRfid.Location = new System.Drawing.Point(221, 0);
            this.txtPreAgingRoomUnloadAreaRfid.Name = "txtPreAgingRoomUnloadAreaRfid";
            this.txtPreAgingRoomUnloadAreaRfid.Size = new System.Drawing.Size(339, 25);
            this.txtPreAgingRoomUnloadAreaRfid.TabIndex = 1;
            this.txtPreAgingRoomUnloadAreaRfid.Text = "0";
            // 
            // label57
            // 
            this.label57.Dock = System.Windows.Forms.DockStyle.Left;
            this.label57.Location = new System.Drawing.Point(0, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(221, 26);
            this.label57.TabIndex = 0;
            this.label57.Text = "下料区待机位RFID";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel57
            // 
            this.panel57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel57.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel57.Location = new System.Drawing.Point(3, 105);
            this.panel57.Name = "panel57";
            this.panel57.Size = new System.Drawing.Size(562, 28);
            this.panel57.TabIndex = 5;
            // 
            // panel56
            // 
            this.panel56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel56.Controls.Add(this.txtPreAgingRoomStaticAreaRfid);
            this.panel56.Controls.Add(this.label58);
            this.panel56.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel56.Location = new System.Drawing.Point(3, 77);
            this.panel56.Name = "panel56";
            this.panel56.Size = new System.Drawing.Size(562, 28);
            this.panel56.TabIndex = 4;
            // 
            // txtPreAgingRoomStaticAreaRfid
            // 
            this.txtPreAgingRoomStaticAreaRfid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreAgingRoomStaticAreaRfid.Location = new System.Drawing.Point(221, 0);
            this.txtPreAgingRoomStaticAreaRfid.Name = "txtPreAgingRoomStaticAreaRfid";
            this.txtPreAgingRoomStaticAreaRfid.Size = new System.Drawing.Size(339, 25);
            this.txtPreAgingRoomStaticAreaRfid.TabIndex = 1;
            this.txtPreAgingRoomStaticAreaRfid.Text = "0";
            // 
            // label58
            // 
            this.label58.Dock = System.Windows.Forms.DockStyle.Left;
            this.label58.Location = new System.Drawing.Point(0, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(221, 26);
            this.label58.TabIndex = 0;
            this.label58.Text = "静置区任务RFID";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel55
            // 
            this.panel55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel55.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel55.Location = new System.Drawing.Point(3, 49);
            this.panel55.Name = "panel55";
            this.panel55.Size = new System.Drawing.Size(562, 28);
            this.panel55.TabIndex = 3;
            // 
            // panel54
            // 
            this.panel54.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel54.Controls.Add(this.txtPreAgingRoomLoadAreaRfid);
            this.panel54.Controls.Add(this.label56);
            this.panel54.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel54.Location = new System.Drawing.Point(3, 21);
            this.panel54.Name = "panel54";
            this.panel54.Size = new System.Drawing.Size(562, 28);
            this.panel54.TabIndex = 2;
            // 
            // txtPreAgingRoomLoadAreaRfid
            // 
            this.txtPreAgingRoomLoadAreaRfid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPreAgingRoomLoadAreaRfid.Location = new System.Drawing.Point(221, 0);
            this.txtPreAgingRoomLoadAreaRfid.Name = "txtPreAgingRoomLoadAreaRfid";
            this.txtPreAgingRoomLoadAreaRfid.Size = new System.Drawing.Size(339, 25);
            this.txtPreAgingRoomLoadAreaRfid.TabIndex = 1;
            this.txtPreAgingRoomLoadAreaRfid.Text = "0";
            // 
            // label56
            // 
            this.label56.Dock = System.Windows.Forms.DockStyle.Left;
            this.label56.Location = new System.Drawing.Point(0, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(221, 26);
            this.label56.TabIndex = 0;
            this.label56.Text = "上料区待机位RFID";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabConfigTest
            // 
            this.tabConfigTest.Controls.Add(this.panConfigTest);
            this.tabConfigTest.Location = new System.Drawing.Point(4, 25);
            this.tabConfigTest.Name = "tabConfigTest";
            this.tabConfigTest.Size = new System.Drawing.Size(1793, 812);
            this.tabConfigTest.TabIndex = 5;
            this.tabConfigTest.Text = "Test";
            this.tabConfigTest.UseVisualStyleBackColor = true;
            // 
            // panConfigTest
            // 
            this.panConfigTest.BackColor = System.Drawing.Color.Gainsboro;
            this.panConfigTest.Controls.Add(this.panel88);
            this.panConfigTest.Controls.Add(this.gbAgvOperation);
            this.panConfigTest.Controls.Add(this.gbRouteTest);
            this.panConfigTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panConfigTest.Location = new System.Drawing.Point(0, 0);
            this.panConfigTest.Name = "panConfigTest";
            this.panConfigTest.Size = new System.Drawing.Size(1793, 812);
            this.panConfigTest.TabIndex = 0;
            // 
            // panel88
            // 
            this.panel88.BackColor = System.Drawing.Color.Azure;
            this.panel88.Controls.Add(this.groupBox5);
            this.panel88.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel88.Location = new System.Drawing.Point(1025, 0);
            this.panel88.Name = "panel88";
            this.panel88.Size = new System.Drawing.Size(768, 812);
            this.panel88.TabIndex = 4;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.panel90);
            this.groupBox5.Controls.Add(this.panel89);
            this.groupBox5.Controls.Add(this.dgvAgvMatchStation);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(768, 812);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Agv指定任务";
            // 
            // panel90
            // 
            this.panel90.Controls.Add(this.chbMatchTask);
            this.panel90.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel90.Location = new System.Drawing.Point(3, 629);
            this.panel90.Name = "panel90";
            this.panel90.Size = new System.Drawing.Size(762, 180);
            this.panel90.TabIndex = 13;
            // 
            // chbMatchTask
            // 
            this.chbMatchTask.AutoSize = true;
            this.chbMatchTask.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbMatchTask.Location = new System.Drawing.Point(0, 0);
            this.chbMatchTask.Name = "chbMatchTask";
            this.chbMatchTask.Size = new System.Drawing.Size(243, 180);
            this.chbMatchTask.TabIndex = 3;
            this.chbMatchTask.Text = "启用指定AGV执行指定通道任务";
            this.chbMatchTask.UseVisualStyleBackColor = true;
            this.chbMatchTask.CheckedChanged += new System.EventHandler(this.chbMatchTask_CheckedChanged);
            // 
            // panel89
            // 
            this.panel89.Controls.Add(this.btnAgvMatchStationRef);
            this.panel89.Controls.Add(this.btnAgvMatchStationRec);
            this.panel89.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel89.Location = new System.Drawing.Point(3, 563);
            this.panel89.Name = "panel89";
            this.panel89.Size = new System.Drawing.Size(762, 66);
            this.panel89.TabIndex = 12;
            // 
            // btnAgvMatchStationRef
            // 
            this.btnAgvMatchStationRef.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAgvMatchStationRef.Location = new System.Drawing.Point(95, 0);
            this.btnAgvMatchStationRef.Name = "btnAgvMatchStationRef";
            this.btnAgvMatchStationRef.Size = new System.Drawing.Size(95, 66);
            this.btnAgvMatchStationRef.TabIndex = 1;
            this.btnAgvMatchStationRef.Text = "更新";
            this.btnAgvMatchStationRef.UseVisualStyleBackColor = true;
            this.btnAgvMatchStationRef.Click += new System.EventHandler(this.btnAgvMatchStationRef_Click);
            // 
            // btnAgvMatchStationRec
            // 
            this.btnAgvMatchStationRec.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAgvMatchStationRec.Location = new System.Drawing.Point(0, 0);
            this.btnAgvMatchStationRec.Name = "btnAgvMatchStationRec";
            this.btnAgvMatchStationRec.Size = new System.Drawing.Size(95, 66);
            this.btnAgvMatchStationRec.TabIndex = 0;
            this.btnAgvMatchStationRec.Text = "获取";
            this.btnAgvMatchStationRec.UseVisualStyleBackColor = true;
            this.btnAgvMatchStationRec.Click += new System.EventHandler(this.btnAgvMatchStationRec_Click);
            // 
            // dgvAgvMatchStation
            // 
            this.dgvAgvMatchStation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgvMatchStation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.Column1});
            this.dgvAgvMatchStation.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvAgvMatchStation.Location = new System.Drawing.Point(3, 21);
            this.dgvAgvMatchStation.Name = "dgvAgvMatchStation";
            this.dgvAgvMatchStation.RowHeadersVisible = false;
            this.dgvAgvMatchStation.RowTemplate.Height = 23;
            this.dgvAgvMatchStation.Size = new System.Drawing.Size(762, 542);
            this.dgvAgvMatchStation.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Agv编号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "组别";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "序号";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "操作命令";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "站点数量";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // Column1
            // 
            this.Column1.FalseValue = "False";
            this.Column1.HeaderText = "是否启用";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.TrueValue = "True";
            // 
            // gbAgvOperation
            // 
            this.gbAgvOperation.BackColor = System.Drawing.Color.White;
            this.gbAgvOperation.Controls.Add(this.panel71);
            this.gbAgvOperation.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbAgvOperation.Location = new System.Drawing.Point(436, 0);
            this.gbAgvOperation.Name = "gbAgvOperation";
            this.gbAgvOperation.Size = new System.Drawing.Size(589, 812);
            this.gbAgvOperation.TabIndex = 3;
            this.gbAgvOperation.TabStop = false;
            this.gbAgvOperation.Text = "Agv操作";
            // 
            // panel71
            // 
            this.panel71.BackColor = System.Drawing.Color.Azure;
            this.panel71.Controls.Add(this.chbSaveRoute);
            this.panel71.Controls.Add(this.panel86);
            this.panel71.Controls.Add(this.txtAutoTaskAgvs);
            this.panel71.Controls.Add(this.panel85);
            this.panel71.Controls.Add(this.panel84);
            this.panel71.Controls.Add(this.groupBox3);
            this.panel71.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel71.Location = new System.Drawing.Point(3, 21);
            this.panel71.Name = "panel71";
            this.panel71.Size = new System.Drawing.Size(583, 788);
            this.panel71.TabIndex = 0;
            // 
            // chbSaveRoute
            // 
            this.chbSaveRoute.AutoSize = true;
            this.chbSaveRoute.Dock = System.Windows.Forms.DockStyle.Top;
            this.chbSaveRoute.Location = new System.Drawing.Point(0, 502);
            this.chbSaveRoute.Name = "chbSaveRoute";
            this.chbSaveRoute.Size = new System.Drawing.Size(583, 20);
            this.chbSaveRoute.TabIndex = 49;
            this.chbSaveRoute.Text = "是否保存写入路段信息";
            this.chbSaveRoute.UseVisualStyleBackColor = true;
            this.chbSaveRoute.CheckedChanged += new System.EventHandler(this.chbSaveRoute_CheckedChanged);
            // 
            // panel86
            // 
            this.panel86.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel86.Controls.Add(this.btnAutoTaskAgvsRef);
            this.panel86.Controls.Add(this.btnAutoTaskAgvsRec);
            this.panel86.Controls.Add(this.label83);
            this.panel86.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel86.Location = new System.Drawing.Point(0, 441);
            this.panel86.Name = "panel86";
            this.panel86.Size = new System.Drawing.Size(583, 61);
            this.panel86.TabIndex = 6;
            // 
            // btnAutoTaskAgvsRef
            // 
            this.btnAutoTaskAgvsRef.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAutoTaskAgvsRef.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAutoTaskAgvsRef.Location = new System.Drawing.Point(400, 0);
            this.btnAutoTaskAgvsRef.Name = "btnAutoTaskAgvsRef";
            this.btnAutoTaskAgvsRef.Size = new System.Drawing.Size(75, 59);
            this.btnAutoTaskAgvsRef.TabIndex = 6;
            this.btnAutoTaskAgvsRef.Text = "设定";
            this.btnAutoTaskAgvsRef.UseVisualStyleBackColor = false;
            this.btnAutoTaskAgvsRef.Click += new System.EventHandler(this.btnAutoTaskAgvsRef_Click);
            // 
            // btnAutoTaskAgvsRec
            // 
            this.btnAutoTaskAgvsRec.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAutoTaskAgvsRec.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnAutoTaskAgvsRec.Location = new System.Drawing.Point(325, 0);
            this.btnAutoTaskAgvsRec.Name = "btnAutoTaskAgvsRec";
            this.btnAutoTaskAgvsRec.Size = new System.Drawing.Size(75, 59);
            this.btnAutoTaskAgvsRec.TabIndex = 5;
            this.btnAutoTaskAgvsRec.Text = "获取";
            this.btnAutoTaskAgvsRec.UseVisualStyleBackColor = false;
            this.btnAutoTaskAgvsRec.Click += new System.EventHandler(this.btnAutoTaskAgvsRec_Click);
            // 
            // label83
            // 
            this.label83.Dock = System.Windows.Forms.DockStyle.Left;
            this.label83.Location = new System.Drawing.Point(0, 0);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(325, 59);
            this.label83.TabIndex = 3;
            this.label83.Text = "设定只用于执行自动任务的Agv编号，用英文\',\'号隔开";
            // 
            // txtAutoTaskAgvs
            // 
            this.txtAutoTaskAgvs.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtAutoTaskAgvs.Location = new System.Drawing.Point(0, 305);
            this.txtAutoTaskAgvs.Multiline = true;
            this.txtAutoTaskAgvs.Name = "txtAutoTaskAgvs";
            this.txtAutoTaskAgvs.Size = new System.Drawing.Size(583, 136);
            this.txtAutoTaskAgvs.TabIndex = 5;
            // 
            // panel85
            // 
            this.panel85.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel85.Controls.Add(this.label82);
            this.panel85.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel85.Location = new System.Drawing.Point(0, 273);
            this.panel85.Name = "panel85";
            this.panel85.Size = new System.Drawing.Size(583, 32);
            this.panel85.TabIndex = 4;
            // 
            // label82
            // 
            this.label82.Dock = System.Windows.Forms.DockStyle.Left;
            this.label82.Location = new System.Drawing.Point(0, 0);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(135, 30);
            this.label82.TabIndex = 0;
            this.label82.Text = "自动任务可使用agv";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel84
            // 
            this.panel84.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel84.Controls.Add(this.btnCapTestStationsRef);
            this.panel84.Controls.Add(this.btnCapTestStationsRec);
            this.panel84.Controls.Add(this.txtCapTestStations);
            this.panel84.Controls.Add(this.label81);
            this.panel84.Controls.Add(this.chbTestSubUnload);
            this.panel84.Controls.Add(this.chbTestSubLoad);
            this.panel84.Controls.Add(this.chbTestSubRefu);
            this.panel84.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel84.Location = new System.Drawing.Point(0, 238);
            this.panel84.Name = "panel84";
            this.panel84.Size = new System.Drawing.Size(583, 35);
            this.panel84.TabIndex = 3;
            // 
            // btnCapTestStationsRef
            // 
            this.btnCapTestStationsRef.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCapTestStationsRef.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCapTestStationsRef.Location = new System.Drawing.Point(504, 0);
            this.btnCapTestStationsRef.Name = "btnCapTestStationsRef";
            this.btnCapTestStationsRef.Size = new System.Drawing.Size(75, 33);
            this.btnCapTestStationsRef.TabIndex = 6;
            this.btnCapTestStationsRef.Text = "设定";
            this.btnCapTestStationsRef.UseVisualStyleBackColor = false;
            this.btnCapTestStationsRef.Click += new System.EventHandler(this.btnCapTestStationsRef_Click);
            // 
            // btnCapTestStationsRec
            // 
            this.btnCapTestStationsRec.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCapTestStationsRec.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCapTestStationsRec.Location = new System.Drawing.Point(429, 0);
            this.btnCapTestStationsRec.Name = "btnCapTestStationsRec";
            this.btnCapTestStationsRec.Size = new System.Drawing.Size(75, 33);
            this.btnCapTestStationsRec.TabIndex = 5;
            this.btnCapTestStationsRec.Text = "获取";
            this.btnCapTestStationsRec.UseVisualStyleBackColor = false;
            this.btnCapTestStationsRec.Click += new System.EventHandler(this.btnCapTestStationsRec_Click);
            // 
            // txtCapTestStations
            // 
            this.txtCapTestStations.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCapTestStations.Location = new System.Drawing.Point(377, 0);
            this.txtCapTestStations.Multiline = true;
            this.txtCapTestStations.Name = "txtCapTestStations";
            this.txtCapTestStations.Size = new System.Drawing.Size(52, 33);
            this.txtCapTestStations.TabIndex = 4;
            this.txtCapTestStations.Text = "5";
            // 
            // label81
            // 
            this.label81.Dock = System.Windows.Forms.DockStyle.Left;
            this.label81.Location = new System.Drawing.Point(321, 0);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(56, 33);
            this.label81.TabIndex = 3;
            this.label81.Text = "站点数";
            this.label81.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbTestSubUnload
            // 
            this.chbTestSubUnload.AutoSize = true;
            this.chbTestSubUnload.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbTestSubUnload.Location = new System.Drawing.Point(214, 0);
            this.chbTestSubUnload.Name = "chbTestSubUnload";
            this.chbTestSubUnload.Size = new System.Drawing.Size(107, 33);
            this.chbTestSubUnload.TabIndex = 2;
            this.chbTestSubUnload.Text = "分容柜下料";
            this.chbTestSubUnload.UseVisualStyleBackColor = true;
            this.chbTestSubUnload.CheckedChanged += new System.EventHandler(this.chbTestSubUnload_CheckedChanged);
            // 
            // chbTestSubLoad
            // 
            this.chbTestSubLoad.AutoSize = true;
            this.chbTestSubLoad.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbTestSubLoad.Location = new System.Drawing.Point(107, 0);
            this.chbTestSubLoad.Name = "chbTestSubLoad";
            this.chbTestSubLoad.Size = new System.Drawing.Size(107, 33);
            this.chbTestSubLoad.TabIndex = 1;
            this.chbTestSubLoad.Text = "分容柜上料";
            this.chbTestSubLoad.UseVisualStyleBackColor = true;
            this.chbTestSubLoad.CheckedChanged += new System.EventHandler(this.chbTestSubLoad_CheckedChanged);
            // 
            // chbTestSubRefu
            // 
            this.chbTestSubRefu.AutoSize = true;
            this.chbTestSubRefu.Checked = true;
            this.chbTestSubRefu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTestSubRefu.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbTestSubRefu.Location = new System.Drawing.Point(0, 0);
            this.chbTestSubRefu.Name = "chbTestSubRefu";
            this.chbTestSubRefu.Size = new System.Drawing.Size(107, 33);
            this.chbTestSubRefu.TabIndex = 0;
            this.chbTestSubRefu.Text = "分容柜换料";
            this.chbTestSubRefu.UseVisualStyleBackColor = true;
            this.chbTestSubRefu.CheckedChanged += new System.EventHandler(this.chbTestSubRefu_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chbRandomRobotOperate);
            this.groupBox3.Controls.Add(this.chbRandomSelect);
            this.groupBox3.Controls.Add(this.btnTestSutSet);
            this.groupBox3.Controls.Add(this.btnTestSubRec);
            this.groupBox3.Controls.Add(this.label72);
            this.groupBox3.Controls.Add(this.txtTestSub);
            this.groupBox3.Controls.Add(this.panel73);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(583, 238);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "`";
            // 
            // chbRandomRobotOperate
            // 
            this.chbRandomRobotOperate.AutoSize = true;
            this.chbRandomRobotOperate.Checked = true;
            this.chbRandomRobotOperate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbRandomRobotOperate.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbRandomRobotOperate.Location = new System.Drawing.Point(486, 156);
            this.chbRandomRobotOperate.Name = "chbRandomRobotOperate";
            this.chbRandomRobotOperate.Size = new System.Drawing.Size(107, 79);
            this.chbRandomRobotOperate.TabIndex = 6;
            this.chbRandomRobotOperate.Text = "是否执行\r\n机械臂动作";
            this.chbRandomRobotOperate.UseVisualStyleBackColor = true;
            this.chbRandomRobotOperate.CheckedChanged += new System.EventHandler(this.chbRandomRobotOperate_CheckedChanged);
            // 
            // chbRandomSelect
            // 
            this.chbRandomSelect.AutoSize = true;
            this.chbRandomSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbRandomSelect.Location = new System.Drawing.Point(395, 156);
            this.chbRandomSelect.Name = "chbRandomSelect";
            this.chbRandomSelect.Size = new System.Drawing.Size(91, 79);
            this.chbRandomSelect.TabIndex = 5;
            this.chbRandomSelect.Text = "随机选择";
            this.chbRandomSelect.UseVisualStyleBackColor = true;
            this.chbRandomSelect.CheckedChanged += new System.EventHandler(this.chbRandomSelect_CheckedChanged);
            // 
            // btnTestSutSet
            // 
            this.btnTestSutSet.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTestSutSet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTestSutSet.Location = new System.Drawing.Point(320, 156);
            this.btnTestSutSet.Name = "btnTestSutSet";
            this.btnTestSutSet.Size = new System.Drawing.Size(75, 79);
            this.btnTestSutSet.TabIndex = 4;
            this.btnTestSutSet.Text = "设定";
            this.btnTestSutSet.UseVisualStyleBackColor = false;
            this.btnTestSutSet.Click += new System.EventHandler(this.btnTestSutSet_Click);
            // 
            // btnTestSubRec
            // 
            this.btnTestSubRec.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTestSubRec.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTestSubRec.Location = new System.Drawing.Point(245, 156);
            this.btnTestSubRec.Name = "btnTestSubRec";
            this.btnTestSubRec.Size = new System.Drawing.Size(75, 79);
            this.btnTestSubRec.TabIndex = 3;
            this.btnTestSubRec.Text = "获取";
            this.btnTestSubRec.UseVisualStyleBackColor = false;
            this.btnTestSubRec.Click += new System.EventHandler(this.btnTestSubRec_Click);
            // 
            // label72
            // 
            this.label72.Dock = System.Windows.Forms.DockStyle.Left;
            this.label72.Location = new System.Drawing.Point(3, 156);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(242, 79);
            this.label72.TabIndex = 2;
            this.label72.Text = "添加自动任务前往分容柜的行号以及起始站点，格式为(南面 行号-站点号[1-1即第一行从第一个站点开始执行],北面第二号-站点号+10[1-11])，非技术人员不可" +
    "操作";
            // 
            // txtTestSub
            // 
            this.txtTestSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtTestSub.Location = new System.Drawing.Point(3, 53);
            this.txtTestSub.Multiline = true;
            this.txtTestSub.Name = "txtTestSub";
            this.txtTestSub.Size = new System.Drawing.Size(577, 103);
            this.txtTestSub.TabIndex = 1;
            // 
            // panel73
            // 
            this.panel73.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel73.Controls.Add(this.chbTestLoad4);
            this.panel73.Controls.Add(this.chbTestLoad3);
            this.panel73.Controls.Add(this.chbTestLoad2);
            this.panel73.Controls.Add(this.chbTestLoad1);
            this.panel73.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel73.Location = new System.Drawing.Point(3, 21);
            this.panel73.Name = "panel73";
            this.panel73.Size = new System.Drawing.Size(577, 32);
            this.panel73.TabIndex = 0;
            // 
            // chbTestLoad4
            // 
            this.chbTestLoad4.AutoSize = true;
            this.chbTestLoad4.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbTestLoad4.Location = new System.Drawing.Point(441, 0);
            this.chbTestLoad4.Name = "chbTestLoad4";
            this.chbTestLoad4.Size = new System.Drawing.Size(147, 30);
            this.chbTestLoad4.TabIndex = 3;
            this.chbTestLoad4.Text = "上下料点4(6204)";
            this.chbTestLoad4.UseVisualStyleBackColor = true;
            this.chbTestLoad4.CheckedChanged += new System.EventHandler(this.chbTestLoad4_CheckedChanged);
            // 
            // chbTestLoad3
            // 
            this.chbTestLoad3.AutoSize = true;
            this.chbTestLoad3.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbTestLoad3.Location = new System.Drawing.Point(294, 0);
            this.chbTestLoad3.Name = "chbTestLoad3";
            this.chbTestLoad3.Size = new System.Drawing.Size(147, 30);
            this.chbTestLoad3.TabIndex = 2;
            this.chbTestLoad3.Text = "上下料点3(6203)";
            this.chbTestLoad3.UseVisualStyleBackColor = true;
            this.chbTestLoad3.CheckedChanged += new System.EventHandler(this.chbTestLoad3_CheckedChanged);
            // 
            // chbTestLoad2
            // 
            this.chbTestLoad2.AutoSize = true;
            this.chbTestLoad2.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbTestLoad2.Location = new System.Drawing.Point(147, 0);
            this.chbTestLoad2.Name = "chbTestLoad2";
            this.chbTestLoad2.Size = new System.Drawing.Size(147, 30);
            this.chbTestLoad2.TabIndex = 1;
            this.chbTestLoad2.Text = "上下料点2(6202)";
            this.chbTestLoad2.UseVisualStyleBackColor = true;
            this.chbTestLoad2.CheckedChanged += new System.EventHandler(this.chbTestLoad2_CheckedChanged);
            // 
            // chbTestLoad1
            // 
            this.chbTestLoad1.AutoSize = true;
            this.chbTestLoad1.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbTestLoad1.Location = new System.Drawing.Point(0, 0);
            this.chbTestLoad1.Name = "chbTestLoad1";
            this.chbTestLoad1.Size = new System.Drawing.Size(147, 30);
            this.chbTestLoad1.TabIndex = 0;
            this.chbTestLoad1.Text = "上下料点1(6201)";
            this.chbTestLoad1.UseVisualStyleBackColor = true;
            this.chbTestLoad1.CheckedChanged += new System.EventHandler(this.chbTestLoad1_CheckedChanged);
            // 
            // gbRouteTest
            // 
            this.gbRouteTest.BackColor = System.Drawing.Color.White;
            this.gbRouteTest.Controls.Add(this.panTestRouteS);
            this.gbRouteTest.Controls.Add(this.panel44);
            this.gbRouteTest.Controls.Add(this.panIsTest);
            this.gbRouteTest.Controls.Add(this.panTestAgvGroup);
            this.gbRouteTest.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbRouteTest.Location = new System.Drawing.Point(0, 0);
            this.gbRouteTest.Name = "gbRouteTest";
            this.gbRouteTest.Size = new System.Drawing.Size(436, 812);
            this.gbRouteTest.TabIndex = 2;
            this.gbRouteTest.TabStop = false;
            this.gbRouteTest.Text = "路段测试";
            // 
            // panTestRouteS
            // 
            this.panTestRouteS.BackColor = System.Drawing.Color.Azure;
            this.panTestRouteS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTestRouteS.Controls.Add(this.txtTestRoutes);
            this.panTestRouteS.Controls.Add(this.panel11);
            this.panTestRouteS.Controls.Add(this.panTestRouteSet);
            this.panTestRouteS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTestRouteS.Location = new System.Drawing.Point(3, 333);
            this.panTestRouteS.Name = "panTestRouteS";
            this.panTestRouteS.Size = new System.Drawing.Size(430, 476);
            this.panTestRouteS.TabIndex = 2;
            // 
            // txtTestRoutes
            // 
            this.txtTestRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTestRoutes.Location = new System.Drawing.Point(0, 127);
            this.txtTestRoutes.Multiline = true;
            this.txtTestRoutes.Name = "txtTestRoutes";
            this.txtTestRoutes.ReadOnly = true;
            this.txtTestRoutes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTestRoutes.Size = new System.Drawing.Size(428, 347);
            this.txtTestRoutes.TabIndex = 2;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel11.Controls.Add(this.btnTestRouteNoClear);
            this.panel11.Controls.Add(this.btnTestRouteClear);
            this.panel11.Controls.Add(this.btnTestRouteReceive);
            this.panel11.Controls.Add(this.btnTestRouteAdd);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 90);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(428, 37);
            this.panel11.TabIndex = 1;
            // 
            // btnTestRouteNoClear
            // 
            this.btnTestRouteNoClear.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTestRouteNoClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTestRouteNoClear.Location = new System.Drawing.Point(225, 0);
            this.btnTestRouteNoClear.Name = "btnTestRouteNoClear";
            this.btnTestRouteNoClear.Size = new System.Drawing.Size(112, 35);
            this.btnTestRouteNoClear.TabIndex = 3;
            this.btnTestRouteNoClear.Text = "清除路段编号";
            this.btnTestRouteNoClear.UseVisualStyleBackColor = false;
            this.btnTestRouteNoClear.Click += new System.EventHandler(this.btnTestRouteNoClear_Click);
            // 
            // btnTestRouteClear
            // 
            this.btnTestRouteClear.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTestRouteClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTestRouteClear.Location = new System.Drawing.Point(150, 0);
            this.btnTestRouteClear.Name = "btnTestRouteClear";
            this.btnTestRouteClear.Size = new System.Drawing.Size(75, 35);
            this.btnTestRouteClear.TabIndex = 2;
            this.btnTestRouteClear.Text = "清除";
            this.btnTestRouteClear.UseVisualStyleBackColor = false;
            this.btnTestRouteClear.Click += new System.EventHandler(this.btnTestRouteClear_Click);
            // 
            // btnTestRouteReceive
            // 
            this.btnTestRouteReceive.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTestRouteReceive.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTestRouteReceive.Location = new System.Drawing.Point(75, 0);
            this.btnTestRouteReceive.Name = "btnTestRouteReceive";
            this.btnTestRouteReceive.Size = new System.Drawing.Size(75, 35);
            this.btnTestRouteReceive.TabIndex = 1;
            this.btnTestRouteReceive.Text = "获取";
            this.btnTestRouteReceive.UseVisualStyleBackColor = false;
            this.btnTestRouteReceive.Click += new System.EventHandler(this.btnTestRouteReceive_Click);
            // 
            // btnTestRouteAdd
            // 
            this.btnTestRouteAdd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTestRouteAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnTestRouteAdd.Location = new System.Drawing.Point(0, 0);
            this.btnTestRouteAdd.Name = "btnTestRouteAdd";
            this.btnTestRouteAdd.Size = new System.Drawing.Size(75, 35);
            this.btnTestRouteAdd.TabIndex = 0;
            this.btnTestRouteAdd.Text = "添加";
            this.btnTestRouteAdd.UseVisualStyleBackColor = false;
            this.btnTestRouteAdd.Click += new System.EventHandler(this.btnTestRouteAdd_Click);
            // 
            // panTestRouteSet
            // 
            this.panTestRouteSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTestRouteSet.Controls.Add(this.panel37);
            this.panTestRouteSet.Controls.Add(this.panel36);
            this.panTestRouteSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTestRouteSet.Location = new System.Drawing.Point(0, 0);
            this.panTestRouteSet.Name = "panTestRouteSet";
            this.panTestRouteSet.Size = new System.Drawing.Size(428, 90);
            this.panTestRouteSet.TabIndex = 0;
            // 
            // panel37
            // 
            this.panel37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel37.Controls.Add(this.txtTestRouteTargetOperate);
            this.panel37.Controls.Add(this.label16);
            this.panel37.Controls.Add(this.txtTestRouteSourceOperate);
            this.panel37.Controls.Add(this.label46);
            this.panel37.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel37.Location = new System.Drawing.Point(0, 41);
            this.panel37.Name = "panel37";
            this.panel37.Size = new System.Drawing.Size(426, 41);
            this.panel37.TabIndex = 5;
            // 
            // txtTestRouteTargetOperate
            // 
            this.txtTestRouteTargetOperate.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestRouteTargetOperate.Location = new System.Drawing.Point(245, 0);
            this.txtTestRouteTargetOperate.Multiline = true;
            this.txtTestRouteTargetOperate.Name = "txtTestRouteTargetOperate";
            this.txtTestRouteTargetOperate.Size = new System.Drawing.Size(91, 39);
            this.txtTestRouteTargetOperate.TabIndex = 7;
            this.txtTestRouteTargetOperate.Text = "0";
            // 
            // label16
            // 
            this.label16.Dock = System.Windows.Forms.DockStyle.Left;
            this.label16.Location = new System.Drawing.Point(168, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(77, 39);
            this.label16.TabIndex = 6;
            this.label16.Text = "目的\r\n动作指令";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTestRouteSourceOperate
            // 
            this.txtTestRouteSourceOperate.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestRouteSourceOperate.Location = new System.Drawing.Point(77, 0);
            this.txtTestRouteSourceOperate.Multiline = true;
            this.txtTestRouteSourceOperate.Name = "txtTestRouteSourceOperate";
            this.txtTestRouteSourceOperate.Size = new System.Drawing.Size(91, 39);
            this.txtTestRouteSourceOperate.TabIndex = 5;
            this.txtTestRouteSourceOperate.Text = "0";
            // 
            // label46
            // 
            this.label46.Dock = System.Windows.Forms.DockStyle.Left;
            this.label46.Location = new System.Drawing.Point(0, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(77, 39);
            this.label46.TabIndex = 4;
            this.label46.Text = "源\r\n动作指令";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel36
            // 
            this.panel36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel36.Controls.Add(this.txtTestRouteTarget);
            this.panel36.Controls.Add(this.label20);
            this.panel36.Controls.Add(this.txtTestRouteSource);
            this.panel36.Controls.Add(this.label19);
            this.panel36.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel36.Location = new System.Drawing.Point(0, 0);
            this.panel36.Name = "panel36";
            this.panel36.Size = new System.Drawing.Size(426, 41);
            this.panel36.TabIndex = 4;
            // 
            // txtTestRouteTarget
            // 
            this.txtTestRouteTarget.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestRouteTarget.Location = new System.Drawing.Point(245, 0);
            this.txtTestRouteTarget.Multiline = true;
            this.txtTestRouteTarget.Name = "txtTestRouteTarget";
            this.txtTestRouteTarget.Size = new System.Drawing.Size(91, 39);
            this.txtTestRouteTarget.TabIndex = 7;
            // 
            // label20
            // 
            this.label20.Dock = System.Windows.Forms.DockStyle.Left;
            this.label20.Location = new System.Drawing.Point(168, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(77, 39);
            this.label20.TabIndex = 6;
            this.label20.Text = "目的RFID";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTestRouteSource
            // 
            this.txtTestRouteSource.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestRouteSource.Location = new System.Drawing.Point(77, 0);
            this.txtTestRouteSource.Multiline = true;
            this.txtTestRouteSource.Name = "txtTestRouteSource";
            this.txtTestRouteSource.Size = new System.Drawing.Size(91, 39);
            this.txtTestRouteSource.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Left;
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 39);
            this.label19.TabIndex = 4;
            this.label19.Text = "源RFID";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel44
            // 
            this.panel44.BackColor = System.Drawing.Color.LightCyan;
            this.panel44.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel44.Controls.Add(this.btnTestRouteAll);
            this.panel44.Controls.Add(this.txtTestRouteAllCount);
            this.panel44.Controls.Add(this.label52);
            this.panel44.Controls.Add(this.txtTestRouteOperateAll);
            this.panel44.Controls.Add(this.label51);
            this.panel44.Controls.Add(this.txtTestRouteTargetAll);
            this.panel44.Controls.Add(this.label50);
            this.panel44.Controls.Add(this.txtTestRouteSourceAll);
            this.panel44.Controls.Add(this.label23);
            this.panel44.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel44.Location = new System.Drawing.Point(3, 296);
            this.panel44.Name = "panel44";
            this.panel44.Size = new System.Drawing.Size(430, 37);
            this.panel44.TabIndex = 3;
            // 
            // btnTestRouteAll
            // 
            this.btnTestRouteAll.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTestRouteAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTestRouteAll.Location = new System.Drawing.Point(346, 0);
            this.btnTestRouteAll.Name = "btnTestRouteAll";
            this.btnTestRouteAll.Size = new System.Drawing.Size(82, 35);
            this.btnTestRouteAll.TabIndex = 6;
            this.btnTestRouteAll.Text = "一键添加";
            this.btnTestRouteAll.UseVisualStyleBackColor = false;
            this.btnTestRouteAll.Click += new System.EventHandler(this.btnTestRouteAll_Click);
            // 
            // txtTestRouteAllCount
            // 
            this.txtTestRouteAllCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestRouteAllCount.Location = new System.Drawing.Point(286, 0);
            this.txtTestRouteAllCount.Multiline = true;
            this.txtTestRouteAllCount.Name = "txtTestRouteAllCount";
            this.txtTestRouteAllCount.Size = new System.Drawing.Size(60, 35);
            this.txtTestRouteAllCount.TabIndex = 8;
            this.txtTestRouteAllCount.Text = "5";
            // 
            // label52
            // 
            this.label52.Dock = System.Windows.Forms.DockStyle.Left;
            this.label52.Location = new System.Drawing.Point(262, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(24, 35);
            this.label52.TabIndex = 7;
            this.label52.Text = "数量";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTestRouteOperateAll
            // 
            this.txtTestRouteOperateAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestRouteOperateAll.Location = new System.Drawing.Point(202, 0);
            this.txtTestRouteOperateAll.Multiline = true;
            this.txtTestRouteOperateAll.Name = "txtTestRouteOperateAll";
            this.txtTestRouteOperateAll.Size = new System.Drawing.Size(60, 35);
            this.txtTestRouteOperateAll.TabIndex = 5;
            this.txtTestRouteOperateAll.Text = "0";
            // 
            // label51
            // 
            this.label51.Dock = System.Windows.Forms.DockStyle.Left;
            this.label51.Location = new System.Drawing.Point(178, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(24, 35);
            this.label51.TabIndex = 4;
            this.label51.Text = "操作";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTestRouteTargetAll
            // 
            this.txtTestRouteTargetAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestRouteTargetAll.Location = new System.Drawing.Point(118, 0);
            this.txtTestRouteTargetAll.Multiline = true;
            this.txtTestRouteTargetAll.Name = "txtTestRouteTargetAll";
            this.txtTestRouteTargetAll.Size = new System.Drawing.Size(60, 35);
            this.txtTestRouteTargetAll.TabIndex = 3;
            this.txtTestRouteTargetAll.Text = "50";
            // 
            // label50
            // 
            this.label50.Dock = System.Windows.Forms.DockStyle.Left;
            this.label50.Location = new System.Drawing.Point(92, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(26, 35);
            this.label50.TabIndex = 2;
            this.label50.Text = "目的";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTestRouteSourceAll
            // 
            this.txtTestRouteSourceAll.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestRouteSourceAll.Location = new System.Drawing.Point(32, 0);
            this.txtTestRouteSourceAll.Multiline = true;
            this.txtTestRouteSourceAll.Name = "txtTestRouteSourceAll";
            this.txtTestRouteSourceAll.Size = new System.Drawing.Size(60, 35);
            this.txtTestRouteSourceAll.TabIndex = 1;
            this.txtTestRouteSourceAll.Text = "1";
            // 
            // label23
            // 
            this.label23.Dock = System.Windows.Forms.DockStyle.Left;
            this.label23.Location = new System.Drawing.Point(0, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(32, 35);
            this.label23.TabIndex = 0;
            this.label23.Text = "起始";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panIsTest
            // 
            this.panIsTest.BackColor = System.Drawing.Color.LightCyan;
            this.panIsTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panIsTest.Controls.Add(this.txtTestTaskCurrentIndex);
            this.panIsTest.Controls.Add(this.chbTestLoop);
            this.panIsTest.Controls.Add(this.chbIsTest);
            this.panIsTest.Dock = System.Windows.Forms.DockStyle.Top;
            this.panIsTest.Location = new System.Drawing.Point(3, 259);
            this.panIsTest.Name = "panIsTest";
            this.panIsTest.Size = new System.Drawing.Size(430, 37);
            this.panIsTest.TabIndex = 1;
            // 
            // txtTestTaskCurrentIndex
            // 
            this.txtTestTaskCurrentIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTestTaskCurrentIndex.Location = new System.Drawing.Point(302, 0);
            this.txtTestTaskCurrentIndex.Multiline = true;
            this.txtTestTaskCurrentIndex.Name = "txtTestTaskCurrentIndex";
            this.txtTestTaskCurrentIndex.ReadOnly = true;
            this.txtTestTaskCurrentIndex.Size = new System.Drawing.Size(126, 35);
            this.txtTestTaskCurrentIndex.TabIndex = 2;
            // 
            // chbTestLoop
            // 
            this.chbTestLoop.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbTestLoop.Location = new System.Drawing.Point(151, 0);
            this.chbTestLoop.Name = "chbTestLoop";
            this.chbTestLoop.Size = new System.Drawing.Size(151, 35);
            this.chbTestLoop.TabIndex = 1;
            this.chbTestLoop.Text = "是否执行循环动作";
            this.chbTestLoop.UseVisualStyleBackColor = true;
            this.chbTestLoop.CheckedChanged += new System.EventHandler(this.chbTestLoop_CheckedChanged);
            // 
            // chbIsTest
            // 
            this.chbIsTest.Dock = System.Windows.Forms.DockStyle.Left;
            this.chbIsTest.Location = new System.Drawing.Point(0, 0);
            this.chbIsTest.Name = "chbIsTest";
            this.chbIsTest.Size = new System.Drawing.Size(151, 35);
            this.chbIsTest.TabIndex = 0;
            this.chbIsTest.Text = "执行测试路段模式";
            this.chbIsTest.UseVisualStyleBackColor = true;
            this.chbIsTest.CheckedChanged += new System.EventHandler(this.chbIsTest_CheckedChanged);
            // 
            // panTestAgvGroup
            // 
            this.panTestAgvGroup.AutoScroll = true;
            this.panTestAgvGroup.BackColor = System.Drawing.Color.Azure;
            this.panTestAgvGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTestAgvGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTestAgvGroup.Location = new System.Drawing.Point(3, 21);
            this.panTestAgvGroup.Name = "panTestAgvGroup";
            this.panTestAgvGroup.Size = new System.Drawing.Size(430, 238);
            this.panTestAgvGroup.TabIndex = 0;
            // 
            // tabpState
            // 
            this.tabpState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabpState.Location = new System.Drawing.Point(4, 31);
            this.tabpState.Name = "tabpState";
            this.tabpState.Padding = new System.Windows.Forms.Padding(3);
            this.tabpState.Size = new System.Drawing.Size(1809, 849);
            this.tabpState.TabIndex = 4;
            this.tabpState.Text = "Agv state";
            this.tabpState.UseVisualStyleBackColor = true;
            // 
            // tabpTaskState
            // 
            this.tabpTaskState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabpTaskState.Controls.Add(this.gbTaskStateCapacityBurnInRoom);
            this.tabpTaskState.Controls.Add(this.gbTaskStatePreChargeBurnInRoom);
            this.tabpTaskState.Controls.Add(this.gbTaskStateCapacityTest);
            this.tabpTaskState.Location = new System.Drawing.Point(4, 31);
            this.tabpTaskState.Name = "tabpTaskState";
            this.tabpTaskState.Size = new System.Drawing.Size(1809, 849);
            this.tabpTaskState.TabIndex = 6;
            this.tabpTaskState.Text = "Task state";
            this.tabpTaskState.UseVisualStyleBackColor = true;
            // 
            // gbTaskStateCapacityBurnInRoom
            // 
            this.gbTaskStateCapacityBurnInRoom.Controls.Add(this.panCapAgingTask);
            this.gbTaskStateCapacityBurnInRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTaskStateCapacityBurnInRoom.Location = new System.Drawing.Point(0, 362);
            this.gbTaskStateCapacityBurnInRoom.Name = "gbTaskStateCapacityBurnInRoom";
            this.gbTaskStateCapacityBurnInRoom.Size = new System.Drawing.Size(1807, 485);
            this.gbTaskStateCapacityBurnInRoom.TabIndex = 2;
            this.gbTaskStateCapacityBurnInRoom.TabStop = false;
            this.gbTaskStateCapacityBurnInRoom.Text = "Task type3";
            // 
            // panCapAgingTask
            // 
            this.panCapAgingTask.BackColor = System.Drawing.Color.Azure;
            this.panCapAgingTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panCapAgingTask.Controls.Add(this.btnCapAgingTaskManualRef);
            this.panCapAgingTask.Controls.Add(this.label71);
            this.panCapAgingTask.Controls.Add(this.btnCapAgingTaskSet);
            this.panCapAgingTask.Controls.Add(this.label67);
            this.panCapAgingTask.Controls.Add(this.txtCapAgingTaskTime);
            this.panCapAgingTask.Controls.Add(this.label68);
            this.panCapAgingTask.Controls.Add(this.cbCapAgingTaskRefEnable);
            this.panCapAgingTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.panCapAgingTask.Location = new System.Drawing.Point(3, 24);
            this.panCapAgingTask.Name = "panCapAgingTask";
            this.panCapAgingTask.Size = new System.Drawing.Size(1801, 27);
            this.panCapAgingTask.TabIndex = 1;
            // 
            // btnCapAgingTaskManualRef
            // 
            this.btnCapAgingTaskManualRef.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCapAgingTaskManualRef.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCapAgingTaskManualRef.Location = new System.Drawing.Point(553, 0);
            this.btnCapAgingTaskManualRef.Name = "btnCapAgingTaskManualRef";
            this.btnCapAgingTaskManualRef.Size = new System.Drawing.Size(92, 25);
            this.btnCapAgingTaskManualRef.TabIndex = 8;
            this.btnCapAgingTaskManualRef.Text = "refresh";
            this.btnCapAgingTaskManualRef.UseVisualStyleBackColor = true;
            this.btnCapAgingTaskManualRef.Click += new System.EventHandler(this.btnCapAgingTaskManualRef_Click);
            // 
            // label71
            // 
            this.label71.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label71.Dock = System.Windows.Forms.DockStyle.Left;
            this.label71.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label71.Location = new System.Drawing.Point(493, 0);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(60, 25);
            this.label71.TabIndex = 7;
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCapAgingTaskSet
            // 
            this.btnCapAgingTaskSet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCapAgingTaskSet.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCapAgingTaskSet.Location = new System.Drawing.Point(418, 0);
            this.btnCapAgingTaskSet.Name = "btnCapAgingTaskSet";
            this.btnCapAgingTaskSet.Size = new System.Drawing.Size(75, 25);
            this.btnCapAgingTaskSet.TabIndex = 4;
            this.btnCapAgingTaskSet.Text = "set";
            this.btnCapAgingTaskSet.UseVisualStyleBackColor = true;
            this.btnCapAgingTaskSet.Click += new System.EventHandler(this.btnCapAgingTaskSet_Click);
            // 
            // label67
            // 
            this.label67.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label67.Dock = System.Windows.Forms.DockStyle.Left;
            this.label67.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label67.Location = new System.Drawing.Point(358, 0);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(60, 25);
            this.label67.TabIndex = 3;
            this.label67.Text = "sec";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCapAgingTaskTime
            // 
            this.txtCapAgingTaskTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCapAgingTaskTime.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCapAgingTaskTime.Location = new System.Drawing.Point(258, 0);
            this.txtCapAgingTaskTime.Multiline = true;
            this.txtCapAgingTaskTime.Name = "txtCapAgingTaskTime";
            this.txtCapAgingTaskTime.Size = new System.Drawing.Size(100, 25);
            this.txtCapAgingTaskTime.TabIndex = 2;
            // 
            // label68
            // 
            this.label68.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label68.Dock = System.Windows.Forms.DockStyle.Left;
            this.label68.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label68.Location = new System.Drawing.Point(163, 0);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(95, 25);
            this.label68.TabIndex = 1;
            this.label68.Text = "Refresh rate";
            this.label68.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbCapAgingTaskRefEnable
            // 
            this.cbCapAgingTaskRefEnable.AutoSize = true;
            this.cbCapAgingTaskRefEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbCapAgingTaskRefEnable.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCapAgingTaskRefEnable.Location = new System.Drawing.Point(0, 0);
            this.cbCapAgingTaskRefEnable.Name = "cbCapAgingTaskRefEnable";
            this.cbCapAgingTaskRefEnable.Size = new System.Drawing.Size(163, 25);
            this.cbCapAgingTaskRefEnable.TabIndex = 0;
            this.cbCapAgingTaskRefEnable.Text = "Automatic Refresh";
            this.cbCapAgingTaskRefEnable.UseVisualStyleBackColor = true;
            this.cbCapAgingTaskRefEnable.CheckedChanged += new System.EventHandler(this.cbCapAgingTaskRefEnable_CheckedChanged);
            // 
            // gbTaskStatePreChargeBurnInRoom
            // 
            this.gbTaskStatePreChargeBurnInRoom.Controls.Add(this.panPreAgingTask);
            this.gbTaskStatePreChargeBurnInRoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTaskStatePreChargeBurnInRoom.Location = new System.Drawing.Point(0, 254);
            this.gbTaskStatePreChargeBurnInRoom.Name = "gbTaskStatePreChargeBurnInRoom";
            this.gbTaskStatePreChargeBurnInRoom.Size = new System.Drawing.Size(1807, 108);
            this.gbTaskStatePreChargeBurnInRoom.TabIndex = 1;
            this.gbTaskStatePreChargeBurnInRoom.TabStop = false;
            this.gbTaskStatePreChargeBurnInRoom.Text = "Task type2";
            // 
            // panPreAgingTask
            // 
            this.panPreAgingTask.BackColor = System.Drawing.Color.Azure;
            this.panPreAgingTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panPreAgingTask.Controls.Add(this.btnPreAgingTaskManualRef);
            this.panPreAgingTask.Controls.Add(this.label70);
            this.panPreAgingTask.Controls.Add(this.btnPreAgingTaskSet);
            this.panPreAgingTask.Controls.Add(this.label65);
            this.panPreAgingTask.Controls.Add(this.txtPreAgingTaskTime);
            this.panPreAgingTask.Controls.Add(this.label66);
            this.panPreAgingTask.Controls.Add(this.cbPreAgingTaskRefEnable);
            this.panPreAgingTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.panPreAgingTask.Location = new System.Drawing.Point(3, 24);
            this.panPreAgingTask.Name = "panPreAgingTask";
            this.panPreAgingTask.Size = new System.Drawing.Size(1801, 27);
            this.panPreAgingTask.TabIndex = 1;
            // 
            // btnPreAgingTaskManualRef
            // 
            this.btnPreAgingTaskManualRef.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPreAgingTaskManualRef.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPreAgingTaskManualRef.Location = new System.Drawing.Point(553, 0);
            this.btnPreAgingTaskManualRef.Name = "btnPreAgingTaskManualRef";
            this.btnPreAgingTaskManualRef.Size = new System.Drawing.Size(92, 25);
            this.btnPreAgingTaskManualRef.TabIndex = 8;
            this.btnPreAgingTaskManualRef.Text = "refresh";
            this.btnPreAgingTaskManualRef.UseVisualStyleBackColor = true;
            this.btnPreAgingTaskManualRef.Click += new System.EventHandler(this.btnPreAgingTaskManualRef_Click);
            // 
            // label70
            // 
            this.label70.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label70.Dock = System.Windows.Forms.DockStyle.Left;
            this.label70.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label70.Location = new System.Drawing.Point(493, 0);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(60, 25);
            this.label70.TabIndex = 7;
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPreAgingTaskSet
            // 
            this.btnPreAgingTaskSet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnPreAgingTaskSet.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPreAgingTaskSet.Location = new System.Drawing.Point(418, 0);
            this.btnPreAgingTaskSet.Name = "btnPreAgingTaskSet";
            this.btnPreAgingTaskSet.Size = new System.Drawing.Size(75, 25);
            this.btnPreAgingTaskSet.TabIndex = 4;
            this.btnPreAgingTaskSet.Text = "set";
            this.btnPreAgingTaskSet.UseVisualStyleBackColor = true;
            this.btnPreAgingTaskSet.Click += new System.EventHandler(this.btnPreAgingTaskSet_Click);
            // 
            // label65
            // 
            this.label65.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label65.Dock = System.Windows.Forms.DockStyle.Left;
            this.label65.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label65.Location = new System.Drawing.Point(358, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(60, 25);
            this.label65.TabIndex = 3;
            this.label65.Text = "sec";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPreAgingTaskTime
            // 
            this.txtPreAgingTaskTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtPreAgingTaskTime.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPreAgingTaskTime.Location = new System.Drawing.Point(258, 0);
            this.txtPreAgingTaskTime.Multiline = true;
            this.txtPreAgingTaskTime.Name = "txtPreAgingTaskTime";
            this.txtPreAgingTaskTime.Size = new System.Drawing.Size(100, 25);
            this.txtPreAgingTaskTime.TabIndex = 2;
            // 
            // label66
            // 
            this.label66.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label66.Dock = System.Windows.Forms.DockStyle.Left;
            this.label66.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label66.Location = new System.Drawing.Point(163, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(95, 25);
            this.label66.TabIndex = 1;
            this.label66.Text = "Refresh rate";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbPreAgingTaskRefEnable
            // 
            this.cbPreAgingTaskRefEnable.AutoSize = true;
            this.cbPreAgingTaskRefEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbPreAgingTaskRefEnable.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbPreAgingTaskRefEnable.Location = new System.Drawing.Point(0, 0);
            this.cbPreAgingTaskRefEnable.Name = "cbPreAgingTaskRefEnable";
            this.cbPreAgingTaskRefEnable.Size = new System.Drawing.Size(163, 25);
            this.cbPreAgingTaskRefEnable.TabIndex = 0;
            this.cbPreAgingTaskRefEnable.Text = "Automatic Refresh";
            this.cbPreAgingTaskRefEnable.UseVisualStyleBackColor = true;
            this.cbPreAgingTaskRefEnable.CheckedChanged += new System.EventHandler(this.cbPreAgingTaskRefEnable_CheckedChanged);
            // 
            // gbTaskStateCapacityTest
            // 
            this.gbTaskStateCapacityTest.Controls.Add(this.panCapTestTask);
            this.gbTaskStateCapacityTest.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTaskStateCapacityTest.Location = new System.Drawing.Point(0, 0);
            this.gbTaskStateCapacityTest.Name = "gbTaskStateCapacityTest";
            this.gbTaskStateCapacityTest.Size = new System.Drawing.Size(1807, 254);
            this.gbTaskStateCapacityTest.TabIndex = 0;
            this.gbTaskStateCapacityTest.TabStop = false;
            this.gbTaskStateCapacityTest.Text = "Task type1";
            // 
            // panCapTestTask
            // 
            this.panCapTestTask.BackColor = System.Drawing.Color.Azure;
            this.panCapTestTask.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panCapTestTask.Controls.Add(this.btnCapTestTaskManualRef);
            this.panCapTestTask.Controls.Add(this.label69);
            this.panCapTestTask.Controls.Add(this.btnCapTestTaskSet);
            this.panCapTestTask.Controls.Add(this.label64);
            this.panCapTestTask.Controls.Add(this.txtCapTestTaskTime);
            this.panCapTestTask.Controls.Add(this.label63);
            this.panCapTestTask.Controls.Add(this.cbCapTestTaskRefEnable);
            this.panCapTestTask.Dock = System.Windows.Forms.DockStyle.Top;
            this.panCapTestTask.Location = new System.Drawing.Point(3, 24);
            this.panCapTestTask.Name = "panCapTestTask";
            this.panCapTestTask.Size = new System.Drawing.Size(1801, 27);
            this.panCapTestTask.TabIndex = 0;
            // 
            // btnCapTestTaskManualRef
            // 
            this.btnCapTestTaskManualRef.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCapTestTaskManualRef.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCapTestTaskManualRef.Location = new System.Drawing.Point(553, 0);
            this.btnCapTestTaskManualRef.Name = "btnCapTestTaskManualRef";
            this.btnCapTestTaskManualRef.Size = new System.Drawing.Size(92, 25);
            this.btnCapTestTaskManualRef.TabIndex = 6;
            this.btnCapTestTaskManualRef.Text = "refresh";
            this.btnCapTestTaskManualRef.UseVisualStyleBackColor = true;
            this.btnCapTestTaskManualRef.Click += new System.EventHandler(this.btnCapTestTaskManualRef_Click);
            // 
            // label69
            // 
            this.label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label69.Dock = System.Windows.Forms.DockStyle.Left;
            this.label69.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label69.Location = new System.Drawing.Point(493, 0);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(60, 25);
            this.label69.TabIndex = 5;
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCapTestTaskSet
            // 
            this.btnCapTestTaskSet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCapTestTaskSet.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCapTestTaskSet.Location = new System.Drawing.Point(418, 0);
            this.btnCapTestTaskSet.Name = "btnCapTestTaskSet";
            this.btnCapTestTaskSet.Size = new System.Drawing.Size(75, 25);
            this.btnCapTestTaskSet.TabIndex = 4;
            this.btnCapTestTaskSet.Text = "set";
            this.btnCapTestTaskSet.UseVisualStyleBackColor = true;
            this.btnCapTestTaskSet.Click += new System.EventHandler(this.btnCapTestTaskSet_Click);
            // 
            // label64
            // 
            this.label64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label64.Dock = System.Windows.Forms.DockStyle.Left;
            this.label64.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label64.Location = new System.Drawing.Point(358, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(60, 25);
            this.label64.TabIndex = 3;
            this.label64.Text = "sec";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCapTestTaskTime
            // 
            this.txtCapTestTaskTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtCapTestTaskTime.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCapTestTaskTime.Location = new System.Drawing.Point(258, 0);
            this.txtCapTestTaskTime.Multiline = true;
            this.txtCapTestTaskTime.Name = "txtCapTestTaskTime";
            this.txtCapTestTaskTime.Size = new System.Drawing.Size(100, 25);
            this.txtCapTestTaskTime.TabIndex = 2;
            // 
            // label63
            // 
            this.label63.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label63.Dock = System.Windows.Forms.DockStyle.Left;
            this.label63.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label63.Location = new System.Drawing.Point(163, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(95, 25);
            this.label63.TabIndex = 1;
            this.label63.Text = "Refresh rate";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbCapTestTaskRefEnable
            // 
            this.cbCapTestTaskRefEnable.AutoSize = true;
            this.cbCapTestTaskRefEnable.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbCapTestTaskRefEnable.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbCapTestTaskRefEnable.Location = new System.Drawing.Point(0, 0);
            this.cbCapTestTaskRefEnable.Name = "cbCapTestTaskRefEnable";
            this.cbCapTestTaskRefEnable.Size = new System.Drawing.Size(163, 25);
            this.cbCapTestTaskRefEnable.TabIndex = 0;
            this.cbCapTestTaskRefEnable.Text = "Automatic Refresh";
            this.cbCapTestTaskRefEnable.UseVisualStyleBackColor = true;
            this.cbCapTestTaskRefEnable.CheckedChanged += new System.EventHandler(this.cbCapTestTaskRefEnable_CheckedChanged);
            // 
            // tabpDoor
            // 
            this.tabpDoor.BackColor = System.Drawing.Color.White;
            this.tabpDoor.Controls.Add(this.groupBox2);
            this.tabpDoor.Controls.Add(this.groupBox7);
            this.tabpDoor.Controls.Add(this.groupBox1);
            this.tabpDoor.Location = new System.Drawing.Point(4, 31);
            this.tabpDoor.Name = "tabpDoor";
            this.tabpDoor.Size = new System.Drawing.Size(1809, 849);
            this.tabpDoor.TabIndex = 7;
            this.tabpDoor.Text = "Other state";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.panChargeInfoState);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 588);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1809, 261);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "充电桩状态及操作";
            // 
            // panChargeInfoState
            // 
            this.panChargeInfoState.AutoScroll = true;
            this.panChargeInfoState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panChargeInfoState.Location = new System.Drawing.Point(3, 24);
            this.panChargeInfoState.Name = "panChargeInfoState";
            this.panChargeInfoState.Size = new System.Drawing.Size(1803, 234);
            this.panChargeInfoState.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.BackColor = System.Drawing.Color.Azure;
            this.groupBox7.Controls.Add(this.panElevatorState);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(0, 284);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1809, 304);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "电梯状态及操作";
            // 
            // panElevatorState
            // 
            this.panElevatorState.AutoScroll = true;
            this.panElevatorState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panElevatorState.Location = new System.Drawing.Point(3, 24);
            this.panElevatorState.Name = "panElevatorState";
            this.panElevatorState.Size = new System.Drawing.Size(1803, 277);
            this.panElevatorState.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Azure;
            this.groupBox1.Controls.Add(this.panDoorState);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1809, 284);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "房门状态及操作";
            // 
            // panDoorState
            // 
            this.panDoorState.AutoScroll = true;
            this.panDoorState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDoorState.Location = new System.Drawing.Point(3, 24);
            this.panDoorState.Name = "panDoorState";
            this.panDoorState.Size = new System.Drawing.Size(1803, 257);
            this.panDoorState.TabIndex = 0;
            // 
            // tabpControlState
            // 
            this.tabpControlState.Controls.Add(this.panControlState);
            this.tabpControlState.Location = new System.Drawing.Point(4, 31);
            this.tabpControlState.Name = "tabpControlState";
            this.tabpControlState.Padding = new System.Windows.Forms.Padding(3);
            this.tabpControlState.Size = new System.Drawing.Size(1809, 849);
            this.tabpControlState.TabIndex = 8;
            this.tabpControlState.Text = "Controls State";
            this.tabpControlState.UseVisualStyleBackColor = true;
            // 
            // panControlState
            // 
            this.panControlState.AutoScroll = true;
            this.panControlState.BackColor = System.Drawing.Color.Azure;
            this.panControlState.Controls.Add(this.panAgvControls);
            this.panControlState.Controls.Add(this.panel72);
            this.panControlState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panControlState.Location = new System.Drawing.Point(3, 3);
            this.panControlState.Name = "panControlState";
            this.panControlState.Size = new System.Drawing.Size(1803, 843);
            this.panControlState.TabIndex = 1;
            // 
            // panAgvControls
            // 
            this.panAgvControls.AutoScroll = true;
            this.panAgvControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panAgvControls.Location = new System.Drawing.Point(0, 54);
            this.panAgvControls.Name = "panAgvControls";
            this.panAgvControls.Size = new System.Drawing.Size(1803, 789);
            this.panAgvControls.TabIndex = 1;
            // 
            // panel72
            // 
            this.panel72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel72.Controls.Add(this.btnManualRefControlState);
            this.panel72.Controls.Add(this.cbhAutoRefControlsState);
            this.panel72.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel72.Location = new System.Drawing.Point(0, 0);
            this.panel72.Name = "panel72";
            this.panel72.Size = new System.Drawing.Size(1803, 54);
            this.panel72.TabIndex = 0;
            // 
            // btnManualRefControlState
            // 
            this.btnManualRefControlState.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnManualRefControlState.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnManualRefControlState.Location = new System.Drawing.Point(105, 0);
            this.btnManualRefControlState.Name = "btnManualRefControlState";
            this.btnManualRefControlState.Size = new System.Drawing.Size(145, 52);
            this.btnManualRefControlState.TabIndex = 2;
            this.btnManualRefControlState.Text = "手动刷新";
            this.btnManualRefControlState.UseVisualStyleBackColor = true;
            this.btnManualRefControlState.Click += new System.EventHandler(this.btnManualRefControlState_Click);
            // 
            // cbhAutoRefControlsState
            // 
            this.cbhAutoRefControlsState.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbhAutoRefControlsState.Font = new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbhAutoRefControlsState.Location = new System.Drawing.Point(0, 0);
            this.cbhAutoRefControlsState.Name = "cbhAutoRefControlsState";
            this.cbhAutoRefControlsState.Size = new System.Drawing.Size(105, 52);
            this.cbhAutoRefControlsState.TabIndex = 1;
            this.cbhAutoRefControlsState.Text = "自动刷新";
            this.cbhAutoRefControlsState.UseVisualStyleBackColor = true;
            // 
            // cmnuTlpAgvLight
            // 
            this.cmnuTlpAgvLight.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.cmnuTlpAgvLight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnutlpAgvCol,
            this.mnutlpAgvRow,
            this.mnutlpAgvChnage});
            this.cmnuTlpAgvLight.Name = "cmnuTlpAgvLight";
            this.cmnuTlpAgvLight.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmnuTlpAgvLight.Size = new System.Drawing.Size(161, 82);
            // 
            // mnutlpAgvCol
            // 
            this.mnutlpAgvCol.MaxLength = 2;
            this.mnutlpAgvCol.Name = "mnutlpAgvCol";
            this.mnutlpAgvCol.Size = new System.Drawing.Size(100, 25);
            this.mnutlpAgvCol.Text = "0";
            // 
            // mnutlpAgvRow
            // 
            this.mnutlpAgvRow.Name = "mnutlpAgvRow";
            this.mnutlpAgvRow.Size = new System.Drawing.Size(100, 25);
            this.mnutlpAgvRow.Text = "0";
            // 
            // mnutlpAgvChnage
            // 
            this.mnutlpAgvChnage.Name = "mnutlpAgvChnage";
            this.mnutlpAgvChnage.Size = new System.Drawing.Size(160, 24);
            this.mnutlpAgvChnage.Text = "修改行列";
            this.mnutlpAgvChnage.Click += new System.EventHandler(this.mnutlpAgvChnage_Click);
            // 
            // stu
            // 
            this.stu.BackColor = System.Drawing.Color.White;
            this.stu.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.stu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stuLblUser,
            this.stuLsplit,
            this.stuLabelCommStatus,
            this.toolStripStatusLabel1,
            this.stuLabelTcpStatus,
            this.stuLsplit1,
            this.stuLabelDataToSql,
            this.stuProDataToSql,
            this.toolStripStatusLabel2,
            this.stuLabelSql,
            this.tsslAgvRun,
            this.tsslAgvStop,
            this.tsslAgvError,
            this.tsslAgvLine,
            this.tsslAgvObstacle,
            this.tsslAgvLowVoltage,
            this.toolStripStatusLabel3});
            this.stu.Location = new System.Drawing.Point(0, 911);
            this.stu.Name = "stu";
            this.stu.Size = new System.Drawing.Size(1817, 28);
            this.stu.TabIndex = 2;
            this.stu.Text = "statusStrip1";
            // 
            // stuLblUser
            // 
            this.stuLblUser.Name = "stuLblUser";
            this.stuLblUser.Size = new System.Drawing.Size(116, 23);
            this.stuLblUser.Text = "Active user：None";
            // 
            // stuLsplit
            // 
            this.stuLsplit.Name = "stuLsplit";
            this.stuLsplit.Size = new System.Drawing.Size(41, 23);
            this.stuLsplit.Text = "        ";
            // 
            // stuLabelCommStatus
            // 
            this.stuLabelCommStatus.BackColor = System.Drawing.Color.Lime;
            this.stuLabelCommStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.stuLabelCommStatus.Name = "stuLabelCommStatus";
            this.stuLabelCommStatus.Size = new System.Drawing.Size(113, 23);
            this.stuLabelCommStatus.Text = "PLC State：Open";
            this.stuLabelCommStatus.Click += new System.EventHandler(this.stuLabelCommStatus_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(41, 23);
            this.toolStripStatusLabel1.Text = "        ";
            // 
            // stuLabelTcpStatus
            // 
            this.stuLabelTcpStatus.BackColor = System.Drawing.Color.Lime;
            this.stuLabelTcpStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.stuLabelTcpStatus.Name = "stuLabelTcpStatus";
            this.stuLabelTcpStatus.Size = new System.Drawing.Size(124, 23);
            this.stuLabelTcpStatus.Text = "客户端连接：Open";
            this.stuLabelTcpStatus.Visible = false;
            this.stuLabelTcpStatus.Click += new System.EventHandler(this.stuLabelTcpStatus_Click);
            this.stuLabelTcpStatus.MouseLeave += new System.EventHandler(this.stuLabelTcpStatus_MouseLeave);
            this.stuLabelTcpStatus.MouseHover += new System.EventHandler(this.stuLabelTcpStatus_MouseHover);
            // 
            // stuLsplit1
            // 
            this.stuLsplit1.Name = "stuLsplit1";
            this.stuLsplit1.Size = new System.Drawing.Size(41, 23);
            this.stuLsplit1.Text = "        ";
            // 
            // stuLabelDataToSql
            // 
            this.stuLabelDataToSql.Name = "stuLabelDataToSql";
            this.stuLabelDataToSql.Size = new System.Drawing.Size(152, 23);
            this.stuLabelDataToSql.Text = "Data is being imported:";
            // 
            // stuProDataToSql
            // 
            this.stuProDataToSql.Name = "stuProDataToSql";
            this.stuProDataToSql.Size = new System.Drawing.Size(100, 22);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(177, 23);
            this.toolStripStatusLabel2.Text = "                                          ";
            // 
            // stuLabelSql
            // 
            this.stuLabelSql.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.stuLabelSql.Name = "stuLabelSql";
            this.stuLabelSql.Size = new System.Drawing.Size(59, 23);
            this.stuLabelSql.Text = "Plc : Ok";
            // 
            // tsslAgvRun
            // 
            this.tsslAgvRun.BackColor = System.Drawing.Color.Lime;
            this.tsslAgvRun.Name = "tsslAgvRun";
            this.tsslAgvRun.Size = new System.Drawing.Size(73, 23);
            this.tsslAgvRun.Text = "运行(绿色)";
            this.tsslAgvRun.Visible = false;
            // 
            // tsslAgvStop
            // 
            this.tsslAgvStop.BackColor = System.Drawing.Color.SkyBlue;
            this.tsslAgvStop.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslAgvStop.Name = "tsslAgvStop";
            this.tsslAgvStop.Size = new System.Drawing.Size(77, 23);
            this.tsslAgvStop.Text = "待机(蓝色)";
            this.tsslAgvStop.Visible = false;
            // 
            // tsslAgvError
            // 
            this.tsslAgvError.BackColor = System.Drawing.Color.Red;
            this.tsslAgvError.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslAgvError.Name = "tsslAgvError";
            this.tsslAgvError.Size = new System.Drawing.Size(77, 23);
            this.tsslAgvError.Text = "异常(红色)";
            this.tsslAgvError.Visible = false;
            // 
            // tsslAgvLine
            // 
            this.tsslAgvLine.BackColor = System.Drawing.Color.Silver;
            this.tsslAgvLine.Name = "tsslAgvLine";
            this.tsslAgvLine.Size = new System.Drawing.Size(73, 23);
            this.tsslAgvLine.Text = "掉线(灰色)";
            this.tsslAgvLine.Visible = false;
            // 
            // tsslAgvObstacle
            // 
            this.tsslAgvObstacle.BackColor = System.Drawing.Color.Yellow;
            this.tsslAgvObstacle.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslAgvObstacle.Name = "tsslAgvObstacle";
            this.tsslAgvObstacle.Size = new System.Drawing.Size(110, 23);
            this.tsslAgvObstacle.Text = "障碍/管制(黄色)";
            this.tsslAgvObstacle.Visible = false;
            // 
            // tsslAgvLowVoltage
            // 
            this.tsslAgvLowVoltage.BackColor = System.Drawing.Color.Aqua;
            this.tsslAgvLowVoltage.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tsslAgvLowVoltage.Name = "tsslAgvLowVoltage";
            this.tsslAgvLowVoltage.Size = new System.Drawing.Size(105, 23);
            this.tsslAgvLowVoltage.Text = "低电压(浅蓝色)";
            this.tsslAgvLowVoltage.Visible = false;
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(33, 23);
            this.toolStripStatusLabel3.Text = "      ";
            // 
            // tmrRef
            // 
            this.tmrRef.Interval = 500;
            this.tmrRef.Tick += new System.EventHandler(this.tmrRef_Tick);
            // 
            // tmrMapRef
            // 
            this.tmrMapRef.Interval = 500;
            this.tmrMapRef.Tick += new System.EventHandler(this.tmrMapRef_Tick);
            // 
            // tooltip
            // 
            this.tooltip.AutoPopDelay = 8000;
            this.tooltip.InitialDelay = 500;
            this.tooltip.ReshowDelay = 100;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(44, 269);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "更新小车模型";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(44, 306);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(156, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "获取小车模型";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(44, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(242, 45);
            this.label5.TabIndex = 12;
            this.label5.Text = "小车模型设置";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrMapChange
            // 
            this.tmrMapChange.Interval = 5000;
            this.tmrMapChange.Tick += new System.EventHandler(this.tmrMapChange_Tick);
            // 
            // tmrTip
            // 
            this.tmrTip.Interval = 2000;
            this.tmrTip.Tick += new System.EventHandler(this.tmrTip_Tick);
            // 
            // tmrAgvInfo
            // 
            this.tmrAgvInfo.Interval = 500;
            this.tmrAgvInfo.Tick += new System.EventHandler(this.tmrAgvInfo_Tick);
            // 
            // mnuSetInvLoc
            // 
            this.mnuSetInvLoc.Name = "mnuSetInvLoc";
            this.mnuSetInvLoc.Size = new System.Drawing.Size(254, 24);
            this.mnuSetInvLoc.Text = "Inventory Location";
            this.mnuSetInvLoc.Click += new System.EventHandler(this.mnuSetInvLoc_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1817, 939);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.stu);
            this.Controls.Add(this.mnu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnu;
            this.Name = "MainForm";
            this.Opacity = 0.98D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agv central control system";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.tabMain.ResumeLayout(false);
            this.tabpMap.ResumeLayout(false);
            this.tabpTask.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSqlTaskData)).EndInit();
            this.panQueryTaskTitle.ResumeLayout(false);
            this.panQueryTaskTitle.PerformLayout();
            this.tabpQueryAbnormal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSqlData)).EndInit();
            this.panQueryAbnormalTitle.ResumeLayout(false);
            this.panQueryAbnormalTitle.PerformLayout();
            this.tabpConfig.ResumeLayout(false);
            this.tabConfig.ResumeLayout(false);
            this.tabConfigAgvInfo.ResumeLayout(false);
            this.panTabConfigAgvInfo.ResumeLayout(false);
            this.panTabConfigAgvInfoList.ResumeLayout(false);
            this.panTabConfigAgvInfoList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgvInfo)).EndInit();
            this.panTabConfigAgvInfoAdd.ResumeLayout(false);
            this.panTabConfigAgvInfoAdd.PerformLayout();
            this.tabConfigMapSet.ResumeLayout(false);
            this.panMapConfig.ResumeLayout(false);
            this.panConfigMapAgvModel.ResumeLayout(false);
            this.panConfigMapAgvModel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConfigMapModel)).EndInit();
            this.panConfigMapShortPathTest.ResumeLayout(false);
            this.panConfigMapShortPathTest.PerformLayout();
            this.panConfigMapBackgroundImageSet.ResumeLayout(false);
            this.panConfigMapBackgroundImageSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConfigMap)).EndInit();
            this.tabConfigSql.ResumeLayout(false);
            this.panConfigSqlConfig.ResumeLayout(false);
            this.panConfigSQLSet1.ResumeLayout(false);
            this.panConfigSQLSet.ResumeLayout(false);
            this.panConfigSQLSet.PerformLayout();
            this.tabConfigBasic.ResumeLayout(false);
            this.panConfigBasic.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigControl)).EndInit();
            this.panConfigBasicParameter.ResumeLayout(false);
            this.panConfigBasicParameter.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpcState)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbTaskClient.ResumeLayout(false);
            this.gbTaskClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStation)).EndInit();
            this.tabConfigStation.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStationInformation)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel45.ResumeLayout(false);
            this.panel70.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel41.ResumeLayout(false);
            this.panel42.ResumeLayout(false);
            this.panel42.PerformLayout();
            this.panel43.ResumeLayout(false);
            this.panel43.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel23.ResumeLayout(false);
            this.panel23.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel19.ResumeLayout(false);
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel21.ResumeLayout(false);
            this.panel21.PerformLayout();
            this.tabConfigCharge.ResumeLayout(false);
            this.panCharge.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChargeInfo)).EndInit();
            this.panChargeAdd.ResumeLayout(false);
            this.panChargeAdd.PerformLayout();
            this.panChargeEnable.ResumeLayout(false);
            this.panel52.ResumeLayout(false);
            this.panel49.ResumeLayout(false);
            this.panel50.ResumeLayout(false);
            this.panel50.PerformLayout();
            this.panel51.ResumeLayout(false);
            this.panel51.PerformLayout();
            this.panel46.ResumeLayout(false);
            this.panel47.ResumeLayout(false);
            this.panel47.PerformLayout();
            this.panel48.ResumeLayout(false);
            this.panel48.PerformLayout();
            this.tabConfigElevator.ResumeLayout(false);
            this.panel25.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvElevator)).EndInit();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.panel95.ResumeLayout(false);
            this.panel97.ResumeLayout(false);
            this.panel98.ResumeLayout(false);
            this.panel98.PerformLayout();
            this.panel101.ResumeLayout(false);
            this.panel101.PerformLayout();
            this.panel102.ResumeLayout(false);
            this.panel103.ResumeLayout(false);
            this.panel103.PerformLayout();
            this.panel104.ResumeLayout(false);
            this.panel104.PerformLayout();
            this.tabConfigShutterDoor.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShutterDoor)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel33.ResumeLayout(false);
            this.panel34.ResumeLayout(false);
            this.panel34.PerformLayout();
            this.panel35.ResumeLayout(false);
            this.panel35.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel38.ResumeLayout(false);
            this.panel39.ResumeLayout(false);
            this.panel39.PerformLayout();
            this.panel40.ResumeLayout(false);
            this.panel40.PerformLayout();
            this.tabConfigCapacityTest.ResumeLayout(false);
            this.panCapaCityTest.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.panel99.ResumeLayout(false);
            this.panel100.ResumeLayout(false);
            this.panel106.ResumeLayout(false);
            this.panel106.PerformLayout();
            this.gbxCapacityTestOperate.ResumeLayout(false);
            this.panel92.ResumeLayout(false);
            this.panel91.ResumeLayout(false);
            this.panel91.PerformLayout();
            this.panel87.ResumeLayout(false);
            this.panel83.ResumeLayout(false);
            this.panel82.ResumeLayout(false);
            this.panel82.PerformLayout();
            this.panel74.ResumeLayout(false);
            this.panel81.ResumeLayout(false);
            this.panel80.ResumeLayout(false);
            this.panel80.PerformLayout();
            this.panel79.ResumeLayout(false);
            this.panel79.PerformLayout();
            this.panel78.ResumeLayout(false);
            this.panel78.PerformLayout();
            this.panel77.ResumeLayout(false);
            this.panel77.PerformLayout();
            this.panel76.ResumeLayout(false);
            this.panel76.PerformLayout();
            this.panel75.ResumeLayout(false);
            this.panel75.PerformLayout();
            this.gbCapacityTestWaitPoint.ResumeLayout(false);
            this.gbCapacityTestWait2.ResumeLayout(false);
            this.gbCapacityTestWait2.PerformLayout();
            this.panel31.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.gbCapacityTestWait1.ResumeLayout(false);
            this.gbCapacityTestWait1.PerformLayout();
            this.panel28.ResumeLayout(false);
            this.panel27.ResumeLayout(false);
            this.panel27.PerformLayout();
            this.tabConfigBurnInRoom.ResumeLayout(false);
            this.panAgingRoom.ResumeLayout(false);
            this.gbxCapAgingRoom.ResumeLayout(false);
            this.panel62.ResumeLayout(false);
            this.panel65.ResumeLayout(false);
            this.panel65.PerformLayout();
            this.panel67.ResumeLayout(false);
            this.panel67.PerformLayout();
            this.panel69.ResumeLayout(false);
            this.panel69.PerformLayout();
            this.gbxPreAgingRoom.ResumeLayout(false);
            this.panel60.ResumeLayout(false);
            this.panel58.ResumeLayout(false);
            this.panel58.PerformLayout();
            this.panel56.ResumeLayout(false);
            this.panel56.PerformLayout();
            this.panel54.ResumeLayout(false);
            this.panel54.PerformLayout();
            this.tabConfigTest.ResumeLayout(false);
            this.panConfigTest.ResumeLayout(false);
            this.panel88.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.panel90.ResumeLayout(false);
            this.panel90.PerformLayout();
            this.panel89.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgvMatchStation)).EndInit();
            this.gbAgvOperation.ResumeLayout(false);
            this.panel71.ResumeLayout(false);
            this.panel71.PerformLayout();
            this.panel86.ResumeLayout(false);
            this.panel85.ResumeLayout(false);
            this.panel84.ResumeLayout(false);
            this.panel84.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel73.ResumeLayout(false);
            this.panel73.PerformLayout();
            this.gbRouteTest.ResumeLayout(false);
            this.panTestRouteS.ResumeLayout(false);
            this.panTestRouteS.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panTestRouteSet.ResumeLayout(false);
            this.panel37.ResumeLayout(false);
            this.panel37.PerformLayout();
            this.panel36.ResumeLayout(false);
            this.panel36.PerformLayout();
            this.panel44.ResumeLayout(false);
            this.panel44.PerformLayout();
            this.panIsTest.ResumeLayout(false);
            this.panIsTest.PerformLayout();
            this.tabpTaskState.ResumeLayout(false);
            this.gbTaskStateCapacityBurnInRoom.ResumeLayout(false);
            this.panCapAgingTask.ResumeLayout(false);
            this.panCapAgingTask.PerformLayout();
            this.gbTaskStatePreChargeBurnInRoom.ResumeLayout(false);
            this.panPreAgingTask.ResumeLayout(false);
            this.panPreAgingTask.PerformLayout();
            this.gbTaskStateCapacityTest.ResumeLayout(false);
            this.panCapTestTask.ResumeLayout(false);
            this.panCapTestTask.PerformLayout();
            this.tabpDoor.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabpControlState.ResumeLayout(false);
            this.panControlState.ResumeLayout(false);
            this.panel72.ResumeLayout(false);
            this.cmnuTlpAgvLight.ResumeLayout(false);
            this.cmnuTlpAgvLight.PerformLayout();
            this.stu.ResumeLayout(false);
            this.stu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuSet;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuInitSet;
        private System.Windows.Forms.ToolStripMenuItem mnuVersion;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuLgoinUser;
        private System.Windows.Forms.ToolStripMenuItem mnuLoginChangePassword;
        private System.Windows.Forms.ToolStripMenuItem mnuLoginEsc;
        private System.Windows.Forms.ToolStripMenuItem mnuInitSetTab;
        private System.Windows.Forms.ToolStripMenuItem mnuInitSetAdmin;
        private System.Windows.Forms.ToolStripMenuItem mnuInitSetAdminManageUser;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabpMap;
        private System.Windows.Forms.TabPage tabpQueryAbnormal;
        private System.Windows.Forms.StatusStrip stu;
        private System.Windows.Forms.ToolStripStatusLabel stuLblUser;
        private System.Windows.Forms.TabPage tabpConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuInitSetTabMap;
        private System.Windows.Forms.ToolStripMenuItem mnuInitSetTabQueryAbnormal;
        private System.Windows.Forms.ToolStripMenuItem mnuInitSetTabConfig;
        private System.Windows.Forms.Panel panQueryAbnormalTitle;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label lblAnd;
        private System.Windows.Forms.CheckBox chbDateSelect;
        private System.Windows.Forms.Label lblQueryAbnormalAgvNo;
        private System.Windows.Forms.ComboBox cbQueryAbnormalAgvNo;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.DataGridView dgvSqlData;
        private System.Windows.Forms.Timer tmrRef;
        private System.Windows.Forms.ToolStripMenuItem mnuLoginAdd;
        private System.Windows.Forms.Panel panTabMap;
        private System.Windows.Forms.Label lblQueryAbnormalInfo;
        private System.Windows.Forms.ComboBox cbQueryAbnormalInfo;
        private System.Windows.Forms.TextBox txtQueryAbnormalRfid;
        private System.Windows.Forms.Label lblQueryAbnormalRfid;
        private System.Windows.Forms.TabPage tabpTask;
        private System.Windows.Forms.DataGridView dgvSqlTaskData;
        private System.Windows.Forms.Panel panQueryTaskTitle;
        private System.Windows.Forms.Label lblQueryTaskLineNo;
        private System.Windows.Forms.ComboBox cbQueryTaskLineNo;
        private System.Windows.Forms.Button btnTaskExport;
        private System.Windows.Forms.Button btnQueryTask;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbTaskDateSelect;
        private System.Windows.Forms.Label lblQueryTaskAgvNo;
        private System.Windows.Forms.ComboBox cbQueryTaskAgvNo;
        private System.Windows.Forms.DateTimePicker dtTaskEnd;
        private System.Windows.Forms.DateTimePicker dtTaskBegin;
        private System.Windows.Forms.ToolStripMenuItem mnuInitSetTabQueryTask;
        private System.Windows.Forms.ToolStripStatusLabel stuLsplit;
        private System.Windows.Forms.ToolStripStatusLabel stuLabelCommStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuEsc;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenInformation;
        private System.Windows.Forms.ToolStripMenuItem mnuSetRfid;
        private System.Windows.Forms.ToolStripMenuItem mnuInitSetAdminRfidSet;
        private System.Windows.Forms.ToolStripStatusLabel stuLsplit1;
        private System.Windows.Forms.ToolStripStatusLabel stuLabelTcpStatus;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.ContextMenuStrip cmnuTlpAgvLight;
        private System.Windows.Forms.ToolStripTextBox mnutlpAgvCol;
        private System.Windows.Forms.ToolStripMenuItem mnutlpAgvChnage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem mnuSetMap;
        private System.Windows.Forms.ToolStripMenuItem mnuSetMapOut;
        private System.Windows.Forms.ToolStripProgressBar stuProDataToSql;
        private System.Windows.Forms.ToolStripStatusLabel stuLabelDataToSql;
        private System.Windows.Forms.Timer tmrMapChange;
        private System.Windows.Forms.Timer tmrTip;
        private System.Windows.Forms.Timer tmrAgvInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuSetAgvSelect;
        private System.Windows.Forms.ToolStripMenuItem mnuSetPositionName;
        private System.Windows.Forms.ToolStripMenuItem mnuSetAgvModelSet;
        private System.Windows.Forms.ToolStripMenuItem mnuSetSaveParameter;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabControl tabConfig;
        private System.Windows.Forms.TabPage tabConfigAgvInfo;
        private System.Windows.Forms.Panel panTabConfigAgvInfo;
        private System.Windows.Forms.Panel panTabConfigAgvInfoList;
        private System.Windows.Forms.Button btnRestThread;
        private System.Windows.Forms.Button btnAgvComInfoObtain;
        private System.Windows.Forms.DataGridView dgvAgvInfo;
        private System.Windows.Forms.Label lblAgvConfigList;
        private System.Windows.Forms.Panel panTabConfigAgvInfoAdd;
        private System.Windows.Forms.Panel panAgvComInfoLine8;
        private System.Windows.Forms.Panel panAgvComInfoLine9;
        private System.Windows.Forms.Panel panAgvComInfoLine7;
        private System.Windows.Forms.Panel panAgvComInfoLine6;
        private System.Windows.Forms.Panel panAgvComInfoLine5;
        private System.Windows.Forms.Panel panAgvComInfoLine4;
        private System.Windows.Forms.Panel panAgvComInfoLine3;
        private System.Windows.Forms.Panel panAgvComInfoLine2;
        private System.Windows.Forms.Panel panAgvComInfoLine1;
        private System.Windows.Forms.ComboBox cbIsUsing;
        private System.Windows.Forms.Label lblIsUsing;
        private System.Windows.Forms.TextBox txtAgvInfoDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.MaskedTextBox mtxtIp;
        private System.Windows.Forms.Button btnAgvInfoAdd;
        private System.Windows.Forms.ComboBox cbAgvConnectType;
        private System.Windows.Forms.Label lblAgvType;
        private System.Windows.Forms.Label lblDesPort;
        private System.Windows.Forms.TextBox txtAgvInfoDesPort;
        private System.Windows.Forms.Label lblLocalPort;
        private System.Windows.Forms.TextBox txtAgvInfoLocalPort;
        private System.Windows.Forms.Label lblAgvNetNo;
        private System.Windows.Forms.TextBox txtAgvInfoNetNo;
        private System.Windows.Forms.TextBox txtAgvInfoId;
        private System.Windows.Forms.Label lblAgvIpAddress;
        private System.Windows.Forms.Label lblAgvId;
        private System.Windows.Forms.TabPage tabConfigMapSet;
        private System.Windows.Forms.Panel panMapConfig;
        private System.Windows.Forms.Panel panConfigMapAgvModel;
        private System.Windows.Forms.PictureBox picConfigMapModel;
        private System.Windows.Forms.LinkLabel llblConfigMapModelInsert;
        private System.Windows.Forms.Button btnConfigMapAgvModelRef;
        private System.Windows.Forms.Button btnConfigMapAgvModelRecevied;
        private System.Windows.Forms.Label lblConfigMapAgvModel;
        private System.Windows.Forms.Panel panConfigMapShortPathTest;
        private System.Windows.Forms.Label lblConfigMapShortPathTest;
        private System.Windows.Forms.TextBox txtPathShow;
        private System.Windows.Forms.Button btnShortPath;
        private System.Windows.Forms.TextBox txtStartId;
        private System.Windows.Forms.Label lblEndId;
        private System.Windows.Forms.TextBox txtEndId;
        private System.Windows.Forms.Label lblStartId;
        private System.Windows.Forms.Panel panConfigMapBackgroundImageSet;
        private System.Windows.Forms.Label lblConfigMapBackgroundImage;
        private System.Windows.Forms.Button btnMapConfigImport;
        private System.Windows.Forms.Button btnMapConfigExport;
        private System.Windows.Forms.TabPage tabConfigSql;
        private System.Windows.Forms.Panel panConfigSqlConfig;
        private System.Windows.Forms.Panel panConfigSQLSet1;
        private System.Windows.Forms.Label lblConfigSqlTItle1;
        private System.Windows.Forms.Button btnConfigDataType;
        private System.Windows.Forms.ComboBox cbConfigDataType;
        private System.Windows.Forms.Panel panConfigSQLSet;
        private System.Windows.Forms.Label lblConfigSqlTItle;
        private System.Windows.Forms.TextBox txtConfigSqlDatabase;
        private System.Windows.Forms.TextBox txtConfigSqlUserPwd;
        private System.Windows.Forms.TextBox txtConfigUserName;
        private System.Windows.Forms.TextBox txtConfigSqlAddress;
        private System.Windows.Forms.Button btnConfigSqlRef;
        private System.Windows.Forms.Button btnConfigSqlRec;
        private System.Windows.Forms.Label lblConfigSqlDataBase;
        private System.Windows.Forms.Label lblConfigSqlUserPwd;
        private System.Windows.Forms.Label lblConfigUserName;
        private System.Windows.Forms.Label lblConfigSqlAddress;
        private System.Windows.Forms.TabPage tabConfigBasic;
        private System.Windows.Forms.Panel panConfigBasic;
        private System.Windows.Forms.Panel panConfigBasicParameter;
        private System.Windows.Forms.Label lblConfigBasicParameter;
        private System.Windows.Forms.TabPage tabConfigTest;
        private System.Windows.Forms.Panel panConfigTest;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvConfigControl;
        private System.Windows.Forms.Button btnConfigControlAdd;
        private System.Windows.Forms.Label lblConfigControlPoint;
        private System.Windows.Forms.TextBox txtConfigControlPoint;
        private System.Windows.Forms.Label lblConfigControlNo;
        private System.Windows.Forms.TextBox txtConfigControlNo;
        private System.Windows.Forms.Button btnConfigControlObtain;
        private System.Windows.Forms.Label lblConfigControlPoints;
        private System.Windows.Forms.PictureBox picConfigMap;
        private System.Windows.Forms.Button btnMapConfigPreview;
        private System.Windows.Forms.Button btnMapConfigPreviewClear;
        private System.Windows.Forms.Button btnMapConfigRef;
        private System.Windows.Forms.ComboBox cbMapSel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem mnuSetMapSet;
        private System.Windows.Forms.ToolStripMenuItem mnuSetMapIn;
        private System.Windows.Forms.ToolStripTextBox mnutlpAgvRow;
        private System.Windows.Forms.ToolStripStatusLabel stuLabelSql;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem mnuSetVoltageLimited;
        private System.Windows.Forms.GroupBox gbTaskClient;
        private System.Windows.Forms.Button btnPlcClientRef;
        private System.Windows.Forms.Button btnPlcClientRec;
        private System.Windows.Forms.TextBox txtOpcHostName;
        private System.Windows.Forms.TextBox txtOpcIp;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Timer tmrMapRef;
        private System.Windows.Forms.ToolStripMenuItem mnuInitSetAdminStationSet;
        private System.Windows.Forms.ToolStripMenuItem mnuInitSetAdminStationHide;
        private System.Windows.Forms.ToolStripMenuItem mnuSetPassEnable;
        private System.Windows.Forms.TabPage tabpState;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbAgvCommonType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabConfigCharge;
        private System.Windows.Forms.Panel panCharge;
        private System.Windows.Forms.Panel panChargeAdd;
        private System.Windows.Forms.TextBox txtChargeRfid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panChargeEnable;
        private System.Windows.Forms.ComboBox cbChargeEnable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvChargeInfo;
        private System.Windows.Forms.TabPage tabConfigShutterDoor;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvShutterDoor;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ComboBox cbShutterDoorEnable;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtShutterStopRfids;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtChargedescribe;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnChargeRec;
        private System.Windows.Forms.Button btnChargeAdd;
        private System.Windows.Forms.Button btnShutterDoorReceive;
        private System.Windows.Forms.Button btnShutterDoorAdd;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txtShutterPort;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtShutterDoorIp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtShutterCallRfids;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gbRouteTest;
        private System.Windows.Forms.GroupBox gbAgvOperation;
        private System.Windows.Forms.Panel panTestAgvGroup;
        private System.Windows.Forms.Panel panIsTest;
        private System.Windows.Forms.Panel panTestRouteS;
        private System.Windows.Forms.CheckBox chbIsTest;
        private System.Windows.Forms.Panel panTestRouteSet;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnTestRouteClear;
        private System.Windows.Forms.Button btnTestRouteReceive;
        private System.Windows.Forms.Button btnTestRouteAdd;
        private System.Windows.Forms.TextBox txtTestRoutes;
        private System.Windows.Forms.TabPage tabConfigStation;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.DataGridView dgvStationInformation;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.TextBox txtStationTypeName;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Panel panel21;
        private System.Windows.Forms.TextBox txtStationType;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Button btnStationReceive;
        private System.Windows.Forms.TextBox txtStationDescribe;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.ComboBox cbStationEnable;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.TextBox txtStationName;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.TextBox txtStationNo;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Panel panel22;
        private System.Windows.Forms.Panel panel23;
        private System.Windows.Forms.TextBox txtStationMatchValue;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Panel panel24;
        private System.Windows.Forms.TextBox txtStationRfid;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnStationRef;
        private System.Windows.Forms.Button btnStationRec;
        private System.Windows.Forms.DataGridView dgvStation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.TabPage tabConfigCapacityTest;
        private System.Windows.Forms.TabPage tabConfigBurnInRoom;
        private System.Windows.Forms.Panel panCapaCityTest;
        private System.Windows.Forms.GroupBox gbCapacityTestWaitPoint;
        private System.Windows.Forms.GroupBox gbCapacityTestWait1;
        private System.Windows.Forms.Panel panel27;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txtCapacityTestWait1Rfid;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox txtCapacityTestWait1Rfids;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox txtCapacityTestWait1Stations;
        private System.Windows.Forms.Panel panel28;
        private System.Windows.Forms.Button btnCapacityTestWait1Receive;
        private System.Windows.Forms.Button btnCapacityTestWait1Update;
        private System.Windows.Forms.GroupBox gbCapacityTestWait2;
        private System.Windows.Forms.Panel panel31;
        private System.Windows.Forms.Button btnCapacityTestWait2Receive;
        private System.Windows.Forms.Button btnCapacityTestWait2update;
        private System.Windows.Forms.TextBox txtCapacityTestWait2Rfids;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtCapacityTestWait2Stations;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Panel panel32;
        private System.Windows.Forms.TextBox txtCapacityTestWait2Rfid;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Panel panel33;
        private System.Windows.Forms.Panel panel34;
        private System.Windows.Forms.TextBox txtShutterRelationNumber;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Panel panel35;
        private System.Windows.Forms.TextBox txtShutterRelation;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TabPage tabpTaskState;
        private System.Windows.Forms.GroupBox gbTaskStateCapacityBurnInRoom;
        private System.Windows.Forms.GroupBox gbTaskStatePreChargeBurnInRoom;
        private System.Windows.Forms.GroupBox gbTaskStateCapacityTest;
        private System.Windows.Forms.ToolStripMenuItem mnuFullSrceen;
        private System.Windows.Forms.Panel panel37;
        private System.Windows.Forms.TextBox txtTestRouteTargetOperate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTestRouteSourceOperate;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Panel panel36;
        private System.Windows.Forms.TextBox txtTestRouteTarget;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtTestRouteSource;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabpDoor;
        private System.Windows.Forms.Panel panDoorState;
        private System.Windows.Forms.Panel panel38;
        private System.Windows.Forms.Panel panel39;
        private System.Windows.Forms.TextBox txtShutterDoorName;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Panel panel40;
        private System.Windows.Forms.TextBox txtShutterDoorNo;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.CheckBox chbTestLoop;
        private System.Windows.Forms.Button btnTestRouteNoClear;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveOther;
        private System.Windows.Forms.Panel panel41;
        private System.Windows.Forms.Panel panel42;
        private System.Windows.Forms.TextBox txtStationGroup;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel43;
        private System.Windows.Forms.TextBox txtStationOperate;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.TextBox txtTestTaskCurrentIndex;
        private System.Windows.Forms.Panel panel44;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtTestRouteOperateAll;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox txtTestRouteTargetAll;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox txtTestRouteSourceAll;
        private System.Windows.Forms.Button btnTestRouteAll;
        private System.Windows.Forms.TextBox txtTestRouteAllCount;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Panel panel45;
        private System.Windows.Forms.ComboBox cbbStationTypeShow;
        private System.Windows.Forms.ComboBox cbbStationTypeShow1;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Panel panel46;
        private System.Windows.Forms.Panel panel47;
        private System.Windows.Forms.TextBox txtChargeName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel48;
        private System.Windows.Forms.TextBox txtChargeNo;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Panel panel49;
        private System.Windows.Forms.Panel panel50;
        private System.Windows.Forms.TextBox txtChargePort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel51;
        private System.Windows.Forms.TextBox txtChargeIp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel52;
        private System.Windows.Forms.ComboBox cbChargeType;
        private System.Windows.Forms.Panel panel53;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Panel panAgingRoom;
        private System.Windows.Forms.GroupBox gbxPreAgingRoom;
        private System.Windows.Forms.GroupBox gbxCapAgingRoom;
        private System.Windows.Forms.Panel panel54;
        private System.Windows.Forms.TextBox txtPreAgingRoomLoadAreaRfid;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Panel panel56;
        private System.Windows.Forms.TextBox txtPreAgingRoomStaticAreaRfid;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Panel panel55;
        private System.Windows.Forms.Panel panel58;
        private System.Windows.Forms.TextBox txtPreAgingRoomUnloadAreaRfid;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Panel panel57;
        private System.Windows.Forms.Panel panel60;
        private System.Windows.Forms.Button btnPreAgingRoomUpdate;
        private System.Windows.Forms.Panel panel61;
        private System.Windows.Forms.Button btnPreAgingRoomRfidReceive;
        private System.Windows.Forms.Panel panel59;
        private System.Windows.Forms.Panel panel62;
        private System.Windows.Forms.Button btnCapAgingRoomUpdate;
        private System.Windows.Forms.Panel panel63;
        private System.Windows.Forms.Button btnCapAgingRoomRfidReceive;
        private System.Windows.Forms.Panel panel64;
        private System.Windows.Forms.Panel panel65;
        private System.Windows.Forms.TextBox txtCapAgingRoomUnloadAreaRfid;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Panel panel66;
        private System.Windows.Forms.Panel panel67;
        private System.Windows.Forms.TextBox txtCapAgingRoomStaticArea2Rfid;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.TextBox txtCapAgingRoomStaticArea1Rfid;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Panel panel68;
        private System.Windows.Forms.Panel panel69;
        private System.Windows.Forms.TextBox txtCapAgingRoomLoadAreaRfid;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panChargeInfoState;
        private System.Windows.Forms.Panel panel70;
        private System.Windows.Forms.Button btnStationAdd;
        private System.Windows.Forms.Button btnCellsStationAdd;
        private System.Windows.Forms.Panel panCapAgingTask;
        private System.Windows.Forms.Button btnCapAgingTaskSet;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.TextBox txtCapAgingTaskTime;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.CheckBox cbCapAgingTaskRefEnable;
        private System.Windows.Forms.Panel panPreAgingTask;
        private System.Windows.Forms.Button btnPreAgingTaskSet;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TextBox txtPreAgingTaskTime;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.CheckBox cbPreAgingTaskRefEnable;
        private System.Windows.Forms.Panel panCapTestTask;
        private System.Windows.Forms.Button btnCapTestTaskSet;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox txtCapTestTaskTime;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.CheckBox cbCapTestTaskRefEnable;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Button btnCapAgingTaskManualRef;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Button btnPreAgingTaskManualRef;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Button btnCapTestTaskManualRef;
        private System.Windows.Forms.Panel panel71;
        private System.Windows.Forms.TabPage tabpControlState;
        private System.Windows.Forms.Panel panControlState;
        private System.Windows.Forms.Panel panel72;
        private System.Windows.Forms.CheckBox cbhAutoRefControlsState;
        private System.Windows.Forms.Button btnManualRefControlState;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel73;
        private System.Windows.Forms.CheckBox chbTestLoad2;
        private System.Windows.Forms.CheckBox chbTestLoad1;
        private System.Windows.Forms.CheckBox chbTestLoad4;
        private System.Windows.Forms.CheckBox chbTestLoad3;
        private System.Windows.Forms.TextBox txtTestSub;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Button btnTestSutSet;
        private System.Windows.Forms.Button btnTestSubRec;
        private System.Windows.Forms.CheckBox chbRandomSelect;
        private System.Windows.Forms.GroupBox gbxCapacityTestOperate;
        private System.Windows.Forms.Panel panel74;
        private System.Windows.Forms.Panel panel81;
        private System.Windows.Forms.Button btnCapacityTestOperateRec;
        private System.Windows.Forms.Button btnCapacityTestOperateRef;
        private System.Windows.Forms.Panel panel80;
        private System.Windows.Forms.TextBox txtCapacityTestRightUnload;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Panel panel79;
        private System.Windows.Forms.TextBox txtCapacityTestLeftUnload;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Panel panel78;
        private System.Windows.Forms.TextBox txtCapacityTestRightRefueling;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Panel panel77;
        private System.Windows.Forms.TextBox txtCapacityTestLeftRefueling;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.Panel panel76;
        private System.Windows.Forms.TextBox txtCapacityTestRightLoad;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Panel panel75;
        private System.Windows.Forms.TextBox txtCapacityTestLeftLoad;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Panel panAgvControls;
        private System.Windows.Forms.Panel panel82;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.TextBox txtTestSubStayTime;
        private System.Windows.Forms.Panel panel83;
        private System.Windows.Forms.Button txtTestSubStayRec;
        private System.Windows.Forms.Button btnTestSubStayRef;
        private System.Windows.Forms.Panel panel84;
        private System.Windows.Forms.CheckBox chbTestSubUnload;
        private System.Windows.Forms.CheckBox chbTestSubLoad;
        private System.Windows.Forms.CheckBox chbTestSubRefu;
        private System.Windows.Forms.TextBox txtCapTestStations;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Button btnCapTestStationsRef;
        private System.Windows.Forms.Button btnCapTestStationsRec;
        private System.Windows.Forms.TextBox txtAutoTaskAgvs;
        private System.Windows.Forms.Panel panel85;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.Panel panel86;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Button btnAutoTaskAgvsRef;
        private System.Windows.Forms.Button btnAutoTaskAgvsRec;
        private System.Windows.Forms.ToolStripMenuItem mnuSetReceiveMesTask;
        private System.Windows.Forms.Panel panel87;
        private System.Windows.Forms.CheckBox chbQRCode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnLineTimeRef;
        private System.Windows.Forms.Button btnLineTimeRec;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.TextBox txtLineTime;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtClearLineTime;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.CheckBox chbSaveRoute;
        private System.Windows.Forms.Panel panel88;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel89;
        private System.Windows.Forms.DataGridView dgvAgvMatchStation;
        private System.Windows.Forms.Button btnAgvMatchStationRef;
        private System.Windows.Forms.Button btnAgvMatchStationRec;
        private System.Windows.Forms.Panel panel90;
        private System.Windows.Forms.CheckBox chbMatchTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtDoorNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtDoorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtDoorIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtDoorPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtDoorStopRfids;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtDoorCallRfids;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ccbDoorEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtDoorRelation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtDoorRelationNumber;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnDoorOperate;
        private System.Windows.Forms.DataGridViewButtonColumn cBtnDoorDelete;
        private System.Windows.Forms.DataGridView dgvOpcState;
        private System.Windows.Forms.Button btnRobotRefence;
        private System.Windows.Forms.Button btnRobotStateReceive;
        private System.Windows.Forms.Panel panel92;
        private System.Windows.Forms.Button btnGroupMesTaskRec;
        private System.Windows.Forms.Button btnGroupMesTaskRef;
        private System.Windows.Forms.Panel panel91;
        private System.Windows.Forms.TextBox txtGroupMesTask;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.ToolStripStatusLabel tsslAgvRun;
        private System.Windows.Forms.ToolStripStatusLabel tsslAgvStop;
        private System.Windows.Forms.ToolStripStatusLabel tsslAgvError;
        private System.Windows.Forms.ToolStripStatusLabel tsslAgvObstacle;
        private System.Windows.Forms.ToolStripStatusLabel tsslAgvLine;
        private System.Windows.Forms.ToolStripStatusLabel tsslAgvLowVoltage;
        private System.Windows.Forms.CheckBox chbRandomRobotOperate;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.ComboBox cbQueryTaskTaskType;
        private System.Windows.Forms.Panel panel93;
        private System.Windows.Forms.CheckBox chbTaskMes;
        private System.Windows.Forms.Label lblTaskCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Panel panel99;
        private System.Windows.Forms.Panel panel100;
        private System.Windows.Forms.Button btnAgvLimitedRec;
        private System.Windows.Forms.Button btnAgvLimitedRef;
        private System.Windows.Forms.Panel panel106;
        private System.Windows.Forms.TextBox txtAgvLimited;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.ToolStripMenuItem mnuInitSetIsDynPwd;
        private System.Windows.Forms.TabPage tabConfigElevator;
        private System.Windows.Forms.Panel panel25;
        private System.Windows.Forms.DataGridView dgvElevator;
        private System.Windows.Forms.Panel panel26;
        private System.Windows.Forms.Button btnElevatorReceive;
        private System.Windows.Forms.Button btnElevatorAdd;
        private System.Windows.Forms.Panel panel95;
        private System.Windows.Forms.ComboBox cbElevatorEnable;
        private System.Windows.Forms.Panel panel96;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txtElevatorCallRfids;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox txtElevatorStopRfids;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Panel panel97;
        private System.Windows.Forms.Panel panel98;
        private System.Windows.Forms.TextBox txtElevatorPort;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Panel panel101;
        private System.Windows.Forms.TextBox txtElevatorIp;
        private System.Windows.Forms.Label label89;
        private System.Windows.Forms.Panel panel102;
        private System.Windows.Forms.Panel panel103;
        private System.Windows.Forms.TextBox txtElevatorName;
        private System.Windows.Forms.Label label90;
        private System.Windows.Forms.Panel panel104;
        private System.Windows.Forms.TextBox txtElevatorNo;
        private System.Windows.Forms.Label label91;
        private System.Windows.Forms.TextBox txtElevatorNumber;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtxtElevatorNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtxtElevatorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtxtElevatorIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtxtElevatorPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtxtElevatorStopRfids;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtxtElevatorCallRfids;
        private System.Windows.Forms.DataGridViewTextBoxColumn dtxtElevatorFloorNumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dchbElevatorEnable;
        private System.Windows.Forms.DataGridViewButtonColumn dbtnOperate;
        private System.Windows.Forms.DataGridViewButtonColumn dbtnDelete;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Panel panElevatorState;
        private System.Windows.Forms.ProgressBar pbAbn;
        private System.Windows.Forms.Label lblAbnWaitShow;
        private System.Windows.Forms.ProgressBar pbQueryTask;
        private System.Windows.Forms.Label lblQueryTaskShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Handle;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpcParameterValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtConfigControlNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtConfigControlPoint;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn17;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn18;
        private System.Windows.Forms.TextBox txtHandleValue;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox txtHandle;
        private System.Windows.Forms.Label lblHandle;
        private System.Windows.Forms.Button btnOpcValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtChargeNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ccbChargeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtChargeIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtChargePort;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtChargeRfid;
        private System.Windows.Forms.DataGridViewComboBoxColumn ccbChargeType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ccbChargeEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtChargeDescribe;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnChargeOperate;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnChargeDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTxtAgvId;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTxtDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTxtAgvAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTxtAgvNetNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTxtLocalPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTxtDesPort;
        private System.Windows.Forms.DataGridViewComboBoxColumn cCbAgvConnectType;
        private System.Windows.Forms.DataGridViewComboBoxColumn cCbAgvCommonType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cCbIsUsing;
        private System.Windows.Forms.DataGridViewButtonColumn cCbDelete;
        private System.Windows.Forms.DataGridViewButtonColumn cCbChange;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtStationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtStationNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtStationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtStationRfid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtStationMatchValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtStationInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtStationGroup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ccbStationEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtStationDescribe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ctxtStationBindAgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStationState;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStationHandle;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtStationUpdateTime;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnStationOperate;
        private System.Windows.Forms.DataGridViewButtonColumn cbtnStationDelete;
        private System.Windows.Forms.ToolStripMenuItem testTaskToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnChargeTimeUpdate;
        private System.Windows.Forms.Button btnChargeTimeReceive;
        private System.Windows.Forms.TextBox txtChargeTime;
        private System.Windows.Forms.Label label93;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label94;
        private System.Windows.Forms.Button btnStandbyChargeTimeUpdate;
        private System.Windows.Forms.Button btnStandbyChargeTimeReceive;
        private System.Windows.Forms.TextBox txtStanbyChargeTime;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.ToolStripMenuItem mnuWorkMode;
        private System.Windows.Forms.ToolStripMenuItem mnuAgvInit;
        private System.Windows.Forms.ToolStripMenuItem mnuSetInvLoc;
    }
}

