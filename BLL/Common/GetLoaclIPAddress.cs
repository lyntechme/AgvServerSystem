using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;

namespace BLL
{
    public class GetLoaclIPAddress
    {
        #region 获取本机本地ip地址
        public static IPAddress GetServerIP()
        {
            IPAddress ipaddress = IPAddress.Parse("0.0.0.0");
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                {
                    foreach (UnicastIPAddressInformation ip in
                        ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipaddress = ip.Address;
                        }
                    }
                }
            }
            return ipaddress;
        }
        #endregion

        #region 获取本地连接IP地址、无线连接IP地址
        /// <summary>
        /// 获取本地连接IP地址、无线连接IP地址
        /// </summary>
        /// <param name="k">0:本地连接，1:本地连接1，2:无线网络连接</param>
        /// <returns></returns>
        public static IPAddress GetIP(int k)
        {
            NetworkInterface[] interfaces = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            int len = interfaces.Length;
            IPAddress[] mip = { IPAddress.Parse("0.0.0.0"), IPAddress.Parse("0.0.0.0"), IPAddress.Parse("0.0.0.0") };

            for (int i = 0; i < len; i++)
            {
                NetworkInterface ni = interfaces[i];

                if (ni.Name == "本地连接")
                {
                    IPInterfaceProperties property = ni.GetIPProperties();
                    foreach (UnicastIPAddressInformation ip in property.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            mip[0] = ip.Address;
                        }
                    }
                }
                else if (ni.Name == "本地连接2")
                {
                    IPInterfaceProperties property = ni.GetIPProperties();
                    foreach (UnicastIPAddressInformation ip in property.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            mip[1] = ip.Address;
                        }
                    }
                }
                else if (ni.Name == "无线网络连接")
                {
                    IPInterfaceProperties property = ni.GetIPProperties();
                    foreach (UnicastIPAddressInformation ip in property.UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            mip[2] = ip.Address;
                        }
                    }
                }
            }
            return mip[k];
        }
        #endregion //获取本地连接IP地址、无线连接IP地址
    }
}
