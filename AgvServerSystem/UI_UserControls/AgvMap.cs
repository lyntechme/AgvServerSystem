using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgvServerSystem.UI_UserControls
{
    /// <summary>
    /// agv电子地图控件组合，包含全部关于电子地图的操作
    /// </summary>
    public partial class AgvMap : UserControl
    {
        #region properties
        /// <summary>
        /// 用户权限 0：显示权限，1；简单设定权限，2：管理员权限
        /// </summary>
        private int UserLevel;
        /// <summary>
        /// 电子地图信息
        /// </summary>
        private MapInfo mapInfo;
        #endregion
        /// <summary>
        /// 无参数初始化
        /// </summary>
        public AgvMap()
        {
            InitializeComponent();
            UserLevel = 0;
            AgvMapInit();
        }
        /// <summary>
        /// 带参数初始化
        /// </summary>
        /// <param name="_userLevel"></param>
        public AgvMap(int _userLevel,MapInfo _mapInfo)
        {
            InitializeComponent();
            this.UserLevel = _userLevel;
            this.mapInfo = _mapInfo;
            AgvMapInit();
        }
        private void AgvMapInit()
        {
            this.mapInfo = new MapInfo(0, "map0");
            PanMap();
        }
        /// <summary>
        /// 电子地图panel的设置
        /// </summary>
        private void PanMap()
        {
            Panel panMap = new MapPanel();
            panMap.Parent = this;
            panMap.Dock = DockStyle.Fill;

        }
    }

    /// <summary>
    /// 电子地图属性
    /// </summary>
    public class MapInfo
    {
        public MapInfo(int _id, string _name)
        {
            this.Id = _id;
            this.Name = _name;
        }
        /// <summary>
        /// 电子地图id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 电子地图名称
        /// </summary>
        public string Name { get; set; }
        //public string Set { get; set; }
    }
}
