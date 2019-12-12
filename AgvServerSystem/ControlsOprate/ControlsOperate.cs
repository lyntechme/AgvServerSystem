using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using System.Drawing;
using System.Diagnostics;

namespace AgvServerSystem
{
    public class ControlsOperate
    {
        #region priperties
        private static point mouseDownAgvPoint = new point();
        private static bool isLeftMouseRfidLabel = false;
        private static point mouseDownStation = new point();
        private static bool isStationLeftMouse = false;
        private static bool isInvLocLeftMouse = false;
        private static int lastStationId = -1;
        private static int lastInvLocId = -1;
        private static ToolTip tlpStation = new ToolTip();
        private static ToolTip tlpInvLoc = new ToolTip();

        public static int InvLocId { get; private set; }
        #endregion
        /// <summary>
        /// 添加Rfid坐标点的label
        /// </summary>
        /// <param name="_rfid">rfid集合</param>
        /// <param name="panMap">地图标号</param>
        /// <param name="rfidLabel">rfid Label集合</param>
        public static void AddLabelRfidPoint(Dictionary<int, MA_RfidPoint> _rfid, Panel panMap, Dictionary<int, Label> _rfidLabelDt)
        {
            if (_rfid != null)
            {
                try
                {
                    foreach (MA_RfidPoint item in _rfid.Values)
                    {
                        if (item.MapNo == (int)panMap.Tag)
                        {
                            Label lbl = new Label();
                            lbl.Name = "lblr" + item.RfidNo.ToString();
                            lbl.Location = new Point(Convert.ToInt32(item.RfidX * Common.sizeMapImage[item.MapNo].widthScale) - Common.excPoint.X, Convert.ToInt32(item.RfidY * Common.sizeMapImage[item.MapNo].heightScale) - Common.excPoint.Y);
                            lbl.Text = item.RfidNo.ToString();
                            lbl.BackColor = Color.Yellow;
                            lbl.AutoSize = false;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Size = new Size(20, 20);
                            lbl.Font = new Font("宋体", 7f, FontStyle.Regular);
                            //lbl.Visible = false;
                            //cb.Enabled = false;
                            lbl.Parent = panMap;
                            lbl.MouseDown += lbl_MouseDown;
                            lbl.MouseUp += lbl_MouseUp;
                            lbl.MouseMove += lbl_MouseMove;
                            _rfidLabelDt[item.RfidNo] = lbl;
                        }
                    }
                }
                catch
                { }
                //return panMap;
            }
        }

        static void lbl_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                if (isLeftMouseRfidLabel)
                {
                    Point movPoint = new Point();
                    movPoint.X = Cursor.Position.X - mouseDownAgvPoint.X;
                    movPoint.Y = Cursor.Position.Y - mouseDownAgvPoint.Y;
                    Debug.Print(string.Format("{0},{1}", movPoint.X, movPoint.Y));
                    mouseDownAgvPoint.X = Cursor.Position.X;
                    mouseDownAgvPoint.Y = Cursor.Position.Y;
                    lbl.Left += movPoint.X;
                    lbl.Top += movPoint.Y;

                }
            }
            catch { }
        }

        static void lbl_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                int rfid = Convert.ToInt32(lbl.Name.Replace("lblr", ""));
                int mapNo = Common.rfidDt[rfid].MapNo;
                int x = Convert.ToInt32((lbl.Left + Common.excPoint.X) / Common.sizeMapImage[mapNo].widthScale);
                int y = Convert.ToInt32((lbl.Top + Common.excPoint.Y) / Common.sizeMapImage[mapNo].heightScale);
                Common.rfidDt[rfid].RfidX = x;
                Common.rfidDt[rfid].RfidY = y;
                isLeftMouseRfidLabel = false;
            }
            catch { }
        }

        static void lbl_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    mouseDownAgvPoint.X = Cursor.Position.X;
                    mouseDownAgvPoint.Y = Cursor.Position.Y;
                    isLeftMouseRfidLabel = true;
                }
            }
            catch { }
        }
        /// <summary>
        /// 删除Rfid坐标点的label
        /// </summary>
        /// <param name="_rfid">rfid信息集合</param>
        /// <param name="panMap">地图Panel</param>
        /// <param name="_rfidLabelDt">rfid Label集合</param>
        public static void RemoveRfidPoint(Dictionary<int, MA_RfidPoint> _rfid, Panel panMap, Dictionary<int, Label> _rfidLabelDt)
        {
            try
            {
                foreach (int item in _rfid.Keys)
                {
                    try
                    {
                        while (_rfidLabelDt.ContainsKey(item))
                        {
                            _rfidLabelDt[item].Parent = null;
                            _rfidLabelDt.Remove(item);
                        }
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 修改Rfid坐标点的label
        /// </summary>
        /// <param name="_rfid">rfid信息集合</param>
        /// <param name="panMap">地图</param>
        /// <param name="_rfidLabelDt">rfid label集合</param>
        public static void ChangeRfidPoint(MA_RfidPoint _rfid, Panel panMap, Dictionary<int, Label> _rfidLabelDt)
        {
            try
            {
                if (_rfidLabelDt.ContainsKey(_rfid.RfidNo))
                {
                    _rfidLabelDt[_rfid.RfidNo].Location = new Point(Convert.ToInt32(_rfid.RfidX * Common.sizeMapImage[_rfid.MapNo].widthScale) - Common.excPoint.X, Convert.ToInt32(_rfid.RfidY * Common.sizeMapImage[_rfid.MapNo].heightScale) - Common.excPoint.Y);
                }
            }
            catch { }
        }
        /// <summary>
        /// 查询Rfid坐标点的label
        /// </summary>
        /// <param name="_rfid"></param>
        /// <param name="panMap"></param>
        public static void QueryRfidPoint(List<MA_RfidPoint> _rfid, Panel panMap)
        {

        }
        /// <summary>
        /// 添加站点
        /// </summary>
        /// <param name="_stationPosition"></param>
        /// <param name="pan"></param>
        /// <param name="lblDt"></param>
        public static void AddLabelStationPoint(Dictionary<int, StationInfo> _stationPosition, Panel pan, Dictionary<int, Label> lblDt)
        {
            int mapNo = (int)pan.Tag;
            if (_stationPosition != null)
            {
                try
                {
                    foreach (StationInfo item in _stationPosition.Values)
                    {
                        if (item.MapNo == mapNo)
                        {
                            Label lbl = new Label();
                            lbl.Name = "lblSP" + item.Id.ToString();
                            lbl.Location = new Point(Convert.ToInt32(item.LayoutInfo.Location.X * Common.sizeMapImage[mapNo].widthScale), Convert.ToInt32(item.LayoutInfo.Location.Y * Common.sizeMapImage[mapNo].heightScale));
                            lbl.Text = item.Name.ToString();
                            lbl.Tag = item.Id;
                            lbl.ForeColor = Color.Black;
                            lbl.BackColor = Color.White;
                            lbl.AutoSize = false;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Size = new Size(Convert.ToInt32(item.LayoutInfo.Size.X * Common.sizeMapImage[mapNo].widthScale), Convert.ToInt32(item.LayoutInfo.Size.Y * Common.sizeMapImage[mapNo].heightScale));
                            lbl.Font = new Font("新宋体", 6.5f, FontStyle.Regular);
                            lbl.BorderStyle = BorderStyle.FixedSingle;
                            lbl.BringToFront();
                            //点击事件
                            //lbl.Tag = mapNo;
                            lbl.MouseDown += new MouseEventHandler(lbl_RightClick);
                            lbl.MouseMove += lbl_StationMouseMove;
                            lbl.MouseUp += lbl_stationMouseUp;
                            lbl.MouseLeave += lbl_StationMouseLeave;
                            //根据当前缓存点的信息显示不同的颜色
                            //lbl.Visible = false;
                            //cb.Enabled = false;
                            lbl.Parent = pan;
                            lblDt[item.Id] = lbl;
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public static void AddLabelInvLocPoint(Dictionary<int, InventoryLocationInfo> _InvLocPosition, Panel pan, Dictionary<int, Label> lblDt)
        {
            int mapNo = (int)pan.Tag;
            if (_InvLocPosition != null)
            {
                try
                {
                    foreach (InventoryLocationInfo item in _InvLocPosition.Values)
                    {
                        if (item.MapNo == mapNo)
                        {
                            Label lbl = new Label();
                            lbl.Name = "lblIL" + item.Id.ToString();
                            lbl.Location = new Point(Convert.ToInt32(item.LayoutInfo.location.X * Common.sizeMapImage[mapNo].widthScale), Convert.ToInt32(item.LayoutInfo.location.Y * Common.sizeMapImage[mapNo].heightScale));
                            lbl.Text = item.Name.ToString();
                            lbl.Tag = item.Id;
                            lbl.ForeColor = Color.Black;
                            lbl.BackColor = Color.White;
                            lbl.AutoSize = false;
                            lbl.TextAlign = ContentAlignment.MiddleCenter;
                            lbl.Size = new Size(Convert.ToInt32(item.LayoutInfo.size.X * Common.sizeMapImage[mapNo].widthScale), Convert.ToInt32(item.LayoutInfo.size.Y * Common.sizeMapImage[mapNo].heightScale));
                            lbl.Font = new Font("新宋体", 6.5f, FontStyle.Regular);
                            lbl.BorderStyle = BorderStyle.FixedSingle;
                            lbl.BringToFront();
                            //点击事件
                            //lbl.Tag = mapNo;
                            lbl.MouseDown += new MouseEventHandler(lbl_RightClick);
                            lbl.MouseMove += lbl_StationMouseMove;
                            lbl.MouseUp += lbl_stationMouseUp;
                            lbl.MouseLeave += lbl_StationMouseLeave;
                            //根据当前缓存点的信息显示不同的颜色
                            //lbl.Visible = false;
                            //cb.Enabled = false;
                            lbl.Parent = pan;
                            lblDt[item.Id] = lbl;
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        static void lbl_StationMouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            try
            {
                int statoinId = Convert.ToInt32(lbl.Tag);
                if (lastStationId == statoinId) lastStationId = -1;
            }
            catch { }
        }

        static void lbl_InvLocMouseLeave(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            try
            {
                int InvLocId = Convert.ToInt32(lbl.Tag);
                if (lastInvLocId == InvLocId) lastInvLocId = -1;
            }
            catch { }
        }


        private static void lbl_stationMouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                int stationId = Convert.ToInt32(lbl.Name.Replace("lblSP", ""));
                int mapNo = Common.dtStationInfo[stationId].MapNo;
                int x = Convert.ToInt32((lbl.Left) / Common.sizeMapImage[mapNo].widthScale);
                int y = Convert.ToInt32((lbl.Top) / Common.sizeMapImage[mapNo].heightScale);
                Common.dtStationInfo[stationId].LayoutInfo.Location.X = x;
                Common.dtStationInfo[stationId].LayoutInfo.Location.Y = y;
                isStationLeftMouse = false;
            }
            catch { }
        }

        private static void lbl_InvLocMouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                int stationId = Convert.ToInt32(lbl.Name.Replace("lblIL", ""));
                int mapNo = Common.dtInvLocInfo[InvLocId].MapNo;
                int x = Convert.ToInt32((lbl.Left) / Common.sizeMapImage[mapNo].widthScale);
                int y = Convert.ToInt32((lbl.Top) / Common.sizeMapImage[mapNo].heightScale);
                Common.dtInvLocInfo[InvLocId].LayoutInfo.location.X = x;
                Common.dtInvLocInfo[InvLocId].LayoutInfo.location.Y = y;
               // Common.dtInvLocInfo[InvLocId].LayoutInfo.Location = new point(x, y);
                isInvLocLeftMouse = false;
            }
            catch { }
        }



        private static void lbl_StationMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                int stationId = (int)lbl.Tag;
                if (isStationLeftMouse)
                {
                    Point movPoint = new Point();
                    movPoint.X = Cursor.Position.X - mouseDownStation.X;
                    movPoint.Y = Cursor.Position.Y - mouseDownStation.Y;
                    mouseDownStation.X = Cursor.Position.X;
                    mouseDownStation.Y = Cursor.Position.Y;
                    lbl.Left += movPoint.X;
                    lbl.Top += movPoint.Y;

                }
                if (lastStationId != stationId)
                {
                    if (Common.dtStationInfo.ContainsKey(stationId) && Common.Instance.dtStationInformation.Any(o => o.Value.StationNo == stationId))
                    {
                        StationInformation station = Common.Instance.dtStationInformation.First(o => o.Value.StationNo == stationId).Value;
                        string stateStr = string.Empty;
                        switch (station.State)
                        {
                            case (int)EStationState.Init:
                                stateStr = "Init";
                                break;
                            case (int)EStationState.Free:
                                stateStr = "Free";
                                break;
                            case (int)EStationState.Busy:
                                stateStr = "Busy";
                                break;
                            case (int)EStationState.Book:
                                stateStr = "Book";
                                break;
                        }
                        string tipString = string.Format("Name : {0}\r\nEnable : {1}\r\nState : {2}\r\nLoadReady : {3}\r\nUnloadReady : {4}\r\nDock : {5}\r\nUndock : {6}\r\nWriteValue : {7}\r\nBindAgv : {8}\r\nUTC : {9}", station.StationName, station.StationEnable, stateStr, station.LoadReady, station.UnloadReady, station.Dock, station.Undock, station.WriteValue, station.bindAgvNo, station.UpdateTime);
                        tlpStation.Dispose();
                        tlpStation = new ToolTip();
                        tlpStation.SetToolTip(lbl, tipString);
                        tlpStation.BackColor = Color.Red;
                        lastStationId = stationId;
                    }
                }
            }
            catch { }
        }



        private static void lbl_InvLocMouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Label lbl = (Label)sender;
                int stationId = (int)lbl.Tag;
                if (isInvLocLeftMouse)
                {
                    Point movPoint = new Point();
                    movPoint.X = Cursor.Position.X - mouseDownStation.X;
                    movPoint.Y = Cursor.Position.Y - mouseDownStation.Y;
                    mouseDownStation.X = Cursor.Position.X;
                    mouseDownStation.Y = Cursor.Position.Y;
                    lbl.Left += movPoint.X;
                    lbl.Top += movPoint.Y;

                }
                if (lastInvLocId != InvLocId)
                {
                    if (Common.dtInvLocInfo.ContainsKey(InvLocId) && Common.Instance.dtInvLocInformation.Any(o => o.Value.InvLocNo == InvLocId))
                    {
                        InventoryLocationInformation invloc = Common.Instance.dtInvLocInformation.First(o => o.Value.InvLocNo == InvLocId).Value;
                        string stateStr = string.Empty;
                        switch (invloc.State)
                        {
                            case (int)EStationState.Init:
                                stateStr = "Init";
                                break;
                            case (int)EStationState.Free:
                                stateStr = "Free";
                                break;
                            case (int)EStationState.Busy:
                                stateStr = "Busy";
                                break;
                            case (int)EStationState.Book:
                                stateStr = "Book";
                                break;
                        }
                        string tipString = string.Format("Name : {0}\r\nEnable : {1}\r\nState : {2}\r\nLoadReady : {3}\r\nUnloadReady : {4}\r\nUTC : {5}", invloc.Name, invloc.InvLocEnable, stateStr, invloc.LoadReady, invloc.UnloadReady,  invloc.UpdateTime);
                        tlpInvLoc.Dispose();
                        tlpInvLoc = new ToolTip();
                        tlpInvLoc.SetToolTip(lbl, tipString);
                        tlpInvLoc.BackColor = Color.Red;
                        lastInvLocId = InvLocId;
                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// 站点点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void lbl_RightClick(object sender, MouseEventArgs e)
        {
            Label lbl = (Label)sender;
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    mouseDownStation.X = Cursor.Position.X;
                    mouseDownStation.Y = Cursor.Position.Y;
                    isStationLeftMouse = true;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (LoginRoler.U_Level >= 2)
                    {
                        int stationId = Convert.ToInt32(lbl.Tag);
                        if (Common.dtStationInfo.ContainsKey(stationId) && Common.Instance.dtStationInformation.Any(o => o.Value.StationNo == stationId))
                        {
                            StationInformation station = Common.Instance.dtStationInformation.First(o => o.Value.StationNo == stationId).Value;
                            switch (station.State)
                            {
                                case (int)EStationState.Init:
                                    if (MessageBox.Show(string.Format("Whether set the station[{0}] as busy", stationId), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                    {
                                        try
                                        {
                                            station.State = (int)EStationState.Busy;
                                            station.LastState = (int)EStationState.Busy;
                                            station.UpdateTime = DateTime.Now;
                                        }
                                        catch { }
                                    }
                                    break;
                                case (int)EStationState.Book:
                                    if (MessageBox.Show(string.Format("Whether set the station[{0}] as free and clear station[{0}] 'BindAgv'", stationId), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                    {
                                        try
                                        {
                                            station.State = (int)EStationState.Busy;
                                            station.LastState = (int)EStationState.Busy;
                                            station.UpdateTime = DateTime.Now;
                                            station.PassRfid = -1;
                                        }
                                        catch { }
                                    }
                                    break;
                                case (int)EStationState.Busy:
                                    if (MessageBox.Show(string.Format("Whether set the station[{0}] as free", stationId), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                    {
                                        try
                                        {
                                            station.State = (int)EStationState.Free;
                                            station.LastState = (int)EStationState.Free;
                                            station.UpdateTime = DateTime.Now;
                                        }
                                        catch { }
                                    }
                                    break;
                                case (int)EStationState.Free:
                                    if (MessageBox.Show(string.Format("Whether set the station[{0}] as busy", stationId), "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                                    {
                                        try
                                        {
                                            station.State = (int)EStationState.Busy;
                                            station.LastState = (int)EStationState.Busy;
                                            station.UpdateTime = DateTime.Now;
                                        }
                                        catch { }
                                    }
                                    break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please login.");
                    }
                }
                //if (LoginRoler.U_Level >= 2)
                //{
                //    Label lbl = (Label)sender;
                //    string idStr = lbl.Name.Replace("lblSP", "");
                //    int stationId = Convert.ToInt32(idStr);
                //    if (e.Button == MouseButtons.Right)  //右键按下
                //    {
                //        StationInfoForm stationInfoForm = new StationInfoForm(stationId);
                //        stationInfoForm.ShowDialog();
                //    }
                //    else if (e.Button == MouseButtons.Left)
                //    {
                //        mouseDownStation.X = Cursor.Position.X;
                //        mouseDownStation.Y = Cursor.Position.Y;
                //        isStationLeftMouse = true;
                //    }
                //}
            }
            catch (Exception)
            {
            }
        }
    }
}
