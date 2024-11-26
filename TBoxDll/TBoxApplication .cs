using QuickFix;
using QuickFix.Fields;
using System.Diagnostics;
using TBoxDll.TBoxModel;
using TBoxDll.CustomModel;

namespace TBoxDll
{
    public class FixApplication : MessageCracker, QuickFix.IApplication
    {

        //SessionID _session = null;
        Session _session = null;


        #region 自定义事件供前端获取

        public event ExecutionReportHandler OnExecutionReport;
        public delegate void ExecutionReportHandler(ExecReportResp req);

        public event CancelRejectHandler OnCancelReject;
        public delegate void CancelRejectHandler(CancelRejectResp req);

        public event RequestForPositionsAckHandler OnRequestForPositionsAck;
        public delegate void RequestForPositionsAckHandler(PositionsAckResp req);

        public event PositionReportHandler OnPositionReport;
        public delegate void PositionReportHandler(PositionReportResp req);
        

        #endregion

        #region IApplication interface overrides

        public void OnCreate(SessionID sessionID)
        {
            _session = Session.LookupSession(sessionID);
        }

        public void OnLogon(SessionID sessionID)
        {
            Debug.WriteLine("Logon - " + sessionID.ToString());
        }

        public void OnLogout(SessionID sessionID) { 
            Debug.WriteLine("Logout - " + sessionID.ToString()); 
        }

        public void ToAdmin(QuickFix.Message message, SessionID sessionID)
        {
            Debug.WriteLine("ToAdmin:  " + message.ToString());
        }

        public void FromAdmin(QuickFix.Message message, SessionID sessionID)
        {
            Debug.WriteLine("FromAdmin:  " + message.ToString());
        }

        public void ToApp(QuickFix.Message message, SessionID sessionID)
        {
            Debug.WriteLine("ToApp:  " + message.ToString());
        }

        public void FromApp(QuickFix.Message message, SessionID sessionID)
        {
            //Debug.WriteLine("FromApp:  " + message.ToString());
            if (message.Header.GetString(35) == RequestForPositionsAck.MsgType)
            {
                PositionsAckResp resp = new PositionsAckResp();
                resp.PosMaintRptID = message.IsSetField(Tags.PosMaintRptID) ? message.GetString(Tags.PosMaintRptID) : "";
                resp.PosReqID = message.IsSetField(Tags.PosReqID) ? message.GetString(Tags.PosReqID) : "";
                resp.TotalNumPosReports = message.IsSetField(Tags.TotalNumPosReports) ? message.GetInt(Tags.TotalNumPosReports) : 0;
                resp.Account = message.IsSetField(Tags.Account) ? message.GetString(Tags.Account) : "";
                resp.Text = message.IsSetField(Tags.Text) ? message.GetString(Tags.Text) : "";
                resp.EncodedTextLen = message.IsSetField(Tags.EncodedTextLen) ? message.GetInt(Tags.EncodedTextLen) : 0;
                resp.EncodedText = message.IsSetField(Tags.EncodedText) ? message.GetString(Tags.EncodedText) : "";
                if (OnRequestForPositionsAck != null)
                {
                    OnRequestForPositionsAck(resp);
                }
            }
            else if (message.Header.GetString(35) == PositionReport.MsgType)
            {
                PositionReportResp resp = new PositionReportResp();
                resp.PosMaintRptID = message.IsSetField(Tags.PosMaintRptID) ? message.GetString(Tags.PosMaintRptID) : "";
                resp.PosReqID = message.IsSetField(Tags.PosReqID) ? message.GetString(Tags.PosReqID) : "";
                resp.TotalNumPosReports = message.IsSetField(Tags.TotalNumPosReports) ? message.GetInt(Tags.TotalNumPosReports) : 0;
                resp.SecurityExchange = message.IsSetField(Tags.SecurityExchange) ? message.GetString(Tags.SecurityExchange) : "";
                string exchange = "sh";
                if(resp.SecurityExchange == "BJ")
                {
                    exchange = "bj";
                }
                else if (resp.SecurityExchange == "SZ")
                {
                    exchange = "sz";
                }
                resp.Symbol = message.IsSetField(Tags.Symbol) ? exchange + message.GetString(Tags.Symbol) : "";
                resp.SettlCurrency = message.IsSetField(Tags.SettlCurrency) ? message.GetString(Tags.SettlCurrency) : "";
                resp.Account = message.IsSetField(Tags.Account) ? message.GetString(Tags.Account) : "";
                resp.ClientID = message.IsSetField(Tags.ClientID) ? message.GetString(Tags.ClientID) : "";
                resp.Currency = message.IsSetField(Tags.Currency) ? message.GetString(Tags.Currency) : "";
                resp.SettlPrice = message.IsSetField(Tags.SettlPrice) ? message.GetDecimal(Tags.SettlPrice) : 0;
                resp.LeavesQty = message.IsSetField(Tags.LeavesQty) ? message.GetDecimal(Tags.LeavesQty) : 0;
                resp.BuyVolume = message.IsSetField(Tags.BuyVolume) ? message.GetDecimal(Tags.BuyVolume) : 0;
                resp.SellVolume = message.IsSetField(Tags.SellVolume) ? message.GetDecimal(Tags.SellVolume) : 0;

                resp.Account = message.IsSetField(Tags.Account) ? message.GetString(Tags.Account) : "";
                resp.Text = message.IsSetField(Tags.Text) ? message.GetString(Tags.Text) : "";
                resp.EncodedTextLen = message.IsSetField(Tags.EncodedTextLen) ? message.GetInt(Tags.EncodedTextLen) : 0;
                resp.EncodedText = message.IsSetField(Tags.EncodedText) ? message.GetString(Tags.EncodedText) : "";
                if (OnPositionReport != null)
                {
                    OnPositionReport(resp);
                }
            }
            else
            {
                try
                {
                    Crack(message, sessionID);
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("Crack message error: " + ex.Message);
                }
            }
        }

        #endregion

        #region MessageCracker overloads


        public void OnMessage(QuickFix.FIX42.ExecutionReport msg, SessionID s)
        {
            ExecReportResp resp = new ExecReportResp();
            resp.ClOrdID = msg.IsSetClOrdID()?msg.ClOrdID.getValue():"";
            resp.OrigClOrdID = msg.IsSetOrigClOrdID() ? msg.OrigClOrdID.getValue() : "";
            resp.OrderID = msg.IsSetOrderID() ? msg.OrderID.getValue() : "";
            resp.Account = msg.IsSetAccount() ? msg.Account.getValue() : "";
            resp.ClientID = msg.IsSetClientID() ? msg.ClientID.getValue() : "";
            resp.SecondaryOrderID = msg.IsSetSecondaryOrderID() ? msg.SecondaryOrderID.getValue() : "";
            //excel文件中的526——SecondaryClOrdID在xml中没有定义
            //resp.SecondaryClOrdID = msg.SecondaryOrderID
            resp.ExecBroker = msg.IsSetExecBroker() ? msg.ExecBroker.getValue() : "";
            resp.ExecID = msg.IsSetExecID() ? msg.ExecID.getValue() : "";
            resp.ExecTransType = msg.IsSetExecTransType() ? (ExecTransTypeEnum)msg.ExecTransType.getValue() : ExecTransTypeEnum.Unknown;
            resp.ExecRefID = msg.IsSetExecRefID() ? msg.ExecRefID.getValue() : "";
            resp.ExecType = msg.IsSetExecType() ? (OrdStatusEnum)msg.ExecType.getValue() : OrdStatusEnum.Unknown;
            resp.OrdStatus = msg.IsSetOrdStatus() ? (OrdStatusEnum)msg.OrdStatus.getValue() : OrdStatusEnum.Unknown;
            resp.Symbol = msg.IsSetSymbol() ? msg.Symbol.getValue() : "";
            resp.Side = msg.IsSetSide() ? (SideEnum)msg.Side.getValue() : SideEnum.Unknown;
            resp.OrderQty = msg.IsSetOrderQty() ? msg.OrderQty.getValue() : 0;
            resp.Price = msg.IsSetPrice() ? msg.Price.getValue() : 0;
            resp.OrdType = msg.IsSetOrdType() ? (OrdTypeEnum)msg.OrdType.getValue() : OrdTypeEnum.Unknown;
            resp.TimeInForce = msg.IsSetTimeInForce() ? (TimeInForceEnum)msg.TimeInForce.getValue() : TimeInForceEnum.Unknown;
            resp.LastQty = msg.IsSetLastShares() ? msg.LastShares.getValue() : 0;
            resp.LastPrx = msg.IsSetLastPx() ? msg.LastPx.getValue() : 0;
            resp.LeavesQty = msg.IsSetLeavesQty() ? msg.LeavesQty.getValue() : 0;
            resp.CumQty = msg.IsSetCumQty() ? msg.CumQty.getValue() : 0;
            resp.AvgPx = msg.IsSetAvgPx() ? msg.AvgPx.getValue() : 0;
            resp.Text = msg.IsSetText() ? msg.Text.getValue() : "";
            resp.TransactTime = msg.IsSetTransactTime() ? msg.TransactTime.getValue() : DateTime.UtcNow.AddHours(8);
            resp.CxlQty = msg.IsSetOrderQty() ? msg.OrderQty.getValue() : 0;

            if (OnExecutionReport != null)
            {
                OnExecutionReport(resp);
            }

        }

        public void OnMessage(QuickFix.FIX42.OrderCancelReject msg, SessionID s)
        {
            CancelRejectResp resp = new CancelRejectResp();
            resp.ClOrdID = msg.IsSetClOrdID() ? msg.ClOrdID.getValue() : "";
            resp.OrigClOrdID = msg.IsSetOrigClOrdID() ? msg.OrigClOrdID.getValue() : "";
            resp.OrdStatus = msg.IsSetOrdStatus() ? (OrdStatusEnum)msg.OrdStatus.getValue() : OrdStatusEnum.Unknown;
            resp.OrderID = msg.IsSetOrderID() ? msg.OrderID.getValue() : "";
            resp.Account = msg.IsSetAccount() ? msg.Account.getValue() : "";
            resp.Text = msg.IsSetText() ? msg.Text.getValue() : "";
            resp.TransactTime = msg.IsSetTransactTime() ? msg.TransactTime.getValue() : DateTime.UtcNow.AddHours(8);
            resp.CxlRejResponseTo = msg.IsSetCxlRejResponseTo() ? (CxlRejResponseToEnum)msg.CxlRejResponseTo.getValue() : CxlRejResponseToEnum.Unknown;

            if (OnCancelReject != null)
            {
                OnCancelReject(resp);
            }
        }


        #endregion

        private void SendMessage(QuickFix.FIX42.Message m)
        {
            if (_session != null)
                _session.Send(m);
            else
            {
                // This probably won't ever happen.
                Debug.WriteLine("Can't send message: session not created.");
            }
        }

        /// <summary>
        /// 发送新的订单信息
        /// </summary>
        /// <param name="clOrdID">订单编号</param>
        /// <param name="account"></param>
        /// <param name="clientID"></param>
        public void SendNewOrderSingle(NewOrderReq req)
        {
            if (_session == null)
            {
                Debug.WriteLine("Session not logged on.");
                return;
            }
            var newOrder = new TBoxNewOrderSingle();
            newOrder.ClOrdID = new ClOrdID(req.ClOrdID);
            newOrder.HandlInst = new HandlInst(req.HandlInst);
            newOrder.Account = new Account(req.Account);
            newOrder.ClientID = new ClientID(req.ClientID);
            newOrder.SecurityExchange = new SecurityExchange(req.SecurityExchange);
            newOrder.SecurityType = new SecurityType(req.SecurityType);
            newOrder.Symbol = new Symbol(req.Symbol);
            newOrder.Side = new Side((char)req.Side);
            newOrder.OrderQty = new OrderQty(req.OrderQty);
            newOrder.Price = new Price(req.Price);
            newOrder.OrdType = new OrdType((char)req.OrdType);
            newOrder.TimeInForce = new TimeInForce((char)req.TimeInForce);
            newOrder.TransactTime = new TransactTime(req.TransactTime);
            newOrder.Currency = new Currency(req.Currency);
            if (req.ExecBroker != null)
            {
                newOrder.ExecBroker = new ExecBroker(req.ExecBroker);
            }
            if (req.ExecInst != null)
            {
                newOrder.ExecInst = new ExecInst(req.ExecInst);
            }
            if (req.ExpireTime != null)
            {
                newOrder.ExpireTime = new ExpireTime(req.ExpireTime.Value);
            }
            if (req.EffectiveTime != null)
            {
                newOrder.EffectiveTime = new EffectiveTime(req.EffectiveTime.Value);
            }
            if (req.NetInfo != null)
            {
                newOrder.NetInfo = new NetInfo(req.NetInfo);
            }
            if (req.IPAddress != null)
            {
                newOrder.IPAddress = new IPAddress(req.IPAddress);
            }
            if (req.MACAddress != null)
            {
                newOrder.MACAddress = new MACAddress(req.MACAddress);
            }
            if (req.Strategy != null)
            {
                newOrder.Strategy = new Strategy(req.Strategy);
            }
            if (req.StrategyParam != null)
            {
                newOrder.StrategyParam = new StrategyParam(req.StrategyParam);
            }
            if (req.Text != null)
            {
                newOrder.Text = new Text(req.Text);
            }
            try
            {
                // 通过 QuickFix Session 发送消息
                SendMessage(newOrder);
                Debug.WriteLine("NewOrderSingleMessage sent successfully!");
            }
            catch (SessionNotFound ex)
            {
                Debug.WriteLine("Failed to send message: " + ex.Message);
            }
        }

        public void SendOrderCancelRequest(OrderCancelReq req)
        {
            if (_session == null)
            {
                Debug.WriteLine("Session not logged on.");
                return;
            }
            var newReq = new QuickFix.FIX42.OrderCancelRequest();
            newReq.ClOrdID = new ClOrdID(req.ClOrdID);
            newReq.OrigClOrdID = new OrigClOrdID(req.OrigClOrdID);
            newReq.Symbol = new Symbol(req.Symbol);
            newReq.Side = new Side((char)req.Side);
            newReq.TransactTime = new TransactTime(req.TransactTime);
            if (req.OrderID != null)
            {
                newReq.OrderID = new OrderID(req.OrderID);
            }
            if (req.ClientID != null)
            {
                newReq.ClientID = new ClientID(req.ClientID);
            }
            if (req.Account != null)
            {
                newReq.Account = new Account(req.Account);
            }
            if (req.SecurityType != null)
            {
                newReq.SecurityType = new SecurityType(req.SecurityType);
            }
            if (req.Text != null)
            {
                newReq.Text = new Text(req.Text);
            }
            try
            {
                // 通过 QuickFix Session 发送消息
                SendMessage(newReq);
                Debug.WriteLine("OrderCancelRequest sent successfully!");
            }
            catch (SessionNotFound ex)
            {
                Debug.WriteLine("Failed to send message: " + ex.Message);
            }
        }

        public void SendPositionsRequest(PositionsReq req)
        {
            if (_session == null)
            {
                Debug.WriteLine("Session not logged on.");
                return;
            }
            var newReq = new RequestForPositions();
            newReq.PosReqID = new PosReqID(req.PosReqID);
            newReq.TransactTime = new TransactTime(req.TransactTime);
            if (req.Symbol != null)
            {
                newReq.Symbol = new Symbol(req.Symbol);
            }
            if (req.Currency != null)
            {
                newReq.Currency = new Currency(req.Currency);
            }
            if (req.Account != null)
            {
                newReq.Account = new Account(req.Account);
            }
            if (req.EncodedTextLen > 0)
            {
                newReq.EncodedTextLen = new EncodedTextLen(req.EncodedTextLen);
            }
            if (req.EncodedText != null)
            {
                newReq.EncodedText = new EncodedText(req.EncodedText);
            }
            if (req.Text != null)
            {
                newReq.Text = new Text(req.Text);
            }
            try
            {
                // 通过 QuickFix Session 发送消息
                SendMessage(newReq);
                Debug.WriteLine("PositionsRequest sent successfully!");
            }
            catch (SessionNotFound ex)
            {
                Debug.WriteLine("Failed to send message: " + ex.Message);
            }
        }
    }
}
