using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickFix;
using QuickFix.Fields;
using QuickFix.Logger;
using QuickFix.Store;
using QuickFix.Transport;

namespace TBoxDll
{
    public class TBoxSession
    {
        // 创建配置和应用实例
        SessionSettings settings;
        public FixApplication App = new FixApplication();
        FileStoreFactory storeFactory;
        FileLogFactory logFactory;
        SocketInitiator initiator;

        Thread connect_monitor = null;

        /// <summary>
        /// 是否已经登陆
        /// </summary>
        public bool Connected
        {
            get { return initiator.IsLoggedOn; }
        }
        /// <summary>
        /// 最后一次检查是否已登陆
        /// </summary>
        private bool LastLoggedOn = false; 


        /// <summary>
        /// 添加一个事件，当Connected变化时返回
        /// </summary>
        public event EventHandler ConnectedChanged;

        public TBoxSession()
        {
            // 创建配置和应用实例
            settings = new SessionSettings("config.cfg");
            storeFactory = new FileStoreFactory(settings);
            logFactory = new FileLogFactory(settings);
            initiator = new SocketInitiator(App, storeFactory, settings, logFactory);
            connect_monitor = new Thread(new ThreadStart(ConnectMonitor));
            connect_monitor.IsBackground = true;
            connect_monitor.Start();
        }

        private void ConnectMonitor()
        {
            while (true)
            {
                if (ConnectedChanged != null && LastLoggedOn != initiator.IsLoggedOn)
                {
                    LastLoggedOn = initiator.IsLoggedOn;
                    ConnectedChanged(this, new EventArgs());
                }
                Thread.Sleep(1000);
            }
        }

        public void Connect()
        {
            // 启动会话
            initiator.Start();
        }

        public void Disconnect()
        {
            // 停止会话
            initiator.Stop();
        }

    }
}
