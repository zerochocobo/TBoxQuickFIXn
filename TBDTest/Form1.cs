
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
        //ClientID:3006235214  �������˻����Խ���

        public string Account = "FIX1001";
        public string ClientID = "3006200021";

        /// <summary>
        /// �������ID�����ڳ������ԣ�ֱ��ʹ����һ������ID
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
            Debug.WriteLine("�ֲ�����Ϣ��" + req.Text + "��" + req.PosMaintRptID + "��" + req.Account + "���ֲܳ�����" + req.TotalNumPosReports);
        }

        private void App_OnPositionReport(PositionReportResp req)
        {
            //�����ﴦ��ֲֻر�
            Debug.WriteLine("�ֲֻر�:" + req.PosMaintRptID + "��" + req.Account + "����Ʊ��" + req.Symbol + "�۸�" + req.SettlPrice + ",ʣ������:" + req.LeavesQty);
        }

        private void App_OnCancelReject(CancelRejectResp req)
        {
            //�����ﴦ�����ر�
            Debug.WriteLine("�����ر�:" + req.ClOrdID + " " + req.OrdStatus + " " + req.Text);
        }

        private void App_OnExecutionReport(ExecReportResp req)
        {
            //�����ﴦ�����ر�
            Debug.WriteLine("�����ر�:" + req.ClOrdID + " " + req.OrdStatus + " " + req.Text);
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
            //�����洦������״̬�仯
            if (session.Connected)
            {
                //�̰߳�ȫ�����ð�ť�ı�
                SetConnectBtnText("�Ѿ�����");
            }
            else
            {
                SetConnectBtnText("�Ѿ��Ͽ�");
            }
        }

        private void newOrderBtn_Click(object sender, EventArgs e)
        {
            if (session.Connected == false)
            {
                MessageBox.Show("��������");
                return;
            }
            lastOrdrId = Guid.NewGuid().ToString();
            string clOrdID = lastOrdrId; //Guid.NewGuid().ToString();// "123123";//���ظ��Ķ������
            string execBroker = "123123"; // �Լ��Ķ���ϵͳ���ɵĶ�����ţ������ر�ʱ�᷵��
            string account = Account;
            string clientID = ClientID;
            string symbol = "sz000001";
            var side = SideEnum.Buy;//1 - ����,2 - ����,3-��������,4-��ȯ����,5 - ��ȯ��ȯ,6-��ȯ����,7-�������
            int orderQty = 100;
            var ordType = OrdTypeEnum.Limit;//1 - Market,  2 - Limit, 7 - LimitOrBetter(��ǿ�޼۵����۹�ר�ã�59 = 0)
            decimal price = 100.0m;
            NewOrderReq order = new NewOrderReq(clOrdID, clOrdID, account, clientID, symbol, side, orderQty, ordType, price);
            session.App.SendNewOrderSingle(order);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (session.Connected == false)
            {
                MessageBox.Show("��������");
                return;
            }
            if (String.IsNullOrEmpty(lastOrdrId))
            {
                MessageBox.Show("���ȷ����¶���");
                return;
            }
            string clOrdID = Guid.NewGuid().ToString();// ����ʱʹ����ֵ��
            string origClOrdID = lastOrdrId;//ʹ��ԭ�ж���ֵ
            string symbol = "sz000001";
            var side = SideEnum.Buy;
            OrderCancelReq req = new OrderCancelReq(clOrdID, origClOrdID, symbol, side);
            session.App.SendOrderCancelRequest(req);
        }

        private void positionsBtn_Click(object sender, EventArgs e)
        {
            if (session.Connected == false)
            {
                MessageBox.Show("��������");
                return;
            }
            PositionsReq req = new PositionsReq(Guid.NewGuid().ToString(), Account);
            session.App.SendPositionsRequest(req);
        }
    }
}