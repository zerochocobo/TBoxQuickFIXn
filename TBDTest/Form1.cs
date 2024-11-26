
using Microsoft.VisualBasic;
using QuickFix.Fields;
using System.Diagnostics;
using TBoxDll;
using TBoxDll.CustomModel;

namespace TBDTest
{
    public partial class Form1 : Form
    {
        //Account:FIX1001
        //ClientID:3006200021

        //Account:FIX10002
        //ClientID:3006235214  这两组账户可以交易

        public string Account = "FIX1001";
        public string ClientID = "3006200021";

        /// <summary>
        /// 最近订单ID，用于撤单测试，直接使用上一个订单ID
        /// </summary>
        string lastOrdrId = "";


        TBoxSession session = new TBoxSession();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            session.ConnectedChanged += new EventHandler(session_ConnectedChanged);
            session.App.OnExecutionReport += App_OnExecutionReport;
            session.App.OnCancelReject += App_OnCancelReject;
            session.App.OnPositionReport += App_OnPositionReport;
            session.App.OnRequestForPositionsAck += App_OnRequestForPositionsAck;
        }

        private void App_OnRequestForPositionsAck(PositionsAckResp req)
        {
            Debug.WriteLine("持仓总信息：" + req.Text + "，" + req.PosMaintRptID + "，" + req.Account + "，总持仓数：" + req.TotalNumPosReports);
        }

        private void App_OnPositionReport(PositionReportResp req)
        {
            //在这里处理持仓回报
            Debug.WriteLine("持仓回报:" + req.PosMaintRptID + "，" + req.Account + "，股票：" + req.Symbol + "价格：" + req.SettlPrice + ",剩余数量:" + req.LeavesQty);
        }

        private void App_OnCancelReject(CancelRejectResp req)
        {
            //在这里处理撤单回报
            Debug.WriteLine("撤单回报:" + req.ClOrdID + " " + req.OrdStatus + " " + req.Text);
        }

        private void App_OnExecutionReport(ExecReportResp req)
        {
            //在这里处理订单回报
            Debug.WriteLine("订单回报:" + req.ClOrdID + " " + req.OrdStatus + " " + req.Text);
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (session.Connected)
            {
                session.Disconnect();
            }
            else
            {
                session.Connect();
            }
        }
        delegate void SetConnectBtnTextCallback(string text);
        public void SetConnectBtnText(string text)
        {
            if (this.connectBtn.InvokeRequired)
            {
                SetConnectBtnTextCallback d = new SetConnectBtnTextCallback(SetConnectBtnText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.connectBtn.Text = text;
            }
        }
        private void session_ConnectedChanged(object? sender, EventArgs e)
        {
            //在外面处理连接状态变化
            if (session.Connected)
            {
                //线程安全的设置按钮文本
                SetConnectBtnText("已经连接");
            }
            else
            {
                SetConnectBtnText("已经断开");
            }
        }

        private void newOrderBtn_Click(object sender, EventArgs e)
        {
            if (session.Connected == false)
            {
                MessageBox.Show("请先连接");
                return;
            }
            lastOrdrId = Guid.NewGuid().ToString();
            string clOrdID = lastOrdrId; //Guid.NewGuid().ToString();// "123123";//不重复的订单编号
            string execBroker = "123123"; // 自己的订单系统生成的订单编号，订单回报时会返回
            string account = Account;
            string clientID = ClientID;
            string symbol = "sz000001";
            var side = SideEnum.Buy;//1 - 买入,2 - 卖出,3-融资买入,4-融券卖出,5 - 买券还券,6-卖券还款,7-零股卖出
            int orderQty = 100;
            var ordType = OrdTypeEnum.Limit;//1 - Market,  2 - Limit, 7 - LimitOrBetter(增强限价单，港股专用，59 = 0)
            decimal price = 100.0m;
            NewOrderReq order = new NewOrderReq(clOrdID, clOrdID, account, clientID, symbol, side, orderQty, ordType, price);
            session.App.SendNewOrderSingle(order);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (session.Connected == false)
            {
                MessageBox.Show("请先连接");
                return;
            }
            if (String.IsNullOrEmpty(lastOrdrId))
            {
                MessageBox.Show("请先发送新订单");
                return;
            }
            string clOrdID = Guid.NewGuid().ToString();// 撤销时使用新值；
            string origClOrdID = lastOrdrId;//使用原有订单值
            string symbol = "sz000001";
            var side = SideEnum.Buy;
            OrderCancelReq req = new OrderCancelReq(clOrdID, origClOrdID, symbol, side);
            session.App.SendOrderCancelRequest(req);
        }

        private void positionsBtn_Click(object sender, EventArgs e)
        {
            if (session.Connected == false)
            {
                MessageBox.Show("请先连接");
                return;
            }
            PositionsReq req = new PositionsReq(Guid.NewGuid().ToString(), Account);
            session.App.SendPositionsRequest(req);
        }
    }
}